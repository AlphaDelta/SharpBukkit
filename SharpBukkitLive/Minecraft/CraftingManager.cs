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
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.PAPER, 3), new object
				[] { "###", '#', net.minecraft.src.Item.SUGAR_CANE });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.BOOK, 1), new object
				[] { "#", "#", "#", '#', net.minecraft.src.Item.PAPER });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.FENCE, 2), new 
				object[] { "###", "###", '#', net.minecraft.src.Item.STICK });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.JUKEBOX, 1), new 
				object[] { "###", "#X#", "###", '#', net.minecraft.src.Block.WOOD
				, 'X', net.minecraft.src.Item.DIAMOND });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.NOTE_BLOCK, 1), 
				new object[] { "###", "#X#", "###", '#', net.minecraft.src.Block.WOOD
				, 'X', net.minecraft.src.Item.REDSTONE });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.BOOKSHELF, 1), 
				new object[] { "###", "XXX", "###", '#', net.minecraft.src.Block.WOOD
				, 'X', net.minecraft.src.Item.BOOK });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.SNOW_BLOCK, 1), 
				new object[] { "##", "##", '#', net.minecraft.src.Item.SNOW_BALL });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.CLAY, 1), 
				new object[] { "##", "##", '#', net.minecraft.src.Item.CLAY_BALL });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.BRICK, 1), new 
				object[] { "##", "##", '#', net.minecraft.src.Item.CLAY_BRICK });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.GLOWSTONE, 1), 
				new object[] { "##", "##", '#', net.minecraft.src.Item.GLOWSTONE_DUST
				 });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.WOOL, 1), new 
				object[] { "##", "##", '#', net.minecraft.src.Item.STRING });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.TNT, 1), new object
				[] { "X#X", "#X#", "X#X", 'X', net.minecraft.src.Item.SULPHUR, '#', net.minecraft.src.Block.SAND });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.STEP, 3, 
				3), new object[] { "###", '#', net.minecraft.src.Block.COBBLESTONE
				 });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.STEP, 3, 
				0), new object[] { "###", '#', net.minecraft.src.Block.STONE });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.STEP, 3, 
				1), new object[] { "###", '#', net.minecraft.src.Block.SANDSTONE }
				);
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.STEP, 3, 
				2), new object[] { "###", '#', net.minecraft.src.Block.WOOD });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.LADDER, 2), new 
				object[] { "# #", "###", "# #", '#', net.minecraft.src.Item.STICK }
				);
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.WOOD_DOOR, 1), new 
				object[] { "##", "##", "##", '#', net.minecraft.src.Block.WOOD }
				);
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.TRAP_DOOR, 2), new 
				object[] { "###", "###", '#', net.minecraft.src.Block.WOOD });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.IRON_DOOR, 1), new 
				object[] { "##", "##", "##", '#', net.minecraft.src.Item.IRON_INGOT
				 });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.SIGN, 1), new object
				[] { "###", "###", " X ", '#', net.minecraft.src.Block.WOOD, 'X', net.minecraft.src.Item.STICK });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.CAKE, 1), new object
				[] { "AAA", "BEB", "CCC", 'A', net.minecraft.src.Item.MILK_BUCKET, 
				'B', net.minecraft.src.Item.SUGAR, 'C', net.minecraft.src.Item
				.WHEAT, 'E', net.minecraft.src.Item.EGG });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.SUGAR, 1), new object
				[] { "#", '#', net.minecraft.src.Item.SUGAR_CANE });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.WOOD, 4), new 
				object[] { "#", '#', net.minecraft.src.Block.LOG });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.STICK, 4), new object
				[] { "#", "#", '#', net.minecraft.src.Block.WOOD });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.TORCH, 4), 
				new object[] { "X", "#", 'X', net.minecraft.src.Item.COAL, '#', net.minecraft.src.Item.STICK });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.TORCH, 4), 
				new object[] { "X", "#", 'X', new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.COAL, 1, 1), '#', net.minecraft.src.Item.STICK });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.BOWL, 4), new 
				object[] { "# #", " # ", '#', net.minecraft.src.Block.WOOD });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.RAILS, 
				16), new object[] { "X X", "X#X", "X X", 'X', net.minecraft.src.Item
				.IRON_INGOT, '#', net.minecraft.src.Item.STICK });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.GOLDEN_RAIL, 6)
				, new object[] { "X X", "X#X", "XRX", 'X', net.minecraft.src.Item.
				GOLD_INGOT, 'R', net.minecraft.src.Item.REDSTONE, '#'
				, net.minecraft.src.Item.STICK });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.DETECTOR_RAIL, 6
				), new object[] { "X X", "X#X", "XRX", 'X', net.minecraft.src.Item
				.IRON_INGOT, 'R', net.minecraft.src.Item.REDSTONE, '#', net.minecraft.src.Block.STONE_PLATE });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.MINECART, 1
				), new object[] { "# #", "###", '#', net.minecraft.src.Item.IRON_INGOT
				 });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.JACK_O_LANTERN, 
				1), new object[] { "A", "B", 'A', net.minecraft.src.Block.PUMPKIN, 
				'B', net.minecraft.src.Block.TORCH });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.STORAGE_MINECART, 1
				), new object[] { "A", "B", 'A', net.minecraft.src.Block.CHEST, 'B', net.minecraft.src.Item.MINECART });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.POWERED_MINECART, 
				1), new object[] { "A", "B", 'A', net.minecraft.src.Block.FURNACE
				, 'B', net.minecraft.src.Item.MINECART });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.BOAT, 1), new object
				[] { "# #", "###", '#', net.minecraft.src.Block.WOOD });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.BUCKET, 1), 
				new object[] { "# #", " # ", '#', net.minecraft.src.Item.IRON_INGOT
				 });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.FLINT_AND_STEEL, 1
				), new object[] { "A ", " B", 'A', net.minecraft.src.Item.IRON_INGOT
				, 'B', net.minecraft.src.Item.FLINT });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.BREAD, 1), new object
				[] { "###", '#', net.minecraft.src.Item.WHEAT });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.WOOD_STAIRS
				, 4), new object[] { "#  ", "## ", "###", '#', net.minecraft.src.Block
				.WOOD });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.FISHING_ROD, 1), 
				new object[] { "  #", " #X", "# X", '#', net.minecraft.src.Item.STICK
				, 'X', net.minecraft.src.Item.STRING });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.COBBLESTONE_STAIRS
				, 4), new object[] { "#  ", "## ", "###", '#', net.minecraft.src.Block
				.COBBLESTONE });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.PAINTING, 1), new 
				object[] { "###", "#X#", "###", '#', net.minecraft.src.Item.STICK, 
				'X', net.minecraft.src.Block.WOOL });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.GOLDEN_APPLE, 1), new 
				object[] { "###", "#X#", "###", '#', net.minecraft.src.Block.GOLD_BLOCK
				, 'X', net.minecraft.src.Item.APPLE });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.LEVEL, 1), new 
				object[] { "X", "#", '#', net.minecraft.src.Block.COBBLESTONE, 'X', net.minecraft.src.Item.STICK });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.REDSTONE_TORCH_ON
				, 1), new object[] { "X", "#", '#', net.minecraft.src.Item.STICK, 
				'X', net.minecraft.src.Item.REDSTONE });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.DIODE
				, 1), new object[] { "#X#", "III", '#', net.minecraft.src.Block.REDSTONE_TORCH_ON
				, 'X', net.minecraft.src.Item.REDSTONE, 'I', net.minecraft.src.Block
				.STONE });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.WATCH, 1
				), new object[] { " # ", "#X#", " # ", '#', net.minecraft.src.Item
				.GOLD_INGOT, 'X', net.minecraft.src.Item.REDSTONE });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.COMPASS, 1), new 
				object[] { " # ", "#X#", " # ", '#', net.minecraft.src.Item.IRON_INGOT
				, 'X', net.minecraft.src.Item.REDSTONE });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.MAP, 1), new object[] { "###", "#X#", "###", '#', net.minecraft.src.Item.PAPER, 'X', net.minecraft.src.Item.COMPASS });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.STONE_BUTTON, 1), new object[] { "#", "#", '#', net.minecraft.src.Block.STONE });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.STONE_PLATE, 1), new object[] { "##", '#', net.minecraft.src.Block.STONE });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.WOOD_PLATE, 1), new object[] { "##", '#', net.minecraft.src.Block.WOOD });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.DISPENSER, 1), new object[] { "###", "#X#", "#R#", '#', net.minecraft.src.Block.COBBLESTONE, 'X', net.minecraft.src.Item.BOW, 'R', net.minecraft.src.Item.REDSTONE });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.PISTON, 1), new object[] { "TTT", "#X#", "#R#", '#', net.minecraft.src.Block.COBBLESTONE, 'X', net.minecraft.src.Item.IRON_INGOT, 'R', net.minecraft.src.Item.REDSTONE, 'T', net.minecraft.src.Block.WOOD });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Block.PISTON_STICKY, 1), new object[] { "S", "P", 'S', net.minecraft.src.Item.SLIME_BALL, 'P', net.minecraft.src.Block.PISTON });
			AddRecipe(new net.minecraft.src.ItemStack(net.minecraft.src.Item.BED, 1), new object[] { "###", "XXX", '#', net.minecraft.src.Block.WOOL, 'X', net.minecraft.src.Block.WOOD });
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

		internal virtual void AddShapelessRecipe(net.minecraft.src.ItemStack itemstack, object[] aobj)
		{
			List<ItemStack> arraylist = new List<ItemStack>();
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

		public virtual List<IRecipe> GetRecipeList()
		{
			return recipes;
		}

		private static readonly net.minecraft.src.CraftingManager instance = new net.minecraft.src.CraftingManager
			();

		private List<IRecipe> recipes;
	}
}
