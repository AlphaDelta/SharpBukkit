// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityCreature : net.minecraft.src.EntityLiving
	{
		public EntityCreature(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityLiving, World, Entity, AxisAlignedBB, 
			//            MathHelper, PathEntity, Vec3D
			hasAttacked = false;
		}

		protected internal virtual bool Func_25026_u()
		{
			return false;
		}

		protected internal override void UpdatePlayerActionState()
		{
			hasAttacked = Func_25026_u();
			float f = 16F;
			if (playerToAttack == null)
			{
				playerToAttack = FindPlayerToAttack();
				if (playerToAttack != null)
				{
					pathToEntity = worldObj.GetPathToEntity(this, playerToAttack, f);
				}
			}
			else
			{
				if (!playerToAttack.IsEntityAlive())
				{
					playerToAttack = null;
				}
				else
				{
					float f1 = playerToAttack.GetDistanceToEntity(this);
					if (CanEntityBeSeen(playerToAttack))
					{
						AttackEntity(playerToAttack, f1);
					}
					else
					{
						Func_28013_b(playerToAttack, f1);
					}
				}
			}
			if (!hasAttacked && playerToAttack != null && (pathToEntity == null || rand.NextInt
				(20) == 0))
			{
				pathToEntity = worldObj.GetPathToEntity(this, playerToAttack, f);
			}
			else
			{
				if (!hasAttacked && (pathToEntity == null && rand.Next(80) == 0 || rand.NextInt
					(80) == 0))
				{
					Func_31021_B();
				}
			}
			int i = net.minecraft.src.MathHelper.Floor_double(boundingBox.minY + 0.5D);
			bool flag = IsInWater();
			bool flag1 = HandleLavaMovement();
			rotationPitch = 0.0F;
			if (pathToEntity == null || rand.Next(100) == 0)
			{
				base.UpdatePlayerActionState();
				pathToEntity = null;
				return;
			}
			net.minecraft.src.Vec3D vec3d = pathToEntity.GetPosition(this);
			for (double d = width * 2.0F; vec3d != null && vec3d.SquareDistanceTo(posX, vec3d
				.yCoord, posZ) < d * d; )
			{
				pathToEntity.IncrementPathIndex();
				if (pathToEntity.IsFinished())
				{
					vec3d = null;
					pathToEntity = null;
				}
				else
				{
					vec3d = pathToEntity.GetPosition(this);
				}
			}
			isJumping = false;
			if (vec3d != null)
			{
				double d1 = vec3d.xCoord - posX;
				double d2 = vec3d.zCoord - posZ;
				double d3 = vec3d.yCoord - (double)i;
				float f2 = (float)((System.Math.Atan2(d2, d1) * 180D) / 3.1415927410125732D) - 90F;
				float f3 = f2 - rotationYaw;
				moveForward = moveSpeed;
				for (; f3 < -180F; f3 += 360F)
				{
				}
				for (; f3 >= 180F; f3 -= 360F)
				{
				}
				if (f3 > 30F)
				{
					f3 = 30F;
				}
				if (f3 < -30F)
				{
					f3 = -30F;
				}
				rotationYaw += f3;
				if (hasAttacked && playerToAttack != null)
				{
					double d4 = playerToAttack.posX - posX;
					double d5 = playerToAttack.posZ - posZ;
					float f5 = rotationYaw;
					rotationYaw = (float)((System.Math.Atan2(d5, d4) * 180D) / 3.1415927410125732D) -
						 90F;
					float f4 = (((f5 - rotationYaw) + 90F) * 3.141593F) / 180F;
					moveStrafing = -net.minecraft.src.MathHelper.Sin(f4) * moveForward * 1.0F;
					moveForward = net.minecraft.src.MathHelper.Cos(f4) * moveForward * 1.0F;
				}
				if (d3 > 0.0D)
				{
					isJumping = true;
				}
			}
			if (playerToAttack != null)
			{
				FaceEntity(playerToAttack, 30F, 30F);
			}
			if (isCollidedHorizontally && !GetGotPath())
			{
				isJumping = true;
			}
			if (rand.NextFloat() < 0.8F && (flag || flag1))
			{
				isJumping = true;
			}
		}

		protected internal virtual void Func_31021_B()
		{
			bool flag = false;
			int i = -1;
			int j = -1;
			int k = -1;
			float f = -99999F;
			for (int l = 0; l < 10; l++)
			{
				int i1 = net.minecraft.src.MathHelper.Floor_double((posX + (double)rand.Next(13
					)) - 6D);
				int j1 = net.minecraft.src.MathHelper.Floor_double((posY + (double)rand.Next(7
					)) - 3D);
				int k1 = net.minecraft.src.MathHelper.Floor_double((posZ + (double)rand.Next(13
					)) - 6D);
				float f1 = GetBlockPathWeight(i1, j1, k1);
				if (f1 > f)
				{
					f = f1;
					i = i1;
					j = j1;
					k = k1;
					flag = true;
				}
			}
			if (flag)
			{
				pathToEntity = worldObj.GetEntityPathToXYZ(this, i, j, k, 10F);
			}
		}

		protected internal virtual void AttackEntity(net.minecraft.src.Entity entity, float
			 f)
		{
		}

		protected internal virtual void Func_28013_b(net.minecraft.src.Entity entity, float
			 f)
		{
		}

		protected internal virtual float GetBlockPathWeight(int i, int j, int k)
		{
			return 0.0F;
		}

		protected internal virtual net.minecraft.src.Entity FindPlayerToAttack()
		{
			return null;
		}

		public override bool GetCanSpawnHere()
		{
			int i = net.minecraft.src.MathHelper.Floor_double(posX);
			int j = net.minecraft.src.MathHelper.Floor_double(boundingBox.minY);
			int k = net.minecraft.src.MathHelper.Floor_double(posZ);
			return base.GetCanSpawnHere() && GetBlockPathWeight(i, j, k) >= 0.0F;
		}

		public virtual bool GetGotPath()
		{
			return pathToEntity != null;
		}

		public virtual void SetPathToEntity(net.minecraft.src.PathEntity pathentity)
		{
			pathToEntity = pathentity;
		}

		public virtual net.minecraft.src.Entity GetEntityToAttack()
		{
			return playerToAttack;
		}

		public virtual void SetEntityToAttack(net.minecraft.src.Entity entity)
		{
			playerToAttack = entity;
		}

		private net.minecraft.src.PathEntity pathToEntity;

		protected internal net.minecraft.src.Entity playerToAttack;

		protected internal bool hasAttacked;
	}
}
