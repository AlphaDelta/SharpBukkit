// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityFish : net.minecraft.src.Entity
	{
		public EntityFish(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            Entity, EntityPlayer, MathHelper, World, 
			//            ItemStack, Item, AxisAlignedBB, Vec3D, 
			//            MovingObjectPosition, Material, NBTTagCompound, EntityItem, 
			//            StatList
			xTile = -1;
			yTile = -1;
			zTile = -1;
			inTile = 0;
			inGround = false;
			shake = 0;
			ticksInAir = 0;
			ticksCatchable = 0;
			bobber = null;
			SetSize(0.25F, 0.25F);
			field_28008_bI = true;
		}

		public EntityFish(net.minecraft.src.World world, net.minecraft.src.EntityPlayer entityplayer
			)
			: base(world)
		{
			xTile = -1;
			yTile = -1;
			zTile = -1;
			inTile = 0;
			inGround = false;
			shake = 0;
			ticksInAir = 0;
			ticksCatchable = 0;
			bobber = null;
			field_28008_bI = true;
			angler = entityplayer;
			angler.fishEntity = this;
			SetSize(0.25F, 0.25F);
			SetLocationAndAngles(entityplayer.posX, (entityplayer.posY + 1.6200000000000001D)
				 - (double)entityplayer.yOffset, entityplayer.posZ, entityplayer.rotationYaw, entityplayer
				.rotationPitch);
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
			Func_6142_a(motionX, motionY, motionZ, 1.5F, 1.0F);
		}

		protected internal override void EntityInit()
		{
		}

		public virtual void Func_6142_a(double d, double d1, double d2, float f, float f1
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
			ticksInGround = 0;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			if (field_6149_an > 0)
			{
				double d = posX + (field_6148_ao - posX) / (double)field_6149_an;
				double d1 = posY + (field_6147_ap - posY) / (double)field_6149_an;
				double d2 = posZ + (field_6146_aq - posZ) / (double)field_6149_an;
				double d4;
				for (d4 = field_6145_ar - (double)rotationYaw; d4 < -180D; d4 += 360D)
				{
				}
				for (; d4 >= 180D; d4 -= 360D)
				{
				}
				rotationYaw += (float)(d4 / (double)field_6149_an);
				rotationPitch += (float)((field_6144_as - (double)rotationPitch) / (double)field_6149_an);
				field_6149_an--;
				SetPosition(d, d1, d2);
				SetRotation(rotationYaw, rotationPitch);
				return;
			}
			if (!worldObj.singleplayerWorld)
			{
				net.minecraft.src.ItemStack itemstack = angler.GetCurrentEquippedItem();
				if (angler.isDead || !angler.IsEntityAlive() || itemstack == null || itemstack.GetItem
					() != net.minecraft.src.Item.FISHING_ROD || GetDistanceSqToEntity(angler) > 1024D)
				{
					SetEntityDead();
					angler.fishEntity = null;
					return;
				}
				if (bobber != null)
				{
					if (bobber.isDead)
					{
						bobber = null;
					}
					else
					{
						posX = bobber.posX;
						posY = bobber.boundingBox.minY + (double)bobber.height * 0.80000000000000004D;
						posZ = bobber.posZ;
						return;
					}
				}
			}
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
					ticksInGround = 0;
					ticksInAir = 0;
				}
				else
				{
					ticksInGround++;
					if (ticksInGround == 1200)
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
			double d3 = 0.0D;
			for (int j = 0; j < list.Count; j++)
			{
				net.minecraft.src.Entity entity1 = (net.minecraft.src.Entity)list[j];
				if (!entity1.CanBeCollidedWith() || entity1 == angler && ticksInAir < 5)
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
				double d6 = vec3d.DistanceTo(movingobjectposition1.hitVec);
				if (d6 < d3 || d3 == 0.0D)
				{
					entity = entity1;
					d3 = d6;
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
					if (movingobjectposition.entityHit.AttackEntityFrom(angler, 0))
					{
						bobber = movingobjectposition.entityHit;
					}
				}
				else
				{
					inGround = true;
				}
			}
			if (inGround)
			{
				return;
			}
			MoveEntity(motionX, motionY, motionZ);
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
			float f1 = 0.92F;
			if (onGround || isCollidedHorizontally)
			{
				f1 = 0.5F;
			}
			int k = 5;
			double d5 = 0.0D;
			for (int l = 0; l < k; l++)
			{
				double d8 = ((boundingBox.minY + ((boundingBox.maxY - boundingBox.minY) * (double
					)(l + 0)) / (double)k) - 0.125D) + 0.125D;
				double d9 = ((boundingBox.minY + ((boundingBox.maxY - boundingBox.minY) * (double
					)(l + 1)) / (double)k) - 0.125D) + 0.125D;
				net.minecraft.src.AxisAlignedBB axisalignedbb1 = net.minecraft.src.AxisAlignedBB.
					GetBoundingBoxFromPool(boundingBox.minX, d8, boundingBox.minZ, boundingBox.maxX, 
					d9, boundingBox.maxZ);
				if (worldObj.IsAABBInMaterial(axisalignedbb1, net.minecraft.src.Material.water))
				{
					d5 += 1.0D / (double)k;
				}
			}
			if (d5 > 0.0D)
			{
				if (ticksCatchable > 0)
				{
					ticksCatchable--;
				}
				else
				{
					char c = '\u01F4';
					if (worldObj.CanLightningStrikeAt(net.minecraft.src.MathHelper.Floor_double(posX)
						, net.minecraft.src.MathHelper.Floor_double(posY) + 1, net.minecraft.src.MathHelper
						.Floor_double(posZ)))
					{
						c = '\u012C';
					}
					if (rand.Next(c) == 0)
					{
						ticksCatchable = rand.Next(30) + 10;
						motionY -= 0.20000000298023224D;
						worldObj.PlaySoundAtEntity(this, "random.splash", 0.25F, 1.0F + (rand.NextFloat()
							 - rand.NextFloat()) * 0.4F);
						float f3 = net.minecraft.src.MathHelper.Floor_double(boundingBox.minY);
						for (int i1 = 0; (float)i1 < 1.0F + width * 20F; i1++)
						{
							float f4 = (rand.NextFloat() * 2.0F - 1.0F) * width;
							float f6 = (rand.NextFloat() * 2.0F - 1.0F) * width;
							worldObj.SpawnParticle("bubble", posX + (double)f4, f3 + 1.0F, posZ + (double)f6, 
								motionX, motionY - (double)(rand.NextFloat() * 0.2F), motionZ);
						}
						for (int j1 = 0; (float)j1 < 1.0F + width * 20F; j1++)
						{
							float f5 = (rand.NextFloat() * 2.0F - 1.0F) * width;
							float f7 = (rand.NextFloat() * 2.0F - 1.0F) * width;
							worldObj.SpawnParticle("splash", posX + (double)f5, f3 + 1.0F, posZ + (double)f7, 
								motionX, motionY, motionZ);
						}
					}
				}
			}
			if (ticksCatchable > 0)
			{
				motionY -= (double)(rand.NextFloat() * rand.NextFloat() * rand.NextFloat()) * 0.20000000000000001D;
			}
			double d7 = d5 * 2D - 1.0D;
			motionY += 0.039999999105930328D * d7;
			if (d5 > 0.0D)
			{
				f1 = (float)((double)f1 * 0.90000000000000002D);
				motionY *= 0.80000000000000004D;
			}
			motionX *= f1;
			motionY *= f1;
			motionZ *= f1;
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

		public virtual int CatchFish()
		{
			byte byte0 = 0;
			if (bobber != null)
			{
				double d = angler.posX - posX;
				double d2 = angler.posY - posY;
				double d4 = angler.posZ - posZ;
				double d6 = net.minecraft.src.MathHelper.Sqrt_double(d * d + d2 * d2 + d4 * d4);
				double d8 = 0.10000000000000001D;
				bobber.motionX += d * d8;
				bobber.motionY += d2 * d8 + (double)net.minecraft.src.MathHelper.Sqrt_double(d6) 
					* 0.080000000000000002D;
				bobber.motionZ += d4 * d8;
				byte0 = 3;
			}
			else
			{
				if (ticksCatchable > 0)
				{
					net.minecraft.src.EntityItem entityitem = new net.minecraft.src.EntityItem(worldObj
						, posX, posY, posZ, new net.minecraft.src.ItemStack(net.minecraft.src.Item.RAW_FISH
						));
					double d1 = angler.posX - posX;
					double d3 = angler.posY - posY;
					double d5 = angler.posZ - posZ;
					double d7 = net.minecraft.src.MathHelper.Sqrt_double(d1 * d1 + d3 * d3 + d5 * d5);
					double d9 = 0.10000000000000001D;
					entityitem.motionX = d1 * d9;
					entityitem.motionY = d3 * d9 + (double)net.minecraft.src.MathHelper.Sqrt_double(d7
						) * 0.080000000000000002D;
					entityitem.motionZ = d5 * d9;
					worldObj.AddEntity(entityitem);
					angler.AddStat(net.minecraft.src.StatList.StatFishCaught, 1);
					byte0 = 1;
				}
			}
			if (inGround)
			{
				byte0 = 2;
			}
			SetEntityDead();
			angler.fishEntity = null;
			return byte0;
		}

		private int xTile;

		private int yTile;

		private int zTile;

		private int inTile;

		private bool inGround;

		public int shake;

		public net.minecraft.src.EntityPlayer angler;

		private int ticksInGround;

		private int ticksInAir;

		private int ticksCatchable;

		public net.minecraft.src.Entity bobber;

		private int field_6149_an;

		private double field_6148_ao;

		private double field_6147_ap;

		private double field_6146_aq;

		private double field_6145_ar;

		private double field_6144_as;
	}
}
