// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityPigZombie : net.minecraft.src.EntityZombie
	{
		public EntityPigZombie(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityZombie, World, NBTTagCompound, EntityPlayer, 
			//            AxisAlignedBB, Entity, Item, ItemStack
			angerLevel = 0;
			randomSoundDelay = 0;
			texture = "/mob/pigzombie.png";
			moveSpeed = 0.5F;
			attackStrength = 5;
			isImmuneToFire = true;
		}

		public override void OnUpdate()
		{
			moveSpeed = playerToAttack == null ? 0.5F : 0.95F;
			if (randomSoundDelay > 0 && --randomSoundDelay == 0)
			{
				worldObj.PlaySoundAtEntity(this, "mob.zombiepig.zpigangry", GetSoundVolume() * 2.0F
					, ((rand.NextFloat() - rand.NextFloat()) * 0.2F + 1.0F) * 1.8F);
			}
			base.OnUpdate();
		}

		public override bool GetCanSpawnHere()
		{
			return worldObj.difficultySetting > 0 && worldObj.CheckIfAABBIsClear(boundingBox)
				 && worldObj.GetCollidingBoundingBoxes(this, boundingBox).Count == 0 && !worldObj
				.GetIsAnyLiquid(boundingBox);
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.WriteEntityToNBT(nbttagcompound);
			nbttagcompound.SetShort("Anger", (short)angerLevel);
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.ReadEntityFromNBT(nbttagcompound);
			angerLevel = nbttagcompound.GetShort("Anger");
		}

		protected internal override net.minecraft.src.Entity FindPlayerToAttack()
		{
			if (angerLevel == 0)
			{
				return null;
			}
			else
			{
				return base.FindPlayerToAttack();
			}
		}

		public override void OnLivingUpdate()
		{
			base.OnLivingUpdate();
		}

		public override bool AttackEntityFrom(net.minecraft.src.Entity entity, int i)
		{
			if (entity is net.minecraft.src.EntityPlayer)
			{
				System.Collections.Generic.List<Entity> list = worldObj.GetEntitiesWithinAABBExcludingEntity(this
					, boundingBox.Expand(32D, 32D, 32D));
				for (int j = 0; j < list.Count; j++)
				{
					net.minecraft.src.Entity entity1 = (net.minecraft.src.Entity)list[j];
					if (entity1 is net.minecraft.src.EntityPigZombie)
					{
						net.minecraft.src.EntityPigZombie entitypigzombie = (net.minecraft.src.EntityPigZombie
							)entity1;
						entitypigzombie.BecomeAngryAt(entity);
					}
				}
				BecomeAngryAt(entity);
			}
			return base.AttackEntityFrom(entity, i);
		}

		private void BecomeAngryAt(net.minecraft.src.Entity entity)
		{
			playerToAttack = entity;
			angerLevel = 400 + rand.Next(400);
			randomSoundDelay = rand.Next(40);
		}

		protected internal override string GetLivingSound()
		{
			return "mob.zombiepig.zpig";
		}

		protected internal override string GetHurtSound()
		{
			return "mob.zombiepig.zpighurt";
		}

		protected internal override string GetDeathSound()
		{
			return "mob.zombiepig.zpigdeath";
		}

		protected internal override int GetDropItemId()
		{
			return net.minecraft.src.Item.porkCooked.shiftedIndex;
		}

		private int angerLevel;

		private int randomSoundDelay;

		private static readonly net.minecraft.src.ItemStack defaultHeldItem;

		static EntityPigZombie()
		{
			defaultHeldItem = new net.minecraft.src.ItemStack(net.minecraft.src.Item.swordGold
				, 1);
		}
	}
}
