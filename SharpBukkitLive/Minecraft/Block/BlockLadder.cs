// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockLadder : net.minecraft.src.Block
	{
		protected internal BlockLadder(int i, int j)
			: base(i, j, net.minecraft.src.Material.circuits)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Block, Material, World, AxisAlignedBB
		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			int l = world.GetBlockMetadata(i, j, k);
			float f = 0.125F;
			if (l == 2)
			{
				SetBlockBounds(0.0F, 0.0F, 1.0F - f, 1.0F, 1.0F, 1.0F);
			}
			if (l == 3)
			{
				SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 1.0F, f);
			}
			if (l == 4)
			{
				SetBlockBounds(1.0F - f, 0.0F, 0.0F, 1.0F, 1.0F, 1.0F);
			}
			if (l == 5)
			{
				SetBlockBounds(0.0F, 0.0F, 0.0F, f, 1.0F, 1.0F);
			}
			return base.GetCollisionBoundingBoxFromPool(world, i, j, k);
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		public override bool IsACube()
		{
			return false;
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			if (world.IsBlockNormalCube(i - 1, j, k))
			{
				return true;
			}
			if (world.IsBlockNormalCube(i + 1, j, k))
			{
				return true;
			}
			if (world.IsBlockNormalCube(i, j, k - 1))
			{
				return true;
			}
			return world.IsBlockNormalCube(i, j, k + 1);
		}

		public override void OnBlockPlaced(net.minecraft.src.World world, int i, int j, int
			 k, int l)
		{
			int i1 = world.GetBlockMetadata(i, j, k);
			if ((i1 == 0 || l == 2) && world.IsBlockNormalCube(i, j, k + 1))
			{
				i1 = 2;
			}
			if ((i1 == 0 || l == 3) && world.IsBlockNormalCube(i, j, k - 1))
			{
				i1 = 3;
			}
			if ((i1 == 0 || l == 4) && world.IsBlockNormalCube(i + 1, j, k))
			{
				i1 = 4;
			}
			if ((i1 == 0 || l == 5) && world.IsBlockNormalCube(i - 1, j, k))
			{
				i1 = 5;
			}
			world.SetBlockMetadataWithNotify(i, j, k, i1);
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			int i1 = world.GetBlockMetadata(i, j, k);
			bool flag = false;
			if (i1 == 2 && world.IsBlockNormalCube(i, j, k + 1))
			{
				flag = true;
			}
			if (i1 == 3 && world.IsBlockNormalCube(i, j, k - 1))
			{
				flag = true;
			}
			if (i1 == 4 && world.IsBlockNormalCube(i + 1, j, k))
			{
				flag = true;
			}
			if (i1 == 5 && world.IsBlockNormalCube(i - 1, j, k))
			{
				flag = true;
			}
			if (!flag)
			{
				DropBlockAsItem(world, i, j, k, i1);
				world.SetBlockWithNotify(i, j, k, 0);
			}
			base.OnNeighborBlockChange(world, i, j, k, l);
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 1;
		}
	}
}
