// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public abstract class BlockContainer : net.minecraft.src.Block
	{
		protected internal BlockContainer(int i, net.minecraft.src.Material material)
			: base(i, material)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, World, Material, TileEntity
			isBlockContainer[i] = true;
		}

		protected internal BlockContainer(int i, int j, net.minecraft.src.Material material
			)
			: base(i, j, material)
		{
			isBlockContainer[i] = true;
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			base.OnBlockAdded(world, i, j, k);
			world.SetBlockTileEntity(i, j, k, GetBlockEntity());
		}

		public override void OnBlockRemoval(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			base.OnBlockRemoval(world, i, j, k);
			world.RemoveBlockTileEntity(i, j, k);
		}

		protected internal abstract net.minecraft.src.TileEntity GetBlockEntity();
	}
}
