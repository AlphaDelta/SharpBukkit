// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockPistonMoving : net.minecraft.src.BlockContainer
	{
		public BlockPistonMoving(int i)
			: base(i, net.minecraft.src.Material.piston)
		{
			// Referenced classes of package net.minecraft.src:
			//            BlockContainer, Material, World, TileEntityPiston, 
			//            Block, PistonBlockTextures, AxisAlignedBB, IBlockAccess, 
			//            TileEntity, EntityPlayer
			SetHardness(-1F);
		}

		protected internal override net.minecraft.src.TileEntity GetBlockEntity()
		{
			return null;
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
		}

		public override void OnBlockRemoval(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			net.minecraft.src.TileEntity tileentity = world.GetBlockTileEntity(i, j, k);
			if (tileentity != null && (tileentity is net.minecraft.src.TileEntityPiston))
			{
				((net.minecraft.src.TileEntityPiston)tileentity).ClearPistonTileEntity();
			}
			else
			{
				base.OnBlockRemoval(world, i, j, k);
			}
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			return false;
		}

		public override bool CanPlaceBlockOnSide(net.minecraft.src.World world, int i, int
			 j, int k, int l)
		{
			return false;
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		public override bool IsACube()
		{
			return false;
		}

		public override bool BlockActivated(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			if (!world.singleplayerWorld && world.GetBlockTileEntity(i, j, k) == null)
			{
				world.SetBlockWithNotify(i, j, k, 0);
				return true;
			}
			else
			{
				return false;
			}
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 0;
		}

		public override void DropBlockAsItemWithChance(net.minecraft.src.World world, int
			 i, int j, int k, int l, float f)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			net.minecraft.src.TileEntityPiston tileentitypiston = GetTileEntityAtLocation(world
				, i, j, k);
			if (tileentitypiston == null)
			{
				return;
			}
			else
			{
				net.minecraft.src.Block.blocksList[tileentitypiston.GetStoredBlockID()].DropBlockAsItem
					(world, i, j, k, tileentitypiston.Func_31005_e());
				return;
			}
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			if (!world.singleplayerWorld)
			{
				if (world.GetBlockTileEntity(i, j, k) != null)
				{
				}
			}
		}

		public static net.minecraft.src.TileEntity GetTileEntity(int i, int j, int k, bool
			 flag, bool flag1)
		{
			return new net.minecraft.src.TileEntityPiston(i, j, k, flag, flag1);
		}

		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			net.minecraft.src.TileEntityPiston tileentitypiston = GetTileEntityAtLocation(world
				, i, j, k);
			if (tileentitypiston == null)
			{
				return null;
			}
			float f = tileentitypiston.Func_31007_a(0.0F);
			if (tileentitypiston.Func_31010_c())
			{
				f = 1.0F - f;
			}
			return Func_31032_a(world, i, j, k, tileentitypiston.GetStoredBlockID(), f, tileentitypiston
				.Func_31008_d());
		}

		public override void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k)
		{
			net.minecraft.src.TileEntityPiston tileentitypiston = GetTileEntityAtLocation(iblockaccess
				, i, j, k);
			if (tileentitypiston != null)
			{
				net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[tileentitypiston
					.GetStoredBlockID()];
				if (block == null || block == this)
				{
					return;
				}
				block.SetBlockBoundsBasedOnState(iblockaccess, i, j, k);
				float f = tileentitypiston.Func_31007_a(0.0F);
				if (tileentitypiston.Func_31010_c())
				{
					f = 1.0F - f;
				}
				int l = tileentitypiston.Func_31008_d();
				minX = block.minX - (double)((float)net.minecraft.src.PistonBlockTextures.field_31051_b
					[l] * f);
				minY = block.minY - (double)((float)net.minecraft.src.PistonBlockTextures.field_31054_c
					[l] * f);
				minZ = block.minZ - (double)((float)net.minecraft.src.PistonBlockTextures.field_31053_d
					[l] * f);
				maxX = block.maxX - (double)((float)net.minecraft.src.PistonBlockTextures.field_31051_b
					[l] * f);
				maxY = block.maxY - (double)((float)net.minecraft.src.PistonBlockTextures.field_31054_c
					[l] * f);
				maxZ = block.maxZ - (double)((float)net.minecraft.src.PistonBlockTextures.field_31053_d
					[l] * f);
			}
		}

		public virtual net.minecraft.src.AxisAlignedBB Func_31032_a(net.minecraft.src.World
			 world, int i, int j, int k, int l, float f, int i1)
		{
			if (l == 0 || l == blockID)
			{
				return null;
			}
			net.minecraft.src.AxisAlignedBB axisalignedbb = net.minecraft.src.Block.blocksList
				[l].GetCollisionBoundingBoxFromPool(world, i, j, k);
			if (axisalignedbb == null)
			{
				return null;
			}
			else
			{
				axisalignedbb.minX -= (float)net.minecraft.src.PistonBlockTextures.field_31051_b[
					i1] * f;
				axisalignedbb.maxX -= (float)net.minecraft.src.PistonBlockTextures.field_31051_b[
					i1] * f;
				axisalignedbb.minY -= (float)net.minecraft.src.PistonBlockTextures.field_31054_c[
					i1] * f;
				axisalignedbb.maxY -= (float)net.minecraft.src.PistonBlockTextures.field_31054_c[
					i1] * f;
				axisalignedbb.minZ -= (float)net.minecraft.src.PistonBlockTextures.field_31053_d[
					i1] * f;
				axisalignedbb.maxZ -= (float)net.minecraft.src.PistonBlockTextures.field_31053_d[
					i1] * f;
				return axisalignedbb;
			}
		}

		private net.minecraft.src.TileEntityPiston GetTileEntityAtLocation(net.minecraft.src.IBlockAccess
			 iblockaccess, int i, int j, int k)
		{
			net.minecraft.src.TileEntity tileentity = iblockaccess.GetBlockTileEntity(i, j, k
				);
			if (tileentity != null && (tileentity is net.minecraft.src.TileEntityPiston))
			{
				return (net.minecraft.src.TileEntityPiston)tileentity;
			}
			else
			{
				return null;
			}
		}
	}
}
