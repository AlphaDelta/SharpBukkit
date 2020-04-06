// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityCreeper : net.minecraft.src.EntityMob
	{
		public EntityCreeper(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityMob, DataWatcher, NBTTagCompound, World, 
			//            EntitySkeleton, Item, Entity, EntityLightningBolt
			texture = "/mob/creeper.png";
		}

		protected internal override void EntityInit()
		{
			base.EntityInit();
			dataWatcher.AddObject(16, unchecked((byte)(-1)));
			dataWatcher.AddObject(17, unchecked((byte)0));
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.WriteEntityToNBT(nbttagcompound);
			if (dataWatcher.GetWatchableObjectByte(17) == 1)
			{
				nbttagcompound.SetBoolean("powered", true);
			}
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.ReadEntityFromNBT(nbttagcompound);
			dataWatcher.UpdateObject(17, unchecked((byte)(nbttagcompound.GetBoolean
				("powered") ? 1 : 0)));
		}

		protected internal override void Func_28013_b(net.minecraft.src.Entity entity, float
			 f)
		{
			if (worldObj.singleplayerWorld)
			{
				return;
			}
			if (timeSinceIgnited > 0)
			{
				SetCreeperState(-1);
				timeSinceIgnited--;
				if (timeSinceIgnited < 0)
				{
					timeSinceIgnited = 0;
				}
			}
		}

		public override void OnUpdate()
		{
			lastActiveTime = timeSinceIgnited;
			if (worldObj.singleplayerWorld)
			{
				int i = GetCreeperState();
				if (i > 0 && timeSinceIgnited == 0)
				{
					worldObj.PlaySoundAtEntity(this, "random.fuse", 1.0F, 0.5F);
				}
				timeSinceIgnited += i;
				if (timeSinceIgnited < 0)
				{
					timeSinceIgnited = 0;
				}
				if (timeSinceIgnited >= 30)
				{
					timeSinceIgnited = 30;
				}
			}
			base.OnUpdate();
			if (playerToAttack == null && timeSinceIgnited > 0)
			{
				SetCreeperState(-1);
				timeSinceIgnited--;
				if (timeSinceIgnited < 0)
				{
					timeSinceIgnited = 0;
				}
			}
		}

		protected internal override string GetHurtSound()
		{
			return "mob.creeper";
		}

		protected internal override string GetDeathSound()
		{
			return "mob.creeperdeath";
		}

		public override void OnDeath(net.minecraft.src.Entity entity)
		{
			base.OnDeath(entity);
			if (entity is net.minecraft.src.EntitySkeleton)
			{
				DropItem(net.minecraft.src.Item.record13.shiftedIndex + rand.Next(2), 1);
			}
		}

		protected internal override void AttackEntity(net.minecraft.src.Entity entity, float
			 f)
		{
			if (worldObj.singleplayerWorld)
			{
				return;
			}
			int i = GetCreeperState();
			if (i <= 0 && f < 3F || i > 0 && f < 7F)
			{
				if (timeSinceIgnited == 0)
				{
					worldObj.PlaySoundAtEntity(this, "random.fuse", 1.0F, 0.5F);
				}
				SetCreeperState(1);
				timeSinceIgnited++;
				if (timeSinceIgnited >= 30)
				{
					if (GetPowered())
					{
						worldObj.CreateExplosion(this, posX, posY, posZ, 6F);
					}
					else
					{
						worldObj.CreateExplosion(this, posX, posY, posZ, 3F);
					}
					SetEntityDead();
				}
				hasAttacked = true;
			}
			else
			{
				SetCreeperState(-1);
				timeSinceIgnited--;
				if (timeSinceIgnited < 0)
				{
					timeSinceIgnited = 0;
				}
			}
		}

		public virtual bool GetPowered()
		{
			return dataWatcher.GetWatchableObjectByte(17) == 1;
		}

		protected internal override int GetDropItemId()
		{
			return net.minecraft.src.Item.gunpowder.shiftedIndex;
		}

		private int GetCreeperState()
		{
			return dataWatcher.GetWatchableObjectByte(16);
		}

		private void SetCreeperState(int i)
		{
			dataWatcher.UpdateObject(16, unchecked((byte)i));
		}

		public override void OnStruckByLightning(net.minecraft.src.EntityLightningBolt entitylightningbolt
			)
		{
			base.OnStruckByLightning(entitylightningbolt);
			dataWatcher.UpdateObject(17, unchecked((byte)1));
		}

		internal int timeSinceIgnited;

		internal int lastActiveTime;
	}
}
