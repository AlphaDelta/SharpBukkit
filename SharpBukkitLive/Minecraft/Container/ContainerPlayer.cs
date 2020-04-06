// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ContainerPlayer : net.minecraft.src.Container
	{
		public ContainerPlayer(net.minecraft.src.InventoryPlayer inventoryplayer)
			: this(inventoryplayer, true)
		{
		}

		public ContainerPlayer(net.minecraft.src.InventoryPlayer inventoryplayer, bool flag
			)
		{
			// Referenced classes of package net.minecraft.src:
			//            Container, InventoryCrafting, InventoryCraftResult, SlotCrafting, 
			//            InventoryPlayer, Slot, SlotArmor, CraftingManager, 
			//            IInventory, EntityPlayer, ItemStack
			craftMatrix = new net.minecraft.src.InventoryCrafting(this, 2, 2);
			craftResult = new net.minecraft.src.InventoryCraftResult();
			isMP = false;
			isMP = flag;
			AddSlot(new net.minecraft.src.SlotCrafting(inventoryplayer.player, craftMatrix, craftResult
				, 0, 144, 36));
			for (int i = 0; i < 2; i++)
			{
				for (int i1 = 0; i1 < 2; i1++)
				{
					AddSlot(new net.minecraft.src.Slot(craftMatrix, i1 + i * 2, 88 + i1 * 18, 26 + i 
						* 18));
				}
			}
			for (int j = 0; j < 4; j++)
			{
				int j1 = j;
				AddSlot(new net.minecraft.src.SlotArmor(this, inventoryplayer, inventoryplayer.GetSizeInventory
					() - 1 - j, 8, 8 + j * 18, j1));
			}
			for (int k = 0; k < 3; k++)
			{
				for (int k1 = 0; k1 < 9; k1++)
				{
					AddSlot(new net.minecraft.src.Slot(inventoryplayer, k1 + (k + 1) * 9, 8 + k1 * 18
						, 84 + k * 18));
				}
			}
			for (int l = 0; l < 9; l++)
			{
				AddSlot(new net.minecraft.src.Slot(inventoryplayer, l, 8 + l * 18, 142));
			}
			OnCraftMatrixChanged(craftMatrix);
		}

		public override void OnCraftMatrixChanged(net.minecraft.src.IInventory iinventory
			)
		{
			craftResult.SetInventorySlotContents(0, net.minecraft.src.CraftingManager.GetInstance
				().FindMatchingRecipe(craftMatrix));
		}

		public override void OnCraftGuiClosed(net.minecraft.src.EntityPlayer entityplayer
			)
		{
			base.OnCraftGuiClosed(entityplayer);
			for (int i = 0; i < 4; i++)
			{
				net.minecraft.src.ItemStack itemstack = craftMatrix.GetStackInSlot(i);
				if (itemstack != null)
				{
					entityplayer.DropPlayerItem(itemstack);
					craftMatrix.SetInventorySlotContents(i, null);
				}
			}
		}

		public override bool CanInteractWith(net.minecraft.src.EntityPlayer entityplayer)
		{
			return true;
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
					Func_28126_a(itemstack1, 9, 45, true);
				}
				else
				{
					if (i >= 9 && i < 36)
					{
						Func_28126_a(itemstack1, 36, 45, false);
					}
					else
					{
						if (i >= 36 && i < 45)
						{
							Func_28126_a(itemstack1, 9, 36, false);
						}
						else
						{
							Func_28126_a(itemstack1, 9, 45, false);
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

		public bool isMP;
	}
}
