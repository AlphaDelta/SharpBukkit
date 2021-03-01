// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ContainerWorkbench : net.minecraft.src.Container
	{
		public ContainerWorkbench(net.minecraft.src.InventoryPlayer inventoryplayer, net.minecraft.src.World
			 world, int i, int j, int k)
		{
			// Referenced classes of package net.minecraft.src:
			//            Container, InventoryCrafting, InventoryCraftResult, SlotCrafting, 
			//            InventoryPlayer, Slot, CraftingManager, IInventory, 
			//            World, EntityPlayer, Block, ItemStack
			craftMatrix = new net.minecraft.src.InventoryCrafting(this, 3, 3);
			craftResult = new net.minecraft.src.InventoryCraftResult();
			field_20150_c = world;
			field_20149_h = i;
			field_20148_i = j;
			field_20147_j = k;
			AddSlot(new net.minecraft.src.SlotCrafting(inventoryplayer.player, craftMatrix, craftResult
				, 0, 124, 35));
			for (int l = 0; l < 3; l++)
			{
				for (int k1 = 0; k1 < 3; k1++)
				{
					AddSlot(new net.minecraft.src.Slot(craftMatrix, k1 + l * 3, 30 + k1 * 18, 17 + l 
						* 18));
				}
			}
			for (int i1 = 0; i1 < 3; i1++)
			{
				for (int l1 = 0; l1 < 9; l1++)
				{
					AddSlot(new net.minecraft.src.Slot(inventoryplayer, l1 + i1 * 9 + 9, 8 + l1 * 18, 
						84 + i1 * 18));
				}
			}
			for (int j1 = 0; j1 < 9; j1++)
			{
				AddSlot(new net.minecraft.src.Slot(inventoryplayer, j1, 8 + j1 * 18, 142));
			}
			OnCraftMatrixChanged(craftMatrix);
		}

		public override void OnCraftMatrixChanged(net.minecraft.src.IInventory iinventory)
		{
			//TODO: Bukkit fix???
			craftResult.SetInventorySlotContents(0, net.minecraft.src.CraftingManager.GetInstance().FindMatchingRecipe(craftMatrix));
		}

		public override void OnCraftGuiClosed(net.minecraft.src.EntityPlayer entityplayer
			)
		{
			base.OnCraftGuiClosed(entityplayer);
			if (field_20150_c.singleplayerWorld)
			{
				return;
			}
			for (int i = 0; i < 9; i++)
			{
				net.minecraft.src.ItemStack itemstack = craftMatrix.GetStackInSlot(i);
				if (itemstack != null)
				{
					entityplayer.DropPlayerItem(itemstack);
				}
			}
		}

		public override bool CanInteractWith(net.minecraft.src.EntityPlayer entityplayer)
		{
			if (field_20150_c.GetBlockId(field_20149_h, field_20148_i, field_20147_j) != net.minecraft.src.Block
				.workbench.blockID)
			{
				return false;
			}
			return entityplayer.GetDistanceSq((double)field_20149_h + 0.5D, (double)field_20148_i
				 + 0.5D, (double)field_20147_j + 0.5D) <= 64D;
		}

		public override net.minecraft.src.ItemStack Func_27086_a(int i)
		{
			net.minecraft.src.ItemStack itemstack = null;
			net.minecraft.src.Slot slot = (net.minecraft.src.Slot)inventorySlots[i];
			if (slot != null && slot.Func_27006_b())
			{
				net.minecraft.src.ItemStack itemstack1 = slot.GetStack();
				itemstack = itemstack1.Copy();
				if (i == 0)
				{
					Func_28126_a(itemstack1, 10, 46, true);
				}
				else
				{
					if (i >= 10 && i < 37)
					{
						Func_28126_a(itemstack1, 37, 46, false);
					}
					else
					{
						if (i >= 37 && i < 46)
						{
							Func_28126_a(itemstack1, 10, 37, false);
						}
						else
						{
							Func_28126_a(itemstack1, 10, 46, false);
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

		public net.minecraft.src.InventoryCrafting craftMatrix;

		public net.minecraft.src.IInventory craftResult;

		private net.minecraft.src.World field_20150_c;

		private int field_20149_h;

		private int field_20148_i;

		private int field_20147_j;
	}
}
