// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class FurnaceRecipes
	{
		// Referenced classes of package net.minecraft.src:
		//            Block, ItemStack, Item
		public static net.minecraft.src.FurnaceRecipes Smelting()
		{
			return smeltingBase;
		}

		private FurnaceRecipes()
		{
			smeltingList = new System.Collections.Hashtable();
			AddSmelting(net.minecraft.src.Block.IRON_ORE.ID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.IRON_INGOT));
			AddSmelting(net.minecraft.src.Block.GOLD_ORE.ID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.GOLD_INGOT));
			AddSmelting(net.minecraft.src.Block.DIAMOND_ORE.ID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.DIAMOND));
			AddSmelting(net.minecraft.src.Block.SAND.ID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Block.GLASS));
			AddSmelting(net.minecraft.src.Item.PORK.ID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.GRILLED_PORK));
			AddSmelting(net.minecraft.src.Item.RAW_FISH.ID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.COOKED_FISH));
			AddSmelting(net.minecraft.src.Block.COBBLESTONE.ID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Block.STONE));
			AddSmelting(net.minecraft.src.Item.CLAY_BALL.ID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.CLAY_BRICK));
			AddSmelting(net.minecraft.src.Block.CACTUS.ID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.INK_SACK, 1, 2));
			AddSmelting(net.minecraft.src.Block.LOG.ID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.COAL, 1, 1));
		}

		public virtual void AddSmelting(int i, net.minecraft.src.ItemStack itemstack)
		{
			smeltingList[i] = itemstack;
		}

		public virtual net.minecraft.src.ItemStack GetSmeltingResult(int i)
		{
			return (net.minecraft.src.ItemStack)smeltingList[i];
		}

		public virtual System.Collections.IDictionary GetSmeltingList()
		{
			return smeltingList;
		}

		private static readonly net.minecraft.src.FurnaceRecipes smeltingBase = new net.minecraft.src.FurnaceRecipes
			();

		private System.Collections.IDictionary smeltingList;
	}
}
