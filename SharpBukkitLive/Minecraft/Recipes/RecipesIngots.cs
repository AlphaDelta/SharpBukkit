// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class RecipesIngots
	{
		public RecipesIngots()
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, ItemStack, Item, CraftingManager
			recipeItems = (new object[][] { new object[] { net.minecraft.src.Block.GOLD_BLOCK, 
				new net.minecraft.src.ItemStack(net.minecraft.src.Item.GOLD_INGOT, 9) }, new object
				[] { net.minecraft.src.Block.IRON_BLOCK, new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.IRON_INGOT, 9) }, new object[] { net.minecraft.src.Block.DIAMOND_BLOCK, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.DIAMOND, 9) }, new object[] { net.minecraft.src.Block.LAPIS_BLOCK
				, new net.minecraft.src.ItemStack(net.minecraft.src.Item.INK_SACK, 9, 4) } });
		}

		public virtual void AddRecipes(net.minecraft.src.CraftingManager craftingmanager)
		{
			for (int i = 0; i < recipeItems.Length; i++)
			{
				net.minecraft.src.Block block = (net.minecraft.src.Block)recipeItems[i][0];
				net.minecraft.src.ItemStack itemstack = (net.minecraft.src.ItemStack)recipeItems[
					i][1];
				craftingmanager.AddRecipe(new net.minecraft.src.ItemStack(block), new object[] { 
					"###", "###", "###", '#', itemstack });
				craftingmanager.AddRecipe(itemstack, new object[] { "#", '#', block
					 });
			}
		}

		private object[][] recipeItems;
	}
}
