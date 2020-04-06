// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ContainerChest : net.minecraft.src.Container
	{
		public ContainerChest(net.minecraft.src.IInventory iinventory, net.minecraft.src.IInventory
			 iinventory1)
		{
			// Referenced classes of package net.minecraft.src:
			//            Container, IInventory, Slot, ItemStack, 
			//            EntityPlayer
			field_20137_a = iinventory1;
			field_27088_b = iinventory1.GetSizeInventory() / 9;
			int i = (field_27088_b - 4) * 18;
			for (int j = 0; j < field_27088_b; j++)
			{
				for (int i1 = 0; i1 < 9; i1++)
				{
					AddSlot(new net.minecraft.src.Slot(iinventory1, i1 + j * 9, 8 + i1 * 18, 18 + j *
						 18));
				}
			}
			for (int k = 0; k < 3; k++)
			{
				for (int j1 = 0; j1 < 9; j1++)
				{
					AddSlot(new net.minecraft.src.Slot(iinventory, j1 + k * 9 + 9, 8 + j1 * 18, 103 +
						 k * 18 + i));
				}
			}
			for (int l = 0; l < 9; l++)
			{
				AddSlot(new net.minecraft.src.Slot(iinventory, l, 8 + l * 18, 161 + i));
			}
		}

		public override bool CanInteractWith(net.minecraft.src.EntityPlayer entityplayer)
		{
			return field_20137_a.CanInteractWith(entityplayer);
		}

		public override net.minecraft.src.ItemStack Func_27086_a(int i)
		{
			net.minecraft.src.ItemStack itemstack = null;
			net.minecraft.src.Slot slot = (net.minecraft.src.Slot)inventorySlots[i];
			if (slot != null && slot.Func_27006_b())
			{
				net.minecraft.src.ItemStack itemstack1 = slot.GetStack();
				itemstack = itemstack1.Copy();
				if (i < field_27088_b * 9)
				{
					Func_28126_a(itemstack1, field_27088_b * 9, inventorySlots.Count, true);
				}
				else
				{
					Func_28126_a(itemstack1, 0, field_27088_b * 9, false);
				}
				if (itemstack1.stackSize == 0)
				{
					slot.PutStack(null);
				}
				else
				{
					slot.OnSlotChanged();
				}
			}
			return itemstack;
		}

		private net.minecraft.src.IInventory field_20137_a;

		private int field_27088_b;
	}
}
