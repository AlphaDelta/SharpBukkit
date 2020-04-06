// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Slot
	{
		public Slot(net.minecraft.src.IInventory iinventory, int i, int j, int k)
		{
			// Referenced classes of package net.minecraft.src:
			//            IInventory, ItemStack
			inventory = iinventory;
			slotIndex = i;
			xDisplayPosition = j;
			yDisplayPosition = k;
		}

		public virtual void OnPickupFromSlot(net.minecraft.src.ItemStack itemstack)
		{
			OnSlotChanged();
		}

		public virtual bool IsItemValid(net.minecraft.src.ItemStack itemstack)
		{
			return true;
		}

		public virtual net.minecraft.src.ItemStack GetStack()
		{
			return inventory.GetStackInSlot(slotIndex);
		}

		public virtual bool Func_27006_b()
		{
			return GetStack() != null;
		}

		public virtual void PutStack(net.minecraft.src.ItemStack itemstack)
		{
			inventory.SetInventorySlotContents(slotIndex, itemstack);
			OnSlotChanged();
		}

		public virtual void OnSlotChanged()
		{
			inventory.OnInventoryChanged();
		}

		public virtual int GetSlotStackLimit()
		{
			return inventory.GetInventoryStackLimit();
		}

		public virtual net.minecraft.src.ItemStack DecrStackSize(int i)
		{
			return inventory.DecrStackSize(slotIndex, i);
		}

		public virtual bool IsHere(net.minecraft.src.IInventory iinventory, int i)
		{
			return iinventory == inventory && i == slotIndex;
		}

		private readonly int slotIndex;

		private readonly net.minecraft.src.IInventory inventory;

		public int id;

		public int xDisplayPosition;

		public int yDisplayPosition;
	}
}
