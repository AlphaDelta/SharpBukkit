// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockSnow : net.minecraft.src.Block
	{
		protected internal BlockSnow(int i, int j)
			: base(i, j, net.minecraft.src.Material.snow)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, World, AxisAlignedBB, 
			//            IBlockAccess, Item, EntityItem, ItemStack, 
			//            StatList, EntityPlayer, EnumSkyBlock
			SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 0.125F, 1.0F);
			SetTickOnLoad(true);
		}

		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			int l = world.GetBlockMetadata(i, j, k) & 7;
			if (l >= 3)
			{
				return net.minecraft.src.AxisAlignedBB.GetBoundingBoxFromPool((double)i + minX, (
					double)j + minY, (double)k + minZ, (double)i + maxX, (float)j + 0.5F, (double)k 
					+ maxZ);
			}
			else
			{
				return null;
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

		public override void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k)
		{
			int l = iblockaccess.GetBlockMetadata(i, j, k) & 7;
			float f = (float)(2 * (1 + l)) / 16F;
			SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, f, 1.0F);
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			int l = world.GetBlockId(i, j - 1, k);
			if (l == 0 || !net.minecraft.src.Block.blocksList[l].IsOpaqueCube())
			{
				return false;
			}
			else
			{
				return world.GetBlockMaterial(i, j - 1, k).GetIsSolid();
			}
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			Func_275_g(world, i, j, k);
		}

		private bool Func_275_g(net.minecraft.src.World world, int i, int j, int k)
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

		public override void HarvestBlock(net.minecraft.src.World world, net.minecraft.src.EntityPlayer
			 entityplayer, int i, int j, int k, int l)
		{
			int i1 = net.minecraft.src.Item.snowball.shiftedIndex;
			float f = 0.7F;
			double d = (double)(world.rand.NextFloat() * f) + (double)(1.0F - f) * 0.5D;
			double d1 = (double)(world.rand.NextFloat() * f) + (double)(1.0F - f) * 0.5D;
			double d2 = (double)(world.rand.NextFloat() * f) + (double)(1.0F - f) * 0.5D;
			net.minecraft.src.EntityItem entityitem = new net.minecraft.src.EntityItem(world, 
				(double)i + d, (double)j + d1, (double)k + d2, new net.minecraft.src.ItemStack(i1
				, 1, 0));
			entityitem.delayBeforeCanPickup = 10;
			world.EntityJoinedWorld(entityitem);
			world.SetBlockWithNotify(i, j, k, 0);
			entityplayer.AddStat(net.minecraft.src.StatList.StatMinedBlocks[blockID], 1);
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Item.snowball.shiftedIndex;
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 0;
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (world.GetSavedLightValue(net.minecraft.src.EnumSkyBlock.Block, i, j, k) > 11)
			{
				DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
				world.SetBlockWithNotify(i, j, k, 0);
			}
		}
	}
}
