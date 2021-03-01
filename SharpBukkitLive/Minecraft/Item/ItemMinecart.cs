// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemMinecart : net.minecraft.src.Item
	{
		public ItemMinecart(int i, int j)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, World, BlockRail, EntityMinecart, 
			//            ItemStack, EntityPlayer
			maxStackSize = 1;
			minecartType = j;
		}

		public override bool OnItemUse(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityPlayer
			 entityplayer, net.minecraft.src.World world, int i, int j, int k, int l)
		{
			int i1 = world.GetBlockId(i, j, k);
			if (net.minecraft.src.BlockRail.Func_27030_c(i1))
			{
				if (!world.singleplayerWorld)
				{
					world.AddEntity(new net.minecraft.src.EntityMinecart(world, (float)i + 0.5F
						, (float)j + 0.5F, (float)k + 0.5F, minecartType));
				}
				itemstack.stackSize--;
				return true;
			}
			else
			{
				return false;
			}
		}

		public int minecartType;
	}
}
