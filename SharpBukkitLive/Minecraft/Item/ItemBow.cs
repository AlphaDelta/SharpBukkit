// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemBow : net.minecraft.src.Item
	{
		public ItemBow(int i)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, EntityPlayer, InventoryPlayer, World, 
			//            EntityArrow, ItemStack
			maxStackSize = 1;
		}

		public override net.minecraft.src.ItemStack OnItemRightClick(net.minecraft.src.ItemStack
			 itemstack, net.minecraft.src.World world, net.minecraft.src.EntityPlayer entityplayer
			)
		{
			if (entityplayer.inventory.ConsumeInventoryItem(net.minecraft.src.Item.ARROW.ID
				))
			{
				world.PlaySoundAtEntity(entityplayer, "random.bow", 1.0F, 1.0F / (itemRand.NextFloat
					() * 0.4F + 0.8F));
				if (!world.singleplayerWorld)
				{
					world.AddEntity(new net.minecraft.src.EntityArrow(world, entityplayer));
				}
			}
			return itemstack;
		}
	}
}
