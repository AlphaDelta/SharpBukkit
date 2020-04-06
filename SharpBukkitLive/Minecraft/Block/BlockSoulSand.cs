// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockSoulSand : net.minecraft.src.Block
	{
		public BlockSoulSand(int i, int j)
			: base(i, j, net.minecraft.src.Material.sand)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Block, Material, AxisAlignedBB, Entity, 
		//            World
		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			float f = 0.125F;
			return net.minecraft.src.AxisAlignedBB.GetBoundingBoxFromPool(i, j, k, i + 1, (float
				)(j + 1) - f, k + 1);
		}

		public override void OnEntityCollidedWithBlock(net.minecraft.src.World world, int
			 i, int j, int k, net.minecraft.src.Entity entity)
		{
			entity.motionX *= 0.40000000000000002D;
			entity.motionZ *= 0.40000000000000002D;
		}
	}
}
