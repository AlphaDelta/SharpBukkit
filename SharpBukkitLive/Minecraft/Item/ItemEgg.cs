// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemEgg : net.minecraft.src.Item
	{
		public ItemEgg(int i)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, ItemStack, World, EntityEgg, 
			//            EntityPlayer
			maxStackSize = 16;
		}

		public override net.minecraft.src.ItemStack OnItemRightClick(net.minecraft.src.ItemStack
			 itemstack, net.minecraft.src.World world, net.minecraft.src.EntityPlayer entityplayer
			)
		{
			itemstack.stackSize--;
			world.PlaySoundAtEntity(entityplayer, "random.bow", 0.5F, 0.4F / (itemRand.NextFloat
				() * 0.4F + 0.8F));
			if (!world.singleplayerWorld)
			{
				world.EntityJoinedWorld(new net.minecraft.src.EntityEgg(world, entityplayer));
			}
			return itemstack;
		}
	}
}
