// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockPumpkin : net.minecraft.src.Block
	{
		protected internal BlockPumpkin(int i, int j, bool flag)
			: base(i, net.minecraft.src.Material.pumpkin)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, World, EntityLiving, 
			//            MathHelper
			blockIndexInTexture = j;
			SetTickOnLoad(true);
			blockType = flag;
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			if (i == 1)
			{
				return blockIndexInTexture;
			}
			if (i == 0)
			{
				return blockIndexInTexture;
			}
			int k = blockIndexInTexture + 1 + 16;
			if (blockType)
			{
				k++;
			}
			if (j == 2 && i == 2)
			{
				return k;
			}
			if (j == 3 && i == 5)
			{
				return k;
			}
			if (j == 0 && i == 3)
			{
				return k;
			}
			if (j == 1 && i == 4)
			{
				return k;
			}
			else
			{
				return blockIndexInTexture + 16;
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
				return blockIndexInTexture;
			}
			if (i == 3)
			{
				return blockIndexInTexture + 1 + 16;
			}
			else
			{
				return blockIndexInTexture + 16;
			}
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			base.OnBlockAdded(world, i, j, k);
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			int l = world.GetBlockId(i, j, k);
			return (l == 0 || net.minecraft.src.Block.blocksList[l].blockMaterial.Func_27090_g
				()) && world.IsBlockNormalCube(i, j - 1, k);
		}

		public override void OnBlockPlacedBy(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityLiving entityliving)
		{
			int l = net.minecraft.src.MathHelper.Floor_double((double)((entityliving.rotationYaw
				 * 4F) / 360F) + 2.5D) & 3;
			world.SetBlockMetadataWithNotify(i, j, k, l);
		}

		private bool blockType;
	}
}
