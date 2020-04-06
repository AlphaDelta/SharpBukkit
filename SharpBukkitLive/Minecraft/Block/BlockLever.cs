// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockLever : net.minecraft.src.Block
	{
		protected internal BlockLever(int i, int j)
			: base(i, j, net.minecraft.src.Material.circuits)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Block, Material, World, IBlockAccess, 
		//            AxisAlignedBB, EntityPlayer
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

		public override bool CanPlaceBlockOnSide(net.minecraft.src.World world, int i, int
			 j, int k, int l)
		{
			if (l == 1 && world.IsBlockNormalCube(i, j - 1, k))
			{
				return true;
			}
			if (l == 2 && world.IsBlockNormalCube(i, j, k + 1))
			{
				return true;
			}
			if (l == 3 && world.IsBlockNormalCube(i, j, k - 1))
			{
				return true;
			}
			if (l == 4 && world.IsBlockNormalCube(i + 1, j, k))
			{
				return true;
			}
			return l == 5 && world.IsBlockNormalCube(i - 1, j, k);
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
			if (world.IsBlockNormalCube(i, j, k + 1))
			{
				return true;
			}
			return world.IsBlockNormalCube(i, j - 1, k);
		}

		public override void OnBlockPlaced(net.minecraft.src.World world, int i, int j, int
			 k, int l)
		{
			int i1 = world.GetBlockMetadata(i, j, k);
			int j1 = i1 & 8;
			i1 &= 7;
			i1 = -1;
			if (l == 1 && world.IsBlockNormalCube(i, j - 1, k))
			{
				i1 = 5 + world.rand.Next(2);
			}
			if (l == 2 && world.IsBlockNormalCube(i, j, k + 1))
			{
				i1 = 4;
			}
			if (l == 3 && world.IsBlockNormalCube(i, j, k - 1))
			{
				i1 = 3;
			}
			if (l == 4 && world.IsBlockNormalCube(i + 1, j, k))
			{
				i1 = 2;
			}
			if (l == 5 && world.IsBlockNormalCube(i - 1, j, k))
			{
				i1 = 1;
			}
			if (i1 == -1)
			{
				DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
				world.SetBlockWithNotify(i, j, k, 0);
				return;
			}
			else
			{
				world.SetBlockMetadataWithNotify(i, j, k, i1 + j1);
				return;
			}
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			if (CheckIfAttachedToBlock(world, i, j, k))
			{
				int i1 = world.GetBlockMetadata(i, j, k) & 7;
				bool flag = false;
				if (!world.IsBlockNormalCube(i - 1, j, k) && i1 == 1)
				{
					flag = true;
				}
				if (!world.IsBlockNormalCube(i + 1, j, k) && i1 == 2)
				{
					flag = true;
				}
				if (!world.IsBlockNormalCube(i, j, k - 1) && i1 == 3)
				{
					flag = true;
				}
				if (!world.IsBlockNormalCube(i, j, k + 1) && i1 == 4)
				{
					flag = true;
				}
				if (!world.IsBlockNormalCube(i, j - 1, k) && i1 == 5)
				{
					flag = true;
				}
				if (!world.IsBlockNormalCube(i, j - 1, k) && i1 == 6)
				{
					flag = true;
				}
				if (flag)
				{
					DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
					world.SetBlockWithNotify(i, j, k, 0);
				}
			}
		}

		private bool CheckIfAttachedToBlock(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			if (!CanPlaceBlockAt(world, i, j, k))
			{
				DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
				world.SetBlockWithNotify(i, j, k, 0);
				return false;
			}
			else
			{
				return true;
			}
		}

		public override void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k)
		{
			int l = iblockaccess.GetBlockMetadata(i, j, k) & 7;
			float f = 0.1875F;
			if (l == 1)
			{
				SetBlockBounds(0.0F, 0.2F, 0.5F - f, f * 2.0F, 0.8F, 0.5F + f);
			}
			else
			{
				if (l == 2)
				{
					SetBlockBounds(1.0F - f * 2.0F, 0.2F, 0.5F - f, 1.0F, 0.8F, 0.5F + f);
				}
				else
				{
					if (l == 3)
					{
						SetBlockBounds(0.5F - f, 0.2F, 0.0F, 0.5F + f, 0.8F, f * 2.0F);
					}
					else
					{
						if (l == 4)
						{
							SetBlockBounds(0.5F - f, 0.2F, 1.0F - f * 2.0F, 0.5F + f, 0.8F, 1.0F);
						}
						else
						{
							float f1 = 0.25F;
							SetBlockBounds(0.5F - f1, 0.0F, 0.5F - f1, 0.5F + f1, 0.6F, 0.5F + f1);
						}
					}
				}
			}
		}

		public override void OnBlockClicked(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			BlockActivated(world, i, j, k, entityplayer);
		}

		public override bool BlockActivated(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			if (world.singleplayerWorld)
			{
				return true;
			}
			int l = world.GetBlockMetadata(i, j, k);
			int i1 = l & 7;
			int j1 = 8 - (l & 8);
			world.SetBlockMetadataWithNotify(i, j, k, i1 + j1);
			world.MarkBlocksDirty(i, j, k, i, j, k);
			world.PlaySoundEffect((double)i + 0.5D, (double)j + 0.5D, (double)k + 0.5D, "random.click"
				, 0.3F, j1 <= 0 ? 0.5F : 0.6F);
			world.NotifyBlocksOfNeighborChange(i, j, k, blockID);
			if (i1 == 1)
			{
				world.NotifyBlocksOfNeighborChange(i - 1, j, k, blockID);
			}
			else
			{
				if (i1 == 2)
				{
					world.NotifyBlocksOfNeighborChange(i + 1, j, k, blockID);
				}
				else
				{
					if (i1 == 3)
					{
						world.NotifyBlocksOfNeighborChange(i, j, k - 1, blockID);
					}
					else
					{
						if (i1 == 4)
						{
							world.NotifyBlocksOfNeighborChange(i, j, k + 1, blockID);
						}
						else
						{
							world.NotifyBlocksOfNeighborChange(i, j - 1, k, blockID);
						}
					}
				}
			}
			return true;
		}

		public override void OnBlockRemoval(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			int l = world.GetBlockMetadata(i, j, k);
			if ((l & 8) > 0)
			{
				world.NotifyBlocksOfNeighborChange(i, j, k, blockID);
				int i1 = l & 7;
				if (i1 == 1)
				{
					world.NotifyBlocksOfNeighborChange(i - 1, j, k, blockID);
				}
				else
				{
					if (i1 == 2)
					{
						world.NotifyBlocksOfNeighborChange(i + 1, j, k, blockID);
					}
					else
					{
						if (i1 == 3)
						{
							world.NotifyBlocksOfNeighborChange(i, j, k - 1, blockID);
						}
						else
						{
							if (i1 == 4)
							{
								world.NotifyBlocksOfNeighborChange(i, j, k + 1, blockID);
							}
							else
							{
								world.NotifyBlocksOfNeighborChange(i, j - 1, k, blockID);
							}
						}
					}
				}
			}
			base.OnBlockRemoval(world, i, j, k);
		}

		public override bool IsPoweringTo(net.minecraft.src.IBlockAccess iblockaccess, int
			 i, int j, int k, int l)
		{
			return (iblockaccess.GetBlockMetadata(i, j, k) & 8) > 0;
		}

		public override bool IsIndirectlyPoweringTo(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			int i1 = world.GetBlockMetadata(i, j, k);
			if ((i1 & 8) == 0)
			{
				return false;
			}
			int j1 = i1 & 7;
			if (j1 == 6 && l == 1)
			{
				return true;
			}
			if (j1 == 5 && l == 1)
			{
				return true;
			}
			if (j1 == 4 && l == 2)
			{
				return true;
			}
			if (j1 == 3 && l == 3)
			{
				return true;
			}
			if (j1 == 2 && l == 4)
			{
				return true;
			}
			return j1 == 1 && l == 5;
		}

		public override bool CanProvidePower()
		{
			return true;
		}
	}
}
