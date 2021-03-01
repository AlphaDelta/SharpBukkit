// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class RecipesDyes
	{
		public RecipesDyes()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            ItemStack, Block, BlockCloth, Item, 
		//            CraftingManager
		public virtual void AddRecipes(net.minecraft.src.CraftingManager craftingmanager)
		{
			for (int i = 0; i < 16; i++)
			{
				craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block
					.WOOL, 1, net.minecraft.src.BlockCloth.Func_21034_d(i)), new object[] { new net.minecraft.src.ItemStack
					(net.minecraft.src.Item.dyePowder, 1, i), new net.minecraft.src.ItemStack(net.minecraft.src.Item
					.itemsList[net.minecraft.src.Block.WOOL.blockID], 1, 0) });
			}
			craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 2, 11), new object[] { net.minecraft.src.Block.YELLOW_FLOWER });
			craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 2, 1), new object[] { net.minecraft.src.Block.RED_ROSE });
			craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 3, 15), new object[] { net.minecraft.src.Item.bone });
			craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 2, 9), new object[] { new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 1, 1), new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder
				, 1, 15) });
			craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 2, 14), new object[] { new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 1, 1), new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder
				, 1, 11) });
			craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 2, 10), new object[] { new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 1, 2), new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder
				, 1, 15) });
			craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 2, 8), new object[] { new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 1, 0), new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder
				, 1, 15) });
			craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 2, 7), new object[] { new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 1, 8), new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder
				, 1, 15) });
			craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 3, 7), new object[] { new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 1, 0), new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder
				, 1, 15), new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder, 1, 15
				) });
			craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 2, 12), new object[] { new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 1, 4), new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder
				, 1, 15) });
			craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 2, 6), new object[] { new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 1, 4), new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder
				, 1, 2) });
			craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 2, 5), new object[] { new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 1, 4), new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder
				, 1, 1) });
			craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 2, 13), new object[] { new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 1, 5), new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder
				, 1, 9) });
			craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 3, 13), new object[] { new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 1, 4), new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder
				, 1, 1), new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder, 1, 9)
				 });
			craftingmanager.AddShapelessRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 4, 13), new object[] { new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.dyePowder, 1, 4), new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder
				, 1, 1), new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder, 1, 1)
				, new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder, 1, 15) });
		}
	}
}
