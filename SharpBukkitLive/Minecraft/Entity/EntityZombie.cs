// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityZombie : net.minecraft.src.EntityMob
	{
		public EntityZombie(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityMob, World, MathHelper, Item
			texture = "/mob/zombie.png";
			moveSpeed = 0.5F;
			attackStrength = 5;
		}

		public override void OnLivingUpdate()
		{
			if (worldObj.IsDaytime())
			{
				float f = GetEntityBrightness(1.0F);
				if (f > 0.5F && worldObj.CanBlockSeeTheSky(net.minecraft.src.MathHelper.Floor_double
					(posX), net.minecraft.src.MathHelper.Floor_double(posY), net.minecraft.src.MathHelper
					.Floor_double(posZ)) && rand.NextFloat() * 30F < (f - 0.4F) * 2.0F)
				{
					fire = 300;
				}
			}
			base.OnLivingUpdate();
		}

		protected internal override string GetLivingSound()
		{
			return "mob.zombie";
		}

		protected internal override string GetHurtSound()
		{
			return "mob.zombiehurt";
		}

		protected internal override string GetDeathSound()
		{
			return "mob.zombiedeath";
		}

		protected internal override int GetDropItemId()
		{
			return net.minecraft.src.Item.FEATHER.ID;
		}
	}
}
