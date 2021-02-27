// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ChunkCache : net.minecraft.src.IBlockAccess
	{
		public ChunkCache(net.minecraft.src.World world, int i, int j, int k, int l, int 
			i1, int j1)
		{
			// Referenced classes of package net.minecraft.src:
			//            IBlockAccess, World, Chunk, Material, 
			//            Block, TileEntity
			worldObj = world;
			chunkX = i >> 4;
			chunkZ = k >> 4;
			int k1 = l >> 4;
			int l1 = j1 >> 4;
			chunkArray = new Chunk[(k1 - chunkX) + 1][];
			for (int iv = 0; iv < chunkArray.Length; iv++) chunkArray[iv] = new Chunk[(l1 - chunkZ) + 1];
			for (int i2 = chunkX; i2 <= k1; i2++)
			{
				for (int j2 = chunkZ; j2 <= l1; j2++)
				{
					chunkArray[i2 - chunkX][j2 - chunkZ] = world.GetChunkFromChunkCoords(i2, j2);
				}
			}
		}

		public virtual int GetBlockId(int i, int j, int k)
		{
			if (j < 0)
			{
				return 0;
			}
			if (j >= 128)
			{
				return 0;
			}
			int l = (i >> 4) - chunkX;
			int i1 = (k >> 4) - chunkZ;
			if (l < 0 || l >= chunkArray.Length || i1 < 0 || i1 >= chunkArray[l].Length)
			{
				return 0;
			}
			net.minecraft.src.Chunk chunk = chunkArray[l][i1];
			if (chunk == null)
			{
				return 0;
			}
			else
			{
				return chunk.GetBlockID(i & 0xf, j, k & 0xf);
			}
		}

		public virtual net.minecraft.src.TileEntity GetBlockTileEntity(int i, int j, int 
			k)
		{
			int l = (i >> 4) - chunkX;
			int i1 = (k >> 4) - chunkZ;
			return chunkArray[l][i1].GetChunkBlockTileEntity(i & 0xf, j, k 
				& 0xf);
		}

		public virtual int GetBlockMetadata(int i, int j, int k)
		{
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
				int l = (i >> 4) - chunkX;
				int i1 = (k >> 4) - chunkZ;
				return chunkArray[l][i1].GetBlockMetadata(i & 0xf, j, k & 0xf);
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
				return block.blockMaterial.GetIsSolid() && block.IsACube();
			}
		}

		private int chunkX;

		private int chunkZ;

		private net.minecraft.src.Chunk[][] chunkArray;

		private net.minecraft.src.World worldObj;
	}
}
