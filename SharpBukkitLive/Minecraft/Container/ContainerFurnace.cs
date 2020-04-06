// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ContainerFurnace : net.minecraft.src.Container
	{
		public ContainerFurnace(net.minecraft.src.InventoryPlayer inventoryplayer, net.minecraft.src.TileEntityFurnace
			 tileentityfurnace)
		{
			// Referenced classes of package net.minecraft.src:
			//            Container, Slot, SlotFurnace, InventoryPlayer, 
			//            TileEntityFurnace, ICrafting, ItemStack, EntityPlayer
			lastCookTime = 0;
			lastBurnTime = 0;
			lastItemBurnTime = 0;
			furnace = tileentityfurnace;
			AddSlot(new net.minecraft.src.Slot(tileentityfurnace, 0, 56, 17));
			AddSlot(new net.minecraft.src.Slot(tileentityfurnace, 1, 56, 53));
			AddSlot(new net.minecraft.src.SlotFurnace(inventoryplayer.player, tileentityfurnace
				, 2, 116, 35));
			for (int i = 0; i < 3; i++)
			{
				for (int k = 0; k < 9; k++)
				{
					AddSlot(new net.minecraft.src.Slot(inventoryplayer, k + i * 9 + 9, 8 + k * 18, 84
						 + i * 18));
				}
			}
			for (int j = 0; j < 9; j++)
			{
				AddSlot(new net.minecraft.src.Slot(inventoryplayer, j, 8 + j * 18, 142));
			}
		}

		public override void OnCraftGuiOpened(net.minecraft.src.ICrafting icrafting)
		{
			base.OnCraftGuiOpened(icrafting);
			icrafting.UpdateCraftingInventoryInfo(this, 0, furnace.furnaceCookTime);
			icrafting.UpdateCraftingInventoryInfo(this, 1, furnace.furnaceBurnTime);
			icrafting.UpdateCraftingInventoryInfo(this, 2, furnace.currentItemBurnTime);
		}

		public override void UpdateCraftingMatrix()
		{
			base.UpdateCraftingMatrix();
			for (int i = 0; i < crafters.Count; i++)
			{
				net.minecraft.src.ICrafting icrafting = (net.minecraft.src.ICrafting)crafters[i];
				if (lastCookTime != furnace.furnaceCookTime)
				{
					icrafting.UpdateCraftingInventoryInfo(this, 0, furnace.furnaceCookTime);
				}
				if (lastBurnTime != furnace.furnaceBurnTime)
				{
					icrafting.UpdateCraftingInventoryInfo(this, 1, furnace.furnaceBurnTime);
				}
				if (lastItemBurnTime != furnace.currentItemBurnTime)
				{
					icrafting.UpdateCraftingInventoryInfo(this, 2, furnace.currentItemBurnTime);
				}
			}
			lastCookTime = furnace.furnaceCookTime;
			lastBurnTime = furnace.furnaceBurnTime;
			lastItemBurnTime = furnace.currentItemBurnTime;
		}

		public override bool CanInteractWith(net.minecraft.src.EntityPlayer entityplayer)
		{
			return furnace.CanInteractWith(entityplayer);
		}

		public override net.minecraft.src.ItemStack Func_27086_a(int i)
		{
			net.minecraft.src.ItemStack itemstack = null;
			net.minecraft.src.Slot slot = (net.minecraft.src.Slot)inventorySlots[i];
			if (slot != null && slot.Func_27006_b())
			{
				net.minecraft.src.ItemStack itemstack1 = slot.GetStack();
				itemstack = itemstack1.Copy();
				if (i == 2)
				{
					Func_28126_a(itemstack1, 3, 39, true);
				}
				else
				{
					if (i >= 3 && i < 30)
					{
						Func_28126_a(itemstack1, 30, 39, false);
					}
					else
					{
						if (i >= 30 && i < 39)
						{
							Func_28126_a(itemstack1, 3, 30, false);
						}
						else
						{
							Func_28126_a(itemstack1, 3, 39, false);
						}
					}
				}
				if (itemstack1.stackSize == 0)
				{
					slot.PutStack(null);
				}
				else
				{
					slot.OnSlotChanged();
				}
				if (itemstack1.stackSize != itemstack.stackSize)
				{
					slot.OnPickupFromSlot(itemstack1);
				}
				else
				{
					return null;
				}
			}
			return itemstack;
		}

		private net.minecraft.src.TileEntityFurnace furnace;

		private int lastCookTime;

		private int lastBurnTime;

		private int lastItemBurnTime;
	}
}
