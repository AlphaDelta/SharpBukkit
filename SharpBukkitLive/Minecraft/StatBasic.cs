// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class StatBasic : net.minecraft.src.StatBase
	{
		public StatBasic(int i, string s, net.minecraft.src.IStatType istattype)
			: base(i, s, istattype)
		{
		}

		public StatBasic(int i, string s)
			: base(i, s)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            StatBase, StatList, IStatType
		public override net.minecraft.src.StatBase CheckDuplicate()
		{
			base.CheckDuplicate();
			net.minecraft.src.StatList.field_25122_b.Add(this);
			return this;
		}
	}
}
