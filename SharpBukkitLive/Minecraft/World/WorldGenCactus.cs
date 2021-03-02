// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldGenCactus : net.minecraft.src.WorldGenerator
	{
		public WorldGenCactus()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            WorldGenerator, World, Block
		public override bool Generate(net.minecraft.src.World world, SharpBukkitLive.SharpBukkit.SharpRandom random
			, int i, int j, int k)
		{
			for (int l = 0; l < 10; l++)
			{
				int i1 = (i + random.Next(8)) - random.Next(8);
				int j1 = (j + random.Next(4)) - random.Next(4);
				int k1 = (k + random.Next(8)) - random.Next(8);
				if (!world.IsAirBlock(i1, j1, k1))
				{
					continue;
				}
				int l1 = 1 + random.Next(random.Next(3) + 1);
				for (int i2 = 0; i2 < l1; i2++)
				{
					if (net.minecraft.src.Block.CACTUS.CanBlockStay(world, i1, j1 + i2, k1))
					{
						world.SetBlock(i1, j1 + i2, k1, net.minecraft.src.Block.CACTUS.ID);
					}
				}
			}
			return true;
		}
	}
}
