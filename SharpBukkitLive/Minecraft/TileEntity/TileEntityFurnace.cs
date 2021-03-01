// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class TileEntityFurnace : net.minecraft.src.TileEntity, net.minecraft.src.IInventory
	{
		public TileEntityFurnace()
		{
			// Referenced classes of package net.minecraft.src:
			//            TileEntity, IInventory, ItemStack, NBTTagCompound, 
			//            NBTTagList, World, BlockFurnace, FurnaceRecipes, 
			//            Item, Block, Material, EntityPlayer
			furnaceItemStacks = new net.minecraft.src.ItemStack[3];
			furnaceBurnTime = 0;
			currentItemBurnTime = 0;
			furnaceCookTime = 0;
		}

		public virtual int GetSizeInventory()
		{
			return furnaceItemStacks.Length;
		}

		public virtual net.minecraft.src.ItemStack GetStackInSlot(int i)
		{
			return furnaceItemStacks[i];
		}

		public virtual net.minecraft.src.ItemStack DecrStackSize(int i, int j)
		{
			if (furnaceItemStacks[i] != null)
			{
				if (furnaceItemStacks[i].stackSize <= j)
				{
					net.minecraft.src.ItemStack itemstack = furnaceItemStacks[i];
					furnaceItemStacks[i] = null;
					return itemstack;
				}
				net.minecraft.src.ItemStack itemstack1 = furnaceItemStacks[i].SplitStack(j);
				if (furnaceItemStacks[i].stackSize == 0)
				{
					furnaceItemStacks[i] = null;
				}
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
			furnaceItemStacks[i] = itemstack;
			if (itemstack != null && itemstack.stackSize > GetInventoryStackLimit())
			{
				itemstack.stackSize = GetInventoryStackLimit();
			}
		}

		public virtual string GetInvName()
		{
			return "Furnace";
		}

		public override void ReadFromNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.ReadFromNBT(nbttagcompound);
			net.minecraft.src.NBTTagList nbttaglist = nbttagcompound.GetTagList("Items");
			furnaceItemStacks = new net.minecraft.src.ItemStack[GetSizeInventory()];
			for (int i = 0; i < nbttaglist.TagCount(); i++)
			{
				net.minecraft.src.NBTTagCompound nbttagcompound1 = (net.minecraft.src.NBTTagCompound
					)nbttaglist.TagAt(i);
				byte byte0 = nbttagcompound1.GetByte("Slot");
				if (byte0 >= 0 && ((sbyte)byte0) < furnaceItemStacks.Length)
				{
					furnaceItemStacks[byte0] = new net.minecraft.src.ItemStack(nbttagcompound1);
				}
			}
			furnaceBurnTime = nbttagcompound.GetShort("BurnTime");
			furnaceCookTime = nbttagcompound.GetShort("CookTime");
			currentItemBurnTime = GetItemBurnTime(furnaceItemStacks[1]);
		}

		public override void WriteToNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.WriteToNBT(nbttagcompound);
			nbttagcompound.SetShort("BurnTime", (short)furnaceBurnTime);
			nbttagcompound.SetShort("CookTime", (short)furnaceCookTime);
			net.minecraft.src.NBTTagList nbttaglist = new net.minecraft.src.NBTTagList();
			for (int i = 0; i < furnaceItemStacks.Length; i++)
			{
				if (furnaceItemStacks[i] != null)
				{
					net.minecraft.src.NBTTagCompound nbttagcompound1 = new net.minecraft.src.NBTTagCompound
						();
					nbttagcompound1.SetByte("Slot", unchecked((byte)i));
					furnaceItemStacks[i].WriteToNBT(nbttagcompound1);
					nbttaglist.SetTag(nbttagcompound1);
				}
			}
			nbttagcompound.SetTag("Items", nbttaglist);
		}

		public virtual int GetInventoryStackLimit()
		{
			return 64;
		}

		public virtual bool IsBurning()
		{
			return furnaceBurnTime > 0;
		}

		public override void UpdateEntity()
		{
			bool flag = furnaceBurnTime > 0;
			bool flag1 = false;
			if (furnaceBurnTime > 0)
			{
				furnaceBurnTime--;
			}
			if (!worldObj.singleplayerWorld)
			{
				if (furnaceBurnTime == 0 && CanSmelt())
				{
					currentItemBurnTime = furnaceBurnTime = GetItemBurnTime(furnaceItemStacks[1]);
					if (furnaceBurnTime > 0)
					{
						flag1 = true;
						if (furnaceItemStacks[1] != null)
						{
							furnaceItemStacks[1].stackSize--;
							if (furnaceItemStacks[1].stackSize == 0)
							{
								furnaceItemStacks[1] = null;
							}
						}
					}
				}
				if (IsBurning() && CanSmelt())
				{
					furnaceCookTime++;
					if (furnaceCookTime == 200)
					{
						furnaceCookTime = 0;
						SmeltItem();
						flag1 = true;
					}
				}
				else
				{
					furnaceCookTime = 0;
				}
				if (flag != (furnaceBurnTime > 0))
				{
					flag1 = true;
					net.minecraft.src.BlockFurnace.UpdateFurnaceBlockState(furnaceBurnTime > 0, worldObj
						, xCoord, yCoord, zCoord);
				}
			}
			if (flag1)
			{
				OnInventoryChanged();
			}
		}

		private bool CanSmelt()
		{
			if (furnaceItemStacks[0] == null)
			{
				return false;
			}
			net.minecraft.src.ItemStack itemstack = net.minecraft.src.FurnaceRecipes.Smelting
				().GetSmeltingResult(furnaceItemStacks[0].GetItem().shiftedIndex);
			if (itemstack == null)
			{
				return false;
			}
			if (furnaceItemStacks[2] == null)
			{
				return true;
			}
			if (!furnaceItemStacks[2].IsItemEqual(itemstack))
			{
				return false;
			}
			if (furnaceItemStacks[2].stackSize < GetInventoryStackLimit() && furnaceItemStacks
				[2].stackSize < furnaceItemStacks[2].GetMaxStackSize())
			{
				return true;
			}
			return furnaceItemStacks[2].stackSize < itemstack.GetMaxStackSize();
		}

		public virtual void SmeltItem()
		{
			if (!CanSmelt())
			{
				return;
			}
			net.minecraft.src.ItemStack itemstack = net.minecraft.src.FurnaceRecipes.Smelting
				().GetSmeltingResult(furnaceItemStacks[0].GetItem().shiftedIndex);
			if (furnaceItemStacks[2] == null)
			{
				furnaceItemStacks[2] = itemstack.Copy();
			}
			else
			{
				if (furnaceItemStacks[2].itemID == itemstack.itemID)
				{
					furnaceItemStacks[2].stackSize++;
				}
			}
			furnaceItemStacks[0].stackSize--;
			if (furnaceItemStacks[0].stackSize <= 0)
			{
				furnaceItemStacks[0] = null;
			}
		}

		private int GetItemBurnTime(net.minecraft.src.ItemStack itemstack)
		{
			if (itemstack == null)
			{
				return 0;
			}
			int i = itemstack.GetItem().shiftedIndex;
			if (i < 256 && net.minecraft.src.Block.blocksList[i].blockMaterial == net.minecraft.src.Material
				.wood)
			{
				return 300;
			}
			if (i == net.minecraft.src.Item.stick.shiftedIndex)
			{
				return 100;
			}
			if (i == net.minecraft.src.Item.coal.shiftedIndex)
			{
				return 1600;
			}
			if (i == net.minecraft.src.Item.bucketLava.shiftedIndex)
			{
				return 20000;
			}
			return i != net.minecraft.src.Block.SAPLING.blockID ? 0 : 100;
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

		private net.minecraft.src.ItemStack[] furnaceItemStacks;

		public int furnaceBurnTime;

		public int currentItemBurnTime;

		public int furnaceCookTime;
	}
}
