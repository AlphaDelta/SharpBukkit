// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemPickaxe : net.minecraft.src.ItemTool
	{
		protected internal ItemPickaxe(int i, net.minecraft.src.EnumToolMaterial enumtoolmaterial
			)
			: base(i, 2, enumtoolmaterial, blocksEffectiveAgainst)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            ItemTool, Block, EnumToolMaterial, Material
		public override bool CanHarvestBlock(net.minecraft.src.Block block)
		{
			if (block == net.minecraft.src.Block.OBSIDIAN)
			{
				return toolMaterial.GetHarvestLevel() == 3;
			}
			if (block == net.minecraft.src.Block.DIAMOND_BLOCK || block == net.minecraft.src.Block
				.DIAMOND_ORE)
			{
				return toolMaterial.GetHarvestLevel() >= 2;
			}
			if (block == net.minecraft.src.Block.GOLD_BLOCK || block == net.minecraft.src.Block
				.GOLD_ORE)
			{
				return toolMaterial.GetHarvestLevel() >= 2;
			}
			if (block == net.minecraft.src.Block.IRON_BLOCK || block == net.minecraft.src.Block
				.IRON_ORE)
			{
				return toolMaterial.GetHarvestLevel() >= 1;
			}
			if (block == net.minecraft.src.Block.LAPIS_BLOCK || block == net.minecraft.src.Block
				.LAPIS_ORE)
			{
				return toolMaterial.GetHarvestLevel() >= 1;
			}
			if (block == net.minecraft.src.Block.REDSTONE_ORE || block == net.minecraft.src.Block
				.GLOWING_REDSTONE_ORE)
			{
				return toolMaterial.GetHarvestLevel() >= 2;
			}
			if (block.blockMaterial == net.minecraft.src.Material.rock)
			{
				return true;
			}
			return block.blockMaterial == net.minecraft.src.Material.iron;
		}

		private static net.minecraft.src.Block[] blocksEffectiveAgainst;

		static ItemPickaxe()
		{
			blocksEffectiveAgainst = (new net.minecraft.src.Block[] { net.minecraft.src.Block
				.COBBLESTONE, net.minecraft.src.Block.DOUBLE_STEP, net.minecraft.src.Block.STEP
				, net.minecraft.src.Block.STONE, net.minecraft.src.Block.SANDSTONE, net.minecraft.src.Block
				.MOSSY_COBBLESTONE, net.minecraft.src.Block.IRON_ORE, net.minecraft.src.Block.IRON_BLOCK
				, net.minecraft.src.Block.COAL_ORE, net.minecraft.src.Block.GOLD_BLOCK, net.minecraft.src.Block
				.GOLD_ORE, net.minecraft.src.Block.DIAMOND_ORE, net.minecraft.src.Block.DIAMOND_BLOCK
				, net.minecraft.src.Block.ICE, net.minecraft.src.Block.NETHERRACK, net.minecraft.src.Block
				.LAPIS_ORE, net.minecraft.src.Block.LAPIS_BLOCK });
		}
	}
}
