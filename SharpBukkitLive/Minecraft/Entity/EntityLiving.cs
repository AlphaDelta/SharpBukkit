// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;

namespace net.minecraft.src
{
    public abstract class EntityLiving : net.minecraft.src.Entity
    {
        SharpRandom SharpRandom = new SharpRandom();
        public EntityLiving(net.minecraft.src.World world)
            : base(world)
        {
            // Referenced classes of package net.minecraft.src:
            //            Entity, Vec3D, World, Material, 
            //            MathHelper, Block, StepSound, AxisAlignedBB, 
            //            NBTTagCompound
            field_9099_av = 20;
            renderYawOffset = 0.0F;
            prevRenderYawOffset = 0.0F;
            field_9120_aF = true;
            texture = "/mob/char.png";
            field_9118_aH = true;
            field_9117_aI = 0.0F;
            entityType = null;
            field_9115_aK = 1.0F;
            scoreValue = 0;
            field_9113_aM = 0.0F;
            isMultiplayerEntity = false;
            attackedAtYaw = 0.0F;
            deathTime = 0;
            attackTime = 0;
            unused_flag = false;
            field_9144_ba = -1;
            field_9143_bb = (float)(SharpRandom.NextDouble() * 0.89999997615814209D + 0.10000000149011612D
                );
            field_9134_bl = 0.0F;
            field_9133_bm = 0;
            age = 0;
            isJumping = false;
            defaultPitch = 0.0F;
            moveSpeed = 0.7F;
            numTicksToChaseTarget = 0;
            health = 10;
            preventEntitySpawning = true;
            field_9096_ay = (float)(SharpRandom.NextDouble() + 1.0D) * 0.01F;
            SetPosition(posX, posY, posZ);
            field_9098_aw = (float)SharpRandom.NextDouble() * 12398F;
            rotationYaw = (float)(SharpRandom.NextDouble() * 3.1415927410125732D * 2D);
            stepHeight = 0.5F;
        }

        protected internal override void EntityInit()
        {
        }

        public virtual bool CanEntityBeSeen(net.minecraft.src.Entity entity)
        {
            return worldObj.RayTraceBlocks(net.minecraft.src.Vec3D.CreateVector(posX, posY +
                (double)GetEyeHeight(), posZ), net.minecraft.src.Vec3D.CreateVector(entity.posX,
                entity.posY + (double)entity.GetEyeHeight(), entity.posZ)) == null;
        }

        public override bool CanBeCollidedWith()
        {
            return !isDead;
        }

        public override bool CanBePushed()
        {
            return !isDead;
        }

        public override float GetEyeHeight()
        {
            return height * 0.85F;
        }

        public virtual int GetTalkInterval()
        {
            return 80;
        }

        public virtual void PlayLivingSound()
        {
            string s = GetLivingSound();
            if (s != null)
            {
                worldObj.PlaySoundAtEntity(this, s, GetSoundVolume(), (rand.NextFloat() - rand.NextFloat
                    ()) * 0.2F + 1.0F);
            }
        }

        public override void OnEntityUpdate()
        {
            prevSwingProgress = swingProgress;
            base.OnEntityUpdate();
            if (rand.Next(1000) < livingSoundTime++)
            {
                livingSoundTime = -GetTalkInterval();
                PlayLivingSound();
            }
            if (IsEntityAlive() && IsEntityInsideOpaqueBlock())
            {
                AttackEntityFrom(null, 1);
            }
            if (isImmuneToFire || worldObj.singleplayerWorld)
            {
                fire = 0;
            }
            if (IsEntityAlive() && IsInsideOfMaterial(net.minecraft.src.Material.water) && !CanBreatheUnderwater
                ())
            {
                air--;
                if (air == -20)
                {
                    air = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        float f = rand.NextFloat() - rand.NextFloat();
                        float f1 = rand.NextFloat() - rand.NextFloat();
                        float f2 = rand.NextFloat() - rand.NextFloat();
                        worldObj.SpawnParticle("bubble", posX + (double)f, posY + (double)f1, posZ + (double
                            )f2, motionX, motionY, motionZ);
                    }
                    AttackEntityFrom(null, 2);
                }
                fire = 0;
            }
            else
            {
                if(air != 300) // CRAFTBUKKIT
                    air = maxAir;
            }
            field_9102_aX = field_9101_aY;
            if (attackTime > 0)
            {
                attackTime--;
            }
            if (hurtTime > 0)
            {
                hurtTime--;
            }
            if (field_9083_ac > 0)
            {
                field_9083_ac--;
            }
            if (health <= 0)
            {
                deathTime++;
                if (deathTime > 20)
                {
                    Func_6101_K();
                    SetEntityDead();
                    for (int j = 0; j < 20; j++)
                    {
                        double d = rand.NextGaussian() * 0.02D;
                        double d1 = rand.NextGaussian() * 0.02D;
                        double d2 = rand.NextGaussian() * 0.02D;
                        worldObj.SpawnParticle("explode", (posX + (double)(rand.NextFloat() * width * 2.0F
                            )) - (double)width, posY + (double)(rand.NextFloat() * height), (posZ + (double)
                            (rand.NextFloat() * width * 2.0F)) - (double)width, d, d1, d2);
                    }
                }
            }
            field_9121_aE = field_9122_aD;
            prevRenderYawOffset = renderYawOffset;
            prevRotationYaw = rotationYaw;
            prevRotationPitch = rotationPitch;
        }

