// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class EntityArrow : net.minecraft.src.Entity
	{
		public EntityArrow(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            Entity, EntityPlayer, EntityLiving, MathHelper, 
			//            World, Block, Vec3D, AxisAlignedBB, 
			//            MovingObjectPosition, NBTTagCompound, ItemStack, Item, 
			//            InventoryPlayer
			xTile = -1;
			yTile = -1;
			zTile = -1;
			inTile = 0;
			field_28011_h = 0;
			inGround = false;
			field_28012_a = false;
			arrowShake = 0;
			ticksInAir = 0;
			SetSize(0.5F, 0.5F);
		}

		public EntityArrow(net.minecraft.src.World world, double d, double d1, double d2)
			: base(world)
		{
			xTile = -1;
			yTile = -1;
			zTile = -1;
			inTile = 0;
			field_28011_h = 0;
			inGround = false;
			field_28012_a = false;
			arrowShake = 0;
			ticksInAir = 0;
			SetSize(0.5F, 0.5F);
			SetPosition(d, d1, d2);
			yOffset = 0.0F;
		}

		public EntityArrow(net.minecraft.src.World world, net.minecraft.src.EntityLiving 
			entityliving)
			: base(world)
		{
			xTile = -1;
			yTile = -1;
			zTile = -1;
			inTile = 0;
			field_28011_h = 0;
			inGround = false;
			field_28012_a = false;
			arrowShake = 0;
			ticksInAir = 0;
			owner = entityliving;
			field_28012_a = entityliving is net.minecraft.src.EntityPlayer;
			SetSize(0.5F, 0.5F);
			SetLocationAndAngles(entityliving.posX, entityliving.posY + (double)entityliving.
				GetEyeHeight(), entityliving.posZ, entityliving.rotationYaw, entityliving.rotationPitch
				);
			posX -= net.minecraft.src.MathHelper.Cos((rotationYaw / 180F) * 3.141593F) * 0.16F;
			posY -= 0.10000000149011612D;
			posZ -= net.minecraft.src.MathHelper.Sin((rotationYaw / 180F) * 3.141593F) * 0.16F;
			SetPosition(posX, posY, posZ);
			yOffset = 0.0F;
			motionX = -net.minecraft.src.MathHelper.Sin((rotationYaw / 180F) * 3.141593F) * net.minecraft.src.MathHelper
				.Cos((rotationPitch / 180F) * 3.141593F);
			motionZ = net.minecraft.src.MathHelper.Cos((rotationYaw / 180F) * 3.141593F) * net.minecraft.src.MathHelper
				.Cos((rotationPitch / 180F) * 3.141593F);
			motionY = -net.minecraft.src.MathHelper.Sin((rotationPitch / 180F) * 3.141593F);
			SetArrowHeading(motionX, motionY, motionZ, 1.5F, 1.0F);
		}

		protected internal override void EntityInit()
		{
		}

		public virtual void SetArrowHeading(double d, double d1, double d2, float f, float
			 f1)
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
			ticksInGround = 0;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			if (prevRotationPitch == 0.0F && prevRotationYaw == 0.0F)
			{
				float f = net.minecraft.src.MathHelper.Sqrt_double(motionX * motionX + motionZ * 
					motionZ);
				prevRotationYaw = rotationYaw = (float)((System.Math.Atan2(motionX, motionZ) * 180D
					) / 3.1415927410125732D);
				prevRotationPitch = rotationPitch = (float)((System.Math.Atan2(motionY, f) * 180D
					) / 3.1415927410125732D);
			}
			int i = worldObj.GetBlockId(xTile, yTile, zTile);
			if (i > 0)
			{
				net.minecraft.src.Block.blocksList[i].SetBlockBoundsBasedOnState(worldObj, xTile, 
					yTile, zTile);
				net.minecraft.src.AxisAlignedBB axisalignedbb = net.minecraft.src.Block.blocksList
					[i].GetCollisionBoundingBoxFromPool(worldObj, xTile, yTile, zTile);
				if (axisalignedbb != null && axisalignedbb.IsVecInXYZ(net.minecraft.src.Vec3D.CreateVector
					(posX, posY, posZ)))
				{
					inGround = true;
				}
			}
			if (arrowShake > 0)
			{
				arrowShake--;
			}
			if (inGround)
			{
				int j = worldObj.GetBlockId(xTile, yTile, zTile);
				int k = worldObj.GetBlockMetadata(xTile, yTile, zTile);
				if (j != inTile || k != field_28011_h)
				{
					inGround = false;
					motionX *= rand.NextFloat() * 0.2F;
					motionY *= rand.NextFloat() * 0.2F;
					motionZ *= rand.NextFloat() * 0.2F;
					ticksInGround = 0;
					ticksInAir = 0;
					return;
				}
				ticksInGround++;
				if (ticksInGround == 1200)
				{
					SetEntityDead();
				}
				return;
			}
			ticksInAir++;
			net.minecraft.src.Vec3D vec3d = net.minecraft.src.Vec3D.CreateVector(posX, posY, 
				posZ);
			net.minecraft.src.Vec3D vec3d1 = net.minecraft.src.Vec3D.CreateVector(posX + motionX
				, posY + motionY, posZ + motionZ);
			net.minecraft.src.MovingObjectPosition movingobjectposition = worldObj.Func_28099_a
				(vec3d, vec3d1, false, true);
			vec3d = net.minecraft.src.Vec3D.CreateVector(posX, posY, posZ);
			vec3d1 = net.minecraft.src.Vec3D.CreateVector(posX + motionX, posY + motionY, posZ
				 + motionZ);
			if (movingobjectposition != null)
			{
				vec3d1 = net.minecraft.src.Vec3D.CreateVector(movingobjectposition.hitVec.xCoord, 
					movingobjectposition.hitVec.yCoord, movingobjectposition.hitVec.zCoord);
			}
			net.minecraft.src.Entity entity = null;
			List<Entity> list = worldObj.GetEntitiesWithinAABBExcludingEntity(this
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
				net.minecraft.src.AxisAlignedBB axisalignedbb1 = entity1.boundingBox.Expand(f4, f4
					, f4);
				net.minecraft.src.MovingObjectPosition movingobjectposition1 = axisalignedbb1.Func_706_a
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
				if (movingobjectposition.entityHit != null)
				{
					if (movingobjectposition.entityHit.AttackEntityFrom(owner, 4))
					{
						worldObj.PlaySoundAtEntity(this, "random.drr", 1.0F, 1.2F / (rand.NextFloat() * 0.2F
							 + 0.9F));
						SetEntityDead();
					}
					else
					{
						motionX *= -0.10000000149011612D;
						motionY *= -0.10000000149011612D;
						motionZ *= -0.10000000149011612D;
						rotationYaw += 180F;
						prevRotationYaw += 180F;
						ticksInAir = 0;
					}
				}
				else
				{
					xTile = movingobjectposition.blockX;
					yTile = movingobjectposition.blockY;
					zTile = movingobjectposition.blockZ;
					inTile = worldObj.GetBlockId(xTile, yTile, zTile);
					field_28011_h = worldObj.GetBlockMetadata(xTile, yTile, zTile);
					motionX = (float)(movingobjectposition.hitVec.xCoord - posX);
					motionY = (float)(movingobjectposition.hitVec.yCoord - posY);
					motionZ = (float)(movingobjectposition.hitVec.zCoord - posZ);
					float f1 = net.minecraft.src.MathHelper.Sqrt_double(motionX * motionX + motionY *
						 motionY + motionZ * motionZ);
					posX -= (motionX / (double)f1) * 0.05000000074505806D;
					posY -= (motionY / (double)f1) * 0.05000000074505806D;
					posZ -= (motionZ / (double)f1) * 0.05000000074505806D;
					worldObj.PlaySoundAtEntity(this, "random.drr", 1.0F, 1.2F / (rand.NextFloat() * 0.2F
						 + 0.9F));
					inGround = true;
					arrowShake = 7;
				}
			}
			posX += motionX;
			posY += motionY;
			posZ += motionZ;
			float f2 = net.minecraft.src.MathHelper.Sqrt_double(motionX * motionX + motionZ *
				 motionZ);
			rotationYaw = (float)((System.Math.Atan2(motionX, motionZ) * 180D) / 3.1415927410125732D
				);
			for (rotationPitch = (float)((System.Math.Atan2(motionY, f2) * 180D) / 3.1415927410125732D
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
			float f3 = 0.99F;
			float f5 = 0.03F;
			if (IsInWater())
			{
				for (int i1 = 0; i1 < 4; i1++)
				{
					float f6 = 0.25F;
					worldObj.SpawnParticle("bubble", posX - motionX * (double)f6, posY - motionY * (double
						)f6, posZ - motionZ * (double)f6, motionX, motionY, motionZ);
				}
				f3 = 0.8F;
			}
			motionX *= f3;
			motionY *= f3;
			motionZ *= f3;
			motionY -= f5;
			SetPosition(posX, posY, posZ);
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			nbttagcompound.SetShort("xTile", (short)xTile);
			nbttagcompound.SetShort("yTile", (short)yTile);
			nbttagcompound.SetShort("zTile", (short)zTile);
			nbttagcompound.SetByte("inTile", unchecked((byte)inTile));
			nbttagcompound.SetByte("inData", unchecked((byte)field_28011_h));
			nbttagcompound.SetByte("shake", unchecked((byte)arrowShake));
			nbttagcompound.SetByte("inGround", unchecked((byte)(inGround ? 1 : 0)));
			nbttagcompound.SetBoolean("player", field_28012_a);
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			xTile = nbttagcompound.GetShort("xTile");
			yTile = nbttagcompound.GetShort("yTile");
			zTile = nbttagcompound.GetShort("zTile");
			inTile = nbttagcompound.GetByte("inTile") & unchecked((int)(0xff));
			field_28011_h = nbttagcompound.GetByte("inData") & unchecked((int)(0xff));
			arrowShake = nbttagcompound.GetByte("shake") & unchecked((int)(0xff));
			inGround = nbttagcompound.GetByte("inGround") == 1;
			field_28012_a = nbttagcompound.GetBoolean("player");
		}

		public override void OnCollideWithPlayer(net.minecraft.src.EntityPlayer entityplayer
			)
		{
			if (worldObj.singleplayerWorld)
			{
				return;
			}
			if (inGround && field_28012_a && arrowShake <= 0 && entityplayer.inventory.AddItemStackToInventory
				(new net.minecraft.src.ItemStack(net.minecraft.src.Item.arrow, 1)))
			{
				worldObj.PlaySoundAtEntity(this, "random.pop", 0.2F, ((rand.NextFloat() - rand.NextFloat
					()) * 0.7F + 1.0F) * 2.0F);
				entityplayer.OnItemPickup(this, 1);
				SetEntityDead();
			}
		}

		private int xTile;

		private int yTile;

		private int zTile;

		private int inTile;

		private int field_28011_h;

		private bool inGround;

		public bool field_28012_a;

		public int arrowShake;

		public net.minecraft.src.EntityLiving owner;

		private int ticksInGround;

		private int ticksInAir;
	}
}
