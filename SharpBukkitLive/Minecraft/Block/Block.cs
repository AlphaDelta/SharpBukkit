// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System;
using System.Collections.Generic;

namespace net.minecraft.src
{
    public class Block
    {
        protected internal Block(int i, net.minecraft.src.Material material)
        {
            // Referenced classes of package net.minecraft.src:
            //            Material, IBlockAccess, AxisAlignedBB, EntityPlayer, 
            //            World, ItemStack, EntityItem, Vec3D, 
            //            MovingObjectPosition, StatList, StatCollector, StepSound, 
            //            StepSoundStone, StepSoundSand, BlockStone, BlockGrass, 
            //            BlockDirt, BlockSapling, BlockFlowing, BlockStationary, 
            //            BlockSand, BlockGravel, BlockOre, BlockLog, 
            //            BlockLeaves, BlockSponge, BlockGlass, BlockDispenser, 
            //            BlockSandStone, BlockNote, BlockBed, BlockRail, 
            //            BlockDetectorRail, BlockPistonBase, BlockWeb, BlockTallGrass, 
            //            BlockDeadBush, BlockPistonExtension, BlockCloth, BlockPistonMoving, 
            //            BlockFlower, BlockMushroom, BlockOreStorage, BlockStep, 
            //            BlockTNT, BlockBookshelf, BlockObsidian, BlockTorch, 
            //            BlockFire, BlockMobSpawner, BlockStairs, BlockChest, 
            //            BlockRedstoneWire, BlockWorkbench, BlockCrops, BlockFarmland, 
            //            BlockFurnace, BlockSign, TileEntitySign, BlockDoor, 
            //            BlockLadder, BlockLever, BlockPressurePlate, EnumMobType, 
            //            BlockRedstoneOre, BlockRedstoneTorch, BlockButton, BlockSnow, 
            //            BlockIce, BlockSnowBlock, BlockCactus, BlockClay, 
            //            BlockReed, BlockJukeBox, BlockFence, BlockPumpkin, 
            //            BlockNetherrack, BlockSoulSand, BlockGlowStone, BlockPortal, 
            //            BlockCake, BlockRedstoneRepeater, BlockLockedChest, BlockTrapDoor, 
            //            Item, ItemCloth, ItemLog, ItemSlab, 
            //            ItemSapling, ItemLeaves, ItemPiston, ItemBlock, 
            //            Entity, EntityLiving
            blockConstructorCalled = true;
            enableStats = true;
            stepSound = soundPowderFootstep;
            blockParticleGravity = 1.0F;
            slipperiness = 0.6F;
            if (blocksList[i] != null)
            {
                throw new System.ArgumentException((new java.lang.StringBuilder()).Append("Slot "
                    ).Append(i).Append(" is already occupied by ").Append(blocksList[i]).Append(" when adding "
                    ).Append(this).ToString());
            }
            else
            {
                blockMaterial = material;
                blocksList[i] = this;
                blockID = i;
                SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 1.0F, 1.0F);
                opaqueCubeLookup[i] = IsOpaqueCube();
                lightOpacity[i] = IsOpaqueCube() ? 255 : 0;
                canBlockGrass[i] = !material.GetCanBlockGrass();
                isBlockContainer[i] = false;
                return;
            }
        }

        protected internal virtual net.minecraft.src.Block SetRequiresSelfNotify()
        {
            requiresSelfNotify[blockID] = true;
            return this;
        }

        protected internal virtual void SetFireBurnRates()
        {
        }

        protected internal Block(int i, int j, net.minecraft.src.Material material)
            : this(i, material)
        {
            blockIndexInTexture = j;
        }

        protected internal virtual net.minecraft.src.Block SetStepSound(net.minecraft.src.StepSound
             stepsound)
        {
            stepSound = stepsound;
            return this;
        }

        protected internal virtual net.minecraft.src.Block SetLightOpacity(int i)
        {
            lightOpacity[blockID] = i;
            return this;
        }

        protected internal virtual net.minecraft.src.Block SetLightValue(float f)
        {
            lightValue[blockID] = (int)(15F * f);
            return this;
        }

        protected internal virtual net.minecraft.src.Block SetResistance(float f)
        {
            blockResistance = f * 3F;
            return this;
        }

        public virtual bool IsACube()
        {
            return true;
        }

        protected internal virtual net.minecraft.src.Block SetHardness(float f)
        {
            blockHardness = f;
            if (blockResistance < f * 5F)
            {
                blockResistance = f * 5F;
            }
            return this;
        }

        protected internal virtual net.minecraft.src.Block SetBlockUnbreakable()
        {
            SetHardness(-1F);
            return this;
        }

        public virtual float GetHardness()
        {
            return blockHardness;
        }

        protected internal virtual net.minecraft.src.Block SetTickOnLoad(bool flag)
        {
            tickOnLoad[blockID] = flag;
            return this;
        }

        public virtual void SetBlockBounds(float f, float f1, float f2, float f3, float f4
            , float f5)
        {
            minX = f;
            minY = f1;
            minZ = f2;
            maxX = f3;
            maxY = f4;
            maxZ = f5;
        }

        public virtual bool ShouldSideBeRendered(net.minecraft.src.IBlockAccess iblockaccess
            , int i, int j, int k, int l)
        {
            return iblockaccess.GetBlockMaterial(i, j, k).IsSolid();
        }

        public virtual int GetBlockTextureFromSideAndMetadata(int i, int j)
        {
            return GetBlockTextureFromSide(i);
        }

        public virtual int GetBlockTextureFromSide(int i)
        {
            return blockIndexInTexture;
        }

        public virtual void GetCollidingBoundingBoxes(net.minecraft.src.World world, int i, int j, int k, net.minecraft.src.AxisAlignedBB axisalignedbb, List<AxisAlignedBB> arraylist)
        {
            net.minecraft.src.AxisAlignedBB axisalignedbb1 = GetCollisionBoundingBoxFromPool(
                world, i, j, k);
            if (axisalignedbb1 != null && axisalignedbb.IntersectsWith(axisalignedbb1))
            {
                arraylist.Add(axisalignedbb1);
            }
        }

