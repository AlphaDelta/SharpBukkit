// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public sealed class ItemStack
    {
        public ItemStack(net.minecraft.src.Block block)
            : this(block, 1)
        {
        }

        public ItemStack(net.minecraft.src.Block block, int i)
            : this(block.ID, i, 0)
        {
        }

        public ItemStack(net.minecraft.src.Block block, int i, int j)
            : this(block.ID, i, j)
        {
        }

        public ItemStack(net.minecraft.src.Item item)
            : this(item.ID, 1, 0)
        {
        }

        public ItemStack(net.minecraft.src.Item item, int i)
            : this(item.ID, i, 0)
        {
        }

        public ItemStack(net.minecraft.src.Item item, int i, int j)
            : this(item.ID, i, j)
        {
        }

        public ItemStack(int itemID, int stackSize, int itemDamage)
        {
            // Referenced classes of package net.minecraft.src:
            //            Block, Item, StatList, EntityPlayer, 
            //            NBTTagCompound, World, Entity, EntityLiving
            this.stackSize = 0;
            this.itemID = itemID;
            this.stackSize = stackSize;
            this.itemDamage = itemDamage;
        }

        public ItemStack(net.minecraft.src.NBTTagCompound nbttagcompound)
        {
            stackSize = 0;
            ReadFromNBT(nbttagcompound);
        }

        public net.minecraft.src.ItemStack SplitStack(int i)
        {
            //TODO: Do proper sanity check to prevent duplication (Maybe... might break a lot of other methods)
            if(stackSize <= 0)
                return new net.minecraft.src.ItemStack(net.minecraft.src.Item.SNOW_BALL, i, itemDamage);
            //===================================================

            stackSize -= i;
            return new net.minecraft.src.ItemStack(itemID, i, itemDamage);
        }

        public net.minecraft.src.Item GetItem()
        {
            return net.minecraft.src.Item.itemsList[itemID];
        }

        public bool UseItem(net.minecraft.src.EntityPlayer entityplayer, net.minecraft.src.World
             world, int i, int j, int k, int l)
        {
            bool flag = GetItem().OnItemUse(this, entityplayer, world, i, j, k, l);
            if (flag)
            {
                entityplayer.AddStat(net.minecraft.src.StatList.StatUseItem[itemID], 1);
            }
            return flag;
        }

        public float GetStrVsBlock(net.minecraft.src.Block block)
        {
            return GetItem().GetStrVsBlock(this, block);
        }

        public net.minecraft.src.ItemStack UseItemRightClick(net.minecraft.src.World world
            , net.minecraft.src.EntityPlayer entityplayer)
        {
            return GetItem().OnItemRightClick(this, world, entityplayer);
        }

        public net.minecraft.src.NBTTagCompound WriteToNBT(net.minecraft.src.NBTTagCompound
             nbttagcompound)
        {
            nbttagcompound.SetShort("id", (short)itemID);
            nbttagcompound.SetByte("Count", unchecked((byte)stackSize));
            nbttagcompound.SetShort("Damage", (short)itemDamage);
            return nbttagcompound;
        }

        public void ReadFromNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
        {
            itemID = nbttagcompound.GetShort("id");
            stackSize = nbttagcompound.GetByte("Count");
            itemDamage = nbttagcompound.GetShort("Damage");
        }

        public int GetMaxStackSize()
        {
            return GetItem().GetItemStackLimit();
        }

        public bool Func_21132_c()
        {
            return GetMaxStackSize() > 1 && (!IsItemStackDamageable() || !IsItemDamaged());
        }

        public bool IsItemStackDamageable()
        {
            return net.minecraft.src.Item.itemsList[itemID].GetMaxDamage() > 0;
        }

        public bool GetHasSubtypes()
        {
            return net.minecraft.src.Item.itemsList[itemID].GetHasSubtypes();
        }

        public bool IsItemDamaged()
        {
            return IsItemStackDamageable() && itemDamage > 0;
        }

        public int GetItemDamageForDisplay()
        {
            return itemDamage;
        }

        public int GetItemDamage()
        {
            return itemDamage;
        }

        public void SetItemDamage(int i)
        {
            itemDamage = i;
        }

        public int GetMaxDamage()
        {
            return net.minecraft.src.Item.itemsList[itemID].GetMaxDamage();
        }

        public void DamageItem(int i, net.minecraft.src.Entity entity)
        {
            if (!IsItemStackDamageable())
            {
                return;
            }
            itemDamage += i;
            if (itemDamage > GetMaxDamage())
            {
                if (entity is net.minecraft.src.EntityPlayer)
                {
                    ((net.minecraft.src.EntityPlayer)entity).AddStat(net.minecraft.src.StatList.StatBreakItem
                        [itemID], 1);
                }
                stackSize--;
                if (stackSize < 0)
                {
                    stackSize = 0;
                }
                itemDamage = 0;
            }
        }

        public void HitEntity(net.minecraft.src.EntityLiving entityliving, net.minecraft.src.EntityPlayer
             entityplayer)
        {
            bool flag = net.minecraft.src.Item.itemsList[itemID].HitEntity(this, entityliving
                , entityplayer);
            if (flag)
            {
                entityplayer.AddStat(net.minecraft.src.StatList.StatUseItem[itemID], 1);
            }
        }

        public void Func_25124_a(int i, int j, int k, int l, net.minecraft.src.EntityPlayer
             entityplayer)
        {
            bool flag = net.minecraft.src.Item.itemsList[itemID].Func_25007_a(this, i, j, k,
                l, entityplayer);
            if (flag)
            {
                entityplayer.AddStat(net.minecraft.src.StatList.StatUseItem[itemID], 1);
            }
        }

        public int GetDamageVsEntity(net.minecraft.src.Entity entity)
        {
            return net.minecraft.src.Item.itemsList[itemID].GetDamageVsEntity(entity);
        }

        public bool CanHarvestBlock(net.minecraft.src.Block block)
        {
            return net.minecraft.src.Item.itemsList[itemID].CanHarvestBlock(block);
        }

        public void Func_577_a(net.minecraft.src.EntityPlayer entityplayer)
        {
        }

        public void UseItemOnEntity(net.minecraft.src.EntityLiving entityliving)
        {
            net.minecraft.src.Item.itemsList[itemID].SaddleEntity(this, entityliving);
        }

        public net.minecraft.src.ItemStack Copy()
        {
            return new net.minecraft.src.ItemStack(itemID, stackSize, itemDamage);
        }

        public static bool AreItemStacksEqual(net.minecraft.src.ItemStack itemstack, net.minecraft.src.ItemStack
             itemstack1)
        {
            if (itemstack == null && itemstack1 == null)
            {
                return true;
            }
            if (itemstack == null || itemstack1 == null)
            {
                return false;
            }
            else
            {
                return itemstack.IsItemStackEqual(itemstack1);
            }
        }

        private bool IsItemStackEqual(net.minecraft.src.ItemStack itemstack)
        {
            if (stackSize != itemstack.stackSize)
            {
                return false;
            }
            if (itemID != itemstack.itemID)
            {
                return false;
            }
            return itemDamage == itemstack.itemDamage;
        }

        public bool IsItemEqual(net.minecraft.src.ItemStack itemstack)
        {
            return itemID == itemstack.itemID && itemDamage == itemstack.itemDamage;
        }

        public static net.minecraft.src.ItemStack CloneStack(net.minecraft.src.ItemStack
             itemstack)
        {
            return itemstack != null ? itemstack.Copy() : null;
        }

        public override string ToString()
        {
            return (new java.lang.StringBuilder()).Append(stackSize).Append("x").Append(net.minecraft.src.Item
                .itemsList[itemID].GetItemName()).Append("@").Append(itemDamage).ToString();
        }

        public void Func_28143_a(net.minecraft.src.World world, net.minecraft.src.Entity
            entity, int i, bool flag)
        {
            if (animationsToGo > 0)
            {
                animationsToGo--;
            }
            net.minecraft.src.Item.itemsList[itemID].Func_28018_a(this, world, entity, i, flag);
        }

        public void AddCraftStatistic(net.minecraft.src.World world, net.minecraft.src.EntityPlayer entityplayer)
        {
            entityplayer.AddStat(net.minecraft.src.StatList.StatisticCraftItem[itemID], stackSize);
            net.minecraft.src.Item.itemsList[itemID].Func_28020_c(this, world, entityplayer);
        }

        public bool CompareStacks(net.minecraft.src.ItemStack itemstack)
        {
            return itemID == itemstack.itemID && stackSize == itemstack.stackSize && itemDamage
                 == itemstack.itemDamage;
        }

        //SHARP sanity check
        private int _stackSize;
        public int stackSize
        {
            get
            {
                return _stackSize;
            }
            set
            {
                if (value < 0) _stackSize = 0;
                else if (value > 128) _stackSize = 128;
                else _stackSize = value;
            }
        }

        public int animationsToGo;

        public int itemID;

        private int itemDamage;
    }
}
