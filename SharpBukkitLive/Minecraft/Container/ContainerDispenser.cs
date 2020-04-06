// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ContainerDispenser : net.minecraft.src.Container
	{
		public ContainerDispenser(net.minecraft.src.IInventory iinventory, net.minecraft.src.TileEntityDispenser
			 tileentitydispenser)
		{
			// Referenced classes of package net.minecraft.src:
			//            Container, Slot, TileEntityDispenser, IInventory, 
			//            EntityPlayer
			field_21133_a = tileentitydispenser;
			for (int i = 0; i < 3; i++)
			{
				for (int l = 0; l < 3; l++)
				{
					AddSlot(new net.minecraft.src.Slot(tileentitydispenser, l + i * 3, 62 + l * 18, 17
						 + i * 18));
				}
			}
			for (int j = 0; j < 3; j++)
			{
				for (int i1 = 0; i1 < 9; i1++)
				{
					AddSlot(new net.minecraft.src.Slot(iinventory, i1 + j * 9 + 9, 8 + i1 * 18, 84 + 
						j * 18));
				}
			}
			for (int k = 0; k < 9; k++)
			{
				AddSlot(new net.minecraft.src.Slot(iinventory, k, 8 + k * 18, 142));
			}
		}

		public override bool CanInteractWith(net.minecraft.src.EntityPlayer entityplayer)
		{
			return field_21133_a.CanInteractWith(entityplayer);
		}

		private net.minecraft.src.TileEntityDispenser field_21133_a;
	}
}
