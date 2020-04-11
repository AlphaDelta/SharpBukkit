// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class ChunkProvider : net.minecraft.src.IChunkProvider
	{
		public ChunkProvider(net.minecraft.src.World world, net.minecraft.src.IChunkLoader
			 ichunkloader, net.minecraft.src.IChunkProvider ichunkprovider)
		{
			// Referenced classes of package net.minecraft.src:
			//            IChunkProvider, EmptyChunk, ChunkCoordIntPair, Chunk, 
			//            IChunkLoader, World, IProgressUpdate
			field_28062_a = new SharpBukkitLive.NullSafeDictionary<int, Chunk>();
			field_28065_e = new SharpBukkitLive.NullSafeDictionary<int, Chunk>();
			field_28064_f = new List<Chunk>();
			field_28061_b = new net.minecraft.src.EmptyChunk(world, new byte[32768], 0, 0);
			worldObj = world;
			field_28066_d = ichunkloader;
			chunkGenerator = ichunkprovider;
		}

		public virtual bool ChunkExists(int i, int j)
		{
			return field_28065_e.ContainsKey(net.minecraft.src.ChunkCoordIntPair.ChunkXZ2Int(i, j));
		}

		public virtual net.minecraft.src.Chunk LoadChunk(int i, int j)
		{
			int k = net.minecraft.src.ChunkCoordIntPair.ChunkXZ2Int(i, j);
			field_28062_a.Remove(k);
			net.minecraft.src.Chunk chunk = (net.minecraft.src.Chunk)field_28065_e[k];
			if (chunk == null)
			{
				chunk = Func_28058_d(i, j);
				if (chunk == null)
				{
					if (chunkGenerator == null)
					{
						chunk = field_28061_b;
					}
					else
					{
						chunk = chunkGenerator.ProvideChunk(i, j);
					}
				}
				field_28065_e[k] = chunk;
				field_28064_f.Add(chunk);
				if (chunk != null)
				{
					chunk.Func_4053_c();
					chunk.OnChunkLoad();
				}
				if (!chunk.isTerrainPopulated && ChunkExists(i + 1, j + 1) && ChunkExists(i, j + 
					1) && ChunkExists(i + 1, j))
				{
					Populate(this, i, j);
				}
				if (ChunkExists(i - 1, j) && !ProvideChunk(i - 1, j).isTerrainPopulated && ChunkExists
					(i - 1, j + 1) && ChunkExists(i, j + 1) && ChunkExists(i - 1, j))
				{
					Populate(this, i - 1, j);
				}
				if (ChunkExists(i, j - 1) && !ProvideChunk(i, j - 1).isTerrainPopulated && ChunkExists
					(i + 1, j - 1) && ChunkExists(i, j - 1) && ChunkExists(i + 1, j))
				{
					Populate(this, i, j - 1);
				}
				if (ChunkExists(i - 1, j - 1) && !ProvideChunk(i - 1, j - 1).isTerrainPopulated &&
					 ChunkExists(i - 1, j - 1) && ChunkExists(i, j - 1) && ChunkExists(i - 1, j))
				{
					Populate(this, i - 1, j - 1);
				}
			}
			return chunk;
		}

		public virtual net.minecraft.src.Chunk ProvideChunk(int i, int j)
		{
			net.minecraft.src.Chunk chunk = (net.minecraft.src.Chunk)field_28065_e[
				net.minecraft.src.ChunkCoordIntPair.ChunkXZ2Int(i, j)];
			if (chunk == null)
			{
				return LoadChunk(i, j);
			}
			else
			{
				return chunk;
			}
		}

		private net.minecraft.src.Chunk Func_28058_d(int i, int j)
		{
			if (field_28066_d == null)
			{
				return null;
			}
			try
			{
				net.minecraft.src.Chunk chunk = field_28066_d.LoadChunk(worldObj, i, j);
				if (chunk != null)
				{
					chunk.lastSaveTime = worldObj.GetWorldTime();
				}
				return chunk;
			}
			catch (System.Exception exception)
			{
				Sharpen.Runtime.PrintStackTrace(exception);
			}
			return null;
		}

		private void Func_28060_a(net.minecraft.src.Chunk chunk)
		{
			if (field_28066_d == null)
			{
				return;
			}
			try
			{
				field_28066_d.SaveExtraChunkData(worldObj, chunk);
			}
			catch (System.Exception exception)
			{
				Sharpen.Runtime.PrintStackTrace(exception);
			}
		}

		private void Func_28059_b(net.minecraft.src.Chunk chunk)
		{
			if (field_28066_d == null)
			{
				return;
			}
			try
			{
				chunk.lastSaveTime = worldObj.GetWorldTime();
				field_28066_d.SaveChunk(worldObj, chunk);
			}
			catch (System.IO.IOException ioexception)
			{
				Sharpen.Runtime.PrintStackTrace(ioexception);
			}
		}

		public virtual void Populate(net.minecraft.src.IChunkProvider ichunkprovider, int
			 i, int j)
		{
			net.minecraft.src.Chunk chunk = ProvideChunk(i, j);
			if (!chunk.isTerrainPopulated)
			{
				chunk.isTerrainPopulated = true;
				if (chunkGenerator != null)
				{
					chunkGenerator.Populate(ichunkprovider, i, j);
					chunk.SetChunkModified();
				}
			}
		}

		public virtual bool SaveChunks(bool flag, net.minecraft.src.IProgressUpdate iprogressupdate
			)
		{
			int i = 0;
			for (int j = 0; j < field_28064_f.Count; j++)
			{
				net.minecraft.src.Chunk chunk = (net.minecraft.src.Chunk)field_28064_f[j];
				if (flag && !chunk.neverSave)
				{
					Func_28060_a(chunk);
				}
				if (!chunk.NeedsSaving(flag))
				{
					continue;
				}
				Func_28059_b(chunk);
				chunk.isModified = false;
				if (++i == 24 && !flag)
				{
					return false;
				}
			}
			if (flag)
			{
				if (field_28066_d == null)
				{
					return true;
				}
				field_28066_d.SaveExtraData();
			}
			return true;
		}

		public virtual bool Func_361_a()
		{
			for (int i = 0; i < 100; i++)
			{
				if (field_28062_a.Count > 0)
				{
					int integer = (int)field_28062_a.GetEnumerator().Current.Key;
					net.minecraft.src.Chunk chunk = (net.minecraft.src.Chunk)field_28065_e[integer];
					chunk.OnChunkUnload();
					Func_28059_b(chunk);
					Func_28060_a(chunk);
					field_28062_a.Remove(integer);
					field_28065_e.Remove(integer);//Sharpen.Collections.Remove(field_28065_e, integer);
					field_28064_f.Remove(chunk);
				}
			}
			if (field_28066_d != null)
			{
				field_28066_d.Func_661_a();
			}
			return chunkGenerator.Func_361_a();
		}

		public virtual bool CanSave()
		{
			return true;
		}

		private Dictionary<int, Chunk> field_28062_a;

		private net.minecraft.src.Chunk field_28061_b;

		private net.minecraft.src.IChunkProvider chunkGenerator;

		private net.minecraft.src.IChunkLoader field_28066_d;

		private Dictionary<int, Chunk> field_28065_e;

		private List<Chunk> field_28064_f;

		private net.minecraft.src.World worldObj;
	}
}
