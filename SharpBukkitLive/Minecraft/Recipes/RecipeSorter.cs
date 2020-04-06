// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Diagnostics.CodeAnalysis;

namespace net.minecraft.src
{
	internal class RecipeSorter : System.Collections.Generic.IComparer<IRecipe>
	{
		internal RecipeSorter(net.minecraft.src.CraftingManager craftingmanager)
		{
			// Referenced classes of package net.minecraft.src:
			//            ShapelessRecipes, ShapedRecipes, IRecipe, CraftingManager
			//        super();
			craftingManager = craftingmanager;
		}

		public virtual int CompareRecipes(net.minecraft.src.IRecipe irecipe, net.minecraft.src.IRecipe
			 irecipe1)
		{
			if ((irecipe is net.minecraft.src.ShapelessRecipes) && (irecipe1 is net.minecraft.src.ShapedRecipes
				))
			{
				return 1;
			}
			if ((irecipe1 is net.minecraft.src.ShapelessRecipes) && (irecipe is net.minecraft.src.ShapedRecipes
				))
			{
				return -1;
			}
			if (irecipe1.GetRecipeSize() < irecipe.GetRecipeSize())
			{
				return -1;
			}
			return irecipe1.GetRecipeSize() <= irecipe.GetRecipeSize() ? 0 : 1;
		}

		public virtual int Compare(object obj, object obj1)
		{
			return CompareRecipes((net.minecraft.src.IRecipe)obj, (net.minecraft.src.IRecipe)
				obj1);
		}

		public int Compare([AllowNull] IRecipe x, [AllowNull] IRecipe y)
		{
			return CompareRecipes(x, y);
		}

		internal readonly net.minecraft.src.CraftingManager craftingManager;
 /* synthetic field */
	}
}
