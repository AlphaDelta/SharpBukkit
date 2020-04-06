// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class InventoryLargeChest : net.minecraft.src.IInventory
	{
		public InventoryLargeChest(string s, net.minecraft.src.IInventory iinventory, net.minecraft.src.IInventory
			 iinventory1)
		{
			// Referenced classes of package net.minecraft.src:
			//            IInventory, ItemStack, EntityPlayer
			name = s;
			upperChest = iinventory;
			lowerChest = iinventory1;
		}

		public virtual int GetSizeInventory()
		{
			return upperChest.GetSizeInventory() + lowerChest.GetSizeInventory();
		}

		public virtual string GetInvName()
		{
			return name;
		}

		public virtual net.minecraft.src.ItemStack GetStackInSlot(int i)
		{
			if (i >= upperChest.GetSizeInventory())
			{
				return lowerChest.GetStackInSlot(i - upperChest.GetSizeInventory());
			}
			else
			{
				return upperChest.GetStackInSlot(i);
			}
		}

		public virtual net.minecraft.src.ItemStack DecrStackSize(int i, int j)
		{
			if (i >= upperChest.GetSizeInventory())
			{
				return lowerChest.DecrStackSize(i - upperChest.GetSizeInventory(), j);
			}
			else
			{
				return upperChest.DecrStackSize(i, j);
			}
		}

		public virtual void SetInventorySlotContents(int i, net.minecraft.src.ItemStack itemstack
			)
		{
			if (i >= upperChest.GetSizeInventory())
			{
				lowerChest.SetInventorySlotContents(i - upperChest.GetSizeInventory(), itemstack);
			}
			else
			{
				upperChest.SetInventorySlotContents(i, itemstack);
			}
		}

		public virtual int GetInventoryStackLimit()
		{
			return upperChest.GetInventoryStackLimit();
		}

		public virtual void OnInventoryChanged()
		{
			upperChest.OnInventoryChanged();
			lowerChest.OnInventoryChanged();
		}

		public virtual bool CanInteractWith(net.minecraft.src.EntityPlayer entityplayer)
		{
			return upperChest.CanInteractWith(entityplayer) && lowerChest.CanInteractWith(entityplayer
				);
		}

		private string name;

		private net.minecraft.src.IInventory upperChest;

		private net.minecraft.src.IInventory lowerChest;
	}
}
