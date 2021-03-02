// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockFence : net.minecraft.src.Block
	{
		public BlockFence(int i, int j)
			: base(i, j, net.minecraft.src.Material.wood)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Block, Material, World, AxisAlignedBB
		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			if (world.GetBlockId(i, j - 1, k) == ID)
			{
				return true;
			}
			if (!world.GetBlockMaterial(i, j - 1, k).IsSolid())
			{
				return false;
			}
			else
			{
				return base.CanPlaceBlockAt(world, i, j, k);
			}
		}

		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			return net.minecraft.src.AxisAlignedBB.GetBoundingBoxFromPool(i, j, k, i + 1, (float
				)j + 1.5F, k + 1);
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		public override bool IsACube()
		{
			return false;
		}
	}
}
