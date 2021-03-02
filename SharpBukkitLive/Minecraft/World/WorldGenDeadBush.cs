// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldGenDeadBush : net.minecraft.src.WorldGenerator
	{
		public WorldGenDeadBush(int i)
		{
			// Referenced classes of package net.minecraft.src:
			//            WorldGenerator, World, Block, BlockLeaves, 
			//            BlockFlower
			field_28055_a = i;
		}

		public override bool Generate(net.minecraft.src.World world, SharpBukkitLive.SharpBukkit.SharpRandom random
			, int i, int j, int k)
		{
			for (int l = 0; ((l = world.GetBlockId(i, j, k)) == 0 || l == net.minecraft.src.Block
				.LEAVES.ID) && j > 0; j--)
			{
			}
			for (int i1 = 0; i1 < 4; i1++)
			{
				int j1 = (i + random.Next(8)) - random.Next(8);
				int k1 = (j + random.Next(4)) - random.Next(4);
				int l1 = (k + random.Next(8)) - random.Next(8);
				if (world.IsAirBlock(j1, k1, l1) && ((net.minecraft.src.BlockFlower)net.minecraft.src.Block
					.blocksList[field_28055_a]).CanBlockStay(world, j1, k1, l1))
				{
					world.SetBlock(j1, k1, l1, field_28055_a);
				}
			}
			return true;
		}

		private int field_28055_a;
	}
}
