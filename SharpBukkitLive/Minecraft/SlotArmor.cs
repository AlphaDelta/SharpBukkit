// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	internal class SlotArmor : net.minecraft.src.Slot
	{
		internal SlotArmor(net.minecraft.src.ContainerPlayer containerplayer, net.minecraft.src.IInventory
			 iinventory, int i, int j, int k, int l)
			: base(iinventory, i, j, k)
		{
			// Referenced classes of package net.minecraft.src:
			//            Slot, ItemStack, ItemArmor, Item, 
			//            Block, ContainerPlayer, IInventory
			field_20101_b = containerplayer;
			field_20102_a = l;
		}

		public override int GetSlotStackLimit()
		{
			return 1;
		}

		public override bool IsItemValid(net.minecraft.src.ItemStack itemstack)
		{
			if (itemstack.GetItem() is net.minecraft.src.ItemArmor)
			{
				return ((net.minecraft.src.ItemArmor)itemstack.GetItem()).armorType == field_20102_a;
			}
			if (itemstack.GetItem().shiftedIndex == net.minecraft.src.Block.pumpkin.blockID)
			{
				return field_20102_a == 0;
			}
			else
			{
				return false;
			}
		}

		internal readonly int field_20102_a;

		internal readonly net.minecraft.src.ContainerPlayer field_20101_b;
 /* synthetic field */
 /* synthetic field */
	}
}
