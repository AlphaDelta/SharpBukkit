// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

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

		public static System.Collections.IList field_25129_a;

		public static net.minecraft.src.Achievement field_25128_b;

		public static net.minecraft.src.Achievement field_25131_c;

		public static net.minecraft.src.Achievement field_25130_d;

		public static net.minecraft.src.Achievement field_27110_i;

		public static net.minecraft.src.Achievement field_27109_j;

		public static net.minecraft.src.Achievement field_27108_k;

		public static net.minecraft.src.Achievement field_27107_l;

		public static net.minecraft.src.Achievement field_27106_m;

		public static net.minecraft.src.Achievement field_27105_n;

		public static net.minecraft.src.Achievement field_27104_o;

		public static net.minecraft.src.Achievement field_27103_p;

		public static net.minecraft.src.Achievement field_27102_q;

		public static net.minecraft.src.Achievement field_27101_r;

		public static net.minecraft.src.Achievement field_27100_s;

		public static net.minecraft.src.Achievement field_27099_t;

		public static net.minecraft.src.Achievement field_27098_u;

		static AchievementList()
		{
			field_25129_a = new System.Collections.ArrayList();
			field_25128_b = (new net.minecraft.src.Achievement(0, "openInventory", 0, 0, net.minecraft.src.Item
				.book, null)).Func_27059_a().Func_27061_c();
			field_25131_c = (new net.minecraft.src.Achievement(1, "mineWood", 2, 1, net.minecraft.src.Block
				.wood, field_25128_b)).Func_27061_c();
			field_25130_d = (new net.minecraft.src.Achievement(2, "buildWorkBench", 4, -1, net.minecraft.src.Block
				.workbench, field_25131_c)).Func_27061_c();
			field_27110_i = (new net.minecraft.src.Achievement(3, "buildPickaxe", 4, 2, net.minecraft.src.Item
				.pickaxeWood, field_25130_d)).Func_27061_c();
			field_27109_j = (new net.minecraft.src.Achievement(4, "buildFurnace", 3, 4, net.minecraft.src.Block
				.stoneOvenActive, field_27110_i)).Func_27061_c();
			field_27108_k = (new net.minecraft.src.Achievement(5, "acquireIron", 1, 4, net.minecraft.src.Item
				.ingotIron, field_27109_j)).Func_27061_c();
			field_27107_l = (new net.minecraft.src.Achievement(6, "buildHoe", 2, -3, net.minecraft.src.Item
				.hoeWood, field_25130_d)).Func_27061_c();
			field_27106_m = (new net.minecraft.src.Achievement(7, "makeBread", -1, -3, net.minecraft.src.Item
				.bread, field_27107_l)).Func_27061_c();
			field_27105_n = (new net.minecraft.src.Achievement(8, "bakeCake", 0, -5, net.minecraft.src.Item
				.cake, field_27107_l)).Func_27061_c();
			field_27104_o = (new net.minecraft.src.Achievement(9, "buildBetterPickaxe", 6, 2, 
				net.minecraft.src.Item.pickaxeStone, field_27110_i)).Func_27061_c();
			field_27103_p = (new net.minecraft.src.Achievement(10, "cookFish", 2, 6, net.minecraft.src.Item
				.fishCooked, field_27109_j)).Func_27061_c();
			field_27102_q = (new net.minecraft.src.Achievement(11, "onARail", 2, 3, net.minecraft.src.Block
				.minecartTrack, field_27108_k)).Func_27060_b().Func_27061_c();
			field_27101_r = (new net.minecraft.src.Achievement(12, "buildSword", 6, -1, net.minecraft.src.Item
				.swordWood, field_25130_d)).Func_27061_c();
			field_27100_s = (new net.minecraft.src.Achievement(13, "killEnemy", 8, -1, net.minecraft.src.Item
				.bone, field_27101_r)).Func_27061_c();
			field_27099_t = (new net.minecraft.src.Achievement(14, "killCow", 7, -3, net.minecraft.src.Item
				.leather, field_27101_r)).Func_27061_c();
			field_27098_u = (new net.minecraft.src.Achievement(15, "flyPig", 8, -4, net.minecraft.src.Item
				.saddle, field_27099_t)).Func_27060_b().Func_27061_c();
			System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append(field_25129_a
				.Count).Append(" achievements").ToString());
		}
	}
}
