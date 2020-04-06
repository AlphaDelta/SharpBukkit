// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemFood : net.minecraft.src.Item
	{
		public ItemFood(int i, int j, bool flag)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, ItemStack, EntityPlayer, World
			healAmount = j;
			field_25011_bi = flag;
			maxStackSize = 1;
		}

		public override net.minecraft.src.ItemStack OnItemRightClick(net.minecraft.src.ItemStack
			 itemstack, net.minecraft.src.World world, net.minecraft.src.EntityPlayer entityplayer
			)
		{
			itemstack.stackSize--;
			entityplayer.Heal(healAmount);
			return itemstack;
		}

		public virtual int GetHealAmount()
		{
			return healAmount;
		}

		public virtual bool Func_25010_k()
		{
			return field_25011_bi;
		}

		private int healAmount;

		private bool field_25011_bi;
	}
}
