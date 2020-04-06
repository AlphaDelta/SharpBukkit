// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class RecipesCrafting
	{
		public RecipesCrafting()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            ItemStack, Block, CraftingManager
		public virtual void AddRecipes(net.minecraft.src.CraftingManager craftingmanager)
		{
			craftingmanager.AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block
				.chest), new object[] { "###", "# #", "###", '#', net.minecraft.src.Block
				.planks });
			craftingmanager.AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block
				.stoneOvenIdle), new object[] { "###", "# #", "###", '#', net.minecraft.src.Block
				.cobblestone });
			craftingmanager.AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block
				.workbench), new object[] { "##", "##", '#', net.minecraft.src.Block
				.planks });
			craftingmanager.AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block
				.sandStone), new object[] { "##", "##", '#', net.minecraft.src.Block
				.sand });
		}
	}
}