        public virtual void SpawnExplosionParticle()
        {
            for (int i = 0; i < 20; i++)
            {
                double d = rand.NextGaussian() * 0.02D;
                double d1 = rand.NextGaussian() * 0.02D;
                double d2 = rand.NextGaussian() * 0.02D;
                double d3 = 10D;
                worldObj.SpawnParticle("explode", (posX + (double)(rand.NextFloat() * width * 2.0F
                    )) - (double)width - d * d3, (posY + (double)(rand.NextFloat() * height)) - d1 *
                     d3, (posZ + (double)(rand.NextFloat() * width * 2.0F)) - (double)width - d2 * d3
                    , d, d1, d2);
            }
        }

        public override void UpdateRidden()
        {
            base.UpdateRidden();
            field_9124_aB = field_9123_aC;
            field_9123_aC = 0.0F;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            OnLivingUpdate();
            double d = posX - prevPosX;
            double d1 = posZ - prevPosZ;
            float f = net.minecraft.src.MathHelper.Sqrt_double(d * d + d1 * d1);
            float f1 = renderYawOffset;
            float f2 = 0.0F;
            field_9124_aB = field_9123_aC;
            float f3 = 0.0F;
            if (f > 0.05F)
            {
                f3 = 1.0F;
                f2 = f * 3F;
                f1 = ((float)System.Math.Atan2(d1, d) * 180F) / 3.141593F - 90F;
            }
            if (swingProgress > 0.0F)
            {
                f1 = rotationYaw;
            }
            if (!onGround)
            {
                f3 = 0.0F;
            }
            field_9123_aC = field_9123_aC + (f3 - field_9123_aC) * 0.3F;
            float f4;
            for (f4 = f1 - renderYawOffset; f4 < -180F; f4 += 360F)
            {
            }
            for (; f4 >= 180F; f4 -= 360F)
            {
            }
            renderYawOffset += f4 * 0.3F;
            float f5;
            for (f5 = rotationYaw - renderYawOffset; f5 < -180F; f5 += 360F)
            {
            }
            for (; f5 >= 180F; f5 -= 360F)
            {
            }
            bool flag = f5 < -90F || f5 >= 90F;
            if (f5 < -75F)
            {
                f5 = -75F;
            }
            if (f5 >= 75F)
            {
                f5 = 75F;
            }
            renderYawOffset = rotationYaw - f5;
            if (f5 * f5 > 2500F)
            {
                renderYawOffset += f5 * 0.2F;
            }
            if (flag)
            {
                f2 *= -1F;
            }
            for (; rotationYaw - prevRotationYaw < -180F; prevRotationYaw -= 360F)
            {
            }
            for (; rotationYaw - prevRotationYaw >= 180F; prevRotationYaw += 360F)
            {
            }
            for (; renderYawOffset - prevRenderYawOffset < -180F; prevRenderYawOffset -= 360F)
            {
            }
            for (; renderYawOffset - prevRenderYawOffset >= 180F; prevRenderYawOffset += 360F)
            {
            }
            for (; rotationPitch - prevRotationPitch < -180F; prevRotationPitch -= 360F)
            {
            }
            for (; rotationPitch - prevRotationPitch >= 180F; prevRotationPitch += 360F)
            {
            }
            field_9122_aD += f2;
        }

        protected internal override void SetSize(float f, float f1)
        {
            base.SetSize(f, f1);
        }

