// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemSaddle : net.minecraft.src.Item
	{
		public ItemSaddle(int i)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, EntityPig, ItemStack, EntityLiving
			maxStackSize = 1;
		}

		public override void SaddleEntity(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityLiving
			 entityliving)
		{
			if (entityliving is net.minecraft.src.EntityPig)
			{
				net.minecraft.src.EntityPig entitypig = (net.minecraft.src.EntityPig)entityliving;
				if (!entitypig.GetSaddled())
				{
					entitypig.SetSaddled(true);
					itemstack.stackSize--;
				}
			}
		}

		public override bool HitEntity(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityLiving
			 entityliving, net.minecraft.src.EntityLiving entityliving1)
		{
			SaddleEntity(itemstack, entityliving);
			return true;
		}
	}
}
