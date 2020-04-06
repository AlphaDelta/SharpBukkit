// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemSword : net.minecraft.src.Item
	{
		public ItemSword(int i, net.minecraft.src.EnumToolMaterial enumtoolmaterial)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, EnumToolMaterial, Block, ItemStack, 
			//            EntityLiving, Entity
			maxStackSize = 1;
			SetMaxDamage(enumtoolmaterial.GetMaxUses());
			weaponDamage = 4 + enumtoolmaterial.GetDamageVsEntity() * 2;
		}

		public override float GetStrVsBlock(net.minecraft.src.ItemStack itemstack, net.minecraft.src.Block
			 block)
		{
			return block.blockID != net.minecraft.src.Block.web.blockID ? 1.5F : 15F;
		}

		public override bool HitEntity(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityLiving
			 entityliving, net.minecraft.src.EntityLiving entityliving1)
		{
			itemstack.DamageItem(1, entityliving1);
			return true;
		}

		public override bool Func_25007_a(net.minecraft.src.ItemStack itemstack, int i, int
			 j, int k, int l, net.minecraft.src.EntityLiving entityliving)
		{
			itemstack.DamageItem(2, entityliving);
			return true;
		}

		public override int GetDamageVsEntity(net.minecraft.src.Entity entity)
		{
			return weaponDamage;
		}

		public override bool CanHarvestBlock(net.minecraft.src.Block block)
		{
			return block.blockID == net.minecraft.src.Block.web.blockID;
		}

		private int weaponDamage;
	}
}