        public virtual net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
             world, int i, int j, int k)
        {
            return net.minecraft.src.AxisAlignedBB.GetBoundingBoxFromPool((double)i + minX, (
                double)j + minY, (double)k + minZ, (double)i + maxX, (double)j + maxY, (double)k
                 + maxZ);
        }

        public virtual bool IsOpaqueCube()
        {
            return true;
        }

        public virtual bool CanCollideCheck(int i, bool flag)
        {
            return IsCollidable();
        }

        public virtual bool IsCollidable()
        {
            return true;
        }

        public virtual void UpdateTick(net.minecraft.src.World world, int i, int j, int k
            , SharpRandom random)
        {
        }

        public virtual void OnBlockDestroyedByPlayer(net.minecraft.src.World world, int i
            , int j, int k, int l)
        {
        }

        public virtual void OnNeighborBlockChange(net.minecraft.src.World world, int i, int
             j, int k, int l)
        {
        }

        public virtual int TickRate()
        {
            return 10;
        }

        public virtual void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
             k)
        {
        }

        public virtual void OnBlockRemoval(net.minecraft.src.World world, int i, int j, int
             k)
        {
        }

        public virtual int QuantityDropped(SharpRandom random)
        {
            return 1;
        }

        public virtual int IdDropped(int i, SharpRandom random)
        {
            return blockID;
        }

        public virtual float BlockStrength(net.minecraft.src.EntityPlayer entityplayer)
        {
            if (blockHardness < 0.0F)
            {
                return 0.0F;
            }
            if (!entityplayer.CanHarvestBlock(this))
            {
                return 1.0F / blockHardness / 100F;
            }
            else
            {
                return entityplayer.GetCurrentPlayerStrVsBlock(this) / blockHardness / 30F;
            }
        }

        public void DropBlockAsItem(net.minecraft.src.World world, int i, int j, int k, int
             l)
        {
            DropBlockAsItemWithChance(world, i, j, k, l, 1.0F);
        }

        public virtual void DropBlockAsItemWithChance(net.minecraft.src.World world, int
            i, int j, int k, int l, float f)
        {
            if (world.singleplayerWorld)
            {
                return;
            }
            int i1 = QuantityDropped(world.rand);
            for (int j1 = 0; j1 < i1; j1++)
            {
                if (world.rand.NextFloat() > f)
                {
                    continue;
                }
                int k1 = IdDropped(l, world.rand);
                if (k1 > 0)
                {
                    DropBlockAsItem_do(world, i, j, k, new net.minecraft.src.ItemStack(k1, 1, DamageDropped
                        (l)));
                }
            }
        }

        protected internal virtual void DropBlockAsItem_do(net.minecraft.src.World world,
            int i, int j, int k, net.minecraft.src.ItemStack itemstack)
        {
            if (world.singleplayerWorld)
            {
                return;
            }
            else
            {
                float f = 0.7F;
                double d = (double)(world.rand.NextFloat() * f) + (double)(1.0F - f) * 0.5D;
                double d1 = (double)(world.rand.NextFloat() * f) + (double)(1.0F - f) * 0.5D;
                double d2 = (double)(world.rand.NextFloat() * f) + (double)(1.0F - f) * 0.5D;
                net.minecraft.src.EntityItem entityitem = new net.minecraft.src.EntityItem(world,
                    (double)i + d, (double)j + d1, (double)k + d2, itemstack);
                entityitem.delayBeforeCanPickup = 10;
                world.EntityJoinedWorld(entityitem);
                return;
            }
        }

        protected internal virtual int DamageDropped(int i)
        {
            return 0;
        }

        public virtual float GetExplosionResistance(net.minecraft.src.Entity entity)
        {
            return blockResistance / 5F;
        }

        public virtual net.minecraft.src.MovingObjectPosition CollisionRayTrace(net.minecraft.src.World
             world, int i, int j, int k, net.minecraft.src.Vec3D vec3d, net.minecraft.src.Vec3D
             vec3d1)
        {
            SetBlockBoundsBasedOnState(world, i, j, k);
            vec3d = vec3d.AddVector(-i, -j, -k);
            vec3d1 = vec3d1.AddVector(-i, -j, -k);
            net.minecraft.src.Vec3D vec3d2 = vec3d.GetIntermediateWithXValue(vec3d1, minX);
            net.minecraft.src.Vec3D vec3d3 = vec3d.GetIntermediateWithXValue(vec3d1, maxX);
            net.minecraft.src.Vec3D vec3d4 = vec3d.GetIntermediateWithYValue(vec3d1, minY);
            net.minecraft.src.Vec3D vec3d5 = vec3d.GetIntermediateWithYValue(vec3d1, maxY);
            net.minecraft.src.Vec3D vec3d6 = vec3d.GetIntermediateWithZValue(vec3d1, minZ);
            net.minecraft.src.Vec3D vec3d7 = vec3d.GetIntermediateWithZValue(vec3d1, maxZ);
            if (!IsVecInsideYZBounds(vec3d2))
            {
                vec3d2 = null;
            }
            if (!IsVecInsideYZBounds(vec3d3))
            {
                vec3d3 = null;
            }
            if (!IsVecInsideXZBounds(vec3d4))
            {
                vec3d4 = null;
            }
            if (!IsVecInsideXZBounds(vec3d5))
            {
                vec3d5 = null;
            }
            if (!IsVecInsideXYBounds(vec3d6))
            {
                vec3d6 = null;
            }
            if (!IsVecInsideXYBounds(vec3d7))
            {
                vec3d7 = null;
            }
            net.minecraft.src.Vec3D vec3d8 = null;
            if (vec3d2 != null && (vec3d8 == null || vec3d.DistanceTo(vec3d2) < vec3d.DistanceTo
                (vec3d8)))
            {
                vec3d8 = vec3d2;
            }
            if (vec3d3 != null && (vec3d8 == null || vec3d.DistanceTo(vec3d3) < vec3d.DistanceTo
                (vec3d8)))
            {
                vec3d8 = vec3d3;
            }
            if (vec3d4 != null && (vec3d8 == null || vec3d.DistanceTo(vec3d4) < vec3d.DistanceTo
                (vec3d8)))
            {
                vec3d8 = vec3d4;
            }
            if (vec3d5 != null && (vec3d8 == null || vec3d.DistanceTo(vec3d5) < vec3d.DistanceTo
                (vec3d8)))
            {
                vec3d8 = vec3d5;
            }
            if (vec3d6 != null && (vec3d8 == null || vec3d.DistanceTo(vec3d6) < vec3d.DistanceTo
                (vec3d8)))
            {
                vec3d8 = vec3d6;
            }
            if (vec3d7 != null && (vec3d8 == null || vec3d.DistanceTo(vec3d7) < vec3d.DistanceTo
                (vec3d8)))
            {
                vec3d8 = vec3d7;
            }
            if (vec3d8 == null)
            {
                return null;
            }
            byte byte0 = unchecked((byte)(-1));
            if (vec3d8 == vec3d2)
            {
                byte0 = 4;
            }
            if (vec3d8 == vec3d3)
            {
                byte0 = 5;
            }
            if (vec3d8 == vec3d4)
            {
                byte0 = 0;
            }
            if (vec3d8 == vec3d5)
            {
                byte0 = 1;
            }
            if (vec3d8 == vec3d6)
            {
                byte0 = 2;
            }
            if (vec3d8 == vec3d7)
            {
                byte0 = 3;
            }
            return new net.minecraft.src.MovingObjectPosition(i, j, k, byte0, vec3d8.AddVector
                (i, j, k));
        }

        private bool IsVecInsideYZBounds(net.minecraft.src.Vec3D vec3d)
        {
            if (vec3d == null)
            {
                return false;
            }
            else
            {
                return vec3d.yCoord >= minY && vec3d.yCoord <= maxY && vec3d.zCoord >= minZ && vec3d
                    .zCoord <= maxZ;
            }
        }

        private bool IsVecInsideXZBounds(net.minecraft.src.Vec3D vec3d)
        {
            if (vec3d == null)
            {
                return false;
            }
            else
            {
                return vec3d.xCoord >= minX && vec3d.xCoord <= maxX && vec3d.zCoord >= minZ && vec3d
                    .zCoord <= maxZ;
            }
        }

        private bool IsVecInsideXYBounds(net.minecraft.src.Vec3D vec3d)
        {
            if (vec3d == null)
            {
                return false;
            }
            else
            {
                return vec3d.xCoord >= minX && vec3d.xCoord <= maxX && vec3d.yCoord >= minY && vec3d
                    .yCoord <= maxY;
            }
        }

        public virtual void OnBlockDestroyedByExplosion(net.minecraft.src.World world, int
             i, int j, int k)
        {
        }

        public virtual bool CanPlaceBlockOnSide(net.minecraft.src.World world, int i, int
             j, int k, int l)
        {
            return CanPlaceBlockAt(world, i, j, k);
        }

        public virtual bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j,
            int k)
        {
            int l = world.GetBlockId(i, j, k);
            return l == 0 || blocksList[l].blockMaterial.Func_27090_g();
        }

        public virtual bool BlockActivated(net.minecraft.src.World world, int i, int j, int
             k, net.minecraft.src.EntityPlayer entityplayer)
        {
            return false;
        }

        public virtual void OnEntityWalking(net.minecraft.src.World world, int i, int j,
            int k, net.minecraft.src.Entity entity)
        {
        }

        public virtual void OnBlockPlaced(net.minecraft.src.World world, int i, int j, int
             k, int l)
        {
        }

        public virtual void OnBlockClicked(net.minecraft.src.World world, int i, int j, int
             k, net.minecraft.src.EntityPlayer entityplayer)
        {
        }

        public virtual void VelocityToAddToEntity(net.minecraft.src.World world, int i, int
             j, int k, net.minecraft.src.Entity entity, net.minecraft.src.Vec3D vec3d)
        {
        }

        public virtual void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
            , int i, int j, int k)
        {
        }

        public virtual bool IsPoweringTo(net.minecraft.src.IBlockAccess iblockaccess, int
             i, int j, int k, int l)
        {
            return false;
        }

        public virtual bool CanProvidePower()
        {
            return false;
        }

        public virtual void OnEntityCollidedWithBlock(net.minecraft.src.World world, int
            i, int j, int k, net.minecraft.src.Entity entity)
        {
        }

        public virtual bool IsIndirectlyPoweringTo(net.minecraft.src.World world, int i,
            int j, int k, int l)
        {
            return false;
        }

        public virtual void HarvestBlock(net.minecraft.src.World world, net.minecraft.src.EntityPlayer
             entityplayer, int i, int j, int k, int l)
        {
            entityplayer.AddStat(net.minecraft.src.StatList.mineBlockStatArray[blockID], 1);
            DropBlockAsItem(world, i, j, k, l);
        }

        public virtual bool CanBlockStay(net.minecraft.src.World world, int i, int j, int
             k)
        {
            return true;
        }

        public virtual void OnBlockPlacedBy(net.minecraft.src.World world, int i, int j,
            int k, net.minecraft.src.EntityLiving entityliving)
        {
        }

        public virtual net.minecraft.src.Block SetBlockName(string s)
        {
            blockName = (new java.lang.StringBuilder()).Append("tile.").Append(s).ToString();
            return this;
        }

        public virtual string GetNameLocalizedForStats()
        {
            return net.minecraft.src.StatCollector.TranslateToLocal((new java.lang.StringBuilder
                ()).Append(GetBlockName()).Append(".name").ToString());
        }

        public virtual string GetBlockName()
        {
            return blockName;
        }

        public virtual void PlayBlock(net.minecraft.src.World world, int i, int j, int k,
            int l, int i1)
        {
        }

        public virtual bool GetEnableStats()
        {
            return enableStats;
        }

        protected internal virtual net.minecraft.src.Block DisableStats()
        {
            enableStats = false;
            return this;
        }

        public virtual int GetMobilityFlag()
        {
            return blockMaterial.GetMaterialMobility();
        }

        //internal static Type _mthclass(string s)
        //{
        //    try
        //    {
        //        return System.Type.ForName(s);
        //    }
        //    catch (System.TypeNotFoundException classnotfoundexception)
        //    {
        //        throw new java.lang.NoClassDefFoundError(classnotfoundexception.Message);
        //    }
        //}

        public static readonly net.minecraft.src.StepSound soundPowderFootstep;

        public static readonly net.minecraft.src.StepSound soundWoodFootstep;

        public static readonly net.minecraft.src.StepSound soundGravelFootstep;

        public static readonly net.minecraft.src.StepSound soundGrassFootstep;

        public static readonly net.minecraft.src.StepSound soundStoneFootstep;

        public static readonly net.minecraft.src.StepSound soundMetalFootstep;

        public static readonly net.minecraft.src.StepSound soundGlassFootstep;

        public static readonly net.minecraft.src.StepSound soundClothFootstep;

        public static readonly net.minecraft.src.StepSound soundSandFootstep;

        public static readonly net.minecraft.src.Block[] blocksList;

        public static readonly bool[] tickOnLoad = new bool[256];

        public static readonly bool[] opaqueCubeLookup = new bool[256];

        public static readonly bool[] isBlockContainer = new bool[256];

        public static readonly int[] lightOpacity = new int[256];

        public static readonly bool[] canBlockGrass;

        public static readonly int[] lightValue = new int[256];

        public static readonly bool[] requiresSelfNotify = new bool[256];

        public static readonly net.minecraft.src.Block stone;

        public static readonly net.minecraft.src.BlockGrass grass;

        public static readonly net.minecraft.src.Block dirt;

        public static readonly net.minecraft.src.Block cobblestone;

        public static readonly net.minecraft.src.Block planks;

        public static readonly net.minecraft.src.Block sapling;

        public static readonly net.minecraft.src.Block bedrock;

        public static readonly net.minecraft.src.Block waterMoving;

        public static readonly net.minecraft.src.Block waterStill;

        public static readonly net.minecraft.src.Block lavaMoving;

        public static readonly net.minecraft.src.Block lavaStill;

        public static readonly net.minecraft.src.Block sand;

        public static readonly net.minecraft.src.Block gravel;

        public static readonly net.minecraft.src.Block oreGold;

        public static readonly net.minecraft.src.Block oreIron;

        public static readonly net.minecraft.src.Block oreCoal;

        public static readonly net.minecraft.src.Block wood;

        public static readonly net.minecraft.src.BlockLeaves leaves;

        public static readonly net.minecraft.src.Block sponge;

        public static readonly net.minecraft.src.Block glass;

        public static readonly net.minecraft.src.Block oreLapis;

        public static readonly net.minecraft.src.Block blockLapis;

        public static readonly net.minecraft.src.Block dispenser;

        public static readonly net.minecraft.src.Block sandStone;

        public static readonly net.minecraft.src.Block musicBlock;

        public static readonly net.minecraft.src.Block bed;

        public static readonly net.minecraft.src.Block railPowered;

        public static readonly net.minecraft.src.Block railDetector;

        public static readonly net.minecraft.src.Block pistonStickyBase;

        public static readonly net.minecraft.src.Block web;

        public static readonly net.minecraft.src.BlockTallGrass tallGrass;

        public static readonly net.minecraft.src.BlockDeadBush deadBush;

        public static readonly net.minecraft.src.Block pistonBase;

        public static readonly net.minecraft.src.BlockPistonExtension pistonExtension;

        public static readonly net.minecraft.src.Block cloth;

        public static readonly net.minecraft.src.BlockPistonMoving pistonMoving;

        public static readonly net.minecraft.src.BlockFlower plantYellow;

        public static readonly net.minecraft.src.BlockFlower plantRed;

        public static readonly net.minecraft.src.BlockFlower mushroomBrown;

        public static readonly net.minecraft.src.BlockFlower mushroomRed;

        public static readonly net.minecraft.src.Block blockGold;

        public static readonly net.minecraft.src.Block blockSteel;

        public static readonly net.minecraft.src.Block stairDouble;

        public static readonly net.minecraft.src.Block stairSingle;

        public static readonly net.minecraft.src.Block brick;

        public static readonly net.minecraft.src.Block tnt;

        public static readonly net.minecraft.src.Block bookShelf;

        public static readonly net.minecraft.src.Block cobblestoneMossy;

        public static readonly net.minecraft.src.Block obsidian;

        public static readonly net.minecraft.src.Block torchWood;

        public static readonly net.minecraft.src.BlockFire fire;

        public static readonly net.minecraft.src.Block mobSpawner;

        public static readonly net.minecraft.src.Block stairCompactPlanks;

        public static readonly net.minecraft.src.Block chest;

        public static readonly net.minecraft.src.Block redstoneWire;

        public static readonly net.minecraft.src.Block oreDiamond;

        public static readonly net.minecraft.src.Block blockDiamond;

        public static readonly net.minecraft.src.Block workbench;

        public static readonly net.minecraft.src.Block crops;

        public static readonly net.minecraft.src.Block tilledField;

        public static readonly net.minecraft.src.Block stoneOvenIdle;

        public static readonly net.minecraft.src.Block stoneOvenActive;

        public static readonly net.minecraft.src.Block signPost;

        public static readonly net.minecraft.src.Block doorWood;

        public static readonly net.minecraft.src.Block ladder;

        public static readonly net.minecraft.src.Block minecartTrack;

        public static readonly net.minecraft.src.Block stairCompactCobblestone;

        public static readonly net.minecraft.src.Block signWall;

        public static readonly net.minecraft.src.Block lever;

        public static readonly net.minecraft.src.Block pressurePlateStone;

        public static readonly net.minecraft.src.Block doorSteel;

        public static readonly net.minecraft.src.Block pressurePlatePlanks;

        public static readonly net.minecraft.src.Block oreRedstone;

        public static readonly net.minecraft.src.Block oreRedstoneGlowing;

        public static readonly net.minecraft.src.Block torchRedstoneIdle;

        public static readonly net.minecraft.src.Block torchRedstoneActive;

        public static readonly net.minecraft.src.Block button;

        public static readonly net.minecraft.src.Block snow;

        public static readonly net.minecraft.src.Block ice;

        public static readonly net.minecraft.src.Block blockSnow;

        public static readonly net.minecraft.src.Block cactus;

        public static readonly net.minecraft.src.Block blockClay;

        public static readonly net.minecraft.src.Block reed;

        public static readonly net.minecraft.src.Block jukebox;

        public static readonly net.minecraft.src.Block fence;

        public static readonly net.minecraft.src.Block pumpkin;

        public static readonly net.minecraft.src.Block bloodStone;

        public static readonly net.minecraft.src.Block slowSand;

        public static readonly net.minecraft.src.Block glowStone;

        public static readonly net.minecraft.src.BlockPortal portal;

        public static readonly net.minecraft.src.Block pumpkinLantern;

        public static readonly net.minecraft.src.Block cake;

        public static readonly net.minecraft.src.Block redstoneRepeaterIdle;

        public static readonly net.minecraft.src.Block redstoneRepeaterActive;

        public static readonly net.minecraft.src.Block lockedChest;

        public static readonly net.minecraft.src.Block trapdoor;

        public int blockIndexInTexture;

        public readonly int blockID;

        protected internal float blockHardness;

        protected internal float blockResistance;

        protected internal bool blockConstructorCalled;

        protected internal bool enableStats;

        public double minX;

        public double minY;

        public double minZ;

        public double maxX;

        public double maxY;

        public double maxZ;

        public net.minecraft.src.StepSound stepSound;

        public float blockParticleGravity;

        public readonly net.minecraft.src.Material blockMaterial;

        public float slipperiness;

        private string blockName;

        static Block()
        {
            soundPowderFootstep = new net.minecraft.src.StepSound("stone", 1.0F, 1.0F);
            soundWoodFootstep = new net.minecraft.src.StepSound("wood", 1.0F, 1.0F);
            soundGravelFootstep = new net.minecraft.src.StepSound("gravel", 1.0F, 1.0F);
            soundGrassFootstep = new net.minecraft.src.StepSound("grass", 1.0F, 1.0F);
            soundStoneFootstep = new net.minecraft.src.StepSound("stone", 1.0F, 1.0F);
            soundMetalFootstep = new net.minecraft.src.StepSound("stone", 1.0F, 1.5F);
            soundGlassFootstep = new net.minecraft.src.StepSoundStone("stone", 1.0F, 1.0F);
            soundClothFootstep = new net.minecraft.src.StepSound("cloth", 1.0F, 1.0F);
            soundSandFootstep = new net.minecraft.src.StepSoundSand("sand", 1.0F, 1.0F);
            blocksList = new net.minecraft.src.Block[256];
            canBlockGrass = new bool[256];
            stone = (new net.minecraft.src.BlockStone(1, 1)).SetHardness(1.5F).SetResistance(
                10F).SetStepSound(soundStoneFootstep).SetBlockName("stone");
            grass = (net.minecraft.src.BlockGrass)(new net.minecraft.src.BlockGrass(2)).SetHardness
                (0.6F).SetStepSound(soundGrassFootstep).SetBlockName("grass");
            dirt = (new net.minecraft.src.BlockDirt(3, 2)).SetHardness(0.5F).SetStepSound(soundGravelFootstep
                ).SetBlockName("dirt");
            cobblestone = (new net.minecraft.src.Block(4, 16, net.minecraft.src.Material.rock
                )).SetHardness(2.0F).SetResistance(10F).SetStepSound(soundStoneFootstep).SetBlockName
                ("stonebrick");
            planks = (new net.minecraft.src.Block(5, 4, net.minecraft.src.Material.wood)).SetHardness
                (2.0F).SetResistance(5F).SetStepSound(soundWoodFootstep).SetBlockName("wood").SetRequiresSelfNotify
                ();
            sapling = (new net.minecraft.src.BlockSapling(6, 15)).SetHardness(0.0F).SetStepSound
                (soundGrassFootstep).SetBlockName("sapling").SetRequiresSelfNotify();
            bedrock = (new net.minecraft.src.Block(7, 17, net.minecraft.src.Material.rock)).SetBlockUnbreakable
                ().SetResistance(6000000F).SetStepSound(soundStoneFootstep).SetBlockName("bedrock"
                ).DisableStats();
            waterMoving = (new net.minecraft.src.BlockFlowing(8, net.minecraft.src.Material.water
                )).SetHardness(100F).SetLightOpacity(3).SetBlockName("water").DisableStats().SetRequiresSelfNotify
                ();
            waterStill = (new net.minecraft.src.BlockStationary(9, net.minecraft.src.Material
                .water)).SetHardness(100F).SetLightOpacity(3).SetBlockName("water").DisableStats
                ().SetRequiresSelfNotify();
            lavaMoving = (new net.minecraft.src.BlockFlowing(10, net.minecraft.src.Material.lava
                )).SetHardness(0.0F).SetLightValue(1.0F).SetLightOpacity(255).SetBlockName("lava"
                ).DisableStats().SetRequiresSelfNotify();
            lavaStill = (new net.minecraft.src.BlockStationary(11, net.minecraft.src.Material
                .lava)).SetHardness(100F).SetLightValue(1.0F).SetLightOpacity(255).SetBlockName(
                "lava").DisableStats().SetRequiresSelfNotify();
            sand = (new net.minecraft.src.BlockSand(12, 18)).SetHardness(0.5F).SetStepSound(soundSandFootstep
                ).SetBlockName("sand");
            gravel = (new net.minecraft.src.BlockGravel(13, 19)).SetHardness(0.6F).SetStepSound
                (soundGravelFootstep).SetBlockName("gravel");
            oreGold = (new net.minecraft.src.BlockOre(14, 32)).SetHardness(3F).SetResistance(
                5F).SetStepSound(soundStoneFootstep).SetBlockName("oreGold");
            oreIron = (new net.minecraft.src.BlockOre(15, 33)).SetHardness(3F).SetResistance(
                5F).SetStepSound(soundStoneFootstep).SetBlockName("oreIron");
            oreCoal = (new net.minecraft.src.BlockOre(16, 34)).SetHardness(3F).SetResistance(
                5F).SetStepSound(soundStoneFootstep).SetBlockName("oreCoal");
            wood = (new net.minecraft.src.BlockLog(17)).SetHardness(2.0F).SetStepSound(soundWoodFootstep
                ).SetBlockName("log").SetRequiresSelfNotify();
            leaves = (net.minecraft.src.BlockLeaves)(new net.minecraft.src.BlockLeaves(18, 52
                )).SetHardness(0.2F).SetLightOpacity(1).SetStepSound(soundGrassFootstep).SetBlockName
                ("leaves").DisableStats().SetRequiresSelfNotify();
            sponge = (new net.minecraft.src.BlockSponge(19)).SetHardness(0.6F).SetStepSound(soundGrassFootstep
                ).SetBlockName("sponge");
            glass = (new net.minecraft.src.BlockGlass(20, 49, net.minecraft.src.Material.glass
                , false)).SetHardness(0.3F).SetStepSound(soundGlassFootstep).SetBlockName("glass"
                );
            oreLapis = (new net.minecraft.src.BlockOre(21, 160)).SetHardness(3F).SetResistance
                (5F).SetStepSound(soundStoneFootstep).SetBlockName("oreLapis");
            blockLapis = (new net.minecraft.src.Block(22, 144, net.minecraft.src.Material.rock
                )).SetHardness(3F).SetResistance(5F).SetStepSound(soundStoneFootstep).SetBlockName
                ("blockLapis");
            dispenser = (new net.minecraft.src.BlockDispenser(23)).SetHardness(3.5F).SetStepSound
                (soundStoneFootstep).SetBlockName("dispenser").SetRequiresSelfNotify();
            sandStone = (new net.minecraft.src.BlockSandStone(24)).SetStepSound(soundStoneFootstep
                ).SetHardness(0.8F).SetBlockName("sandStone");
            musicBlock = (new net.minecraft.src.BlockNote(25)).SetHardness(0.8F).SetBlockName
                ("musicBlock").SetRequiresSelfNotify();
            bed = (new net.minecraft.src.BlockBed(26)).SetHardness(0.2F).SetBlockName("bed").
                DisableStats().SetRequiresSelfNotify();
            railPowered = (new net.minecraft.src.BlockRail(27, 179, true)).SetHardness(0.7F).
                SetStepSound(soundMetalFootstep).SetBlockName("goldenRail").SetRequiresSelfNotify
                ();
            railDetector = (new net.minecraft.src.BlockDetectorRail(28, 195)).SetHardness(0.7F
                ).SetStepSound(soundMetalFootstep).SetBlockName("detectorRail").SetRequiresSelfNotify
                ();
            pistonStickyBase = (new net.minecraft.src.BlockPistonBase(29, 106, true)).SetBlockName
                ("pistonStickyBase").SetRequiresSelfNotify();
            web = (new net.minecraft.src.BlockWeb(30, 11)).SetLightOpacity(1).SetHardness(4F)
                .SetBlockName("web");
            tallGrass = (net.minecraft.src.BlockTallGrass)(new net.minecraft.src.BlockTallGrass
                (31, 39)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetBlockName("tallgrass"
                );
            deadBush = (net.minecraft.src.BlockDeadBush)(new net.minecraft.src.BlockDeadBush(
                32, 55)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetBlockName("deadbush"
                );
            pistonBase = (new net.minecraft.src.BlockPistonBase(33, 107, false)).SetBlockName
                ("pistonBase").SetRequiresSelfNotify();
            pistonExtension = (net.minecraft.src.BlockPistonExtension)(new net.minecraft.src.BlockPistonExtension
                (34, 107)).SetRequiresSelfNotify();
            cloth = (new net.minecraft.src.BlockCloth()).SetHardness(0.8F).SetStepSound(soundClothFootstep
                ).SetBlockName("cloth").SetRequiresSelfNotify();
            pistonMoving = new net.minecraft.src.BlockPistonMoving(36);
            plantYellow = (net.minecraft.src.BlockFlower)(new net.minecraft.src.BlockFlower(37
                , 13)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetBlockName("flower");
            plantRed = (net.minecraft.src.BlockFlower)(new net.minecraft.src.BlockFlower(38,
                12)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetBlockName("rose");
            mushroomBrown = (net.minecraft.src.BlockFlower)(new net.minecraft.src.BlockMushroom
                (39, 29)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetLightValue(0.125F
                ).SetBlockName("mushroom");
            mushroomRed = (net.minecraft.src.BlockFlower)(new net.minecraft.src.BlockMushroom
                (40, 28)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetBlockName("mushroom"
                );
            blockGold = (new net.minecraft.src.BlockOreStorage(41, 23)).SetHardness(3F).SetResistance
                (10F).SetStepSound(soundMetalFootstep).SetBlockName("blockGold");
            blockSteel = (new net.minecraft.src.BlockOreStorage(42, 22)).SetHardness(5F).SetResistance
                (10F).SetStepSound(soundMetalFootstep).SetBlockName("blockIron");
            stairDouble = (new net.minecraft.src.BlockStep(43, true)).SetHardness(2.0F).SetResistance
                (10F).SetStepSound(soundStoneFootstep).SetBlockName("stoneSlab");
            stairSingle = (new net.minecraft.src.BlockStep(44, false)).SetHardness(2.0F).SetResistance
                (10F).SetStepSound(soundStoneFootstep).SetBlockName("stoneSlab");
            brick = (new net.minecraft.src.Block(45, 7, net.minecraft.src.Material.rock)).SetHardness
                (2.0F).SetResistance(10F).SetStepSound(soundStoneFootstep).SetBlockName("brick");
            tnt = (new net.minecraft.src.BlockTNT(46, 8)).SetHardness(0.0F).SetStepSound(soundGrassFootstep
                ).SetBlockName("tnt");
            bookShelf = (new net.minecraft.src.BlockBookshelf(47, 35)).SetHardness(1.5F).SetStepSound
                (soundWoodFootstep).SetBlockName("bookshelf");
            cobblestoneMossy = (new net.minecraft.src.Block(48, 36, net.minecraft.src.Material
                .rock)).SetHardness(2.0F).SetResistance(10F).SetStepSound(soundStoneFootstep).SetBlockName
                ("stoneMoss");
            obsidian = (new net.minecraft.src.BlockObsidian(49, 37)).SetHardness(10F).SetResistance
                (2000F).SetStepSound(soundStoneFootstep).SetBlockName("obsidian");
            torchWood = (new net.minecraft.src.BlockTorch(50, 80)).SetHardness(0.0F).SetLightValue
                (0.9375F).SetStepSound(soundWoodFootstep).SetBlockName("torch").SetRequiresSelfNotify
                ();
            fire = (net.minecraft.src.BlockFire)(new net.minecraft.src.BlockFire(51, 31)).SetHardness
                (0.0F).SetLightValue(1.0F).SetStepSound(soundWoodFootstep).SetBlockName("fire").
                DisableStats().SetRequiresSelfNotify();
            mobSpawner = (new net.minecraft.src.BlockMobSpawner(52, 65)).SetHardness(5F).SetStepSound
                (soundMetalFootstep).SetBlockName("mobSpawner").DisableStats();
            stairCompactPlanks = (new net.minecraft.src.BlockStairs(53, planks)).SetBlockName
                ("stairsWood").SetRequiresSelfNotify();
            chest = (new net.minecraft.src.BlockChest(54)).SetHardness(2.5F).SetStepSound(soundWoodFootstep
                ).SetBlockName("chest").SetRequiresSelfNotify();
            redstoneWire = (new net.minecraft.src.BlockRedstoneWire(55, 164)).SetHardness(0.0F
                ).SetStepSound(soundPowderFootstep).SetBlockName("redstoneDust").DisableStats().
                SetRequiresSelfNotify();
            oreDiamond = (new net.minecraft.src.BlockOre(56, 50)).SetHardness(3F).SetResistance
                (5F).SetStepSound(soundStoneFootstep).SetBlockName("oreDiamond");
            blockDiamond = (new net.minecraft.src.BlockOreStorage(57, 24)).SetHardness(5F).SetResistance
                (10F).SetStepSound(soundMetalFootstep).SetBlockName("blockDiamond");
            workbench = (new net.minecraft.src.BlockWorkbench(58)).SetHardness(2.5F).SetStepSound
                (soundWoodFootstep).SetBlockName("workbench");
            crops = (new net.minecraft.src.BlockCrops(59, 88)).SetHardness(0.0F).SetStepSound
                (soundGrassFootstep).SetBlockName("crops").DisableStats().SetRequiresSelfNotify(
                );
            tilledField = (new net.minecraft.src.BlockFarmland(60)).SetHardness(0.6F).SetStepSound
                (soundGravelFootstep).SetBlockName("farmland");
            stoneOvenIdle = (new net.minecraft.src.BlockFurnace(61, false)).SetHardness(3.5F)
                .SetStepSound(soundStoneFootstep).SetBlockName("furnace").SetRequiresSelfNotify(
                );
            stoneOvenActive = (new net.minecraft.src.BlockFurnace(62, true)).SetHardness(3.5F
                ).SetStepSound(soundStoneFootstep).SetLightValue(0.875F).SetBlockName("furnace")
                .SetRequiresSelfNotify();
            signPost = (new net.minecraft.src.BlockSign(63, Sharpen.Runtime.GetClassForType(typeof(
                net.minecraft.src.TileEntitySign)), true)).SetHardness(1.0F).SetStepSound(soundWoodFootstep
                ).SetBlockName("sign").DisableStats().SetRequiresSelfNotify();
            doorWood = (new net.minecraft.src.BlockDoor(64, net.minecraft.src.Material.wood))
                .SetHardness(3F).SetStepSound(soundWoodFootstep).SetBlockName("doorWood").DisableStats
                ().SetRequiresSelfNotify();
            ladder = (new net.minecraft.src.BlockLadder(65, 83)).SetHardness(0.4F).SetStepSound
                (soundWoodFootstep).SetBlockName("ladder").SetRequiresSelfNotify();
            minecartTrack = (new net.minecraft.src.BlockRail(66, 128, false)).SetHardness(0.7F
                ).SetStepSound(soundMetalFootstep).SetBlockName("rail").SetRequiresSelfNotify();
            stairCompactCobblestone = (new net.minecraft.src.BlockStairs(67, cobblestone)).SetBlockName
                ("stairsStone").SetRequiresSelfNotify();
            signWall = (new net.minecraft.src.BlockSign(68, Sharpen.Runtime.GetClassForType(typeof(
                net.minecraft.src.TileEntitySign)), false)).SetHardness(1.0F).SetStepSound(soundWoodFootstep
                ).SetBlockName("sign").DisableStats().SetRequiresSelfNotify();
            lever = (new net.minecraft.src.BlockLever(69, 96)).SetHardness(0.5F).SetStepSound
                (soundWoodFootstep).SetBlockName("lever").SetRequiresSelfNotify();
            pressurePlateStone = (new net.minecraft.src.BlockPressurePlate(70, stone.blockIndexInTexture
                , net.minecraft.src.EnumMobType.mobs, net.minecraft.src.Material.rock)).SetHardness
                (0.5F).SetStepSound(soundStoneFootstep).SetBlockName("pressurePlate").SetRequiresSelfNotify
                ();
            doorSteel = (new net.minecraft.src.BlockDoor(71, net.minecraft.src.Material.iron)
                ).SetHardness(5F).SetStepSound(soundMetalFootstep).SetBlockName("doorIron").DisableStats
                ().SetRequiresSelfNotify();
            pressurePlatePlanks = (new net.minecraft.src.BlockPressurePlate(72, planks.blockIndexInTexture
                , net.minecraft.src.EnumMobType.everything, net.minecraft.src.Material.wood)).SetHardness
                (0.5F).SetStepSound(soundWoodFootstep).SetBlockName("pressurePlate").SetRequiresSelfNotify
                ();
            oreRedstone = (new net.minecraft.src.BlockRedstoneOre(73, 51, false)).SetHardness
                (3F).SetResistance(5F).SetStepSound(soundStoneFootstep).SetBlockName("oreRedstone"
                ).SetRequiresSelfNotify();
            oreRedstoneGlowing = (new net.minecraft.src.BlockRedstoneOre(74, 51, true)).SetLightValue
                (0.625F).SetHardness(3F).SetResistance(5F).SetStepSound(soundStoneFootstep).SetBlockName
                ("oreRedstone").SetRequiresSelfNotify();
            torchRedstoneIdle = (new net.minecraft.src.BlockRedstoneTorch(75, 115, false)).SetHardness
                (0.0F).SetStepSound(soundWoodFootstep).SetBlockName("notGate").SetRequiresSelfNotify
                ();
            torchRedstoneActive = (new net.minecraft.src.BlockRedstoneTorch(76, 99, true)).SetHardness
                (0.0F).SetLightValue(0.5F).SetStepSound(soundWoodFootstep).SetBlockName("notGate"
                ).SetRequiresSelfNotify();
            button = (new net.minecraft.src.BlockButton(77, stone.blockIndexInTexture)).SetHardness
                (0.5F).SetStepSound(soundStoneFootstep).SetBlockName("button").SetRequiresSelfNotify
                ();
            snow = (new net.minecraft.src.BlockSnow(78, 66)).SetHardness(0.1F).SetStepSound(soundClothFootstep
                ).SetBlockName("snow");
            ice = (new net.minecraft.src.BlockIce(79, 67)).SetHardness(0.5F).SetLightOpacity(
                3).SetStepSound(soundGlassFootstep).SetBlockName("ice");
            blockSnow = (new net.minecraft.src.BlockSnowBlock(80, 66)).SetHardness(0.2F).SetStepSound
                (soundClothFootstep).SetBlockName("snow");
            cactus = (new net.minecraft.src.BlockCactus(81, 70)).SetHardness(0.4F).SetStepSound
                (soundClothFootstep).SetBlockName("cactus");
            blockClay = (new net.minecraft.src.BlockClay(82, 72)).SetHardness(0.6F).SetStepSound
                (soundGravelFootstep).SetBlockName("clay");
            reed = (new net.minecraft.src.BlockReed(83, 73)).SetHardness(0.0F).SetStepSound(soundGrassFootstep
                ).SetBlockName("reeds").DisableStats();
            jukebox = (new net.minecraft.src.BlockJukeBox(84, 74)).SetHardness(2.0F).SetResistance
                (10F).SetStepSound(soundStoneFootstep).SetBlockName("jukebox").SetRequiresSelfNotify
                ();
            fence = (new net.minecraft.src.BlockFence(85, 4)).SetHardness(2.0F).SetResistance
                (5F).SetStepSound(soundWoodFootstep).SetBlockName("fence").SetRequiresSelfNotify
                ();
            pumpkin = (new net.minecraft.src.BlockPumpkin(86, 102, false)).SetHardness(1.0F).
                SetStepSound(soundWoodFootstep).SetBlockName("pumpkin").SetRequiresSelfNotify();
            bloodStone = (new net.minecraft.src.BlockNetherrack(87, 103)).SetHardness(0.4F).SetStepSound
                (soundStoneFootstep).SetBlockName("hellrock");
            slowSand = (new net.minecraft.src.BlockSoulSand(88, 104)).SetHardness(0.5F).SetStepSound
                (soundSandFootstep).SetBlockName("hellsand");
            glowStone = (new net.minecraft.src.BlockGlowStone(89, 105, net.minecraft.src.Material
                .rock)).SetHardness(0.3F).SetStepSound(soundGlassFootstep).SetLightValue(1.0F).SetBlockName
                ("lightgem");
            portal = (net.minecraft.src.BlockPortal)(new net.minecraft.src.BlockPortal(90, 14
                )).SetHardness(-1F).SetStepSound(soundGlassFootstep).SetLightValue(0.75F).SetBlockName
                ("portal");
            pumpkinLantern = (new net.minecraft.src.BlockPumpkin(91, 102, true)).SetHardness(
                1.0F).SetStepSound(soundWoodFootstep).SetLightValue(1.0F).SetBlockName("litpumpkin"
                ).SetRequiresSelfNotify();
            cake = (new net.minecraft.src.BlockCake(92, 121)).SetHardness(0.5F).SetStepSound(
                soundClothFootstep).SetBlockName("cake").DisableStats().SetRequiresSelfNotify();
            redstoneRepeaterIdle = (new net.minecraft.src.BlockRedstoneRepeater(93, false)).SetHardness
                (0.0F).SetStepSound(soundWoodFootstep).SetBlockName("diode").DisableStats().SetRequiresSelfNotify
                ();
            redstoneRepeaterActive = (new net.minecraft.src.BlockRedstoneRepeater(94, true)).
                SetHardness(0.0F).SetLightValue(0.625F).SetStepSound(soundWoodFootstep).SetBlockName
                ("diode").DisableStats().SetRequiresSelfNotify();
            lockedChest = (new net.minecraft.src.BlockLockedChest(95)).SetHardness(0.0F).SetLightValue
                (1.0F).SetStepSound(soundWoodFootstep).SetBlockName("lockedchest").SetTickOnLoad
                (true).SetRequiresSelfNotify();
            trapdoor = (new net.minecraft.src.BlockTrapDoor(96, net.minecraft.src.Material.wood
                )).SetHardness(3F).SetStepSound(soundWoodFootstep).SetBlockName("trapdoor").DisableStats
                ().SetRequiresSelfNotify();
            net.minecraft.src.Item.itemsList[cloth.blockID] = (new net.minecraft.src.ItemCloth
                (cloth.blockID - 256)).SetItemName("cloth");
            net.minecraft.src.Item.itemsList[wood.blockID] = (new net.minecraft.src.ItemLog(wood
                .blockID - 256)).SetItemName("log");
            net.minecraft.src.Item.itemsList[stairSingle.blockID] = (new net.minecraft.src.ItemSlab
                (stairSingle.blockID - 256)).SetItemName("stoneSlab");
            net.minecraft.src.Item.itemsList[sapling.blockID] = (new net.minecraft.src.ItemSapling
                (sapling.blockID - 256)).SetItemName("sapling");
            net.minecraft.src.Item.itemsList[leaves.blockID] = (new net.minecraft.src.ItemLeaves
                (leaves.blockID - 256)).SetItemName("leaves");
            net.minecraft.src.Item.itemsList[pistonBase.blockID] = new net.minecraft.src.ItemPiston
                (pistonBase.blockID - 256);
            net.minecraft.src.Item.itemsList[pistonStickyBase.blockID] = new net.minecraft.src.ItemPiston
                (pistonStickyBase.blockID - 256);
            for (int i = 0; i < 256; i++)
            {
                if (blocksList[i] != null && net.minecraft.src.Item.itemsList[i] == null)
                {
                    net.minecraft.src.Item.itemsList[i] = new net.minecraft.src.ItemBlock(i - 256);
                    blocksList[i].SetFireBurnRates();
                }
            }
            canBlockGrass[0] = true;
            net.minecraft.src.StatList.Func_25088_a();
        }
    }
}
