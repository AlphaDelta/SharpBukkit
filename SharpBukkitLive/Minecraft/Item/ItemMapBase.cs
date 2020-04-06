// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemMapBase : net.minecraft.src.Item
	{
		protected internal ItemMapBase(int i)
			: base(i)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Item, ItemStack, World, EntityPlayer, 
		//            Packet
		public override bool Func_28019_b()
		{
			return true;
		}

		public virtual net.minecraft.src.Packet Func_28022_b(net.minecraft.src.ItemStack 
			itemstack, net.minecraft.src.World world, net.minecraft.src.EntityPlayer entityplayer
			)
		{
			return null;
		}
	}
}
