// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldGenTaiga2 : net.minecraft.src.WorldGenerator
	{
		public WorldGenTaiga2()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            WorldGenerator, World, Block, BlockLeaves, 
		//            BlockGrass
		public override bool Generate(net.minecraft.src.World world, SharpBukkitLive.SharpBukkit.SharpRandom random
			, int i, int j, int k)
		{
			int l = random.Next(4) + 6;
			int i1 = 1 + random.Next(2);
			int j1 = l - i1;
			int k1 = 2 + random.Next(2);
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
					for (int j3 = k - j2; j3 <= k + j2 && flag; j3++)
					{
						if (l1 >= 0 && l1 < 128)
						{
							int k3 = world.GetBlockId(l2, l1, j3);
							if (k3 != 0 && k3 != net.minecraft.src.Block.LEAVES.blockID)
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
			int k2 = random.Next(2);
			int i3 = 1;
			bool flag1 = false;
			for (int l3 = 0; l3 <= j1; l3++)
			{
				int j4 = (j + l) - l3;
				for (int l4 = i - k2; l4 <= i + k2; l4++)
				{
					int j5 = l4 - i;
					for (int k5 = k - k2; k5 <= k + k2; k5++)
					{
						int l5 = k5 - k;
						if ((System.Math.Abs(j5) != k2 || System.Math.Abs(l5) != k2 || k2 <= 0) && !net.minecraft.src.Block
							.opaqueCubeLookup[world.GetBlockId(l4, j4, k5)])
						{
							world.SetBlockAndMetadata(l4, j4, k5, net.minecraft.src.Block.LEAVES.blockID, 1);
						}
					}
				}
				if (k2 >= i3)
				{
					k2 = ((flag1) ? 1 : 0);
					flag1 = true;
					if (++i3 > k1)
					{
						i3 = k1;
					}
				}
				else
				{
					k2++;
				}
			}
			int i4 = random.Next(3);
			for (int k4 = 0; k4 < l - i4; k4++)
			{
				int i5 = world.GetBlockId(i, j + k4, k);
				if (i5 == 0 || i5 == net.minecraft.src.Block.LEAVES.blockID)
				{
					world.SetBlockAndMetadata(i, j + k4, k, net.minecraft.src.Block.LOG.blockID, 1);
				}
			}
			return true;
		}
	}
}
