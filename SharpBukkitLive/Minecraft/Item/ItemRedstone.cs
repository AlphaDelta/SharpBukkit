// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemRedstone : net.minecraft.src.Item
	{
		public ItemRedstone(int i)
			: base(i)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Item, World, Block, ItemStack, 
		//            EntityPlayer
		public override bool OnItemUse(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityPlayer
			 entityplayer, net.minecraft.src.World world, int i, int j, int k, int l)
		{
			if (world.GetBlockId(i, j, k) != net.minecraft.src.Block.SNOW.blockID)
			{
				if (l == 0)
				{
					j--;
				}
				if (l == 1)
				{
					j++;
				}
				if (l == 2)
				{
					k--;
				}
				if (l == 3)
				{
					k++;
				}
				if (l == 4)
				{
					i--;
				}
				if (l == 5)
				{
					i++;
				}
				if (!world.IsAirBlock(i, j, k))
				{
					return false;
				}
			}
			if (net.minecraft.src.Block.REDSTONE_WIRE.CanPlaceBlockAt(world, i, j, k))
			{
				itemstack.stackSize--;
				world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.REDSTONE_WIRE.blockID);
			}
			return true;
		}
	}
}
