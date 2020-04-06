// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class InventoryPlayer : net.minecraft.src.IInventory
	{
		public InventoryPlayer(net.minecraft.src.EntityPlayer entityplayer)
		{
			// Referenced classes of package net.minecraft.src:
			//            IInventory, ItemStack, EntityPlayer, NBTTagCompound, 
			//            NBTTagList, Block, Material, ItemArmor, 
			//            Entity
			mainInventory = new net.minecraft.src.ItemStack[36];
			armorInventory = new net.minecraft.src.ItemStack[4];
			currentItem = 0;
			inventoryChanged = false;
			player = entityplayer;
		}

		public virtual net.minecraft.src.ItemStack GetCurrentItem()
		{
			if (currentItem < 9 && currentItem >= 0)
			{
				return mainInventory[currentItem];
			}
			else
			{
				return null;
			}
		}

		public static int Func_25054_e()
		{
			return 9;
		}

		private int GetInventorySlotContainItem(int i)
		{
			for (int j = 0; j < mainInventory.Length; j++)
			{
				if (mainInventory[j] != null && mainInventory[j].itemID == i)
				{
					return j;
				}
			}
			return -1;
		}

		private int Func_21082_c(net.minecraft.src.ItemStack itemstack)
		{
			for (int i = 0; i < mainInventory.Length; i++)
			{
				if (mainInventory[i] != null && mainInventory[i].itemID == itemstack.itemID && mainInventory
					[i].Func_21132_c() && mainInventory[i].stackSize < mainInventory[i].GetMaxStackSize
					() && mainInventory[i].stackSize < GetInventoryStackLimit() && (!mainInventory[i
					].GetHasSubtypes() || mainInventory[i].GetItemDamage() == itemstack.GetItemDamage
					()))
				{
					return i;
				}
			}
			return -1;
		}

		private int GetFirstEmptyStack()
		{
			for (int i = 0; i < mainInventory.Length; i++)
			{
				if (mainInventory[i] == null)
				{
					return i;
				}
			}
			return -1;
		}

		private int Func_21083_d(net.minecraft.src.ItemStack itemstack)
		{
			int i = itemstack.itemID;
			int j = itemstack.stackSize;
			int k = Func_21082_c(itemstack);
			if (k < 0)
			{
				k = GetFirstEmptyStack();
			}
			if (k < 0)
			{
				return j;
			}
			if (mainInventory[k] == null)
			{
				mainInventory[k] = new net.minecraft.src.ItemStack(i, 0, itemstack.GetItemDamage(
					));
			}
			int l = j;
			if (l > mainInventory[k].GetMaxStackSize() - mainInventory[k].stackSize)
			{
				l = mainInventory[k].GetMaxStackSize() - mainInventory[k].stackSize;
			}
			if (l > GetInventoryStackLimit() - mainInventory[k].stackSize)
			{
				l = GetInventoryStackLimit() - mainInventory[k].stackSize;
			}
			if (l == 0)
			{
				return j;
			}
			else
			{
				j -= l;
				mainInventory[k].stackSize += l;
				mainInventory[k].animationsToGo = 5;
				return j;
			}
		}

		public virtual void DecrementAnimations()
		{
			for (int i = 0; i < mainInventory.Length; i++)
			{
				if (mainInventory[i] != null)
				{
					mainInventory[i].Func_28143_a(player.worldObj, player, i, currentItem == i);
				}
			}
		}

		public virtual bool ConsumeInventoryItem(int i)
		{
			int j = GetInventorySlotContainItem(i);
			if (j < 0)
			{
				return false;
			}
			if (--mainInventory[j].stackSize <= 0)
			{
				mainInventory[j] = null;
			}
			return true;
		}

		public virtual bool AddItemStackToInventory(net.minecraft.src.ItemStack itemstack
			)
		{
			if (!itemstack.IsItemDamaged())
			{
				int i;
				do
				{
					i = itemstack.stackSize;
					itemstack.stackSize = Func_21083_d(itemstack);
				}
				while (itemstack.stackSize > 0 && itemstack.stackSize < i);
				return itemstack.stackSize < i;
			}
			int j = GetFirstEmptyStack();
			if (j >= 0)
			{
				mainInventory[j] = net.minecraft.src.ItemStack.Func_20117_a(itemstack);
				mainInventory[j].animationsToGo = 5;
				itemstack.stackSize = 0;
				return true;
			}
			else
			{
				return false;
			}
		}

		public virtual net.minecraft.src.ItemStack DecrStackSize(int i, int j)
		{
			net.minecraft.src.ItemStack[] aitemstack = mainInventory;
			if (i >= mainInventory.Length)
			{
				aitemstack = armorInventory;
				i -= mainInventory.Length;
			}
			if (aitemstack[i] != null)
			{
				if (aitemstack[i].stackSize <= j)
				{
					net.minecraft.src.ItemStack itemstack = aitemstack[i];
					aitemstack[i] = null;
					return itemstack;
				}
				net.minecraft.src.ItemStack itemstack1 = aitemstack[i].SplitStack(j);
				if (aitemstack[i].stackSize == 0)
				{
					aitemstack[i] = null;
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
			net.minecraft.src.ItemStack[] aitemstack = mainInventory;
			if (i >= aitemstack.Length)
			{
				i -= aitemstack.Length;
				aitemstack = armorInventory;
			}
			aitemstack[i] = itemstack;
		}

		public virtual float GetStrVsBlock(net.minecraft.src.Block block)
		{
			float f = 1.0F;
			if (mainInventory[currentItem] != null)
			{
				f *= mainInventory[currentItem].GetStrVsBlock(block);
			}
			return f;
		}

		public virtual net.minecraft.src.NBTTagList WriteToNBT(net.minecraft.src.NBTTagList
			 nbttaglist)
		{
			for (int i = 0; i < mainInventory.Length; i++)
			{
				if (mainInventory[i] != null)
				{
					net.minecraft.src.NBTTagCompound nbttagcompound = new net.minecraft.src.NBTTagCompound
						();
					nbttagcompound.SetByte("Slot", unchecked((byte)i));
					mainInventory[i].WriteToNBT(nbttagcompound);
					nbttaglist.SetTag(nbttagcompound);
				}
			}
			for (int j = 0; j < armorInventory.Length; j++)
			{
				if (armorInventory[j] != null)
				{
					net.minecraft.src.NBTTagCompound nbttagcompound1 = new net.minecraft.src.NBTTagCompound
						();
					nbttagcompound1.SetByte("Slot", unchecked((byte)(j + 100)));
					armorInventory[j].WriteToNBT(nbttagcompound1);
					nbttaglist.SetTag(nbttagcompound1);
				}
			}
			return nbttaglist;
		}

		public virtual void ReadFromNBT(net.minecraft.src.NBTTagList nbttaglist)
		{
			mainInventory = new net.minecraft.src.ItemStack[36];
			armorInventory = new net.minecraft.src.ItemStack[4];
			for (int i = 0; i < nbttaglist.TagCount(); i++)
			{
				net.minecraft.src.NBTTagCompound nbttagcompound = (net.minecraft.src.NBTTagCompound
					)nbttaglist.TagAt(i);
				int j = nbttagcompound.GetByte("Slot") & unchecked((int)(0xff));
				net.minecraft.src.ItemStack itemstack = new net.minecraft.src.ItemStack(nbttagcompound
					);
				if (itemstack.GetItem() == null)
				{
					continue;
				}
				if (j >= 0 && j < mainInventory.Length)
				{
					mainInventory[j] = itemstack;
				}
				if (j >= 100 && j < armorInventory.Length + 100)
				{
					armorInventory[j - 100] = itemstack;
				}
			}
		}

		public virtual int GetSizeInventory()
		{
			return mainInventory.Length + 4;
		}

		public virtual net.minecraft.src.ItemStack GetStackInSlot(int i)
		{
			net.minecraft.src.ItemStack[] aitemstack = mainInventory;
			if (i >= aitemstack.Length)
			{
				i -= aitemstack.Length;
				aitemstack = armorInventory;
			}
			return aitemstack[i];
		}

		public virtual string GetInvName()
		{
			return "Inventory";
		}

		public virtual int GetInventoryStackLimit()
		{
			return 64;
		}

		public virtual int GetDamageVsEntity(net.minecraft.src.Entity entity)
		{
			net.minecraft.src.ItemStack itemstack = GetStackInSlot(currentItem);
			if (itemstack != null)
			{
				return itemstack.GetDamageVsEntity(entity);
			}
			else
			{
				return 1;
			}
		}

		public virtual bool CanHarvestBlock(net.minecraft.src.Block block)
		{
			if (block.blockMaterial.Func_31055_i())
			{
				return true;
			}
			net.minecraft.src.ItemStack itemstack = GetStackInSlot(currentItem);
			if (itemstack != null)
			{
				return itemstack.CanHarvestBlock(block);
			}
			else
			{
				return false;
			}
		}

		public virtual int GetTotalArmorValue()
		{
			int i = 0;
			int j = 0;
			int k = 0;
			for (int l = 0; l < armorInventory.Length; l++)
			{
				if (armorInventory[l] != null && (armorInventory[l].GetItem() is net.minecraft.src.ItemArmor
					))
				{
					int i1 = armorInventory[l].GetMaxDamage();
					int j1 = armorInventory[l].GetItemDamageForDisplay();
					int k1 = i1 - j1;
					j += k1;
					k += i1;
					int l1 = ((net.minecraft.src.ItemArmor)armorInventory[l].GetItem()).damageReduceAmount;
					i += l1;
				}
			}
			if (k == 0)
			{
				return 0;
			}
			else
			{
				return ((i - 1) * j) / k + 1;
			}
		}

		public virtual void DamageArmor(int i)
		{
			for (int j = 0; j < armorInventory.Length; j++)
			{
				if (armorInventory[j] == null || !(armorInventory[j].GetItem() is net.minecraft.src.ItemArmor
					))
				{
					continue;
				}
				armorInventory[j].DamageItem(i, player);
				if (armorInventory[j].stackSize == 0)
				{
					armorInventory[j].Func_577_a(player);
					armorInventory[j] = null;
				}
			}
		}

		public virtual void DropAllItems()
		{
			for (int i = 0; i < mainInventory.Length; i++)
			{
				if (mainInventory[i] != null)
				{
					player.DropPlayerItemWithRandomChoice(mainInventory[i], true);
					mainInventory[i] = null;
				}
			}
			for (int j = 0; j < armorInventory.Length; j++)
			{
				if (armorInventory[j] != null)
				{
					player.DropPlayerItemWithRandomChoice(armorInventory[j], true);
					armorInventory[j] = null;
				}
			}
		}

		public virtual void OnInventoryChanged()
		{
			inventoryChanged = true;
		}

		public virtual void SetItemStack(net.minecraft.src.ItemStack itemstack)
		{
			itemStack = itemstack;
			player.OnItemStackChanged(itemstack);
		}

		public virtual net.minecraft.src.ItemStack GetItemStack()
		{
			return itemStack;
		}

		public virtual bool CanInteractWith(net.minecraft.src.EntityPlayer entityplayer)
		{
			if (player.isDead)
			{
				return false;
			}
			return entityplayer.GetDistanceSqToEntity(player) <= 64D;
		}

		public virtual bool Func_28010_c(net.minecraft.src.ItemStack itemstack)
		{
			for (int i = 0; i < armorInventory.Length; i++)
			{
				if (armorInventory[i] != null && armorInventory[i].Func_28144_c(itemstack))
				{
					return true;
				}
			}
			for (int j = 0; j < mainInventory.Length; j++)
			{
				if (mainInventory[j] != null && mainInventory[j].Func_28144_c(itemstack))
				{
					return true;
				}
			}
			return false;
		}

		public net.minecraft.src.ItemStack[] mainInventory;

		public net.minecraft.src.ItemStack[] armorInventory;

		public int currentItem;

		public net.minecraft.src.EntityPlayer player;

		private net.minecraft.src.ItemStack itemStack;

		public bool inventoryChanged;
	}
}
