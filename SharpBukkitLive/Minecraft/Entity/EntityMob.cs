// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityMob : net.minecraft.src.EntityCreature, net.minecraft.src.IMob
	{
		public EntityMob(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityCreature, IMob, World, Entity, 
			//            AxisAlignedBB, MathHelper, EnumSkyBlock, NBTTagCompound
			attackStrength = 2;
			health = 20;
		}

		public override void OnLivingUpdate()
		{
			float f = GetEntityBrightness(1.0F);
			if (f > 0.5F)
			{
				age += 2;
			}
			base.OnLivingUpdate();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			if (!worldObj.singleplayerWorld && worldObj.difficultySetting == 0)
			{
				SetEntityDead();
			}
		}

		protected internal override net.minecraft.src.Entity FindPlayerToAttack()
		{
			net.minecraft.src.EntityPlayer entityplayer = worldObj.GetClosestPlayerToEntity(this
				, 16D);
			if (entityplayer != null && CanEntityBeSeen(entityplayer))
			{
				return entityplayer;
			}
			else
			{
				return null;
			}
		}

		public override bool AttackEntityFrom(net.minecraft.src.Entity entity, int i)
		{
			if (base.AttackEntityFrom(entity, i))
			{
				if (riddenByEntity == entity || ridingEntity == entity)
				{
					return true;
				}
				if (entity != this)
				{
					playerToAttack = entity;
				}
				return true;
			}
			else
			{
				return false;
			}
		}

		protected internal override void AttackEntity(net.minecraft.src.Entity entity, float
			 f)
		{
			if (attackTime <= 0 && f < 2.0F && entity.boundingBox.maxY > boundingBox.minY && 
				entity.boundingBox.minY < boundingBox.maxY)
			{
				attackTime = 20;
				entity.AttackEntityFrom(this, attackStrength);
			}
		}

		protected internal override float GetBlockPathWeight(int i, int j, int k)
		{
			return 0.5F - worldObj.GetLightBrightness(i, j, k);
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

		public override bool GetCanSpawnHere()
		{
			int i = net.minecraft.src.MathHelper.Floor_double(posX);
			int j = net.minecraft.src.MathHelper.Floor_double(boundingBox.minY);
			int k = net.minecraft.src.MathHelper.Floor_double(posZ);
			if (worldObj.GetSavedLightValue(net.minecraft.src.EnumSkyBlock.Sky, i, j, k) > rand
				.NextInt(32))
			{
				return false;
			}
			int l = worldObj.GetBlockLightValue(i, j, k);
			if (worldObj.Func_27067_u())
			{
				int i1 = worldObj.skylightSubtracted;
				worldObj.skylightSubtracted = 10;
				l = worldObj.GetBlockLightValue(i, j, k);
				worldObj.skylightSubtracted = i1;
			}
			return l <= rand.Next(8) && base.GetCanSpawnHere();
		}

		protected internal int attackStrength;
	}
}
