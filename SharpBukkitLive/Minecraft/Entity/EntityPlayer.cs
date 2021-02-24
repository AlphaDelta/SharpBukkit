// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public abstract class EntityPlayer : net.minecraft.src.EntityLiving
	{
		public EntityPlayer(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityLiving, InventoryPlayer, ContainerPlayer, World, 
			//            ChunkCoordinates, DataWatcher, Container, StatList, 
			//            MathHelper, AxisAlignedBB, Entity, ItemStack, 
			//            Item, EntityItem, Material, NBTTagCompound, 
			//            NBTTagList, EntityMob, EntityArrow, EntityCreeper, 
			//            EntityGhast, EntityWolf, EnumStatus, WorldProvider, 
			//            BlockBed, Block, IChunkProvider, EntityMinecart, 
			//            AchievementList, EntityBoat, EntityPig, EntityFish, 
			//            IInventory, TileEntityFurnace, TileEntityDispenser, TileEntitySign, 
			//            StatBase
			inventory = new net.minecraft.src.InventoryPlayer(this);
			field_9152_am = 0;
			score = 0;
			isSwinging = false;
			swingProgressInt = 0;
			timeUntilPortal = 20;
			inPortal = false;
			damageRemainder = 0;
			fishEntity = null;
			personalCraftingInventory = new net.minecraft.src.ContainerPlayer(inventory, !world
				.singleplayerWorld);
			currentCraftingInventory = personalCraftingInventory;
			yOffset = 1.62F;
			net.minecraft.src.ChunkCoordinates chunkcoordinates = world.GetSpawnPoint();
			SetLocationAndAngles((double)chunkcoordinates.posX + 0.5D, chunkcoordinates.posY 
				+ 1, (double)chunkcoordinates.posZ + 0.5D, 0.0F, 0.0F);
			health = 20;
			entityType = "humanoid";
			field_9117_aI = 180F;
			fireResistance = 20;
			texture = "/mob/char.png";
		}

		protected internal override void EntityInit()
		{
			base.EntityInit();
			dataWatcher.AddObject(16, unchecked((byte)0));
		}

		public override void OnUpdate()
		{
			if (Func_22057_E())
			{
				sleepTimer++;
				if (sleepTimer > 100)
				{
					sleepTimer = 100;
				}
				if (!worldObj.singleplayerWorld)
				{
					if (!IsInBed())
					{
						WakeUpPlayer(true, true, false);
					}
					else
					{
						if (worldObj.IsDaytime())
						{
							WakeUpPlayer(false, true, true);
						}
					}
				}
			}
			else
			{
				if (sleepTimer > 0)
				{
					sleepTimer++;
					if (sleepTimer >= 110)
					{
						sleepTimer = 0;
					}
				}
			}
			base.OnUpdate();
			if (!worldObj.singleplayerWorld && currentCraftingInventory != null && !currentCraftingInventory
				.CanInteractWith(this))
			{
				UsePersonalCraftingInventory();
				currentCraftingInventory = personalCraftingInventory;
			}
			field_20047_ay = field_20050_aB;
			field_20046_az = field_20049_aC;
			field_20051_aA = field_20048_aD;
			double d = posX - field_20050_aB;
			double d1 = posY - field_20049_aC;
			double d2 = posZ - field_20048_aD;
			double d3 = 10D;
			if (d > d3)
			{
				field_20047_ay = field_20050_aB = posX;
			}
			if (d2 > d3)
			{
				field_20051_aA = field_20048_aD = posZ;
			}
			if (d1 > d3)
			{
				field_20046_az = field_20049_aC = posY;
			}
			if (d < -d3)
			{
				field_20047_ay = field_20050_aB = posX;
			}
			if (d2 < -d3)
			{
				field_20051_aA = field_20048_aD = posZ;
			}
			if (d1 < -d3)
			{
				field_20046_az = field_20049_aC = posY;
			}
			field_20050_aB += d * 0.25D;
			field_20048_aD += d2 * 0.25D;
			field_20049_aC += d1 * 0.25D;
			AddStat(net.minecraft.src.StatList.StatPlayOneMinute, 1);
			if (ridingEntity == null)
			{
				field_27995_d = null;
			}
		}

		protected internal override bool IsMovementBlocked()
		{
			return health <= 0 || Func_22057_E();
		}

		protected internal virtual void UsePersonalCraftingInventory()
		{
			currentCraftingInventory = personalCraftingInventory;
		}

		public override void UpdateRidden()
		{
			double d = posX;
			double d1 = posY;
			double d2 = posZ;
			base.UpdateRidden();
			field_9150_ao = field_9149_ap;
			field_9149_ap = 0.0F;
			Func_27015_h(posX - d, posY - d1, posZ - d2);
		}

		protected internal override void UpdatePlayerActionState()
		{
			if (isSwinging)
			{
				swingProgressInt++;
				if (swingProgressInt >= 8)
				{
					swingProgressInt = 0;
					isSwinging = false;
				}
			}
			else
			{
				swingProgressInt = 0;
			}
			swingProgress = (float)swingProgressInt / 8F;
		}

		public override void OnLivingUpdate()
		{
			if (worldObj.difficultySetting == 0 && health < 20 && (ticksExisted % 20) * 12 ==
				 0)
			{
				Heal(1);
			}
			inventory.DecrementAnimations();
			field_9150_ao = field_9149_ap;
			base.OnLivingUpdate();
			float f = net.minecraft.src.MathHelper.Sqrt_double(motionX * motionX + motionZ * 
				motionZ);
			float f1 = (float)System.Math.Atan(-motionY * 0.20000000298023224D) * 15F;
			if (f > 0.1F)
			{
				f = 0.1F;
			}
			if (!onGround || health <= 0)
			{
				f = 0.0F;
			}
			if (onGround || health <= 0)
			{
				f1 = 0.0F;
			}
			field_9149_ap += (f - field_9149_ap) * 0.4F;
			field_9101_aY += (f1 - field_9101_aY) * 0.8F;
			if (health > 0)
			{
				System.Collections.Generic.List<Entity> list = worldObj.GetEntitiesWithinAABBExcludingEntity(this
					, boundingBox.Expand(1.0D, 0.0D, 1.0D));
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						net.minecraft.src.Entity entity = (net.minecraft.src.Entity)list[i];
						if (!entity.isDead)
						{
							Func_171_h(entity);
						}
					}
				}
			}
		}

		private void Func_171_h(net.minecraft.src.Entity entity)
		{
			entity.OnCollideWithPlayer(this);
		}

		public override void OnDeath(net.minecraft.src.Entity entity)
		{
			base.OnDeath(entity);
			SetSize(0.2F, 0.2F);
			SetPosition(posX, posY, posZ);
			motionY = 0.10000000149011612D;
			if (username.Equals("Notch"))
			{
				DropPlayerItemWithRandomChoice(new net.minecraft.src.ItemStack(net.minecraft.src.Item
					.appleRed, 1), true);
			}
			inventory.DropAllItems();
			if (entity != null)
			{
				motionX = -net.minecraft.src.MathHelper.Cos(((attackedAtYaw + rotationYaw) * 3.141593F
					) / 180F) * 0.1F;
				motionZ = -net.minecraft.src.MathHelper.Sin(((attackedAtYaw + rotationYaw) * 3.141593F
					) / 180F) * 0.1F;
			}
			else
			{
				motionX = motionZ = 0.0D;
			}
			yOffset = 0.1F;
			AddStat(net.minecraft.src.StatList.StatDeaths, 1);
		}

		public override void AddToPlayerScore(net.minecraft.src.Entity entity, int i)
		{
			score += i;
			if (entity is net.minecraft.src.EntityPlayer)
			{
				AddStat(net.minecraft.src.StatList.StatPlayerKills, 1);
			}
			else
			{
				AddStat(net.minecraft.src.StatList.StatMobKills, 1);
			}
		}

		public virtual void DropCurrentItem()
		{
			DropPlayerItemWithRandomChoice(inventory.DecrStackSize(inventory.currentItem, 1), 
				false);
		}

		public virtual void DropPlayerItem(net.minecraft.src.ItemStack itemstack)
		{
			DropPlayerItemWithRandomChoice(itemstack, false);
		}

		public virtual void DropPlayerItemWithRandomChoice(net.minecraft.src.ItemStack itemstack
			, bool flag)
		{
			if (itemstack == null)
			{
				return;
			}
			net.minecraft.src.EntityItem entityitem = new net.minecraft.src.EntityItem(worldObj
				, posX, (posY - 0.30000001192092896D) + (double)GetEyeHeight(), posZ, itemstack);
			entityitem.delayBeforeCanPickup = 40;
			float f = 0.1F;
			if (flag)
			{
				float f2 = rand.NextFloat() * 0.5F;
				float f4 = rand.NextFloat() * 3.141593F * 2.0F;
				entityitem.motionX = -net.minecraft.src.MathHelper.Sin(f4) * f2;
				entityitem.motionZ = net.minecraft.src.MathHelper.Cos(f4) * f2;
				entityitem.motionY = 0.20000000298023224D;
			}
			else
			{

				//TODO: Fix me
				float f1 = 0.3F;
				entityitem.motionX = -net.minecraft.src.MathHelper.Sin((rotationYaw / 180F) * 3.141593F
					) * net.minecraft.src.MathHelper.Cos((rotationPitch / 180F) * 3.141593F) * f1;
				entityitem.motionZ = net.minecraft.src.MathHelper.Cos((rotationYaw / 180F) * 3.141593F
					) * net.minecraft.src.MathHelper.Cos((rotationPitch / 180F) * 3.141593F) * f1;
				entityitem.motionY = -net.minecraft.src.MathHelper.Sin((rotationPitch / 180F) * 3.141593F
					) * f1 + 0.1F;
				f1 = 0.02F;
				float f3 = rand.NextFloat() * 3.141593F * 2.0F;
				f1 *= rand.NextFloat();
				entityitem.motionX += System.Math.Cos(f3) * (double)f1;
				entityitem.motionY += (rand.NextFloat() - rand.NextFloat()) * 0.1F;
				entityitem.motionZ += System.Math.Sin(f3) * (double)f1;
			}
			JoinEntityItemWithWorld(entityitem);
			AddStat(net.minecraft.src.StatList.StatDrop, 1);
		}

		protected internal virtual void JoinEntityItemWithWorld(net.minecraft.src.EntityItem
			 entityitem)
		{
			worldObj.EntityJoinedWorld(entityitem);
		}

		public virtual float GetCurrentPlayerStrVsBlock(net.minecraft.src.Block block)
		{
			float f = inventory.GetStrVsBlock(block);
			if (IsInsideOfMaterial(net.minecraft.src.Material.water))
			{
				f /= 5F;
			}
			if (!onGround)
			{
				f /= 5F;
			}
			return f;
		}

		public virtual bool CanHarvestBlock(net.minecraft.src.Block block)
		{
			return inventory.CanHarvestBlock(block);
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.ReadEntityFromNBT(nbttagcompound);
			net.minecraft.src.NBTTagList nbttaglist = nbttagcompound.GetTagList("Inventory");
			inventory.ReadFromNBT(nbttaglist);
			dimension = nbttagcompound.GetInteger("Dimension");
			sleeping = nbttagcompound.GetBoolean("Sleeping");
			sleepTimer = nbttagcompound.GetShort("SleepTimer");
			if (sleeping)
			{
				playerLocation = new net.minecraft.src.ChunkCoordinates(net.minecraft.src.MathHelper
					.Floor_double(posX), net.minecraft.src.MathHelper.Floor_double(posY), net.minecraft.src.MathHelper
					.Floor_double(posZ));
				WakeUpPlayer(true, true, false);
			}
			if (nbttagcompound.HasKey("SpawnX") && nbttagcompound.HasKey("SpawnY") && nbttagcompound
				.HasKey("SpawnZ"))
			{
				spawnChunk = new net.minecraft.src.ChunkCoordinates(nbttagcompound.GetInteger("SpawnX"
					), nbttagcompound.GetInteger("SpawnY"), nbttagcompound.GetInteger("SpawnZ"));
			}
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.WriteEntityToNBT(nbttagcompound);
			nbttagcompound.SetTag("Inventory", inventory.WriteToNBT(new net.minecraft.src.NBTTagList
				()));
			nbttagcompound.SetInteger("Dimension", dimension);
			nbttagcompound.SetBoolean("Sleeping", sleeping);
			nbttagcompound.SetShort("SleepTimer", (short)sleepTimer);
			if (spawnChunk != null)
			{
				nbttagcompound.SetInteger("SpawnX", spawnChunk.posX);
				nbttagcompound.SetInteger("SpawnY", spawnChunk.posY);
				nbttagcompound.SetInteger("SpawnZ", spawnChunk.posZ);
			}
		}

		public virtual void DisplayGUIChest(net.minecraft.src.IInventory iinventory)
		{
		}

		public virtual void DisplayWorkbenchGUI(int i, int j, int k)
		{
		}

		public virtual void OnItemPickup(net.minecraft.src.Entity entity, int i)
		{
		}

		public override float GetEyeHeight()
		{
			return 0.12F;
		}

		protected internal virtual void ResetHeight()
		{
			yOffset = 1.62F;
		}

		public override bool AttackEntityFrom(net.minecraft.src.Entity entity, int i)
		{
			age = 0;
			if (health <= 0)
			{
				return false;
			}
			if (Func_22057_E() && !worldObj.singleplayerWorld)
			{
				WakeUpPlayer(true, true, false);
			}
			if ((entity is net.minecraft.src.EntityMob) || (entity is net.minecraft.src.EntityArrow
				))
			{
				if (worldObj.difficultySetting == 0)
				{
					i = 0;
				}
				if (worldObj.difficultySetting == 1)
				{
					i = i / 3 + 1;
				}
				if (worldObj.difficultySetting == 3)
				{
					i = (i * 3) / 2;
				}
			}
			if (i == 0)
			{
				return false;
			}
			object obj = entity;
			if ((obj is net.minecraft.src.EntityArrow) && ((net.minecraft.src.EntityArrow)obj
				).owner != null)
			{
				obj = ((net.minecraft.src.EntityArrow)obj).owner;
			}
			if (obj is net.minecraft.src.EntityLiving)
			{
				Func_25047_a((net.minecraft.src.EntityLiving)obj, false);
			}
			AddStat(net.minecraft.src.StatList.StatDamageTaken, i);
			return base.AttackEntityFrom(entity, i);
		}

		protected internal virtual bool IsPVPEnabled()
		{
			return false;
		}

		protected internal virtual void Func_25047_a(net.minecraft.src.EntityLiving entityliving
			, bool flag)
		{
			if ((entityliving is net.minecraft.src.EntityCreeper) || (entityliving is net.minecraft.src.EntityGhast
				))
			{
				return;
			}
			if (entityliving is net.minecraft.src.EntityWolf)
			{
				net.minecraft.src.EntityWolf entitywolf = (net.minecraft.src.EntityWolf)entityliving;
				if (entitywolf.Func_25030_y() && username.Equals(entitywolf.GetOwner()))
				{
					return;
				}
			}
			if ((entityliving is net.minecraft.src.EntityPlayer) && !IsPVPEnabled())
			{
				return;
			}
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
				net.minecraft.src.Entity entity = (net.minecraft.src.Entity)iterator.Current;
				net.minecraft.src.EntityWolf entitywolf1 = (net.minecraft.src.EntityWolf)entity;
				if (entitywolf1.Func_25030_y() && entitywolf1.GetEntityToAttack() == null && username
					.Equals(entitywolf1.GetOwner()) && (!flag || !entitywolf1.GetIsSitting()))
				{
					entitywolf1.SetIsSitting(false);
					entitywolf1.SetEntityToAttack(entityliving);
				}
			}
			while (true);
		}

		protected internal override void DamageEntity(int i)
		{
			int j = 25 - inventory.GetTotalArmorValue();
			int k = i * j + damageRemainder;
			inventory.DamageArmor(i);
			i = k / 25;
			damageRemainder = k % 25;
			base.DamageEntity(i);
		}

		public virtual void DisplayGUIFurnace(net.minecraft.src.TileEntityFurnace tileentityfurnace
			)
		{
		}

		public virtual void DisplayGUIDispenser(net.minecraft.src.TileEntityDispenser tileentitydispenser
			)
		{
		}

		public virtual void DisplayGUIEditSign(net.minecraft.src.TileEntitySign tileentitysign
			)
		{
		}

		public virtual void UseCurrentItemOnEntity(net.minecraft.src.Entity entity)
		{
			if (entity.Interact(this))
			{
				return;
			}
			net.minecraft.src.ItemStack itemstack = GetCurrentEquippedItem();
			if (itemstack != null && (entity is net.minecraft.src.EntityLiving))
			{
				itemstack.UseItemOnEntity((net.minecraft.src.EntityLiving)entity);
				if (itemstack.stackSize <= 0)
				{
					itemstack.Func_577_a(this);
					DestroyCurrentEquippedItem();
				}
			}
		}

		public virtual net.minecraft.src.ItemStack GetCurrentEquippedItem()
		{
			return inventory.GetCurrentItem();
		}

		public virtual void DestroyCurrentEquippedItem()
		{
			inventory.SetInventorySlotContents(inventory.currentItem, null);
		}

		public override double GetYOffset()
		{
			return (double)(yOffset - 0.5F);
		}

		public virtual void SwingItem()
		{
			swingProgressInt = -1;
			isSwinging = true;
		}

		public virtual void AttackTargetEntityWithCurrentItem(net.minecraft.src.Entity entity
			)
		{
			int i = inventory.GetDamageVsEntity(entity);
			if (i > 0)
			{
				if (motionY < 0.0D)
				{
					i++;
				}
				entity.AttackEntityFrom(this, i);
				net.minecraft.src.ItemStack itemstack = GetCurrentEquippedItem();
				if (itemstack != null && (entity is net.minecraft.src.EntityLiving))
				{
					itemstack.HitEntity((net.minecraft.src.EntityLiving)entity, this);
					if (itemstack.stackSize <= 0)
					{
						itemstack.Func_577_a(this);
						DestroyCurrentEquippedItem();
					}
				}
				if (entity is net.minecraft.src.EntityLiving)
				{
					if (entity.IsEntityAlive())
					{
						Func_25047_a((net.minecraft.src.EntityLiving)entity, true);
					}
					AddStat(net.minecraft.src.StatList.StatDamageDealt, i);
				}
			}
		}

		public virtual void OnItemStackChanged(net.minecraft.src.ItemStack itemstack)
		{
		}

		public override void SetEntityDead()
		{
			base.SetEntityDead();
			personalCraftingInventory.OnCraftGuiClosed(this);
			if (currentCraftingInventory != null)
			{
				currentCraftingInventory.OnCraftGuiClosed(this);
			}
		}

		public override bool IsEntityInsideOpaqueBlock()
		{
			return !sleeping && base.IsEntityInsideOpaqueBlock();
		}

		public virtual net.minecraft.src.EnumStatus GoToSleep(int i, int j, int k)
		{
			if (!worldObj.singleplayerWorld)
			{
				if (Func_22057_E() || !IsEntityAlive())
				{
					return net.minecraft.src.EnumStatus.OTHER_PROBLEM;
				}
				if (worldObj.worldProvider.field_6167_c)
				{
					return net.minecraft.src.EnumStatus.NOT_POSSIBLE_HERE;
				}
				if (worldObj.IsDaytime())
				{
					return net.minecraft.src.EnumStatus.NOT_POSSIBLE_NOW;
				}
				if (System.Math.Abs(posX - (double)i) > 3D || System.Math.Abs(posY - (double)j) >
					 2D || System.Math.Abs(posZ - (double)k) > 3D)
				{
					return net.minecraft.src.EnumStatus.TOO_FAR_AWAY;
				}
			}
			SetSize(0.2F, 0.2F);
			yOffset = 0.2F;
			if (worldObj.BlockExists(i, j, k))
			{
				int l = worldObj.GetBlockMetadata(i, j, k);
				int i1 = net.minecraft.src.BlockBed.Func_22019_c(l);
				float f = 0.5F;
				float f1 = 0.5F;
				switch (i1)
				{
					case 0:
					{
						// '\0'
						f1 = 0.9F;
						break;
					}

					case 2:
					{
						// '\002'
						f1 = 0.1F;
						break;
					}

					case 1:
					{
						// '\001'
						f = 0.1F;
						break;
					}

					case 3:
					{
						// '\003'
						f = 0.9F;
						break;
					}
				}
				Func_22059_e(i1);
				SetPosition((float)i + f, (float)j + 0.9375F, (float)k + f1);
			}
			else
			{
				SetPosition((float)i + 0.5F, (float)j + 0.9375F, (float)k + 0.5F);
			}
			sleeping = true;
			sleepTimer = 0;
			playerLocation = new net.minecraft.src.ChunkCoordinates(i, j, k);
			motionX = motionZ = motionY = 0.0D;
			if (!worldObj.singleplayerWorld)
			{
				worldObj.UpdateAllPlayersSleepingFlag();
			}
			return net.minecraft.src.EnumStatus.OK;
		}

		private void Func_22059_e(int i)
		{
			field_22066_z = 0.0F;
			field_22067_A = 0.0F;
			switch (i)
			{
				case 0:
				{
					// '\0'
					field_22067_A = -1.8F;
					break;
				}

				case 2:
				{
					// '\002'
					field_22067_A = 1.8F;
					break;
				}

				case 1:
				{
					// '\001'
					field_22066_z = 1.8F;
					break;
				}

				case 3:
				{
					// '\003'
					field_22066_z = -1.8F;
					break;
				}
			}
		}

		public virtual void WakeUpPlayer(bool flag, bool flag1, bool flag2)
		{
			SetSize(0.6F, 1.8F);
			ResetHeight();
			net.minecraft.src.ChunkCoordinates chunkcoordinates = playerLocation;
			net.minecraft.src.ChunkCoordinates chunkcoordinates1 = playerLocation;
			if (chunkcoordinates != null && worldObj.GetBlockId(chunkcoordinates.posX, chunkcoordinates
				.posY, chunkcoordinates.posZ) == net.minecraft.src.Block.bed.blockID)
			{
				net.minecraft.src.BlockBed.Func_22022_a(worldObj, chunkcoordinates.posX, chunkcoordinates
					.posY, chunkcoordinates.posZ, false);
				net.minecraft.src.ChunkCoordinates chunkcoordinates2 = net.minecraft.src.BlockBed
					.Func_22021_g(worldObj, chunkcoordinates.posX, chunkcoordinates.posY, chunkcoordinates
					.posZ, 0);
				if (chunkcoordinates2 == null)
				{
					chunkcoordinates2 = new net.minecraft.src.ChunkCoordinates(chunkcoordinates.posX, 
						chunkcoordinates.posY + 1, chunkcoordinates.posZ);
				}
				SetPosition((float)chunkcoordinates2.posX + 0.5F, (float)chunkcoordinates2.posY +
					 yOffset + 0.1F, (float)chunkcoordinates2.posZ + 0.5F);
			}
			sleeping = false;
			if (!worldObj.singleplayerWorld && flag1)
			{
				worldObj.UpdateAllPlayersSleepingFlag();
			}
			if (flag)
			{
				sleepTimer = 0;
			}
			else
			{
				sleepTimer = 100;
			}
			if (flag2)
			{
				SetSpawnChunk(playerLocation);
			}
		}

		private bool IsInBed()
		{
			return worldObj.GetBlockId(playerLocation.posX, playerLocation.posY, playerLocation
				.posZ) == net.minecraft.src.Block.bed.blockID;
		}

		public static net.minecraft.src.ChunkCoordinates Func_25051_a(net.minecraft.src.World
			 world, net.minecraft.src.ChunkCoordinates chunkcoordinates)
		{
			net.minecraft.src.IChunkProvider ichunkprovider = world.GetChunkProvider();
			ichunkprovider.LoadChunk(chunkcoordinates.posX - 3 >> 4, chunkcoordinates.posZ - 
				3 >> 4);
			ichunkprovider.LoadChunk(chunkcoordinates.posX + 3 >> 4, chunkcoordinates.posZ - 
				3 >> 4);
			ichunkprovider.LoadChunk(chunkcoordinates.posX - 3 >> 4, chunkcoordinates.posZ + 
				3 >> 4);
			ichunkprovider.LoadChunk(chunkcoordinates.posX + 3 >> 4, chunkcoordinates.posZ + 
				3 >> 4);
			if (world.GetBlockId(chunkcoordinates.posX, chunkcoordinates.posY, chunkcoordinates
				.posZ) != net.minecraft.src.Block.bed.blockID)
			{
				return null;
			}
			else
			{
				net.minecraft.src.ChunkCoordinates chunkcoordinates1 = net.minecraft.src.BlockBed
					.Func_22021_g(world, chunkcoordinates.posX, chunkcoordinates.posY, chunkcoordinates
					.posZ, 0);
				return chunkcoordinates1;
			}
		}

		public override bool Func_22057_E()
		{
			return sleeping;
		}

		public virtual bool IsPlayerFullyAsleep()
		{
			return sleeping && sleepTimer >= 100;
		}

		public virtual void Func_22061_a(string s)
		{
		}

		public virtual net.minecraft.src.ChunkCoordinates GetSpawnChunk()
		{
			return spawnChunk;
		}

		public virtual void SetSpawnChunk(net.minecraft.src.ChunkCoordinates chunkcoordinates
			)
		{
			if (chunkcoordinates != null)
			{
				spawnChunk = new net.minecraft.src.ChunkCoordinates(chunkcoordinates);
			}
			else
			{
				spawnChunk = null;
			}
		}

		public virtual void Func_27017_a(net.minecraft.src.StatBase statbase)
		{
			AddStat(statbase, 1);
		}

		public virtual void AddStat(net.minecraft.src.StatBase statbase, int i)
		{
		}

		protected internal override void Jump()
		{
			base.Jump();
			AddStat(net.minecraft.src.StatList.StatJump, 1);
		}

		public override void MoveEntityWithHeading(float f, float f1)
		{
			double d = posX;
			double d1 = posY;
			double d2 = posZ;
			base.MoveEntityWithHeading(f, f1);
			Func_25045_g(posX - d, posY - d1, posZ - d2);
		}

		private void Func_25045_g(double d, double d1, double d2)
		{
			if (ridingEntity != null)
			{
				return;
			}
			if (IsInsideOfMaterial(net.minecraft.src.Material.water))
			{
				int i = (int)System.Math.Round(net.minecraft.src.MathHelper.Sqrt_double(d * d + d1 * d1 + d2 * d2) * 100F);
				if (i > 0)
				{
					AddStat(net.minecraft.src.StatList.StatDiveOneCm, i);
				}
			}
			else
			{
				if (IsInWater())
				{
					int j = (int)System.Math.Round(net.minecraft.src.MathHelper.Sqrt_double(d * d + d2 * d2) * 100F);
					if (j > 0)
					{
						AddStat(net.minecraft.src.StatList.StatSwimOneCm, j);
					}
				}
				else
				{
					if (IsOnLadder())
					{
						if (d1 > 0.0D)
						{
							AddStat(net.minecraft.src.StatList.StatClimbOneCm, (int)System.Math.Round(d1 * 100D
								));
						}
					}
					else
					{
						if (onGround)
						{
							int k = (int)System.Math.Round(net.minecraft.src.MathHelper.Sqrt_double(d * d + d2 * d2) * 100F);
							if (k > 0)
							{
								AddStat(net.minecraft.src.StatList.StatWalkOneCm, k);
							}
						}
						else
						{
							int l = (int)System.Math.Round(net.minecraft.src.MathHelper.Sqrt_double(d * d + d2 * d2) * 100F);
							if (l > 25)
							{
								AddStat(net.minecraft.src.StatList.StatFlyOneCm, l);
							}
						}
					}
				}
			}
		}

		private void Func_27015_h(double d, double d1, double d2)
		{
			if (ridingEntity != null)
			{
				int i = (int)System.Math.Round(net.minecraft.src.MathHelper.Sqrt_double(d * d + d1 * d1 + d2 * d2) * 100F);
				if (i > 0)
				{
					if (ridingEntity is net.minecraft.src.EntityMinecart)
					{
						AddStat(net.minecraft.src.StatList.StatMinecartOneCm, i);
						if (field_27995_d == null)
						{
							field_27995_d = new net.minecraft.src.ChunkCoordinates(net.minecraft.src.MathHelper
								.Floor_double(posX), net.minecraft.src.MathHelper.Floor_double(posY), net.minecraft.src.MathHelper
								.Floor_double(posZ));
						}
						else
						{
							if (field_27995_d.GetSqDistanceTo(net.minecraft.src.MathHelper.Floor_double(posX)
								, net.minecraft.src.MathHelper.Floor_double(posY), net.minecraft.src.MathHelper.
								Floor_double(posZ)) >= 1000D)
							{
								AddStat(net.minecraft.src.AchievementList.aOnARail, 1);
							}
						}
					}
					else
					{
						if (ridingEntity is net.minecraft.src.EntityBoat)
						{
							AddStat(net.minecraft.src.StatList.StatBoatOneCm, i);
						}
						else
						{
							if (ridingEntity is net.minecraft.src.EntityPig)
							{
								AddStat(net.minecraft.src.StatList.StatPigOneCm, i);
							}
						}
					}
				}
			}
		}

		protected internal override void Fall(float f)
		{
			if (f >= 2.0F)
			{
				AddStat(net.minecraft.src.StatList.StatFallOneCm, (int)System.Math.Round((double)
					f * 100D));
			}
			base.Fall(f);
		}

		public override void Func_27010_a(net.minecraft.src.EntityLiving entityliving)
		{
			if (entityliving is net.minecraft.src.EntityMob)
			{
				Func_27017_a(net.minecraft.src.AchievementList.aKillEnemy);
			}
		}

		public override void SetInPortal()
		{
			if (timeUntilPortal > 0)
			{
				timeUntilPortal = 10;
				return;
			}
			else
			{
				inPortal = true;
				return;
			}
		}

		public net.minecraft.src.InventoryPlayer inventory;

		public net.minecraft.src.Container personalCraftingInventory;

		public net.minecraft.src.Container currentCraftingInventory;

		public byte field_9152_am;

		public int score;

		public float field_9150_ao;

		public float field_9149_ap;

		public bool isSwinging;

		public int swingProgressInt;

		public string username;

		public int dimension;

		public double field_20047_ay;

		public double field_20046_az;

		public double field_20051_aA;

		public double field_20050_aB;

		public double field_20049_aC;

		public double field_20048_aD;

		protected internal bool sleeping;

		public net.minecraft.src.ChunkCoordinates playerLocation;

		private int sleepTimer;

		public float field_22066_z;

		public float field_22067_A;

		private net.minecraft.src.ChunkCoordinates spawnChunk;

		private net.minecraft.src.ChunkCoordinates field_27995_d;

		public int timeUntilPortal;

		protected internal bool inPortal;

		public float timeInPortal;

		private int damageRemainder;

		public net.minecraft.src.EntityFish fishEntity;
	}
}
