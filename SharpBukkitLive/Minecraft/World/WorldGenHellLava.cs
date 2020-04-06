// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldGenHellLava : net.minecraft.src.WorldGenerator
	{
		public WorldGenHellLava(int i)
		{
			// Referenced classes of package net.minecraft.src:
			//            WorldGenerator, World, Block
			field_4250_a = i;
		}

		public override bool Generate(net.minecraft.src.World world, SharpBukkitLive.SharpBukkit.SharpRandom random
			, int i, int j, int k)
		{
			if (world.GetBlockId(i, j + 1, k) != net.minecraft.src.Block.bloodStone.blockID)
			{
				return false;
			}
			if (world.GetBlockId(i, j, k) != 0 && world.GetBlockId(i, j, k) != net.minecraft.src.Block
				.bloodStone.blockID)
			{
				return false;
			}
			int l = 0;
			if (world.GetBlockId(i - 1, j, k) == net.minecraft.src.Block.bloodStone.blockID)
			{
				l++;
			}
			if (world.GetBlockId(i + 1, j, k) == net.minecraft.src.Block.bloodStone.blockID)
			{
				l++;
			}
			if (world.GetBlockId(i, j, k - 1) == net.minecraft.src.Block.bloodStone.blockID)
			{
				l++;
			}
			if (world.GetBlockId(i, j, k + 1) == net.minecraft.src.Block.bloodStone.blockID)
			{
				l++;
			}
			if (world.GetBlockId(i, j - 1, k) == net.minecraft.src.Block.bloodStone.blockID)
			{
				l++;
			}
			int i1 = 0;
			if (world.IsAirBlock(i - 1, j, k))
			{
				i1++;
			}
			if (world.IsAirBlock(i + 1, j, k))
			{
				i1++;
			}
			if (world.IsAirBlock(i, j, k - 1))
			{
				i1++;
			}
			if (world.IsAirBlock(i, j, k + 1))
			{
				i1++;
			}
			if (world.IsAirBlock(i, j - 1, k))
			{
				i1++;
			}
			if (l == 4 && i1 == 1)
			{
				world.SetBlockWithNotify(i, j, k, field_4250_a);
				world.scheduledUpdatesAreImmediate = true;
				net.minecraft.src.Block.blocksList[field_4250_a].UpdateTick(world, i, j, k, random
					);
				world.scheduledUpdatesAreImmediate = false;
			}
			return true;
		}

		private int field_4250_a;
	}
}
