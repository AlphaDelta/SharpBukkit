// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemSeeds : net.minecraft.src.Item
	{
		public ItemSeeds(int i, int j)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, World, Block, ItemStack, 
			//            EntityPlayer
			field_271_a = j;
		}

		public override bool OnItemUse(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityPlayer
			 entityplayer, net.minecraft.src.World world, int i, int j, int k, int l)
		{
			if (l != 1)
			{
				return false;
			}
			int i1 = world.GetBlockId(i, j, k);
			if (i1 == net.minecraft.src.Block.tilledField.blockID && world.IsAirBlock(i, j + 
				1, k))
			{
				world.SetBlockWithNotify(i, j + 1, k, field_271_a);
				itemstack.stackSize--;
				return true;
			}
			else
			{
				return false;
			}
		}

		private int field_271_a;
	}
}
