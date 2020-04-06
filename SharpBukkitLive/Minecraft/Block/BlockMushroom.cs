// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockMushroom : net.minecraft.src.BlockFlower
	{
		protected internal BlockMushroom(int i, int j)
			: base(i, j)
		{
			// Referenced classes of package net.minecraft.src:
			//            BlockFlower, World, Block
			float f = 0.2F;
			SetBlockBounds(0.5F - f, 0.0F, 0.5F - f, 0.5F + f, f * 2.0F, 0.5F + f);
			SetTickOnLoad(true);
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (random.Next(100) == 0)
			{
				int l = (i + random.Next(3)) - 1;
				int i1 = (j + random.Next(2)) - random.Next(2);
				int j1 = (k + random.Next(3)) - 1;
				if (world.IsAirBlock(l, i1, j1) && CanBlockStay(world, l, i1, j1))
				{
					i += random.Next(3) - 1;
					k += random.Next(3) - 1;
					if (world.IsAirBlock(l, i1, j1) && CanBlockStay(world, l, i1, j1))
					{
						world.SetBlockWithNotify(l, i1, j1, blockID);
					}
				}
			}
		}

		protected internal override bool CanThisPlantGrowOnThisBlockID(int i)
		{
			return net.minecraft.src.Block.opaqueCubeLookup[i];
		}

		public override bool CanBlockStay(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			if (j < 0 || j >= 128)
			{
				return false;
			}
			else
			{
				return world.GetBlockLightValueNoChecks(i, j, k) < 13 && CanThisPlantGrowOnThisBlockID
					(world.GetBlockId(i, j - 1, k));
			}
		}
	}
}