        public virtual void Heal(int i)
        {
            if (health <= 0)
            {
                return;
            }
            health += i;
            if (health > 20)
            {
                health = 20;
            }
            field_9083_ac = field_9099_av / 2;
        }

        public override bool AttackEntityFrom(net.minecraft.src.Entity entity, int i)
        {
            if (worldObj.singleplayerWorld)
            {
                return false;
            }
            age = 0;
            if (health <= 0)
            {
                return false;
            }
            field_9141_bd = 1.5F;
            bool flag = true;
            if ((float)field_9083_ac > (float)field_9099_av / 2.0F)
            {
                if (i <= field_9133_bm)
                {
                    return false;
                }
                DamageEntity(i - field_9133_bm);
                field_9133_bm = i;
                flag = false;
            }
            else
            {
                field_9133_bm = i;
                prevHealth = health;
                field_9083_ac = field_9099_av;
                DamageEntity(i);
                hurtTime = maxHurtTime = 10;
            }
            attackedAtYaw = 0.0F;
            if (flag)
            {
                worldObj.SendTrackedEntityStatusUpdatePacket(this, unchecked((byte)2));
                SetBeenAttacked();
                if (entity != null)
                {
                    double d = entity.posX - posX;
                    double d1;
                    for (d1 = entity.posZ - posZ; d * d + d1 * d1 < 0.0001D; d1 = (SharpRandom.NextDouble() - SharpRandom.NextDouble()) * 0.01D)
                    {
                        d = (SharpRandom.NextDouble() - SharpRandom.NextDouble()) * 0.01D;
                    }
                    attackedAtYaw = (float)((System.Math.Atan2(d1, d) * 180D) / 3.1415927410125732D)
                        - rotationYaw;
                    KnockBack(entity, i, d, d1);
                }
                else
                {
                    attackedAtYaw = (int)(SharpRandom.NextDouble() * 2D) * 180;
                }
            }
            if (health <= 0)
            {
                if (flag)
                {
                    worldObj.PlaySoundAtEntity(this, GetDeathSound(), GetSoundVolume(), (rand.NextFloat
                        () - rand.NextFloat()) * 0.2F + 1.0F);
                }
                OnDeath(entity);
            }
            else
            {
                if (flag)
                {
                    worldObj.PlaySoundAtEntity(this, GetHurtSound(), GetSoundVolume(), (rand.NextFloat
                        () - rand.NextFloat()) * 0.2F + 1.0F);
                }
            }
            return true;
        }

        protected internal virtual void DamageEntity(int i)
        {
            health -= i;
        }

        protected internal virtual float GetSoundVolume()
        {
            return 1.0F;
        }

        protected internal virtual string GetLivingSound()
        {
            return null;
        }

        protected internal virtual string GetHurtSound()
        {
            return "random.hurt";
        }

        protected internal virtual string GetDeathSound()
        {
            return "random.hurt";
        }

        public virtual void KnockBack(net.minecraft.src.Entity entity, int i, double d, double
             d1)
        {
            float f = net.minecraft.src.MathHelper.Sqrt_double(d * d + d1 * d1);
            float f1 = 0.4F;
            motionX /= 2D;
            motionY /= 2D;
            motionZ /= 2D;
            motionX -= (d / (double)f) * (double)f1;
            motionY += 0.40000000596046448D;
            motionZ -= (d1 / (double)f) * (double)f1;
            if (motionY > 0.40000000596046448D)
            {
                motionY = 0.40000000596046448D;
            }
        }

        public virtual void OnDeath(net.minecraft.src.Entity entity)
        {
            if (scoreValue >= 0 && entity != null)
            {
                entity.AddToPlayerScore(this, scoreValue);
            }
            if (entity != null)
            {
                entity.UpdateKillStatistic(this);
            }
            unused_flag = true;
            if (!worldObj.singleplayerWorld)
            {
                DropFewItems();
            }
            worldObj.SendTrackedEntityStatusUpdatePacket(this, unchecked((byte)3));
        }

        protected internal virtual void DropFewItems()
        {
            int i = GetDropItemId();
            if (i > 0)
            {
                int j = rand.Next(3);
                for (int k = 0; k < j; k++)
                {
                    DropItem(i, 1);
                }
            }
        }

        protected internal virtual int GetDropItemId()
        {
            return 0;
        }

