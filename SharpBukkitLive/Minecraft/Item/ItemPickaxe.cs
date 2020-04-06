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
			if (block == net.minecraft.src.Block.obsidian)
			{
				return toolMaterial.GetHarvestLevel() == 3;
			}
			if (block == net.minecraft.src.Block.blockDiamond || block == net.minecraft.src.Block
				.oreDiamond)
			{
				return toolMaterial.GetHarvestLevel() >= 2;
			}
			if (block == net.minecraft.src.Block.blockGold || block == net.minecraft.src.Block
				.oreGold)
			{
				return toolMaterial.GetHarvestLevel() >= 2;
			}
			if (block == net.minecraft.src.Block.blockSteel || block == net.minecraft.src.Block
				.oreIron)
			{
				return toolMaterial.GetHarvestLevel() >= 1;
			}
			if (block == net.minecraft.src.Block.blockLapis || block == net.minecraft.src.Block
				.oreLapis)
			{
				return toolMaterial.GetHarvestLevel() >= 1;
			}
			if (block == net.minecraft.src.Block.oreRedstone || block == net.minecraft.src.Block
				.oreRedstoneGlowing)
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
				.cobblestone, net.minecraft.src.Block.stairDouble, net.minecraft.src.Block.stairSingle
				, net.minecraft.src.Block.stone, net.minecraft.src.Block.sandStone, net.minecraft.src.Block
				.cobblestoneMossy, net.minecraft.src.Block.oreIron, net.minecraft.src.Block.blockSteel
				, net.minecraft.src.Block.oreCoal, net.minecraft.src.Block.blockGold, net.minecraft.src.Block
				.oreGold, net.minecraft.src.Block.oreDiamond, net.minecraft.src.Block.blockDiamond
				, net.minecraft.src.Block.ice, net.minecraft.src.Block.bloodStone, net.minecraft.src.Block
				.oreLapis, net.minecraft.src.Block.blockLapis });
		}
	}
}
