// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class CraftingManager
	{
		// Referenced classes of package net.minecraft.src:
		//            RecipesTools, RecipesWeapons, RecipesIngots, RecipesFood, 
		//            RecipesCrafting, RecipesArmor, RecipesDyes, ItemStack, 
		//            Item, Block, RecipeSorter, ShapedRecipes, 
		//            ShapelessRecipes, IRecipe, InventoryCrafting
		public static net.minecraft.src.CraftingManager GetInstance()
		{
			return instance;
		}

		private CraftingManager()
		{
			recipes = new List<IRecipe>();
			(new net.minecraft.src.RecipesTools()).AddRecipes(this);
			(new net.minecraft.src.RecipesWeapons()).AddRecipes(this);
			(new net.minecraft.src.RecipesIngots()).AddRecipes(this);
			(new net.minecraft.src.RecipesFood()).AddRecipes(this);
			(new net.minecraft.src.RecipesCrafting()).AddRecipes(this);
			(new net.minecraft.src.RecipesArmor()).AddRecipes(this);
			(new net.minecraft.src.RecipesDyes()).AddRecipes(this);
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.paper, 3), new object
				[] { "###", '#', net.minecraft.src.Item.reed });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.book, 1), new object
				[] { "#", "#", "#", '#', net.minecraft.src.Item.paper });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.fence, 2), new 
				object[] { "###", "###", '#', net.minecraft.src.Item.stick });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.jukebox, 1), new 
				object[] { "###", "#X#", "###", '#', net.minecraft.src.Block.planks
				, 'X', net.minecraft.src.Item.diamond });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.musicBlock, 1), 
				new object[] { "###", "#X#", "###", '#', net.minecraft.src.Block.planks
				, 'X', net.minecraft.src.Item.redstone });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.bookShelf, 1), 
				new object[] { "###", "XXX", "###", '#', net.minecraft.src.Block.planks
				, 'X', net.minecraft.src.Item.book });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.blockSnow, 1), 
				new object[] { "##", "##", '#', net.minecraft.src.Item.snowball });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.blockClay, 1), 
				new object[] { "##", "##", '#', net.minecraft.src.Item.clay });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.brick, 1), new 
				object[] { "##", "##", '#', net.minecraft.src.Item.brick });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.glowStone, 1), 
				new object[] { "##", "##", '#', net.minecraft.src.Item.lightStoneDust
				 });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.cloth, 1), new 
				object[] { "##", "##", '#', net.minecraft.src.Item.silk });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.tnt, 1), new object
				[] { "X#X", "#X#", "X#X", 'X', net.minecraft.src.Item.gunpowder, '#', net.minecraft.src.Block.sand });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.stairSingle, 3, 
				3), new object[] { "###", '#', net.minecraft.src.Block.cobblestone
				 });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.stairSingle, 3, 
				0), new object[] { "###", '#', net.minecraft.src.Block.stone });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.stairSingle, 3, 
				1), new object[] { "###", '#', net.minecraft.src.Block.sandStone }
				);
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.stairSingle, 3, 
				2), new object[] { "###", '#', net.minecraft.src.Block.planks });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.ladder, 2), new 
				object[] { "# #", "###", "# #", '#', net.minecraft.src.Item.stick }
				);
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.doorWood, 1), new 
				object[] { "##", "##", "##", '#', net.minecraft.src.Block.planks }
				);
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.trapdoor, 2), new 
				object[] { "###", "###", '#', net.minecraft.src.Block.planks });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.doorSteel, 1), new 
				object[] { "##", "##", "##", '#', net.minecraft.src.Item.ingotIron
				 });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.sign, 1), new object
				[] { "###", "###", " X ", '#', net.minecraft.src.Block.planks, 'X', net.minecraft.src.Item.stick });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.cake, 1), new object
				[] { "AAA", "BEB", "CCC", 'A', net.minecraft.src.Item.bucketMilk, 
				'B', net.minecraft.src.Item.sugar, 'C', net.minecraft.src.Item
				.wheat, 'E', net.minecraft.src.Item.egg });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.sugar, 1), new object
				[] { "#", '#', net.minecraft.src.Item.reed });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.planks, 4), new 
				object[] { "#", '#', net.minecraft.src.Block.wood });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.stick, 4), new object
				[] { "#", "#", '#', net.minecraft.src.Block.planks });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.torchWood, 4), 
				new object[] { "X", "#", 'X', net.minecraft.src.Item.coal, '#', net.minecraft.src.Item.stick });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.torchWood, 4), 
				new object[] { "X", "#", 'X', new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.coal, 1, 1), '#', net.minecraft.src.Item.stick });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.bowlEmpty, 4), new 
				object[] { "# #", " # ", '#', net.minecraft.src.Block.planks });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.minecartTrack, 
				16), new object[] { "X X", "X#X", "X X", 'X', net.minecraft.src.Item
				.ingotIron, '#', net.minecraft.src.Item.stick });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.railPowered, 6)
				, new object[] { "X X", "X#X", "XRX", 'X', net.minecraft.src.Item.
				ingotGold, 'R', net.minecraft.src.Item.redstone, '#'
				, net.minecraft.src.Item.stick });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.railDetector, 6
				), new object[] { "X X", "X#X", "XRX", 'X', net.minecraft.src.Item
				.ingotIron, 'R', net.minecraft.src.Item.redstone, '#', net.minecraft.src.Block.pressurePlateStone });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.minecartEmpty, 1
				), new object[] { "# #", "###", '#', net.minecraft.src.Item.ingotIron
				 });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.pumpkinLantern, 
				1), new object[] { "A", "B", 'A', net.minecraft.src.Block.pumpkin, 
				'B', net.minecraft.src.Block.torchWood });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.minecartCrate, 1
				), new object[] { "A", "B", 'A', net.minecraft.src.Block.chest, 'B', net.minecraft.src.Item.minecartEmpty });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.minecartPowered, 
				1), new object[] { "A", "B", 'A', net.minecraft.src.Block.stoneOvenIdle
				, 'B', net.minecraft.src.Item.minecartEmpty });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.boat, 1), new object
				[] { "# #", "###", '#', net.minecraft.src.Block.planks });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.bucketEmpty, 1), 
				new object[] { "# #", " # ", '#', net.minecraft.src.Item.ingotIron
				 });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.flintAndSteel, 1
				), new object[] { "A ", " B", 'A', net.minecraft.src.Item.ingotIron
				, 'B', net.minecraft.src.Item.flint });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.bread, 1), new object
				[] { "###", '#', net.minecraft.src.Item.wheat });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.stairCompactPlanks
				, 4), new object[] { "#  ", "## ", "###", '#', net.minecraft.src.Block
				.planks });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.fishingRod, 1), 
				new object[] { "  #", " #X", "# X", '#', net.minecraft.src.Item.stick
				, 'X', net.minecraft.src.Item.silk });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.stairCompactCobblestone
				, 4), new object[] { "#  ", "## ", "###", '#', net.minecraft.src.Block
				.cobblestone });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.painting, 1), new 
				object[] { "###", "#X#", "###", '#', net.minecraft.src.Item.stick, 
				'X', net.minecraft.src.Block.cloth });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.appleGold, 1), new 
				object[] { "###", "#X#", "###", '#', net.minecraft.src.Block.blockGold
				, 'X', net.minecraft.src.Item.appleRed });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.lever, 1), new 
				object[] { "X", "#", '#', net.minecraft.src.Block.cobblestone, 'X', net.minecraft.src.Item.stick });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.torchRedstoneActive
				, 1), new object[] { "X", "#", '#', net.minecraft.src.Item.stick, 
				'X', net.minecraft.src.Item.redstone });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.redstoneRepeater
				, 1), new object[] { "#X#", "III", '#', net.minecraft.src.Block.torchRedstoneActive
				, 'X', net.minecraft.src.Item.redstone, 'I', net.minecraft.src.Block
				.stone });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.pocketSundial, 1
				), new object[] { " # ", "#X#", " # ", '#', net.minecraft.src.Item
				.ingotGold, 'X', net.minecraft.src.Item.redstone });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.compass, 1), new 
				object[] { " # ", "#X#", " # ", '#', net.minecraft.src.Item.ingotIron
				, 'X', net.minecraft.src.Item.redstone });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.field_28021_bb, 1), new object[] { "###", "#X#", "###", '#', net.minecraft.src.Item.paper, 'X', net.minecraft.src.Item.compass });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.button, 1), new object[] { "#", "#", '#', net.minecraft.src.Block.stone });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.pressurePlateStone, 1), new object[] { "##", '#', net.minecraft.src.Block.stone });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.pressurePlatePlanks, 1), new object[] { "##", '#', net.minecraft.src.Block.planks });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.dispenser, 1), new object[] { "###", "#X#", "#R#", '#', net.minecraft.src.Block.cobblestone, 'X', net.minecraft.src.Item.bow, 'R', net.minecraft.src.Item.redstone });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.pistonBase, 1), new object[] { "TTT", "#X#", "#R#", '#', net.minecraft.src.Block.cobblestone, 'X', net.minecraft.src.Item.ingotIron, 'R', net.minecraft.src.Item.redstone, 'T', net.minecraft.src.Block.planks });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.pistonStickyBase, 1), new object[] { "S", "P", 'S', net.minecraft.src.Item.slimeBall, 'P', net.minecraft.src.Block.pistonBase });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.bed, 1), new object[] { "###", "XXX", '#', net.minecraft.src.Block.cloth, 'X', net.minecraft.src.Block.planks });
			//recipes.Sort(new net.minecraft.src.RecipeSorter(this));
			recipes.Sort(new net.minecraft.src.RecipeSorter(this));
			System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append(recipes.Count
				).Append(" recipes").ToString());
		}

		internal virtual void AddRecipe(net.minecraft.src.ItemStack itemstack, object[] aobj
			)
		{
			string s = string.Empty;
			int i = 0;
			int j = 0;
			int k = 0;
			if (aobj[i] is string[])
			{
				string[] @as = (string[])aobj[i++];
				for (int l = 0; l < @as.Length; l++)
				{
					string s2 = @as[l];
					k++;
					j = s2.Length;
					s = (new java.lang.StringBuilder()).Append(s).Append(s2).ToString();
				}
			}
			else
			{
				while (aobj[i] is string)
				{
					string s1 = (string)aobj[i++];
					k++;
					j = s1.Length;
					s = (new java.lang.StringBuilder()).Append(s).Append(s1).ToString();
				}
			}
			System.Collections.Hashtable hashmap = new System.Collections.Hashtable();
			for (; i < aobj.Length; i += 2)
			{
				char character = (char)aobj[i];
				net.minecraft.src.ItemStack itemstack1 = null;
				if (aobj[i + 1] is net.minecraft.src.Item)
				{
					itemstack1 = new net.minecraft.src.ItemStack((net.minecraft.src.Item)aobj[i + 1]);
				}
				else
				{
					if (aobj[i + 1] is net.minecraft.src.Block)
					{
						itemstack1 = new net.minecraft.src.ItemStack((net.minecraft.src.Block)aobj[i + 1]
							, 1, -1);
					}
					else
					{
						if (aobj[i + 1] is net.minecraft.src.ItemStack)
						{
							itemstack1 = (net.minecraft.src.ItemStack)aobj[i + 1];
						}
					}
				}
				hashmap[character] = itemstack1;
			}
			net.minecraft.src.ItemStack[] aitemstack = new net.minecraft.src.ItemStack[j * k]
				;
			for (int i1 = 0; i1 < j * k; i1++)
			{
				char c = s[i1];
				if (hashmap.Contains(c))
				{
					aitemstack[i1] = ((net.minecraft.src.ItemStack)hashmap[c]).Copy();
				}
				else
				{
					aitemstack[i1] = null;
				}
			}
			recipes.Add(new net.minecraft.src.ShapedRecipes(j, k, aitemstack, itemstack));
		}

		internal virtual void AddShapelessRecipe(net.minecraft.src.ItemStack itemstack, object
			[] aobj)
		{
			System.Collections.ArrayList arraylist = new System.Collections.ArrayList();
			object[] aobj1 = aobj;
			int i = aobj1.Length;
			for (int j = 0; j < i; j++)
			{
				object obj = aobj1[j];
				if (obj is net.minecraft.src.ItemStack)
				{
					arraylist.Add(((net.minecraft.src.ItemStack)obj).Copy());
					continue;
				}
				if (obj is net.minecraft.src.Item)
				{
					arraylist.Add(new net.minecraft.src.ItemStack((net.minecraft.src.Item)obj));
					continue;
				}
				if (obj is net.minecraft.src.Block)
				{
					arraylist.Add(new net.minecraft.src.ItemStack((net.minecraft.src.Block)obj));
				}
				else
				{
					throw new System.Exception("Invalid shapeless recipy!");
				}
			}
			recipes.Add(new net.minecraft.src.ShapelessRecipes(itemstack, arraylist));
		}

		public virtual net.minecraft.src.ItemStack FindMatchingRecipe(net.minecraft.src.InventoryCrafting
			 inventorycrafting)
		{
			for (int i = 0; i < recipes.Count; i++)
			{
				net.minecraft.src.IRecipe irecipe = (net.minecraft.src.IRecipe)recipes[i];
				if (irecipe.Func_21134_a(inventorycrafting))
				{
					return irecipe.Func_21136_b(inventorycrafting);
				}
			}
			return null;
		}

		public virtual System.Collections.IList GetRecipeList()
		{
			return recipes;
		}

		private static readonly net.minecraft.src.CraftingManager instance = new net.minecraft.src.CraftingManager
			();

		private List<IRecipe> recipes;
	}
}
