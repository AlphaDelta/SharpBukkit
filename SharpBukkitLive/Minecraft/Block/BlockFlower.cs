// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockFlower : net.minecraft.src.Block
	{
		protected internal BlockFlower(int i, int j)
			: base(i, net.minecraft.src.Material.plants)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, World, BlockGrass, 
			//            AxisAlignedBB
			blockIndexInTexture = j;
			SetTickOnLoad(true);
			float f = 0.2F;
			SetBlockBounds(0.5F - f, 0.0F, 0.5F - f, 0.5F + f, f * 3F, 0.5F + f);
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			return base.CanPlaceBlockAt(world, i, j, k) && CanThisPlantGrowOnThisBlockID(world
				.GetBlockId(i, j - 1, k));
		}

		protected internal virtual bool CanThisPlantGrowOnThisBlockID(int i)
		{
			return i == net.minecraft.src.Block.grass.blockID || i == net.minecraft.src.Block
				.dirt.blockID || i == net.minecraft.src.Block.tilledField.blockID;
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			base.OnNeighborBlockChange(world, i, j, k, l);
			Func_276_g(world, i, j, k);
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			Func_276_g(world, i, j, k);
		}

		protected internal void Func_276_g(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			if (!CanBlockStay(world, i, j, k))
			{
				DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
				world.SetBlockWithNotify(i, j, k, 0);
			}
		}

		public override bool CanBlockStay(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			return (world.GetBlockLightValueNoChecks(i, j, k) >= 8 || world.CanBlockSeeTheSky
				(i, j, k)) && CanThisPlantGrowOnThisBlockID(world.GetBlockId(i, j - 1, k));
		}

		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			return null;
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
