// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
    public class StatList
    {
        public StatList()
        {
        }

        // Referenced classes of package net.minecraft.src:
        //            Block, CraftingManager, IRecipe, ItemStack, 
        //            FurnaceRecipes, StatBase, Item, StatCollector, 
        //            StatCrafting, BlockFlower, BlockGrass, StatBasic, 
        //            AchievementList
        public static void Func_27092_a() //???
        {
        }

        public static void Func_25088_a()
        {
            StatUseItem = Func_25090_a(StatUseItem, "stat.useItem", unchecked((int)0x1020000), 0, net.minecraft.src.Block.blocksList.Length);
            StatBreakItem = Func_25087_b(StatBreakItem, "stat.breakItem", unchecked((int)0x1030000), 0, net.minecraft.src.Block.blocksList.Length);
            field_25101_D = true;
            Func_25091_c();
        }

        public static void Func_25086_b()
        {
            StatUseItem = Func_25090_a(StatUseItem, "stat.useItem", unchecked((int)0x1020000), net.minecraft.src.Block.blocksList.Length, 32000);
            StatBreakItem = Func_25087_b(StatBreakItem, "stat.breakItem", unchecked((int)0x1030000), net.minecraft.src.Block.blocksList.Length, 32000);
            field_25099_E = true;
            Func_25091_c();
        }

        public static void Func_25091_c()
        {
            if (!field_25101_D || !field_25099_E)
            {
                return;
            }
            HashSet<int> hashset = new HashSet<int>();
            net.minecraft.src.IRecipe irecipe;
            for (System.Collections.IEnumerator iterator = net.minecraft.src.CraftingManager.GetInstance().GetRecipeList().GetEnumerator(); iterator.MoveNext(); hashset.Add(irecipe.Func_25077_b().itemID))
            {
                irecipe = (net.minecraft.src.IRecipe)iterator.Current;
            }
            net.minecraft.src.ItemStack itemstack;
            for (System.Collections.IEnumerator iterator1 = net.minecraft.src.FurnaceRecipes.Smelting().GetSmeltingList().Values.GetEnumerator(); iterator1.MoveNext(); hashset.Add(itemstack.itemID))
            {
                itemstack = (net.minecraft.src.ItemStack)iterator1.Current;
            }
            StatisticCraftItem = new net.minecraft.src.StatBase[32000];
            System.Collections.IEnumerator iterator2 = hashset.GetEnumerator();
            do
            {
                if (!iterator2.MoveNext())
                {
                    break;
                }
                int integer = (int)iterator2.Current;
                if (net.minecraft.src.Item.itemsList[integer] != null)
                {
                    string s = net.minecraft.src.StatCollector.TranslateToLocalFormatted("stat.craftItem", new object[] { net.minecraft.src.Item.itemsList[integer].Func_25006_i() });
                    StatisticCraftItem[integer] = (new net.minecraft.src.StatCrafting(unchecked((int)0x1010000) + integer, s, integer)).CheckDuplicate();
                }
            }
            while (true);
            ReplaceAllSimilarBlocks(StatisticCraftItem);
        }

        private static net.minecraft.src.StatBase[] GetMinedBlockStatistics(string s, int i)
        {
            net.minecraft.src.StatBase[] astatbase = new net.minecraft.src.StatBase[256];
            for (int j = 0; j < 256; j++)
            {
                if (net.minecraft.src.Block.blocksList[j] != null && net.minecraft.src.Block.blocksList
                    [j].GetEnableStats())
                {
                    string s1 = net.minecraft.src.StatCollector.TranslateToLocalFormatted(s, new object
                        [] { net.minecraft.src.Block.blocksList[j].GetNameLocalizedForStats() });
                    astatbase[j] = (new net.minecraft.src.StatCrafting(i + j, s1, j)).CheckDuplicate();
                    field_25120_d.Add((net.minecraft.src.StatCrafting)astatbase[j]);
                }
            }
            ReplaceAllSimilarBlocks(astatbase);
            return astatbase;
        }

        private static net.minecraft.src.StatBase[] Func_25090_a(net.minecraft.src.StatBase[] astatbase, string s, int i, int j, int k)
        {
            if (astatbase == null)
            {
                astatbase = new net.minecraft.src.StatBase[32000];
            }
            for (int l = j; l < k; l++)
            {
                if (net.minecraft.src.Item.itemsList[l] == null)
                {
                    continue;
                }
                string s1 = net.minecraft.src.StatCollector.TranslateToLocalFormatted(s, new object[] { net.minecraft.src.Item.itemsList[l].Func_25006_i() });
                astatbase[l] = new net.minecraft.src.StatCrafting(i + l, s1, l).CheckDuplicate();
                if (l >= net.minecraft.src.Block.blocksList.Length)
                {
                    field_25121_c.Add((net.minecraft.src.StatCrafting)astatbase[l]);
                }
            }
            ReplaceAllSimilarBlocks(astatbase);
            return astatbase;
        }

        private static net.minecraft.src.StatBase[] Func_25087_b(net.minecraft.src.StatBase[] astatbase, string s, int i, int j, int k)
        {
            if (astatbase == null)
            {
                astatbase = new net.minecraft.src.StatBase[32000];
            }
            for (int l = j; l < k; l++)
            {
                if (net.minecraft.src.Item.itemsList[l] != null && net.minecraft.src.Item.itemsList[l].Func_25005_e())
                {
                    string s1 = net.minecraft.src.StatCollector.TranslateToLocalFormatted(s, new object[] { net.minecraft.src.Item.itemsList[l].Func_25006_i() });
                    astatbase[l] = new net.minecraft.src.StatCrafting(i + l, s1, l).CheckDuplicate();
                }
            }
            ReplaceAllSimilarBlocks(astatbase);
            return astatbase;
        }

        private static void ReplaceAllSimilarBlocks(net.minecraft.src.StatBase[] astatbase)
        {
            ReplaceSimilarBlocks(astatbase, net.minecraft.src.Block.waterStill.blockID, net.minecraft.src.Block.waterMoving.blockID);
            ReplaceSimilarBlocks(astatbase, net.minecraft.src.Block.lavaStill.blockID, net.minecraft.src.Block.lavaStill.blockID);
            ReplaceSimilarBlocks(astatbase, net.minecraft.src.Block.pumpkinLantern.blockID, net.minecraft.src.Block.pumpkin.blockID);
            ReplaceSimilarBlocks(astatbase, net.minecraft.src.Block.stoneOvenActive.blockID, net.minecraft.src.Block.stoneOvenIdle.blockID);
            ReplaceSimilarBlocks(astatbase, net.minecraft.src.Block.oreRedstoneGlowing.blockID, net.minecraft.src.Block.oreRedstone.blockID);
            ReplaceSimilarBlocks(astatbase, net.minecraft.src.Block.redstoneRepeaterActive.blockID, net.minecraft.src.Block.redstoneRepeaterIdle.blockID);
            ReplaceSimilarBlocks(astatbase, net.minecraft.src.Block.torchRedstoneActive.blockID, net.minecraft.src.Block.torchRedstoneIdle.blockID);
            ReplaceSimilarBlocks(astatbase, net.minecraft.src.Block.mushroomRed.blockID, net.minecraft.src.Block.mushroomBrown.blockID);
            ReplaceSimilarBlocks(astatbase, net.minecraft.src.Block.stairDouble.blockID, net.minecraft.src.Block.stairSingle.blockID);
            ReplaceSimilarBlocks(astatbase, net.minecraft.src.Block.grass.blockID, net.minecraft.src.Block.dirt.blockID);
            ReplaceSimilarBlocks(astatbase, net.minecraft.src.Block.tilledField.blockID, net.minecraft.src.Block.dirt.blockID);
        }

        private static void ReplaceSimilarBlocks(net.minecraft.src.StatBase[] astatbase, int i, int j)
        {
            if (astatbase[i] != null && astatbase[j] == null)
            {
                astatbase[j] = astatbase[i];
                return;
            }
            else
            {
                field_25123_a.Remove(astatbase[i]);
                field_25120_d.Remove(astatbase[i]);
                field_25122_b.Remove(astatbase[i]);
                astatbase[i] = astatbase[j];
                return;
            }
        }

        protected internal static System.Collections.IDictionary StatisticHashtable = new System.Collections.Hashtable();
        public static List<StatBase> field_25123_a = new List<StatBase>();
        public static List<StatBase> field_25122_b = new List<StatBase>();
        public static List<StatBase> field_25121_c = new List<StatBase>();
        public static List<StatBase> field_25120_d = new List<StatBase>();

        public static net.minecraft.src.StatBase StatStartGame = new net.minecraft.src.StatBasic(1000, net.minecraft.src.StatCollector.TranslateToLocal("stat.startGame")).SetServerStatistic().CheckDuplicate();
        public static net.minecraft.src.StatBase StatCreateWorld = new net.minecraft.src.StatBasic(1001, net.minecraft.src.StatCollector.TranslateToLocal("stat.createWorld")).SetServerStatistic().CheckDuplicate();
        public static net.minecraft.src.StatBase StatLoadWorld = new net.minecraft.src.StatBasic(1002, net.minecraft.src.StatCollector.TranslateToLocal("stat.loadWorld")).SetServerStatistic().CheckDuplicate();
        public static net.minecraft.src.StatBase StatJoinMultiplayer = new net.minecraft.src.StatBasic(1003, net.minecraft.src.StatCollector.TranslateToLocal("stat.joinMultiplayer")).SetServerStatistic().CheckDuplicate();
        public static net.minecraft.src.StatBase StatLeaveGame = new net.minecraft.src.StatBasic(1004, net.minecraft.src.StatCollector.TranslateToLocal("stat.leaveGame")).SetServerStatistic().CheckDuplicate();

        public static net.minecraft.src.StatBase StatPlayOneMinute;
        public static net.minecraft.src.StatBase StatWalkOneCm;
        public static net.minecraft.src.StatBase StatSwimOneCm;
        public static net.minecraft.src.StatBase StatFallOneCm;
        public static net.minecraft.src.StatBase StatClimbOneCm;
        public static net.minecraft.src.StatBase StatFlyOneCm;
        public static net.minecraft.src.StatBase StatDiveOneCm;
        public static net.minecraft.src.StatBase StatMinecartOneCm;
        public static net.minecraft.src.StatBase StatBoatOneCm;
        public static net.minecraft.src.StatBase StatPigOneCm;

        public static net.minecraft.src.StatBase StatJump = (new net.minecraft.src.StatBasic(2010, net.minecraft.src.StatCollector.TranslateToLocal("stat.jump"))).SetServerStatistic().CheckDuplicate();
        public static net.minecraft.src.StatBase StatDrop = (new net.minecraft.src.StatBasic(2011, net.minecraft.src.StatCollector.TranslateToLocal("stat.drop"))).SetServerStatistic().CheckDuplicate();
        public static net.minecraft.src.StatBase StatDamageDealt = (new net.minecraft.src.StatBasic(2020, net.minecraft.src.StatCollector.TranslateToLocal("stat.damageDealt"))).CheckDuplicate();
        public static net.minecraft.src.StatBase StatDamageTaken = (new net.minecraft.src.StatBasic(2021, net.minecraft.src.StatCollector.TranslateToLocal("stat.damageTaken"))).CheckDuplicate();
        public static net.minecraft.src.StatBase StatDeaths = (new net.minecraft.src.StatBasic(2022, net.minecraft.src.StatCollector.TranslateToLocal("stat.deaths"))).CheckDuplicate();
        public static net.minecraft.src.StatBase StatMobKills = (new net.minecraft.src.StatBasic(2023, net.minecraft.src.StatCollector.TranslateToLocal("stat.mobKills"))).CheckDuplicate();
        public static net.minecraft.src.StatBase StatPlayerKills = (new net.minecraft.src.StatBasic(2024, net.minecraft.src.StatCollector.TranslateToLocal("stat.playerKills"))).CheckDuplicate();
        public static net.minecraft.src.StatBase StatFishCaught = (new net.minecraft.src.StatBasic(2025, net.minecraft.src.StatCollector.TranslateToLocal("stat.fishCaught"))).CheckDuplicate();

        public static net.minecraft.src.StatBase[] StatMinedBlocks = GetMinedBlockStatistics("stat.mineBlock", 0);

        public static net.minecraft.src.StatBase[] StatisticCraftItem;

        public static net.minecraft.src.StatBase[] StatUseItem;

        public static net.minecraft.src.StatBase[] StatBreakItem;

        private static bool field_25101_D = false;

        private static bool field_25099_E = false;

        static StatList()
        {
            StatPlayOneMinute = new net.minecraft.src.StatBasic(1100, net.minecraft.src.StatCollector.TranslateToLocal("stat.playOneMinute"), net.minecraft.src.StatBase.StatTypeTime).SetServerStatistic().CheckDuplicate();
            StatWalkOneCm = new net.minecraft.src.StatBasic(2000, net.minecraft.src.StatCollector.TranslateToLocal("stat.walkOneCm"), net.minecraft.src.StatBase.StatTypeDistance).SetServerStatistic().CheckDuplicate();
            StatSwimOneCm = new net.minecraft.src.StatBasic(2001, net.minecraft.src.StatCollector.TranslateToLocal("stat.swimOneCm"), net.minecraft.src.StatBase.StatTypeDistance).SetServerStatistic().CheckDuplicate();
            StatFallOneCm = new net.minecraft.src.StatBasic(2002, net.minecraft.src.StatCollector.TranslateToLocal("stat.fallOneCm"), net.minecraft.src.StatBase.StatTypeDistance).SetServerStatistic().CheckDuplicate();
            StatClimbOneCm = new net.minecraft.src.StatBasic(2003, net.minecraft.src.StatCollector.TranslateToLocal("stat.climbOneCm"), net.minecraft.src.StatBase.StatTypeDistance).SetServerStatistic().CheckDuplicate();
            StatFlyOneCm = new net.minecraft.src.StatBasic(2004, net.minecraft.src.StatCollector.TranslateToLocal("stat.flyOneCm"), net.minecraft.src.StatBase.StatTypeDistance).SetServerStatistic().CheckDuplicate();
            StatDiveOneCm = new net.minecraft.src.StatBasic(2005, net.minecraft.src.StatCollector.TranslateToLocal("stat.diveOneCm"), net.minecraft.src.StatBase.StatTypeDistance).SetServerStatistic().CheckDuplicate();
            StatMinecartOneCm = new net.minecraft.src.StatBasic(2006, net.minecraft.src.StatCollector.TranslateToLocal("stat.minecartOneCm"), net.minecraft.src.StatBase.StatTypeDistance).SetServerStatistic().CheckDuplicate();
            StatBoatOneCm = new net.minecraft.src.StatBasic(2007, net.minecraft.src.StatCollector.TranslateToLocal("stat.boatOneCm"), net.minecraft.src.StatBase.StatTypeDistance).SetServerStatistic().CheckDuplicate();
            StatPigOneCm = new net.minecraft.src.StatBasic(2008, net.minecraft.src.StatCollector.TranslateToLocal("stat.pigOneCm"), net.minecraft.src.StatBase.StatTypeDistance).SetServerStatistic().CheckDuplicate();
            net.minecraft.src.AchievementList.Func_27097_a();
        }
    }
}
