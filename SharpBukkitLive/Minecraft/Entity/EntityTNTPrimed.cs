// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;

namespace net.minecraft.src
{
	public class EntityTNTPrimed : net.minecraft.src.Entity
	{
		SharpRandom SharpRandom = new SharpRandom();
		public EntityTNTPrimed(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            Entity, MathHelper, World, NBTTagCompound
			fuse = 0;
			preventEntitySpawning = true;
			SetSize(0.98F, 0.98F);
			yOffset = height / 2.0F;
		}

		public EntityTNTPrimed(net.minecraft.src.World world, double d, double d1, double
			 d2)
			: this(world)
		{
			SetPosition(d, d1, d2);
			float f = (float)(SharpRandom.NextDouble() * 3.1415927410125732D * 2D);
			motionX = -net.minecraft.src.MathHelper.Sin((f * 3.141593F) / 180F) * 0.02F;
			motionY = 0.20000000298023224D;
			motionZ = -net.minecraft.src.MathHelper.Cos((f * 3.141593F) / 180F) * 0.02F;
			fuse = 80;
			prevPosX = d;
			prevPosY = d1;
			prevPosZ = d2;
		}

		protected internal override void EntityInit()
		{
		}

		protected internal override bool Func_25017_l()
		{
			return false;
		}

		public override bool CanBeCollidedWith()
		{
			return !isDead;
		}

		public override void OnUpdate()
		{
			prevPosX = posX;
			prevPosY = posY;
			prevPosZ = posZ;
			motionY -= 0.039999999105930328D;
			MoveEntity(motionX, motionY, motionZ);
			motionX *= 0.98000001907348633D;
			motionY *= 0.98000001907348633D;
			motionZ *= 0.98000001907348633D;
			if (onGround)
			{
				motionX *= 0.69999998807907104D;
				motionZ *= 0.69999998807907104D;
				motionY *= -0.5D;
			}
			if (fuse-- <= 0)
			{
				if (!worldObj.singleplayerWorld)
				{
					SetEntityDead();
					Explode();
				}
				else
				{
					SetEntityDead();
				}
			}
			else
			{
				worldObj.SpawnParticle("smoke", posX, posY + 0.5D, posZ, 0.0D, 0.0D, 0.0D);
			}
		}

		private void Explode()
		{
			float f = 4F;
			worldObj.CreateExplosion(null, posX, posY, posZ, f);
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			nbttagcompound.SetByte("Fuse", unchecked((byte)fuse));
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			fuse = nbttagcompound.GetByte("Fuse");
		}

		public int fuse;
	}
}
