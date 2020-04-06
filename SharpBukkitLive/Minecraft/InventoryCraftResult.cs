// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class InventoryCraftResult : net.minecraft.src.IInventory
	{
		public InventoryCraftResult()
		{
			// Referenced classes of package net.minecraft.src:
			//            IInventory, ItemStack, EntityPlayer
			stackResult = new net.minecraft.src.ItemStack[1];
		}

		public virtual int GetSizeInventory()
		{
			return 1;
		}

		public virtual net.minecraft.src.ItemStack GetStackInSlot(int i)
		{
			return stackResult[i];
		}

		public virtual string GetInvName()
		{
			return "Result";
		}

		public virtual net.minecraft.src.ItemStack DecrStackSize(int i, int j)
		{
			if (stackResult[i] != null)
			{
				net.minecraft.src.ItemStack itemstack = stackResult[i];
				stackResult[i] = null;
				return itemstack;
			}
			else
			{
				return null;
			}
		}

		public virtual void SetInventorySlotContents(int i, net.minecraft.src.ItemStack itemstack
			)
		{
			stackResult[i] = itemstack;
		}

		public virtual int GetInventoryStackLimit()
		{
			return 64;
		}

		public virtual void OnInventoryChanged()
		{
		}

		public virtual bool CanInteractWith(net.minecraft.src.EntityPlayer entityplayer)
		{
			return true;
		}

		private net.minecraft.src.ItemStack[] stackResult;
	}
}