        protected internal override void Fall(float f)
        {
            base.Fall(f);
            int i = (int)System.Math.Ceiling(f - 3F);
            if (i > 0)
            {
                AttackEntityFrom(null, i);
                int j = worldObj.GetBlockId(net.minecraft.src.MathHelper.Floor_double(posX), net.minecraft.src.MathHelper
                    .Floor_double(posY - 0.20000000298023224D - (double)yOffset), net.minecraft.src.MathHelper
                    .Floor_double(posZ));
                if (j > 0)
                {
                    net.minecraft.src.StepSound stepsound = net.minecraft.src.Block.blocksList[j].stepSound;
                    worldObj.PlaySoundAtEntity(this, stepsound.Func_737_c(), stepsound.GetVolume() *
                        0.5F, stepsound.GetPitch() * 0.75F);
                }
            }
        }

        public virtual void MoveEntityWithHeading(float f, float f1)
        {
            if (IsInWater())
            {
                double d = posY;
                MoveFlying(f, f1, 0.02F);
                MoveEntity(motionX, motionY, motionZ);
                motionX *= 0.80000001192092896D;
                motionY *= 0.80000001192092896D;
                motionZ *= 0.80000001192092896D;
                motionY -= 0.02D;
                if (isCollidedHorizontally && IsOffsetPositionInLiquid(motionX, ((motionY + 0.60000002384185791D
                    ) - posY) + d, motionZ))
                {
                    motionY = 0.30000001192092896D;
                }
            }
            else
            {
                if (HandleLavaMovement())
                {
                    double d1 = posY;
                    MoveFlying(f, f1, 0.02F);
                    MoveEntity(motionX, motionY, motionZ);
                    motionX *= 0.5D;
                    motionY *= 0.5D;
                    motionZ *= 0.5D;
                    motionY -= 0.02D;
                    if (isCollidedHorizontally && IsOffsetPositionInLiquid(motionX, ((motionY + 0.60000002384185791D
                        ) - posY) + d1, motionZ))
                    {
                        motionY = 0.30000001192092896D;
                    }
                }
                else
                {
                    float f2 = 0.91F;
                    if (onGround)
                    {
                        f2 = 0.5460001F;
                        int i = worldObj.GetBlockId(net.minecraft.src.MathHelper.Floor_double(posX), net.minecraft.src.MathHelper
                            .Floor_double(boundingBox.minY) - 1, net.minecraft.src.MathHelper.Floor_double(posZ
                            ));
                        if (i > 0)
                        {
                            f2 = net.minecraft.src.Block.blocksList[i].slipperiness * 0.91F;
                        }
                    }
                    float f3 = 0.1627714F / (f2 * f2 * f2);
                    MoveFlying(f, f1, onGround ? 0.1F * f3 : 0.02F);
                    f2 = 0.91F;
                    if (onGround)
                    {
                        f2 = 0.5460001F;
                        int j = worldObj.GetBlockId(net.minecraft.src.MathHelper.Floor_double(posX), net.minecraft.src.MathHelper
                            .Floor_double(boundingBox.minY) - 1, net.minecraft.src.MathHelper.Floor_double(posZ
                            ));
                        if (j > 0)
                        {
                            f2 = net.minecraft.src.Block.blocksList[j].slipperiness * 0.91F;
                        }
                    }
                    if (IsOnLadder())
                    {
                        float f4 = 0.15F;
                        if (motionX < (double)(-f4))
                        {
                            motionX = -f4;
                        }
                        if (motionX > (double)f4)
                        {
                            motionX = f4;
                        }
                        if (motionZ < (double)(-f4))
                        {
                            motionZ = -f4;
                        }
                        if (motionZ > (double)f4)
                        {
                            motionZ = f4;
                        }
                        fallDistance = 0.0F;
                        if (motionY < -0.14999999999999999D)
                        {
                            motionY = -0.14999999999999999D;
                        }
                        if (IsSneaking() && motionY < 0.0D)
                        {
                            motionY = 0.0D;
                        }
                    }
                    MoveEntity(motionX, motionY, motionZ);
                    if (isCollidedHorizontally && IsOnLadder())
                    {
                        motionY = 0.20000000000000001D;
                    }
                    motionY -= 0.080000000000000002D;
                    motionY *= 0.98000001907348633D;
                    motionX *= f2;
                    motionZ *= f2;
                }
            }
            field_9142_bc = field_9141_bd;
            double d2 = posX - prevPosX;
            double d3 = posZ - prevPosZ;
            float f5 = net.minecraft.src.MathHelper.Sqrt_double(d2 * d2 + d3 * d3) * 4F;
            if (f5 > 1.0F)
            {
                f5 = 1.0F;
            }
            field_9141_bd += (f5 - field_9141_bd) * 0.4F;
            field_386_ba += field_9141_bd;
        }

