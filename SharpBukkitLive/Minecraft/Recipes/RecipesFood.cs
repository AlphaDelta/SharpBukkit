// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class RecipesFood
	{
		public RecipesFood()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            ItemStack, Item, Block, CraftingManager
		public virtual void AddRecipes(net.minecraft.src.CraftingManager craftingmanager)
		{
			craftingmanager.AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.
				MUSHROOM_SOUP), new object[] { "Y", "X", "#", 'X', net.minecraft.src.Block
				.BROWN_MUSHROOM, 'Y', net.minecraft.src.Block.RED_MUSHROOM, '#', net.minecraft.src.Item.BOWL });
			craftingmanager.AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.
				MUSHROOM_SOUP), new object[] { "Y", "X", "#", 'X', net.minecraft.src.Block
				.RED_MUSHROOM, 'Y', net.minecraft.src.Block.BROWN_MUSHROOM, '#', net.minecraft.src.Item.BOWL });
			craftingmanager.AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.
				COOKIE, 8), new object[] { "#X#", 'X', new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.INK_SACK, 1, 3), '#', net.minecraft.src.Item
				.WHEAT });
		}
	}
}
