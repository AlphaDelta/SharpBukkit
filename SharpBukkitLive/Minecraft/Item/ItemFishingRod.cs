// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemFishingRod : net.minecraft.src.Item
	{
		public ItemFishingRod(int i)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, EntityPlayer, EntityFish, ItemStack, 
			//            World
			SetMaxDamage(64);
			SetMaxStackSize(1);
		}

		public override net.minecraft.src.ItemStack OnItemRightClick(net.minecraft.src.ItemStack
			 itemstack, net.minecraft.src.World world, net.minecraft.src.EntityPlayer entityplayer
			)
		{
			if (entityplayer.fishEntity != null)
			{
				int i = entityplayer.fishEntity.CatchFish();
				itemstack.DamageItem(i, entityplayer);
				entityplayer.SwingItem();
			}
			else
			{
				world.PlaySoundAtEntity(entityplayer, "random.bow", 0.5F, 0.4F / (itemRand.NextFloat
					() * 0.4F + 0.8F));
				if (!world.singleplayerWorld)
				{
					world.AddEntity(new net.minecraft.src.EntityFish(world, entityplayer));
				}
				entityplayer.SwingItem();
			}
			return itemstack;
		}
	}
}
