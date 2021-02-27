// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;

namespace net.minecraft.src
{
    public class EntityItem : net.minecraft.src.Entity
    {
        SharpRandom SharpRandom = new SharpRandom();
        public EntityItem(net.minecraft.src.World world, double x, double y, double z, net.minecraft.src.ItemStack itemstack)
            : base(world)
        {
            // Referenced classes of package net.minecraft.src:
            //            Entity, MathHelper, World, Material, 
            //            AxisAlignedBB, Block, NBTTagCompound, ItemStack, 
            //            EntityPlayer, InventoryPlayer, AchievementList, Item
            age = 0;
            health = 5;
            field_432_ae = (float)(SharpRandom.NextDouble() * 3.1415926535897931D * 2D);
            SetSize(0.25F, 0.25F);
            yOffset = height / 2.0F;
            SetPosition(x, y, z);
            item = itemstack;
            rotationYaw = (float)(SharpRandom.NextDouble() * 360D);
            motionX = (float)(SharpRandom.NextDouble() * 0.20000000298023224D - 0.10000000149011612D);
            motionY = 0.20000000298023224D;
            motionZ = (float)(SharpRandom.NextDouble() * 0.20000000298023224D - 0.10000000149011612D);
        }

        protected internal override bool Func_25017_l()
        {
            return false;
        }

        public EntityItem(net.minecraft.src.World world)
            : base(world)
        {
            age = 0;
            health = 5;
            field_432_ae = (float)(SharpRandom.NextDouble() * 3.1415926535897931D * 2D);
            SetSize(0.25F, 0.25F);
            yOffset = height / 2.0F;
        }

        protected internal override void EntityInit()
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (delayBeforeCanPickup > 0)
            {
                delayBeforeCanPickup--;
            }
            prevPosX = posX;
            prevPosY = posY;
            prevPosZ = posZ;
            motionY -= 0.039999999105930328D;
            if (worldObj.GetBlockMaterial(net.minecraft.src.MathHelper.Floor_double(posX), net.minecraft.src.MathHelper
                .Floor_double(posY), net.minecraft.src.MathHelper.Floor_double(posZ)) == net.minecraft.src.Material
                .lava)
            {
                motionY = 0.20000000298023224D;
                motionX = (rand.NextFloat() - rand.NextFloat()) * 0.2F;
                motionZ = (rand.NextFloat() - rand.NextFloat()) * 0.2F;
                worldObj.PlaySoundAtEntity(this, "random.fizz", 0.4F, 2.0F + rand.NextFloat() * 0.4F);
            }
            Func_28005_g(posX, (boundingBox.minY + boundingBox.maxY) / 2D, posZ);
            MoveEntity(motionX, motionY, motionZ);
            float f = 0.98F;
            if (onGround)
            {
                f = 0.5880001F;
                int i = worldObj.GetBlockId(net.minecraft.src.MathHelper.Floor_double(posX), net.minecraft.src.MathHelper
                    .Floor_double(boundingBox.minY) - 1, net.minecraft.src.MathHelper.Floor_double(posZ
                    ));
                if (i > 0)
                {
                    f = net.minecraft.src.Block.blocksList[i].slipperiness * 0.98F;
                }
            }
            motionX *= f;
            motionY *= 0.98000001907348633D;
            motionZ *= f;
            if (onGround)
            {
                motionY *= -0.5D;
            }
            field_9170_e++;
            age++;
            if (age >= 6000) //TODO: Hook age
            {
                SetEntityDead();
            }
        }

        public override bool HandleWaterMovement()
        {
            return worldObj.HandleMaterialAcceleration(boundingBox, net.minecraft.src.Material
                .water, this);
        }

        protected internal override void DealFireDamage(int i)
        {
            AttackEntityFrom(null, i);
        }

        public override bool AttackEntityFrom(net.minecraft.src.Entity entity, int i)
        {
            SetBeenAttacked();
            health -= i;
            if (health <= 0)
            {
                SetEntityDead();
            }
            return false;
        }

        protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
             nbttagcompound)
        {
            nbttagcompound.SetShort("Health", unchecked((byte)health));
            nbttagcompound.SetShort("Age", (short)age);
            nbttagcompound.SetCompoundTag("Item", item.WriteToNBT(new net.minecraft.src.NBTTagCompound()));
        }

        protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
        {
            health = nbttagcompound.GetShort("Health") & 0xff;
            age = nbttagcompound.GetShort("Age");
            net.minecraft.src.NBTTagCompound nbttagcompound1 = nbttagcompound.GetCompoundTag("Item");
            item = new net.minecraft.src.ItemStack(nbttagcompound1);
        }

        public override void OnCollideWithPlayer(net.minecraft.src.EntityPlayer entityplayer)
        {
            if (worldObj.singleplayerWorld)
            {
                return;
            }

            int stackSize = item.stackSize;
            if (delayBeforeCanPickup == 0 && SanityCheckStackSize() && entityplayer.inventory.AddItemStackToInventory(item))
            {
                //SHARP: Do these even matter in MP?
                //if (item.itemID == net.minecraft.src.Block.wood.blockID)
                //{
                //    entityplayer.AddStatistic(net.minecraft.src.AchievementList.aCollectWood);
                //}
                //if (item.itemID == net.minecraft.src.Item.leather.shiftedIndex)
                //{
                //    entityplayer.AddStatistic(net.minecraft.src.AchievementList.aKillCow);
                //}
                worldObj.PlaySoundAtEntity(this, "random.pop", 0.2F, ((rand.NextFloat() - rand.NextFloat()) * 0.7F + 1.0F) * 2.0F);
                entityplayer.OnItemPickup(this, stackSize);
                if (item.stackSize <= 0)
                {
                    SetEntityDead();
                }
            }
        }

        //SHARP sanity check
        bool SanityCheckStackSize()
        {
            if (item.stackSize < 0)
            {
                item.stackSize = 0;
                SetEntityDead();
                return false;
            }
            if (item.stackSize > 128)
                item.stackSize = 128;

            return true;
        }

        public net.minecraft.src.ItemStack item;

        private int field_9170_e;

        public int age;

        public int delayBeforeCanPickup;

        private int health;

        public float field_432_ae;
    }
}
