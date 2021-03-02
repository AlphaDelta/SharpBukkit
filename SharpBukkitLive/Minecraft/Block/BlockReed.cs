// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockReed : net.minecraft.src.Block
	{
		protected internal BlockReed(int i, int j)
			: base(i, net.minecraft.src.Material.plants)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, World, BlockGrass, 
			//            Item, AxisAlignedBB
			blockIndexInTexture = j;
			float f = 0.375F;
			SetBlockBounds(0.5F - f, 0.0F, 0.5F - f, 0.5F + f, 1.0F, 0.5F + f);
			SetTickOnLoad(true);
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (world.IsAirBlock(i, j + 1, k))
			{
				int l;
				for (l = 1; world.GetBlockId(i, j - l, k) == ID; l++)
				{
				}
				if (l < 3)
				{
					int i1 = world.GetBlockMetadata(i, j, k);
					if (i1 == 15)
					{
						world.SetBlockWithNotify(i, j + 1, k, ID);
						world.SetBlockMetadataWithNotify(i, j, k, 0);
					}
					else
					{
						world.SetBlockMetadataWithNotify(i, j, k, i1 + 1);
					}
				}
			}
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			int l = world.GetBlockId(i, j - 1, k);
			if (l == ID)
			{
				return true;
			}
			if (l != net.minecraft.src.Block.GRASS.ID && l != net.minecraft.src.Block.DIRT
				.ID)
			{
				return false;
			}
			if (world.GetBlockMaterial(i - 1, j - 1, k) == net.minecraft.src.Material.water)
			{
				return true;
			}
			if (world.GetBlockMaterial(i + 1, j - 1, k) == net.minecraft.src.Material.water)
			{
				return true;
			}
			if (world.GetBlockMaterial(i, j - 1, k - 1) == net.minecraft.src.Material.water)
			{
				return true;
			}
			return world.GetBlockMaterial(i, j - 1, k + 1) == net.minecraft.src.Material.water;
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			CheckBlockCoordValid(world, i, j, k);
		}

		protected internal void CheckBlockCoordValid(net.minecraft.src.World world, int i
			, int j, int k)
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
			return CanPlaceBlockAt(world, i, j, k);
		}

		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			return null;
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Item.SUGAR_CANE.ID;
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
