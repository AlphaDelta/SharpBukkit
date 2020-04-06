// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ShapelessRecipes : net.minecraft.src.IRecipe
	{
		public ShapelessRecipes(net.minecraft.src.ItemStack itemstack, System.Collections.IList
			 list)
		{
			// Referenced classes of package net.minecraft.src:
			//            IRecipe, InventoryCrafting, ItemStack
			field_21138_a = itemstack;
			field_21137_b = list;
		}

		public virtual net.minecraft.src.ItemStack Func_25077_b()
		{
			return field_21138_a;
		}

		public virtual bool Func_21134_a(net.minecraft.src.InventoryCrafting inventorycrafting
			)
		{
			System.Collections.ArrayList arraylist = new System.Collections.ArrayList(field_21137_b
				);
			int i = 0;
			do
			{
				if (i >= 3)
				{
					break;
				}
				for (int j = 0; j < 3; j++)
				{
					net.minecraft.src.ItemStack itemstack = inventorycrafting.Func_21084_a(j, i);
					if (itemstack == null)
					{
						continue;
					}
					bool flag = false;
					System.Collections.IEnumerator iterator = arraylist.GetEnumerator();
					do
					{
						if (!iterator.MoveNext())
						{
							break;
						}
						net.minecraft.src.ItemStack itemstack1 = (net.minecraft.src.ItemStack)iterator.Current;
						if (itemstack.itemID != itemstack1.itemID || itemstack1.GetItemDamage() != -1 && 
							itemstack.GetItemDamage() != itemstack1.GetItemDamage())
						{
							continue;
						}
						flag = true;
						arraylist.Remove(itemstack1);
						break;
					}
					while (true);
					if (!flag)
					{
						return false;
					}
				}
				i++;
			}
			while (true);
			return arraylist.Count < 1;
		}

		public virtual net.minecraft.src.ItemStack Func_21136_b(net.minecraft.src.InventoryCrafting
			 inventorycrafting)
		{
			return field_21138_a.Copy();
		}

		public virtual int GetRecipeSize()
		{
			return field_21137_b.Count;
		}

		private readonly net.minecraft.src.ItemStack field_21138_a;

		private readonly System.Collections.IList field_21137_b;
	}
}
