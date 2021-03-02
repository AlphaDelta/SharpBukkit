// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemSoup : net.minecraft.src.ItemFood
	{
		public ItemSoup(int i, int j)
			: base(i, j, false)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            ItemFood, ItemStack, Item, World, 
		//            EntityPlayer
		public override net.minecraft.src.ItemStack OnItemRightClick(net.minecraft.src.ItemStack
			 itemstack, net.minecraft.src.World world, net.minecraft.src.EntityPlayer entityplayer
			)
		{
			base.OnItemRightClick(itemstack, world, entityplayer);
			return new net.minecraft.src.ItemStack(net.minecraft.src.Item.BOWL);
		}
	}
}
