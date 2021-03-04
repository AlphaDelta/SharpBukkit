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
            (new RecipesTools()).AddRecipes(this);
            (new RecipesWeapons()).AddRecipes(this);
            (new RecipesIngots()).AddRecipes(this);
            (new RecipesFood()).AddRecipes(this);
            (new RecipesCrafting()).AddRecipes(this);
            (new RecipesArmor()).AddRecipes(this);
            (new RecipesDyes()).AddRecipes(this);
            AddRecipe(new ItemStack(Item.PAPER, 3), new object[] { "###", '#', Item.SUGAR_CANE });
            AddRecipe(new ItemStack(Item.BOOK, 1), new object[] { "#", "#", "#", '#', Item.PAPER });
            AddRecipe(new ItemStack(Block.FENCE, 2), new object[] { "###", "###", '#', Item.STICK });
            AddRecipe(new ItemStack(Block.JUKEBOX, 1), new object[] { "###", "#X#", "###", '#', Block.WOOD, 'X', Item.DIAMOND });
            AddRecipe(new ItemStack(Block.NOTE_BLOCK, 1), new object[] { "###", "#X#", "###", '#', Block.WOOD, 'X', Item.REDSTONE });
            AddRecipe(new ItemStack(Block.BOOKSHELF, 1), new object[] { "###", "XXX", "###", '#', Block.WOOD, 'X', Item.BOOK });
            AddRecipe(new ItemStack(Block.SNOW_BLOCK, 1), new object[] { "##", "##", '#', Item.SNOW_BALL });
            AddRecipe(new ItemStack(Block.CLAY, 1), new object[] { "##", "##", '#', Item.CLAY_BALL });
            AddRecipe(new ItemStack(Block.BRICK, 1), new object[] { "##", "##", '#', Item.CLAY_BRICK });
            AddRecipe(new ItemStack(Block.GLOWSTONE, 1), new object[] { "##", "##", '#', Item.GLOWSTONE_DUST });
            AddRecipe(new ItemStack(Block.WOOL, 1), new object[] { "##", "##", '#', Item.STRING });
            AddRecipe(new ItemStack(Block.TNT, 1), new object[] { "X#X", "#X#", "X#X", 'X', Item.SULPHUR, '#', Block.SAND });
            AddRecipe(new ItemStack(Block.STEP, 3, 3), new object[] { "###", '#', Block.COBBLESTONE });
            AddRecipe(new ItemStack(Block.STEP, 3, 0), new object[] { "###", '#', Block.STONE });
            AddRecipe(new ItemStack(Block.STEP, 3, 1), new object[] { "###", '#', Block.SANDSTONE });
            AddRecipe(new ItemStack(Block.STEP, 3, 2), new object[] { "###", '#', Block.WOOD });
            AddRecipe(new ItemStack(Block.LADDER, 2), new object[] { "# #", "###", "# #", '#', Item.STICK });
            AddRecipe(new ItemStack(Item.WOOD_DOOR, 1), new object[] { "##", "##", "##", '#', Block.WOOD });
            AddRecipe(new ItemStack(Block.TRAP_DOOR, 2), new object[] { "###", "###", '#', Block.WOOD });
            AddRecipe(new ItemStack(Item.IRON_DOOR, 1), new object[] { "##", "##", "##", '#', Item.IRON_INGOT });
            AddRecipe(new ItemStack(Item.SIGN, 1), new object[] { "###", "###", " X ", '#', Block.WOOD, 'X', Item.STICK });
            AddRecipe(new ItemStack(Item.CAKE, 1), new object[] { "AAA", "BEB", "CCC", 'A', Item.MILK_BUCKET, 'B', Item.SUGAR, 'C', Item.WHEAT, 'E', Item.EGG });
            AddRecipe(new ItemStack(Item.SUGAR, 1), new object[] { "#", '#', Item.SUGAR_CANE });
            AddRecipe(new ItemStack(Block.WOOD, 4), new object[] { "#", '#', Block.LOG });
            AddRecipe(new ItemStack(Item.STICK, 4), new object[] { "#", "#", '#', Block.WOOD });
            AddRecipe(new ItemStack(Block.TORCH, 4), new object[] { "X", "#", 'X', Item.COAL, '#', Item.STICK });
            AddRecipe(new ItemStack(Block.TORCH, 4), new object[] { "X", "#", 'X', new ItemStack(Item.COAL, 1, 1), '#', Item.STICK });
            AddRecipe(new ItemStack(Item.BOWL, 4), new object[] { "# #", " # ", '#', Block.WOOD });
            AddRecipe(new ItemStack(Block.RAILS, 16), new object[] { "X X", "X#X", "X X", 'X', Item.IRON_INGOT, '#', Item.STICK });
            AddRecipe(new ItemStack(Block.GOLDEN_RAIL, 6), new object[] { "X X", "X#X", "XRX", 'X', Item.GOLD_INGOT, 'R', Item.REDSTONE, '#', Item.STICK });
            AddRecipe(new ItemStack(Block.DETECTOR_RAIL, 6), new object[] { "X X", "X#X", "XRX", 'X', Item.IRON_INGOT, 'R', Item.REDSTONE, '#', Block.STONE_PLATE });
            AddRecipe(new ItemStack(Item.MINECART, 1), new object[] { "# #", "###", '#', Item.IRON_INGOT });
            AddRecipe(new ItemStack(Block.JACK_O_LANTERN, 1), new object[] { "A", "B", 'A', Block.PUMPKIN, 'B', Block.TORCH });
            AddRecipe(new ItemStack(Item.STORAGE_MINECART, 1), new object[] { "A", "B", 'A', Block.CHEST, 'B', Item.MINECART });
            AddRecipe(new ItemStack(Item.POWERED_MINECART, 1), new object[] { "A", "B", 'A', Block.FURNACE, 'B', Item.MINECART });
            AddRecipe(new ItemStack(Item.BOAT, 1), new object[] { "# #", "###", '#', Block.WOOD });
            AddRecipe(new ItemStack(Item.BUCKET, 1), new object[] { "# #", " # ", '#', Item.IRON_INGOT });
            AddRecipe(new ItemStack(Item.FLINT_AND_STEEL, 1), new object[] { "A ", " B", 'A', Item.IRON_INGOT, 'B', Item.FLINT });
            AddRecipe(new ItemStack(Item.BREAD, 1), new object[] { "###", '#', Item.WHEAT });
            AddRecipe(new ItemStack(Block.WOOD_STAIRS, 4), new object[] { "#  ", "## ", "###", '#', Block.WOOD });
            AddRecipe(new ItemStack(Item.FISHING_ROD, 1), new object[] { "  #", " #X", "# X", '#', Item.STICK, 'X', Item.STRING });
            AddRecipe(new ItemStack(Block.COBBLESTONE_STAIRS, 4), new object[] { "#  ", "## ", "###", '#', Block.COBBLESTONE });
            AddRecipe(new ItemStack(Item.PAINTING, 1), new object[] { "###", "#X#", "###", '#', Item.STICK, 'X', Block.WOOL });
            AddRecipe(new ItemStack(Item.GOLDEN_APPLE, 1), new object[] { "###", "#X#", "###", '#', Block.GOLD_BLOCK, 'X', Item.APPLE });
            AddRecipe(new ItemStack(Block.LEVER, 1), new object[] { "X", "#", '#', Block.COBBLESTONE, 'X', Item.STICK });
            AddRecipe(new ItemStack(Block.REDSTONE_TORCH_ON, 1), new object[] { "X", "#", '#', Item.STICK, 'X', Item.REDSTONE });
            AddRecipe(new ItemStack(Item.DIODE, 1), new object[] { "#X#", "III", '#', Block.REDSTONE_TORCH_ON, 'X', Item.REDSTONE, 'I', Block.STONE });
            AddRecipe(new ItemStack(Item.WATCH, 1), new object[] { " # ", "#X#", " # ", '#', Item.GOLD_INGOT, 'X', Item.REDSTONE });
            AddRecipe(new ItemStack(Item.COMPASS, 1), new object[] { " # ", "#X#", " # ", '#', Item.IRON_INGOT, 'X', Item.REDSTONE });
            AddRecipe(new ItemStack(Item.MAP, 1), new object[] { "###", "#X#", "###", '#', Item.PAPER, 'X', Item.COMPASS });
            AddRecipe(new ItemStack(Block.STONE_BUTTON, 1), new object[] { "#", "#", '#', Block.STONE });
            AddRecipe(new ItemStack(Block.STONE_PLATE, 1), new object[] { "##", '#', Block.STONE });
            AddRecipe(new ItemStack(Block.WOOD_PLATE, 1), new object[] { "##", '#', Block.WOOD });
            AddRecipe(new ItemStack(Block.DISPENSER, 1), new object[] { "###", "#X#", "#R#", '#', Block.COBBLESTONE, 'X', Item.BOW, 'R', Item.REDSTONE });
            AddRecipe(new ItemStack(Block.PISTON, 1), new object[] { "TTT", "#X#", "#R#", '#', Block.COBBLESTONE, 'X', Item.IRON_INGOT, 'R', Item.REDSTONE, 'T', Block.WOOD });
            AddRecipe(new ItemStack(Block.PISTON_STICKY, 1), new object[] { "S", "P", 'S', Item.SLIME_BALL, 'P', Block.PISTON });
            AddRecipe(new ItemStack(Item.BED, 1), new object[] { "###", "XXX", '#', Block.WOOL, 'X', Block.WOOD });
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
