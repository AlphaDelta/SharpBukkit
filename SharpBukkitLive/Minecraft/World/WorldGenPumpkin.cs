// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldGenPumpkin : net.minecraft.src.WorldGenerator
	{
		public WorldGenPumpkin()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            WorldGenerator, World, Block, BlockGrass
		public override bool Generate(net.minecraft.src.World world, SharpBukkitLive.SharpBukkit.SharpRandom random
			, int i, int j, int k)
		{
			for (int l = 0; l < 64; l++)
			{
				int i1 = (i + random.Next(8)) - random.Next(8);
				int j1 = (j + random.Next(4)) - random.Next(4);
				int k1 = (k + random.Next(8)) - random.Next(8);
				if (world.IsAirBlock(i1, j1, k1) && world.GetBlockId(i1, j1 - 1, k1) == net.minecraft.src.Block
					.GRASS.ID && net.minecraft.src.Block.PUMPKIN.CanPlaceBlockAt(world, i1, j1, 
					k1))
				{
					world.SetBlockAndMetadata(i1, j1, k1, net.minecraft.src.Block.PUMPKIN.ID, random
						.NextInt(4));
				}
			}
			return true;
		}
	}
}
