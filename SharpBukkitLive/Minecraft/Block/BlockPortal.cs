// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockPortal : net.minecraft.src.BlockBreakable
	{
		public BlockPortal(int i, int j)
			: base(i, j, net.minecraft.src.Material.portal, false)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            BlockBreakable, Material, IBlockAccess, World, 
		//            Block, BlockFire, Entity, AxisAlignedBB
		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			return null;
		}

		public override void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k)
		{
			if (iblockaccess.GetBlockId(i - 1, j, k) == ID || iblockaccess.GetBlockId(i 
				+ 1, j, k) == ID)
			{
				float f = 0.5F;
				float f2 = 0.125F;
				SetBlockBounds(0.5F - f, 0.0F, 0.5F - f2, 0.5F + f, 1.0F, 0.5F + f2);
			}
			else
			{
				float f1 = 0.125F;
				float f3 = 0.5F;
				SetBlockBounds(0.5F - f1, 0.0F, 0.5F - f3, 0.5F + f1, 1.0F, 0.5F + f3);
			}
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		public override bool IsACube()
		{
			return false;
		}

		public virtual bool TryToCreatePortal(net.minecraft.src.World world, int i, int j
			, int k)
		{
			int l = 0;
			int i1 = 0;
			if (world.GetBlockId(i - 1, j, k) == net.minecraft.src.Block.OBSISIAN.ID || 
				world.GetBlockId(i + 1, j, k) == net.minecraft.src.Block.OBSISIAN.ID)
			{
				l = 1;
			}
			if (world.GetBlockId(i, j, k - 1) == net.minecraft.src.Block.OBSISIAN.ID || 
				world.GetBlockId(i, j, k + 1) == net.minecraft.src.Block.OBSISIAN.ID)
			{
				i1 = 1;
			}
			if (l == i1)
			{
				return false;
			}
			if (world.GetBlockId(i - l, j, k - i1) == 0)
			{
				i -= l;
				k -= i1;
			}
			for (int j1 = -1; j1 <= 2; j1++)
			{
				for (int l1 = -1; l1 <= 3; l1++)
				{
					bool flag = j1 == -1 || j1 == 2 || l1 == -1 || l1 == 3;
					if ((j1 == -1 || j1 == 2) && (l1 == -1 || l1 == 3))
					{
						continue;
					}
					int j2 = world.GetBlockId(i + l * j1, j + l1, k + i1 * j1);
					if (flag)
					{
						if (j2 != net.minecraft.src.Block.OBSISIAN.ID)
						{
							return false;
						}
						continue;
					}
					if (j2 != 0 && j2 != net.minecraft.src.Block.FIRE.ID)
					{
						return false;
					}
				}
			}
			world.editingBlocks = true;
			for (int k1 = 0; k1 < 2; k1++)
			{
				for (int i2 = 0; i2 < 3; i2++)
				{
					world.SetBlockWithNotify(i + l * k1, j + i2, k + i1 * k1, net.minecraft.src.Block
						.PORTAL.ID);
				}
			}
			world.editingBlocks = false;
			return true;
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			int i1 = 0;
			int j1 = 1;
			if (world.GetBlockId(i - 1, j, k) == ID || world.GetBlockId(i + 1, j, k) == 
				ID)
			{
				i1 = 1;
				j1 = 0;
			}
			int k1;
			for (k1 = j; world.GetBlockId(i, k1 - 1, k) == ID; k1--)
			{
			}
			if (world.GetBlockId(i, k1 - 1, k) != net.minecraft.src.Block.OBSISIAN.ID)
			{
				world.SetBlockWithNotify(i, j, k, 0);
				return;
			}
			int l1;
			for (l1 = 1; l1 < 4 && world.GetBlockId(i, k1 + l1, k) == ID; l1++)
			{
			}
			if (l1 != 3 || world.GetBlockId(i, k1 + l1, k) != net.minecraft.src.Block.OBSISIAN
				.ID)
			{
				world.SetBlockWithNotify(i, j, k, 0);
				return;
			}
			bool flag = world.GetBlockId(i - 1, j, k) == ID || world.GetBlockId(i + 1, j
				, k) == ID;
			bool flag1 = world.GetBlockId(i, j, k - 1) == ID || world.GetBlockId(i, j, k
				 + 1) == ID;
			if (flag && flag1)
			{
				world.SetBlockWithNotify(i, j, k, 0);
				return;
			}
			if ((world.GetBlockId(i + i1, j, k + j1) != net.minecraft.src.Block.OBSISIAN.ID
				 || world.GetBlockId(i - i1, j, k - j1) != ID) && (world.GetBlockId(i - i1, 
				j, k - j1) != net.minecraft.src.Block.OBSISIAN.ID || world.GetBlockId(i + i1
				, j, k + j1) != ID))
			{
				world.SetBlockWithNotify(i, j, k, 0);
				return;
			}
			else
			{
				return;
			}
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 0;
		}

		public override void OnEntityCollidedWithBlock(net.minecraft.src.World world, int
			 i, int j, int k, net.minecraft.src.Entity entity)
		{
			if (entity.ridingEntity == null && entity.riddenByEntity == null)
			{
				entity.SetInPortal();
			}
		}
	}
}
