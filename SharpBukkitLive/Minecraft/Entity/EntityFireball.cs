// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityFireball : net.minecraft.src.Entity
	{
		public EntityFireball(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            Entity, EntityLiving, MathHelper, World, 
			//            Vec3D, MovingObjectPosition, AxisAlignedBB, NBTTagCompound
			xTile = -1;
			yTile = -1;
			zTile = -1;
			inTile = 0;
			inGround = false;
			shake = 0;
			ticksInAir = 0;
			SetSize(1.0F, 1.0F);
		}

		protected internal override void EntityInit()
		{
		}

		public EntityFireball(net.minecraft.src.World world, net.minecraft.src.EntityLiving
			 entityliving, double d, double d1, double d2)
			: base(world)
		{
			xTile = -1;
			yTile = -1;
			zTile = -1;
			inTile = 0;
			inGround = false;
			shake = 0;
			ticksInAir = 0;
			owner = entityliving;
			SetSize(1.0F, 1.0F);
			SetLocationAndAngles(entityliving.posX, entityliving.posY, entityliving.posZ, entityliving
				.rotationYaw, entityliving.rotationPitch);
			SetPosition(posX, posY, posZ);
			yOffset = 0.0F;
			motionX = motionY = motionZ = 0.0D;
			d += rand.NextGaussian() * 0.40000000000000002D;
			d1 += rand.NextGaussian() * 0.40000000000000002D;
			d2 += rand.NextGaussian() * 0.40000000000000002D;
			double d3 = net.minecraft.src.MathHelper.Sqrt_double(d * d + d1 * d1 + d2 * d2);
			field_9199_b = (d / d3) * 0.10000000000000001D;
			field_9198_c = (d1 / d3) * 0.10000000000000001D;
			field_9196_d = (d2 / d3) * 0.10000000000000001D;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			fire = 10;
			if (shake > 0)
			{
				shake--;
			}
			if (inGround)
			{
				int i = worldObj.GetBlockId(xTile, yTile, zTile);
				if (i != inTile)
				{
					inGround = false;
					motionX *= rand.NextFloat() * 0.2F;
					motionY *= rand.NextFloat() * 0.2F;
					motionZ *= rand.NextFloat() * 0.2F;
					field_9190_an = 0;
					ticksInAir = 0;
				}
				else
				{
					field_9190_an++;
					if (field_9190_an == 1200)
					{
						SetEntityDead();
					}
					return;
				}
			}
			else
			{
				ticksInAir++;
			}
			net.minecraft.src.Vec3D vec3d = net.minecraft.src.Vec3D.CreateVector(posX, posY, 
				posZ);
			net.minecraft.src.Vec3D vec3d1 = net.minecraft.src.Vec3D.CreateVector(posX + motionX
				, posY + motionY, posZ + motionZ);
			net.minecraft.src.MovingObjectPosition movingobjectposition = worldObj.RayTraceBlocks
				(vec3d, vec3d1);
			vec3d = net.minecraft.src.Vec3D.CreateVector(posX, posY, posZ);
			vec3d1 = net.minecraft.src.Vec3D.CreateVector(posX + motionX, posY + motionY, posZ
				 + motionZ);
			if (movingobjectposition != null)
			{
				vec3d1 = net.minecraft.src.Vec3D.CreateVector(movingobjectposition.hitVec.xCoord, 
					movingobjectposition.hitVec.yCoord, movingobjectposition.hitVec.zCoord);
			}
			net.minecraft.src.Entity entity = null;
			System.Collections.Generic.List<Entity> list = worldObj.GetEntitiesWithinAABBExcludingEntity(this
				, boundingBox.AddCoord(motionX, motionY, motionZ).Expand(1.0D, 1.0D, 1.0D));
			double d = 0.0D;
			for (int j = 0; j < list.Count; j++)
			{
				net.minecraft.src.Entity entity1 = (net.minecraft.src.Entity)list[j];
				if (!entity1.CanBeCollidedWith() || entity1 == owner && ticksInAir < 25)
				{
					continue;
				}
				float f2 = 0.3F;
				net.minecraft.src.AxisAlignedBB axisalignedbb = entity1.boundingBox.Expand(f2, f2
					, f2);
				net.minecraft.src.MovingObjectPosition movingobjectposition1 = axisalignedbb.Func_706_a
					(vec3d, vec3d1);
				if (movingobjectposition1 == null)
				{
					continue;
				}
				double d1 = vec3d.DistanceTo(movingobjectposition1.hitVec);
				if (d1 < d || d == 0.0D)
				{
					entity = entity1;
					d = d1;
				}
			}
			if (entity != null)
			{
				movingobjectposition = new net.minecraft.src.MovingObjectPosition(entity);
			}
			if (movingobjectposition != null)
			{
				if (!worldObj.singleplayerWorld)
				{
					if (movingobjectposition.entityHit != null)
					{
						if (!movingobjectposition.entityHit.AttackEntityFrom(owner, 0))
						{
						}
					}
					worldObj.NewExplosion(null, posX, posY, posZ, 1.0F, true);
				}
				SetEntityDead();
			}
			posX += motionX;
			posY += motionY;
			posZ += motionZ;
			float f = net.minecraft.src.MathHelper.Sqrt_double(motionX * motionX + motionZ * 
				motionZ);
			rotationYaw = (float)((System.Math.Atan2(motionX, motionZ) * 180D) / 3.1415927410125732D
				);
			for (rotationPitch = (float)((System.Math.Atan2(motionY, f) * 180D) / 3.1415927410125732D
				); rotationPitch - prevRotationPitch < -180F; prevRotationPitch -= 360F)
			{
			}
			for (; rotationPitch - prevRotationPitch >= 180F; prevRotationPitch += 360F)
			{
			}
			for (; rotationYaw - prevRotationYaw < -180F; prevRotationYaw -= 360F)
			{
			}
			for (; rotationYaw - prevRotationYaw >= 180F; prevRotationYaw += 360F)
			{
			}
			rotationPitch = prevRotationPitch + (rotationPitch - prevRotationPitch) * 0.2F;
			rotationYaw = prevRotationYaw + (rotationYaw - prevRotationYaw) * 0.2F;
			float f1 = 0.95F;
			if (IsInWater())
			{
				for (int k = 0; k < 4; k++)
				{
					float f3 = 0.25F;
					worldObj.SpawnParticle("bubble", posX - motionX * (double)f3, posY - motionY * (double
						)f3, posZ - motionZ * (double)f3, motionX, motionY, motionZ);
				}
				f1 = 0.8F;
			}
			motionX += field_9199_b;
			motionY += field_9198_c;
			motionZ += field_9196_d;
			motionX *= f1;
			motionY *= f1;
			motionZ *= f1;
			worldObj.SpawnParticle("smoke", posX, posY + 0.5D, posZ, 0.0D, 0.0D, 0.0D);
			SetPosition(posX, posY, posZ);
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			nbttagcompound.SetShort("xTile", (short)xTile);
			nbttagcompound.SetShort("yTile", (short)yTile);
			nbttagcompound.SetShort("zTile", (short)zTile);
			nbttagcompound.SetByte("inTile", unchecked((byte)inTile));
			nbttagcompound.SetByte("shake", unchecked((byte)shake));
			nbttagcompound.SetByte("inGround", unchecked((byte)(inGround ? 1 : 0)));
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			xTile = nbttagcompound.GetShort("xTile");
			yTile = nbttagcompound.GetShort("yTile");
			zTile = nbttagcompound.GetShort("zTile");
			inTile = nbttagcompound.GetByte("inTile");
			shake = nbttagcompound.GetByte("shake");
			inGround = nbttagcompound.GetByte("inGround") == 1;
		}

		public override bool CanBeCollidedWith()
		{
			return true;
		}

		public override bool AttackEntityFrom(net.minecraft.src.Entity entity, int i)
		{
			SetBeenAttacked();
			if (entity != null)
			{
				net.minecraft.src.Vec3D vec3d = entity.GetLookVec();
				if (vec3d != null)
				{
					motionX = vec3d.xCoord;
					motionY = vec3d.yCoord;
					motionZ = vec3d.zCoord;
					field_9199_b = motionX * 0.10000000000000001D;
					field_9198_c = motionY * 0.10000000000000001D;
					field_9196_d = motionZ * 0.10000000000000001D;
				}
				return true;
			}
			else
			{
				return false;
			}
		}

		private int xTile;

		private int yTile;

		private int zTile;

		private int inTile;

		private bool inGround;

		public int shake;

		public net.minecraft.src.EntityLiving owner;

		private int field_9190_an;

		private int ticksInAir;

		public double field_9199_b;

		public double field_9198_c;

		public double field_9196_d;
	}
}
