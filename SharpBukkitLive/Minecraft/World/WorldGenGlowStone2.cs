// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldGenGlowStone2 : net.minecraft.src.WorldGenerator
	{
		public WorldGenGlowStone2()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            WorldGenerator, World, Block
		public override bool Generate(net.minecraft.src.World world, SharpBukkitLive.SharpBukkit.SharpRandom random
			, int i, int j, int k)
		{
			if (!world.IsAirBlock(i, j, k))
			{
				return false;
			}
			if (world.GetBlockId(i, j + 1, k) != net.minecraft.src.Block.bloodStone.blockID)
			{
				return false;
			}
			world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.glowStone.blockID);
			for (int l = 0; l < 1500; l++)
			{
				int i1 = (i + random.Next(8)) - random.Next(8);
				int j1 = j - random.Next(12);
				int k1 = (k + random.Next(8)) - random.Next(8);
				if (world.GetBlockId(i1, j1, k1) != 0)
				{
					continue;
				}
				int l1 = 0;
				for (int i2 = 0; i2 < 6; i2++)
				{
					int j2 = 0;
					if (i2 == 0)
					{
						j2 = world.GetBlockId(i1 - 1, j1, k1);
					}
					if (i2 == 1)
					{
						j2 = world.GetBlockId(i1 + 1, j1, k1);
					}
					if (i2 == 2)
					{
						j2 = world.GetBlockId(i1, j1 - 1, k1);
					}
					if (i2 == 3)
					{
						j2 = world.GetBlockId(i1, j1 + 1, k1);
					}
					if (i2 == 4)
					{
						j2 = world.GetBlockId(i1, j1, k1 - 1);
					}
					if (i2 == 5)
					{
						j2 = world.GetBlockId(i1, j1, k1 + 1);
					}
					if (j2 == net.minecraft.src.Block.glowStone.blockID)
					{
						l1++;
					}
				}
				if (l1 == 1)
				{
					world.SetBlockWithNotify(i1, j1, k1, net.minecraft.src.Block.glowStone.blockID);
				}
			}
			return true;
		}
	}
}
