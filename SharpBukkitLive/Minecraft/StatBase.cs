// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class StatBase
	{
		public StatBase(int i, string s, net.minecraft.src.IStatType istattype)
		{
			// Referenced classes of package net.minecraft.src:
			//            StatList, AchievementMap, StatTypeSimple, StatTypeTime, 
			//            StatTypeDistance, IStatType
			ServerStatistic = false;
			statId = i;
			statName = s;
			field_25065_a = istattype;
		}

		public StatBase(int i, string s)
			: this(i, s, StatTypeSimple)
		{
		}

		public virtual net.minecraft.src.StatBase SetServerStatistic()
		{
			ServerStatistic = true;
			return this;
		}

		public virtual net.minecraft.src.StatBase CheckDuplicate()
		{
			if (net.minecraft.src.StatList.StatisticHashtable.Contains(statId))
			{
				throw new System.Exception((new java.lang.StringBuilder()).Append("Duplicate stat id: \""
					).Append(((net.minecraft.src.StatBase)net.minecraft.src.StatList.StatisticHashtable[statId]).statName).Append("\" and \"").Append(statName).Append("\" at id ").Append
					(statId).ToString());
			}
			else
			{
				net.minecraft.src.StatList.field_25123_a.Add(this);
				net.minecraft.src.StatList.StatisticHashtable[statId] = this;
				field_27057_h = net.minecraft.src.AchievementMap.Func_25132_a(statId);
				return this;
			}
		}

		public override string ToString()
		{
			return statName;
		}

		public readonly int statId;

		public readonly string statName;

		public bool ServerStatistic;

		public string field_27057_h;

		private readonly net.minecraft.src.IStatType field_25065_a;

		//private static java.text.NumberFormat field_25066_b;

		public static net.minecraft.src.IStatType StatTypeSimple = new net.minecraft.src.StatTypeSimple();

		//private static java.text.DecimalFormat field_25068_c = new java.text.DecimalFormat("########0.00");

		public static net.minecraft.src.IStatType StatTypeTime = new net.minecraft.src.StatTypeTime();

		public static net.minecraft.src.IStatType StatTypeDistance = new net.minecraft.src.StatTypeDistance();

		static StatBase()
		{
			//field_25066_b = java.text.NumberFormat.GetIntegerInstance(java.util.Locale.US);
		}
	}
}
