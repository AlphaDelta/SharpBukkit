// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockCake : net.minecraft.src.Block
	{
		protected internal BlockCake(int i, int j)
			: base(i, j, net.minecraft.src.Material.cakeMaterial)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, IBlockAccess, World, 
			//            AxisAlignedBB, EntityPlayer
			SetTickOnLoad(true);
		}

		public override void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k)
		{
			int l = iblockaccess.GetBlockMetadata(i, j, k);
			float f = 0.0625F;
			float f1 = (float)(1 + l * 2) / 16F;
			float f2 = 0.5F;
			SetBlockBounds(f1, 0.0F, f, 1.0F - f, f2, 1.0F - f);
		}

		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			int l = world.GetBlockMetadata(i, j, k);
			float f = 0.0625F;
			float f1 = (float)(1 + l * 2) / 16F;
			float f2 = 0.5F;
			return net.minecraft.src.AxisAlignedBB.GetBoundingBoxFromPool((float)i + f1, j, (
				float)k + f, (float)(i + 1) - f, ((float)j + f2) - f, (float)(k + 1) - f);
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			if (i == 1)
			{
				return blockIndexInTexture;
			}
			if (i == 0)
			{
				return blockIndexInTexture + 3;
			}
			if (j > 0 && i == 4)
			{
				return blockIndexInTexture + 2;
			}
			else
			{
				return blockIndexInTexture + 1;
			}
		}

		public override int GetBlockTextureFromSide(int i)
		{
			if (i == 1)
			{
				return blockIndexInTexture;
			}
			if (i == 0)
			{
				return blockIndexInTexture + 3;
			}
			else
			{
				return blockIndexInTexture + 1;
			}
		}

		public override bool IsACube()
		{
			return false;
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		public override bool BlockActivated(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			EatCakeSlice(world, i, j, k, entityplayer);
			return true;
		}

		public override void OnBlockClicked(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			EatCakeSlice(world, i, j, k, entityplayer);
		}

		private void EatCakeSlice(net.minecraft.src.World world, int i, int j, int k, net.minecraft.src.EntityPlayer
			 entityplayer)
		{
			if (entityplayer.health < 20)
			{
				entityplayer.Heal(3);
				int l = world.GetBlockMetadata(i, j, k) + 1;
				if (l >= 6)
				{
					world.SetBlockWithNotify(i, j, k, 0);
				}
				else
				{
					world.SetBlockMetadataWithNotify(i, j, k, l);
					world.MarkBlockAsNeedsUpdate(i, j, k);
				}
			}
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			if (!base.CanPlaceBlockAt(world, i, j, k))
			{
				return false;
			}
			else
			{
				return CanBlockStay(world, i, j, k);
			}
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
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
			return world.GetBlockMaterial(i, j - 1, k).IsSolid();
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 0;
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 0;
		}
	}
}
