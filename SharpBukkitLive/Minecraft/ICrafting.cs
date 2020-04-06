// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public interface ICrafting
	{
		// Referenced classes of package net.minecraft.src:
		//            Container, ItemStack
		void UpdateCraftingInventory(net.minecraft.src.Container container, System.Collections.IList
			 list);

		void UpdateCraftingInventorySlot(net.minecraft.src.Container container, int i, net.minecraft.src.ItemStack
			 itemstack);

		void UpdateCraftingInventoryInfo(net.minecraft.src.Container container, int i, int
			 j);
	}
}
