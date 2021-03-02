// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntitySpider : net.minecraft.src.EntityMob
	{
		public EntitySpider(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityMob, World, Entity, MathHelper, 
			//            Item, NBTTagCompound
			texture = "/mob/spider.png";
			SetSize(1.4F, 0.9F);
			moveSpeed = 0.8F;
		}

		public override double GetMountedYOffset()
		{
			return (double)height * 0.75D - 0.5D;
		}

		protected internal override bool Func_25017_l()
		{
			return false;
		}

		protected internal override net.minecraft.src.Entity FindPlayerToAttack()
		{
			float f = GetEntityBrightness(1.0F);
			if (f < 0.5F)
			{
				double d = 16D;
				return worldObj.GetClosestPlayerToEntity(this, d);
			}
			else
			{
				return null;
			}
		}

		protected internal override string GetLivingSound()
		{
			return "mob.spider";
		}

		protected internal override string GetHurtSound()
		{
			return "mob.spider";
		}

		protected internal override string GetDeathSound()
		{
			return "mob.spiderdeath";
		}

		protected internal override void AttackEntity(net.minecraft.src.Entity entity, float
			 f)
		{
			float f1 = GetEntityBrightness(1.0F);
			if (f1 > 0.5F && rand.Next(100) == 0)
			{
				playerToAttack = null;
				return;
			}
			if (f > 2.0F && f < 6F && rand.Next(10) == 0)
			{
				if (onGround)
				{
					double d = entity.posX - posX;
					double d1 = entity.posZ - posZ;
					float f2 = net.minecraft.src.MathHelper.Sqrt_double(d * d + d1 * d1);
					motionX = (d / (double)f2) * 0.5D * 0.80000001192092896D + motionX * 0.20000000298023224D;
					motionZ = (d1 / (double)f2) * 0.5D * 0.80000001192092896D + motionZ * 0.20000000298023224D;
					motionY = 0.40000000596046448D;
				}
			}
			else
			{
				base.AttackEntity(entity, f);
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
			return net.minecraft.src.Item.STRING.ID;
		}

		public override bool IsOnLadder()
		{
			return isCollidedHorizontally;
		}
	}
}
