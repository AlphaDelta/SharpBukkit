// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityWolf : net.minecraft.src.EntityAnimal
	{
		public EntityWolf(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityAnimal, DataWatcher, NBTTagCompound, World, 
			//            EntityPlayer, EntitySheep, AxisAlignedBB, Entity, 
			//            InventoryPlayer, ItemStack, Item, ItemFood, 
			//            MathHelper, EntityArrow, EntityLiving
			field_25039_a = false;
			texture = "/mob/wolf.png";
			SetSize(0.8F, 0.8F);
			moveSpeed = 1.1F;
			health = 8;
		}

		protected internal override void EntityInit()
		{
			base.EntityInit();
			dataWatcher.AddObject(16, unchecked((byte)0));
			dataWatcher.AddObject(17, string.Empty);
			dataWatcher.AddObject(18, health);
		}

		protected internal override bool Func_25017_l()
		{
			return false;
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.WriteEntityToNBT(nbttagcompound);
			nbttagcompound.SetBoolean("Angry", GetIsAngry());
			nbttagcompound.SetBoolean("Sitting", GetIsSitting());
			if (GetOwner() == null)
			{
				nbttagcompound.SetString("Owner", string.Empty);
			}
			else
			{
				nbttagcompound.SetString("Owner", GetOwner());
			}
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.ReadEntityFromNBT(nbttagcompound);
			SetIsAngry(nbttagcompound.GetBoolean("Angry"));
			SetIsSitting(nbttagcompound.GetBoolean("Sitting"));
			string s = nbttagcompound.GetString("Owner");
			if (s.Length > 0)
			{
				SetOwner(s);
				SetIsTamed(true);
			}
		}

		protected internal override bool Func_25020_s()
		{
			return !Func_25030_y();
		}

		protected internal override string GetLivingSound()
		{
			if (GetIsAngry())
			{
				return "mob.wolf.growl";
			}
			if (rand.Next(3) == 0)
			{
				if (Func_25030_y() && dataWatcher.GetWatchableObjectInteger(18) < 10)
				{
					return "mob.wolf.whine";
				}
				else
				{
					return "mob.wolf.panting";
				}
			}
			else
			{
				return "mob.wolf.bark";
			}
		}

		protected internal override string GetHurtSound()
		{
			return "mob.wolf.hurt";
		}

		protected internal override string GetDeathSound()
		{
			return "mob.wolf.death";
		}

		protected internal override float GetSoundVolume()
		{
			return 0.4F;
		}

		protected internal override int GetDropItemId()
		{
			return -1;
		}

		protected internal override void UpdatePlayerActionState()
		{
			base.UpdatePlayerActionState();
			if (!hasAttacked && !GetGotPath() && Func_25030_y() && ridingEntity == null)
			{
				net.minecraft.src.EntityPlayer entityplayer = worldObj.GetPlayerEntityByName(GetOwner
					());
				if (entityplayer != null)
				{
					float f = entityplayer.GetDistanceToEntity(this);
					if (f > 5F)
					{
						SetPathEntity(entityplayer, f);
					}
				}
				else
				{
					if (!IsInWater())
					{
						SetIsSitting(true);
					}
				}
			}
			else
			{
				if (playerToAttack == null && !GetGotPath() && !Func_25030_y() && worldObj.rand.NextInt
					(100) == 0)
				{
					System.Collections.Generic.List<Entity> list = worldObj.GetEntitiesWithinAABB(Sharpen.Runtime.GetClassForType
						(typeof(net.minecraft.src.EntitySheep)), net.minecraft.src.AxisAlignedBB.GetBoundingBoxFromPool
						(posX, posY, posZ, posX + 1.0D, posY + 1.0D, posZ + 1.0D).Expand(16D, 4D, 16D));
					if (list.Count > 0)
					{
						SetEntityToAttack((net.minecraft.src.Entity)list[worldObj.rand.Next(list.Count
							)]);
					}
				}
			}
			if (IsInWater())
			{
				SetIsSitting(false);
			}
			if (!worldObj.singleplayerWorld)
			{
				dataWatcher.UpdateObject(18, health);
			}
		}

		public override void OnLivingUpdate()
		{
			base.OnLivingUpdate();
			field_25039_a = false;
			if (Func_25021_O() && !GetGotPath() && !GetIsAngry())
			{
				net.minecraft.src.Entity entity = GetCurrentTarget();
				if (entity is net.minecraft.src.EntityPlayer)
				{
					net.minecraft.src.EntityPlayer entityplayer = (net.minecraft.src.EntityPlayer)entity;
					net.minecraft.src.ItemStack itemstack = entityplayer.inventory.GetCurrentItem();
					if (itemstack != null)
					{
						if (!Func_25030_y() && itemstack.itemID == net.minecraft.src.Item.bone.shiftedIndex)
						{
							field_25039_a = true;
						}
						else
						{
							if (Func_25030_y() && (net.minecraft.src.Item.itemsList[itemstack.itemID] is net.minecraft.src.ItemFood
								))
							{
								field_25039_a = ((net.minecraft.src.ItemFood)net.minecraft.src.Item.itemsList[itemstack
									.itemID]).Func_25010_k();
							}
						}
					}
				}
			}
			if (!isMultiplayerEntity && isWet && !field_25042_g && !GetGotPath() && onGround)
			{
				field_25042_g = true;
				field_25041_h = 0.0F;
				field_25040_i = 0.0F;
				worldObj.SendTrackedEntityStatusUpdatePacket(this, unchecked((byte)8));
			}
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			field_25044_c = field_25038_b;
			if (field_25039_a)
			{
				field_25038_b = field_25038_b + (1.0F - field_25038_b) * 0.4F;
			}
			else
			{
				field_25038_b = field_25038_b + (0.0F - field_25038_b) * 0.4F;
			}
			if (field_25039_a)
			{
				numTicksToChaseTarget = 10;
			}
			if (Func_27008_Y())
			{
				isWet = true;
				field_25042_g = false;
				field_25041_h = 0.0F;
				field_25040_i = 0.0F;
			}
			else
			{
				if ((isWet || field_25042_g) && field_25042_g)
				{
					if (field_25041_h == 0.0F)
					{
						worldObj.PlaySoundAtEntity(this, "mob.wolf.shake", GetSoundVolume(), (rand.NextFloat
							() - rand.NextFloat()) * 0.2F + 1.0F);
					}
					field_25040_i = field_25041_h;
					field_25041_h += 0.05F;
					if (field_25040_i >= 2.0F)
					{
						isWet = false;
						field_25042_g = false;
						field_25040_i = 0.0F;
						field_25041_h = 0.0F;
					}
					if (field_25041_h > 0.4F)
					{
						float f = (float)boundingBox.minY;
						int i = (int)(net.minecraft.src.MathHelper.Sin((field_25041_h - 0.4F) * 3.141593F
							) * 7F);
						for (int j = 0; j < i; j++)
						{
							float f1 = (rand.NextFloat() * 2.0F - 1.0F) * width * 0.5F;
							float f2 = (rand.NextFloat() * 2.0F - 1.0F) * width * 0.5F;
							worldObj.SpawnParticle("splash", posX + (double)f1, f + 0.8F, posZ + (double)f2, 
								motionX, motionY, motionZ);
						}
					}
				}
			}
		}

		public override float GetEyeHeight()
		{
			return height * 0.8F;
		}

		protected internal override int Func_25018_n_()
		{
			if (GetIsSitting())
			{
				return 20;
			}
			else
			{
				return base.Func_25018_n_();
			}
		}

		private void SetPathEntity(net.minecraft.src.Entity entity, float f)
		{
			net.minecraft.src.PathEntity pathentity = worldObj.GetPathToEntity(this, entity, 
				16F);
			if (pathentity == null && f > 12F)
			{
				int i = net.minecraft.src.MathHelper.Floor_double(entity.posX) - 2;
				int j = net.minecraft.src.MathHelper.Floor_double(entity.posZ) - 2;
				int k = net.minecraft.src.MathHelper.Floor_double(entity.boundingBox.minY);
				for (int l = 0; l <= 4; l++)
				{
					for (int i1 = 0; i1 <= 4; i1++)
					{
						if ((l < 1 || i1 < 1 || l > 3 || i1 > 3) && worldObj.IsBlockNormalCube(i + l, k -
							 1, j + i1) && !worldObj.IsBlockNormalCube(i + l, k, j + i1) && !worldObj.IsBlockNormalCube
							(i + l, k + 1, j + i1))
						{
							SetLocationAndAngles((float)(i + l) + 0.5F, k, (float)(j + i1) + 0.5F, rotationYaw
								, rotationPitch);
							return;
						}
					}
				}
			}
			else
			{
				SetPathToEntity(pathentity);
			}
		}

		protected internal override bool Func_25026_u()
		{
			return GetIsSitting() || field_25042_g;
		}

		public override bool AttackEntityFrom(net.minecraft.src.Entity entity, int i)
		{
			SetIsSitting(false);
			if (entity != null && !(entity is net.minecraft.src.EntityPlayer) && !(entity is 
				net.minecraft.src.EntityArrow))
			{
				i = (i + 1) / 2;
			}
			if (base.AttackEntityFrom(entity, i))
			{
				if (!Func_25030_y() && !GetIsAngry())
				{
					if (entity is net.minecraft.src.EntityPlayer)
					{
						SetIsAngry(true);
						playerToAttack = entity;
					}
					if ((entity is net.minecraft.src.EntityArrow) && ((net.minecraft.src.EntityArrow)
						entity).owner != null)
					{
						entity = ((net.minecraft.src.EntityArrow)entity).owner;
					}
					if (entity is net.minecraft.src.EntityLiving)
					{
						System.Collections.Generic.List<Entity> list = worldObj.GetEntitiesWithinAABB(Sharpen.Runtime.GetClassForType
							(typeof(net.minecraft.src.EntityWolf)), net.minecraft.src.AxisAlignedBB.GetBoundingBoxFromPool
							(posX, posY, posZ, posX + 1.0D, posY + 1.0D, posZ + 1.0D).Expand(16D, 4D, 16D));
						System.Collections.IEnumerator iterator = list.GetEnumerator();
						do
						{
							if (!iterator.MoveNext())
							{
								break;
							}
							net.minecraft.src.Entity entity1 = (net.minecraft.src.Entity)iterator.Current;
							net.minecraft.src.EntityWolf entitywolf = (net.minecraft.src.EntityWolf)entity1;
							if (!entitywolf.Func_25030_y() && entitywolf.playerToAttack == null)
							{
								entitywolf.playerToAttack = entity;
								if (entity is net.minecraft.src.EntityPlayer)
								{
									entitywolf.SetIsAngry(true);
								}
							}
						}
						while (true);
					}
				}
				else
				{
					if (entity != this && entity != null)
					{
						if (Func_25030_y() && (entity is net.minecraft.src.EntityPlayer) && ((net.minecraft.src.EntityPlayer)entity).username.Equals(GetOwner(), System.StringComparison.OrdinalIgnoreCase))
						{
							return true;
						}
						playerToAttack = entity;
					}
				}
				return true;
			}
			else
			{
				return false;
			}
		}

		protected internal override net.minecraft.src.Entity FindPlayerToAttack()
		{
			if (GetIsAngry())
			{
				return worldObj.GetClosestPlayerToEntity(this, 16D);
			}
			else
			{
				return null;
			}
		}

		protected internal override void AttackEntity(net.minecraft.src.Entity entity, float
			 f)
		{
			if (f > 2.0F && f < 6F && rand.Next(10) == 0)
			{
				if (onGround)
				{
					double d = entity.posX - posX;
					double d1 = entity.posZ - posZ;
					float f1 = net.minecraft.src.MathHelper.Sqrt_double(d * d + d1 * d1);
					motionX = (d / (double)f1) * 0.5D * 0.80000001192092896D + motionX * 0.20000000298023224D;
					motionZ = (d1 / (double)f1) * 0.5D * 0.80000001192092896D + motionZ * 0.20000000298023224D;
					motionY = 0.40000000596046448D;
				}
			}
			else
			{
				if ((double)f < 1.5D && entity.boundingBox.maxY > boundingBox.minY && entity.boundingBox
					.minY < boundingBox.maxY)
				{
					attackTime = 20;
					byte byte0 = 2;
					if (Func_25030_y())
					{
						byte0 = 4;
					}
					entity.AttackEntityFrom(this, byte0);
				}
			}
		}

		public override bool Interact(net.minecraft.src.EntityPlayer entityplayer)
		{
			net.minecraft.src.ItemStack itemstack = entityplayer.inventory.GetCurrentItem();
			if (!Func_25030_y())
			{
				if (itemstack != null && itemstack.itemID == net.minecraft.src.Item.bone.shiftedIndex
					 && !GetIsAngry())
				{
					itemstack.stackSize--;
					if (itemstack.stackSize <= 0)
					{
						entityplayer.inventory.SetInventorySlotContents(entityplayer.inventory.currentItem
							, null);
					}
					if (!worldObj.singleplayerWorld)
					{
						if (rand.Next(3) == 0)
						{
							SetIsTamed(true);
							SetPathToEntity(null);
							SetIsSitting(true);
							health = 20;
							SetOwner(entityplayer.username);
							IsNowTamed(true);
							worldObj.SendTrackedEntityStatusUpdatePacket(this, unchecked((byte)7));
						}
						else
						{
							IsNowTamed(false);
							worldObj.SendTrackedEntityStatusUpdatePacket(this, unchecked((byte)6));
						}
					}
					return true;
				}
			}
			else
			{
				if (itemstack != null && (net.minecraft.src.Item.itemsList[itemstack.itemID] is net.minecraft.src.ItemFood
					))
				{
					net.minecraft.src.ItemFood itemfood = (net.minecraft.src.ItemFood)net.minecraft.src.Item
						.itemsList[itemstack.itemID];
					if (itemfood.Func_25010_k() && dataWatcher.GetWatchableObjectInteger(18) < 20)
					{
						itemstack.stackSize--;
						if (itemstack.stackSize <= 0)
						{
							entityplayer.inventory.SetInventorySlotContents(entityplayer.inventory.currentItem
								, null);
						}
						Heal(((net.minecraft.src.ItemFood)net.minecraft.src.Item.porkRaw).GetHealAmount()
							);
						return true;
					}
				}
				if (entityplayer.username.Equals(GetOwner(), System.StringComparison.OrdinalIgnoreCase))
				{
					if (!worldObj.singleplayerWorld)
					{
						SetIsSitting(!GetIsSitting());
						isJumping = false;
						SetPathToEntity(null);
					}
					return true;
				}
			}
			return false;
		}

		internal virtual void IsNowTamed(bool flag)
		{
			string s = "heart";
			if (!flag)
			{
				s = "smoke";
			}
			for (int i = 0; i < 7; i++)
			{
				double d = rand.NextGaussian() * 0.02D;
				double d1 = rand.NextGaussian() * 0.02D;
				double d2 = rand.NextGaussian() * 0.02D;
				worldObj.SpawnParticle(s, (posX + (double)(rand.NextFloat() * width * 2.0F)) - (double
					)width, posY + 0.5D + (double)(rand.NextFloat() * height), (posZ + (double)(rand
					.NextFloat() * width * 2.0F)) - (double)width, d, d1, d2);
			}
		}

		public override int GetMaxSpawnedInChunk()
		{
			return 8;
		}

		public virtual string GetOwner()
		{
			return dataWatcher.GetWatchableObjectString(17);
		}

		public virtual void SetOwner(string s)
		{
			dataWatcher.UpdateObject(17, s);
		}

		public virtual bool GetIsSitting()
		{
			return (dataWatcher.GetWatchableObjectByte(16) & 1) != 0;
		}

		public virtual void SetIsSitting(bool flag)
		{
			byte byte0 = dataWatcher.GetWatchableObjectByte(16);
			if (flag)
			{
				dataWatcher.UpdateObject(16, unchecked((byte)(byte0 | 1)));
			}
			else
			{
				dataWatcher.UpdateObject(16, unchecked((byte)(byte0 & -2)));
			}
		}

		public virtual bool GetIsAngry()
		{
			return (dataWatcher.GetWatchableObjectByte(16) & 2) != 0;
		}

		public virtual void SetIsAngry(bool flag)
		{
			byte byte0 = dataWatcher.GetWatchableObjectByte(16);
			if (flag)
			{
				dataWatcher.UpdateObject(16, unchecked((byte)(byte0 | 2)));
			}
			else
			{
				dataWatcher.UpdateObject(16, unchecked((byte)(byte0 & -3)));
			}
		}

		public virtual bool Func_25030_y()
		{
			return (dataWatcher.GetWatchableObjectByte(16) & 4) != 0;
		}

		public virtual void SetIsTamed(bool flag)
		{
			byte byte0 = dataWatcher.GetWatchableObjectByte(16);
			if (flag)
			{
				dataWatcher.UpdateObject(16, unchecked((byte)(byte0 | 4)));
			}
			else
			{
				dataWatcher.UpdateObject(16, unchecked((byte)(byte0 & -5)));
			}
		}

		private bool field_25039_a;

		private float field_25038_b;

		private float field_25044_c;

		private bool isWet;

		private bool field_25042_g;

		private float field_25041_h;

		private float field_25040_i;
	}
}
