// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityCow : net.minecraft.src.EntityAnimal
	{
		public EntityCow(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityAnimal, Item, EntityPlayer, InventoryPlayer, 
			//            ItemStack, World, NBTTagCompound
			texture = "/mob/cow.png";
			SetSize(0.9F, 1.3F);
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.WriteEntityToNBT(nbttagcompound);
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.ReadEntityFromNBT(nbttagcompound);
		}

		protected internal override string GetLivingSound()
		{
			return "mob.cow";
		}

		protected internal override string GetHurtSound()
		{
			return "mob.cowhurt";
		}

		protected internal override string GetDeathSound()
		{
			return "mob.cowhurt";
		}

		protected internal override float GetSoundVolume()
		{
			return 0.4F;
		}

		protected internal override int GetDropItemId()
		{
			return net.minecraft.src.Item.leather.shiftedIndex;
		}

		public override bool Interact(net.minecraft.src.EntityPlayer entityplayer)
		{
			net.minecraft.src.ItemStack itemstack = entityplayer.inventory.GetCurrentItem();
			if (itemstack != null && itemstack.itemID == net.minecraft.src.Item.bucketEmpty.shiftedIndex)
			{
				entityplayer.inventory.SetInventorySlotContents(entityplayer.inventory.currentItem
					, new net.minecraft.src.ItemStack(net.minecraft.src.Item.bucketMilk));
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
