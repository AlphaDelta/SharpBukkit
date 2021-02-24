// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class SlotFurnace : net.minecraft.src.Slot
	{
		public SlotFurnace(net.minecraft.src.EntityPlayer entityplayer, net.minecraft.src.IInventory
			 iinventory, int i, int j, int k)
			: base(iinventory, i, j, k)
		{
			// Referenced classes of package net.minecraft.src:
			//            Slot, EntityPlayer, ItemStack, Item, 
			//            AchievementList, IInventory
			field_27007_d = entityplayer;
		}

		public override bool IsItemValid(net.minecraft.src.ItemStack itemstack)
		{
			return false;
		}

		public override void OnPickupFromSlot(net.minecraft.src.ItemStack itemstack)
		{
			itemstack.AddCraftStatistic(field_27007_d.worldObj, field_27007_d);
			if (itemstack.itemID == net.minecraft.src.Item.ingotIron.shiftedIndex)
			{
				field_27007_d.AddStat(net.minecraft.src.AchievementList.aAcquireIron, 1);
			}
			if (itemstack.itemID == net.minecraft.src.Item.fishCooked.shiftedIndex)
			{
				field_27007_d.AddStat(net.minecraft.src.AchievementList.aCookFish, 1);
			}
			base.OnPickupFromSlot(itemstack);
		}

		private net.minecraft.src.EntityPlayer field_27007_d;
	}
}
