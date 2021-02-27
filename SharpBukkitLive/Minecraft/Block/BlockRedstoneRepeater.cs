// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockRedstoneRepeater : net.minecraft.src.Block
	{
		protected internal BlockRedstoneRepeater(int i, bool flag)
			: base(i, 6, net.minecraft.src.Material.circuits)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, World, IBlockAccess, 
			//            EntityLiving, MathHelper, Item, EntityPlayer
			field_22015_c = flag;
			SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 0.125F, 1.0F);
		}

		public override bool IsACube()
		{
			return false;
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			if (!world.IsBlockNormalCube(i, j - 1, k))
			{
				return false;
			}
			else
			{
				return base.CanPlaceBlockAt(world, i, j, k);
			}
		}

		public override bool CanBlockStay(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			if (!world.IsBlockNormalCube(i, j - 1, k))
			{
				return false;
			}
			else
			{
				return base.CanBlockStay(world, i, j, k);
			}
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			int l = world.GetBlockMetadata(i, j, k);
			bool flag = Func_22012_g(world, i, j, k, l);
			if (field_22015_c && !flag)
			{
				world.SetBlockAndMetadataWithNotify(i, j, k, net.minecraft.src.Block.redstoneRepeaterIdle
					.blockID, l);
			}
			else
			{
				if (!field_22015_c)
				{
					world.SetBlockAndMetadataWithNotify(i, j, k, net.minecraft.src.Block.redstoneRepeaterActive
						.blockID, l);
					if (!flag)
					{
						int i1 = (l & 0xc) >> 2;
						world.ScheduleUpdateTick(i, j, k, net.minecraft.src.Block.redstoneRepeaterActive.
							blockID, field_22013_b[i1] * 2);
					}
				}
			}
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			if (i == 0)
			{
				return !field_22015_c ? 115 : 99;
			}
			if (i == 1)
			{
				return !field_22015_c ? 131 : 147;
			}
			else
			{
				return 5;
			}
		}

		public override int GetBlockTextureFromSide(int i)
		{
			return GetBlockTextureFromSideAndMetadata(i, 0);
		}

		public override bool IsIndirectlyPoweringTo(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			return IsPoweringTo(world, i, j, k, l);
		}

		public override bool IsPoweringTo(net.minecraft.src.IBlockAccess iblockaccess, int
			 i, int j, int k, int l)
		{
			if (!field_22015_c)
			{
				return false;
			}
			int i1 = iblockaccess.GetBlockMetadata(i, j, k) & 3;
			if (i1 == 0 && l == 3)
			{
				return true;
			}
			if (i1 == 1 && l == 4)
			{
				return true;
			}
			if (i1 == 2 && l == 2)
			{
				return true;
			}
			return i1 == 3 && l == 5;
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			if (!CanBlockStay(world, i, j, k))
			{
				DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
				world.SetBlockWithNotify(i, j, k, 0);
				return;
			}
			int i1 = world.GetBlockMetadata(i, j, k);
			bool flag = Func_22012_g(world, i, j, k, i1);
			int j1 = (i1 & 0xc) >> 2;
			if (field_22015_c && !flag)
			{
				world.ScheduleUpdateTick(i, j, k, blockID, field_22013_b[j1] * 2);
			}
			else
			{
				if (!field_22015_c && flag)
				{
					world.ScheduleUpdateTick(i, j, k, blockID, field_22013_b[j1] * 2);
				}
			}
		}

		private bool Func_22012_g(net.minecraft.src.World world, int i, int j, int k, int
			 l)
		{
			int i1 = l & 3;
			switch (i1)
			{
				case 0:
				{
					// '\0'
					return world.IsBlockIndirectlyProvidingPowerTo(i, j, k + 1, 3) || world.GetBlockId
						(i, j, k + 1) == net.minecraft.src.Block.redstoneWire.blockID && world.GetBlockMetadata
						(i, j, k + 1) > 0;
				}

				case 2:
				{
					// '\002'
					return world.IsBlockIndirectlyProvidingPowerTo(i, j, k - 1, 2) || world.GetBlockId
						(i, j, k - 1) == net.minecraft.src.Block.redstoneWire.blockID && world.GetBlockMetadata
						(i, j, k - 1) > 0;
				}

				case 3:
				{
					// '\003'
					return world.IsBlockIndirectlyProvidingPowerTo(i + 1, j, k, 5) || world.GetBlockId
						(i + 1, j, k) == net.minecraft.src.Block.redstoneWire.blockID && world.GetBlockMetadata
						(i + 1, j, k) > 0;
				}

				case 1:
				{
					// '\001'
					return world.IsBlockIndirectlyProvidingPowerTo(i - 1, j, k, 4) || world.GetBlockId
						(i - 1, j, k) == net.minecraft.src.Block.redstoneWire.blockID && world.GetBlockMetadata
						(i - 1, j, k) > 0;
				}
			}
			return false;
		}

		public override bool BlockActivated(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			int l = world.GetBlockMetadata(i, j, k);
			int i1 = (l & 0xc) >> 2;
			i1 = i1 + 1 << 2 & 0xc;
			world.SetBlockMetadataWithNotify(i, j, k, i1 | l & 3);
			return true;
		}

		public override bool CanProvidePower()
		{
			return false;
		}

		public override void OnBlockPlacedBy(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityLiving entityliving)
		{
			int l = ((net.minecraft.src.MathHelper.Floor_double((double)((entityliving.rotationYaw
				 * 4F) / 360F) + 0.5D) & 3) + 2) % 4;
			world.SetBlockMetadataWithNotify(i, j, k, l);
			bool flag = Func_22012_g(world, i, j, k, l);
			if (flag)
			{
				world.ScheduleUpdateTick(i, j, k, blockID, 1);
			}
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			world.NotifyBlocksOfNeighborChange(i + 1, j, k, blockID);
			world.NotifyBlocksOfNeighborChange(i - 1, j, k, blockID);
			world.NotifyBlocksOfNeighborChange(i, j, k + 1, blockID);
			world.NotifyBlocksOfNeighborChange(i, j, k - 1, blockID);
			world.NotifyBlocksOfNeighborChange(i, j - 1, k, blockID);
			world.NotifyBlocksOfNeighborChange(i, j + 1, k, blockID);
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Item.redstoneRepeater.shiftedIndex;
		}

		public static readonly double[] field_22014_a = new double[] { -0.0625D, 0.0625D, 
			0.1875D, 0.3125D };

		private static readonly int[] field_22013_b = new int[] { 1, 2, 3, 4 };

		private readonly bool field_22015_c;
	}
}
