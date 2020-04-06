// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockSponge : net.minecraft.src.Block
	{
		protected internal BlockSponge(int i)
			: base(i, net.minecraft.src.Material.sponge)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, World
			blockIndexInTexture = 48;
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			byte byte0 = 2;
			for (int l = i - byte0; l <= i + byte0; l++)
			{
				for (int i1 = j - byte0; i1 <= j + byte0; i1++)
				{
					for (int j1 = k - byte0; j1 <= k + byte0; j1++)
					{
						if (world.GetBlockMaterial(l, i1, j1) != net.minecraft.src.Material.water)
						{
						}
					}
				}
			}
		}

		public override void OnBlockRemoval(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			byte byte0 = 2;
			for (int l = i - byte0; l <= i + byte0; l++)
			{
				for (int i1 = j - byte0; i1 <= j + byte0; i1++)
				{
					for (int j1 = k - byte0; j1 <= k + byte0; j1++)
					{
						world.NotifyBlocksOfNeighborChange(l, i1, j1, world.GetBlockId(l, i1, j1));
					}
				}
			}
		}
	}
}
