// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockGrass : net.minecraft.src.Block
	{
		protected internal BlockGrass(int i)
			: base(i, net.minecraft.src.Material.grass)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, World
			blockIndexInTexture = 3;
			SetTickOnLoad(true);
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			if (world.GetBlockLightValue(i, j + 1, k) < 4 && net.minecraft.src.Block.lightOpacity
				[world.GetBlockId(i, j + 1, k)] > 2)
			{
				if (random.Next(4) != 0)
				{
					return;
				}
				world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.DIRT.ID);
			}
			else
			{
				if (world.GetBlockLightValue(i, j + 1, k) >= 9)
				{
					int l = (i + random.Next(3)) - 1;
					int i1 = (j + random.Next(5)) - 3;
					int j1 = (k + random.Next(3)) - 1;
					int k1 = world.GetBlockId(l, i1 + 1, j1);
					if (world.GetBlockId(l, i1, j1) == net.minecraft.src.Block.DIRT.ID && world.
						GetBlockLightValue(l, i1 + 1, j1) >= 4 && net.minecraft.src.Block.lightOpacity[k1
						] <= 2)
					{
						world.SetBlockWithNotify(l, i1, j1, net.minecraft.src.Block.GRASS.ID);
					}
				}
			}
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Block.DIRT.IdDropped(0, random);
		}
	}
}
