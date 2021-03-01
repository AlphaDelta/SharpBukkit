// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class BlockPistonBase : net.minecraft.src.Block
	{
		public BlockPistonBase(int i, int j, bool flag)
			: base(i, j, net.minecraft.src.Material.piston)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, PistonBlockTextures, EntityPlayer, 
			//            World, TileEntityPiston, BlockPistonMoving, IBlockAccess, 
			//            MathHelper, BlockPistonExtension, EntityLiving, AxisAlignedBB
			isSticky = flag;
			SetStepSound(soundStoneFootstep);
			SetHardness(0.5F);
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			int k = GetOrientation(j);
			if (k > 5)
			{
				return blockIndexInTexture;
			}
			if (i == k)
			{
				if (IsExtended(j) || minX > 0.0D || minY > 0.0D || minZ > 0.0D || maxX < 1.0D || 
					maxY < 1.0D || maxZ < 1.0D)
				{
					return 110;
				}
				else
				{
					return blockIndexInTexture;
				}
			}
			return i != net.minecraft.src.PistonBlockTextures.field_31052_a[k] ? 108 : 109;
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		public override bool BlockActivated(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			return false;
		}

		public override void OnBlockPlacedBy(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityLiving entityliving)
		{
			int l = DetermineOrientation(world, i, j, k, (net.minecraft.src.EntityPlayer)entityliving
				);
			world.SetBlockMetadataWithNotify(i, j, k, l);
			if (!world.singleplayerWorld)
			{
				UpdatePistonState(world, i, j, k);
			}
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			if (!world.singleplayerWorld && !ignoreUpdates)
			{
				UpdatePistonState(world, i, j, k);
			}
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			if (!world.singleplayerWorld && world.GetBlockTileEntity(i, j, k) == null)
			{
				UpdatePistonState(world, i, j, k);
			}
		}

		private void UpdatePistonState(net.minecraft.src.World world, int i, int j, int k
			)
		{
			int l = world.GetBlockMetadata(i, j, k);
			int i1 = GetOrientation(l);
			bool flag = IsPowered(world, i, j, k, i1);
			if (l == 7)
			{
				return;
			}
			if (flag && !IsExtended(l))
			{
				if (CanExtend(world, i, j, k, i1)) //TODO: bukkit bool -> int return on CanExtend
				{
					world.SetBlockMetadata(i, j, k, i1 | 8);
					world.PlayNoteAt(i, j, k, 0, i1);
				}
			}
			else
			{
				if (!flag && IsExtended(l))
				{
					world.SetBlockMetadata(i, j, k, i1);
					world.PlayNoteAt(i, j, k, 1, i1);
				}
			}
		}

		private bool IsPowered(net.minecraft.src.World world, int i, int j, int k, int l)
		{
			if (l != 0 && world.IsBlockIndirectlyProvidingPowerTo(i, j - 1, k, 0))
			{
				return true;
			}
			if (l != 1 && world.IsBlockIndirectlyProvidingPowerTo(i, j + 1, k, 1))
			{
				return true;
			}
			if (l != 2 && world.IsBlockIndirectlyProvidingPowerTo(i, j, k - 1, 2))
			{
				return true;
			}
			if (l != 3 && world.IsBlockIndirectlyProvidingPowerTo(i, j, k + 1, 3))
			{
				return true;
			}
			if (l != 5 && world.IsBlockIndirectlyProvidingPowerTo(i + 1, j, k, 5))
			{
				return true;
			}
			if (l != 4 && world.IsBlockIndirectlyProvidingPowerTo(i - 1, j, k, 4))
			{
				return true;
			}
			if (world.IsBlockIndirectlyProvidingPowerTo(i, j, k, 0))
			{
				return true;
			}
			if (world.IsBlockIndirectlyProvidingPowerTo(i, j + 2, k, 1))
			{
				return true;
			}
			if (world.IsBlockIndirectlyProvidingPowerTo(i, j + 1, k - 1, 2))
			{
				return true;
			}
			if (world.IsBlockIndirectlyProvidingPowerTo(i, j + 1, k + 1, 3))
			{
				return true;
			}
			if (world.IsBlockIndirectlyProvidingPowerTo(i - 1, j + 1, k, 4))
			{
				return true;
			}
			return world.IsBlockIndirectlyProvidingPowerTo(i + 1, j + 1, k, 5);
		}

		public override void PlayBlock(net.minecraft.src.World world, int i, int j, int k
			, int l, int i1)
		{
			ignoreUpdates = true;
			int j1 = i1;
			if (l == 0)
			{
				if (TryExtend(world, i, j, k, j1))
				{
					world.SetBlockMetadataWithNotify(i, j, k, j1 | 8);
					world.PlaySoundEffect((double)i + 0.5D, (double)j + 0.5D, (double)k + 0.5D, "tile.piston.out"
						, 0.5F, world.rand.NextFloat() * 0.25F + 0.6F);
				}
			}
			else
			{
				if (l == 1)
				{
					net.minecraft.src.TileEntity tileentity = world.GetBlockTileEntity(i + net.minecraft.src.PistonBlockTextures
						.field_31051_b[j1], j + net.minecraft.src.PistonBlockTextures.field_31054_c[j1], 
						k + net.minecraft.src.PistonBlockTextures.field_31053_d[j1]);
					if (tileentity != null && (tileentity is net.minecraft.src.TileEntityPiston))
					{
						((net.minecraft.src.TileEntityPiston)tileentity).ClearPistonTileEntity();
					}
					world.SetBlockAndMetadata(i, j, k, net.minecraft.src.Block.pistonMoving.blockID, 
						j1);
					world.SetBlockTileEntity(i, j, k, net.minecraft.src.BlockPistonMoving.GetTileEntity
						(blockID, j1, j1, false, true));
					if (isSticky)
					{
						int k1 = i + net.minecraft.src.PistonBlockTextures.field_31051_b[j1] * 2;
						int l1 = j + net.minecraft.src.PistonBlockTextures.field_31054_c[j1] * 2;
						int i2 = k + net.minecraft.src.PistonBlockTextures.field_31053_d[j1] * 2;
						int j2 = world.GetBlockId(k1, l1, i2);
						int k2 = world.GetBlockMetadata(k1, l1, i2);
						bool flag = false;
						if (j2 == net.minecraft.src.Block.pistonMoving.blockID)
						{
							net.minecraft.src.TileEntity tileentity1 = world.GetBlockTileEntity(k1, l1, i2);
							if (tileentity1 != null && (tileentity1 is net.minecraft.src.TileEntityPiston))
							{
								net.minecraft.src.TileEntityPiston tileentitypiston = (net.minecraft.src.TileEntityPiston
									)tileentity1;
								if (tileentitypiston.Func_31008_d() == j1 && tileentitypiston.Func_31010_c())
								{
									tileentitypiston.ClearPistonTileEntity();
									j2 = tileentitypiston.GetStoredBlockID();
									k2 = tileentitypiston.Func_31005_e();
									flag = true;
								}
							}
						}
						if (!flag && j2 > 0 && CanPushBlock(j2, world, k1, l1, i2, false) && (net.minecraft.src.Block
							.blocksList[j2].GetMobilityFlag() == 0 || j2 == net.minecraft.src.Block.pistonBase
							.blockID || j2 == net.minecraft.src.Block.pistonStickyBase.blockID))
						{
							ignoreUpdates = false;
							world.SetBlockWithNotify(k1, l1, i2, 0);
							ignoreUpdates = true;
							i += net.minecraft.src.PistonBlockTextures.field_31051_b[j1];
							j += net.minecraft.src.PistonBlockTextures.field_31054_c[j1];
							k += net.minecraft.src.PistonBlockTextures.field_31053_d[j1];
							world.SetBlockAndMetadata(i, j, k, net.minecraft.src.Block.pistonMoving.blockID, 
								k2);
							world.SetBlockTileEntity(i, j, k, net.minecraft.src.BlockPistonMoving.GetTileEntity
								(j2, k2, j1, false, false));
						}
						else
						{
							if (!flag)
							{
								ignoreUpdates = false;
								world.SetBlockWithNotify(i + net.minecraft.src.PistonBlockTextures.field_31051_b[
									j1], j + net.minecraft.src.PistonBlockTextures.field_31054_c[j1], k + net.minecraft.src.PistonBlockTextures
									.field_31053_d[j1], 0);
								ignoreUpdates = true;
							}
						}
					}
					else
					{
						ignoreUpdates = false;
						world.SetBlockWithNotify(i + net.minecraft.src.PistonBlockTextures.field_31051_b[
							j1], j + net.minecraft.src.PistonBlockTextures.field_31054_c[j1], k + net.minecraft.src.PistonBlockTextures
							.field_31053_d[j1], 0);
						ignoreUpdates = true;
					}
					world.PlaySoundEffect((double)i + 0.5D, (double)j + 0.5D, (double)k + 0.5D, "tile.piston.in"
						, 0.5F, world.rand.NextFloat() * 0.15F + 0.6F);
				}
			}
			ignoreUpdates = false;
		}

		public override void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k)
		{
			int l = iblockaccess.GetBlockMetadata(i, j, k);
			if (IsExtended(l))
			{
				switch (GetOrientation(l))
				{
					case 0:
					{
						// '\0'
						SetBlockBounds(0.0F, 0.25F, 0.0F, 1.0F, 1.0F, 1.0F);
						break;
					}

					case 1:
					{
						// '\001'
						SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 0.75F, 1.0F);
						break;
					}

					case 2:
					{
						// '\002'
						SetBlockBounds(0.0F, 0.0F, 0.25F, 1.0F, 1.0F, 1.0F);
						break;
					}

					case 3:
					{
						// '\003'
						SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 1.0F, 0.75F);
						break;
					}

					case 4:
					{
						// '\004'
						SetBlockBounds(0.25F, 0.0F, 0.0F, 1.0F, 1.0F, 1.0F);
						break;
					}

					case 5:
					{
						// '\005'
						SetBlockBounds(0.0F, 0.0F, 0.0F, 0.75F, 1.0F, 1.0F);
						break;
					}
				}
			}
			else
			{
				SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 1.0F, 1.0F);
			}
		}

		public override void GetCollidingBoundingBoxes(net.minecraft.src.World world, int i, int j, int k, net.minecraft.src.AxisAlignedBB axisalignedbb, List<AxisAlignedBB> arraylist)
		{
			SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 1.0F, 1.0F);
			base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
		}

		public override bool IsACube()
		{
			return false;
		}

		public static int GetOrientation(int i)
		{
			return i & 7;
		}

		public static bool IsExtended(int i)
		{
			return (i & 8) != 0;
		}

		private static int DetermineOrientation(net.minecraft.src.World world, int i, int
			 j, int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			if (net.minecraft.src.MathHelper.Abs((float)entityplayer.posX - (float)i) < 2.0F 
				&& net.minecraft.src.MathHelper.Abs((float)entityplayer.posZ - (float)k) < 2.0F)
			{
				double d = (entityplayer.posY + 1.8200000000000001D) - (double)entityplayer.yOffset;
				if (d - (double)j > 2D)
				{
					return 1;
				}
				if ((double)j - d > 0.0D)
				{
					return 0;
				}
			}
			int l = net.minecraft.src.MathHelper.Floor_double((double)((entityplayer.rotationYaw
				 * 4F) / 360F) + 0.5D) & 3;
			if (l == 0)
			{
				return 2;
			}
			if (l == 1)
			{
				return 5;
			}
			if (l == 2)
			{
				return 3;
			}
			return l != 3 ? 0 : 4;
		}

		private static bool CanPushBlock(int i, net.minecraft.src.World world, int j, int
			 k, int l, bool flag)
		{
			if (i == net.minecraft.src.Block.obsidian.blockID)
			{
				return false;
			}
			if (i == net.minecraft.src.Block.pistonBase.blockID || i == net.minecraft.src.Block
				.pistonStickyBase.blockID)
			{
				if (IsExtended(world.GetBlockMetadata(j, k, l)))
				{
					return false;
				}
			}
			else
			{
				if (net.minecraft.src.Block.blocksList[i].GetHardness() == -1F)
				{
					return false;
				}
				if (net.minecraft.src.Block.blocksList[i].GetMobilityFlag() == 2)
				{
					return false;
				}
				if (!flag && net.minecraft.src.Block.blocksList[i].GetMobilityFlag() == 1)
				{
					return false;
				}
			}
			net.minecraft.src.TileEntity tileentity = world.GetBlockTileEntity(j, k, l);
			return tileentity == null;
		}

		private static bool CanExtend(net.minecraft.src.World world, int i, int j, int k, 
			int l)
		{
			int i1 = i + net.minecraft.src.PistonBlockTextures.field_31051_b[l];
			int j1 = j + net.minecraft.src.PistonBlockTextures.field_31054_c[l];
			int k1 = k + net.minecraft.src.PistonBlockTextures.field_31053_d[l];
			int l1 = 0;
			do
			{
				if (l1 >= 13)
				{
					break;
				}
				if (j1 <= 0 || j1 >= 127)
				{
					return false;
				}
				int i2 = world.GetBlockId(i1, j1, k1);
				if (i2 == 0)
				{
					break;
				}
				if (!CanPushBlock(i2, world, i1, j1, k1, true))
				{
					return false;
				}
				if (net.minecraft.src.Block.blocksList[i2].GetMobilityFlag() == 1)
				{
					break;
				}
				if (l1 == 12)
				{
					return false;
				}
				i1 += net.minecraft.src.PistonBlockTextures.field_31051_b[l];
				j1 += net.minecraft.src.PistonBlockTextures.field_31054_c[l];
				k1 += net.minecraft.src.PistonBlockTextures.field_31053_d[l];
				l1++;
			}
			while (true);
			return true;
		}

		private bool TryExtend(net.minecraft.src.World world, int i, int j, int k, int l)
		{
			int i1 = i + net.minecraft.src.PistonBlockTextures.field_31051_b[l];
			int j1 = j + net.minecraft.src.PistonBlockTextures.field_31054_c[l];
			int k1 = k + net.minecraft.src.PistonBlockTextures.field_31053_d[l];
			int l1 = 0;
			do
			{
				if (l1 >= 13)
				{
					break;
				}
				if (j1 <= 0 || j1 >= 127)
				{
					return false;
				}
				int j2 = world.GetBlockId(i1, j1, k1);
				if (j2 == 0)
				{
					break;
				}
				if (!CanPushBlock(j2, world, i1, j1, k1, true))
				{
					return false;
				}
				if (net.minecraft.src.Block.blocksList[j2].GetMobilityFlag() == 1)
				{
					net.minecraft.src.Block.blocksList[j2].DropBlockAsItem(world, i1, j1, k1, world.GetBlockMetadata
						(i1, j1, k1));
					world.SetBlockWithNotify(i1, j1, k1, 0);
					break;
				}
				if (l1 == 12)
				{
					return false;
				}
				i1 += net.minecraft.src.PistonBlockTextures.field_31051_b[l];
				j1 += net.minecraft.src.PistonBlockTextures.field_31054_c[l];
				k1 += net.minecraft.src.PistonBlockTextures.field_31053_d[l];
				l1++;
			}
			while (true);
			int l2;
			for (; i1 != i || j1 != j || k1 != k; k1 = l2)
			{
				int i2 = i1 - net.minecraft.src.PistonBlockTextures.field_31051_b[l];
				int k2 = j1 - net.minecraft.src.PistonBlockTextures.field_31054_c[l];
				l2 = k1 - net.minecraft.src.PistonBlockTextures.field_31053_d[l];
				int i3 = world.GetBlockId(i2, k2, l2);
				int j3 = world.GetBlockMetadata(i2, k2, l2);
				if (i3 == blockID && i2 == i && k2 == j && l2 == k)
				{
					world.SetBlockAndMetadata(i1, j1, k1, net.minecraft.src.Block.pistonMoving.blockID
						, l | (isSticky ? 8 : 0));
					world.SetBlockTileEntity(i1, j1, k1, net.minecraft.src.BlockPistonMoving.GetTileEntity
						(net.minecraft.src.Block.pistonExtension.blockID, l | (isSticky ? 8 : 0), l, true
						, false));
				}
				else
				{
					world.SetBlockAndMetadata(i1, j1, k1, net.minecraft.src.Block.pistonMoving.blockID
						, j3);
					world.SetBlockTileEntity(i1, j1, k1, net.minecraft.src.BlockPistonMoving.GetTileEntity
						(i3, j3, l, true, false));
				}
				i1 = i2;
				j1 = k2;
			}
			return true;
		}

		private bool isSticky;

		private bool ignoreUpdates;
	}
}
