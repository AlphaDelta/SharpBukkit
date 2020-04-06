// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class TileEntityDispenser : net.minecraft.src.TileEntity, net.minecraft.src.IInventory
	{
		public TileEntityDispenser()
		{
			// Referenced classes of package net.minecraft.src:
			//            TileEntity, IInventory, ItemStack, NBTTagCompound, 
			//            NBTTagList, World, EntityPlayer
			dispenserContents = new net.minecraft.src.ItemStack[9];
			dispenserRandom = new SharpBukkitLive.SharpBukkit.SharpRandom();
		}

		public virtual int GetSizeInventory()
		{
			return 9;
		}

		public virtual net.minecraft.src.ItemStack GetStackInSlot(int i)
		{
			return dispenserContents[i];
		}

		public virtual net.minecraft.src.ItemStack DecrStackSize(int i, int j)
		{
			if (dispenserContents[i] != null)
			{
				if (dispenserContents[i].stackSize <= j)
				{
					net.minecraft.src.ItemStack itemstack = dispenserContents[i];
					dispenserContents[i] = null;
					OnInventoryChanged();
					return itemstack;
				}
				net.minecraft.src.ItemStack itemstack1 = dispenserContents[i].SplitStack(j);
				if (dispenserContents[i].stackSize == 0)
				{
					dispenserContents[i] = null;
				}
				OnInventoryChanged();
				return itemstack1;
			}
			else
			{
				return null;
			}
		}

		public virtual net.minecraft.src.ItemStack GetRandomStackFromInventory()
		{
			int i = -1;
			int j = 1;
			for (int k = 0; k < dispenserContents.Length; k++)
			{
				if (dispenserContents[k] != null && dispenserRandom.Next(j++) == 0)
				{
					i = k;
				}
			}
			if (i >= 0)
			{
				return DecrStackSize(i, 1);
			}
			else
			{
				return null;
			}
		}

		public virtual void SetInventorySlotContents(int i, net.minecraft.src.ItemStack itemstack
			)
		{
			dispenserContents[i] = itemstack;
			if (itemstack != null && itemstack.stackSize > GetInventoryStackLimit())
			{
				itemstack.stackSize = GetInventoryStackLimit();
			}
			OnInventoryChanged();
		}

		public virtual string GetInvName()
		{
			return "Trap";
		}

		public override void ReadFromNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.ReadFromNBT(nbttagcompound);
			net.minecraft.src.NBTTagList nbttaglist = nbttagcompound.GetTagList("Items");
			dispenserContents = new net.minecraft.src.ItemStack[GetSizeInventory()];
			for (int i = 0; i < nbttaglist.TagCount(); i++)
			{
				net.minecraft.src.NBTTagCompound nbttagcompound1 = (net.minecraft.src.NBTTagCompound
					)nbttaglist.TagAt(i);
				int j = nbttagcompound1.GetByte("Slot") & unchecked((int)(0xff));
				if (j >= 0 && j < dispenserContents.Length)
				{
					dispenserContents[j] = new net.minecraft.src.ItemStack(nbttagcompound1);
				}
			}
		}

		public override void WriteToNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.WriteToNBT(nbttagcompound);
			net.minecraft.src.NBTTagList nbttaglist = new net.minecraft.src.NBTTagList();
			for (int i = 0; i < dispenserContents.Length; i++)
			{
				if (dispenserContents[i] != null)
				{
					net.minecraft.src.NBTTagCompound nbttagcompound1 = new net.minecraft.src.NBTTagCompound
						();
					nbttagcompound1.SetByte("Slot", unchecked((byte)i));
					dispenserContents[i].WriteToNBT(nbttagcompound1);
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

		private net.minecraft.src.ItemStack[] dispenserContents;

		private SharpBukkitLive.SharpBukkit.SharpRandom dispenserRandom;
	}
}
