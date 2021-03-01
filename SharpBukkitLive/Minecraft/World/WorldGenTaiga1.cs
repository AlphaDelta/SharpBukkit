// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldGenTaiga1 : net.minecraft.src.WorldGenerator
	{
		public WorldGenTaiga1()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            WorldGenerator, World, Block, BlockLeaves, 
		//            BlockGrass
		public override bool Generate(net.minecraft.src.World world, SharpBukkitLive.SharpBukkit.SharpRandom random
			, int i, int j, int k)
		{
			int l = random.Next(5) + 7;
			int i1 = l - random.Next(2) - 3;
			int j1 = l - i1;
			int k1 = 1 + random.Next(j1 + 1);
			bool flag = true;
			if (j < 1 || j + l + 1 > 128)
			{
				return false;
			}
			for (int l1 = j; l1 <= j + 1 + l && flag; l1++)
			{
				int j2 = 1;
				if (l1 - j < i1)
				{
					j2 = 0;
				}
				else
				{
					j2 = k1;
				}
				for (int l2 = i - j2; l2 <= i + j2 && flag; l2++)
				{
					for (int k3 = k - j2; k3 <= k + j2 && flag; k3++)
					{
						if (l1 >= 0 && l1 < 128)
						{
							int j4 = world.GetBlockId(l2, l1, k3);
							if (j4 != 0 && j4 != net.minecraft.src.Block.LEAVES.blockID)
							{
								flag = false;
							}
						}
						else
						{
							flag = false;
						}
					}
				}
			}
			if (!flag)
			{
				return false;
			}
			int i2 = world.GetBlockId(i, j - 1, k);
			if (i2 != net.minecraft.src.Block.GRASS.blockID && i2 != net.minecraft.src.Block.
				DIRT.blockID || j >= 128 - l - 1)
			{
				return false;
			}
			world.SetBlock(i, j - 1, k, net.minecraft.src.Block.DIRT.blockID);
			int k2 = 0;
			for (int i3 = j + l; i3 >= j + i1; i3--)
			{
				for (int l3 = i - k2; l3 <= i + k2; l3++)
				{
					int k4 = l3 - i;
					for (int l4 = k - k2; l4 <= k + k2; l4++)
					{
						int i5 = l4 - k;
						if ((System.Math.Abs(k4) != k2 || System.Math.Abs(i5) != k2 || k2 <= 0) && !net.minecraft.src.Block
							.opaqueCubeLookup[world.GetBlockId(l3, i3, l4)])
						{
							world.SetBlockAndMetadata(l3, i3, l4, net.minecraft.src.Block.LEAVES.blockID, 1);
						}
					}
				}
				if (k2 >= 1 && i3 == j + i1 + 1)
				{
					k2--;
					continue;
				}
				if (k2 < k1)
				{
					k2++;
				}
			}
			for (int j3 = 0; j3 < l - 1; j3++)
			{
				int i4 = world.GetBlockId(i, j + j3, k);
				if (i4 == 0 || i4 == net.minecraft.src.Block.LEAVES.blockID)
				{
					world.SetBlockAndMetadata(i, j + j3, k, net.minecraft.src.Block.LOG.blockID, 1);
				}
			}
			return true;
		}
	}
}
