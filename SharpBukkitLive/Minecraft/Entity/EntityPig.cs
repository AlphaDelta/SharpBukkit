// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityPig : net.minecraft.src.EntityAnimal
	{
		public EntityPig(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityAnimal, DataWatcher, NBTTagCompound, World, 
			//            EntityPlayer, Item, EntityPigZombie, AchievementList, 
			//            EntityLightningBolt
			texture = "/mob/pig.png";
			SetSize(0.9F, 0.9F);
		}

		protected internal override void EntityInit()
		{
			dataWatcher.AddObject(16, unchecked((byte)0));
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.WriteEntityToNBT(nbttagcompound);
			nbttagcompound.SetBoolean("Saddle", GetSaddled());
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.ReadEntityFromNBT(nbttagcompound);
			SetSaddled(nbttagcompound.GetBoolean("Saddle"));
		}

		protected internal override string GetLivingSound()
		{
			return "mob.pig";
		}

		protected internal override string GetHurtSound()
		{
			return "mob.pig";
		}

		protected internal override string GetDeathSound()
		{
			return "mob.pigdeath";
		}

		public override bool Interact(net.minecraft.src.EntityPlayer entityplayer)
		{
			if (GetSaddled() && !worldObj.singleplayerWorld && (riddenByEntity == null || riddenByEntity
				 == entityplayer))
			{
				entityplayer.MountEntity(this);
				return true;
			}
			else
			{
				return false;
			}
		}

		protected internal override int GetDropItemId()
		{
			if (fire > 0)
			{
				return net.minecraft.src.Item.porkCooked.shiftedIndex;
			}
			else
			{
				return net.minecraft.src.Item.porkRaw.shiftedIndex;
			}
		}

		public virtual bool GetSaddled()
		{
			return (dataWatcher.GetWatchableObjectByte(16) & 1) != 0;
		}

		public virtual void SetSaddled(bool flag)
		{
			if (flag)
			{
				dataWatcher.UpdateObject(16, unchecked((byte)1));
			}
			else
			{
				dataWatcher.UpdateObject(16, unchecked((byte)0));
			}
		}

		public override void OnStruckByLightning(net.minecraft.src.EntityLightningBolt entitylightningbolt
			)
		{
			if (worldObj.singleplayerWorld)
			{
				return;
			}
			else
			{
				net.minecraft.src.EntityPigZombie entitypigzombie = new net.minecraft.src.EntityPigZombie
					(worldObj);
				entitypigzombie.SetLocationAndAngles(posX, posY, posZ, rotationYaw, rotationPitch
					);
				worldObj.AddEntity(entitypigzombie);
				SetEntityDead();
				return;
			}
		}

		protected internal override void Fall(float f)
		{
			base.Fall(f);
			if (f > 5F && (riddenByEntity is net.minecraft.src.EntityPlayer))
			{
				((net.minecraft.src.EntityPlayer)riddenByEntity).AddStatistic(net.minecraft.src.AchievementList
					.aFlyPig);
			}
		}
	}
}
