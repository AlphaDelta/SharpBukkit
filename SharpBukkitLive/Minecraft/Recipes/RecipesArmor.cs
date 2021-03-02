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
			recipeItems = (new object[][] { new object[] { net.minecraft.src.Item.LEATHER, net.minecraft.src.Block
				.FIRE, net.minecraft.src.Item.IRON_INGOT, net.minecraft.src.Item.DIAMOND, net.minecraft.src.Item
				.GOLD_INGOT }, new object[] { net.minecraft.src.Item.LEATHER_HELMET, net.minecraft.src.Item
				.CHAINMAIL_HELMET, net.minecraft.src.Item.IRON_HELMET, net.minecraft.src.Item.DIAMOND_HELMET
				, net.minecraft.src.Item.GOLD_HELMET }, new object[] { net.minecraft.src.Item.LEATHER_CHESTPLATE
				, net.minecraft.src.Item.CHAINMAIL_CHESTPLATE, net.minecraft.src.Item.IRON_CHESTPLATE, net.minecraft.src.Item
				.DIAMOND_CHESTPLATE, net.minecraft.src.Item.GOLD_CHESTPLATE }, new object[] { net.minecraft.src.Item
				.LEATHER_LEGGINGS, net.minecraft.src.Item.CHAINMAIL_LEGGINGS, net.minecraft.src.Item.IRON_LEGGINGS
				, net.minecraft.src.Item.DIAMOND_LEGGINGS, net.minecraft.src.Item.GOLD_LEGGINGS }, new object
				[] { net.minecraft.src.Item.LEATHER_BOOTS, net.minecraft.src.Item.CHAINMAIL_BOOTS, net.minecraft.src.Item
				.IRON_BOOTS, net.minecraft.src.Item.DIAMOND_BOOTS, net.minecraft.src.Item.GOLD_BOOTS
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
