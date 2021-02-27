// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive;
using Sharpen;
using System;
using System.Collections;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class Chunk
	{
		public Chunk(net.minecraft.src.World world, int i, int j)
		{
			// Referenced classes of package net.minecraft.src:
			//            NibbleArray, Block, World, WorldProvider, 
			//            EnumSkyBlock, Entity, MathHelper, ChunkPosition, 
			//            TileEntity, BlockContainer, AxisAlignedBB, ChunkBlockMap
			chunkTileEntityMap = new SharpBukkitLive.NullSafeDictionary<ChunkPosition, TileEntity>();
			entities = new List<Entity>[8];
			isTerrainPopulated = false;
			isModified = false;
			hasEntities = false;
			lastSaveTime = 0L;
			worldObj = world;
			xPosition = i;
			zPosition = j;
			heightMap = new byte[256];
			for (int k = 0; k < entities.Length; k++)
			{
				entities[k] = new List<Entity>();
			}
		}

		public Chunk(net.minecraft.src.World world, byte[] abyte0, int i, int j)
			: this(world, i, j)
		{
			blocks = abyte0;
			data = new net.minecraft.src.NibbleArray(abyte0.Length);
			skylightMap = new net.minecraft.src.NibbleArray(abyte0.Length);
			blocklightMap = new net.minecraft.src.NibbleArray(abyte0.Length);
		}

		public virtual bool IsAtLocation(int i, int j)
		{
			return i == xPosition && j == zPosition;
		}

		public virtual int GetHeightValue(int i, int j)
		{
			return heightMap[j << 4 | i];
		}

		public virtual void Func_348_a()
		{
		}

		public virtual void Func_353_b()
		{
			int i = 127;
			for (int j = 0; j < 16; j++)
			{
				for (int l = 0; l < 16; l++)
				{
					int j1 = 127;
					int k1;
					for (k1 = j << 11 | l << 7; j1 > 0 && net.minecraft.src.Block.lightOpacity[blocks
						[(k1 + j1) - 1]] == 0; j1--)
					{
					}
					heightMap[l << 4 | j] = unchecked((byte)j1);
					if (j1 < i)
					{
						i = j1;
					}
					if (worldObj.worldProvider.field_4306_c)
					{
						continue;
					}
					int l1 = 15;
					int i2 = 127;
					do
					{
						l1 -= net.minecraft.src.Block.lightOpacity[blocks[k1 + i2]];
						if (l1 > 0)
						{
							skylightMap.SetNibble(j, i2, l, l1);
						}
					}
					while (--i2 > 0 && l1 > 0);
				}
			}
			field_686_i = i;
			for (int k = 0; k < 16; k++)
			{
				for (int i1 = 0; i1 < 16; i1++)
				{
					Func_333_c(k, i1);
				}
			}
			isModified = true;
		}

		public virtual void Func_4053_c()
		{
		}

		private void Func_333_c(int i, int j)
		{
			int k = GetHeightValue(i, j);
			int l = xPosition * 16 + i;
			int i1 = zPosition * 16 + j;
			Func_355_f(l - 1, i1, k);
			Func_355_f(l + 1, i1, k);
			Func_355_f(l, i1 - 1, k);
			Func_355_f(l, i1 + 1, k);
		}

		private void Func_355_f(int i, int j, int k)
		{
			int l = worldObj.GetHeightValue(i, j);
			if (l > k)
			{
				worldObj.ScheduleLightingUpdate(net.minecraft.src.EnumSkyBlock.Sky, i, k, j, i, l
					, j);
				isModified = true;
			}
			else
			{
				if (l < k)
				{
					worldObj.ScheduleLightingUpdate(net.minecraft.src.EnumSkyBlock.Sky, i, l, j, i, k
						, j);
					isModified = true;
				}
			}
		}

		private void Func_339_g(int i, int j, int k)
		{
			int l = heightMap[k << 4 | i];
			int i1 = l;
			if (j > l)
			{
				i1 = j;
			}
			for (int j1 = i << 11 | k << 7; i1 > 0 && net.minecraft.src.Block.lightOpacity[blocks
				[(j1 + i1) - 1]] == 0; i1--)
			{
			}
			if (i1 == l)
			{
				return;
			}
			worldObj.MarkBlocksDirtyVertical(i, k, i1, l);
			heightMap[k << 4 | i] = unchecked((byte)i1);
			if (i1 < field_686_i)
			{
				field_686_i = i1;
			}
			else
			{
				int k1 = 127;
				for (int i2 = 0; i2 < 16; i2++)
				{
					for (int k2 = 0; k2 < 16; k2++)
					{
						if ((heightMap[k2 << 4 | i2]) < k1)
						{
							k1 = heightMap[k2 << 4 | i2];
						}
					}
				}
				field_686_i = k1;
			}
			int l1 = xPosition * 16 + i;
			int j2 = zPosition * 16 + k;
			if (i1 < l)
			{
				for (int l2 = i1; l2 < l; l2++)
				{
					skylightMap.SetNibble(i, l2, k, 15);
				}
			}
			else
			{
				worldObj.ScheduleLightingUpdate(net.minecraft.src.EnumSkyBlock.Sky, l1, l, j2, l1
					, i1, j2);
				for (int i3 = l; i3 < i1; i3++)
				{
					skylightMap.SetNibble(i, i3, k, 0);
				}
			}
			int j3 = 15;
			int k3 = i1;
			while (i1 > 0 && j3 > 0)
			{
				i1--;
				int l3 = net.minecraft.src.Block.lightOpacity[GetBlockID(i, i1, k)];
				if (l3 == 0)
				{
					l3 = 1;
				}
				j3 -= l3;
				if (j3 < 0)
				{
					j3 = 0;
				}
				skylightMap.SetNibble(i, i1, k, j3);
			}
			for (; i1 > 0 && net.minecraft.src.Block.lightOpacity[GetBlockID(i, i1 - 1, k)] ==
				 0; i1--)
			{
			}
			if (i1 != k3)
			{
				worldObj.ScheduleLightingUpdate(net.minecraft.src.EnumSkyBlock.Sky, l1 - 1, i1, j2
					 - 1, l1 + 1, k3, j2 + 1);
			}
			isModified = true;
		}

		public virtual int GetBlockID(int i, int j, int k)
		{
			return blocks[i << 11 | k << 7 | j];
		}

		public virtual bool SetBlockIDWithMetadata(int i, int j, int k, int l, int i1)
		{
			byte byte0 = unchecked((byte)l);
			int j1 = heightMap[k << 4 | i];
			int k1 = blocks[i << 11 | k << 7 | j];
			if (k1 == l && data.GetNibble(i, j, k) == i1)
			{
				return false;
			}
			int l1 = xPosition * 16 + i;
			int i2 = zPosition * 16 + k;
			blocks[i << 11 | k << 7 | j] = byte0;
			if (k1 != 0 && !worldObj.singleplayerWorld)
			{
				net.minecraft.src.Block.blocksList[k1].OnBlockRemoval(worldObj, l1, j, i2);
			}
			data.SetNibble(i, j, k, i1);
			if (!worldObj.worldProvider.field_4306_c)
			{
				if (net.minecraft.src.Block.lightOpacity[byte0] != 0)
				{
					if (j >= j1)
					{
						Func_339_g(i, j + 1, k);
					}
				}
				else
				{
					if (j == j1 - 1)
					{
						Func_339_g(i, j, k);
					}
				}
				worldObj.ScheduleLightingUpdate(net.minecraft.src.EnumSkyBlock.Sky, l1, j, i2, l1
					, j, i2);
			}
			worldObj.ScheduleLightingUpdate(net.minecraft.src.EnumSkyBlock.Block, l1, j, i2, 
				l1, j, i2);
			Func_333_c(i, k);
			data.SetNibble(i, j, k, i1);
			if (l != 0)
			{
				net.minecraft.src.Block.blocksList[l].OnBlockAdded(worldObj, l1, j, i2);
			}
			isModified = true;
			return true;
		}

		public virtual bool SetBlockID(int i, int j, int k, int l)
		{
			byte byte0 = unchecked((byte)l);
			int i1 = heightMap[k << 4 | i];
			int j1 = blocks[i << 11 | k << 7 | j];
			if (j1 == l)
			{
				return false;
			}
			int k1 = xPosition * 16 + i;
			int l1 = zPosition * 16 + k;
			blocks[i << 11 | k << 7 | j] = byte0;
			if (j1 != 0)
			{
				net.minecraft.src.Block.blocksList[j1].OnBlockRemoval(worldObj, k1, j, l1);
			}
			data.SetNibble(i, j, k, 0);
			if (net.minecraft.src.Block.lightOpacity[byte0] != 0)
			{
				if (j >= i1)
				{
					Func_339_g(i, j + 1, k);
				}
			}
			else
			{
				if (j == i1 - 1)
				{
					Func_339_g(i, j, k);
				}
			}
			worldObj.ScheduleLightingUpdate(net.minecraft.src.EnumSkyBlock.Sky, k1, j, l1, k1
				, j, l1);
			worldObj.ScheduleLightingUpdate(net.minecraft.src.EnumSkyBlock.Block, k1, j, l1, 
				k1, j, l1);
			Func_333_c(i, k);
			if (l != 0 && !worldObj.singleplayerWorld)
			{
				net.minecraft.src.Block.blocksList[l].OnBlockAdded(worldObj, k1, j, l1);
			}
			isModified = true;
			return true;
		}

		public virtual int GetBlockMetadata(int i, int j, int k)
		{
			return data.GetNibble(i, j, k);
		}

		public virtual void SetBlockMetadata(int i, int j, int k, int l)
		{
			isModified = true;
			data.SetNibble(i, j, k, l);
		}

		public virtual int GetSavedLightValue(net.minecraft.src.EnumSkyBlock enumskyblock
			, int i, int j, int k)
		{
			if (enumskyblock == net.minecraft.src.EnumSkyBlock.Sky)
			{
				return skylightMap.GetNibble(i, j, k);
			}
			if (enumskyblock == net.minecraft.src.EnumSkyBlock.Block)
			{
				return blocklightMap.GetNibble(i, j, k);
			}
			else
			{
				return 0;
			}
		}

		public virtual void SetLightValue(net.minecraft.src.EnumSkyBlock enumskyblock, int
			 i, int j, int k, int l)
		{
			isModified = true;
			if (enumskyblock == net.minecraft.src.EnumSkyBlock.Sky)
			{
				skylightMap.SetNibble(i, j, k, l);
			}
			else
			{
				if (enumskyblock == net.minecraft.src.EnumSkyBlock.Block)
				{
					blocklightMap.SetNibble(i, j, k, l);
				}
				else
				{
					return;
				}
			}
		}

		public virtual int GetBlockLightValue(int i, int j, int k, int l)
		{
			int i1 = skylightMap.GetNibble(i, j, k);
			if (i1 > 0)
			{
				isLit = true;
			}
			i1 -= l;
			int j1 = blocklightMap.GetNibble(i, j, k);
			if (j1 > i1)
			{
				i1 = j1;
			}
			return i1;
		}

		public virtual void AddEntity(net.minecraft.src.Entity entity)
		{
			hasEntities = true;
			int i = net.minecraft.src.MathHelper.Floor_double(entity.posX / 16D);
			int j = net.minecraft.src.MathHelper.Floor_double(entity.posZ / 16D);
			if (i != xPosition || j != zPosition)
			{
				System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append("Wrong location! "
					).Append(entity).ToString());
				//java.lang.Thread.DumpStack();
			}
			int k = net.minecraft.src.MathHelper.Floor_double(entity.posY / 16D);
			if (k < 0)
			{
				k = 0;
			}
			if (k >= entities.Length)
			{
				k = entities.Length - 1;
			}
			entity.addedToChunk = true;
			entity.chunkCoordX = xPosition;
			entity.chunkCoordY = k;
			entity.chunkCoordZ = zPosition;
			entities[k].Add(entity);
		}

		public virtual void RemoveEntity(net.minecraft.src.Entity entity)
		{
			RemoveEntityAtIndex(entity, entity.chunkCoordY);
		}

		public virtual void RemoveEntityAtIndex(net.minecraft.src.Entity entity, int i)
		{
			if (i < 0)
			{
				i = 0;
			}
			if (i >= entities.Length)
			{
				i = entities.Length - 1;
			}
			entities[i].Remove(entity);
		}

		public virtual bool CanBlockSeeTheSky(int i, int j, int k)
		{
			return j >= (heightMap[k << 4 | i]);
		}

		public virtual net.minecraft.src.TileEntity GetChunkBlockTileEntity(int i, int j, 
			int k)
		{
			net.minecraft.src.ChunkPosition chunkposition = new net.minecraft.src.ChunkPosition
				(i, j, k);
			net.minecraft.src.TileEntity tileentity = (net.minecraft.src.TileEntity)chunkTileEntityMap
				[chunkposition];
			if (tileentity == null)
			{
				int l = GetBlockID(i, j, k);
				if (!net.minecraft.src.Block.isBlockContainer[l])
				{
					return null;
				}
				net.minecraft.src.BlockContainer blockcontainer = (net.minecraft.src.BlockContainer
					)net.minecraft.src.Block.blocksList[l];
				blockcontainer.OnBlockAdded(worldObj, xPosition * 16 + i, j, zPosition * 16 + k);
				tileentity = (net.minecraft.src.TileEntity)chunkTileEntityMap[chunkposition];
			}
			if (tileentity != null && tileentity.IsInvalid())
			{
				chunkTileEntityMap.Remove(chunkposition);
				//Sharpen.Collections.Remove(chunkTileEntityMap, chunkposition);
				return null;
			}
			else
			{
				return tileentity;
			}
		}

		public virtual void AddTileEntity(net.minecraft.src.TileEntity tileentity)
		{
			int i = tileentity.xCoord - xPosition * 16;
			int j = tileentity.yCoord;
			int k = tileentity.zCoord - zPosition * 16;
			SetChunkBlockTileEntity(i, j, k, tileentity);
			if (isChunkLoaded)
			{
				worldObj.loadedTileEntityList.Add(tileentity);
			}
		}

		public virtual void SetChunkBlockTileEntity(int i, int j, int k, net.minecraft.src.TileEntity
			 tileentity)
		{
			net.minecraft.src.ChunkPosition chunkposition = new net.minecraft.src.ChunkPosition
				(i, j, k);
			tileentity.worldObj = worldObj;
			tileentity.xCoord = xPosition * 16 + i;
			tileentity.yCoord = j;
			tileentity.zCoord = zPosition * 16 + k;
			if (GetBlockID(i, j, k) == 0 || !(net.minecraft.src.Block.blocksList[GetBlockID(i
				, j, k)] is net.minecraft.src.BlockContainer))
			{
				System.Console.Out.WriteLine("Attempted to place a tile entity where there was no entity tile!"
					);
				return;
			}
			else
			{
				tileentity.Validate();
				chunkTileEntityMap[chunkposition] = tileentity;
				return;
			}
		}

		public virtual void RemoveChunkBlockTileEntity(int i, int j, int k)
		{
			net.minecraft.src.ChunkPosition chunkposition = new net.minecraft.src.ChunkPosition
				(i, j, k);
			if (isChunkLoaded)
			{
				net.minecraft.src.TileEntity tileentity = (TileEntity)chunkTileEntityMap[chunkposition];// (net.minecraft.src.TileEntity)Sharpen.Collections.Remove(chunkTileEntityMap, chunkposition);
				if (tileentity != null)
				{
					chunkTileEntityMap.Remove(chunkposition);
					tileentity.Invalidate();
				}
			}
		}

		public virtual void OnChunkLoad()
		{
			isChunkLoaded = true;
			worldObj.Func_31047_a(chunkTileEntityMap.Values);
			for (int i = 0; i < entities.Length; i++)
			{
				worldObj.AddLoadedEntities(entities[i]);
			}
		}

		public virtual void OnChunkUnload()
		{
			isChunkLoaded = false;
			net.minecraft.src.TileEntity tileentity;
			for (System.Collections.IEnumerator iterator = chunkTileEntityMap.Values.GetEnumerator
				(); iterator.MoveNext(); tileentity.Invalidate())
			{
				tileentity = (net.minecraft.src.TileEntity)iterator.Current;
			}
			for (int i = 0; i < entities.Length; i++)
			{
				worldObj.AddUnloadedEntities(entities[i]);
			}
		}

		public virtual void SetChunkModified()
		{
			isModified = true;
		}

		public virtual void GetEntitiesWithinAABBForEntity(net.minecraft.src.Entity entity, net.minecraft.src.AxisAlignedBB axisalignedbb, List<Entity> list)
		{
			int i = net.minecraft.src.MathHelper.Floor_double((axisalignedbb.minY - 2D) / 16D
				);
			int j = net.minecraft.src.MathHelper.Floor_double((axisalignedbb.maxY + 2D) / 16D
				);
			if (i < 0)
			{
				i = 0;
			}
			if (j >= entities.Length)
			{
				j = entities.Length - 1;
			}
			for (int k = i; k <= j; k++)
			{
				List<Entity> list1 = entities[k];
				for (int l = 0; l < list1.Count; l++)
				{
					net.minecraft.src.Entity entity1 = (net.minecraft.src.Entity)list1[l];
					if (entity1 != entity && entity1.boundingBox.IntersectsWith(axisalignedbb))
					{
						list.Add(entity1);
					}
				}
			}
		}

		public virtual void GetEntitiesOfTypeWithinAAAB(Type class1, net.minecraft.src.AxisAlignedBB axisalignedbb, List<Entity> list)
		{
			int i = net.minecraft.src.MathHelper.Floor_double((axisalignedbb.minY - 2D) / 16D
				);
			int j = net.minecraft.src.MathHelper.Floor_double((axisalignedbb.maxY + 2D) / 16D
				);
			if (i < 0)
			{
				i = 0;
			}
			if (j >= entities.Length)
			{
				j = entities.Length - 1;
			}
			for (int k = i; k <= j; k++)
			{
				List<Entity> list1 = entities[k];
				for (int l = 0; l < list1.Count; l++)
				{
					net.minecraft.src.Entity entity = (net.minecraft.src.Entity)list1[l];
					if (class1.IsAssignableFrom(entity.GetType()) && entity.
						boundingBox.IntersectsWith(axisalignedbb))
					{
						list.Add(entity);
					}
				}
			}
		}

		public virtual bool NeedsSaving(bool flag)
		{
			if (neverSave)
			{
				return false;
			}
			if (flag)
			{
				if (hasEntities && worldObj.GetWorldTime() != lastSaveTime)
				{
					return true;
				}
			}
			else
			{
				if (hasEntities && worldObj.GetWorldTime() >= lastSaveTime + 600L)
				{
					return true;
				}
			}
			return isModified;
		}

		public virtual int GetChunkData(byte[] abyte0, int i, int j, int k, int l, int i1
			, int j1, int k1)
		{
			int l1 = l - i;
			int i2 = i1 - j;
			int j2 = j1 - k;
			if (l1 * i2 * j2 == blocks.Length)
			{
				System.Array.Copy(blocks, 0, abyte0, k1, blocks.Length);
				k1 += blocks.Length;
				System.Array.Copy(data.data, 0, abyte0, k1, data.data.Length);
				k1 += data.data.Length;
				System.Array.Copy(blocklightMap.data, 0, abyte0, k1, blocklightMap.data.Length);
				k1 += blocklightMap.data.Length;
				System.Array.Copy(skylightMap.data, 0, abyte0, k1, skylightMap.data.Length);
				k1 += skylightMap.data.Length;
				return k1;
			}
			for (int k2 = i; k2 < l; k2++)
			{
				for (int k3 = k; k3 < j1; k3++)
				{
					int k4 = k2 << 11 | k3 << 7 | j;
					int k5 = i1 - j;
					System.Array.Copy(blocks, k4, abyte0, k1, k5);
					k1 += k5;
				}
			}
			for (int l2 = i; l2 < l; l2++)
			{
				for (int l3 = k; l3 < j1; l3++)
				{
					int l4 = (l2 << 11 | l3 << 7 | j) >> 1;
					int l5 = (i1 - j) / 2;
					System.Array.Copy(data.data, l4, abyte0, k1, l5);
					k1 += l5;
				}
			}
			for (int i3 = i; i3 < l; i3++)
			{
				for (int i4 = k; i4 < j1; i4++)
				{
					int i5 = (i3 << 11 | i4 << 7 | j) >> 1;
					int i6 = (i1 - j) / 2;
					System.Array.Copy(blocklightMap.data, i5, abyte0, k1, i6);
					k1 += i6;
				}
			}
			for (int j3 = i; j3 < l; j3++)
			{
				for (int j4 = k; j4 < j1; j4++)
				{
					int j5 = (j3 << 11 | j4 << 7 | j) >> 1;
					int j6 = (i1 - j) / 2;
					System.Array.Copy(skylightMap.data, j5, abyte0, k1, j6);
					k1 += j6;
				}
			}
			return k1;
		}

		public virtual SharpBukkitLive.SharpBukkit.SharpRandom Func_334_a(long l)
		{
			return new SharpBukkitLive.SharpBukkit.SharpRandom((worldObj.GetRandomSeed() + (long)(xPosition * xPosition
				 * 0x4c1906) + (long)(xPosition * 0x5ac0db) 
				+ (long)(zPosition * zPosition) * unchecked((long)(0x4307a7L)) + (long)(zPosition
				 * 0x5f24f) ^ l));
		}

		public virtual bool Func_21101_g()
		{
			return false;
		}

		public virtual void Func_25083_h()
		{
			net.minecraft.src.ChunkBlockMap.Func_26001_a(blocks);
		}

		public static bool isLit;

		public byte[] blocks;

		public bool isChunkLoaded;

		public net.minecraft.src.World worldObj;

		public net.minecraft.src.NibbleArray data;

		public net.minecraft.src.NibbleArray skylightMap;

		public net.minecraft.src.NibbleArray blocklightMap;

		public byte[] heightMap;

		public int field_686_i;

		public readonly int xPosition;

		public readonly int zPosition;

		public Dictionary<ChunkPosition, TileEntity> chunkTileEntityMap;

		public List<Entity>[] entities;

		public bool isTerrainPopulated;

		public bool isModified;

		public bool neverSave;

		public bool hasEntities;

		public long lastSaveTime;
	}
}
