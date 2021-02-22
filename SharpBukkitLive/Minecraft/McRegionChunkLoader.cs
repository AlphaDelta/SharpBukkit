// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class McRegionChunkLoader : net.minecraft.src.IChunkLoader
	{
		public McRegionChunkLoader(string file)
		{
			// Referenced classes of package net.minecraft.src:
			//            IChunkLoader, RegionFileCache, CompressedStreamTools, NBTTagCompound, 
			//            ChunkLoader, Chunk, World, WorldInfo
			worldFolder = file;
		}

		/// <exception cref="System.IO.IOException"/>
		public virtual net.minecraft.src.Chunk LoadChunk(net.minecraft.src.World world, int
			 i, int j)
		{
			java.io.DataInputStream datainputstream = net.minecraft.src.RegionFileCache.Func_22124_c(worldFolder, i, j);
			net.minecraft.src.NBTTagCompound nbttagcompound;
			if (datainputstream != null)
			{
				nbttagcompound = net.minecraft.src.CompressedStreamTools.GetCompound(datainputstream
					);
			}
			else
			{
				return null;
			}
			if (!nbttagcompound.HasKey("Level"))
			{
				System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append("Chunk file at "
					).Append(i).Append(",").Append(j).Append(" is missing level data, skipping").ToString
					());
				return null;
			}
			if (!nbttagcompound.GetCompoundTag("Level").HasKey("Blocks"))
			{
				System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append("Chunk file at "
					).Append(i).Append(",").Append(j).Append(" is missing block data, skipping").ToString
					());
				return null;
			}
			net.minecraft.src.Chunk chunk = net.minecraft.src.ChunkLoader.LoadChunkIntoWorldFromCompound
				(world, nbttagcompound.GetCompoundTag("Level"));
			if (!chunk.IsAtLocation(i, j))
			{
				System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append("Chunk file at "
					).Append(i).Append(",").Append(j).Append(" is in the wrong location; relocating. (Expected "
					).Append(i).Append(", ").Append(j).Append(", got ").Append(chunk.xPosition).Append
					(", ").Append(chunk.zPosition).Append(")").ToString());
				nbttagcompound.SetInteger("xPos", i);
				nbttagcompound.SetInteger("zPos", j);
				chunk = net.minecraft.src.ChunkLoader.LoadChunkIntoWorldFromCompound(world, nbttagcompound
					.GetCompoundTag("Level"));
			}
			chunk.Func_25083_h();
			return chunk;
		}

		/// <exception cref="System.IO.IOException"/>
		public virtual void SaveChunk(net.minecraft.src.World world, net.minecraft.src.Chunk
			 chunk)
		{
			world.CheckSessionLock();
			try
			{
				java.io.DataOutputStream dataoutputstream = net.minecraft.src.RegionFileCache.Func_22120_d
					(worldFolder, chunk.xPosition, chunk.zPosition);
				net.minecraft.src.NBTTagCompound nbttagcompound = new net.minecraft.src.NBTTagCompound
					();
				net.minecraft.src.NBTTagCompound nbttagcompound1 = new net.minecraft.src.NBTTagCompound
					();
				nbttagcompound.SetTag("Level", nbttagcompound1);
				net.minecraft.src.ChunkLoader.StoreChunkInCompound(chunk, world, nbttagcompound1);
				net.minecraft.src.CompressedStreamTools.Func_771_a(nbttagcompound, dataoutputstream
					);
				dataoutputstream.Close();
				net.minecraft.src.WorldInfo worldinfo = world.GetWorldInfo();
				worldinfo.SetSizeOnDisk(worldinfo.GetSizeOnDisk() + (long)net.minecraft.src.RegionFileCache
					.Func_22121_b(worldFolder, chunk.xPosition, chunk.zPosition));
			}
			catch (System.Exception exception)
			{
				Sharpen.Runtime.PrintStackTrace(exception);
			}
		}

		/// <exception cref="System.IO.IOException"/>
		public virtual void SaveExtraChunkData(net.minecraft.src.World world, net.minecraft.src.Chunk
			 chunk)
		{
		}

		public virtual void Func_661_a()
		{
		}

		public virtual void SaveExtraData()
		{
		}

		private readonly string worldFolder;
	}
}
