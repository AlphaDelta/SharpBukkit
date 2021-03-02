// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System;

namespace net.minecraft.src
{
	public class BlockSign : net.minecraft.src.BlockContainer
	{
		protected internal BlockSign(int i, Type class1, bool flag)
			: base(i, net.minecraft.src.Material.wood)
		{
			// Referenced classes of package net.minecraft.src:
			//            BlockContainer, Material, IBlockAccess, TileEntity, 
			//            Item, World, AxisAlignedBB
			isFreestanding = flag;
			blockIndexInTexture = 4;
			signEntityClass = class1;
			float f = 0.25F;
			float f1 = 1.0F;
			SetBlockBounds(0.5F - f, 0.0F, 0.5F - f, 0.5F + f, f1, 0.5F + f);
		}

		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			return null;
		}

		public override void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k)
		{
			if (isFreestanding)
			{
				return;
			}
			int l = iblockaccess.GetBlockMetadata(i, j, k);
			float f = 0.28125F;
			float f1 = 0.78125F;
			float f2 = 0.0F;
			float f3 = 1.0F;
			float f4 = 0.125F;
			SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 1.0F, 1.0F);
			if (l == 2)
			{
				SetBlockBounds(f2, f, 1.0F - f4, f3, f1, 1.0F);
			}
			if (l == 3)
			{
				SetBlockBounds(f2, f, 0.0F, f3, f1, f4);
			}
			if (l == 4)
			{
				SetBlockBounds(1.0F - f4, f, f2, 1.0F, f1, f3);
			}
			if (l == 5)
			{
				SetBlockBounds(0.0F, f, f2, f4, f1, f3);
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

		protected internal override net.minecraft.src.TileEntity GetBlockEntity()
		{
			//try
			//{
				return (net.minecraft.src.TileEntity)Activator.CreateInstance(signEntityClass);//signEntityClass.NewInstance();
			//}
			//catch (System.Exception exception)
			//{
			//	throw exception;
			//}
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Item.SIGN.ID;
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			bool flag = false;
			if (isFreestanding)
			{
				if (!world.GetBlockMaterial(i, j - 1, k).IsSolid())
				{
					flag = true;
				}
			}
			else
			{
				int i1 = world.GetBlockMetadata(i, j, k);
				flag = true;
				if (i1 == 2 && world.GetBlockMaterial(i, j, k + 1).IsSolid())
				{
					flag = false;
				}
				if (i1 == 3 && world.GetBlockMaterial(i, j, k - 1).IsSolid())
				{
					flag = false;
				}
				if (i1 == 4 && world.GetBlockMaterial(i + 1, j, k).IsSolid())
				{
					flag = false;
				}
				if (i1 == 5 && world.GetBlockMaterial(i - 1, j, k).IsSolid())
				{
					flag = false;
				}
			}
			if (flag)
			{
				DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
				world.SetBlockWithNotify(i, j, k, 0);
			}
			base.OnNeighborBlockChange(world, i, j, k, l);
		}

		private Type signEntityClass;

		private bool isFreestanding;
	}
}
