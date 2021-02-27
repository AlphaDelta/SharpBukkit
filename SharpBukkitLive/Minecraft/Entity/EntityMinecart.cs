// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class EntityMinecart : net.minecraft.src.Entity, net.minecraft.src.IInventory
    {
        public EntityMinecart(net.minecraft.src.World world)
            : base(world)
        {
            // Referenced classes of package net.minecraft.src:
            //            Entity, IInventory, ItemStack, World, 
            //            Item, EntityItem, Block, MathHelper, 
            //            BlockRail, Vec3D, AxisAlignedBB, NBTTagCompound, 
            //            NBTTagList, EntityLiving, EntityPlayer, InventoryPlayer
            cargoItems = new net.minecraft.src.ItemStack[36];
            damageTaken = 0;
            field_9167_b = 0;
            forwardDirection = 1;
            field_469_aj = false;
            preventEntitySpawning = true;
            SetSize(0.98F, 0.7F);
            yOffset = height / 2.0F;
        }

        protected internal override bool Func_25017_l()
        {
            return false;
        }

        protected internal override void EntityInit()
        {
        }

        public override net.minecraft.src.AxisAlignedBB Func_89_d(net.minecraft.src.Entity
             entity)
        {
            return entity.boundingBox;
        }

        public override net.minecraft.src.AxisAlignedBB GetBoundingBox()
        {
            return null;
        }

        public override bool CanBePushed()
        {
            return true;
        }

        public EntityMinecart(net.minecraft.src.World world, double d, double d1, double
            d2, int i)
            : this(world)
        {
            SetPosition(d, d1 + (double)yOffset, d2);
            motionX = 0.0D;
            motionY = 0.0D;
            motionZ = 0.0D;
            prevPosX = d;
            prevPosY = d1;
            prevPosZ = d2;
            minecartType = i;
        }

        public override double GetMountedYOffset()
        {
            return (double)height * 0.0D - 0.30000001192092896D;
        }

        public override bool AttackEntityFrom(net.minecraft.src.Entity entity, int i)
        {
            if (worldObj.singleplayerWorld || isDead)
            {
                return true;
            }
            forwardDirection = -forwardDirection;
            field_9167_b = 10;
            SetBeenAttacked();
            damageTaken += i * 10;
            if (damageTaken > 40)
            {
                if (riddenByEntity != null)
                {
                    riddenByEntity.MountEntity(this);
                }
                SetEntityDead();
                DropItemWithOffset(net.minecraft.src.Item.minecartEmpty.shiftedIndex, 1, 0.0F);
                if (minecartType == 1)
                {
                    net.minecraft.src.EntityMinecart entityminecart = this;
                    for (int j = 0; j < entityminecart.GetSizeInventory(); j++)
                    {
                        net.minecraft.src.ItemStack itemstack = entityminecart.GetStackInSlot(j);
                        if (itemstack == null)
                        {
                            continue;
                        }
                        float f = rand.NextFloat() * 0.8F + 0.1F;
                        float f1 = rand.NextFloat() * 0.8F + 0.1F;
                        float f2 = rand.NextFloat() * 0.8F + 0.1F;
                        do
                        {
                            if (itemstack.stackSize <= 0)
                            {
                                goto label0_continue;
                            }
                            int k = rand.Next(21) + 10;
                            if (k > itemstack.stackSize)
                            {
                                k = itemstack.stackSize;
                            }
                            itemstack.stackSize -= k;
                            net.minecraft.src.EntityItem entityitem = new net.minecraft.src.EntityItem(worldObj
                                , posX + (double)f, posY + (double)f1, posZ + (double)f2, new net.minecraft.src.ItemStack
                                (itemstack.itemID, k, itemstack.GetItemDamage()));
                            float f3 = 0.05F;
                            entityitem.motionX = (float)rand.NextGaussian() * f3;
                            entityitem.motionY = (float)rand.NextGaussian() * f3 + 0.2F;
                            entityitem.motionZ = (float)rand.NextGaussian() * f3;
                            worldObj.EntityJoinedWorld(entityitem);
                        }
                        while (true);
                        label0_continue:;
                    }
                    label0_break:;
                    DropItemWithOffset(net.minecraft.src.Block.chest.blockID, 1, 0.0F);
                }
                else
                {
                    if (minecartType == 2)
                    {
                        DropItemWithOffset(net.minecraft.src.Block.stoneOvenIdle.blockID, 1, 0.0F);
                    }
                }
            }
            return true;
        }

        public override bool CanBeCollidedWith()
        {
            return !isDead;
        }

        public override void SetEntityDead()
        {
            for (int i = 0; i < GetSizeInventory(); i++)
            {
                net.minecraft.src.ItemStack itemstack = GetStackInSlot(i);
                if (itemstack == null)
                {
                    continue;
                }
                float f = rand.NextFloat() * 0.8F + 0.1F;
                float f1 = rand.NextFloat() * 0.8F + 0.1F;
                float f2 = rand.NextFloat() * 0.8F + 0.1F;
                do
                {
                    if (itemstack.stackSize <= 0)
                    {
                        goto label0_continue;
                    }
                    int j = rand.Next(21) + 10;
                    if (j > itemstack.stackSize)
                    {
                        j = itemstack.stackSize;
                    }
                    itemstack.stackSize -= j;
                    net.minecraft.src.EntityItem entityitem = new net.minecraft.src.EntityItem(worldObj
                        , posX + (double)f, posY + (double)f1, posZ + (double)f2, new net.minecraft.src.ItemStack
                        (itemstack.itemID, j, itemstack.GetItemDamage()));
                    float f3 = 0.05F;
                    entityitem.motionX = (float)rand.NextGaussian() * f3;
                    entityitem.motionY = (float)rand.NextGaussian() * f3 + 0.2F;
                    entityitem.motionZ = (float)rand.NextGaussian() * f3;
                    worldObj.EntityJoinedWorld(entityitem);
                }
                while (true);
                label0_continue:;
            }
            label0_break:;
            base.SetEntityDead();
        }

        public override void OnUpdate()
        {
            if (field_9167_b > 0)
            {
                field_9167_b--;
            }
            if (damageTaken > 0)
            {
                damageTaken--;
            }
            if (worldObj.singleplayerWorld && field_9163_an > 0)
            {
                if (field_9163_an > 0)
                {
                    double d = posX + (field_9162_ao - posX) / (double)field_9163_an;
                    double d1 = posY + (field_9161_ap - posY) / (double)field_9163_an;
                    double d3 = posZ + (field_9160_aq - posZ) / (double)field_9163_an;
                    double d4;
                    for (d4 = field_9159_ar - (double)rotationYaw; d4 < -180D; d4 += 360D)
                    {
                    }
                    for (; d4 >= 180D; d4 -= 360D)
                    {
                    }
                    rotationYaw += (float)(d4 / (double)field_9163_an);
                    rotationPitch += (float)((field_9158_as - (double)rotationPitch) / (double)field_9163_an);
                    field_9163_an--;
                    SetPosition(d, d1, d3);
                    SetRotation(rotationYaw, rotationPitch);
                }
                else
                {
                    SetPosition(posX, posY, posZ);
                    SetRotation(rotationYaw, rotationPitch);
                }
                return;
            }
            prevPosX = posX;
            prevPosY = posY;
            prevPosZ = posZ;
            motionY -= 0.039999999105930328D;
            int i = net.minecraft.src.MathHelper.Floor_double(posX);
            int j = net.minecraft.src.MathHelper.Floor_double(posY);
            int k = net.minecraft.src.MathHelper.Floor_double(posZ);
            if (net.minecraft.src.BlockRail.Func_27029_g(worldObj, i, j - 1, k))
            {
                j--;
            }
            double d2 = 0.40000000000000002D;
            bool flag = false;
            double d5 = 0.0078125D;
            int l = worldObj.GetBlockId(i, j, k);
            if (net.minecraft.src.BlockRail.Func_27030_c(l))
            {
                net.minecraft.src.Vec3D vec3d = Func_182_g(posX, posY, posZ);
                int i1 = worldObj.GetBlockMetadata(i, j, k);
                posY = j;
                bool flag1 = false;
                bool flag2 = false;
                if (l == net.minecraft.src.Block.railPowered.blockID)
                {
                    flag1 = (i1 & 8) != 0;
                    flag2 = !flag1;
                }
                if (((net.minecraft.src.BlockRail)net.minecraft.src.Block.blocksList[l]).Func_27028_d
                    ())
                {
                    i1 &= 7;
                }
                if (i1 >= 2 && i1 <= 5)
                {
                    posY = j + 1;
                }
                if (i1 == 2)
                {
                    motionX -= d5;
                }
                if (i1 == 3)
                {
                    motionX += d5;
                }
                if (i1 == 4)
                {
                    motionZ += d5;
                }
                if (i1 == 5)
                {
                    motionZ -= d5;
                }
                int[][] ai = field_468_ak[i1];
                double d9 = ai[1][0] - ai[0][0];
                double d10 = ai[1][2] - ai[0][2];
                double d11 = System.Math.Sqrt(d9 * d9 + d10 * d10);
                double d12 = motionX * d9 + motionZ * d10;
                if (d12 < 0.0D)
                {
                    d9 = -d9;
                    d10 = -d10;
                }
                double d13 = System.Math.Sqrt(motionX * motionX + motionZ * motionZ);
                motionX = (d13 * d9) / d11;
                motionZ = (d13 * d10) / d11;
                if (flag2)
                {
                    double d16 = System.Math.Sqrt(motionX * motionX + motionZ * motionZ);
                    if (d16 < 0.029999999999999999D)
                    {
                        motionX *= 0.0D;
                        motionY *= 0.0D;
                        motionZ *= 0.0D;
                    }
                    else
                    {
                        motionX *= 0.5D;
                        motionY *= 0.0D;
                        motionZ *= 0.5D;
                    }
                }
                double d17 = 0.0D;
                double d18 = (double)i + 0.5D + (double)ai[0][0] * 0.5D;
                double d19 = (double)k + 0.5D + (double)ai[0][2] * 0.5D;
                double d20 = (double)i + 0.5D + (double)ai[1][0] * 0.5D;
                double d21 = (double)k + 0.5D + (double)ai[1][2] * 0.5D;
                d9 = d20 - d18;
                d10 = d21 - d19;
                if (d9 == 0.0D)
                {
                    posX = (double)i + 0.5D;
                    d17 = posZ - (double)k;
                }
                else
                {
                    if (d10 == 0.0D)
                    {
                        posZ = (double)k + 0.5D;
                        d17 = posX - (double)i;
                    }
                    else
                    {
                        double d22 = posX - d18;
                        double d24 = posZ - d19;
                        double d26 = (d22 * d9 + d24 * d10) * 2D;
                        d17 = d26;
                    }
                }
                posX = d18 + d9 * d17;
                posZ = d19 + d10 * d17;
                SetPosition(posX, posY + (double)yOffset, posZ);
                double d23 = motionX;
                double d25 = motionZ;
                if (riddenByEntity != null)
                {
                    d23 *= 0.75D;
                    d25 *= 0.75D;
                }
                if (d23 < -d2)
                {
                    d23 = -d2;
                }
                if (d23 > d2)
                {
                    d23 = d2;
                }
                if (d25 < -d2)
                {
                    d25 = -d2;
                }
                if (d25 > d2)
                {
                    d25 = d2;
                }
                MoveEntity(d23, 0.0D, d25);
                if (ai[0][1] != 0 && net.minecraft.src.MathHelper.Floor_double(posX) - i == ai[0]
                    [0] && net.minecraft.src.MathHelper.Floor_double(posZ) - k == ai[0][2])
                {
                    SetPosition(posX, posY + (double)ai[0][1], posZ);
                }
                else
                {
                    if (ai[1][1] != 0 && net.minecraft.src.MathHelper.Floor_double(posX) - i == ai[1]
                        [0] && net.minecraft.src.MathHelper.Floor_double(posZ) - k == ai[1][2])
                    {
                        SetPosition(posX, posY + (double)ai[1][1], posZ);
                    }
                }
                if (riddenByEntity != null)
                {
                    motionX *= 0.99699997901916504D;
                    motionY *= 0.0D;
                    motionZ *= 0.99699997901916504D;
                }
                else
                {
                    if (minecartType == 2)
                    {
                        double d27 = net.minecraft.src.MathHelper.Sqrt_double(pushX * pushX + pushZ * pushZ
                            );
                        if (d27 > 0.01D)
                        {
                            flag = true;
                            pushX /= d27;
                            pushZ /= d27;
                            double d29 = 0.040000000000000001D;
                            motionX *= 0.80000001192092896D;
                            motionY *= 0.0D;
                            motionZ *= 0.80000001192092896D;
                            motionX += pushX * d29;
                            motionZ += pushZ * d29;
                        }
                        else
                        {
                            motionX *= 0.89999997615814209D;
                            motionY *= 0.0D;
                            motionZ *= 0.89999997615814209D;
                        }
                    }
                    motionX *= 0.95999997854232788D;
                    motionY *= 0.0D;
                    motionZ *= 0.95999997854232788D;
                }
                net.minecraft.src.Vec3D vec3d1 = Func_182_g(posX, posY, posZ);
                if (vec3d1 != null && vec3d != null)
                {
                    double d28 = (vec3d.yCoord - vec3d1.yCoord) * 0.050000000000000003D;
                    double d14 = System.Math.Sqrt(motionX * motionX + motionZ * motionZ);
                    if (d14 > 0.0D)
                    {
                        motionX = (motionX / d14) * (d14 + d28);
                        motionZ = (motionZ / d14) * (d14 + d28);
                    }
                    SetPosition(posX, vec3d1.yCoord, posZ);
                }
                int k1 = net.minecraft.src.MathHelper.Floor_double(posX);
                int l1 = net.minecraft.src.MathHelper.Floor_double(posZ);
                if (k1 != i || l1 != k)
                {
                    double d15 = System.Math.Sqrt(motionX * motionX + motionZ * motionZ);
                    motionX = d15 * (double)(k1 - i);
                    motionZ = d15 * (double)(l1 - k);
                }
                if (minecartType == 2)
                {
                    double d30 = net.minecraft.src.MathHelper.Sqrt_double(pushX * pushX + pushZ * pushZ
                        );
                    if (d30 > 0.01D && motionX * motionX + motionZ * motionZ > 0.001D)
                    {
                        pushX /= d30;
                        pushZ /= d30;
                        if (pushX * motionX + pushZ * motionZ < 0.0D)
                        {
                            pushX = 0.0D;
                            pushZ = 0.0D;
                        }
                        else
                        {
                            pushX = motionX;
                            pushZ = motionZ;
                        }
                    }
                }
                if (flag1)
                {
                    double d31 = System.Math.Sqrt(motionX * motionX + motionZ * motionZ);
                    if (d31 > 0.01D)
                    {
                        double d32 = 0.059999999999999998D;
                        motionX += (motionX / d31) * d32;
                        motionZ += (motionZ / d31) * d32;
                    }
                    else
                    {
                        if (i1 == 1)
                        {
                            if (worldObj.IsBlockNormalCube(i - 1, j, k))
                            {
                                motionX = 0.02D;
                            }
                            else
                            {
                                if (worldObj.IsBlockNormalCube(i + 1, j, k))
                                {
                                    motionX = -0.02D;
                                }
                            }
                        }
                        else
                        {
                            if (i1 == 0)
                            {
                                if (worldObj.IsBlockNormalCube(i, j, k - 1))
                                {
                                    motionZ = 0.02D;
                                }
                                else
                                {
                                    if (worldObj.IsBlockNormalCube(i, j, k + 1))
                                    {
                                        motionZ = -0.02D;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (motionX < -d2)
                {
                    motionX = -d2;
                }
                if (motionX > d2)
                {
                    motionX = d2;
                }
                if (motionZ < -d2)
                {
                    motionZ = -d2;
                }
                if (motionZ > d2)
                {
                    motionZ = d2;
                }
                if (onGround)
                {
                    motionX *= 0.5D;
                    motionY *= 0.5D;
                    motionZ *= 0.5D;
                }
                MoveEntity(motionX, motionY, motionZ);
                if (!onGround)
                {
                    motionX *= 0.94999998807907104D;
                    motionY *= 0.94999998807907104D;
                    motionZ *= 0.94999998807907104D;
                }
            }
            rotationPitch = 0.0F;
            double d6 = prevPosX - posX;
            double d7 = prevPosZ - posZ;
            if (d6 * d6 + d7 * d7 > 0.001D)
            {
                rotationYaw = (float)((System.Math.Atan2(d7, d6) * 180D) / 3.1415926535897931D);
                if (field_469_aj)
                {
                    rotationYaw += 180F;
                }
            }
            double d8;
            for (d8 = rotationYaw - prevRotationYaw; d8 >= 180D; d8 -= 360D)
            {
            }
            for (; d8 < -180D; d8 += 360D)
            {
            }
            if (d8 < -170D || d8 >= 170D)
            {
                rotationYaw += 180F;
                field_469_aj = !field_469_aj;
            }
            SetRotation(rotationYaw, rotationPitch);
            System.Collections.Generic.List<Entity> list = worldObj.GetEntitiesWithinAABBExcludingEntity(this
                , boundingBox.Expand(0.20000000298023224D, 0.0D, 0.20000000298023224D));
            if (list != null && list.Count > 0)
            {
                for (int j1 = 0; j1 < list.Count; j1++)
                {
                    net.minecraft.src.Entity entity = (net.minecraft.src.Entity)list[j1];
                    if (entity != riddenByEntity && entity.CanBePushed() && (entity is net.minecraft.src.EntityMinecart
                        ))
                    {
                        entity.ApplyEntityCollision(this);
                    }
                }
            }
            if (riddenByEntity != null && riddenByEntity.isDead)
            {
                riddenByEntity = null;
            }
            if (flag && rand.Next(4) == 0)
            {
                fuel--;
                if (fuel < 0)
                {
                    pushX = pushZ = 0.0D;
                }
                worldObj.SpawnParticle("largesmoke", posX, posY + 0.80000000000000004D, posZ, 0.0D
                    , 0.0D, 0.0D);
            }
        }

        public virtual net.minecraft.src.Vec3D Func_182_g(double d, double d1, double d2)
        {
            int i = net.minecraft.src.MathHelper.Floor_double(d);
            int j = net.minecraft.src.MathHelper.Floor_double(d1);
            int k = net.minecraft.src.MathHelper.Floor_double(d2);
            if (net.minecraft.src.BlockRail.Func_27029_g(worldObj, i, j - 1, k))
            {
                j--;
            }
            int l = worldObj.GetBlockId(i, j, k);
            if (net.minecraft.src.BlockRail.Func_27030_c(l))
            {
                int i1 = worldObj.GetBlockMetadata(i, j, k);
                d1 = j;
                if (((net.minecraft.src.BlockRail)net.minecraft.src.Block.blocksList[l]).Func_27028_d
                    ())
                {
                    i1 &= 7;
                }
                if (i1 >= 2 && i1 <= 5)
                {
                    d1 = j + 1;
                }
                int[][] ai = field_468_ak[i1];
                double d3 = 0.0D;
                double d4 = (double)i + 0.5D + (double)ai[0][0] * 0.5D;
                double d5 = (double)j + 0.5D + (double)ai[0][1] * 0.5D;
                double d6 = (double)k + 0.5D + (double)ai[0][2] * 0.5D;
                double d7 = (double)i + 0.5D + (double)ai[1][0] * 0.5D;
                double d8 = (double)j + 0.5D + (double)ai[1][1] * 0.5D;
                double d9 = (double)k + 0.5D + (double)ai[1][2] * 0.5D;
                double d10 = d7 - d4;
                double d11 = (d8 - d5) * 2D;
                double d12 = d9 - d6;
                if (d10 == 0.0D)
                {
                    d = (double)i + 0.5D;
                    d3 = d2 - (double)k;
                }
                else
                {
                    if (d12 == 0.0D)
                    {
                        d2 = (double)k + 0.5D;
                        d3 = d - (double)i;
                    }
                    else
                    {
                        double d13 = d - d4;
                        double d14 = d2 - d6;
                        double d15 = (d13 * d10 + d14 * d12) * 2D;
                        d3 = d15;
                    }
                }
                d = d4 + d10 * d3;
                d1 = d5 + d11 * d3;
                d2 = d6 + d12 * d3;
                if (d11 < 0.0D)
                {
                    d1++;
                }
                if (d11 > 0.0D)
                {
                    d1 += 0.5D;
                }
                return net.minecraft.src.Vec3D.CreateVector(d, d1, d2);
            }
            else
            {
                return null;
            }
        }

        protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
             nbttagcompound)
        {
            nbttagcompound.SetInteger("Type", minecartType);
            if (minecartType == 2)
            {
                nbttagcompound.SetDouble("PushX", pushX);
                nbttagcompound.SetDouble("PushZ", pushZ);
                nbttagcompound.SetShort("Fuel", (short)fuel);
            }
            else
            {
                if (minecartType == 1)
                {
                    net.minecraft.src.NBTTagList nbttaglist = new net.minecraft.src.NBTTagList();
                    for (int i = 0; i < cargoItems.Length; i++)
                    {
                        if (cargoItems[i] != null)
                        {
                            net.minecraft.src.NBTTagCompound nbttagcompound1 = new net.minecraft.src.NBTTagCompound
                                ();
                            nbttagcompound1.SetByte("Slot", unchecked((byte)i));
                            cargoItems[i].WriteToNBT(nbttagcompound1);
                            nbttaglist.SetTag(nbttagcompound1);
                        }
                    }
                    nbttagcompound.SetTag("Items", nbttaglist);
                }
            }
        }

        protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
             nbttagcompound)
        {
            minecartType = nbttagcompound.GetInteger("Type");
            if (minecartType == 2)
            {
                pushX = nbttagcompound.GetDouble("PushX");
                pushZ = nbttagcompound.GetDouble("PushZ");
                fuel = nbttagcompound.GetShort("Fuel");
            }
            else
            {
                if (minecartType == 1)
                {
                    net.minecraft.src.NBTTagList nbttaglist = nbttagcompound.GetTagList("Items");
                    cargoItems = new net.minecraft.src.ItemStack[GetSizeInventory()];
                    for (int i = 0; i < nbttaglist.TagCount(); i++)
                    {
                        net.minecraft.src.NBTTagCompound nbttagcompound1 = (net.minecraft.src.NBTTagCompound
                            )nbttaglist.TagAt(i);
                        int j = nbttagcompound1.GetByte("Slot");
                        if (j >= 0 && j < cargoItems.Length)
                        {
                            cargoItems[j] = new net.minecraft.src.ItemStack(nbttagcompound1);
                        }
                    }
                }
            }
        }

        public override void ApplyEntityCollision(net.minecraft.src.Entity entity)
        {
            if (worldObj.singleplayerWorld)
            {
                return;
            }
            if (entity == riddenByEntity)
            {
                return;
            }
            if ((entity is net.minecraft.src.EntityLiving) && !(entity is net.minecraft.src.EntityPlayer
                ) && minecartType == 0 && motionX * motionX + motionZ * motionZ > 0.01D && riddenByEntity
                 == null && entity.ridingEntity == null)
            {
                entity.MountEntity(this);
            }
            double d = entity.posX - posX;
            double d1 = entity.posZ - posZ;
            double d2 = d * d + d1 * d1;
            if (d2 >= 9.9999997473787516E-005D)
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
                d *= 0.10000000149011612D;
                d1 *= 0.10000000149011612D;
                d *= 1.0F - entityCollisionReduction;
                d1 *= 1.0F - entityCollisionReduction;
                d *= 0.5D;
                d1 *= 0.5D;
                if (entity is net.minecraft.src.EntityMinecart)
                {
                    double d4 = entity.posX - posX;
                    double d5 = entity.posZ - posZ;
                    double d6 = d4 * entity.motionZ + d5 * entity.prevPosX;
                    d6 *= d6;
                    if (d6 > 5D)
                    {
                        return;
                    }
                    double d7 = entity.motionX + motionX;
                    double d8 = entity.motionZ + motionZ;
                    if (((net.minecraft.src.EntityMinecart)entity).minecartType == 2 && minecartType
                        != 2)
                    {
                        motionX *= 0.20000000298023224D;
                        motionZ *= 0.20000000298023224D;
                        AddVelocity(entity.motionX - d, 0.0D, entity.motionZ - d1);
                        entity.motionX *= 0.69999998807907104D;
                        entity.motionZ *= 0.69999998807907104D;
                    }
                    else
                    {
                        if (((net.minecraft.src.EntityMinecart)entity).minecartType != 2 && minecartType
                            == 2)
                        {
                            entity.motionX *= 0.20000000298023224D;
                            entity.motionZ *= 0.20000000298023224D;
                            entity.AddVelocity(motionX + d, 0.0D, motionZ + d1);
                            motionX *= 0.69999998807907104D;
                            motionZ *= 0.69999998807907104D;
                        }
                        else
                        {
                            d7 /= 2D;
                            d8 /= 2D;
                            motionX *= 0.20000000298023224D;
                            motionZ *= 0.20000000298023224D;
                            AddVelocity(d7 - d, 0.0D, d8 - d1);
                            entity.motionX *= 0.20000000298023224D;
                            entity.motionZ *= 0.20000000298023224D;
                            entity.AddVelocity(d7 + d, 0.0D, d8 + d1);
                        }
                    }
                }
                else
                {
                    AddVelocity(-d, 0.0D, -d1);
                    entity.AddVelocity(d / 4D, 0.0D, d1 / 4D);
                }
            }
        }

        public virtual int GetSizeInventory()
        {
            return 27;
        }

        public virtual net.minecraft.src.ItemStack GetStackInSlot(int i)
        {
            return cargoItems[i];
        }

        public virtual net.minecraft.src.ItemStack DecrStackSize(int i, int j)
        {
            if (cargoItems[i] != null)
            {
                if (cargoItems[i].stackSize <= j)
                {
                    net.minecraft.src.ItemStack itemstack = cargoItems[i];
                    cargoItems[i] = null;
                    return itemstack;
                }
                net.minecraft.src.ItemStack itemstack1 = cargoItems[i].SplitStack(j);
                if (cargoItems[i].stackSize == 0)
                {
                    cargoItems[i] = null;
                }
                return itemstack1;
            }
            else
            {
                return null;
            }
        }

        public virtual void SetInventorySlotContents(int i, net.minecraft.src.ItemStack itemstack
            )
        {
            cargoItems[i] = itemstack;
            if (itemstack != null && itemstack.stackSize > GetInventoryStackLimit())
            {
                itemstack.stackSize = GetInventoryStackLimit();
            }
        }

        public virtual string GetInvName()
        {
            return "Minecart";
        }

        public virtual int GetInventoryStackLimit()
        {
            return 64;
        }

        public virtual void OnInventoryChanged()
        {
        }

        public override bool Interact(net.minecraft.src.EntityPlayer entityplayer)
        {
            if (minecartType == 0)
            {
                if (riddenByEntity != null && (riddenByEntity is net.minecraft.src.EntityPlayer)
                    && riddenByEntity != entityplayer)
                {
                    return true;
                }
                if (!worldObj.singleplayerWorld)
                {
                    entityplayer.MountEntity(this);
                }
            }
            else
            {
                if (minecartType == 1)
                {
                    if (!worldObj.singleplayerWorld)
                    {
                        entityplayer.DisplayGUIChest(this);
                    }
                }
                else
                {
                    if (minecartType == 2)
                    {
                        net.minecraft.src.ItemStack itemstack = entityplayer.inventory.GetCurrentItem();
                        if (itemstack != null && itemstack.itemID == net.minecraft.src.Item.coal.shiftedIndex)
                        {
                            if (--itemstack.stackSize == 0)
                            {
                                entityplayer.inventory.SetInventorySlotContents(entityplayer.inventory.currentItem
                                    , null);
                            }
                            fuel += 1200;
                        }
                        pushX = posX - entityplayer.posX;
                        pushZ = posZ - entityplayer.posZ;
                    }
                }
            }
            return true;
        }

        public virtual bool CanInteractWith(net.minecraft.src.EntityPlayer entityplayer)
        {
            if (isDead)
            {
                return false;
            }
            return entityplayer.GetDistanceSqToEntity(this) <= 64D;
        }

        private net.minecraft.src.ItemStack[] cargoItems;

        public int damageTaken;

        public int field_9167_b;

        public int forwardDirection;

        private bool field_469_aj;

        public int minecartType;

        public int fuel;

        public double pushX;

        public double pushZ;

        private static readonly int[][][] field_468_ak = new int[][][] {
            new int[][] { new int[] { 0, 0, -1 }, new int[] { 0, 0, 1 } },
            new int[][] { new int[] { -1, 0, 0 }, new int[] { 1, 0, 0 } },
            new int[][] { new int[] { -1, -1, 0 }, new int[] { 1, 0, 0 } },
            new int[][] { new int[] { -1, 0, 0 }, new int[] { 1, -1, 0 } },
            new int[][] { new int[] { 0, 0, -1 }, new int[] { 0, -1, 1 } },
            new int[][] { new int[] { 0, -1, -1 }, new int[] { 0, 0, 1 } },
            new int[][] { new int[] { 0, 0, 1 }, new int[] { 1, 0, 0 } },
            new int[][] { new int[] { 0, 0, 1 }, new int[] { -1, 0, 0 } },
            new int[][] { new int[] { 0, 0, -1 }, new int[] { -1, 0, 0 } },
            new int[][] { new int[] { 0, 0, -1 }, new int[] { 1, 0, 0 } }
        };

        private int field_9163_an;

        private double field_9162_ao;

        private double field_9161_ap;

        private double field_9160_aq;

        private double field_9159_ar;

        private double field_9158_as;
    }
}
