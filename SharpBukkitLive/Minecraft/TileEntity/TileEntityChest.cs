// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class TileEntityChest : net.minecraft.src.TileEntity, net.minecraft.src.IInventory
	{
		public TileEntityChest()
		{
			// Referenced classes of package net.minecraft.src:
			//            TileEntity, IInventory, ItemStack, NBTTagCompound, 
			//            NBTTagList, World, EntityPlayer
			chestContents = new net.minecraft.src.ItemStack[36];
		}

		public virtual int GetSizeInventory()
		{
			return 27;
		}

		public virtual net.minecraft.src.ItemStack GetStackInSlot(int i)
		{
			return chestContents[i];
		}

		public virtual net.minecraft.src.ItemStack DecrStackSize(int i, int j)
		{
			if (chestContents[i] != null)
			{
				if (chestContents[i].stackSize <= j)
				{
					net.minecraft.src.ItemStack itemstack = chestContents[i];
					chestContents[i] = null;
					OnInventoryChanged();
					return itemstack;
				}
				net.minecraft.src.ItemStack itemstack1 = chestContents[i].SplitStack(j);
				if (chestContents[i].stackSize == 0)
				{
					chestContents[i] = null;
				}
				OnInventoryChanged();
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
			chestContents[i] = itemstack;
			if (itemstack != null && itemstack.stackSize > GetInventoryStackLimit())
			{
				itemstack.stackSize = GetInventoryStackLimit();
			}
			OnInventoryChanged();
		}

		public virtual string GetInvName()
		{
			return "Chest";
		}

		public override void ReadFromNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.ReadFromNBT(nbttagcompound);
			net.minecraft.src.NBTTagList nbttaglist = nbttagcompound.GetTagList("Items");
			chestContents = new net.minecraft.src.ItemStack[GetSizeInventory()];
			for (int i = 0; i < nbttaglist.TagCount(); i++)
			{
				net.minecraft.src.NBTTagCompound nbttagcompound1 = (net.minecraft.src.NBTTagCompound
					)nbttaglist.TagAt(i);
				int j = nbttagcompound1.GetByte("Slot") & 0xff;
				if (j >= 0 && j < chestContents.Length)
				{
					chestContents[j] = new net.minecraft.src.ItemStack(nbttagcompound1);
				}
			}
		}

		public override void WriteToNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.WriteToNBT(nbttagcompound);
			net.minecraft.src.NBTTagList nbttaglist = new net.minecraft.src.NBTTagList();
			for (int i = 0; i < chestContents.Length; i++)
			{
				if (chestContents[i] != null)
				{
					net.minecraft.src.NBTTagCompound nbttagcompound1 = new net.minecraft.src.NBTTagCompound
						();
					nbttagcompound1.SetByte("Slot", unchecked((byte)i));
					chestContents[i].WriteToNBT(nbttagcompound1);
					nbttaglist.SetTag(nbttagcompound1);
				}
			}
			nbttagcompound.SetTag("Items", nbttaglist);
		}

		public virtual int GetInventoryStackLimit()
		{
			return 64;
		}

		public virtual bool CanInteractWith(net.minecraft.src.EntityPlayer entityplayer)
		{
			if (worldObj.GetBlockTileEntity(xCoord, yCoord, zCoord) != this)
			{
				return false;
			}
			return entityplayer.GetDistanceSq((double)xCoord + 0.5D, (double)yCoord + 0.5D, (
				double)zCoord + 0.5D) <= 64D;
		}

		private net.minecraft.src.ItemStack[] chestContents;
	}
}
