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
				.COBBLESTONE, net.minecraft.src.Item.ingotIron, net.minecraft.src.Item.diamond, 
				net.minecraft.src.Item.ingotGold }, new object[] { net.minecraft.src.Item.pickaxeWood
				, net.minecraft.src.Item.pickaxeStone, net.minecraft.src.Item.pickaxeSteel, net.minecraft.src.Item
				.pickaxeDiamond, net.minecraft.src.Item.pickaxeGold }, new object[] { net.minecraft.src.Item
				.shovelWood, net.minecraft.src.Item.shovelStone, net.minecraft.src.Item.shovelSteel
				, net.minecraft.src.Item.shovelDiamond, net.minecraft.src.Item.shovelGold }, new 
				object[] { net.minecraft.src.Item.axeWood, net.minecraft.src.Item.axeStone, net.minecraft.src.Item
				.axeSteel, net.minecraft.src.Item.axeDiamond, net.minecraft.src.Item.axeGold }, 
				new object[] { net.minecraft.src.Item.hoeWood, net.minecraft.src.Item.hoeStone, 
				net.minecraft.src.Item.hoeSteel, net.minecraft.src.Item.hoeDiamond, net.minecraft.src.Item
				.hoeGold } });
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
				field_31022_bc), new object[] { " #", "# ", '#', net.minecraft.src.Item
				.ingotIron });
		}

		private string[][] recipePatterns = new string[][] { new string[] { "XXX", " # ", " # "
			 }, new string[] { "X", "#", "#" }, new string[] { "XX", "X#", " #" }, new string
			[] { "XX", " #", " #" } };

		private object[][] recipeItems;
	}
}
