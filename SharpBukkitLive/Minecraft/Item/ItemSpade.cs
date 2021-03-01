// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemSpade : net.minecraft.src.ItemTool
	{
		public ItemSpade(int i, net.minecraft.src.EnumToolMaterial enumtoolmaterial)
			: base(i, 1, enumtoolmaterial, blocksEffectiveAgainst)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            ItemTool, Block, EnumToolMaterial
		public override bool CanHarvestBlock(net.minecraft.src.Block block)
		{
			if (block == net.minecraft.src.Block.SNOW)
			{
				return true;
			}
			return block == net.minecraft.src.Block.SNOW_BLOCK;
		}

		private static net.minecraft.src.Block[] blocksEffectiveAgainst;

		static ItemSpade()
		{
			blocksEffectiveAgainst = (new net.minecraft.src.Block[] { net.minecraft.src.Block
				.GRASS, net.minecraft.src.Block.DIRT, net.minecraft.src.Block.SAND, net.minecraft.src.Block
				.GRAVEL, net.minecraft.src.Block.SNOW, net.minecraft.src.Block.SNOW_BLOCK, net.minecraft.src.Block
				.CLAY, net.minecraft.src.Block.SOIL });
		}
	}
}