        public virtual bool IsOnLadder()
        {
            int i = net.minecraft.src.MathHelper.Floor_double(posX);
            int j = net.minecraft.src.MathHelper.Floor_double(boundingBox.minY);
            int k = net.minecraft.src.MathHelper.Floor_double(posZ);
            return worldObj.GetBlockId(i, j, k) == net.minecraft.src.Block.ladder.blockID;
        }

        protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
             nbttagcompound)
        {
            nbttagcompound.SetShort("Health", (short)health);
            nbttagcompound.SetShort("HurtTime", (short)hurtTime);
            nbttagcompound.SetShort("DeathTime", (short)deathTime);
            nbttagcompound.SetShort("AttackTime", (short)attackTime);
        }

        protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
             nbttagcompound)
        {
            health = nbttagcompound.GetShort("Health");
            if (!nbttagcompound.HasKey("Health"))
            {
                health = 10;
            }
            hurtTime = nbttagcompound.GetShort("HurtTime");
            deathTime = nbttagcompound.GetShort("DeathTime");
            attackTime = nbttagcompound.GetShort("AttackTime");
        }

        public override bool IsEntityAlive()
        {
            return !isDead && health > 0;
        }

        public virtual bool CanBreatheUnderwater()
        {
            return false;
        }

        public virtual void OnLivingUpdate()
        {
            if (field_9140_bf > 0)
            {
                double d = posX + (field_9139_bg - posX) / (double)field_9140_bf;
                double d1 = posY + (field_9138_bh - posY) / (double)field_9140_bf;
                double d2 = posZ + (field_9137_bi - posZ) / (double)field_9140_bf;
                double d3;
                for (d3 = field_9136_bj - (double)rotationYaw; d3 < -180D; d3 += 360D)
                {
                }
                for (; d3 >= 180D; d3 -= 360D)
                {
                }
                rotationYaw += (float)(d3 / (double)field_9140_bf);
                rotationPitch += (float)((field_9135_bk - (double)rotationPitch) / (double)field_9140_bf);
                field_9140_bf--;
                SetPosition(d, d1, d2);
                SetRotation(rotationYaw, rotationPitch);
                System.Collections.Generic.List<AxisAlignedBB> list1 = worldObj.GetCollidingBoundingBoxes(this, boundingBox
                    .GetInsetBoundingBox(0.03125D, 0.0D, 0.03125D));
                if (list1.Count > 0)
                {
                    double d4 = 0.0D;
                    for (int j = 0; j < list1.Count; j++)
                    {
                        net.minecraft.src.AxisAlignedBB axisalignedbb = (net.minecraft.src.AxisAlignedBB)
                            list1[j];
                        if (axisalignedbb.maxY > d4)
                        {
                            d4 = axisalignedbb.maxY;
                        }
                    }
                    d1 += d4 - boundingBox.minY;
                    SetPosition(d, d1, d2);
                }
            }
            if (IsMovementBlocked())
            {
                isJumping = false;
                moveStrafing = 0.0F;
                moveForward = 0.0F;
                randomYawVelocity = 0.0F;
            }
            else
            {
                if (!isMultiplayerEntity)
                {
                    UpdatePlayerActionState();
                }
            }
            bool flag = IsInWater();
            bool flag1 = HandleLavaMovement();
            if (isJumping)
            {
                if (flag)
                {
                    motionY += 0.039999999105930328D;
                }
                else
                {
                    if (flag1)
                    {
                        motionY += 0.039999999105930328D;
                    }
                    else
                    {
                        if (onGround)
                        {
                            Jump();
                        }
                    }
                }
            }
            moveStrafing *= 0.98F;
            moveForward *= 0.98F;
            randomYawVelocity *= 0.9F;
            MoveEntityWithHeading(moveStrafing, moveForward);
            System.Collections.Generic.List<Entity> list = worldObj.GetEntitiesWithinAABBExcludingEntity(this
                , boundingBox.Expand(0.20000000298023224D, 0.0D, 0.20000000298023224D));
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    net.minecraft.src.Entity entity = (net.minecraft.src.Entity)list[i];

                    // CRAFTBUKKIT start - Only handle mob (non-player) collisions every other tick
                    if (entity is EntityLiving && !(this is EntityPlayer) && (this.ticksExisted & 1) == 1)
                        continue;
                    // CRAFTBUKKIT end

                    if (entity.CanBePushed())
                        entity.ApplyEntityCollision(this);
                }
            }
        }

        protected internal virtual bool IsMovementBlocked()
        {
            return health <= 0;
        }

        protected internal virtual void Jump()
        {
            motionY = 0.41999998688697815D;
        }

        protected internal virtual bool Func_25020_s()
        {
            return true;
        }

        protected internal virtual void Func_27013_Q()
        {
            net.minecraft.src.EntityPlayer entityplayer = worldObj.GetClosestPlayerToEntity(this
                , -1D);
            if (Func_25020_s() && entityplayer != null)
            {
                double d = ((net.minecraft.src.Entity)(entityplayer)).posX - posX;
                double d1 = ((net.minecraft.src.Entity)(entityplayer)).posY - posY;
                double d2 = ((net.minecraft.src.Entity)(entityplayer)).posZ - posZ;
                double d3 = d * d + d1 * d1 + d2 * d2;
                if (d3 > 16384D)
                {
                    SetEntityDead();
                }
                if (age > 600 && rand.Next(800) == 0)
                {
                    if (d3 < 1024D)
                    {
                        age = 0;
                    }
                    else
                    {
                        SetEntityDead();
                    }
                }
            }
        }

        protected internal virtual void UpdatePlayerActionState()
        {
            age++;
            net.minecraft.src.EntityPlayer entityplayer = worldObj.GetClosestPlayerToEntity(this
                , -1D);
            Func_27013_Q();
            moveStrafing = 0.0F;
            moveForward = 0.0F;
            float f = 8F;
            if (rand.NextFloat() < 0.02F)
            {
                net.minecraft.src.EntityPlayer entityplayer1 = worldObj.GetClosestPlayerToEntity(
                    this, f);
                if (entityplayer1 != null)
                {
                    currentTarget = entityplayer1;
                    numTicksToChaseTarget = 10 + rand.Next(20);
                }
                else
                {
                    randomYawVelocity = (rand.NextFloat() - 0.5F) * 20F;
                }
            }
            if (currentTarget != null)
            {
                FaceEntity(currentTarget, 10F, Func_25018_n_());
                if (numTicksToChaseTarget-- <= 0 || currentTarget.isDead || currentTarget.GetDistanceSqToEntity
                    (this) > (double)(f * f))
                {
                    currentTarget = null;
                }
            }
            else
            {
                if (rand.NextFloat() < 0.05F)
                {
                    randomYawVelocity = (rand.NextFloat() - 0.5F) * 20F;
                }
                rotationYaw += randomYawVelocity;
                rotationPitch = defaultPitch;
            }
            bool flag = IsInWater();
            bool flag1 = HandleLavaMovement();
            if (flag || flag1)
            {
                isJumping = rand.NextFloat() < 0.8F;
            }
        }

        protected internal virtual int Func_25018_n_()
        {
            return 40;
        }

        public virtual void FaceEntity(net.minecraft.src.Entity entity, float f, float f1
            )
        {
            double d = entity.posX - posX;
            double d2 = entity.posZ - posZ;
            double d1;
            if (entity is net.minecraft.src.EntityLiving)
            {
                net.minecraft.src.EntityLiving entityliving = (net.minecraft.src.EntityLiving)entity;
                d1 = (posY + (double)GetEyeHeight()) - (entityliving.posY + (double)entityliving.
                    GetEyeHeight());
            }
            else
            {
                d1 = (entity.boundingBox.minY + entity.boundingBox.maxY) / 2D - (posY + (double)GetEyeHeight
                    ());
            }
            double d3 = net.minecraft.src.MathHelper.Sqrt_double(d * d + d2 * d2);
            float f2 = (float)((System.Math.Atan2(d2, d) * 180D) / 3.1415927410125732D) - 90F;
            float f3 = (float)(-((System.Math.Atan2(d1, d3) * 180D) / 3.1415927410125732D));
            rotationPitch = -UpdateRotation(rotationPitch, f3, f1);
            rotationYaw = UpdateRotation(rotationYaw, f2, f);
        }

        public virtual bool Func_25021_O()
        {
            return currentTarget != null;
        }

        public virtual net.minecraft.src.Entity GetCurrentTarget()
        {
            return currentTarget;
        }

        private float UpdateRotation(float f, float f1, float f2)
        {
            float f3;
            for (f3 = f1 - f; f3 < -180F; f3 += 360F)
            {
            }
            for (; f3 >= 180F; f3 -= 360F)
            {
            }
            if (f3 > f2)
            {
                f3 = f2;
            }
            if (f3 < -f2)
            {
                f3 = -f2;
            }
            return f + f3;
        }

        public virtual void Func_6101_K()
        {
        }

        public virtual bool GetCanSpawnHere()
        {
            return worldObj.CheckIfAABBIsClear(boundingBox) && worldObj.GetCollidingBoundingBoxes
                (this, boundingBox).Count == 0 && !worldObj.GetIsAnyLiquid(boundingBox);
        }

        protected internal override void Kill()
        {
            AttackEntityFrom(null, 4);
        }

        public override net.minecraft.src.Vec3D GetLookVec()
        {
            return GetLook(1.0F);
        }

        public virtual net.minecraft.src.Vec3D GetLook(float f)
        {
            if (f == 1.0F)
            {
                float f1 = net.minecraft.src.MathHelper.Cos(-rotationYaw * 0.01745329F - 3.141593F
                    );
                float f3 = net.minecraft.src.MathHelper.Sin(-rotationYaw * 0.01745329F - 3.141593F
                    );
                float f5 = -net.minecraft.src.MathHelper.Cos(-rotationPitch * 0.01745329F);
                float f7 = net.minecraft.src.MathHelper.Sin(-rotationPitch * 0.01745329F);
                return net.minecraft.src.Vec3D.CreateVector(f3 * f5, f7, f1 * f5);
            }
            else
            {
                float f2 = prevRotationPitch + (rotationPitch - prevRotationPitch) * f;
                float f4 = prevRotationYaw + (rotationYaw - prevRotationYaw) * f;
                float f6 = net.minecraft.src.MathHelper.Cos(-f4 * 0.01745329F - 3.141593F);
                float f8 = net.minecraft.src.MathHelper.Sin(-f4 * 0.01745329F - 3.141593F);
                float f9 = -net.minecraft.src.MathHelper.Cos(-f2 * 0.01745329F);
                float f10 = net.minecraft.src.MathHelper.Sin(-f2 * 0.01745329F);
                return net.minecraft.src.Vec3D.CreateVector(f8 * f9, f10, f6 * f9);
            }
        }

        public virtual int GetMaxSpawnedInChunk()
        {
            return 4;
        }

        public virtual bool IsSleeping()
        {
            return false;
        }

        public int field_9099_av;

        public float field_9098_aw;

        public float field_9096_ay;

        public float renderYawOffset;

        public float prevRenderYawOffset;

        protected internal float field_9124_aB;

        protected internal float field_9123_aC;

        protected internal float field_9122_aD;

        protected internal float field_9121_aE;

        protected internal bool field_9120_aF;

        protected internal string texture;

        protected internal bool field_9118_aH;

        protected internal float field_9117_aI;

        protected internal string entityType;

        protected internal float field_9115_aK;

        protected internal int scoreValue;

        protected internal float field_9113_aM;

        public bool isMultiplayerEntity;

        public float prevSwingProgress;

        public float swingProgress;

        public int health;

        public int prevHealth;

        private int livingSoundTime;

        public int hurtTime;

        public int maxHurtTime;

        public float attackedAtYaw;

        public int deathTime;

        public int attackTime;

        public float field_9102_aX;

        public float field_9101_aY;

        protected internal bool unused_flag;

        public int field_9144_ba;

        public float field_9143_bb;

        public float field_9142_bc;

        public float field_9141_bd;

        public float field_386_ba;

        protected internal int field_9140_bf;

        protected internal double field_9139_bg;

        protected internal double field_9138_bh;

        protected internal double field_9137_bi;

        protected internal double field_9136_bj;

        protected internal double field_9135_bk;

        internal float field_9134_bl;

        protected internal int field_9133_bm;

        protected internal int age;

        protected internal float moveStrafing;

        protected internal float moveForward;

        protected internal float randomYawVelocity;

        protected internal bool isJumping;

        protected internal float defaultPitch;

        protected internal float moveSpeed;

        private net.minecraft.src.Entity currentTarget;

        protected internal int numTicksToChaseTarget;
    }
}
