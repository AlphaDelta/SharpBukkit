// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class ChunkProviderServer : net.minecraft.src.IChunkProvider
	{
		public ChunkProviderServer(net.minecraft.src.WorldServer worldserver, net.minecraft.src.IChunkLoader
			 ichunkloader, net.minecraft.src.IChunkProvider ichunkprovider)
		{
			// Referenced classes of package net.minecraft.src:
			//            IChunkProvider, EmptyChunk, ChunkCoordIntPair, WorldServer, 
			//            ChunkCoordinates, Chunk, IChunkLoader, IProgressUpdate
			field_725_a = new HashSet<int>();
			chunkLoadOverride = false;
			id2ChunkMap = new System.Collections.Hashtable();
			field_727_f = new System.Collections.ArrayList();
			dummyChunk = new net.minecraft.src.EmptyChunk(worldserver, new byte[32768], 0, 0);
			world = worldserver;
			field_729_d = ichunkloader;
			serverChunkGenerator = ichunkprovider;
		}

		public virtual bool ChunkExists(int i, int j)
		{
			return id2ChunkMap.Contains(net.minecraft.src.ChunkCoordIntPair.ChunkXZ2Int(i, j));
		}

		public virtual void Func_374_c(int i, int j)
		{
			net.minecraft.src.ChunkCoordinates chunkcoordinates = world.GetSpawnPoint();
			int k = (i * 16 + 8) - chunkcoordinates.posX;
			int l = (j * 16 + 8) - chunkcoordinates.posZ;
			short c = 128;//'\200';
			if (k < -c || k > c || l < -c || l > c)
			{
				field_725_a.Add(net.minecraft.src.ChunkCoordIntPair.ChunkXZ2Int(i, j));
			}
		}

		public virtual net.minecraft.src.Chunk LoadChunk(int i, int j)
		{
			int k = net.minecraft.src.ChunkCoordIntPair.ChunkXZ2Int(i, j);
			field_725_a.Remove(k);
			net.minecraft.src.Chunk chunk = (net.minecraft.src.Chunk)id2ChunkMap[k];
			if (chunk == null)
			{
				chunk = Func_4063_e(i, j);
				if (chunk == null)
				{
					if (serverChunkGenerator == null)
					{
						chunk = dummyChunk;
					}
					else
					{
						chunk = serverChunkGenerator.ProvideChunk(i, j);
					}
				}
				id2ChunkMap[k] = chunk;
				field_727_f.Add(chunk);
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
			net.minecraft.src.Chunk chunk = (net.minecraft.src.Chunk)id2ChunkMap[net.minecraft.src.ChunkCoordIntPair.ChunkXZ2Int(i, j)];
			if (chunk == null)
			{
				if (world.worldChunkLoadOverride || chunkLoadOverride)
				{
					return LoadChunk(i, j);
				}
				else
				{
					return dummyChunk;
				}
			}
			else
			{
				return chunk;
			}
		}

		private net.minecraft.src.Chunk Func_4063_e(int i, int j)
		{
			if (field_729_d == null)
			{
				return null;
			}
			try
			{
				net.minecraft.src.Chunk chunk = field_729_d.LoadChunk(world, i, j);
				if (chunk != null)
				{
					chunk.lastSaveTime = world.GetWorldTime();
				}
				return chunk;
			}
			catch (System.Exception exception)
			{
				Sharpen.Runtime.PrintStackTrace(exception);
			}
			return null;
		}

		private void Func_375_a(net.minecraft.src.Chunk chunk)
		{
			if (field_729_d == null)
			{
				return;
			}
			try
			{
				field_729_d.SaveExtraChunkData(world, chunk);
			}
			catch (System.Exception exception)
			{
				Sharpen.Runtime.PrintStackTrace(exception);
			}
		}

		private void Func_373_b(net.minecraft.src.Chunk chunk)
		{
			if (field_729_d == null)
			{
				return;
			}
			try
			{
				chunk.lastSaveTime = world.GetWorldTime();
				field_729_d.SaveChunk(world, chunk);
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
				if (serverChunkGenerator != null)
				{
					serverChunkGenerator.Populate(ichunkprovider, i, j);
					chunk.SetChunkModified();
				}
			}
		}

		public virtual bool SaveChunks(bool flag, net.minecraft.src.IProgressUpdate iprogressupdate
			)
		{
			int i = 0;
			for (int j = 0; j < field_727_f.Count; j++)
			{
				net.minecraft.src.Chunk chunk = (net.minecraft.src.Chunk)field_727_f[j];
				if (flag && !chunk.neverSave)
				{
					Func_375_a(chunk);
				}
				if (!chunk.NeedsSaving(flag))
				{
					continue;
				}
				Func_373_b(chunk);
				chunk.isModified = false;
				if (++i == 24 && !flag)
				{
					return false;
				}
			}
			if (flag)
			{
				if (field_729_d == null)
				{
					return true;
				}
				field_729_d.SaveExtraData();
			}
			return true;
		}

		public virtual bool Func_361_a()
		{
			if (!world.levelSaving)
			{
				for (int i = 0; i < 100; i++)
				{
					if (field_725_a.Count > 0)
					{
						int integer = (int)field_725_a.GetEnumerator().Current;
						net.minecraft.src.Chunk chunk = (net.minecraft.src.Chunk)id2ChunkMap[integer];
						chunk.OnChunkUnload();
						Func_373_b(chunk);
						Func_375_a(chunk);
						field_725_a.Remove(integer);
						id2ChunkMap.Remove(integer);
						//Sharpen.Collections.Remove(id2ChunkMap, integer);
						field_727_f.Remove(chunk);
					}
				}
				if (field_729_d != null)
				{
					field_729_d.Func_661_a();
				}
			}
			return serverChunkGenerator.Func_361_a();
		}

		public virtual bool CanSave()
		{
			return !world.levelSaving;
		}

		private HashSet<int> field_725_a;

		private net.minecraft.src.Chunk dummyChunk;

		private net.minecraft.src.IChunkProvider serverChunkGenerator;

		private net.minecraft.src.IChunkLoader field_729_d;

		public bool chunkLoadOverride;

		private System.Collections.IDictionary id2ChunkMap;

		private System.Collections.IList field_727_f;

		private net.minecraft.src.WorldServer world;
	}
}
