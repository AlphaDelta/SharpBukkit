// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityEgg : net.minecraft.src.Entity
	{
		public EntityEgg(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            Entity, EntityLiving, MathHelper, World, 
			//            Vec3D, MovingObjectPosition, AxisAlignedBB, EntityChicken, 
			//            NBTTagCompound, EntityPlayer, ItemStack, Item, 
			//            InventoryPlayer
			xTile = -1;
			yTile = -1;
			zTile = -1;
			inTile = 0;
			inGround = false;
			shake = 0;
			field_20079_al = 0;
			SetSize(0.25F, 0.25F);
		}

		protected internal override void EntityInit()
		{
		}

		public EntityEgg(net.minecraft.src.World world, net.minecraft.src.EntityLiving entityliving
			)
			: base(world)
		{
			xTile = -1;
			yTile = -1;
			zTile = -1;
			inTile = 0;
			inGround = false;
			shake = 0;
			field_20079_al = 0;
			field_20083_aj = entityliving;
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
			SetEggHeading(motionX, motionY, motionZ, 1.5F, 1.0F);
		}

		public EntityEgg(net.minecraft.src.World world, double d, double d1, double d2)
			: base(world)
		{
			xTile = -1;
			yTile = -1;
			zTile = -1;
			inTile = 0;
			inGround = false;
			shake = 0;
			field_20079_al = 0;
			field_20081_ak = 0;
			SetSize(0.25F, 0.25F);
			SetPosition(d, d1, d2);
			yOffset = 0.0F;
		}

		public virtual void SetEggHeading(double d, double d1, double d2, float f, float f1
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
			field_20081_ak = 0;
		}

		public override void OnUpdate()
		{
			lastTickPosX = posX;
			lastTickPosY = posY;
			lastTickPosZ = posZ;
			base.OnUpdate();
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
					field_20081_ak = 0;
					field_20079_al = 0;
				}
				else
				{
					field_20081_ak++;
					if (field_20081_ak == 1200)
					{
						SetEntityDead();
					}
					return;
				}
			}
			else
			{
				field_20079_al++;
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
				System.Collections.Generic.List<Entity> list = worldObj.GetEntitiesWithinAABBExcludingEntity(this
					, boundingBox.AddCoord(motionX, motionY, motionZ).Expand(1.0D, 1.0D, 1.0D));
				double d = 0.0D;
				for (int i1 = 0; i1 < list.Count; i1++)
				{
					net.minecraft.src.Entity entity1 = (net.minecraft.src.Entity)list[i1];
					if (!entity1.CanBeCollidedWith() || entity1 == field_20083_aj && field_20079_al <
						 5)
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
					if (!movingobjectposition.entityHit.AttackEntityFrom(field_20083_aj, 0))
					{
					}
				}
				if (!worldObj.singleplayerWorld && rand.Next(8) == 0)
				{
					byte byte0 = 1;
					if (rand.Next(32) == 0)
					{
						byte0 = 4;
					}
					for (int k = 0; k < byte0; k++)
					{
						net.minecraft.src.EntityChicken entitychicken = new net.minecraft.src.EntityChicken
							(worldObj);
						entitychicken.SetLocationAndAngles(posX, posY, posZ, rotationYaw, 0.0F);
						worldObj.AddEntity(entitychicken);
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
				for (int l = 0; l < 4; l++)
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

		public override void OnCollideWithPlayer(net.minecraft.src.EntityPlayer entityplayer
			)
		{
			if (inGround && field_20083_aj == entityplayer && shake <= 0 && entityplayer.inventory
				.AddItemStackToInventory(new net.minecraft.src.ItemStack(net.minecraft.src.Item.
				arrow, 1)))
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

		private bool inGround;

		public int shake;

		private net.minecraft.src.EntityLiving field_20083_aj;

		private int field_20081_ak;

		private int field_20079_al;
	}
}
