// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldGenFire : net.minecraft.src.WorldGenerator
	{
		public WorldGenFire()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            WorldGenerator, World, Block, BlockFire
		public override bool Generate(net.minecraft.src.World world, SharpBukkitLive.SharpBukkit.SharpRandom random
			, int i, int j, int k)
		{
			for (int l = 0; l < 64; l++)
			{
				int i1 = (i + random.Next(8)) - random.Next(8);
				int j1 = (j + random.Next(4)) - random.Next(4);
				int k1 = (k + random.Next(8)) - random.Next(8);
				if (world.IsAirBlock(i1, j1, k1) && world.GetBlockId(i1, j1 - 1, k1) == net.minecraft.src.Block
					.NETHERRACK.ID)
				{
					world.SetBlockWithNotify(i1, j1, k1, net.minecraft.src.Block.FIRE.ID);
				}
			}
			return true;
		}
	}
}
