// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntitySlime : net.minecraft.src.EntityLiving, net.minecraft.src.IMob
	{
		public EntitySlime(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityLiving, IMob, DataWatcher, NBTTagCompound, 
			//            MathHelper, AxisAlignedBB, World, EntityPlayer, 
			//            Item, Chunk
			ticksTillJump = 0;
			texture = "/mob/slime.png";
			int i = 1 << rand.Next(3);
			yOffset = 0.0F;
			ticksTillJump = rand.Next(20) + 10;
			SetSlimeSize(i);
		}

		protected internal override void EntityInit()
		{
			base.EntityInit();
			dataWatcher.AddObject(16, unchecked((byte)1));
		}

		public virtual void SetSlimeSize(int i)
		{
			dataWatcher.UpdateObject(16, unchecked((byte)i));
			SetSize(0.6F * (float)i, 0.6F * (float)i);
			health = i * i;
			SetPosition(posX, posY, posZ);
		}

		public virtual int Func_25027_m()
		{
			return dataWatcher.GetWatchableObjectByte(16);
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.WriteEntityToNBT(nbttagcompound);
			nbttagcompound.SetInteger("Size", Func_25027_m() - 1);
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.ReadEntityFromNBT(nbttagcompound);
			SetSlimeSize(nbttagcompound.GetInteger("Size") + 1);
		}

		public override void OnUpdate()
		{
			field_400_b = field_401_a;
			bool flag = onGround;
			base.OnUpdate();
			if (onGround && !flag)
			{
				int i = Func_25027_m();
				for (int j = 0; j < i * 8; j++)
				{
					float f = rand.NextFloat() * 3.141593F * 2.0F;
					float f1 = rand.NextFloat() * 0.5F + 0.5F;
					float f2 = net.minecraft.src.MathHelper.Sin(f) * (float)i * 0.5F * f1;
					float f3 = net.minecraft.src.MathHelper.Cos(f) * (float)i * 0.5F * f1;
					worldObj.SpawnParticle("slime", posX + (double)f2, boundingBox.minY, posZ + (double
						)f3, 0.0D, 0.0D, 0.0D);
				}
				if (i > 2)
				{
					worldObj.PlaySoundAtEntity(this, "mob.slime", GetSoundVolume(), ((rand.NextFloat(
						) - rand.NextFloat()) * 0.2F + 1.0F) / 0.8F);
				}
				field_401_a = -0.5F;
			}
			field_401_a = field_401_a * 0.6F;
		}

		protected internal override void UpdatePlayerActionState()
		{
			Func_27013_Q();
			net.minecraft.src.EntityPlayer entityplayer = worldObj.GetClosestPlayerToEntity(this
				, 16D);
			if (entityplayer != null)
			{
				FaceEntity(entityplayer, 10F, 20F);
			}
			if (onGround && ticksTillJump-- <= 0)
			{
				ticksTillJump = rand.Next(20) + 10;
				if (entityplayer != null)
				{
					ticksTillJump /= 3;
				}
				isJumping = true;
				if (Func_25027_m() > 1)
				{
					worldObj.PlaySoundAtEntity(this, "mob.slime", GetSoundVolume(), ((rand.NextFloat(
						) - rand.NextFloat()) * 0.2F + 1.0F) * 0.8F);
				}
				field_401_a = 1.0F;
				moveStrafing = 1.0F - rand.NextFloat() * 2.0F;
				moveForward = 1 * Func_25027_m();
			}
			else
			{
				isJumping = false;
				if (onGround)
				{
					moveStrafing = moveForward = 0.0F;
				}
			}
		}

		public override void SetEntityDead()
		{
			int i = Func_25027_m();
			if (!worldObj.singleplayerWorld && i > 1 && health == 0)
			{
				for (int j = 0; j < 4; j++)
				{
					float f = (((float)(j % 2) - 0.5F) * (float)i) / 4F;
					float f1 = (((float)(j / 2) - 0.5F) * (float)i) / 4F;
					net.minecraft.src.EntitySlime entityslime = new net.minecraft.src.EntitySlime(worldObj
						);
					entityslime.SetSlimeSize(i / 2);
					entityslime.SetLocationAndAngles(posX + (double)f, posY + 0.5D, posZ + (double)f1
						, rand.NextFloat() * 360F, 0.0F);
					worldObj.AddEntity(entityslime);
				}
			}
			base.SetEntityDead();
		}

		public override void OnCollideWithPlayer(net.minecraft.src.EntityPlayer entityplayer
			)
		{
			int i = Func_25027_m();
			if (i > 1 && CanEntityBeSeen(entityplayer) && (double)GetDistanceToEntity(entityplayer
				) < 0.59999999999999998D * (double)i && entityplayer.AttackEntityFrom(this, i))
			{
				worldObj.PlaySoundAtEntity(this, "mob.slimeattack", 1.0F, (rand.NextFloat() - rand
					.NextFloat()) * 0.2F + 1.0F);
			}
		}

		protected internal override string GetHurtSound()
		{
			return "mob.slime";
		}

		protected internal override string GetDeathSound()
		{
			return "mob.slime";
		}

		protected internal override int GetDropItemId()
		{
			if (Func_25027_m() == 1)
			{
				return net.minecraft.src.Item.SLIME_BALL.ID;
			}
			else
			{
				return 0;
			}
		}

		public override bool GetCanSpawnHere()
		{
			net.minecraft.src.Chunk chunk = worldObj.GetChunkFromBlockCoords(net.minecraft.src.MathHelper
				.Floor_double(posX), net.minecraft.src.MathHelper.Floor_double(posZ));
			return (Func_25027_m() == 1 || worldObj.difficultySetting > 0) && rand.Next(10
				) == 0 && chunk.Func_334_a(unchecked((long)(0x3ad8025fL))).NextInt(10) == 0 && posY
				 < 16D;
		}

		protected internal override float GetSoundVolume()
		{
			return 0.6F;
		}

		public float field_401_a;

		public float field_400_b;

		private int ticksTillJump;
	}
}
