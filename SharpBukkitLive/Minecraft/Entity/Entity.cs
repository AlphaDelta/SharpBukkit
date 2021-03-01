// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
    public abstract class Entity
    {
        public Entity(net.minecraft.src.World world)
        {
            // Referenced classes of package net.minecraft.src:
            //            AxisAlignedBB, DataWatcher, MathHelper, World, 
            //            Block, StepSound, Material, BlockFluid, 
            //            NBTTagCompound, NBTTagList, NBTTagDouble, NBTTagFloat, 
            //            EntityList, ItemStack, EntityItem, EntityPlayer, 
            //            Vec3D, EntityLightningBolt, EntityLiving
            entityId = nextEntityID++;
            renderDistanceWeight = 1.0D;
            preventEntitySpawning = false;
            onGround = false;
            isCollided = false;
            beenAttacked = false;
            field_9077_F = true;
            isDead = false;
            yOffset = 0.0F;
            width = 0.6F;
            height = 1.8F;
            prevDistanceWalkedModified = 0.0F;
            distanceWalkedModified = 0.0F;
            fallDistance = 0.0F;
            nextStepDistance = 1;
            ySize = 0.0F;
            stepHeight = 0.0F;
            noClip = false;
            entityCollisionReduction = 0.0F;
            rand = new SharpBukkitLive.SharpBukkit.SharpRandom();
            ticksExisted = 0;
            fireResistance = 1;
            fire = 0;
            maxAir = 300;
            inWater = false;
            field_9083_ac = 0;
            air = 300;
            firstUpdate = true;
            isImmuneToFire = false;
            dataWatcher = new net.minecraft.src.DataWatcher();
            field_31001_bF = 0.0F;
            addedToChunk = false;
            worldObj = world;
            SetPosition(0.0D, 0.0D, 0.0D);
            dataWatcher.AddObject(0, unchecked((byte)0));
            EntityInit();
        }

        protected internal abstract void EntityInit();

        public virtual net.minecraft.src.DataWatcher GetDataWatcher()
        {
            return dataWatcher;
        }

        public override bool Equals(object obj)
        {
            if (obj is net.minecraft.src.Entity)
            {
                return ((net.minecraft.src.Entity)obj).entityId == entityId;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return entityId;
        }

        public virtual void SetEntityDead()
        {
            isDead = true;
        }

        protected internal virtual void SetSize(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        protected internal virtual void SetRotation(float yaw, float pitch)
        {
            // CRAFTBUKKIT/SHARPBUKKIT start
            if (float.IsNaN(yaw)) yaw = 0;
            if (float.IsNaN(pitch)) pitch = 0;

            if (float.IsInfinity(yaw))
            {
                yaw = 0;

                if (this is EntityPlayerMP)
                {
                    Logger.GetLogger().Warning($"Player {((EntityPlayerMP)this).playerNetServerHandler.GetUsername()} ({((EntityPlayerMP)this).playerNetServerHandler.netManager.GetRemoteAddress()}) was caught trying to crash the server with an invalid yaw");
                    ((EntityPlayerMP)this).playerNetServerHandler.KickPlayer("Nope");
                }
            }
            if (float.IsInfinity(pitch))
            {
                pitch = 0;

                if (this is EntityPlayerMP)
                {
                    Logger.GetLogger().Warning($"Player {((EntityPlayerMP)this).playerNetServerHandler.GetUsername()} ({((EntityPlayerMP)this).playerNetServerHandler.netManager.GetRemoteAddress()}) was caught trying to crash the server with an invalid pitch");
                    ((EntityPlayerMP)this).playerNetServerHandler.KickPlayer("Nope");
                }
            }
            // CRAFTBUKKIT/SHARPBUKKIT end

            rotationYaw = yaw % 360F;
            rotationPitch = pitch % 360F;
        }

        public virtual void SetPosition(double x, double y, double z)
        {
            posX = x;
            posY = y;
            posZ = z;
            float f = width / 2.0F;
            float f1 = height;
            boundingBox.SetBounds(x - (double)f, (y - (double)yOffset) + (double)ySize, z -
                 (double)f, x + (double)f, (y - (double)yOffset) + (double)ySize + (double)f1,
                z + (double)f);
        }

        public virtual void OnUpdate()
        {
            OnEntityUpdate();
        }

        public virtual void OnEntityUpdate()
        {
            if (ridingEntity != null && ridingEntity.isDead)
            {
                ridingEntity = null;
            }
            ticksExisted++;
            prevDistanceWalkedModified = distanceWalkedModified;
            prevPosX = posX;
            prevPosY = posY;
            prevPosZ = posZ;
            prevRotationPitch = rotationPitch;
            prevRotationYaw = rotationYaw;
            if (HandleWaterMovement())
            {
                if (!inWater && !firstUpdate)
                {
                    float f = net.minecraft.src.MathHelper.Sqrt_double(motionX * motionX * 0.20000000298023224D
                         + motionY * motionY + motionZ * motionZ * 0.20000000298023224D) * 0.2F;
                    if (f > 1.0F)
                    {
                        f = 1.0F;
                    }
                    worldObj.PlaySoundAtEntity(this, "random.splash", f, 1.0F + (rand.NextFloat() - rand
                        .NextFloat()) * 0.4F);
                    float f1 = net.minecraft.src.MathHelper.Floor_double(boundingBox.minY);
                    for (int i = 0; (float)i < 1.0F + width * 20F; i++)
                    {
                        float f2 = (rand.NextFloat() * 2.0F - 1.0F) * width;
                        float f4 = (rand.NextFloat() * 2.0F - 1.0F) * width;
                        worldObj.SpawnParticle("bubble", posX + (double)f2, f1 + 1.0F, posZ + (double)f4,
                            motionX, motionY - (double)(rand.NextFloat() * 0.2F), motionZ);
                    }
                    for (int j = 0; (float)j < 1.0F + width * 20F; j++)
                    {
                        float f3 = (rand.NextFloat() * 2.0F - 1.0F) * width;
                        float f5 = (rand.NextFloat() * 2.0F - 1.0F) * width;
                        worldObj.SpawnParticle("splash", posX + (double)f3, f1 + 1.0F, posZ + (double)f5,
                            motionX, motionY, motionZ);
                    }
                }
                fallDistance = 0.0F;
                inWater = true;
                fire = 0;
            }
            else
            {
                inWater = false;
            }
            if (worldObj.singleplayerWorld)
            {
                fire = 0;
            }
            else
            {
                if (fire > 0)
                {
                    if (isImmuneToFire)
                    {
                        fire -= 4;
                        if (fire < 0)
                        {
                            fire = 0;
                        }
                    }
                    else
                    {
                        if (fire % 20 == 0)
                        {
                            AttackEntityFrom(null, 1);
                        }
                        fire--;
                    }
                }
            }
            if (HandleLavaMovement())
            {
                SetOnFireFromLava();
            }
            if (posY < -64D)
            {
                Kill();
            }
            if (!worldObj.singleplayerWorld)
            {
                SetFlag(0, fire > 0);
                SetFlag(2, ridingEntity != null);
            }
            firstUpdate = false;
        }

        protected internal virtual void SetOnFireFromLava()
        {
            if (!isImmuneToFire)
            {
                AttackEntityFrom(null, 4);
                fire = 600;
            }
        }

        protected internal virtual void Kill()
        {
            SetEntityDead();
        }

        public virtual bool IsOffsetPositionInLiquid(double d, double d1, double d2)
        {
            net.minecraft.src.AxisAlignedBB axisalignedbb = boundingBox.GetOffsetBoundingBox(d, d1, d2);
            List<AxisAlignedBB> list = worldObj.GetCollidingBoundingBoxes(this, axisalignedbb);
            if (list.Count > 0)
            {
                return false;
            }
            return !worldObj.GetIsAnyLiquid(axisalignedbb);
        }

        public virtual void MoveEntity(double d, double d1, double d2)
        {
            if (d == 0 && d1 == 0 && d2 == 0) return; // CRAFTBUKKIT
            if (noClip)
            {
                boundingBox.Offset(d, d1, d2);
                posX = (boundingBox.minX + boundingBox.maxX) / 2D;
                posY = (boundingBox.minY + (double)yOffset) - (double)ySize;
                posZ = (boundingBox.minZ + boundingBox.maxZ) / 2D;
                return;
            }
            ySize *= 0.4F;
            double d3 = posX;
            double d4 = posZ;
            if (field_27012_bb)
            {
                field_27012_bb = false;
                d *= 0.25D;
                d1 *= 0.05000000074505806D;
                d2 *= 0.25D;
                motionX = 0.0D;
                motionY = 0.0D;
                motionZ = 0.0D;
            }
            double d5 = d;
            double d6 = d1;
            double d7 = d2;
            net.minecraft.src.AxisAlignedBB axisalignedbb = boundingBox.Copy();
            bool flag = onGround && IsSneaking();
            if (flag)
            {
                double d8 = 0.050000000000000003D;
                for (; d != 0.0D && worldObj.GetCollidingBoundingBoxes(this, boundingBox.GetOffsetBoundingBox
                    (d, -1D, 0.0D)).Count == 0; d5 = d)
                {
                    if (d < d8 && d >= -d8)
                    {
                        d = 0.0D;
                        continue;
                    }
                    if (d > 0.0D)
                    {
                        d -= d8;
                    }
                    else
                    {
                        d += d8;
                    }
                }
                for (; d2 != 0.0D && worldObj.GetCollidingBoundingBoxes(this, boundingBox.GetOffsetBoundingBox
                    (0.0D, -1D, d2)).Count == 0; d7 = d2)
                {
                    if (d2 < d8 && d2 >= -d8)
                    {
                        d2 = 0.0D;
                        continue;
                    }
                    if (d2 > 0.0D)
                    {
                        d2 -= d8;
                    }
                    else
                    {
                        d2 += d8;
                    }
                }
            }
            List<AxisAlignedBB> list = worldObj.GetCollidingBoundingBoxes(this, boundingBox
                .AddCoord(d, d1, d2));
            for (int i = 0; i < list.Count; i++)
            {
                d1 = ((net.minecraft.src.AxisAlignedBB)list[i]).CalculateYOffset(boundingBox, d1);
            }
            boundingBox.Offset(0.0D, d1, 0.0D);
            if (!field_9077_F && d6 != d1)
            {
                d = d1 = d2 = 0.0D;
            }
            bool flag1 = onGround || d6 != d1 && d6 < 0.0D;
            for (int j = 0; j < list.Count; j++)
            {
                d = ((net.minecraft.src.AxisAlignedBB)list[j]).CalculateXOffset(boundingBox, d);
            }
            boundingBox.Offset(d, 0.0D, 0.0D);
            if (!field_9077_F && d5 != d)
            {
                d = d1 = d2 = 0.0D;
            }
            for (int k = 0; k < list.Count; k++)
            {
                d2 = ((net.minecraft.src.AxisAlignedBB)list[k]).CalculateZOffset(boundingBox, d2);
            }
            boundingBox.Offset(0.0D, 0.0D, d2);
            if (!field_9077_F && d7 != d2)
            {
                d = d1 = d2 = 0.0D;
            }
            if (stepHeight > 0.0F && flag1 && (flag || ySize < 0.05F) && (d5 != d || d7 != d2
                ))
            {
                double d9 = d;
                double d11 = d1;
                double d13 = d2;
                d = d5;
                d1 = stepHeight;
                d2 = d7;
                net.minecraft.src.AxisAlignedBB axisalignedbb1 = boundingBox.Copy();
                boundingBox.SetBB(axisalignedbb);
                List<AxisAlignedBB> list1 = worldObj.GetCollidingBoundingBoxes(this, boundingBox
                    .AddCoord(d, d1, d2));
                for (int j2 = 0; j2 < list1.Count; j2++)
                {
                    d1 = ((net.minecraft.src.AxisAlignedBB)list1[j2]).CalculateYOffset(boundingBox, d1
                        );
                }
                boundingBox.Offset(0.0D, d1, 0.0D);
                if (!field_9077_F && d6 != d1)
                {
                    d = d1 = d2 = 0.0D;
                }
                for (int k2 = 0; k2 < list1.Count; k2++)
                {
                    d = ((net.minecraft.src.AxisAlignedBB)list1[k2]).CalculateXOffset(boundingBox, d);
                }
                boundingBox.Offset(d, 0.0D, 0.0D);
                if (!field_9077_F && d5 != d)
                {
                    d = d1 = d2 = 0.0D;
                }
                for (int l2 = 0; l2 < list1.Count; l2++)
                {
                    d2 = ((net.minecraft.src.AxisAlignedBB)list1[l2]).CalculateZOffset(boundingBox, d2
                        );
                }
                boundingBox.Offset(0.0D, 0.0D, d2);
                if (!field_9077_F && d7 != d2)
                {
                    d = d1 = d2 = 0.0D;
                }
                if (!field_9077_F && d6 != d1)
                {
                    d = d1 = d2 = 0.0D;
                }
                else
                {
                    d1 = -stepHeight;
                    for (int i3 = 0; i3 < list1.Count; i3++)
                    {
                        d1 = ((net.minecraft.src.AxisAlignedBB)list1[i3]).CalculateYOffset(boundingBox, d1
                            );
                    }
                    boundingBox.Offset(0.0D, d1, 0.0D);
                }
                if (d9 * d9 + d13 * d13 >= d * d + d2 * d2)
                {
                    d = d9;
                    d1 = d11;
                    d2 = d13;
                    boundingBox.SetBB(axisalignedbb1);
                }
                else
                {
                    double d14 = boundingBox.minY - (double)(int)boundingBox.minY;
                    if (d14 > 0.0D)
                    {
                        ySize += (float)(d14 + 0.01D);
                    }
                }
            }
            posX = (boundingBox.minX + boundingBox.maxX) / 2D;
            posY = (boundingBox.minY + (double)yOffset) - (double)ySize;
            posZ = (boundingBox.minZ + boundingBox.maxZ) / 2D;
            isCollidedHorizontally = d5 != d || d7 != d2;
            isCollidedVertically = d6 != d1;
            onGround = d6 != d1 && d6 < 0.0D;
            isCollided = isCollidedHorizontally || isCollidedVertically;
            UpdateFallState(d1, onGround);
            if (d5 != d)
            {
                motionX = 0.0D;
            }
            if (d6 != d1)
            {
                motionY = 0.0D;
            }
            if (d7 != d2)
            {
                motionZ = 0.0D;
            }
            double d10 = posX - d3;
            double d12 = posZ - d4;
            if (Func_25017_l() && !flag && ridingEntity == null)
            {
                distanceWalkedModified += (float)((double)net.minecraft.src.MathHelper.Sqrt_double(d10 * d10 + d12 * d12) * 0.59999999999999998D);
                int l = net.minecraft.src.MathHelper.Floor_double(posX);
                int j1 = net.minecraft.src.MathHelper.Floor_double(posY - 0.20000000298023224D -
                    (double)yOffset);
                int l1 = net.minecraft.src.MathHelper.Floor_double(posZ);
                int j3 = worldObj.GetBlockId(l, j1, l1);
                if (worldObj.GetBlockId(l, j1 - 1, l1) == net.minecraft.src.Block.FENCE.blockID)
                {
                    j3 = worldObj.GetBlockId(l, j1 - 1, l1);
                }
                if (distanceWalkedModified > (float)nextStepDistance && j3 > 0)
                {
                    nextStepDistance++;
                    net.minecraft.src.StepSound stepsound = net.minecraft.src.Block.blocksList[j3].stepSound;
                    if (worldObj.GetBlockId(l, j1 + 1, l1) == net.minecraft.src.Block.SNOW.blockID)
                    {
                        stepsound = net.minecraft.src.Block.SNOW.stepSound;
                        worldObj.PlaySoundAtEntity(this, stepsound.Func_737_c(), stepsound.GetVolume() *
                            0.15F, stepsound.GetPitch());
                    }
                    else
                    {
                        if (!net.minecraft.src.Block.blocksList[j3].blockMaterial.GetIsLiquid())
                        {
                            worldObj.PlaySoundAtEntity(this, stepsound.Func_737_c(), stepsound.GetVolume() *
                                0.15F, stepsound.GetPitch());
                        }
                    }
                    net.minecraft.src.Block.blocksList[j3].OnEntityWalking(worldObj, l, j1, l1, this);
                }
            }
            int i1 = net.minecraft.src.MathHelper.Floor_double(boundingBox.minX + 0.001D);
            int k1 = net.minecraft.src.MathHelper.Floor_double(boundingBox.minY + 0.001D);
            int i2 = net.minecraft.src.MathHelper.Floor_double(boundingBox.minZ + 0.001D);
            int k3 = net.minecraft.src.MathHelper.Floor_double(boundingBox.maxX - 0.001D);
            int l3 = net.minecraft.src.MathHelper.Floor_double(boundingBox.maxY - 0.001D);
            int i4 = net.minecraft.src.MathHelper.Floor_double(boundingBox.maxZ - 0.001D);
            if (worldObj.CheckChunksExist(i1, k1, i2, k3, l3, i4))
            {
                for (int j4 = i1; j4 <= k3; j4++)
                {
                    for (int k4 = k1; k4 <= l3; k4++)
                    {
                        for (int l4 = i2; l4 <= i4; l4++)
                        {
                            int i5 = worldObj.GetBlockId(j4, k4, l4);
                            if (i5 > 0)
                            {
                                net.minecraft.src.Block.blocksList[i5].OnEntityCollidedWithBlock(worldObj, j4, k4
                                    , l4, this);
                            }
                        }
                    }
                }
            }
            bool flag2 = Func_27008_Y();
            if (worldObj.IsBoundingBoxBurning(boundingBox.GetInsetBoundingBox(0.001D, 0.001D,
                0.001D)))
            {
                DealFireDamage(1);
                if (!flag2)
                {
                    fire++;
                    if (fire == 0)
                    {
                        fire = 300;
                    }
                }
            }
            else
            {
                if (fire <= 0)
                {
                    fire = -fireResistance;
                }
            }
            if (flag2 && fire > 0)
            {
                worldObj.PlaySoundAtEntity(this, "random.fizz", 0.7F, 1.6F + (rand.NextFloat() -
                    rand.NextFloat()) * 0.4F);
                fire = -fireResistance;
            }
        }

        protected internal virtual bool Func_25017_l()
        {
            return true;
        }

        protected internal virtual void UpdateFallState(double d, bool flag)
        {
            if (flag)
            {
                if (fallDistance > 0.0F)
                {
                    Fall(fallDistance);
                    fallDistance = 0.0F;
                }
            }
            else
            {
                if (d < 0.0D)
                {
                    fallDistance -= (float)d;
                }
            }
        }

        public virtual net.minecraft.src.AxisAlignedBB GetBoundingBox()
        {
            return null;
        }

        protected internal virtual void DealFireDamage(int i)
        {
            if (!isImmuneToFire)
            {
                AttackEntityFrom(null, i);
            }
        }

        protected internal virtual void Fall(float f)
        {
            if (riddenByEntity != null)
            {
                riddenByEntity.Fall(f);
            }
        }

        public virtual bool Func_27008_Y()
        {
            return inWater || worldObj.CanLightningStrikeAt(net.minecraft.src.MathHelper.Floor_double
                (posX), net.minecraft.src.MathHelper.Floor_double(posY), net.minecraft.src.MathHelper
                .Floor_double(posZ));
        }

        public virtual bool IsInWater()
        {
            return inWater;
        }

        public virtual bool HandleWaterMovement()
        {
            return worldObj.HandleMaterialAcceleration(boundingBox.Expand(0.0D, -0.40000000596046448D
                , 0.0D).GetInsetBoundingBox(0.001D, 0.001D, 0.001D), net.minecraft.src.Material.
                water, this);
        }

        public virtual bool IsInsideOfMaterial(net.minecraft.src.Material material)
        {
            double d = posY + (double)GetEyeHeight();
            int i = net.minecraft.src.MathHelper.Floor_double(posX);
            int j = net.minecraft.src.MathHelper.Floor_float(net.minecraft.src.MathHelper.Floor_double
                (d));
            int k = net.minecraft.src.MathHelper.Floor_double(posZ);
            int l = worldObj.GetBlockId(i, j, k);
            if (l != 0 && net.minecraft.src.Block.blocksList[l].blockMaterial == material)
            {
                float f = net.minecraft.src.BlockFluid.SetFluidHeight(worldObj.GetBlockMetadata(i
                    , j, k)) - 0.1111111F;
                float f1 = (float)(j + 1) - f;
                return d < (double)f1;
            }
            else
            {
                return false;
            }
        }

        public virtual float GetEyeHeight()
        {
            return 0.0F;
        }

        public virtual bool HandleLavaMovement()
        {
            return worldObj.IsMaterialInBB(boundingBox.Expand(-0.10000000149011612D, -0.40000000596046448D
                , -0.10000000149011612D), net.minecraft.src.Material.lava);
        }

        public virtual void MoveFlying(float f, float f1, float f2)
        {
            float f3 = net.minecraft.src.MathHelper.Sqrt_float(f * f + f1 * f1);
            if (f3 < 0.01F)
            {
                return;
            }
            if (f3 < 1.0F)
            {
                f3 = 1.0F;
            }
            f3 = f2 / f3;
            f *= f3;
            f1 *= f3;
            float f4 = net.minecraft.src.MathHelper.Sin((rotationYaw * 3.141593F) / 180F);
            float f5 = net.minecraft.src.MathHelper.Cos((rotationYaw * 3.141593F) / 180F);
            motionX += f * f5 - f1 * f4;
            motionZ += f1 * f5 + f * f4;
        }

        public virtual float GetEntityBrightness(float f)
        {
            int i = net.minecraft.src.MathHelper.Floor_double(posX);
            double d = (boundingBox.maxY - boundingBox.minY) * 0.66000000000000003D;
            int j = net.minecraft.src.MathHelper.Floor_double((posY - (double)yOffset) + d);
            int k = net.minecraft.src.MathHelper.Floor_double(posZ);
            if (worldObj.CheckChunksExist(net.minecraft.src.MathHelper.Floor_double(boundingBox
                .minX), net.minecraft.src.MathHelper.Floor_double(boundingBox.minY), net.minecraft.src.MathHelper
                .Floor_double(boundingBox.minZ), net.minecraft.src.MathHelper.Floor_double(boundingBox
                .maxX), net.minecraft.src.MathHelper.Floor_double(boundingBox.maxY), net.minecraft.src.MathHelper
                .Floor_double(boundingBox.maxZ)))
            {
                float f1 = worldObj.GetLightBrightness(i, j, k);
                if (f1 < field_31001_bF)
                {
                    f1 = field_31001_bF;
                }
                return f1;
            }
            else
            {
                return field_31001_bF;
            }
        }

        public virtual void SetWorldHandler(net.minecraft.src.World world)
        {
            // CRAFTBUKKIT start
            if (world == null)
            {
                this.SetEntityDead();
                world = Entrypoint.minecraftserver.worldMngr[0]; //TODO: Is this correct?
            }
            // CRAFTBUKKIT end

            worldObj = world;
        }

        public virtual void SetPositionAndRotation(double d, double d1, double d2, float
            f, float f1)
        {
            prevPosX = posX = d;
            prevPosY = posY = d1;
            prevPosZ = posZ = d2;
            prevRotationYaw = rotationYaw = f;
            prevRotationPitch = rotationPitch = f1;
            ySize = 0.0F;
            double d3 = prevRotationYaw - f;
            if (d3 < -180D)
            {
                prevRotationYaw += 360F;
            }
            if (d3 >= 180D)
            {
                prevRotationYaw -= 360F;
            }
            SetPosition(posX, posY, posZ);
            SetRotation(f, f1);
        }

        public virtual void SetLocationAndAngles(double d, double d1, double d2, float f,
            float f1)
        {
            lastTickPosX = prevPosX = posX = d;
            lastTickPosY = prevPosY = posY = d1 + (double)yOffset;
            lastTickPosZ = prevPosZ = posZ = d2;
            rotationYaw = f;
            rotationPitch = f1;
            SetPosition(posX, posY, posZ);
        }

        public virtual float GetDistanceToEntity(net.minecraft.src.Entity entity)
        {
            float f = (float)(posX - entity.posX);
            float f1 = (float)(posY - entity.posY);
            float f2 = (float)(posZ - entity.posZ);
            return net.minecraft.src.MathHelper.Sqrt_float(f * f + f1 * f1 + f2 * f2);
        }

        public virtual double GetDistanceSq(double d, double d1, double d2)
        {
            double d3 = posX - d;
            double d4 = posY - d1;
            double d5 = posZ - d2;
            return d3 * d3 + d4 * d4 + d5 * d5;
        }

        public virtual double GetDistance(double d, double d1, double d2)
        {
            double d3 = posX - d;
            double d4 = posY - d1;
            double d5 = posZ - d2;
            return (double)net.minecraft.src.MathHelper.Sqrt_double(d3 * d3 + d4 * d4 + d5 *
                d5);
        }

        public virtual double GetDistanceSqToEntity(net.minecraft.src.Entity entity)
        {
            double d = posX - entity.posX;
            double d1 = posY - entity.posY;
            double d2 = posZ - entity.posZ;
            return d * d + d1 * d1 + d2 * d2;
        }

        public virtual void OnCollideWithPlayer(net.minecraft.src.EntityPlayer entityplayer
            )
        {
        }

        public virtual void ApplyEntityCollision(net.minecraft.src.Entity entity)
        {
            if (entity.riddenByEntity == this || entity.ridingEntity == this)
            {
                return;
            }
            double d = entity.posX - posX;
            double d1 = entity.posZ - posZ;
            double d2 = net.minecraft.src.MathHelper.Abs_max(d, d1);
            if (d2 >= 0.0099999997764825821D)
            {
                d2 = net.minecraft.src.MathHelper.Sqrt_double(d2);
                d /= d2;
                d1 /= d2;
                double d3 = 1.0D / d2;
                if (d3 > 1.0D)
                {
                    d3 = 1.0D;
                }
                d *= d3;
                d1 *= d3;
                d *= 0.05000000074505806D;
                d1 *= 0.05000000074505806D;
                d *= 1.0F - entityCollisionReduction;
                d1 *= 1.0F - entityCollisionReduction;
                AddVelocity(-d, 0.0D, -d1);
                entity.AddVelocity(d, 0.0D, d1);
            }
        }

        public virtual void AddVelocity(double d, double d1, double d2)
        {
            motionX += d;
            motionY += d1;
            motionZ += d2;
        }

        protected internal virtual void SetBeenAttacked()
        {
            beenAttacked = true;
        }

        public virtual bool AttackEntityFrom(net.minecraft.src.Entity entity, int i)
        {
            SetBeenAttacked();
            return false;
        }

        public virtual bool CanBeCollidedWith()
        {
            return false;
        }

        public virtual bool CanBePushed()
        {
            return false;
        }

        public virtual void AddToPlayerScore(net.minecraft.src.Entity entity, int i)
        {
        }

        public virtual bool AddEntityID(net.minecraft.src.NBTTagCompound nbttagcompound)
        {
            string s = GetEntityString();
            if (isDead || s == null)
            {
                return false;
            }
            else
            {
                nbttagcompound.SetString("id", s);
                WriteToNBT(nbttagcompound);
                return true;
            }
        }

        public virtual void WriteToNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
        {
            // CRAFTBUKKIT start
            if (float.IsNaN(rotationYaw)) rotationYaw = 0;
            if (float.IsNaN(rotationPitch)) rotationPitch = 0;
            // CRAFTBUKKIT end

            nbttagcompound.SetTag("Pos", NewDoubleNBTList(new double[] { posX, posY + (double)ySize, posZ }));
            nbttagcompound.SetTag("Motion", NewDoubleNBTList(new double[] { motionX, motionY, motionZ }));
            nbttagcompound.SetTag("Rotation", NewFloatNBTList(new float[] { rotationYaw, rotationPitch }));
            nbttagcompound.SetFloat("FallDistance", fallDistance);
            nbttagcompound.SetShort("Fire", (short)fire);
            nbttagcompound.SetShort("Air", (short)air);
            nbttagcompound.SetBoolean("OnGround", onGround);
            WriteEntityToNBT(nbttagcompound);
        }

        public virtual void ReadFromNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
        {
            //TODO: Bukkit stuff???
            net.minecraft.src.NBTTagList nbttaglist = nbttagcompound.GetTagList("Pos");
            net.minecraft.src.NBTTagList nbttaglist1 = nbttagcompound.GetTagList("Motion");
            net.minecraft.src.NBTTagList nbttaglist2 = nbttagcompound.GetTagList("Rotation");
            motionX = ((net.minecraft.src.NBTTagDouble)nbttaglist1.TagAt(0)).doubleValue;
            motionY = ((net.minecraft.src.NBTTagDouble)nbttaglist1.TagAt(1)).doubleValue;
            motionZ = ((net.minecraft.src.NBTTagDouble)nbttaglist1.TagAt(2)).doubleValue;
            if (System.Math.Abs(motionX) > 10D)
            {
                motionX = 0.0D;
            }
            if (System.Math.Abs(motionY) > 10D)
            {
                motionY = 0.0D;
            }
            if (System.Math.Abs(motionZ) > 10D)
            {
                motionZ = 0.0D;
            }
            prevPosX = lastTickPosX = posX = ((net.minecraft.src.NBTTagDouble)nbttaglist.TagAt
                (0)).doubleValue;
            prevPosY = lastTickPosY = posY = ((net.minecraft.src.NBTTagDouble)nbttaglist.TagAt
                (1)).doubleValue;
            prevPosZ = lastTickPosZ = posZ = ((net.minecraft.src.NBTTagDouble)nbttaglist.TagAt
                (2)).doubleValue;
            prevRotationYaw = rotationYaw = ((net.minecraft.src.NBTTagFloat)nbttaglist2.TagAt
                (0)).floatValue;
            prevRotationPitch = rotationPitch = ((net.minecraft.src.NBTTagFloat)nbttaglist2.TagAt
                (1)).floatValue;
            fallDistance = nbttagcompound.GetFloat("FallDistance");
            fire = nbttagcompound.GetShort("Fire");
            air = nbttagcompound.GetShort("Air");
            onGround = nbttagcompound.GetBoolean("OnGround");
            SetPosition(posX, posY, posZ);
            SetRotation(rotationYaw, rotationPitch);
            ReadEntityFromNBT(nbttagcompound);
        }

        protected internal string GetEntityString()
        {
            return net.minecraft.src.EntityList.GetEntityString(this);
        }

        protected internal abstract void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
             nbttagcompound);

        protected internal abstract void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
             nbttagcompound);

        protected internal virtual net.minecraft.src.NBTTagList NewDoubleNBTList(double[]
             ad)
        {
            net.minecraft.src.NBTTagList nbttaglist = new net.minecraft.src.NBTTagList();
            double[] ad1 = ad;
            int i = ad1.Length;
            for (int j = 0; j < i; j++)
            {
                double d = ad1[j];
                nbttaglist.SetTag(new net.minecraft.src.NBTTagDouble(d));
            }
            return nbttaglist;
        }

        protected internal virtual net.minecraft.src.NBTTagList NewFloatNBTList(float[] af
            )
        {
            net.minecraft.src.NBTTagList nbttaglist = new net.minecraft.src.NBTTagList();
            float[] af1 = af;
            int i = af1.Length;
            for (int j = 0; j < i; j++)
            {
                float f = af1[j];
                nbttaglist.SetTag(new net.minecraft.src.NBTTagFloat(f));
            }
            return nbttaglist;
        }

        public virtual net.minecraft.src.EntityItem DropItem(int i, int j)
        {
            return DropItemWithOffset(i, j, 0.0F);
        }

        public virtual net.minecraft.src.EntityItem DropItemWithOffset(int i, int j, float
             f)
        {
            return EntityDropItem(new net.minecraft.src.ItemStack(i, j, 0), f);
        }

        public virtual net.minecraft.src.EntityItem EntityDropItem(net.minecraft.src.ItemStack
             itemstack, float f)
        {
            net.minecraft.src.EntityItem entityitem = new net.minecraft.src.EntityItem(worldObj
                , posX, posY + (double)f, posZ, itemstack);
            entityitem.delayBeforeCanPickup = 10;
            worldObj.AddEntity(entityitem);
            return entityitem;
        }

        public virtual bool IsEntityAlive()
        {
            return !isDead;
        }

        public virtual bool IsEntityInsideOpaqueBlock()
        {
            for (int i = 0; i < 8; i++)
            {
                float f = ((float)((i >> 0) % 2) - 0.5F) * width * 0.9F;
                float f1 = ((float)((i >> 1) % 2) - 0.5F) * 0.1F;
                float f2 = ((float)((i >> 2) % 2) - 0.5F) * width * 0.9F;
                int j = net.minecraft.src.MathHelper.Floor_double(posX + (double)f);
                int k = net.minecraft.src.MathHelper.Floor_double(posY + (double)GetEyeHeight() +
                     (double)f1);
                int l = net.minecraft.src.MathHelper.Floor_double(posZ + (double)f2);
                if (worldObj.IsBlockNormalCube(j, k, l))
                {
                    return true;
                }
            }
            return false;
        }

        public virtual bool Interact(net.minecraft.src.EntityPlayer entityplayer)
        {
            return false;
        }

        public virtual net.minecraft.src.AxisAlignedBB Func_89_d(net.minecraft.src.Entity
             entity)
        {
            return null;
        }

        public virtual void UpdateRidden()
        {
            if (ridingEntity.isDead)
            {
                ridingEntity = null;
                return;
            }
            motionX = 0.0D;
            motionY = 0.0D;
            motionZ = 0.0D;
            OnUpdate();
            if (ridingEntity == null)
            {
                return;
            }
            ridingEntity.UpdateRiderPosition();
            entityRiderYawDelta += ridingEntity.rotationYaw - ridingEntity.prevRotationYaw;
            entityRiderPitchDelta += ridingEntity.rotationPitch - ridingEntity.prevRotationPitch;
            for (; entityRiderYawDelta >= 180D; entityRiderYawDelta -= 360D)
            {
            }
            for (; entityRiderYawDelta < -180D; entityRiderYawDelta += 360D)
            {
            }
            for (; entityRiderPitchDelta >= 180D; entityRiderPitchDelta -= 360D)
            {
            }
            for (; entityRiderPitchDelta < -180D; entityRiderPitchDelta += 360D)
            {
            }
            double d = entityRiderYawDelta * 0.5D;
            double d1 = entityRiderPitchDelta * 0.5D;
            float f = 10F;
            if (d > (double)f)
            {
                d = f;
            }
            if (d < (double)(-f))
            {
                d = -f;
            }
            if (d1 > (double)f)
            {
                d1 = f;
            }
            if (d1 < (double)(-f))
            {
                d1 = -f;
            }
            entityRiderYawDelta -= d;
            entityRiderPitchDelta -= d1;
            rotationYaw += (float)d;
            rotationPitch += (float)d1;
        }

        public virtual void UpdateRiderPosition()
        {
            riddenByEntity.SetPosition(posX, posY + GetMountedYOffset() + riddenByEntity.GetYOffset
                (), posZ);
        }

        public virtual double GetYOffset()
        {
            return (double)yOffset;
        }

        public virtual double GetMountedYOffset()
        {
            return (double)height * 0.75D;
        }

        public virtual void MountEntity(net.minecraft.src.Entity entity)
        {
            entityRiderPitchDelta = 0.0D;
            entityRiderYawDelta = 0.0D;
            if (entity == null)
            {
                if (ridingEntity != null)
                {
                    SetLocationAndAngles(ridingEntity.posX, ridingEntity.boundingBox.minY + (double)ridingEntity
                        .height, ridingEntity.posZ, rotationYaw, rotationPitch);
                    ridingEntity.riddenByEntity = null;
                }
                ridingEntity = null;
                return;
            }
            if (ridingEntity == entity)
            {
                ridingEntity.riddenByEntity = null;
                ridingEntity = null;
                SetLocationAndAngles(entity.posX, entity.boundingBox.minY + (double)entity.height
                    , entity.posZ, rotationYaw, rotationPitch);
                return;
            }
            if (ridingEntity != null)
            {
                ridingEntity.riddenByEntity = null;
            }
            if (entity.riddenByEntity != null)
            {
                entity.riddenByEntity.ridingEntity = null;
            }
            ridingEntity = entity;
            entity.riddenByEntity = this;
        }

        public virtual net.minecraft.src.Vec3D GetLookVec()
        {
            return null;
        }

        public virtual void SetInPortal()
        {
        }

        public virtual net.minecraft.src.ItemStack[] GetInventory()
        {
            return null;
        }

        public virtual bool IsSneaking()
        {
            return GetFlag(1);
        }

        public virtual void SetSneaking(bool flag)
        {
            SetFlag(1, flag);
        }

        protected internal virtual bool GetFlag(int i)
        {
            return (dataWatcher.GetWatchableObjectByte(0) & 1 << i) != 0;
        }

        protected internal virtual void SetFlag(int i, bool flag)
        {
            byte byte0 = dataWatcher.GetWatchableObjectByte(0);
            if (flag)
            {
                dataWatcher.UpdateObject(0, unchecked((byte)(byte0 | 1 << i)));
            }
            else
            {
                dataWatcher.UpdateObject(0, unchecked((byte)(byte0 & ~(1 << i))));
            }
        }

        public virtual void OnStruckByLightning(net.minecraft.src.EntityLightningBolt entitylightningbolt
            )
        {
            DealFireDamage(5);
            fire++;
            if (fire == 0)
            {
                fire = 300;
            }
        }

        public virtual void UpdateKillStatistic(net.minecraft.src.EntityLiving entityliving)
        {
        }

        protected internal virtual bool Func_28005_g(double d, double d1, double d2) //SHARP: Collision maybe?
        {
            int i = net.minecraft.src.MathHelper.Floor_double(d);
            int j = net.minecraft.src.MathHelper.Floor_double(d1);
            int k = net.minecraft.src.MathHelper.Floor_double(d2);
            double d3 = d - (double)i;
            double d4 = d1 - (double)j;
            double d5 = d2 - (double)k;
            if (worldObj.IsBlockNormalCube(i, j, k))
            {
                bool flag = !worldObj.IsBlockNormalCube(i - 1, j, k);
                bool flag1 = !worldObj.IsBlockNormalCube(i + 1, j, k);
                bool flag2 = !worldObj.IsBlockNormalCube(i, j - 1, k);
                bool flag3 = !worldObj.IsBlockNormalCube(i, j + 1, k);
                bool flag4 = !worldObj.IsBlockNormalCube(i, j, k - 1);
                bool flag5 = !worldObj.IsBlockNormalCube(i, j, k + 1);
                byte byte0 = unchecked((byte)(-1));
                double d6 = 9999D;
                if (flag && d3 < d6)
                {
                    d6 = d3;
                    byte0 = 0;
                }
                if (flag1 && 1.0D - d3 < d6)
                {
                    d6 = 1.0D - d3;
                    byte0 = 1;
                }
                if (flag2 && d4 < d6)
                {
                    d6 = d4;
                    byte0 = 2;
                }
                if (flag3 && 1.0D - d4 < d6)
                {
                    d6 = 1.0D - d4;
                    byte0 = 3;
                }
                if (flag4 && d5 < d6)
                {
                    d6 = d5;
                    byte0 = 4;
                }
                if (flag5 && 1.0D - d5 < d6)
                {
                    double d7 = 1.0D - d5;
                    byte0 = 5;
                }
                float f = rand.NextFloat() * 0.2F + 0.1F;
                if (byte0 == 0)
                {
                    motionX = -f;
                }
                if (byte0 == 1)
                {
                    motionX = f;
                }
                if (byte0 == 2)
                {
                    motionY = -f;
                }
                if (byte0 == 3)
                {
                    motionY = f;
                }
                if (byte0 == 4)
                {
                    motionZ = -f;
                }
                if (byte0 == 5)
                {
                    motionZ = f;
                }
            }
            return false;
        }

        private static int nextEntityID = 0;

        public int entityId;

        public double renderDistanceWeight;

        public bool preventEntitySpawning;

        public net.minecraft.src.Entity riddenByEntity;

        public net.minecraft.src.Entity ridingEntity;

        public net.minecraft.src.World worldObj;

        public double prevPosX;

        public double prevPosY;

        public double prevPosZ;

        public double posX;

        public double posY;

        public double posZ;

        public double motionX;

        public double motionY;

        public double motionZ;

        public float rotationYaw;

        public float rotationPitch;

        public float prevRotationYaw;

        public float prevRotationPitch;

        public readonly net.minecraft.src.AxisAlignedBB boundingBox = net.minecraft.src.AxisAlignedBB
            .GetBoundingBox(0.0D, 0.0D, 0.0D, 0.0D, 0.0D, 0.0D);

        public bool onGround;

        public bool isCollidedHorizontally;

        public bool isCollidedVertically;

        public bool isCollided;

        public bool beenAttacked;

        public bool field_27012_bb;

        public bool field_9077_F;

        public bool isDead;

        public float yOffset;

        public float width;

        public float height;

        public float prevDistanceWalkedModified;

        public float distanceWalkedModified;

        protected internal float fallDistance;

        private int nextStepDistance;

        public double lastTickPosX;

        public double lastTickPosY;

        public double lastTickPosZ;

        public float ySize;

        public float stepHeight;

        public bool noClip;

        public float entityCollisionReduction;

        protected internal SharpBukkitLive.SharpBukkit.SharpRandom rand;

        public int ticksExisted;

        public int fireResistance;

        public int fire;

        protected internal int maxAir;

        protected internal bool inWater;

        public int field_9083_ac;

        public int air;

        private bool firstUpdate;

        protected internal bool isImmuneToFire;

        protected internal net.minecraft.src.DataWatcher dataWatcher;

        public float field_31001_bF;

        private double entityRiderPitchDelta;

        private double entityRiderYawDelta;

        public bool addedToChunk;

        public int chunkCoordX;

        public int chunkCoordY;

        public int chunkCoordZ;

        public bool field_28008_bI;
    }
}
