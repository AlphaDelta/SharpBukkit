// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace net.minecraft.src
{
    public class World : net.minecraft.src.IBlockAccess
    {
        // Referenced classes of package net.minecraft.src:
        //            IBlockAccess, WorldProvider, MapStorage, ISaveHandler, 
        //            WorldInfo, ChunkProvider, IChunkProvider, IProgressUpdate, 
        //            Chunk, Material, Block, IWorldAccess, 
        //            EnumSkyBlock, Vec3D, MathHelper, Entity, 
        //            EntityPlayer, AxisAlignedBB, NextTickListEntry, TileEntity, 
        //            BlockFire, BlockFluid, Explosion, MetadataChunkBlock, 
        //            SpawnerAnimals, ChunkCoordIntPair, EntityLightningBolt, WorldChunkManager, 
        //            BiomeGenBase, ChunkCache, Pathfinder, ChunkCoordinates, 
        //            MovingObjectPosition, PathEntity, MapDataBase
        public virtual net.minecraft.src.WorldChunkManager GetWorldChunkManager()
        {
            return worldProvider.worldChunkMgr;
        }

        public World(net.minecraft.src.ISaveHandler isavehandler, string s, long l, net.minecraft.src.WorldProvider
             worldprovider)
        {
            scheduledUpdatesAreImmediate = false;
            LightingUpdateQueue = new List<MetadataChunkBlock>();
            loadedEntityList = new List<Entity>();
            unloadedEntityList = new List<Entity>();
            scheduledTickTreeSet = new SortedSet<NextTickListEntry>();
            scheduledTickSet = new HashSet<NextTickListEntry>();
            loadedTileEntityList = new List<TileEntity>();
            field_20912_E = new List<TileEntity>();
            playerEntities = new List<EntityPlayer>();
            lightningEntities = new List<Entity>();
            field_6159_E = unchecked((long)(0xffffffL));
            skylightSubtracted = 0;
            distHashCounter = (new SharpBukkitLive.SharpBukkit.SharpRandom()).NextInt();
            field_27075_F = 0;
            field_27080_i = 0;
            editingBlocks = false;
            lockTimestamp = Sharpen.Runtime.CurrentTimeMillis();
            autosavePeriod = 40;
            rand = new SharpBukkitLive.SharpBukkit.SharpRandom();
            isNewWorld = false;
            worldAccesses = new List<IWorldAccess>();
            field_9207_I = new List<AxisAlignedBB>();
            field_4265_J = 0;
            spawnHostileMobs = true;
            spawnPeacefulMobs = true;
            activeChunkSet = new HashSet<ChunkCoordIntPair>();
            ambientTickCountdown = rand.Next(12000);
            field_778_L = new List<Entity>();
            singleplayerWorld = false;
            worldFile = isavehandler;
            field_28105_z = new net.minecraft.src.MapStorage(isavehandler);
            worldInfo = isavehandler.Func_22096_c();
            isNewWorld = worldInfo == null;
            if (worldprovider != null)
            {
                worldProvider = worldprovider;
            }
            else
            {
                if (worldInfo != null && worldInfo.GetDimension() == -1)
                {
                    worldProvider = net.minecraft.src.WorldProvider.Func_4091_a(-1);
                }
                else
                {
                    worldProvider = net.minecraft.src.WorldProvider.Func_4091_a(0);
                }
            }
            bool flag = false;
            if (worldInfo == null)
            {
                worldInfo = new net.minecraft.src.WorldInfo(l, s);
                flag = true;
            }
            else
            {
                worldInfo.SetLevelName(s);
            }
            worldProvider.RegisterWorld(this);
            chunkProvider = CreateChunkProvider();
            if (flag)
            {
                GenerateSpawnPoint();
            }
            CalculateInitialSkylight();
            Func_27070_x();
        }

        protected internal virtual net.minecraft.src.IChunkProvider CreateChunkProvider()
        {
            net.minecraft.src.IChunkLoader ichunkloader = worldFile.Func_22092_a(worldProvider
                );
            return new net.minecraft.src.ChunkProvider(this, ichunkloader, worldProvider.GetChunkProvider
                ());
        }

        protected internal virtual void GenerateSpawnPoint()
        {
            worldChunkLoadOverride = true;
            int i = 0;
            byte byte0 = 64;
            int j;
            for (j = 0; !worldProvider.CanCoordinateBeSpawn(i, j); j += rand.Next(64) - rand
                .NextInt(64))
            {
                i += rand.Next(64) - rand.Next(64);
            }
            worldInfo.SetSpawnPosition(i, byte0, j);
            worldChunkLoadOverride = false;
        }

        public virtual int GetFirstUncoveredBlock(int i, int j)
        {
            int k;
            for (k = 63; !IsAirBlock(i, k + 1, j); k++)
            {
            }
            return GetBlockId(i, k, j);
        }

        public virtual void SaveWorld(bool flag, net.minecraft.src.IProgressUpdate iprogressupdate)
        {
            if (!chunkProvider.CanSave())
            {
                return;
            }
            if (iprogressupdate != null)
            {
                iprogressupdate.Func_438_a("Saving level");
            }
            SaveLevel();
            if (iprogressupdate != null)
            {
                iprogressupdate.DisplayLoadingString("Saving chunks");
            }
            chunkProvider.SaveChunks(flag, iprogressupdate);
        }

        private void SaveLevel()
        {
            CheckSessionLock();
            worldFile.Func_22095_a(worldInfo, playerEntities);
            field_28105_z.Func_28176_a();
        }

        public virtual int GetBlockId(int x, int y, int z)
        {
            if (x < unchecked((int)(0xfe17b800)) || z < unchecked((int)(0xfe17b800)) || x >=
                0x1e84800 || z > 0x1e84800)
            {
                return 0;
            }
            if (y < 0)
            {
                return 0;
            }
            if (y >= 128)
            {
                return 0;
            }
            else
            {
                return GetChunkFromChunkCoords(x >> 4, z >> 4).GetBlockID(x & 0xf, y, z & 0xf);
            }
        }

        public virtual bool IsAirBlock(int i, int j, int k)
        {
            return GetBlockId(i, j, k) == 0;
        }

        public virtual bool BlockExists(int i, int j, int k)
        {
            if (j < 0 || j >= 128)
            {
                return false;
            }
            else
            {
                return ChunkExists(i >> 4, k >> 4);
            }
        }

        public virtual bool DoChunksNearChunkExist(int i, int j, int k, int l)
        {
            return CheckChunksExist(i - l, j - l, k - l, i + l, j + l, k + l);
        }

        public virtual bool CheckChunksExist(int i, int j, int k, int l, int i1, int j1)
        {
            if (i1 < 0 || j >= 128)
            {
                return false;
            }
            i >>= 4;
            j >>= 4;
            k >>= 4;
            l >>= 4;
            i1 >>= 4;
            j1 >>= 4;
            for (int k1 = i; k1 <= l; k1++)
            {
                for (int l1 = k; l1 <= j1; l1++)
                {
                    if (!ChunkExists(k1, l1))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool ChunkExists(int i, int j)
        {
            return chunkProvider.ChunkExists(i, j);
        }

        public virtual net.minecraft.src.Chunk GetChunkFromBlockCoords(int i, int j)
        {
            return GetChunkFromChunkCoords(i >> 4, j >> 4);
        }

        public virtual net.minecraft.src.Chunk GetChunkFromChunkCoords(int i, int j)
        {
            return chunkProvider.ProvideChunk(i, j);
        }

        public virtual bool SetBlockAndMetadata(int i, int j, int k, int l, int i1)
        {
            if (i < unchecked((int)(0xfe17b800)) || k < unchecked((int)(0xfe17b800)) || i >=
                0x1e84800 || k > 0x1e84800)
            {
                return false;
            }
            if (j < 0)
            {
                return false;
            }
            if (j >= 128)
            {
                return false;
            }
            else
            {
                net.minecraft.src.Chunk chunk = GetChunkFromChunkCoords(i >> 4, k >> 4);
                return chunk.SetBlockIDWithMetadata(i & 0xf, j, k & 0xf, l, i1);
            }
        }

        public virtual bool SetBlock(int i, int j, int k, int l)
        {
            if (i < unchecked((int)(0xfe17b800)) || k < unchecked((int)(0xfe17b800)) || i >=
                0x1e84800 || k > 0x1e84800)
            {
                return false;
            }
            if (j < 0)
            {
                return false;
            }
            if (j >= 128)
            {
                return false;
            }
            else
            {
                net.minecraft.src.Chunk chunk = GetChunkFromChunkCoords(i >> 4, k >> 4);
                return chunk.SetBlockID(i & 0xf, j, k & 0xf,
                    l);
            }
        }

        public virtual net.minecraft.src.Material GetBlockMaterial(int i, int j, int k)
        {
            int l = GetBlockId(i, j, k);
            if (l == 0)
            {
                return net.minecraft.src.Material.air;
            }
            else
            {
                return net.minecraft.src.Block.blocksList[l].blockMaterial;
            }
        }

        public virtual int GetBlockMetadata(int i, int j, int k)
        {
            if (i < unchecked((int)(0xfe17b800)) || k < unchecked((int)(0xfe17b800)) || i >=
                0x1e84800 || k > 0x1e84800)
            {
                return 0;
            }
            if (j < 0)
            {
                return 0;
            }
            if (j >= 128)
            {
                return 0;
            }
            else
            {
                net.minecraft.src.Chunk chunk = GetChunkFromChunkCoords(i >> 4, k >> 4);
                i &= 0xf;
                k &= 0xf;
                return chunk.GetBlockMetadata(i, j, k);
            }
        }

        public virtual void SetBlockMetadataWithNotify(int i, int j, int k, int l)
        {
            if (SetBlockMetadata(i, j, k, l))
            {
                int i1 = GetBlockId(i, j, k);
                if (net.minecraft.src.Block.requiresSelfNotify[i1 & 0xff])
                {
                    NotifyBlockChange(i, j, k, i1);
                }
                else
                {
                    NotifyBlocksOfNeighborChange(i, j, k, i1);
                }
            }
        }

        public virtual bool SetBlockMetadata(int i, int j, int k, int l)
        {
            if (i < unchecked((int)(0xfe17b800)) || k < unchecked((int)(0xfe17b800)) || i >=
                0x1e84800 || k > 0x1e84800)
            {
                return false;
            }
            if (j < 0)
            {
                return false;
            }
            if (j >= 128)
            {
                return false;
            }
            else
            {
                net.minecraft.src.Chunk chunk = GetChunkFromChunkCoords(i >> 4, k >> 4);
                i &= 0xf;
                k &= 0xf;
                chunk.SetBlockMetadata(i, j, k, l);
                return true;
            }
        }

        public virtual bool SetBlockWithNotify(int i, int j, int k, int l)
        {
            if (SetBlock(i, j, k, l))
            {
                NotifyBlockChange(i, j, k, l);
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool SetBlockAndMetadataWithNotify(int i, int j, int k, int l, int
             i1)
        {
            if (SetBlockAndMetadata(i, j, k, l, i1))
            {
                NotifyBlockChange(i, j, k, l);
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual void MarkBlockNeedsUpdate(int i, int j, int k)
        {
            for (int l = 0; l < worldAccesses.Count; l++)
            {
                ((net.minecraft.src.IWorldAccess)worldAccesses[l]).MarkBlockNeedsUpdate(i, j, k);
            }
        }

        protected internal virtual void NotifyBlockChange(int i, int j, int k, int l)
        {
            MarkBlockNeedsUpdate(i, j, k);
            NotifyBlocksOfNeighborChange(i, j, k, l);
        }

        public virtual void MarkBlocksDirtyVertical(int i, int j, int k, int l)
        {
            if (k > l)
            {
                int i1 = l;
                l = k;
                k = i1;
            }
            MarkBlocksDirty(i, k, j, i, l, j);
        }

        public virtual void MarkBlockAsNeedsUpdate(int i, int j, int k)
        {
            for (int l = 0; l < worldAccesses.Count; l++)
            {
                ((net.minecraft.src.IWorldAccess)worldAccesses[l]).MarkBlockRangeNeedsUpdate(i, j
                    , k, i, j, k);
            }
        }

        public virtual void MarkBlocksDirty(int i, int j, int k, int l, int i1, int j1)
        {
            for (int k1 = 0; k1 < worldAccesses.Count; k1++)
            {
                ((net.minecraft.src.IWorldAccess)worldAccesses[k1]).MarkBlockRangeNeedsUpdate(i,
                    j, k, l, i1, j1);
            }
        }

        public virtual void NotifyBlocksOfNeighborChange(int i, int j, int k, int l)
        {
            NotifyBlockOfNeighborChange(i - 1, j, k, l);
            NotifyBlockOfNeighborChange(i + 1, j, k, l);
            NotifyBlockOfNeighborChange(i, j - 1, k, l);
            NotifyBlockOfNeighborChange(i, j + 1, k, l);
            NotifyBlockOfNeighborChange(i, j, k - 1, l);
            NotifyBlockOfNeighborChange(i, j, k + 1, l);
        }

        private void NotifyBlockOfNeighborChange(int i, int j, int k, int l)
        {
            if (editingBlocks || singleplayerWorld)
            {
                return;
            }
            net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[GetBlockId(i,
                j, k)];
            if (block != null)
            {
                block.OnNeighborBlockChange(this, i, j, k, l);
            }
        }

        public virtual bool CanBlockSeeTheSky(int i, int j, int k)
        {
            return GetChunkFromChunkCoords(i >> 4, k >> 4).CanBlockSeeTheSky(i & 0xf, j, k & 0xf);
        }

        public virtual int GetBlockLightValueNoChecks(int i, int j, int k)
        {
            if (j < 0)
            {
                return 0;
            }
            if (j >= 128)
            {
                j = 127;
            }
            return GetChunkFromChunkCoords(i >> 4, k >> 4).GetBlockLightValue(i & 0xf, j, k & 0xf, 0);
        }

        public virtual int GetBlockLightValue(int i, int j, int k)
        {
            return GetBlockLightValue_do(i, j, k, true);
        }

        public virtual int GetBlockLightValue_do(int i, int j, int k, bool flag)
        {
            if (i < unchecked((int)(0xfe17b800)) || k < unchecked((int)(0xfe17b800)) || i >=
                0x1e84800 || k > 0x1e84800)
            {
                return 15;
            }
            if (flag)
            {
                int l = GetBlockId(i, j, k);
                if (l == net.minecraft.src.Block.stairSingle.blockID || l == net.minecraft.src.Block
                    .tilledField.blockID || l == net.minecraft.src.Block.stairCompactCobblestone.blockID
                     || l == net.minecraft.src.Block.stairCompactPlanks.blockID)
                {
                    int i1 = GetBlockLightValue_do(i, j + 1, k, false);
                    int j1 = GetBlockLightValue_do(i + 1, j, k, false);
                    int k1 = GetBlockLightValue_do(i - 1, j, k, false);
                    int l1 = GetBlockLightValue_do(i, j, k + 1, false);
                    int i2 = GetBlockLightValue_do(i, j, k - 1, false);
                    if (j1 > i1)
                    {
                        i1 = j1;
                    }
                    if (k1 > i1)
                    {
                        i1 = k1;
                    }
                    if (l1 > i1)
                    {
                        i1 = l1;
                    }
                    if (i2 > i1)
                    {
                        i1 = i2;
                    }
                    return i1;
                }
            }
            if (j < 0)
            {
                return 0;
            }
            if (j >= 128)
            {
                j = 127;
            }
            net.minecraft.src.Chunk chunk = GetChunkFromChunkCoords(i >> 4, k >> 4);
            i &= 0xf;
            k &= 0xf;
            return chunk.GetBlockLightValue(i, j, k, skylightSubtracted);
        }

        public virtual bool CanExistingBlockSeeTheSky(int i, int j, int k)
        {
            if (i < unchecked((int)(0xfe17b800)) || k < unchecked((int)(0xfe17b800)) || i >=
                0x1e84800 || k > 0x1e84800)
            {
                return false;
            }
            if (j < 0)
            {
                return false;
            }
            if (j >= 128)
            {
                return true;
            }
            if (!ChunkExists(i >> 4, k >> 4))
            {
                return false;
            }
            else
            {
                net.minecraft.src.Chunk chunk = GetChunkFromChunkCoords(i >> 4, k >> 4);
                i &= 0xf;
                k &= 0xf;
                return chunk.CanBlockSeeTheSky(i, j, k);
            }
        }

        public virtual int GetHeightValue(int i, int j)
        {
            if (i < unchecked((int)(0xfe17b800)) || j < unchecked((int)(0xfe17b800)) || i >=
                0x1e84800 || j > 0x1e84800)
            {
                return 0;
            }
            if (!ChunkExists(i >> 4, j >> 4))
            {
                return 0;
            }
            else
            {
                net.minecraft.src.Chunk chunk = GetChunkFromChunkCoords(i >> 4, j >> 4);
                return chunk.GetHeightValue(i & 0xf, j & 0xf);
            }
        }

        public virtual void NeighborLightPropagationChanged(net.minecraft.src.EnumSkyBlock
             enumskyblock, int i, int j, int k, int l)
        {
            if (worldProvider.field_4306_c && enumskyblock == net.minecraft.src.EnumSkyBlock.
                Sky)
            {
                return;
            }
            if (!BlockExists(i, j, k))
            {
                return;
            }
            if (enumskyblock == net.minecraft.src.EnumSkyBlock.Sky)
            {
                if (CanExistingBlockSeeTheSky(i, j, k))
                {
                    l = 15;
                }
            }
            else
            {
                if (enumskyblock == net.minecraft.src.EnumSkyBlock.Block)
                {
                    int i1 = GetBlockId(i, j, k);
                    if (net.minecraft.src.Block.lightValue[i1] > l)
                    {
                        l = net.minecraft.src.Block.lightValue[i1];
                    }
                }
            }
            if (GetSavedLightValue(enumskyblock, i, j, k) != l)
            {
                ScheduleLightingUpdate(enumskyblock, i, j, k, i, j, k);
            }
        }

        public virtual int GetSavedLightValue(net.minecraft.src.EnumSkyBlock enumskyblock
            , int i, int j, int k)
        {
            if (j < 0)
            {
                j = 0;
            }
            if (j >= 128)
            {
                j = 127;
            }
            if (j < 0 || j >= 128 || i < unchecked((int)(0xfe17b800)) || k < unchecked((int)(
                0xfe17b800)) || i >= 0x1e84800 || k > 0x1e84800)
            {
                return enumskyblock.field_984_c;
            }
            int l = i >> 4;
            int i1 = k >> 4;
            if (!ChunkExists(l, i1))
            {
                return 0;
            }
            else
            {
                net.minecraft.src.Chunk chunk = GetChunkFromChunkCoords(l, i1);
                return chunk.GetSavedLightValue(enumskyblock, i & 0xf, j, k & 0xf);
            }
        }

        public virtual void SetLightValue(net.minecraft.src.EnumSkyBlock enumskyblock, int
             i, int j, int k, int l)
        {
            if (i < unchecked((int)(0xfe17b800)) || k < unchecked((int)(0xfe17b800)) || i >=
                0x1e84800 || k > 0x1e84800)
            {
                return;
            }
            if (j < 0)
            {
                return;
            }
            if (j >= 128)
            {
                return;
            }
            if (!ChunkExists(i >> 4, k >> 4))
            {
                return;
            }
            net.minecraft.src.Chunk chunk = GetChunkFromChunkCoords(i >> 4, k >> 4);
            chunk.SetLightValue(enumskyblock, i & 0xf, j, k & 0xf, l);
            for (int i1 = 0; i1 < worldAccesses.Count; i1++)
            {
                ((net.minecraft.src.IWorldAccess)worldAccesses[i1]).MarkBlockNeedsUpdate(i, j, k);
            }
        }

        public virtual float GetLightBrightness(int i, int j, int k)
        {
            return worldProvider.lightBrightnessTable[GetBlockLightValue(i, j, k)];
        }

        public virtual bool IsDaytime()
        {
            return skylightSubtracted < 4;
        }

        public virtual net.minecraft.src.MovingObjectPosition RayTraceBlocks(net.minecraft.src.Vec3D
             vec3d, net.minecraft.src.Vec3D vec3d1)
        {
            return Func_28099_a(vec3d, vec3d1, false, false);
        }

        public virtual net.minecraft.src.MovingObjectPosition RayTraceBlocks_do(net.minecraft.src.Vec3D
             vec3d, net.minecraft.src.Vec3D vec3d1, bool flag)
        {
            return Func_28099_a(vec3d, vec3d1, flag, false);
        }

        public virtual net.minecraft.src.MovingObjectPosition Func_28099_a(net.minecraft.src.Vec3D
             vec3d, net.minecraft.src.Vec3D vec3d1, bool flag, bool flag1)
        {
            if (double.IsNaN(vec3d.xCoord) || double.IsNaN(vec3d.yCoord) || double.IsNaN(vec3d
                .zCoord))
            {
                return null;
            }
            if (double.IsNaN(vec3d1.xCoord) || double.IsNaN(vec3d1.yCoord) || double.IsNaN(vec3d1
                .zCoord))
            {
                return null;
            }
            int i = net.minecraft.src.MathHelper.Floor_double(vec3d1.xCoord);
            int j = net.minecraft.src.MathHelper.Floor_double(vec3d1.yCoord);
            int k = net.minecraft.src.MathHelper.Floor_double(vec3d1.zCoord);
            int l = net.minecraft.src.MathHelper.Floor_double(vec3d.xCoord);
            int i1 = net.minecraft.src.MathHelper.Floor_double(vec3d.yCoord);
            int j1 = net.minecraft.src.MathHelper.Floor_double(vec3d.zCoord);
            int k1 = GetBlockId(l, i1, j1);
            int i2 = GetBlockMetadata(l, i1, j1);
            net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[k1];
            if ((!flag1 || block == null || block.GetCollisionBoundingBoxFromPool(this, l, i1
                , j1) != null) && k1 > 0 && block.CanCollideCheck(i2, flag))
            {
                net.minecraft.src.MovingObjectPosition movingobjectposition = block.CollisionRayTrace
                    (this, l, i1, j1, vec3d, vec3d1);
                if (movingobjectposition != null)
                {
                    return movingobjectposition;
                }
            }
            for (int l1 = 200; l1-- >= 0;)
            {
                if (double.IsNaN(vec3d.xCoord) || double.IsNaN(vec3d.yCoord) || double.IsNaN(vec3d
                    .zCoord))
                {
                    return null;
                }
                if (l == i && i1 == j && j1 == k)
                {
                    return null;
                }
                bool flag2 = true;
                bool flag3 = true;
                bool flag4 = true;
                double d = 999D;
                double d1 = 999D;
                double d2 = 999D;
                if (i > l)
                {
                    d = (double)l + 1.0D;
                }
                else
                {
                    if (i < l)
                    {
                        d = (double)l + 0.0D;
                    }
                    else
                    {
                        flag2 = false;
                    }
                }
                if (j > i1)
                {
                    d1 = (double)i1 + 1.0D;
                }
                else
                {
                    if (j < i1)
                    {
                        d1 = (double)i1 + 0.0D;
                    }
                    else
                    {
                        flag3 = false;
                    }
                }
                if (k > j1)
                {
                    d2 = (double)j1 + 1.0D;
                }
                else
                {
                    if (k < j1)
                    {
                        d2 = (double)j1 + 0.0D;
                    }
                    else
                    {
                        flag4 = false;
                    }
                }
                double d3 = 999D;
                double d4 = 999D;
                double d5 = 999D;
                double d6 = vec3d1.xCoord - vec3d.xCoord;
                double d7 = vec3d1.yCoord - vec3d.yCoord;
                double d8 = vec3d1.zCoord - vec3d.zCoord;
                if (flag2)
                {
                    d3 = (d - vec3d.xCoord) / d6;
                }
                if (flag3)
                {
                    d4 = (d1 - vec3d.yCoord) / d7;
                }
                if (flag4)
                {
                    d5 = (d2 - vec3d.zCoord) / d8;
                }
                byte byte0 = 0;
                if (d3 < d4 && d3 < d5)
                {
                    if (i > l)
                    {
                        byte0 = 4;
                    }
                    else
                    {
                        byte0 = 5;
                    }
                    vec3d.xCoord = d;
                    vec3d.yCoord += d7 * d3;
                    vec3d.zCoord += d8 * d3;
                }
                else
                {
                    if (d4 < d5)
                    {
                        if (j > i1)
                        {
                            byte0 = 0;
                        }
                        else
                        {
                            byte0 = 1;
                        }
                        vec3d.xCoord += d6 * d4;
                        vec3d.yCoord = d1;
                        vec3d.zCoord += d8 * d4;
                    }
                    else
                    {
                        if (k > j1)
                        {
                            byte0 = 2;
                        }
                        else
                        {
                            byte0 = 3;
                        }
                        vec3d.xCoord += d6 * d5;
                        vec3d.yCoord += d7 * d5;
                        vec3d.zCoord = d2;
                    }
                }
                net.minecraft.src.Vec3D vec3d2 = net.minecraft.src.Vec3D.CreateVector(vec3d.xCoord
                    , vec3d.yCoord, vec3d.zCoord);
                l = (int)(vec3d2.xCoord = net.minecraft.src.MathHelper.Floor_double(vec3d.xCoord)
                    );
                if (byte0 == 5)
                {
                    l--;
                    vec3d2.xCoord++;
                }
                i1 = (int)(vec3d2.yCoord = net.minecraft.src.MathHelper.Floor_double(vec3d.yCoord
                    ));
                if (byte0 == 1)
                {
                    i1--;
                    vec3d2.yCoord++;
                }
                j1 = (int)(vec3d2.zCoord = net.minecraft.src.MathHelper.Floor_double(vec3d.zCoord
                    ));
                if (byte0 == 3)
                {
                    j1--;
                    vec3d2.zCoord++;
                }
                int j2 = GetBlockId(l, i1, j1);
                int k2 = GetBlockMetadata(l, i1, j1);
                net.minecraft.src.Block block1 = net.minecraft.src.Block.blocksList[j2];
                if ((!flag1 || block1 == null || block1.GetCollisionBoundingBoxFromPool(this, l,
                    i1, j1) != null) && j2 > 0 && block1.CanCollideCheck(k2, flag))
                {
                    net.minecraft.src.MovingObjectPosition movingobjectposition1 = block1.CollisionRayTrace
                        (this, l, i1, j1, vec3d, vec3d1);
                    if (movingobjectposition1 != null)
                    {
                        return movingobjectposition1;
                    }
                }
            }
            return null;
        }

        public virtual void PlaySoundAtEntity(net.minecraft.src.Entity entity, string s,
            float f, float f1)
        {
            for (int i = 0; i < worldAccesses.Count; i++)
            {
                ((net.minecraft.src.IWorldAccess)worldAccesses[i]).PlaySound(s, entity.posX, entity
                    .posY - (double)entity.yOffset, entity.posZ, f, f1);
            }
        }

        public virtual void PlaySoundEffect(double d, double d1, double d2, string s, float
             f, float f1)
        {
            for (int i = 0; i < worldAccesses.Count; i++)
            {
                ((net.minecraft.src.IWorldAccess)worldAccesses[i]).PlaySound(s, d, d1, d2, f, f1);
            }
        }

        public virtual void PlayRecord(string s, int i, int j, int k)
        {
            for (int l = 0; l < worldAccesses.Count; l++)
            {
                ((net.minecraft.src.IWorldAccess)worldAccesses[l]).PlayRecord(s, i, j, k);
            }
        }

        public virtual void SpawnParticle(string s, double d, double d1, double d2, double
             d3, double d4, double d5)
        {
            for (int i = 0; i < worldAccesses.Count; i++)
            {
                ((net.minecraft.src.IWorldAccess)worldAccesses[i]).SpawnParticle(s, d, d1, d2, d3
                    , d4, d5);
            }
        }

        public virtual bool AddLightningBolt(net.minecraft.src.Entity entity)
        {
            lightningEntities.Add(entity);
            return true;
        }

        public virtual bool EntityJoinedWorld(net.minecraft.src.Entity entity)
        {
            int i = net.minecraft.src.MathHelper.Floor_double(entity.posX / 16D);
            int j = net.minecraft.src.MathHelper.Floor_double(entity.posZ / 16D);
            bool flag = false;
            if (entity is net.minecraft.src.EntityPlayer)
            {
                flag = true;
            }
            if (flag || ChunkExists(i, j))
            {
                if (entity is net.minecraft.src.EntityPlayer)
                {
                    net.minecraft.src.EntityPlayer entityplayer = (net.minecraft.src.EntityPlayer)entity;
                    playerEntities.Add(entityplayer);
                    UpdateAllPlayersSleepingFlag();
                }
                GetChunkFromChunkCoords(i, j).AddEntity(entity);
                loadedEntityList.Add(entity);
                ObtainEntitySkin(entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        protected internal virtual void ObtainEntitySkin(net.minecraft.src.Entity entity)
        {
            for (int i = 0; i < worldAccesses.Count; i++)
            {
                ((net.minecraft.src.IWorldAccess)worldAccesses[i]).ObtainEntitySkin(entity);
            }
        }

        protected internal virtual void ReleaseEntitySkin(net.minecraft.src.Entity entity
            )
        {
            for (int i = 0; i < worldAccesses.Count; i++)
            {
                ((net.minecraft.src.IWorldAccess)worldAccesses[i]).ReleaseEntitySkin(entity);
            }
        }

        public virtual void RemovePlayerForLogoff(net.minecraft.src.Entity entity)
        {
            if (entity.riddenByEntity != null)
            {
                entity.riddenByEntity.MountEntity(null);
            }
            if (entity.ridingEntity != null)
            {
                entity.MountEntity(null);
            }
            entity.SetEntityDead();
            if (entity is net.minecraft.src.EntityPlayer)
            {
                playerEntities.Remove((net.minecraft.src.EntityPlayer)entity);
                UpdateAllPlayersSleepingFlag();
            }
        }

        public virtual void RemovePlayer(net.minecraft.src.Entity entity)
        {
            entity.SetEntityDead();
            if (entity is net.minecraft.src.EntityPlayer)
            {
                playerEntities.Remove((net.minecraft.src.EntityPlayer)entity);
                UpdateAllPlayersSleepingFlag();
            }
            int i = entity.chunkCoordX;
            int j = entity.chunkCoordZ;
            if (entity.addedToChunk && ChunkExists(i, j))
            {
                GetChunkFromChunkCoords(i, j).RemoveEntity(entity);
            }
            loadedEntityList.Remove(entity);
            ReleaseEntitySkin(entity);
        }

        public virtual void AddWorldAccess(net.minecraft.src.IWorldAccess iworldaccess)
        {
            worldAccesses.Add(iworldaccess);
        }

        public virtual List<AxisAlignedBB> GetCollidingBoundingBoxes(net.minecraft.src.Entity entity, net.minecraft.src.AxisAlignedBB axisalignedbb)
        {
            field_9207_I.Clear();
            int i = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minX);
            int j = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxX + 1.0D);
            int k = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minY);
            int l = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxY + 1.0D);
            int i1 = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minZ);
            int j1 = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxZ + 1.0D);
            for (int k1 = i; k1 < j; k1++)
            {
                for (int l1 = i1; l1 < j1; l1++)
                {
                    if (!BlockExists(k1, 64, l1))
                    {
                        continue;
                    }
                    for (int i2 = k - 1; i2 < l; i2++)
                    {
                        net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[GetBlockId(k1,
                            i2, l1)];
                        if (block != null)
                        {
                            block.GetCollidingBoundingBoxes(this, k1, i2, l1, axisalignedbb, field_9207_I);
                        }
                    }
                }
            }
            double d = 0.25D;
            List<Entity> list = GetEntitiesWithinAABBExcludingEntity(entity, axisalignedbb.Expand(d, d, d));
            for (int j2 = 0; j2 < list.Count; j2++)
            {
                net.minecraft.src.AxisAlignedBB axisalignedbb1 = ((net.minecraft.src.Entity)list[
                    j2]).GetBoundingBox();
                if (axisalignedbb1 != null && axisalignedbb1.IntersectsWith(axisalignedbb))
                {
                    field_9207_I.Add(axisalignedbb1);
                }
                axisalignedbb1 = entity.Func_89_d((net.minecraft.src.Entity)list[j2]);
                if (axisalignedbb1 != null && axisalignedbb1.IntersectsWith(axisalignedbb))
                {
                    field_9207_I.Add(axisalignedbb1);
                }
            }
            return field_9207_I;
        }

        public virtual int CalculateSkylightSubtracted(float f)
        {
            float f1 = GetCelestialAngle(f);
            float f2 = 1.0F - (net.minecraft.src.MathHelper.Cos(f1 * 3.141593F * 2.0F) * 2.0F
                 + 0.5F);
            if (f2 < 0.0F)
            {
                f2 = 0.0F;
            }
            if (f2 > 1.0F)
            {
                f2 = 1.0F;
            }
            f2 = 1.0F - f2;
            f2 = (float)((double)f2 * (1.0D - (double)(Func_27074_d(f) * 5F) / 16D));
            f2 = (float)((double)f2 * (1.0D - (double)(Func_27065_c(f) * 5F) / 16D));
            f2 = 1.0F - f2;
            return (int)(f2 * 11F);
        }

        public virtual float GetCelestialAngle(float f)
        {
            return worldProvider.CalculateCelestialAngle(worldInfo.GetWorldTime(), f);
        }

        public virtual int GetTopSolidOrLiquidBlock(int i, int j)
        {
            net.minecraft.src.Chunk chunk = GetChunkFromBlockCoords(i, j);
            int k = 127;
            i &= 0xf;
            j &= 0xf;
            while (k > 0)
            {
                int l = chunk.GetBlockID(i, k, j);
                net.minecraft.src.Material material = l != 0 ? net.minecraft.src.Block.blocksList
                    [l].blockMaterial : net.minecraft.src.Material.air;
                if (!material.GetIsSolid() && !material.GetIsLiquid())
                {
                    k--;
                }
                else
                {
                    return k + 1;
                }
            }
            return -1;
        }

        public virtual int FindTopSolidBlock(int i, int j)
        {
            net.minecraft.src.Chunk chunk = GetChunkFromBlockCoords(i, j);
            int k = 127;
            i &= 0xf;
            j &= 0xf;
            while (k > 0)
            {
                int l = chunk.GetBlockID(i, k, j);
                if (l == 0 || !net.minecraft.src.Block.blocksList[l].blockMaterial.GetIsSolid())
                {
                    k--;
                }
                else
                {
                    return k + 1;
                }
            }
            return -1;
        }

        public virtual void ScheduleUpdateTick(int i, int j, int k, int l, int i1)
        {
            net.minecraft.src.NextTickListEntry nextticklistentry = new net.minecraft.src.NextTickListEntry
                (i, j, k, l);
            byte byte0 = 8;
            if (scheduledUpdatesAreImmediate)
            {
                if (CheckChunksExist(nextticklistentry.xCoord - byte0, nextticklistentry.yCoord -
                     byte0, nextticklistentry.zCoord - byte0, nextticklistentry.xCoord + byte0, nextticklistentry
                    .yCoord + byte0, nextticklistentry.zCoord + byte0))
                {
                    int j1 = GetBlockId(nextticklistentry.xCoord, nextticklistentry.yCoord, nextticklistentry
                        .zCoord);
                    if (j1 == nextticklistentry.blockID && j1 > 0)
                    {
                        net.minecraft.src.Block.blocksList[j1].UpdateTick(this, nextticklistentry.xCoord,
                            nextticklistentry.yCoord, nextticklistentry.zCoord, rand);
                    }
                }
                return;
            }
            if (CheckChunksExist(i - byte0, j - byte0, k - byte0, i + byte0, j + byte0, k + byte0
                ))
            {
                if (l > 0)
                {
                    nextticklistentry.SetScheduledTime((long)i1 + worldInfo.GetWorldTime());
                }
                if (!scheduledTickSet.Contains(nextticklistentry))
                {
                    scheduledTickSet.Add(nextticklistentry);
                    scheduledTickTreeSet.Add(nextticklistentry);
                }
            }
        }

        public virtual void UpdateEntities()
        {
            for (int i = 0; i < lightningEntities.Count; i++)
            {
                net.minecraft.src.Entity entity = (net.minecraft.src.Entity)lightningEntities[i];
                entity.OnUpdate();
                if (entity.isDead)
                {
                    lightningEntities.RemoveAt(i--);
                }
            }
            loadedEntityList.RemoveAll(unloadedEntityList);
            for (int j = 0; j < unloadedEntityList.Count; j++)
            {
                net.minecraft.src.Entity entity1 = (net.minecraft.src.Entity)unloadedEntityList[j
                    ];
                int i1 = entity1.chunkCoordX;
                int k1 = entity1.chunkCoordZ;
                if (entity1.addedToChunk && ChunkExists(i1, k1))
                {
                    GetChunkFromChunkCoords(i1, k1).RemoveEntity(entity1);
                }
            }
            for (int k = 0; k < unloadedEntityList.Count; k++)
            {
                ReleaseEntitySkin((net.minecraft.src.Entity)unloadedEntityList[k]);
            }
            unloadedEntityList.Clear();
            for (int l = 0; l < loadedEntityList.Count; l++)
            {
                net.minecraft.src.Entity entity2 = (net.minecraft.src.Entity)loadedEntityList[l];
                if (entity2.ridingEntity != null)
                {
                    if (!entity2.ridingEntity.isDead && entity2.ridingEntity.riddenByEntity == entity2)
                    {
                        continue;
                    }
                    entity2.ridingEntity.riddenByEntity = null;
                    entity2.ridingEntity = null;
                }
                if (!entity2.isDead)
                {
                    UpdateEntity(entity2);
                }
                if (!entity2.isDead)
                {
                    continue;
                }
                int j1 = entity2.chunkCoordX;
                int l1 = entity2.chunkCoordZ;
                if (entity2.addedToChunk && ChunkExists(j1, l1))
                {
                    GetChunkFromChunkCoords(j1, l1).RemoveEntity(entity2);
                }
                loadedEntityList.RemoveAt(l--);
                ReleaseEntitySkin(entity2);
            }
            field_31048_L = true;
            System.Collections.IEnumerator iterator = loadedTileEntityList.GetEnumerator();
            List<TileEntity> toremove = new List<TileEntity>();
            do
            {
                if (!iterator.MoveNext())
                {
                    break;
                }
                net.minecraft.src.TileEntity tileentity = (net.minecraft.src.TileEntity)iterator.Current;
                if (!tileentity.IsInvalid())
                {
                    tileentity.UpdateEntity();
                }
                if (tileentity.IsInvalid())
                {
                    //iterator.Remove();
                    toremove.Add(tileentity);
                    net.minecraft.src.Chunk chunk = GetChunkFromChunkCoords(tileentity.xCoord >> 4, tileentity
                        .zCoord >> 4);
                    if (chunk != null)
                    {
                        chunk.RemoveChunkBlockTileEntity(tileentity.xCoord & 0xf, tileentity
                            .yCoord, tileentity.zCoord & 0xf);
                    }
                }
            }
            while (true);
            foreach (TileEntity rem in toremove)
                loadedTileEntityList.Remove(rem);
            field_31048_L = false;
            if (field_20912_E.Count > 0)
            {
                System.Collections.IEnumerator iterator1 = field_20912_E.GetEnumerator();
                do
                {
                    if (!iterator1.MoveNext())
                    {
                        break;
                    }
                    net.minecraft.src.TileEntity tileentity1 = (net.minecraft.src.TileEntity)iterator1
                        .Current;
                    if (!tileentity1.IsInvalid())
                    {
                        if (!loadedTileEntityList.Contains(tileentity1))
                        {
                            loadedTileEntityList.Add(tileentity1);
                        }
                        net.minecraft.src.Chunk chunk1 = GetChunkFromChunkCoords(tileentity1.xCoord >> 4,
                            tileentity1.zCoord >> 4);
                        if (chunk1 != null)
                        {
                            chunk1.SetChunkBlockTileEntity(tileentity1.xCoord & 0xf, tileentity1
                                .yCoord, tileentity1.zCoord & 0xf, tileentity1);
                        }
                        MarkBlockNeedsUpdate(tileentity1.xCoord, tileentity1.yCoord, tileentity1.zCoord);
                    }
                }
                while (true);
                field_20912_E.Clear();
            }
        }

        public virtual void Func_31047_a(IEnumerable<TileEntity> collection)
        {
            if (field_31048_L)
            {
                field_20912_E.AddRange(collection);
            }
            else
            {
                loadedTileEntityList.AddRange(collection);
            }
        }

        public virtual void UpdateEntity(net.minecraft.src.Entity entity)
        {
            UpdateEntityWithOptionalForce(entity, true);
        }

        public virtual void UpdateEntityWithOptionalForce(net.minecraft.src.Entity entity
            , bool flag)
        {
            int i = net.minecraft.src.MathHelper.Floor_double(entity.posX);
            int j = net.minecraft.src.MathHelper.Floor_double(entity.posZ);
            byte byte0 = 32;
            if (flag && !CheckChunksExist(i - byte0, 0, j - byte0, i + byte0, 128, j + byte0))
            {
                return;
            }
            entity.lastTickPosX = entity.posX;
            entity.lastTickPosY = entity.posY;
            entity.lastTickPosZ = entity.posZ;
            entity.prevRotationYaw = entity.rotationYaw;
            entity.prevRotationPitch = entity.rotationPitch;
            if (flag && entity.addedToChunk)
            {
                if (entity.ridingEntity != null)
                {
                    entity.UpdateRidden();
                }
                else
                {
                    entity.OnUpdate();
                }
            }
            if (double.IsNaN(entity.posX) || double.IsInfinity(entity.posX))
            {
                entity.posX = entity.lastTickPosX;
            }
            if (double.IsNaN(entity.posY) || double.IsInfinity(entity.posY))
            {
                entity.posY = entity.lastTickPosY;
            }
            if (double.IsNaN(entity.posZ) || double.IsInfinity(entity.posZ))
            {
                entity.posZ = entity.lastTickPosZ;
            }
            if (double.IsNaN(entity.rotationPitch) || double.IsInfinity(entity.rotationPitch))
            {
                entity.rotationPitch = entity.prevRotationPitch;
            }
            if (double.IsNaN(entity.rotationYaw) || double.IsInfinity(entity.rotationYaw))
            {
                entity.rotationYaw = entity.prevRotationYaw;
            }
            int k = net.minecraft.src.MathHelper.Floor_double(entity.posX / 16D);
            int l = net.minecraft.src.MathHelper.Floor_double(entity.posY / 16D);
            int i1 = net.minecraft.src.MathHelper.Floor_double(entity.posZ / 16D);
            if (!entity.addedToChunk || entity.chunkCoordX != k || entity.chunkCoordY != l ||
                 entity.chunkCoordZ != i1)
            {
                if (entity.addedToChunk && ChunkExists(entity.chunkCoordX, entity.chunkCoordZ))
                {
                    GetChunkFromChunkCoords(entity.chunkCoordX, entity.chunkCoordZ).RemoveEntityAtIndex
                        (entity, entity.chunkCoordY);
                }
                if (ChunkExists(k, i1))
                {
                    entity.addedToChunk = true;
                    GetChunkFromChunkCoords(k, i1).AddEntity(entity);
                }
                else
                {
                    entity.addedToChunk = false;
                }
            }
            if (flag && entity.addedToChunk && entity.riddenByEntity != null)
            {
                if (entity.riddenByEntity.isDead || entity.riddenByEntity.ridingEntity != entity)
                {
                    entity.riddenByEntity.ridingEntity = null;
                    entity.riddenByEntity = null;
                }
                else
                {
                    UpdateEntity(entity.riddenByEntity);
                }
            }
        }

        public virtual bool CheckIfAABBIsClear(net.minecraft.src.AxisAlignedBB axisalignedbb
            )
        {
            List<Entity> list = GetEntitiesWithinAABBExcludingEntity(null, axisalignedbb);
            for (int i = 0; i < list.Count; i++)
            {
                net.minecraft.src.Entity entity = (net.minecraft.src.Entity)list[i];
                if (!entity.isDead && entity.preventEntitySpawning)
                {
                    return false;
                }
            }
            return true;
        }

        public virtual bool Func_27069_b(net.minecraft.src.AxisAlignedBB axisalignedbb)
        {
            int i = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minX);
            int j = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxX + 1.0D);
            int k = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minY);
            int l = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxY + 1.0D);
            int i1 = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minZ);
            int j1 = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxZ + 1.0D);
            if (axisalignedbb.minX < 0.0D)
            {
                i--;
            }
            if (axisalignedbb.minY < 0.0D)
            {
                k--;
            }
            if (axisalignedbb.minZ < 0.0D)
            {
                i1--;
            }
            for (int k1 = i; k1 < j; k1++)
            {
                for (int l1 = k; l1 < l; l1++)
                {
                    for (int i2 = i1; i2 < j1; i2++)
                    {
                        net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[GetBlockId(k1,
                            l1, i2)];
                        if (block != null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public virtual bool GetIsAnyLiquid(net.minecraft.src.AxisAlignedBB axisalignedbb)
        {
            int i = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minX);
            int j = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxX + 1.0D);
            int k = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minY);
            int l = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxY + 1.0D);
            int i1 = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minZ);
            int j1 = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxZ + 1.0D);
            if (axisalignedbb.minX < 0.0D)
            {
                i--;
            }
            if (axisalignedbb.minY < 0.0D)
            {
                k--;
            }
            if (axisalignedbb.minZ < 0.0D)
            {
                i1--;
            }
            for (int k1 = i; k1 < j; k1++)
            {
                for (int l1 = k; l1 < l; l1++)
                {
                    for (int i2 = i1; i2 < j1; i2++)
                    {
                        net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[GetBlockId(k1,
                            l1, i2)];
                        if (block != null && block.blockMaterial.GetIsLiquid())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public virtual bool IsBoundingBoxBurning(net.minecraft.src.AxisAlignedBB axisalignedbb
            )
        {
            int i = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minX);
            int j = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxX + 1.0D);
            int k = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minY);
            int l = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxY + 1.0D);
            int i1 = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minZ);
            int j1 = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxZ + 1.0D);
            if (CheckChunksExist(i, k, i1, j, l, j1))
            {
                for (int k1 = i; k1 < j; k1++)
                {
                    for (int l1 = k; l1 < l; l1++)
                    {
                        for (int i2 = i1; i2 < j1; i2++)
                        {
                            int j2 = GetBlockId(k1, l1, i2);
                            if (j2 == net.minecraft.src.Block.fire.blockID || j2 == net.minecraft.src.Block.lavaMoving
                                .blockID || j2 == net.minecraft.src.Block.lavaStill.blockID)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public virtual bool HandleMaterialAcceleration(net.minecraft.src.AxisAlignedBB axisalignedbb
            , net.minecraft.src.Material material, net.minecraft.src.Entity entity)
        {
            int i = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minX);
            int j = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxX + 1.0D);
            int k = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minY);
            int l = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxY + 1.0D);
            int i1 = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minZ);
            int j1 = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxZ + 1.0D);
            if (!CheckChunksExist(i, k, i1, j, l, j1))
            {
                return false;
            }
            bool flag = false;
            net.minecraft.src.Vec3D vec3d = net.minecraft.src.Vec3D.CreateVector(0.0D, 0.0D,
                0.0D);
            for (int k1 = i; k1 < j; k1++)
            {
                for (int l1 = k; l1 < l; l1++)
                {
                    for (int i2 = i1; i2 < j1; i2++)
                    {
                        net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[GetBlockId(k1,
                            l1, i2)];
                        if (block == null || block.blockMaterial != material)
                        {
                            continue;
                        }
                        double d1 = (float)(l1 + 1) - net.minecraft.src.BlockFluid.SetFluidHeight(GetBlockMetadata
                            (k1, l1, i2));
                        if ((double)l >= d1)
                        {
                            flag = true;
                            block.VelocityToAddToEntity(this, k1, l1, i2, entity, vec3d);
                        }
                    }
                }
            }
            if (vec3d.LengthVector() > 0.0D)
            {
                vec3d = vec3d.Normalize();
                double d = 0.014D;
                entity.motionX += vec3d.xCoord * d;
                entity.motionY += vec3d.yCoord * d;
                entity.motionZ += vec3d.zCoord * d;
            }
            return flag;
        }

        public virtual bool IsMaterialInBB(net.minecraft.src.AxisAlignedBB axisalignedbb,
            net.minecraft.src.Material material)
        {
            int i = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minX);
            int j = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxX + 1.0D);
            int k = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minY);
            int l = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxY + 1.0D);
            int i1 = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minZ);
            int j1 = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxZ + 1.0D);
            for (int k1 = i; k1 < j; k1++)
            {
                for (int l1 = k; l1 < l; l1++)
                {
                    for (int i2 = i1; i2 < j1; i2++)
                    {
                        net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[GetBlockId(k1,
                            l1, i2)];
                        if (block != null && block.blockMaterial == material)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public virtual bool IsAABBInMaterial(net.minecraft.src.AxisAlignedBB axisalignedbb
            , net.minecraft.src.Material material)
        {
            int i = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minX);
            int j = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxX + 1.0D);
            int k = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minY);
            int l = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxY + 1.0D);
            int i1 = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.minZ);
            int j1 = net.minecraft.src.MathHelper.Floor_double(axisalignedbb.maxZ + 1.0D);
            for (int k1 = i; k1 < j; k1++)
            {
                for (int l1 = k; l1 < l; l1++)
                {
                    for (int i2 = i1; i2 < j1; i2++)
                    {
                        net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[GetBlockId(k1,
                            l1, i2)];
                        if (block == null || block.blockMaterial != material)
                        {
                            continue;
                        }
                        int j2 = GetBlockMetadata(k1, l1, i2);
                        double d = l1 + 1;
                        if (j2 < 8)
                        {
                            d = (double)(l1 + 1) - (double)j2 / 8D;
                        }
                        if (d >= axisalignedbb.minY)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public virtual net.minecraft.src.Explosion CreateExplosion(net.minecraft.src.Entity
             entity, double d, double d1, double d2, float f)
        {
            return NewExplosion(entity, d, d1, d2, f, false);
        }

        public virtual net.minecraft.src.Explosion NewExplosion(net.minecraft.src.Entity
            entity, double d, double d1, double d2, float f, bool flag)
        {
            net.minecraft.src.Explosion explosion = new net.minecraft.src.Explosion(this, entity
                , d, d1, d2, f);
            explosion.isFlaming = flag;
            explosion.DoExplosion();
            explosion.DoEffects(true);
            return explosion;
        }

        public virtual float Func_494_a(net.minecraft.src.Vec3D vec3d, net.minecraft.src.AxisAlignedBB
             axisalignedbb)
        {
            double d = 1.0D / ((axisalignedbb.maxX - axisalignedbb.minX) * 2D + 1.0D);
            double d1 = 1.0D / ((axisalignedbb.maxY - axisalignedbb.minY) * 2D + 1.0D);
            double d2 = 1.0D / ((axisalignedbb.maxZ - axisalignedbb.minZ) * 2D + 1.0D);
            int i = 0;
            int j = 0;
            for (float f = 0.0F; f <= 1.0F; f = (float)((double)f + d))
            {
                for (float f1 = 0.0F; f1 <= 1.0F; f1 = (float)((double)f1 + d1))
                {
                    for (float f2 = 0.0F; f2 <= 1.0F; f2 = (float)((double)f2 + d2))
                    {
                        double d3 = axisalignedbb.minX + (axisalignedbb.maxX - axisalignedbb.minX) * (double
                            )f;
                        double d4 = axisalignedbb.minY + (axisalignedbb.maxY - axisalignedbb.minY) * (double
                            )f1;
                        double d5 = axisalignedbb.minZ + (axisalignedbb.maxZ - axisalignedbb.minZ) * (double
                            )f2;
                        if (RayTraceBlocks(net.minecraft.src.Vec3D.CreateVector(d3, d4, d5), vec3d) == null)
                        {
                            i++;
                        }
                        j++;
                    }
                }
            }
            return (float)i / (float)j;
        }

        public virtual void Func_28096_a(net.minecraft.src.EntityPlayer entityplayer, int
             i, int j, int k, int l)
        {
            if (l == 0)
            {
                j--;
            }
            if (l == 1)
            {
                j++;
            }
            if (l == 2)
            {
                k--;
            }
            if (l == 3)
            {
                k++;
            }
            if (l == 4)
            {
                i--;
            }
            if (l == 5)
            {
                i++;
            }
            if (GetBlockId(i, j, k) == net.minecraft.src.Block.fire.blockID)
            {
                Func_28101_a(entityplayer, 1004, i, j, k, 0);
                SetBlockWithNotify(i, j, k, 0);
            }
        }

        public virtual net.minecraft.src.TileEntity GetBlockTileEntity(int i, int j, int
            k)
        {
            net.minecraft.src.Chunk chunk = GetChunkFromChunkCoords(i >> 4, k >> 4);
            if (chunk != null)
            {
                return chunk.GetChunkBlockTileEntity(i & 0xf, j, k & 0xf);
            }
            else
            {
                return null;
            }
        }

        public virtual void SetBlockTileEntity(int i, int j, int k, net.minecraft.src.TileEntity
             tileentity)
        {
            if (!tileentity.IsInvalid())
            {
                if (field_31048_L)
                {
                    tileentity.xCoord = i;
                    tileentity.yCoord = j;
                    tileentity.zCoord = k;
                    field_20912_E.Add(tileentity);
                }
                else
                {
                    loadedTileEntityList.Add(tileentity);
                    net.minecraft.src.Chunk chunk = GetChunkFromChunkCoords(i >> 4, k >> 4);
                    if (chunk != null)
                    {
                        chunk.SetChunkBlockTileEntity(i & 0xf, j, k & 0xf, tileentity);
                    }
                }
            }
        }

        public virtual void RemoveBlockTileEntity(int i, int j, int k)
        {
            net.minecraft.src.TileEntity tileentity = GetBlockTileEntity(i, j, k);
            if (tileentity != null && field_31048_L)
            {
                tileentity.Invalidate();
            }
            else
            {
                if (tileentity != null)
                {
                    loadedTileEntityList.Remove(tileentity);
                }
                net.minecraft.src.Chunk chunk = GetChunkFromChunkCoords(i >> 4, k >> 4);
                if (chunk != null)
                {
                    chunk.RemoveChunkBlockTileEntity(i & 0xf, j, k & 0xf);
                }
            }
        }

        public virtual bool IsBlockOpaqueCube(int i, int j, int k)
        {
            net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[GetBlockId(i,
                j, k)];
            if (block == null)
            {
                return false;
            }
            else
            {
                return block.IsOpaqueCube();
            }
        }

        public virtual bool IsBlockNormalCube(int i, int j, int k)
        {
            net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[GetBlockId(i,
                j, k)];
            if (block == null)
            {
                return false;
            }
            else
            {
                return block.blockMaterial.GetIsOpaque() && block.IsACube();
            }
        }

        public virtual bool DoLighting()
        {
            if (field_4265_J >= 50)
            {
                return false;
            }
            field_4265_J++;
            try
            {
                int i = 500;
                for (; LightingUpdateQueue.Count > 0;)
                {
                    var chunk = ((net.minecraft.src.MetadataChunkBlock)LightingUpdateQueue[LightingUpdateQueue.Count - 1]); //TODO: Optimise
                    LightingUpdateQueue.RemoveAt(LightingUpdateQueue.Count - 1);
                    chunk.Func_4107_a(this);
                    //LightingUpdateQueue.Remove(chunk);
                    if (--i <= 0)
                    {
                        bool flag = true;
                        return flag;
                    }
                }
                bool flag1 = false;
                return flag1;
            }
            finally
            {
                field_4265_J--;
            }
        }

        public virtual void ScheduleLightingUpdate(net.minecraft.src.EnumSkyBlock enumskyblock
            , int i, int j, int k, int l, int i1, int j1)
        {
            Func_484_a(enumskyblock, i, j, k, l, i1, j1, true);
        }

        public virtual void Func_484_a(net.minecraft.src.EnumSkyBlock enumskyblock, int i
            , int j, int k, int l, int i1, int j1, bool flag)
        {
            if (worldProvider.field_4306_c && enumskyblock == net.minecraft.src.EnumSkyBlock.
                Sky)
            {
                return;
            }
            field_4268_y++;
            try
            {
                if (field_4268_y == 50)
                {
                    return;
                }
                int k1 = (l + i) / 2;
                int l1 = (j1 + k) / 2;
                if (!BlockExists(k1, 64, l1))
                {
                    return;
                }
                if (GetChunkFromBlockCoords(k1, l1).Func_21101_g())
                {
                    return;
                }
                int i2 = LightingUpdateQueue.Count;
                if (flag)
                {
                    int j2 = 5;
                    if (j2 > i2)
                    {
                        j2 = i2;
                    }
                    for (int l2 = 0; l2 < j2; l2++)
                    {
                        net.minecraft.src.MetadataChunkBlock metadatachunkblock = (net.minecraft.src.MetadataChunkBlock
                            )LightingUpdateQueue[LightingUpdateQueue.Count - l2 - 1];
                        if (metadatachunkblock.field_957_a == enumskyblock && metadatachunkblock.Func_692_a
                            (i, j, k, l, i1, j1))
                        {
                            return;
                        }
                    }
                }
                LightingUpdateQueue.Add(new net.minecraft.src.MetadataChunkBlock(enumskyblock, i, j, k, l
                    , i1, j1));
                int k2 = 1000000;
                if (LightingUpdateQueue.Count > 1000000)
                {
                    System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append("More than ")
                        .Append(k2).Append(" updates, aborting lighting updates").ToString());
                    LightingUpdateQueue.Clear();
                }
            }
            finally
            {
                field_4268_y--;
            }
        }

        public virtual void CalculateInitialSkylight()
        {
            int i = CalculateSkylightSubtracted(1.0F);
            if (i != skylightSubtracted)
            {
                skylightSubtracted = i;
            }
        }

        public virtual void SetAllowedSpawnTypes(bool flag, bool flag1)
        {
            spawnHostileMobs = flag;
            spawnPeacefulMobs = flag1;
        }

        public virtual void Tick()
        {
            UpdateWeather();
            if (IsAllPlayersFullyAsleep())
            {
                bool flag = false;
                if (spawnHostileMobs && difficultySetting >= 1)
                {
                    flag = net.minecraft.src.SpawnerAnimals.PerformSleepSpawning(this, playerEntities
                        );
                }
                if (!flag)
                {
                    long l = worldInfo.GetWorldTime() + 24000L;
                    worldInfo.SetWorldTime(l - l % 24000L);
                    WakeUpAllPlayers();
                }
            }
            net.minecraft.src.SpawnerAnimals.PerformSpawning(this, spawnHostileMobs, spawnPeacefulMobs
                );
            chunkProvider.Func_361_a();
            int i = CalculateSkylightSubtracted(1.0F);
            if (i != skylightSubtracted)
            {
                skylightSubtracted = i;
                for (int j = 0; j < worldAccesses.Count; j++)
                {
                    ((net.minecraft.src.IWorldAccess)worldAccesses[j]).UpdateAllRenderers();
                }
            }
            long l1 = worldInfo.GetWorldTime() + 1L;
            if (l1 % (long)autosavePeriod == 0L)
            {
                SaveWorld(false, null);
            }
            worldInfo.SetWorldTime(l1);
            TickUpdates(false);
            DoRandomUpdateTicks();
        }

        private void Func_27070_x()
        {
            if (worldInfo.GetIsRaining())
            {
                field_27078_C = 1.0F;
                if (worldInfo.GetIsThundering())
                {
                    field_27076_E = 1.0F;
                }
            }
        }

        protected internal virtual void UpdateWeather()
        {
            if (worldProvider.field_4306_c)
            {
                return;
            }
            if (field_27075_F > 0)
            {
                field_27075_F--;
            }
            int i = worldInfo.GetThunderTime();
            if (i <= 0)
            {
                if (worldInfo.GetIsThundering())
                {
                    worldInfo.SetThunderTime(rand.Next(12000) + 3600);
                }
                else
                {
                    worldInfo.SetThunderTime(rand.Next(0x29040) + 12000);
                }
            }
            else
            {
                i--;
                worldInfo.SetThunderTime(i);
                if (i <= 0)
                {
                    worldInfo.SetIsThundering(!worldInfo.GetIsThundering());
                }
            }
            int j = worldInfo.GetRainTime();
            if (j <= 0)
            {
                if (worldInfo.GetIsRaining())
                {
                    worldInfo.SetRainTime(rand.Next(12000) + 12000);
                }
                else
                {
                    worldInfo.SetRainTime(rand.Next(0x29040) + 12000);
                }
            }
            else
            {
                j--;
                worldInfo.SetRainTime(j);
                if (j <= 0)
                {
                    worldInfo.SetIsRaining(!worldInfo.GetIsRaining());
                }
            }
            field_27079_B = field_27078_C;
            if (worldInfo.GetIsRaining())
            {
                field_27078_C += 0.01F;
            }
            else
            {
                field_27078_C -= 0.01F;
            }
            if (field_27078_C < 0.0F)
            {
                field_27078_C = 0.0F;
            }
            if (field_27078_C > 1.0F)
            {
                field_27078_C = 1.0F;
            }
            field_27077_D = field_27076_E;
            if (worldInfo.GetIsThundering())
            {
                field_27076_E += 0.01F;
            }
            else
            {
                field_27076_E -= 0.01F;
            }
            if (field_27076_E < 0.0F)
            {
                field_27076_E = 0.0F;
            }
            if (field_27076_E > 1.0F)
            {
                field_27076_E = 1.0F;
            }
        }

        private void ClearWeather()
        {
            worldInfo.SetRainTime(0);
            worldInfo.SetIsRaining(false);
            worldInfo.SetThunderTime(0);
            worldInfo.SetIsThundering(false);
        }

        protected internal virtual void DoRandomUpdateTicks()
        {
            activeChunkSet.Clear();
            for (int i = 0; i < playerEntities.Count; i++)
            {
                net.minecraft.src.EntityPlayer entityplayer = (net.minecraft.src.EntityPlayer)playerEntities
                    [i];
                int j = net.minecraft.src.MathHelper.Floor_double(entityplayer.posX / 16D);
                int l = net.minecraft.src.MathHelper.Floor_double(entityplayer.posZ / 16D);
                byte byte0 = 9;
                for (int j1 = -byte0; j1 <= byte0; j1++)
                {
                    for (int k2 = -byte0; k2 <= byte0; k2++)
                    {
                        activeChunkSet.Add(new net.minecraft.src.ChunkCoordIntPair(j1 + j, k2 + l));
                    }
                }
            }
            if (ambientTickCountdown > 0)
            {
                ambientTickCountdown--;
            }
            for (System.Collections.IEnumerator iterator = activeChunkSet.GetEnumerator(); iterator
                .MoveNext();)
            {
                net.minecraft.src.ChunkCoordIntPair chunkcoordintpair = (net.minecraft.src.ChunkCoordIntPair
                    )iterator.Current;
                int k = chunkcoordintpair.chunkXPos * 16;
                int i1 = chunkcoordintpair.chunkZPos * 16;
                net.minecraft.src.Chunk chunk = GetChunkFromChunkCoords(chunkcoordintpair.chunkXPos
                    , chunkcoordintpair.chunkZPos);
                if (ambientTickCountdown == 0)
                {
                    distHashCounter = distHashCounter * 3 + 0x3c6ef35f;
                    int k1 = distHashCounter >> 2;
                    int l2 = k1 & 0xf;
                    int l3 = k1 >> 8 & 0xf;
                    int l4 = k1 >> 16 & 0x7f;
                    int l5 = chunk.GetBlockID(l2, l4, l3);
                    l2 += k;
                    l3 += i1;
                    if (l5 == 0 && GetBlockLightValueNoChecks(l2, l4, l3) <= rand.Next(8) && GetSavedLightValue
                        (net.minecraft.src.EnumSkyBlock.Sky, l2, l4, l3) <= 0)
                    {
                        net.minecraft.src.EntityPlayer entityplayer1 = GetClosestPlayer((double)l2 + 0.5D
                            , (double)l4 + 0.5D, (double)l3 + 0.5D, 8D);
                        if (entityplayer1 != null && entityplayer1.GetDistanceSq((double)l2 + 0.5D, (double
                            )l4 + 0.5D, (double)l3 + 0.5D) > 4D)
                        {
                            PlaySoundEffect((double)l2 + 0.5D, (double)l4 + 0.5D, (double)l3 + 0.5D, "ambient.cave.cave"
                                , 0.7F, 0.8F + rand.NextFloat() * 0.2F);
                            ambientTickCountdown = rand.Next(12000) + 6000;
                        }
                    }
                }
                if (rand.Next(0x186a0) == 0 && Func_27068_v() && Func_27067_u
                    ())
                {
                    distHashCounter = distHashCounter * 3 + 0x3c6ef35f;
                    int l1 = distHashCounter >> 2;
                    int i3 = k + (l1 & 0xf);
                    int i4 = i1 + (l1 >> 8 & 0xf);
                    int i5 = GetTopSolidOrLiquidBlock(i3, i4);
                    if (CanLightningStrikeAt(i3, i5, i4))
                    {
                        AddLightningBolt(new net.minecraft.src.EntityLightningBolt(this, i3, i5, i4));
                        field_27075_F = 2;
                    }
                }
                if (rand.Next(16) == 0)
                {
                    distHashCounter = distHashCounter * 3 + 0x3c6ef35f;
                    int i2 = distHashCounter >> 2;
                    int j3 = i2 & 0xf;
                    int j4 = i2 >> 8 & 0xf;
                    int j5 = GetTopSolidOrLiquidBlock(j3 + k, j4 + i1);
                    if (GetWorldChunkManager().GetBiomeGenAt(j3 + k, j4 + i1).GetEnableSnow() && j5 >=
                         0 && j5 < 128 && chunk.GetSavedLightValue(net.minecraft.src.EnumSkyBlock.Block,
                        j3, j5, j4) < 10)
                    {
                        int i6 = chunk.GetBlockID(j3, j5 - 1, j4);
                        int k6 = chunk.GetBlockID(j3, j5, j4);
                        if (Func_27068_v() && k6 == 0 && net.minecraft.src.Block.snow.CanPlaceBlockAt(this
                            , j3 + k, j5, j4 + i1) && i6 != 0 && i6 != net.minecraft.src.Block.ice.blockID &&
                             net.minecraft.src.Block.blocksList[i6].blockMaterial.GetIsSolid())
                        {
                            SetBlockWithNotify(j3 + k, j5, j4 + i1, net.minecraft.src.Block.snow.blockID);
                        }
                        if (i6 == net.minecraft.src.Block.waterStill.blockID && chunk.GetBlockMetadata(j3
                            , j5 - 1, j4) == 0)
                        {
                            SetBlockWithNotify(j3 + k, j5 - 1, j4 + i1, net.minecraft.src.Block.ice.blockID);
                        }
                    }
                }
                int j2 = 0;
                while (j2 < 80)
                {
                    distHashCounter = distHashCounter * 3 + 0x3c6ef35f;
                    int k3 = distHashCounter >> 2;
                    int k4 = k3 & 0xf;
                    int k5 = k3 >> 8 & 0xf;
                    int j6 = k3 >> 16 & 0x7f;
                    int l6 = chunk.blocks[k4 << 11 | k5 << 7 | j6];
                    if (net.minecraft.src.Block.tickOnLoad[l6])
                    {
                        net.minecraft.src.Block.blocksList[l6].UpdateTick(this, k4 + k, j6, k5 + i1, rand
                            );
                    }
                    j2++;
                }
            }
        }

        public virtual bool TickUpdates(bool flag)
        {
            int i = scheduledTickTreeSet.Count;
            if (i != scheduledTickSet.Count)
            {
                throw new System.InvalidOperationException("TickNextTick list out of synch");
            }
            if (i > 1000)
            {
                i = 1000;
            }
            for (int j = 0; j < i; j++)
            {
                net.minecraft.src.NextTickListEntry nextticklistentry = (net.minecraft.src.NextTickListEntry)scheduledTickTreeSet.First();
                if (!flag && nextticklistentry.scheduledTime > worldInfo.GetWorldTime())
                {
                    break;
                }
                scheduledTickTreeSet.Remove(nextticklistentry);
                scheduledTickSet.Remove(nextticklistentry);
                byte byte0 = 8;
                if (!CheckChunksExist(nextticklistentry.xCoord - byte0, nextticklistentry.yCoord
                    - byte0, nextticklistentry.zCoord - byte0, nextticklistentry.xCoord + byte0, nextticklistentry
                    .yCoord + byte0, nextticklistentry.zCoord + byte0))
                {
                    continue;
                }
                int k = GetBlockId(nextticklistentry.xCoord, nextticklistentry.yCoord, nextticklistentry
                    .zCoord);
                if (k == nextticklistentry.blockID && k > 0)
                {
                    net.minecraft.src.Block.blocksList[k].UpdateTick(this, nextticklistentry.xCoord,
                        nextticklistentry.yCoord, nextticklistentry.zCoord, rand);
                }
            }
            return scheduledTickTreeSet.Count != 0;
        }

        public virtual List<Entity> GetEntitiesWithinAABBExcludingEntity(net.minecraft.src.Entity entity, net.minecraft.src.AxisAlignedBB axisalignedbb)
        {
            field_778_L.Clear();
            int i = net.minecraft.src.MathHelper.Floor_double((axisalignedbb.minX - 2D) / 16D
                );
            int j = net.minecraft.src.MathHelper.Floor_double((axisalignedbb.maxX + 2D) / 16D
                );
            int k = net.minecraft.src.MathHelper.Floor_double((axisalignedbb.minZ - 2D) / 16D
                );
            int l = net.minecraft.src.MathHelper.Floor_double((axisalignedbb.maxZ + 2D) / 16D
                );
            for (int i1 = i; i1 <= j; i1++)
            {
                for (int j1 = k; j1 <= l; j1++)
                {
                    if (ChunkExists(i1, j1))
                    {
                        GetChunkFromChunkCoords(i1, j1).GetEntitiesWithinAABBForEntity(entity, axisalignedbb
                            , field_778_L);
                    }
                }
            }
            return field_778_L;
        }

        public virtual List<Entity> GetEntitiesWithinAABB(System.Type class1
            , net.minecraft.src.AxisAlignedBB axisalignedbb)
        {
            int i = net.minecraft.src.MathHelper.Floor_double((axisalignedbb.minX - 2D) / 16D
                );
            int j = net.minecraft.src.MathHelper.Floor_double((axisalignedbb.maxX + 2D) / 16D
                );
            int k = net.minecraft.src.MathHelper.Floor_double((axisalignedbb.minZ - 2D) / 16D
                );
            int l = net.minecraft.src.MathHelper.Floor_double((axisalignedbb.maxZ + 2D) / 16D
                );
            List<Entity> arraylist = new List<Entity>();
            for (int i1 = i; i1 <= j; i1++)
            {
                for (int j1 = k; j1 <= l; j1++)
                {
                    if (ChunkExists(i1, j1))
                    {
                        GetChunkFromChunkCoords(i1, j1).GetEntitiesOfTypeWithinAAAB(class1, axisalignedbb
                            , arraylist);
                    }
                }
            }
            return arraylist;
        }

        public virtual void UpdateTileEntityChunkAndDoNothing(int i, int j, int k, net.minecraft.src.TileEntity
             tileentity)
        {
            if (BlockExists(i, j, k))
            {
                GetChunkFromBlockCoords(i, k).SetChunkModified();
            }
            for (int l = 0; l < worldAccesses.Count; l++)
            {
                ((net.minecraft.src.IWorldAccess)worldAccesses[l]).DoNothingWithTileEntity(i, j,
                    k, tileentity);
            }
        }

        public virtual int CountEntities(System.Type class1)
        {
            int i = 0;
            for (int j = 0; j < loadedEntityList.Count; j++)
            {
                net.minecraft.src.Entity entity = (net.minecraft.src.Entity)loadedEntityList[j];
                if (class1.IsAssignableFrom(entity.GetType()))
                {
                    i++;
                }
            }
            return i;
        }

        public virtual void AddLoadedEntities(List<Entity> list)
        {
            loadedEntityList.AddRange(list);
            for (int i = 0; i < list.Count; i++)
            {
                ObtainEntitySkin((net.minecraft.src.Entity)list[i]);
            }
        }

        public virtual void AddUnloadedEntities(List<Entity> list)
        {
            unloadedEntityList.AddRange(list);
        }

        public virtual bool CanBlockBePlacedAt(int i, int j, int k, int l, bool flag, int
             i1)
        {
            int j1 = GetBlockId(j, k, l);
            net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[j1];
            net.minecraft.src.Block block1 = net.minecraft.src.Block.blocksList[i];
            net.minecraft.src.AxisAlignedBB axisalignedbb = block1.GetCollisionBoundingBoxFromPool
                (this, j, k, l);
            if (flag)
            {
                axisalignedbb = null;
            }
            if (axisalignedbb != null && !CheckIfAABBIsClear(axisalignedbb))
            {
                return false;
            }
            if (block == net.minecraft.src.Block.waterMoving || block == net.minecraft.src.Block
                .waterStill || block == net.minecraft.src.Block.lavaMoving || block == net.minecraft.src.Block
                .lavaStill || block == net.minecraft.src.Block.fire || block == net.minecraft.src.Block
                .snow)
            {
                block = null;
            }
            return i > 0 && block == null && block1.CanPlaceBlockOnSide(this, j, k, l, i1);
        }

        public virtual net.minecraft.src.PathEntity GetPathToEntity(net.minecraft.src.Entity
             entity, net.minecraft.src.Entity entity1, float f)
        {
            int i = net.minecraft.src.MathHelper.Floor_double(entity.posX);
            int j = net.minecraft.src.MathHelper.Floor_double(entity.posY);
            int k = net.minecraft.src.MathHelper.Floor_double(entity.posZ);
            int l = (int)(f + 16F);
            int i1 = i - l;
            int j1 = j - l;
            int k1 = k - l;
            int l1 = i + l;
            int i2 = j + l;
            int j2 = k + l;
            net.minecraft.src.ChunkCache chunkcache = new net.minecraft.src.ChunkCache(this,
                i1, j1, k1, l1, i2, j2);
            return (new net.minecraft.src.Pathfinder(chunkcache)).CreateEntityPathTo(entity,
                entity1, f);
        }

        public virtual net.minecraft.src.PathEntity GetEntityPathToXYZ(net.minecraft.src.Entity
             entity, int i, int j, int k, float f)
        {
            int l = net.minecraft.src.MathHelper.Floor_double(entity.posX);
            int i1 = net.minecraft.src.MathHelper.Floor_double(entity.posY);
            int j1 = net.minecraft.src.MathHelper.Floor_double(entity.posZ);
            int k1 = (int)(f + 8F);
            int l1 = l - k1;
            int i2 = i1 - k1;
            int j2 = j1 - k1;
            int k2 = l + k1;
            int l2 = i1 + k1;
            int i3 = j1 + k1;
            net.minecraft.src.ChunkCache chunkcache = new net.minecraft.src.ChunkCache(this,
                l1, i2, j2, k2, l2, i3);
            return (new net.minecraft.src.Pathfinder(chunkcache)).CreateEntityPathTo(entity,
                i, j, k, f);
        }

        public virtual bool IsBlockProvidingPowerTo(int i, int j, int k, int l)
        {
            int i1 = GetBlockId(i, j, k);
            if (i1 == 0)
            {
                return false;
            }
            else
            {
                return net.minecraft.src.Block.blocksList[i1].IsIndirectlyPoweringTo(this, i, j,
                    k, l);
            }
        }

        public virtual bool IsBlockGettingPowered(int i, int j, int k)
        {
            if (IsBlockProvidingPowerTo(i, j - 1, k, 0))
            {
                return true;
            }
            if (IsBlockProvidingPowerTo(i, j + 1, k, 1))
            {
                return true;
            }
            if (IsBlockProvidingPowerTo(i, j, k - 1, 2))
            {
                return true;
            }
            if (IsBlockProvidingPowerTo(i, j, k + 1, 3))
            {
                return true;
            }
            if (IsBlockProvidingPowerTo(i - 1, j, k, 4))
            {
                return true;
            }
            return IsBlockProvidingPowerTo(i + 1, j, k, 5);
        }

        public virtual bool IsBlockIndirectlyProvidingPowerTo(int i, int j, int k, int l)
        {
            if (IsBlockNormalCube(i, j, k))
            {
                return IsBlockGettingPowered(i, j, k);
            }
            int i1 = GetBlockId(i, j, k);
            if (i1 == 0)
            {
                return false;
            }
            else
            {
                return net.minecraft.src.Block.blocksList[i1].IsPoweringTo(this, i, j, k, l);
            }
        }

        public virtual bool IsBlockIndirectlyGettingPowered(int i, int j, int k)
        {
            if (IsBlockIndirectlyProvidingPowerTo(i, j - 1, k, 0))
            {
                return true;
            }
            if (IsBlockIndirectlyProvidingPowerTo(i, j + 1, k, 1))
            {
                return true;
            }
            if (IsBlockIndirectlyProvidingPowerTo(i, j, k - 1, 2))
            {
                return true;
            }
            if (IsBlockIndirectlyProvidingPowerTo(i, j, k + 1, 3))
            {
                return true;
            }
            if (IsBlockIndirectlyProvidingPowerTo(i - 1, j, k, 4))
            {
                return true;
            }
            return IsBlockIndirectlyProvidingPowerTo(i + 1, j, k, 5);
        }

        public virtual net.minecraft.src.EntityPlayer GetClosestPlayerToEntity(net.minecraft.src.Entity
             entity, double d)
        {
            return GetClosestPlayer(entity.posX, entity.posY, entity.posZ, d);
        }

        public virtual net.minecraft.src.EntityPlayer GetClosestPlayer(double d, double d1
            , double d2, double d3)
        {
            double d4 = -1D;
            net.minecraft.src.EntityPlayer entityplayer = null;
            for (int i = 0; i < playerEntities.Count; i++)
            {
                net.minecraft.src.EntityPlayer entityplayer1 = (net.minecraft.src.EntityPlayer)playerEntities
                    [i];
                double d5 = entityplayer1.GetDistanceSq(d, d1, d2);
                if ((d3 < 0.0D || d5 < d3 * d3) && (d4 == -1D || d5 < d4))
                {
                    d4 = d5;
                    entityplayer = entityplayer1;
                }
            }
            return entityplayer;
        }

        public virtual net.minecraft.src.EntityPlayer GetPlayerEntityByName(string s)
        {
            for (int i = 0; i < playerEntities.Count; i++)
            {
                if (s.Equals(((net.minecraft.src.EntityPlayer)playerEntities[i]).username))
                {
                    return (net.minecraft.src.EntityPlayer)playerEntities[i];
                }
            }
            return null;
        }

        public virtual byte[] GetChunkData(int i, int j, int k, int l, int i1, int j1)
        {
            byte[] abyte0 = new byte[(l * i1 * j1 * 5) / 2];
            int k1 = i >> 4;
            int l1 = k >> 4;
            int i2 = (i + l) - 1 >> 4;
            int j2 = (k + j1) - 1 >> 4;
            int k2 = 0;
            int l2 = j;
            int i3 = j + i1;
            if (l2 < 0)
            {
                l2 = 0;
            }
            if (i3 > 128)
            {
                i3 = 128;
            }
            for (int j3 = k1; j3 <= i2; j3++)
            {
                int k3 = i - j3 * 16;
                int l3 = (i + l) - j3 * 16;
                if (k3 < 0)
                {
                    k3 = 0;
                }
                if (l3 > 16)
                {
                    l3 = 16;
                }
                for (int i4 = l1; i4 <= j2; i4++)
                {
                    int j4 = k - i4 * 16;
                    int k4 = (k + j1) - i4 * 16;
                    if (j4 < 0)
                    {
                        j4 = 0;
                    }
                    if (k4 > 16)
                    {
                        k4 = 16;
                    }
                    k2 = GetChunkFromChunkCoords(j3, i4).GetChunkData(abyte0, k3, l2, j4, l3, i3, k4,
                        k2);
                }
            }
            return abyte0;
        }

        public virtual void CheckSessionLock()
        {
            worldFile.Func_22091_b();
        }

        public virtual void SetWorldTime(long l)
        {
            worldInfo.SetWorldTime(l);
        }

        public virtual void Func_32005_b(long l)
        {
            long l1 = l - worldInfo.GetWorldTime();
            for (System.Collections.IEnumerator iterator = scheduledTickSet.GetEnumerator();
                iterator.MoveNext();)
            {
                net.minecraft.src.NextTickListEntry nextticklistentry = (net.minecraft.src.NextTickListEntry
                    )iterator.Current;
                nextticklistentry.scheduledTime += l1;
            }
            SetWorldTime(l);
        }

        public virtual long GetRandomSeed()
        {
            return worldInfo.GetRandomSeed();
        }

        public virtual long GetWorldTime()
        {
            return worldInfo.GetWorldTime();
        }

        public virtual net.minecraft.src.ChunkCoordinates GetSpawnPoint()
        {
            return new net.minecraft.src.ChunkCoordinates(worldInfo.GetSpawnX(), worldInfo.GetSpawnY
                (), worldInfo.GetSpawnZ());
        }

        public virtual bool CanMineBlock(net.minecraft.src.EntityPlayer entityplayer, int
             i, int j, int k)
        {
            return true;
        }

        public virtual void SendTrackedEntityStatusUpdatePacket(net.minecraft.src.Entity
            entity, byte byte0)
        {
        }

        public virtual net.minecraft.src.IChunkProvider GetChunkProvider()
        {
            return chunkProvider;
        }

        public virtual void PlayNoteAt(int i, int j, int k, int l, int i1)
        {
            int j1 = GetBlockId(i, j, k);
            if (j1 > 0)
            {
                net.minecraft.src.Block.blocksList[j1].PlayBlock(this, i, j, k, l, i1);
            }
        }

        public virtual net.minecraft.src.ISaveHandler GetWorldFile()
        {
            return worldFile;
        }

        public virtual net.minecraft.src.WorldInfo GetWorldInfo()
        {
            return worldInfo;
        }

        public virtual void UpdateAllPlayersSleepingFlag()
        {
            allPlayersSleeping = playerEntities.Count > 0;
            System.Collections.IEnumerator iterator = playerEntities.GetEnumerator();
            do
            {
                if (!iterator.MoveNext())
                {
                    break;
                }
                net.minecraft.src.EntityPlayer entityplayer = (net.minecraft.src.EntityPlayer)iterator
                    .Current;
                if (entityplayer.IsSleeping())
                {
                    continue;
                }
                allPlayersSleeping = false;
                break;
            }
            while (true);
        }

        protected internal virtual void WakeUpAllPlayers()
        {
            allPlayersSleeping = false;
            System.Collections.IEnumerator iterator = playerEntities.GetEnumerator();
            do
            {
                if (!iterator.MoveNext())
                {
                    break;
                }
                net.minecraft.src.EntityPlayer entityplayer = (net.minecraft.src.EntityPlayer)iterator
                    .Current;
                if (entityplayer.IsSleeping())
                {
                    entityplayer.WakeUpPlayer(false, false, true);
                }
            }
            while (true);
            ClearWeather();
        }

        public virtual bool IsAllPlayersFullyAsleep()
        {
            if (allPlayersSleeping && !singleplayerWorld)
            {
                for (System.Collections.IEnumerator iterator = playerEntities.GetEnumerator(); iterator
                    .MoveNext();)
                {
                    net.minecraft.src.EntityPlayer entityplayer = (net.minecraft.src.EntityPlayer)iterator
                        .Current;
                    if (!entityplayer.IsPlayerFullyAsleep())
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual float Func_27065_c(float f)
        {
            return (field_27077_D + (field_27076_E - field_27077_D) * f) * Func_27074_d(f);
        }

        public virtual float Func_27074_d(float f)
        {
            return field_27079_B + (field_27078_C - field_27079_B) * f;
        }

        public virtual bool Func_27067_u()
        {
            return (double)Func_27065_c(1.0F) > 0.90000000000000002D;
        }

        public virtual bool Func_27068_v()
        {
            return (double)Func_27074_d(1.0F) > 0.20000000000000001D;
        }

        public virtual bool CanLightningStrikeAt(int i, int j, int k)
        {
            if (!Func_27068_v())
            {
                return false;
            }
            if (!CanBlockSeeTheSky(i, j, k))
            {
                return false;
            }
            if (GetTopSolidOrLiquidBlock(i, k) > j)
            {
                return false;
            }
            net.minecraft.src.BiomeGenBase biomegenbase = GetWorldChunkManager().GetBiomeGenAt
                (i, k);
            if (biomegenbase.GetEnableSnow())
            {
                return false;
            }
            else
            {
                return biomegenbase.CanSpawnLightningBolt();
            }
        }

        public virtual void Func_28102_a(string s, net.minecraft.src.MapDataBase mapdatabase
            )
        {
            field_28105_z.Func_28177_a(s, mapdatabase);
        }

        public virtual net.minecraft.src.MapDataBase Func_28103_a(Type class1,
            string s)
        {
            return field_28105_z.Func_28178_a(class1, s);
        }

        public virtual int Func_28104_b(string s)
        {
            return field_28105_z.Func_28173_a(s);
        }

        public virtual void Func_28097_e(int i, int j, int k, int l, int i1)
        {
            Func_28101_a(null, i, j, k, l, i1);
        }

        public virtual void Func_28101_a(net.minecraft.src.EntityPlayer entityplayer, int
             i, int j, int k, int l, int i1)
        {
            for (int j1 = 0; j1 < worldAccesses.Count; j1++)
            {
                ((net.minecraft.src.IWorldAccess)worldAccesses[j1]).Func_28133_a(entityplayer, i,
                    j, k, l, i1);
            }
        }

        public bool scheduledUpdatesAreImmediate;

        private List<MetadataChunkBlock> LightingUpdateQueue;

        public List<Entity> loadedEntityList;

        private List<Entity> unloadedEntityList;

        private SortedSet<NextTickListEntry> scheduledTickTreeSet;

        private HashSet<NextTickListEntry> scheduledTickSet;

        public List<TileEntity> loadedTileEntityList;

        private List<TileEntity> field_20912_E;

        public List<EntityPlayer> playerEntities;

        public List<Entity> lightningEntities;

        private long field_6159_E;

        public int skylightSubtracted;

        protected internal int distHashCounter;

        protected internal readonly int DIST_HASH_MAGIC = 0x3c6ef35f;

        protected internal float field_27079_B;

        protected internal float field_27078_C;

        protected internal float field_27077_D;

        protected internal float field_27076_E;

        protected internal int field_27075_F;

        public int field_27080_i;

        public bool editingBlocks;

        private long lockTimestamp;

        protected internal int autosavePeriod;

        public int difficultySetting;

        public SharpBukkitLive.SharpBukkit.SharpRandom rand;

        public bool isNewWorld;

        public readonly net.minecraft.src.WorldProvider worldProvider;

        protected internal List<IWorldAccess> worldAccesses;

        protected internal net.minecraft.src.IChunkProvider chunkProvider;

        protected internal readonly net.minecraft.src.ISaveHandler worldFile;

        protected internal net.minecraft.src.WorldInfo worldInfo;

        public bool worldChunkLoadOverride;

        private bool allPlayersSleeping;

        public net.minecraft.src.MapStorage field_28105_z;

        private List<AxisAlignedBB> field_9207_I;

        private bool field_31048_L;

        private int field_4265_J;

        private bool spawnHostileMobs;

        private bool spawnPeacefulMobs;

        internal static int field_4268_y = 0;

        private HashSet<ChunkCoordIntPair> activeChunkSet;

        private int ambientTickCountdown;

        private List<Entity> field_778_L;

        public bool singleplayerWorld;
    }
}