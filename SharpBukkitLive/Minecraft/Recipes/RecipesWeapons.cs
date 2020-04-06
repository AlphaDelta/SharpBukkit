// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class RecipesWeapons
	{
		public RecipesWeapons()
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Item, ItemStack, CraftingManager
			recipeItems = (new object[][] { new object[] { net.minecraft.src.Block.planks, net.minecraft.src.Block
				.cobblestone, net.minecraft.src.Item.ingotIron, net.minecraft.src.Item.diamond, 
				net.minecraft.src.Item.ingotGold }, new object[] { net.minecraft.src.Item.swordWood
				, net.minecraft.src.Item.swordStone, net.minecraft.src.Item.swordSteel, net.minecraft.src.Item
				.swordDiamond, net.minecraft.src.Item.swordGold } });
		}

		public virtual void AddRecipes(net.minecraft.src.CraftingManager craftingmanager)
		{
			for (int i = 0; i < recipeItems[0].Length; i++)
			{
				object obj = recipeItems[0][i];
				for (int j = 0; j < recipeItems.Length - 1; j++)
				{
					net.minecraft.src.Item item = (net.minecraft.src.Item)recipeItems[j + 1][i];
					craftingmanager.AddRecipe(new net.minecraft.src.ItemStack(item), new object[] { recipePatterns
						[j], '#', net.minecraft.src.Item.stick, 'X', obj });
				}
			}
			craftingmanager.AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.
				bow, 1), new object[] { " #X", "# X", " #X", 'X', net.minecraft.src.Item
				.silk, '#', net.minecraft.src.Item.stick });
			craftingmanager.AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.
				arrow, 4), new object[] { "X", "#", "Y", 'Y', net.minecraft.src.Item
				.feather, 'X', net.minecraft.src.Item.flint, '#', net.minecraft.src.Item
				.stick });
		}

		private string[][] recipePatterns = new string[][] { new string[] { "X", "X", "#" }
			 };

		private object[][] recipeItems;
	}
}
