// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public interface IInventory
	{
		// Referenced classes of package net.minecraft.src:
		//            ItemStack, EntityPlayer
		int GetSizeInventory();

		net.minecraft.src.ItemStack GetStackInSlot(int i);

		net.minecraft.src.ItemStack DecrStackSize(int i, int j);

		void SetInventorySlotContents(int i, net.minecraft.src.ItemStack itemstack);

		string GetInvName();

		int GetInventoryStackLimit();

		void OnInventoryChanged();

		bool CanInteractWith(net.minecraft.src.EntityPlayer entityplayer);
	}
}
