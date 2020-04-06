// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldGenTrees : net.minecraft.src.WorldGenerator
	{
		public WorldGenTrees()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            WorldGenerator, World, Block, BlockLeaves, 
		//            BlockGrass
		public override bool Generate(net.minecraft.src.World world, SharpBukkitLive.SharpBukkit.SharpRandom random
			, int i, int j, int k)
		{
			int l = random.Next(3) + 4;
			bool flag = true;
			if (j < 1 || j + l + 1 > 128)
			{
				return false;
			}
			for (int i1 = j; i1 <= j + 1 + l; i1++)
			{
				byte byte0 = 1;
				if (i1 == j)
				{
					byte0 = 0;
				}
				if (i1 >= (j + 1 + l) - 2)
				{
					byte0 = 2;
				}
				for (int i2 = i - byte0; i2 <= i + byte0 && flag; i2++)
				{
					for (int l2 = k - byte0; l2 <= k + byte0 && flag; l2++)
					{
						if (i1 >= 0 && i1 < 128)
						{
							int j3 = world.GetBlockId(i2, i1, l2);
							if (j3 != 0 && j3 != net.minecraft.src.Block.leaves.blockID)
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
			int j1 = world.GetBlockId(i, j - 1, k);
			if (j1 != net.minecraft.src.Block.grass.blockID && j1 != net.minecraft.src.Block.
				dirt.blockID || j >= 128 - l - 1)
			{
				return false;
			}
			world.SetBlock(i, j - 1, k, net.minecraft.src.Block.dirt.blockID);
			for (int k1 = (j - 3) + l; k1 <= j + l; k1++)
			{
				int j2 = k1 - (j + l);
				int i3 = 1 - j2 / 2;
				for (int k3 = i - i3; k3 <= i + i3; k3++)
				{
					int l3 = k3 - i;
					for (int i4 = k - i3; i4 <= k + i3; i4++)
					{
						int j4 = i4 - k;
						if ((System.Math.Abs(l3) != i3 || System.Math.Abs(j4) != i3 || random.Next(2) 
							!= 0 && j2 != 0) && !net.minecraft.src.Block.opaqueCubeLookup[world.GetBlockId(k3
							, k1, i4)])
						{
							world.SetBlock(k3, k1, i4, net.minecraft.src.Block.leaves.blockID);
						}
					}
				}
			}
			for (int l1 = 0; l1 < l; l1++)
			{
				int k2 = world.GetBlockId(i, j + l1, k);
				if (k2 == 0 || k2 == net.minecraft.src.Block.leaves.blockID)
				{
					world.SetBlock(i, j + l1, k, net.minecraft.src.Block.wood.blockID);
				}
			}
			return true;
		}
	}
}
