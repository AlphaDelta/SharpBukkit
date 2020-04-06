// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public interface IRecipe
	{
		// Referenced classes of package net.minecraft.src:
		//            InventoryCrafting, ItemStack
		bool Func_21134_a(net.minecraft.src.InventoryCrafting inventorycrafting);

		net.minecraft.src.ItemStack Func_21136_b(net.minecraft.src.InventoryCrafting inventorycrafting
			);

		int GetRecipeSize();

		net.minecraft.src.ItemStack Func_25077_b();
	}
}
