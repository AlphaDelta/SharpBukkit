// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockRail : net.minecraft.src.Block
	{
		// Referenced classes of package net.minecraft.src:
		//            Block, World, Material, IBlockAccess, 
		//            RailLogic, AxisAlignedBB, Vec3D, MovingObjectPosition
		public static bool Func_27029_g(net.minecraft.src.World world, int i, int j, int 
			k)
		{
			int l = world.GetBlockId(i, j, k);
			return l == net.minecraft.src.Block.RAILS.blockID || l == net.minecraft.src.Block
				.GOLDEN_RAIL.blockID || l == net.minecraft.src.Block.DETECTOR_RAIL.blockID;
		}

		public static bool Func_27030_c(int i)
		{
			return i == net.minecraft.src.Block.RAILS.blockID || i == net.minecraft.src.Block
				.GOLDEN_RAIL.blockID || i == net.minecraft.src.Block.DETECTOR_RAIL.blockID;
		}

		protected internal BlockRail(int i, int j, bool flag)
			: base(i, j, net.minecraft.src.Material.circuits)
		{
			field_27034_a = flag;
			SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 0.125F, 1.0F);
		}

		public virtual bool Func_27028_d()
		{
			return field_27034_a;
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

		public override net.minecraft.src.MovingObjectPosition CollisionRayTrace(net.minecraft.src.World
			 world, int i, int j, int k, net.minecraft.src.Vec3D vec3d, net.minecraft.src.Vec3D
			 vec3d1)
		{
			SetBlockBoundsBasedOnState(world, i, j, k);
			return base.CollisionRayTrace(world, i, j, k, vec3d, vec3d1);
		}

		public override void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k)
		{
			int l = iblockaccess.GetBlockMetadata(i, j, k);
			if (l >= 2 && l <= 5)
			{
				SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 0.625F, 1.0F);
			}
			else
			{
				SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 0.125F, 1.0F);
			}
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			if (field_27034_a)
			{
				if (blockID == net.minecraft.src.Block.GOLDEN_RAIL.blockID && (j & 8) == 0)
				{
					return blockIndexInTexture - 16;
				}
			}
			else
			{
				if (j >= 6)
				{
					return blockIndexInTexture - 16;
				}
			}
			return blockIndexInTexture;
		}

		public override bool IsACube()
		{
			return false;
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 1;
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			return world.IsBlockNormalCube(i, j - 1, k);
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			if (!world.singleplayerWorld)
			{
				Func_4038_g(world, i, j, k, true);
			}
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			int i1 = world.GetBlockMetadata(i, j, k);
			int j1 = i1;
			if (field_27034_a)
			{
				j1 &= 7;
			}
			bool flag = false;
			if (!world.IsBlockNormalCube(i, j - 1, k))
			{
				flag = true;
			}
			if (j1 == 2 && !world.IsBlockNormalCube(i + 1, j, k))
			{
				flag = true;
			}
			if (j1 == 3 && !world.IsBlockNormalCube(i - 1, j, k))
			{
				flag = true;
			}
			if (j1 == 4 && !world.IsBlockNormalCube(i, j, k - 1))
			{
				flag = true;
			}
			if (j1 == 5 && !world.IsBlockNormalCube(i, j, k + 1))
			{
				flag = true;
			}
			if (flag)
			{
				DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
				world.SetBlockWithNotify(i, j, k, 0);
			}
			else
			{
				if (blockID == net.minecraft.src.Block.GOLDEN_RAIL.blockID)
				{
					bool flag1 = world.IsBlockIndirectlyGettingPowered(i, j, k) || world.IsBlockIndirectlyGettingPowered
						(i, j + 1, k);
					flag1 = flag1 || Func_27032_a(world, i, j, k, i1, true, 0) || Func_27032_a(world, 
						i, j, k, i1, false, 0);
					bool flag2 = false;
					if (flag1 && (i1 & 8) == 0)
					{
						world.SetBlockMetadataWithNotify(i, j, k, j1 | 8);
						flag2 = true;
					}
					else
					{
						if (!flag1 && (i1 & 8) != 0)
						{
							world.SetBlockMetadataWithNotify(i, j, k, j1);
							flag2 = true;
						}
					}
					if (flag2)
					{
						world.NotifyBlocksOfNeighborChange(i, j - 1, k, blockID);
						if (j1 == 2 || j1 == 3 || j1 == 4 || j1 == 5)
						{
							world.NotifyBlocksOfNeighborChange(i, j + 1, k, blockID);
						}
					}
				}
				else
				{
					if (l > 0 && net.minecraft.src.Block.blocksList[l].CanProvidePower() && !field_27034_a
						 && net.minecraft.src.RailLogic.GetNAdjacentTracks(new net.minecraft.src.RailLogic
						(this, world, i, j, k)) == 3)
					{
						Func_4038_g(world, i, j, k, false);
					}
				}
			}
		}

		private void Func_4038_g(net.minecraft.src.World world, int i, int j, int k, bool
			 flag)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			else
			{
				(new net.minecraft.src.RailLogic(this, world, i, j, k)).Func_596_a(world.IsBlockIndirectlyGettingPowered
					(i, j, k), flag);
				return;
			}
		}

		private bool Func_27032_a(net.minecraft.src.World world, int i, int j, int k, int
			 l, bool flag, int i1)
		{
			if (i1 >= 8)
			{
				return false;
			}
			int j1 = l & 7;
			bool flag1 = true;
			switch (j1)
			{
				case 0:
				{
					// '\0'
					if (flag)
					{
						k++;
					}
					else
					{
						k--;
					}
					break;
				}

				case 1:
				{
					// '\001'
					if (flag)
					{
						i--;
					}
					else
					{
						i++;
					}
					break;
				}

				case 2:
				{
					// '\002'
					if (flag)
					{
						i--;
					}
					else
					{
						i++;
						j++;
						flag1 = false;
					}
					j1 = 1;
					break;
				}

				case 3:
				{
					// '\003'
					if (flag)
					{
						i--;
						j++;
						flag1 = false;
					}
					else
					{
						i++;
					}
					j1 = 1;
					break;
				}

				case 4:
				{
					// '\004'
					if (flag)
					{
						k++;
					}
					else
					{
						k--;
						j++;
						flag1 = false;
					}
					j1 = 0;
					break;
				}

				case 5:
				{
					// '\005'
					if (flag)
					{
						k++;
						j++;
						flag1 = false;
					}
					else
					{
						k--;
					}
					j1 = 0;
					break;
				}
			}
			if (Func_27031_a(world, i, j, k, flag, i1, j1))
			{
				return true;
			}
			return flag1 && Func_27031_a(world, i, j - 1, k, flag, i1, j1);
		}

		private bool Func_27031_a(net.minecraft.src.World world, int i, int j, int k, bool
			 flag, int l, int i1)
		{
			int j1 = world.GetBlockId(i, j, k);
			if (j1 == net.minecraft.src.Block.GOLDEN_RAIL.blockID)
			{
				int k1 = world.GetBlockMetadata(i, j, k);
				int l1 = k1 & 7;
				if (i1 == 1 && (l1 == 0 || l1 == 4 || l1 == 5))
				{
					return false;
				}
				if (i1 == 0 && (l1 == 1 || l1 == 2 || l1 == 3))
				{
					return false;
				}
				if ((k1 & 8) != 0)
				{
					if (world.IsBlockIndirectlyGettingPowered(i, j, k) || world.IsBlockIndirectlyGettingPowered
						(i, j + 1, k))
					{
						return true;
					}
					else
					{
						return Func_27032_a(world, i, j, k, k1, flag, l + 1);
					}
				}
			}
			return false;
		}

		public override int GetMobilityFlag()
		{
			return 0;
		}

		internal static bool Func_27033_a(net.minecraft.src.BlockRail blockrail)
		{
			return blockrail.field_27034_a;
		}

		private readonly bool field_27034_a;
	}
}
