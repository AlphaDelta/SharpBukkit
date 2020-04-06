// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemBed : net.minecraft.src.Item
	{
		public ItemBed(int i)
			: base(i)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Item, Block, BlockBed, EntityPlayer, 
		//            MathHelper, World, ItemStack
		public override bool OnItemUse(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityPlayer
			 entityplayer, net.minecraft.src.World world, int i, int j, int k, int l)
		{
			if (l != 1)
			{
				return false;
			}
			j++;
			net.minecraft.src.BlockBed blockbed = (net.minecraft.src.BlockBed)net.minecraft.src.Block
				.bed;
			int i1 = net.minecraft.src.MathHelper.Floor_double((double)((entityplayer.rotationYaw
				 * 4F) / 360F) + 0.5D) & 3;
			byte byte0 = 0;
			byte byte1 = 0;
			if (i1 == 0)
			{
				byte1 = 1;
			}
			if (i1 == 1)
			{
				byte0 = unchecked((byte)(-1));
			}
			if (i1 == 2)
			{
				byte1 = unchecked((byte)(-1));
			}
			if (i1 == 3)
			{
				byte0 = 1;
			}
			if (world.IsAirBlock(i, j, k) && world.IsAirBlock(i + byte0, j, k + byte1) && world
				.IsBlockNormalCube(i, j - 1, k) && world.IsBlockNormalCube(i + byte0, j - 1, k +
				 byte1))
			{
				world.SetBlockAndMetadataWithNotify(i, j, k, blockbed.blockID, i1);
				world.SetBlockAndMetadataWithNotify(i + byte0, j, k + byte1, blockbed.blockID, i1
					 + 8);
				itemstack.stackSize--;
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
