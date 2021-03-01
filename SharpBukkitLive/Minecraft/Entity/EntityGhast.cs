// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityGhast : net.minecraft.src.EntityFlying, net.minecraft.src.IMob
	{
		public EntityGhast(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityFlying, IMob, DataWatcher, World, 
			//            MathHelper, Entity, AxisAlignedBB, EntityFireball, 
			//            Vec3D, Item
			courseChangeCooldown = 0;
			targetedEntity = null;
			aggroCooldown = 0;
			prevAttackCounter = 0;
			attackCounter = 0;
			texture = "/mob/ghast.png";
			SetSize(4F, 4F);
			isImmuneToFire = true;
		}

		protected internal override void EntityInit()
		{
			base.EntityInit();
			dataWatcher.AddObject(16, unchecked((byte)0));
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			byte byte0 = dataWatcher.GetWatchableObjectByte(16);
			texture = byte0 != 1 ? "/mob/ghast.png" : "/mob/ghast_fire.png";
		}

		protected internal override void UpdatePlayerActionState()
		{
			if (!worldObj.singleplayerWorld && worldObj.difficultySetting == 0)
			{
				SetEntityDead();
			}
			Func_27013_Q();
			prevAttackCounter = attackCounter;
			double d = waypointX - posX;
			double d1 = waypointY - posY;
			double d2 = waypointZ - posZ;
			double d3 = net.minecraft.src.MathHelper.Sqrt_double(d * d + d1 * d1 + d2 * d2);
			if (d3 < 1.0D || d3 > 60D)
			{
				waypointX = posX + (double)((rand.NextFloat() * 2.0F - 1.0F) * 16F);
				waypointY = posY + (double)((rand.NextFloat() * 2.0F - 1.0F) * 16F);
				waypointZ = posZ + (double)((rand.NextFloat() * 2.0F - 1.0F) * 16F);
			}
			if (courseChangeCooldown-- <= 0)
			{
				courseChangeCooldown += rand.Next(5) + 2;
				if (IsCourseTraversable(waypointX, waypointY, waypointZ, d3))
				{
					motionX += (d / d3) * 0.10000000000000001D;
					motionY += (d1 / d3) * 0.10000000000000001D;
					motionZ += (d2 / d3) * 0.10000000000000001D;
				}
				else
				{
					waypointX = posX;
					waypointY = posY;
					waypointZ = posZ;
				}
			}
			if (targetedEntity != null && targetedEntity.isDead)
			{
				targetedEntity = null;
			}
			if (targetedEntity == null || aggroCooldown-- <= 0)
			{
				targetedEntity = worldObj.GetClosestPlayerToEntity(this, 100D);
				if (targetedEntity != null)
				{
					aggroCooldown = 20;
				}
			}
			double d4 = 64D;
			if (targetedEntity != null && targetedEntity.GetDistanceSqToEntity(this) < d4 * d4)
			{
				double d5 = targetedEntity.posX - posX;
				double d6 = (targetedEntity.boundingBox.minY + (double)(targetedEntity.height / 2.0F
					)) - (posY + (double)(height / 2.0F));
				double d7 = targetedEntity.posZ - posZ;
				renderYawOffset = rotationYaw = (-(float)System.Math.Atan2(d5, d7) * 180F) / 3.141593F;
				if (CanEntityBeSeen(targetedEntity))
				{
					if (attackCounter == 10)
					{
						worldObj.PlaySoundAtEntity(this, "mob.ghast.charge", GetSoundVolume(), (rand.NextFloat
							() - rand.NextFloat()) * 0.2F + 1.0F);
					}
					attackCounter++;
					if (attackCounter == 20)
					{
						worldObj.PlaySoundAtEntity(this, "mob.ghast.fireball", GetSoundVolume(), (rand.NextFloat
							() - rand.NextFloat()) * 0.2F + 1.0F);
						net.minecraft.src.EntityFireball entityfireball = new net.minecraft.src.EntityFireball
							(worldObj, this, d5, d6, d7);
						double d8 = 4D;
						net.minecraft.src.Vec3D vec3d = GetLook(1.0F);
						entityfireball.posX = posX + vec3d.xCoord * d8;
						entityfireball.posY = posY + (double)(height / 2.0F) + 0.5D;
						entityfireball.posZ = posZ + vec3d.zCoord * d8;
						worldObj.AddEntity(entityfireball);
						attackCounter = -40;
					}
				}
				else
				{
					if (attackCounter > 0)
					{
						attackCounter--;
					}
				}
			}
			else
			{
				renderYawOffset = rotationYaw = (-(float)System.Math.Atan2(motionX, motionZ) * 180F
					) / 3.141593F;
				if (attackCounter > 0)
				{
					attackCounter--;
				}
			}
			if (!worldObj.singleplayerWorld)
			{
				byte byte0 = dataWatcher.GetWatchableObjectByte(16);
				byte byte1 = unchecked((byte)(attackCounter <= 10 ? 0 : 1));
				if (byte0 != byte1)
				{
					dataWatcher.UpdateObject(16, byte1);
				}
			}
		}

		private bool IsCourseTraversable(double d, double d1, double d2, double d3)
		{
			double d4 = (waypointX - posX) / d3;
			double d5 = (waypointY - posY) / d3;
			double d6 = (waypointZ - posZ) / d3;
			net.minecraft.src.AxisAlignedBB axisalignedbb = boundingBox.Copy();
			for (int i = 1; (double)i < d3; i++)
			{
				axisalignedbb.Offset(d4, d5, d6);
				if (worldObj.GetCollidingBoundingBoxes(this, axisalignedbb).Count > 0)
				{
					return false;
				}
			}
			return true;
		}

		protected internal override string GetLivingSound()
		{
			return "mob.ghast.moan";
		}

		protected internal override string GetHurtSound()
		{
			return "mob.ghast.scream";
		}

		protected internal override string GetDeathSound()
		{
			return "mob.ghast.death";
		}

		protected internal override int GetDropItemId()
		{
			return net.minecraft.src.Item.gunpowder.shiftedIndex;
		}

		protected internal override float GetSoundVolume()
		{
			return 10F;
		}

		public override bool GetCanSpawnHere()
		{
			return rand.Next(20) == 0 && base.GetCanSpawnHere() && worldObj.difficultySetting
				 > 0;
		}

		public override int GetMaxSpawnedInChunk()
		{
			return 1;
		}

		public int courseChangeCooldown;

		public double waypointX;

		public double waypointY;

		public double waypointZ;

		private net.minecraft.src.Entity targetedEntity;

		private int aggroCooldown;

		public int prevAttackCounter;

		public int attackCounter;
	}
}
