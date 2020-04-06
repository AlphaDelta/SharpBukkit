// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockWeb : net.minecraft.src.Block
	{
		public BlockWeb(int i, int j)
			: base(i, j, net.minecraft.src.Material.web)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Block, Material, Entity, Item, 
		//            World, AxisAlignedBB
		public override void OnEntityCollidedWithBlock(net.minecraft.src.World world, int
			 i, int j, int k, net.minecraft.src.Entity entity)
		{
			entity.field_27012_bb = true;
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			return null;
		}

		public override bool IsACube()
		{
			return false;
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Item.silk.shiftedIndex;
		}
	}
}
