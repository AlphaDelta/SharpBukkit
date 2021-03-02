// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
    public class AchievementList
    {
        public AchievementList()
        {
        }

        // Referenced classes of package net.minecraft.src:
        //            Achievement, Item, Block
        public static void Func_27097_a()
        {
        }

        public static int field_27114_a;

        public static int field_27113_b;

        public static int field_27112_c;

        public static int field_27111_d;

        public static List<Achievement> AllAchievements;

        public static net.minecraft.src.Achievement aOpenInventory;
        public static net.minecraft.src.Achievement aCollectWood;
        public static net.minecraft.src.Achievement aBuildWorkBench;
        public static net.minecraft.src.Achievement aBuildPickaxe;
        public static net.minecraft.src.Achievement aBuildFurnace;
        public static net.minecraft.src.Achievement aAcquireIron;
        public static net.minecraft.src.Achievement aBuildHoe;
        public static net.minecraft.src.Achievement aMakeBreak;
        public static net.minecraft.src.Achievement aBakeCake;
        public static net.minecraft.src.Achievement aBuildBetterPickaxe;
        public static net.minecraft.src.Achievement aCookFish;
        public static net.minecraft.src.Achievement aOnARail;
        public static net.minecraft.src.Achievement aBuildSword;
        public static net.minecraft.src.Achievement aKillEnemy;
        public static net.minecraft.src.Achievement aKillCow;
        public static net.minecraft.src.Achievement aFlyPig;

        static AchievementList()
        {
            AllAchievements = new List<Achievement>();
            aOpenInventory = (new net.minecraft.src.Achievement(0, "openInventory", 0, 0, net.minecraft.src.Item.BOOK, null)).Func_27059_a().Func_27061_c();
            aCollectWood = (new net.minecraft.src.Achievement(1, "mineWood", 2, 1, net.minecraft.src.Block.LOG, aOpenInventory)).Func_27061_c();
            aBuildWorkBench = (new net.minecraft.src.Achievement(2, "buildWorkBench", 4, -1, net.minecraft.src.Block.WORKBENCH, aCollectWood)).Func_27061_c();
            aBuildPickaxe = (new net.minecraft.src.Achievement(3, "buildPickaxe", 4, 2, net.minecraft.src.Item.WOOD_PICKAXE, aBuildWorkBench)).Func_27061_c();
            aBuildFurnace = (new net.minecraft.src.Achievement(4, "buildFurnace", 3, 4, net.minecraft.src.Block.BURNING_FURNACE, aBuildPickaxe)).Func_27061_c();
            aAcquireIron = (new net.minecraft.src.Achievement(5, "acquireIron", 1, 4, net.minecraft.src.Item.IRON_INGOT, aBuildFurnace)).Func_27061_c();
            aBuildHoe = (new net.minecraft.src.Achievement(6, "buildHoe", 2, -3, net.minecraft.src.Item.WOOD_HOE, aBuildWorkBench)).Func_27061_c();
            aMakeBreak = (new net.minecraft.src.Achievement(7, "makeBread", -1, -3, net.minecraft.src.Item.BREAD, aBuildHoe)).Func_27061_c();
            aBakeCake = (new net.minecraft.src.Achievement(8, "bakeCake", 0, -5, net.minecraft.src.Item.CAKE, aBuildHoe)).Func_27061_c();
            aBuildBetterPickaxe = (new net.minecraft.src.Achievement(9, "buildBetterPickaxe", 6, 2, net.minecraft.src.Item.STONE_PICKAXE, aBuildPickaxe)).Func_27061_c();
            aCookFish = (new net.minecraft.src.Achievement(10, "cookFish", 2, 6, net.minecraft.src.Item.COOKED_FISH, aBuildFurnace)).Func_27061_c();
            aOnARail = (new net.minecraft.src.Achievement(11, "onARail", 2, 3, net.minecraft.src.Block.RAILS, aAcquireIron)).Func_27060_b().Func_27061_c();
            aBuildSword = (new net.minecraft.src.Achievement(12, "buildSword", 6, -1, net.minecraft.src.Item.WOOD_SWORD, aBuildWorkBench)).Func_27061_c();
            aKillEnemy = (new net.minecraft.src.Achievement(13, "killEnemy", 8, -1, net.minecraft.src.Item.BONE, aBuildSword)).Func_27061_c();
            aKillCow = (new net.minecraft.src.Achievement(14, "killCow", 7, -3, net.minecraft.src.Item.LEATHER, aBuildSword)).Func_27061_c();
            aFlyPig = (new net.minecraft.src.Achievement(15, "flyPig", 8, -4, net.minecraft.src.Item.SADDLE, aKillCow)).Func_27060_b().Func_27061_c();
            System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append(AllAchievements.Count).Append(" achievements").ToString());
        }
    }
}
