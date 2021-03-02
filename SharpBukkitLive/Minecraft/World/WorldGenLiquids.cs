// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldGenLiquids : net.minecraft.src.WorldGenerator
	{
		public WorldGenLiquids(int i)
		{
			// Referenced classes of package net.minecraft.src:
			//            WorldGenerator, World, Block
			liquidBlockId = i;
		}

		public override bool Generate(net.minecraft.src.World world, SharpBukkitLive.SharpBukkit.SharpRandom random
			, int i, int j, int k)
		{
			if (world.GetBlockId(i, j + 1, k) != net.minecraft.src.Block.STONE.ID)
			{
				return false;
			}
			if (world.GetBlockId(i, j - 1, k) != net.minecraft.src.Block.STONE.ID)
			{
				return false;
			}
			if (world.GetBlockId(i, j, k) != 0 && world.GetBlockId(i, j, k) != net.minecraft.src.Block
				.STONE.ID)
			{
				return false;
			}
			int l = 0;
			if (world.GetBlockId(i - 1, j, k) == net.minecraft.src.Block.STONE.ID)
			{
				l++;
			}
			if (world.GetBlockId(i + 1, j, k) == net.minecraft.src.Block.STONE.ID)
			{
				l++;
			}
			if (world.GetBlockId(i, j, k - 1) == net.minecraft.src.Block.STONE.ID)
			{
				l++;
			}
			if (world.GetBlockId(i, j, k + 1) == net.minecraft.src.Block.STONE.ID)
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
			if (l == 3 && i1 == 1)
			{
				world.SetBlockWithNotify(i, j, k, liquidBlockId);
				world.scheduledUpdatesAreImmediate = true;
				net.minecraft.src.Block.blocksList[liquidBlockId].UpdateTick(world, i, j, k, random
					);
				world.scheduledUpdatesAreImmediate = false;
			}
			return true;
		}

		private int liquidBlockId;
	}
}
