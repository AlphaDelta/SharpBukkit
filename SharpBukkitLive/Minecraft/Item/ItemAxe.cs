// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemAxe : net.minecraft.src.ItemTool
	{
		protected internal ItemAxe(int i, net.minecraft.src.EnumToolMaterial enumtoolmaterial
			)
			: base(i, 3, enumtoolmaterial, blocksEffectiveAgainst)
		{
		}

		private static net.minecraft.src.Block[] blocksEffectiveAgainst;

		static ItemAxe()
		{
			// Referenced classes of package net.minecraft.src:
			//            ItemTool, Block, EnumToolMaterial
			blocksEffectiveAgainst = (new net.minecraft.src.Block[] { net.minecraft.src.Block
				.planks, net.minecraft.src.Block.bookShelf, net.minecraft.src.Block.wood, net.minecraft.src.Block
				.chest });
		}
	}
}
