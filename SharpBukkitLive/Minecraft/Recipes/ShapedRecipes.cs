// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ShapedRecipes : net.minecraft.src.IRecipe
	{
		public ShapedRecipes(int i, int j, net.minecraft.src.ItemStack[] aitemstack, net.minecraft.src.ItemStack
			 itemstack)
		{
			// Referenced classes of package net.minecraft.src:
			//            IRecipe, ItemStack, InventoryCrafting
			field_21141_a = itemstack.itemID;
			field_21140_b = i;
			field_21144_c = j;
			field_21143_d = aitemstack;
			field_21142_e = itemstack;
		}

		public virtual net.minecraft.src.ItemStack Func_25077_b()
		{
			return field_21142_e;
		}

		public virtual bool Func_21134_a(net.minecraft.src.InventoryCrafting inventorycrafting
			)
		{
			for (int i = 0; i <= 3 - field_21140_b; i++)
			{
				for (int j = 0; j <= 3 - field_21144_c; j++)
				{
					if (Func_21139_a(inventorycrafting, i, j, true))
					{
						return true;
					}
					if (Func_21139_a(inventorycrafting, i, j, false))
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool Func_21139_a(net.minecraft.src.InventoryCrafting inventorycrafting, 
			int i, int j, bool flag)
		{
			for (int k = 0; k < 3; k++)
			{
				for (int l = 0; l < 3; l++)
				{
					int i1 = k - i;
					int j1 = l - j;
					net.minecraft.src.ItemStack itemstack = null;
					if (i1 >= 0 && j1 >= 0 && i1 < field_21140_b && j1 < field_21144_c)
					{
						if (flag)
						{
							itemstack = field_21143_d[(field_21140_b - i1 - 1) + j1 * field_21140_b];
						}
						else
						{
							itemstack = field_21143_d[i1 + j1 * field_21140_b];
						}
					}
					net.minecraft.src.ItemStack itemstack1 = inventorycrafting.Func_21084_a(k, l);
					if (itemstack1 == null && itemstack == null)
					{
						continue;
					}
					if (itemstack1 == null && itemstack != null || itemstack1 != null && itemstack ==
						 null)
					{
						return false;
					}
					if (itemstack.itemID != itemstack1.itemID)
					{
						return false;
					}
					if (itemstack.GetItemDamage() != -1 && itemstack.GetItemDamage() != itemstack1.GetItemDamage
						())
					{
						return false;
					}
				}
			}
			return true;
		}

		public virtual net.minecraft.src.ItemStack Func_21136_b(net.minecraft.src.InventoryCrafting
			 inventorycrafting)
		{
			return new net.minecraft.src.ItemStack(field_21142_e.itemID, field_21142_e.stackSize
				, field_21142_e.GetItemDamage());
		}

		public virtual int GetRecipeSize()
		{
			return field_21140_b * field_21144_c;
		}

		private int field_21140_b;

		private int field_21144_c;

		private net.minecraft.src.ItemStack[] field_21143_d;

		private net.minecraft.src.ItemStack field_21142_e;

		public readonly int field_21141_a;
	}
}
