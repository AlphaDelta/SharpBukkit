// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class RecipesArmor
	{
		public RecipesArmor()
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, Block, ItemStack, CraftingManager
			recipeItems = (new object[][] { new object[] { net.minecraft.src.Item.leather, net.minecraft.src.Block
				.fire, net.minecraft.src.Item.ingotIron, net.minecraft.src.Item.diamond, net.minecraft.src.Item
				.ingotGold }, new object[] { net.minecraft.src.Item.helmetLeather, net.minecraft.src.Item
				.helmetChain, net.minecraft.src.Item.helmetSteel, net.minecraft.src.Item.helmetDiamond
				, net.minecraft.src.Item.helmetGold }, new object[] { net.minecraft.src.Item.plateLeather
				, net.minecraft.src.Item.plateChain, net.minecraft.src.Item.plateSteel, net.minecraft.src.Item
				.plateDiamond, net.minecraft.src.Item.plateGold }, new object[] { net.minecraft.src.Item
				.legsLeather, net.minecraft.src.Item.legsChain, net.minecraft.src.Item.legsSteel
				, net.minecraft.src.Item.legsDiamond, net.minecraft.src.Item.legsGold }, new object
				[] { net.minecraft.src.Item.bootsLeather, net.minecraft.src.Item.bootsChain, net.minecraft.src.Item
				.bootsSteel, net.minecraft.src.Item.bootsDiamond, net.minecraft.src.Item.bootsGold
				 } });
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
						[j], 'X', obj });
				}
			}
		}

		private string[][] recipePatterns = new string[][] { new string[] { "XXX", "X X" }, 
			new string[] { "X X", "XXX", "XXX" }, new string[] { "XXX", "X X", "X X" }, new 
			string[] { "X X", "X X" } };

		private object[][] recipeItems;
	}
}
