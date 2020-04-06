// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class InventoryCrafting : net.minecraft.src.IInventory
	{
		public InventoryCrafting(net.minecraft.src.Container container, int i, int j)
		{
			// Referenced classes of package net.minecraft.src:
			//            IInventory, ItemStack, Container, EntityPlayer
			int k = i * j;
			stackList = new net.minecraft.src.ItemStack[k];
			eventHandler = container;
			field_21085_b = i;
		}

		public virtual int GetSizeInventory()
		{
			return stackList.Length;
		}

		public virtual net.minecraft.src.ItemStack GetStackInSlot(int i)
		{
			if (i >= GetSizeInventory())
			{
				return null;
			}
			else
			{
				return stackList[i];
			}
		}

		public virtual net.minecraft.src.ItemStack Func_21084_a(int i, int j)
		{
			if (i < 0 || i >= field_21085_b)
			{
				return null;
			}
			else
			{
				int k = i + j * field_21085_b;
				return GetStackInSlot(k);
			}
		}

		public virtual string GetInvName()
		{
			return "Crafting";
		}

		public virtual net.minecraft.src.ItemStack DecrStackSize(int i, int j)
		{
			if (stackList[i] != null)
			{
				if (stackList[i].stackSize <= j)
				{
					net.minecraft.src.ItemStack itemstack = stackList[i];
					stackList[i] = null;
					eventHandler.OnCraftMatrixChanged(this);
					return itemstack;
				}
				net.minecraft.src.ItemStack itemstack1 = stackList[i].SplitStack(j);
				if (stackList[i].stackSize == 0)
				{
					stackList[i] = null;
				}
				eventHandler.OnCraftMatrixChanged(this);
				return itemstack1;
			}
			else
			{
				return null;
			}
		}

		public virtual void SetInventorySlotContents(int i, net.minecraft.src.ItemStack itemstack
			)
		{
			stackList[i] = itemstack;
			eventHandler.OnCraftMatrixChanged(this);
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

		private net.minecraft.src.ItemStack[] stackList;

		private int field_21085_b;

		private net.minecraft.src.Container eventHandler;
	}
}
