// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemFlintAndSteel : net.minecraft.src.Item
	{
		public ItemFlintAndSteel(int i)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, World, Block, BlockFire, 
			//            ItemStack, EntityPlayer
			maxStackSize = 1;
			SetMaxDamage(64);
		}

		public override bool OnItemUse(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityPlayer
			 entityplayer, net.minecraft.src.World world, int i, int j, int k, int l)
		{
			if (l == 0)
			{
				j--;
			}
			if (l == 1)
			{
				j++;
			}
			if (l == 2)
			{
				k--;
			}
			if (l == 3)
			{
				k++;
			}
			if (l == 4)
			{
				i--;
			}
			if (l == 5)
			{
				i++;
			}
			int i1 = world.GetBlockId(i, j, k);
			if (i1 == 0)
			{
				world.PlaySoundEffect((double)i + 0.5D, (double)j + 0.5D, (double)k + 0.5D, "fire.ignite"
					, 1.0F, itemRand.NextFloat() * 0.4F + 0.8F);
				world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.FIRE.ID);
			}
			itemstack.DamageItem(1, entityplayer);
			return true;
		}
	}
}
