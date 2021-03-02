// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class RecipesTools
	{
		public RecipesTools()
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Item, ItemStack, CraftingManager
			recipeItems = (new object[][] { new object[] { net.minecraft.src.Block.WOOD, net.minecraft.src.Block
				.COBBLESTONE, net.minecraft.src.Item.IRON_INGOT, net.minecraft.src.Item.DIAMOND, 
				net.minecraft.src.Item.GOLD_INGOT }, new object[] { net.minecraft.src.Item.WOOD_PICKAXE
				, net.minecraft.src.Item.STONE_PICKAXE, net.minecraft.src.Item.IRON_PICKAXE, net.minecraft.src.Item
				.DIAMOND_PICKAXE, net.minecraft.src.Item.GOLD_PICKAXE }, new object[] { net.minecraft.src.Item
				.WOOD_SPADE, net.minecraft.src.Item.STONE_SPADE, net.minecraft.src.Item.IRON_SPADE
				, net.minecraft.src.Item.DIAMOND_SPADE, net.minecraft.src.Item.GOLD_SHOVEL }, new 
				object[] { net.minecraft.src.Item.WOOD_AXE, net.minecraft.src.Item.STONE_AXE, net.minecraft.src.Item
				.IRON_AXE, net.minecraft.src.Item.DIAMOND_AXE, net.minecraft.src.Item.GOLD_AXE }, 
				new object[] { net.minecraft.src.Item.WOOD_HOE, net.minecraft.src.Item.STONE_HOE, 
				net.minecraft.src.Item.IRON_HOE, net.minecraft.src.Item.DIAMOND_HOE, net.minecraft.src.Item
				.GOLD_HOE } });
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
				SHEARS), new object[] { " #", "# ", '#', net.minecraft.src.Item
				.IRON_INGOT });
		}

		private string[][] recipePatterns = new string[][] { new string[] { "XXX", " # ", " # "
			 }, new string[] { "X", "#", "#" }, new string[] { "XX", "X#", " #" }, new string
			[] { "XX", " #", " #" } };

		private object[][] recipeItems;
	}
}
