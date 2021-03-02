// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemShears : net.minecraft.src.Item
	{
		public ItemShears(int i)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, Block, BlockLeaves, ItemStack, 
			//            EntityLiving
			SetMaxStackSize(1);
			SetMaxDamage(238);
		}

		public override bool Func_25007_a(net.minecraft.src.ItemStack itemstack, int i, int
			 j, int k, int l, net.minecraft.src.EntityLiving entityliving)
		{
			if (i == net.minecraft.src.Block.LEAVES.ID || i == net.minecraft.src.Block.WEB
				.ID)
			{
				itemstack.DamageItem(1, entityliving);
			}
			return base.Func_25007_a(itemstack, i, j, k, l, entityliving);
		}

		public override bool CanHarvestBlock(net.minecraft.src.Block block)
		{
			return block.ID == net.minecraft.src.Block.WEB.ID;
		}

		public override float GetStrVsBlock(net.minecraft.src.ItemStack itemstack, net.minecraft.src.Block
			 block)
		{
			if (block.ID == net.minecraft.src.Block.WEB.ID || block.ID == net.minecraft.src.Block
				.LEAVES.ID)
			{
				return 15F;
			}
			if (block.ID == net.minecraft.src.Block.WOOL.ID)
			{
				return 5F;
			}
			else
			{
				return base.GetStrVsBlock(itemstack, block);
			}
		}
	}
}
