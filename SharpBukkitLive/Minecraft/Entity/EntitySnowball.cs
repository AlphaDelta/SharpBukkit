// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntitySnowball : net.minecraft.src.Entity
	{
		public EntitySnowball(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            Entity, EntityLiving, MathHelper, World, 
			//            Vec3D, MovingObjectPosition, AxisAlignedBB, NBTTagCompound, 
			//            EntityPlayer, ItemStack, Item, InventoryPlayer
			xTileSnowball = -1;
			yTileSnowball = -1;
			zTileSnowball = -1;
			inTileSnowball = 0;
			inGroundSnowball = false;
			shakeSnowball = 0;
			ticksInAir = 0;
			SetSize(0.25F, 0.25F);
		}

		protected internal override void EntityInit()
		{
		}

		public EntitySnowball(net.minecraft.src.World world, net.minecraft.src.EntityLiving
			 entityliving)
			: base(world)
		{
			xTileSnowball = -1;
			yTileSnowball = -1;
			zTileSnowball = -1;
			inTileSnowball = 0;
			inGroundSnowball = false;
			shakeSnowball = 0;
			ticksInAir = 0;
			owner = entityliving;
			SetSize(0.25F, 0.25F);
			SetLocationAndAngles(entityliving.posX, entityliving.posY + (double)entityliving.
				GetEyeHeight(), entityliving.posZ, entityliving.rotationYaw, entityliving.rotationPitch
				);
			posX -= net.minecraft.src.MathHelper.Cos((rotationYaw / 180F) * 3.141593F) * 0.16F;
			posY -= 0.10000000149011612D;
			posZ -= net.minecraft.src.MathHelper.Sin((rotationYaw / 180F) * 3.141593F) * 0.16F;
			SetPosition(posX, posY, posZ);
			yOffset = 0.0F;
			float f = 0.4F;
			motionX = -net.minecraft.src.MathHelper.Sin((rotationYaw / 180F) * 3.141593F) * net.minecraft.src.MathHelper
				.Cos((rotationPitch / 180F) * 3.141593F) * f;
			motionZ = net.minecraft.src.MathHelper.Cos((rotationYaw / 180F) * 3.141593F) * net.minecraft.src.MathHelper
				.Cos((rotationPitch / 180F) * 3.141593F) * f;
			motionY = -net.minecraft.src.MathHelper.Sin((rotationPitch / 180F) * 3.141593F) *
				 f;
			Func_6141_a(motionX, motionY, motionZ, 1.5F, 1.0F);
		}

		public EntitySnowball(net.minecraft.src.World world, double d, double d1, double 
			d2)
			: base(world)
		{
			xTileSnowball = -1;
			yTileSnowball = -1;
			zTileSnowball = -1;
			inTileSnowball = 0;
			inGroundSnowball = false;
			shakeSnowball = 0;
			ticksInAir = 0;
			ticksOnGround = 0;
			SetSize(0.25F, 0.25F);
			SetPosition(d, d1, d2);
			yOffset = 0.0F;
		}

		public virtual void Func_6141_a(double d, double d1, double d2, float f, float f1
			)
		{
			float f2 = net.minecraft.src.MathHelper.Sqrt_double(d * d + d1 * d1 + d2 * d2);
			d /= f2;
			d1 /= f2;
			d2 /= f2;
			d += rand.NextGaussian() * 0.0074999998323619366D * (double)f1;
			d1 += rand.NextGaussian() * 0.0074999998323619366D * (double)f1;
			d2 += rand.NextGaussian() * 0.0074999998323619366D * (double)f1;
			d *= f;
			d1 *= f;
			d2 *= f;
			motionX = d;
			motionY = d1;
			motionZ = d2;
			float f3 = net.minecraft.src.MathHelper.Sqrt_double(d * d + d2 * d2);
			prevRotationYaw = rotationYaw = (float)((System.Math.Atan2(d, d2) * 180D) / 3.1415927410125732D
				);
			prevRotationPitch = rotationPitch = (float)((System.Math.Atan2(d1, f3) * 180D) / 
				3.1415927410125732D);
			ticksOnGround = 0;
		}

		public override void OnUpdate()
		{
			lastTickPosX = posX;
			lastTickPosY = posY;
			lastTickPosZ = posZ;
			base.OnUpdate();
			if (shakeSnowball > 0)
			{
				shakeSnowball--;
			}
			if (inGroundSnowball)
			{
				int i = worldObj.GetBlockId(xTileSnowball, yTileSnowball, zTileSnowball);
				if (i != inTileSnowball)
				{
					inGroundSnowball = false;
					motionX *= rand.NextFloat() * 0.2F;
					motionY *= rand.NextFloat() * 0.2F;
					motionZ *= rand.NextFloat() * 0.2F;
					ticksOnGround = 0;
					ticksInAir = 0;
				}
				else
				{
					ticksOnGround++;
					if (ticksOnGround == 1200)
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
			if (!worldObj.singleplayerWorld)
			{
				net.minecraft.src.Entity entity = null;
				System.Collections.IList list = worldObj.GetEntitiesWithinAABBExcludingEntity(this
					, boundingBox.AddCoord(motionX, motionY, motionZ).Expand(1.0D, 1.0D, 1.0D));
				double d = 0.0D;
				for (int l = 0; l < list.Count; l++)
				{
					net.minecraft.src.Entity entity1 = (net.minecraft.src.Entity)list[l];
					if (!entity1.CanBeCollidedWith() || entity1 == owner && ticksInAir < 5)
					{
						continue;
					}
					float f4 = 0.3F;
					net.minecraft.src.AxisAlignedBB axisalignedbb = entity1.boundingBox.Expand(f4, f4
						, f4);
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
			}
			if (movingobjectposition != null)
			{
				if (movingobjectposition.entityHit != null)
				{
					if (!movingobjectposition.entityHit.AttackEntityFrom(owner, 0))
					{
					}
				}
				for (int j = 0; j < 8; j++)
				{
					worldObj.SpawnParticle("snowballpoof", posX, posY, posZ, 0.0D, 0.0D, 0.0D);
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
			float f1 = 0.99F;
			float f2 = 0.03F;
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
			motionX *= f1;
			motionY *= f1;
			motionZ *= f1;
			motionY -= f2;
			SetPosition(posX, posY, posZ);
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			nbttagcompound.SetShort("xTile", (short)xTileSnowball);
			nbttagcompound.SetShort("yTile", (short)yTileSnowball);
			nbttagcompound.SetShort("zTile", (short)zTileSnowball);
			nbttagcompound.SetByte("inTile", unchecked((byte)inTileSnowball));
			nbttagcompound.SetByte("shake", unchecked((byte)shakeSnowball));
			nbttagcompound.SetByte("inGround", unchecked((byte)(inGroundSnowball ? 1 : 0)));
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			xTileSnowball = nbttagcompound.GetShort("xTile");
			yTileSnowball = nbttagcompound.GetShort("yTile");
			zTileSnowball = nbttagcompound.GetShort("zTile");
			inTileSnowball = nbttagcompound.GetByte("inTile") & unchecked((int)(0xff));
			shakeSnowball = nbttagcompound.GetByte("shake") & unchecked((int)(0xff));
			inGroundSnowball = nbttagcompound.GetByte("inGround") == 1;
		}

		public override void OnCollideWithPlayer(net.minecraft.src.EntityPlayer entityplayer
			)
		{
			if (inGroundSnowball && owner == entityplayer && shakeSnowball <= 0 && entityplayer
				.inventory.AddItemStackToInventory(new net.minecraft.src.ItemStack(net.minecraft.src.Item
				.arrow, 1)))
			{
				worldObj.PlaySoundAtEntity(this, "random.pop", 0.2F, ((rand.NextFloat() - rand.NextFloat
					()) * 0.7F + 1.0F) * 2.0F);
				entityplayer.OnItemPickup(this, 1);
				SetEntityDead();
			}
		}

		private int xTileSnowball;

		private int yTileSnowball;

		private int zTileSnowball;

		private int inTileSnowball;

		private bool inGroundSnowball;

		public int shakeSnowball;

		private net.minecraft.src.EntityLiving owner;

		private int ticksOnGround;

		private int ticksInAir;
	}
}
