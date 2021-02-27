// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class Achievement : net.minecraft.src.StatBase
    {
        public Achievement(int i, string s, int j, int k, net.minecraft.src.Item item, net.minecraft.src.Achievement
             achievement)
            : this(i, s, j, k, new net.minecraft.src.ItemStack(item), achievement)
        {
        }

        public Achievement(int i, string s, int j, int k, net.minecraft.src.Block block,
            net.minecraft.src.Achievement achievement)
            : this(i, s, j, k, new net.minecraft.src.ItemStack(block), achievement)
        {
        }

        public Achievement(int i, string s, int j, int k, net.minecraft.src.ItemStack itemstack
            , net.minecraft.src.Achievement achievement)
            : base(0x500000 + i, net.minecraft.src.StatCollector.TranslateToLocal("achievement." + s))
        {
            // Referenced classes of package net.minecraft.src:
            //            StatBase, ItemStack, StatCollector, AchievementList, 
            //            Item, Block
            theItemStack = itemstack;
            field_27063_l = net.minecraft.src.StatCollector.TranslateToLocal("achievement." + s + ".desc");
            field_25067_a = j;
            field_27991_b = k;
            if (j < net.minecraft.src.AchievementList.field_27114_a)
            {
                net.minecraft.src.AchievementList.field_27114_a = j;
            }
            if (k < net.minecraft.src.AchievementList.field_27113_b)
            {
                net.minecraft.src.AchievementList.field_27113_b = k;
            }
            if (j > net.minecraft.src.AchievementList.field_27112_c)
            {
                net.minecraft.src.AchievementList.field_27112_c = j;
            }
            if (k > net.minecraft.src.AchievementList.field_27111_d)
            {
                net.minecraft.src.AchievementList.field_27111_d = k;
            }
            field_27992_c = achievement;
        }

        public virtual net.minecraft.src.Achievement Func_27059_a()
        {
            ServerStatistic = true;
            return this;
        }

        public virtual net.minecraft.src.Achievement Func_27060_b()
        {
            field_27062_m = true;
            return this;
        }

        public virtual net.minecraft.src.Achievement Func_27061_c()
        {
            base.CheckDuplicate();
            net.minecraft.src.AchievementList.AllAchievements.Add(this);
            return this;
        }

        public override net.minecraft.src.StatBase CheckDuplicate()
        {
            return Func_27061_c();
        }

        public override net.minecraft.src.StatBase SetServerStatistic()
        {
            return Func_27059_a();
        }

        public readonly int field_25067_a;

        public readonly int field_27991_b;

        public readonly net.minecraft.src.Achievement field_27992_c;

        private readonly string field_27063_l;

        public readonly net.minecraft.src.ItemStack theItemStack;

        private bool field_27062_m;
    }
}
