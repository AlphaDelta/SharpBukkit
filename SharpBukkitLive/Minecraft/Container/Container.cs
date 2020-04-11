// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public abstract class Container
	{
		public Container()
		{
			// Referenced classes of package net.minecraft.src:
			//            Slot, ICrafting, ItemStack, EntityPlayer, 
			//            InventoryPlayer, IInventory
			inventoryItemStacks = new List<ItemStack>();
			inventorySlots = new List<Slot>();
			windowId = 0;
			field_20132_a = 0;
			crafters = new List<ICrafting>();
			field_20131_b = new HashSet<EntityPlayer>();
		}

		protected internal virtual void AddSlot(net.minecraft.src.Slot slot)
		{
			slot.id = inventorySlots.Count;
			inventorySlots.Add(slot);
			inventoryItemStacks.Add(null);
		}

		public virtual void OnCraftGuiOpened(net.minecraft.src.ICrafting icrafting)
		{
			if (crafters.Contains(icrafting))
			{
				throw new System.ArgumentException("Listener already listening");
			}
			else
			{
				crafters.Add(icrafting);
				icrafting.UpdateCraftingInventory(this, GetItemStacks());
				UpdateCraftingMatrix();
				return;
			}
		}

		public virtual List<ItemStack> GetItemStacks()
		{
			List<ItemStack> arraylist = new List<ItemStack>();
			for (int i = 0; i < inventorySlots.Count; i++)
			{
				arraylist.Add(((net.minecraft.src.Slot)inventorySlots[i]).GetStack());
			}
			return arraylist;
		}

		public virtual void UpdateCraftingMatrix()
		{
			for (int i = 0; i < inventorySlots.Count; i++)
			{
				net.minecraft.src.ItemStack itemstack = ((net.minecraft.src.Slot)inventorySlots[i
					]).GetStack();
				net.minecraft.src.ItemStack itemstack1 = (net.minecraft.src.ItemStack)inventoryItemStacks
					[i];
				if (net.minecraft.src.ItemStack.AreItemStacksEqual(itemstack1, itemstack))
				{
					continue;
				}
				itemstack1 = itemstack != null ? itemstack.Copy() : null;
				inventoryItemStacks[i] = itemstack1;
				for (int j = 0; j < crafters.Count; j++)
				{
					((net.minecraft.src.ICrafting)crafters[j]).UpdateCraftingInventorySlot(this, i, itemstack1
						);
				}
			}
		}

		public virtual net.minecraft.src.Slot Func_20127_a(net.minecraft.src.IInventory iinventory
			, int i)
		{
			for (int j = 0; j < inventorySlots.Count; j++)
			{
				net.minecraft.src.Slot slot = (net.minecraft.src.Slot)inventorySlots[j];
				if (slot.IsHere(iinventory, i))
				{
					return slot;
				}
			}
			return null;
		}

		public virtual net.minecraft.src.Slot GetSlot(int i)
		{
			return (net.minecraft.src.Slot)inventorySlots[i];
		}

		public virtual net.minecraft.src.ItemStack Func_27086_a(int i)
		{
			net.minecraft.src.Slot slot = (net.minecraft.src.Slot)inventorySlots[i];
			if (slot != null)
			{
				return slot.GetStack();
			}
			else
			{
				return null;
			}
		}

		public virtual net.minecraft.src.ItemStack Func_27085_a(int i, int j, bool flag, 
			net.minecraft.src.EntityPlayer entityplayer)
		{
			net.minecraft.src.ItemStack itemstack = null;
			if (j == 0 || j == 1)
			{
				net.minecraft.src.InventoryPlayer inventoryplayer = entityplayer.inventory;
				if (i == -999)
				{
					if (inventoryplayer.GetItemStack() != null && i == -999)
					{
						if (j == 0)
						{
							entityplayer.DropPlayerItem(inventoryplayer.GetItemStack());
							inventoryplayer.SetItemStack(null);
						}
						if (j == 1)
						{
							entityplayer.DropPlayerItem(inventoryplayer.GetItemStack().SplitStack(1));
							if (inventoryplayer.GetItemStack().stackSize == 0)
							{
								inventoryplayer.SetItemStack(null);
							}
						}
					}
				}
				else
				{
					if (flag)
					{
						net.minecraft.src.ItemStack itemstack1 = Func_27086_a(i);
						if (itemstack1 != null)
						{
							int k = itemstack1.stackSize;
							itemstack = itemstack1.Copy();
							net.minecraft.src.Slot slot1 = (net.minecraft.src.Slot)inventorySlots[i];
							if (slot1 != null && slot1.GetStack() != null)
							{
								int l = slot1.GetStack().stackSize;
								if (l < k)
								{
									Func_27085_a(i, j, flag, entityplayer);
								}
							}
						}
					}
					else
					{
						net.minecraft.src.Slot slot = (net.minecraft.src.Slot)inventorySlots[i];
						if (slot != null)
						{
							slot.OnSlotChanged();
							net.minecraft.src.ItemStack itemstack2 = slot.GetStack();
							net.minecraft.src.ItemStack itemstack3 = inventoryplayer.GetItemStack();
							if (itemstack2 != null)
							{
								itemstack = itemstack2.Copy();
							}
							if (itemstack2 == null)
							{
								if (itemstack3 != null && slot.IsItemValid(itemstack3))
								{
									int i1 = j != 0 ? 1 : itemstack3.stackSize;
									if (i1 > slot.GetSlotStackLimit())
									{
										i1 = slot.GetSlotStackLimit();
									}
									slot.PutStack(itemstack3.SplitStack(i1));
									if (itemstack3.stackSize == 0)
									{
										inventoryplayer.SetItemStack(null);
									}
								}
							}
							else
							{
								if (itemstack3 == null)
								{
									int j1 = j != 0 ? (itemstack2.stackSize + 1) / 2 : itemstack2.stackSize;
									net.minecraft.src.ItemStack itemstack5 = slot.DecrStackSize(j1);
									inventoryplayer.SetItemStack(itemstack5);
									if (itemstack2.stackSize == 0)
									{
										slot.PutStack(null);
									}
									slot.OnPickupFromSlot(inventoryplayer.GetItemStack());
								}
								else
								{
									if (slot.IsItemValid(itemstack3))
									{
										if (itemstack2.itemID != itemstack3.itemID || itemstack2.GetHasSubtypes() && itemstack2
											.GetItemDamage() != itemstack3.GetItemDamage())
										{
											if (itemstack3.stackSize <= slot.GetSlotStackLimit())
											{
												net.minecraft.src.ItemStack itemstack4 = itemstack2;
												slot.PutStack(itemstack3);
												inventoryplayer.SetItemStack(itemstack4);
											}
										}
										else
										{
											int k1 = j != 0 ? 1 : itemstack3.stackSize;
											if (k1 > slot.GetSlotStackLimit() - itemstack2.stackSize)
											{
												k1 = slot.GetSlotStackLimit() - itemstack2.stackSize;
											}
											if (k1 > itemstack3.GetMaxStackSize() - itemstack2.stackSize)
											{
												k1 = itemstack3.GetMaxStackSize() - itemstack2.stackSize;
											}
											itemstack3.SplitStack(k1);
											if (itemstack3.stackSize == 0)
											{
												inventoryplayer.SetItemStack(null);
											}
											itemstack2.stackSize += k1;
										}
									}
									else
									{
										if (itemstack2.itemID == itemstack3.itemID && itemstack3.GetMaxStackSize() > 1 &&
											 (!itemstack2.GetHasSubtypes() || itemstack2.GetItemDamage() == itemstack3.GetItemDamage
											()))
										{
											int l1 = itemstack2.stackSize;
											if (l1 > 0 && l1 + itemstack3.stackSize <= itemstack3.GetMaxStackSize())
											{
												itemstack3.stackSize += l1;
												itemstack2.SplitStack(l1);
												if (itemstack2.stackSize == 0)
												{
													slot.PutStack(null);
												}
												slot.OnPickupFromSlot(inventoryplayer.GetItemStack());
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return itemstack;
		}

		public virtual void OnCraftGuiClosed(net.minecraft.src.EntityPlayer entityplayer)
		{
			net.minecraft.src.InventoryPlayer inventoryplayer = entityplayer.inventory;
			if (inventoryplayer.GetItemStack() != null)
			{
				entityplayer.DropPlayerItem(inventoryplayer.GetItemStack());
				inventoryplayer.SetItemStack(null);
			}
		}

		public virtual void OnCraftMatrixChanged(net.minecraft.src.IInventory iinventory)
		{
			UpdateCraftingMatrix();
		}

		public virtual bool GetCanCraft(net.minecraft.src.EntityPlayer entityplayer)
		{
			return !field_20131_b.Contains(entityplayer);
		}

		public virtual void SetCanCraft(net.minecraft.src.EntityPlayer entityplayer, bool
			 flag)
		{
			if (flag)
			{
				field_20131_b.Remove(entityplayer);
			}
			else
			{
				field_20131_b.Add(entityplayer);
			}
		}

		public abstract bool CanInteractWith(net.minecraft.src.EntityPlayer entityplayer);

		protected internal virtual void Func_28126_a(net.minecraft.src.ItemStack itemstack
			, int i, int j, bool flag)
		{
			int k = i;
			if (flag)
			{
				k = j - 1;
			}
			if (itemstack.Func_21132_c())
			{
				while (itemstack.stackSize > 0 && (!flag && k < j || flag && k >= i))
				{
					net.minecraft.src.Slot slot = (net.minecraft.src.Slot)inventorySlots[k];
					net.minecraft.src.ItemStack itemstack1 = slot.GetStack();
					if (itemstack1 != null && itemstack1.itemID == itemstack.itemID && (!itemstack.GetHasSubtypes
						() || itemstack.GetItemDamage() == itemstack1.GetItemDamage()))
					{
						int i1 = itemstack1.stackSize + itemstack.stackSize;
						if (i1 <= itemstack.GetMaxStackSize())
						{
							itemstack.stackSize = 0;
							itemstack1.stackSize = i1;
							slot.OnSlotChanged();
						}
						else
						{
							if (itemstack1.stackSize < itemstack.GetMaxStackSize())
							{
								itemstack.stackSize -= itemstack.GetMaxStackSize() - itemstack1.stackSize;
								itemstack1.stackSize = itemstack.GetMaxStackSize();
								slot.OnSlotChanged();
							}
						}
					}
					if (flag)
					{
						k--;
					}
					else
					{
						k++;
					}
				}
			}
			if (itemstack.stackSize > 0)
			{
				int l;
				if (flag)
				{
					l = j - 1;
				}
				else
				{
					l = i;
				}
				do
				{
					if ((flag || l >= j) && (!flag || l < i))
					{
						break;
					}
					net.minecraft.src.Slot slot1 = (net.minecraft.src.Slot)inventorySlots[l];
					net.minecraft.src.ItemStack itemstack2 = slot1.GetStack();
					if (itemstack2 == null)
					{
						slot1.PutStack(itemstack.Copy());
						slot1.OnSlotChanged();
						itemstack.stackSize = 0;
						break;
					}
					if (flag)
					{
						l--;
					}
					else
					{
						l++;
					}
				}
				while (true);
			}
		}

		public List<ItemStack> inventoryItemStacks;

		public List<Slot> inventorySlots;

		public int windowId;

		private short field_20132_a;

		protected internal List<ICrafting> crafters;

		private HashSet<EntityPlayer> field_20131_b;
	}
}
