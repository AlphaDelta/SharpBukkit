// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class SlotCrafting : net.minecraft.src.Slot
	{
		public SlotCrafting(net.minecraft.src.EntityPlayer entityplayer, net.minecraft.src.IInventory
			 iinventory, net.minecraft.src.IInventory iinventory1, int i, int j, int k)
			: base(iinventory1, i, j, k)
		{
			// Referenced classes of package net.minecraft.src:
			//            Slot, EntityPlayer, ItemStack, Block, 
			//            AchievementList, Item, IInventory
			field_25004_e = entityplayer;
			craftMatrix = iinventory;
		}

		public override bool IsItemValid(net.minecraft.src.ItemStack itemstack)
		{
			return false;
		}

		public override void OnPickupFromSlot(net.minecraft.src.ItemStack itemstack)
		{
			itemstack.Func_28142_b(field_25004_e.worldObj, field_25004_e);
			if (itemstack.itemID == net.minecraft.src.Block.workbench.blockID)
			{
				field_25004_e.AddStat(net.minecraft.src.AchievementList.field_25130_d, 1);
			}
			else
			{
				if (itemstack.itemID == net.minecraft.src.Item.pickaxeWood.shiftedIndex)
				{
					field_25004_e.AddStat(net.minecraft.src.AchievementList.field_27110_i, 1);
				}
				else
				{
					if (itemstack.itemID == net.minecraft.src.Block.stoneOvenIdle.blockID)
					{
						field_25004_e.AddStat(net.minecraft.src.AchievementList.field_27109_j, 1);
					}
					else
					{
						if (itemstack.itemID == net.minecraft.src.Item.hoeWood.shiftedIndex)
						{
							field_25004_e.AddStat(net.minecraft.src.AchievementList.field_27107_l, 1);
						}
						else
						{
							if (itemstack.itemID == net.minecraft.src.Item.bread.shiftedIndex)
							{
								field_25004_e.AddStat(net.minecraft.src.AchievementList.field_27106_m, 1);
							}
							else
							{
								if (itemstack.itemID == net.minecraft.src.Item.cake.shiftedIndex)
								{
									field_25004_e.AddStat(net.minecraft.src.AchievementList.field_27105_n, 1);
								}
								else
								{
									if (itemstack.itemID == net.minecraft.src.Item.pickaxeStone.shiftedIndex)
									{
										field_25004_e.AddStat(net.minecraft.src.AchievementList.field_27104_o, 1);
									}
									else
									{
										if (itemstack.itemID == net.minecraft.src.Item.swordWood.shiftedIndex)
										{
											field_25004_e.AddStat(net.minecraft.src.AchievementList.field_27101_r, 1);
										}
									}
								}
							}
						}
					}
				}
			}
			for (int i = 0; i < craftMatrix.GetSizeInventory(); i++)
			{
				net.minecraft.src.ItemStack itemstack1 = craftMatrix.GetStackInSlot(i);
				if (itemstack1 == null)
				{
					continue;
				}
				craftMatrix.DecrStackSize(i, 1);
				if (itemstack1.GetItem().HasContainerItem())
				{
					craftMatrix.SetInventorySlotContents(i, new net.minecraft.src.ItemStack(itemstack1
						.GetItem().GetContainerItem()));
				}
			}
		}

		private readonly net.minecraft.src.IInventory craftMatrix;

		private net.minecraft.src.EntityPlayer field_25004_e;
	}
}
