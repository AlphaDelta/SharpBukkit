// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntitySkeleton : net.minecraft.src.EntityMob
	{
		public EntitySkeleton(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityMob, World, MathHelper, Entity, 
			//            EntityArrow, Item, ItemStack, NBTTagCompound
			texture = "/mob/skeleton.png";
		}

		protected internal override string GetLivingSound()
		{
			return "mob.skeleton";
		}

		protected internal override string GetHurtSound()
		{
			return "mob.skeletonhurt";
		}

		protected internal override string GetDeathSound()
		{
			return "mob.skeletonhurt";
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

		protected internal override void AttackEntity(net.minecraft.src.Entity entity, float
			 f)
		{
			if (f < 10F)
			{
				double d = entity.posX - posX;
				double d1 = entity.posZ - posZ;
				if (attackTime == 0)
				{
					net.minecraft.src.EntityArrow entityarrow = new net.minecraft.src.EntityArrow(worldObj
						, this);
					entityarrow.posY += 1.3999999761581421D;
					double d2 = (entity.posY + (double)entity.GetEyeHeight()) - 0.20000000298023224D 
						- entityarrow.posY;
					float f1 = net.minecraft.src.MathHelper.Sqrt_double(d * d + d1 * d1) * 0.2F;
					worldObj.PlaySoundAtEntity(this, "random.bow", 1.0F, 1.0F / (rand.NextFloat() * 0.4F
						 + 0.8F));
					worldObj.AddEntity(entityarrow);
					entityarrow.SetArrowHeading(d, d2 + (double)f1, d1, 0.6F, 12F);
					attackTime = 30;
				}
				rotationYaw = (float)((System.Math.Atan2(d1, d) * 180D) / 3.1415927410125732D) - 
					90F;
				hasAttacked = true;
			}
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

		protected internal override int GetDropItemId()
		{
			return net.minecraft.src.Item.ARROW.ID;
		}

		protected internal override void DropFewItems()
		{
			int i = rand.Next(3);
			for (int j = 0; j < i; j++)
			{
				DropItem(net.minecraft.src.Item.ARROW.ID, 1);
			}
			i = rand.Next(3);
			for (int k = 0; k < i; k++)
			{
				DropItem(net.minecraft.src.Item.BONE.ID, 1);
			}
		}

		private static readonly net.minecraft.src.ItemStack defaultHeldItem;

		static EntitySkeleton()
		{
			defaultHeldItem = new net.minecraft.src.ItemStack(net.minecraft.src.Item.BOW, 1);
		}
	}
}
