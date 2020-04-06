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
			AddSmelting(net.minecraft.src.Block.oreIron.blockID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.ingotIron));
			AddSmelting(net.minecraft.src.Block.oreGold.blockID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.ingotGold));
			AddSmelting(net.minecraft.src.Block.oreDiamond.blockID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.diamond));
			AddSmelting(net.minecraft.src.Block.sand.blockID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Block.glass));
			AddSmelting(net.minecraft.src.Item.porkRaw.shiftedIndex, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.porkCooked));
			AddSmelting(net.minecraft.src.Item.fishRaw.shiftedIndex, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.fishCooked));
			AddSmelting(net.minecraft.src.Block.cobblestone.blockID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Block.stone));
			AddSmelting(net.minecraft.src.Item.clay.shiftedIndex, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.brick));
			AddSmelting(net.minecraft.src.Block.cactus.blockID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.dyePowder, 1, 2));
			AddSmelting(net.minecraft.src.Block.wood.blockID, new net.minecraft.src.ItemStack
				(net.minecraft.src.Item.coal, 1, 1));
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
