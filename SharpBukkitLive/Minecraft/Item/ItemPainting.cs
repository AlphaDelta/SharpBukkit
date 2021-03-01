// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemPainting : net.minecraft.src.Item
	{
		public ItemPainting(int i)
			: base(i)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Item, EntityPainting, World, ItemStack, 
		//            EntityPlayer
		public override bool OnItemUse(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityPlayer
			 entityplayer, net.minecraft.src.World world, int i, int j, int k, int l)
		{
			if (l == 0)
			{
				return false;
			}
			if (l == 1)
			{
				return false;
			}
			byte byte0 = 0;
			if (l == 4)
			{
				byte0 = 1;
			}
			if (l == 3)
			{
				byte0 = 2;
			}
			if (l == 5)
			{
				byte0 = 3;
			}
			net.minecraft.src.EntityPainting entitypainting = new net.minecraft.src.EntityPainting
				(world, i, j, k, byte0);
			if (entitypainting.OnValidSurface())
			{
				if (!world.singleplayerWorld)
				{
					world.AddEntity(entitypainting);
				}
				itemstack.stackSize--;
			}
			return true;
		}
	}
}
