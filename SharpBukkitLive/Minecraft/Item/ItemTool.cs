// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemTool : net.minecraft.src.Item
	{
		protected internal ItemTool(int i, int j, net.minecraft.src.EnumToolMaterial enumtoolmaterial
			, net.minecraft.src.Block[] ablock)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, EnumToolMaterial, ItemStack, Block, 
			//            EntityLiving, Entity
			efficiencyOnProperMaterial = 4F;
			toolMaterial = enumtoolmaterial;
			blocksEffectiveAgainst = ablock;
			maxStackSize = 1;
			SetMaxDamage(enumtoolmaterial.GetMaxUses());
			efficiencyOnProperMaterial = enumtoolmaterial.GetEfficiencyOnProperMaterial();
			damageVsEntity = j + enumtoolmaterial.GetDamageVsEntity();
		}

		public override float GetStrVsBlock(net.minecraft.src.ItemStack itemstack, net.minecraft.src.Block
			 block)
		{
			for (int i = 0; i < blocksEffectiveAgainst.Length; i++)
			{
				if (blocksEffectiveAgainst[i] == block)
				{
					return efficiencyOnProperMaterial;
				}
			}
			return 1.0F;
		}

		public override bool HitEntity(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityLiving
			 entityliving, net.minecraft.src.EntityLiving entityliving1)
		{
			itemstack.DamageItem(2, entityliving1);
			return true;
		}

		public override bool Func_25007_a(net.minecraft.src.ItemStack itemstack, int i, int
			 j, int k, int l, net.minecraft.src.EntityLiving entityliving)
		{
			itemstack.DamageItem(1, entityliving);
			return true;
		}

		public override int GetDamageVsEntity(net.minecraft.src.Entity entity)
		{
			return damageVsEntity;
		}

		private net.minecraft.src.Block[] blocksEffectiveAgainst;

		private float efficiencyOnProperMaterial;

		private int damageVsEntity;

		protected internal net.minecraft.src.EnumToolMaterial toolMaterial;
	}
}
