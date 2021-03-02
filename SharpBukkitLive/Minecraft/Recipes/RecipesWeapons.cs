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
			recipeItems = (new object[][] { new object[] { net.minecraft.src.Block.WOOD, net.minecraft.src.Block
				.COBBLESTONE, net.minecraft.src.Item.IRON_INGOT, net.minecraft.src.Item.DIAMOND, 
				net.minecraft.src.Item.GOLD_INGOT }, new object[] { net.minecraft.src.Item.WOOD_SWORD
				, net.minecraft.src.Item.STONE_SWORD, net.minecraft.src.Item.IRON_SWORD, net.minecraft.src.Item
				.DIAMOND_SWORD, net.minecraft.src.Item.GOLD_SWORD } });
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
						[j], '#', net.minecraft.src.Item.STICK, 'X', obj });
				}
			}
			craftingmanager.AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.
				BOW, 1), new object[] { " #X", "# X", " #X", 'X', net.minecraft.src.Item
				.STRING, '#', net.minecraft.src.Item.STICK });
			craftingmanager.AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.
				ARROW, 4), new object[] { "X", "#", "Y", 'Y', net.minecraft.src.Item
				.FEATHER, 'X', net.minecraft.src.Item.FLINT, '#', net.minecraft.src.Item
				.STICK });
		}

		private string[][] recipePatterns = new string[][] { new string[] { "X", "X", "#" }
			 };

		private object[][] recipeItems;
	}
}
