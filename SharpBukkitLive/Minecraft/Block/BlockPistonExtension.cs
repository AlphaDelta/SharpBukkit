// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class BlockPistonExtension : net.minecraft.src.Block
	{
		public BlockPistonExtension(int i, int j)
			: base(i, j, net.minecraft.src.Material.piston)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, World, PistonBlockTextures, 
			//            BlockPistonBase, IBlockAccess, AxisAlignedBB
			field_31046_a = -1;
			SetStepSound(soundStoneFootstep);
			SetHardness(0.5F);
		}

		public override void OnBlockRemoval(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			base.OnBlockRemoval(world, i, j, k);
			int l = world.GetBlockMetadata(i, j, k);
			int j1 = net.minecraft.src.PistonBlockTextures.field_31052_a[Func_31045_b(l)];
			i += net.minecraft.src.PistonBlockTextures.field_31051_b[j1];
			j += net.minecraft.src.PistonBlockTextures.field_31054_c[j1];
			k += net.minecraft.src.PistonBlockTextures.field_31053_d[j1];
			int k1 = world.GetBlockId(i, j, k);
			if (k1 == net.minecraft.src.Block.pistonBase.blockID || k1 == net.minecraft.src.Block
				.pistonStickyBase.blockID)
			{
				int i1 = world.GetBlockMetadata(i, j, k);
				if (net.minecraft.src.BlockPistonBase.IsExtended(i1))
				{
					net.minecraft.src.Block.blocksList[k1].DropBlockAsItem(world, i, j, k, i1);
					world.SetBlockWithNotify(i, j, k, 0);
				}
			}
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			int k = Func_31045_b(j);
			if (i == k)
			{
				if (field_31046_a >= 0)
				{
					return field_31046_a;
				}
				if ((j & 8) != 0)
				{
					return blockIndexInTexture - 1;
				}
				else
				{
					return blockIndexInTexture;
				}
			}
			return i != net.minecraft.src.PistonBlockTextures.field_31052_a[k] ? 108 : 107;
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
			return false;
		}

		public override bool CanPlaceBlockOnSide(net.minecraft.src.World world, int i, int
			 j, int k, int l)
		{
			return false;
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 0;
		}

		public override void GetCollidingBoundingBoxes(net.minecraft.src.World world, int i, int j, int k, net.minecraft.src.AxisAlignedBB axisalignedbb, List<AxisAlignedBB> arraylist)
		{
			int l = world.GetBlockMetadata(i, j, k);
			switch (Func_31045_b(l))
			{
				case 0:
				{
					// '\0'
					SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 0.25F, 1.0F);
					base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
					SetBlockBounds(0.375F, 0.25F, 0.375F, 0.625F, 1.0F, 0.625F);
					base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
					break;
				}

				case 1:
				{
					// '\001'
					SetBlockBounds(0.0F, 0.75F, 0.0F, 1.0F, 1.0F, 1.0F);
					base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
					SetBlockBounds(0.375F, 0.0F, 0.375F, 0.625F, 0.75F, 0.625F);
					base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
					break;
				}

				case 2:
				{
					// '\002'
					SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 1.0F, 0.25F);
					base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
					SetBlockBounds(0.25F, 0.375F, 0.25F, 0.75F, 0.625F, 1.0F);
					base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
					break;
				}

				case 3:
				{
					// '\003'
					SetBlockBounds(0.0F, 0.0F, 0.75F, 1.0F, 1.0F, 1.0F);
					base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
					SetBlockBounds(0.25F, 0.375F, 0.0F, 0.75F, 0.625F, 0.75F);
					base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
					break;
				}

				case 4:
				{
					// '\004'
					SetBlockBounds(0.0F, 0.0F, 0.0F, 0.25F, 1.0F, 1.0F);
					base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
					SetBlockBounds(0.375F, 0.25F, 0.25F, 0.625F, 0.75F, 1.0F);
					base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
					break;
				}

				case 5:
				{
					// '\005'
					SetBlockBounds(0.75F, 0.0F, 0.0F, 1.0F, 1.0F, 1.0F);
					base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
					SetBlockBounds(0.0F, 0.375F, 0.25F, 0.75F, 0.625F, 0.75F);
					base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
					break;
				}
			}
			SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 1.0F, 1.0F);
		}

		public override void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k)
		{
			int l = iblockaccess.GetBlockMetadata(i, j, k);
			switch (Func_31045_b(l))
			{
				case 0:
				{
					// '\0'
					SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 0.25F, 1.0F);
					break;
				}

				case 1:
				{
					// '\001'
					SetBlockBounds(0.0F, 0.75F, 0.0F, 1.0F, 1.0F, 1.0F);
					break;
				}

				case 2:
				{
					// '\002'
					SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 1.0F, 0.25F);
					break;
				}

				case 3:
				{
					// '\003'
					SetBlockBounds(0.0F, 0.0F, 0.75F, 1.0F, 1.0F, 1.0F);
					break;
				}

				case 4:
				{
					// '\004'
					SetBlockBounds(0.0F, 0.0F, 0.0F, 0.25F, 1.0F, 1.0F);
					break;
				}

				case 5:
				{
					// '\005'
					SetBlockBounds(0.75F, 0.0F, 0.0F, 1.0F, 1.0F, 1.0F);
					break;
				}
			}
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			int i1 = Func_31045_b(world.GetBlockMetadata(i, j, k));
			int j1 = world.GetBlockId(i - net.minecraft.src.PistonBlockTextures.field_31051_b
				[i1], j - net.minecraft.src.PistonBlockTextures.field_31054_c[i1], k - net.minecraft.src.PistonBlockTextures
				.field_31053_d[i1]);
			if (j1 != net.minecraft.src.Block.pistonBase.blockID && j1 != net.minecraft.src.Block
				.pistonStickyBase.blockID)
			{
				world.SetBlockWithNotify(i, j, k, 0);
			}
			else
			{
				net.minecraft.src.Block.blocksList[j1].OnNeighborBlockChange(world, i - net.minecraft.src.PistonBlockTextures
					.field_31051_b[i1], j - net.minecraft.src.PistonBlockTextures.field_31054_c[i1], 
					k - net.minecraft.src.PistonBlockTextures.field_31053_d[i1], l);
			}
		}

		public static int Func_31045_b(int i)
		{
			return i & 7;
		}

		private int field_31046_a;
	}
}
