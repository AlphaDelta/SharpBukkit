// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class StatCollector
	{
		public StatCollector()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            StringTranslate
		public static string TranslateToLocal(string s)
		{
			return localizedName.TranslateKey(s);
		}

		public static string TranslateToLocalFormatted(string s, object[] aobj)
		{
			return localizedName.TranslateKeyFormat(s, aobj);
		}

		private static net.minecraft.src.StringTranslate localizedName = net.minecraft.src.StringTranslate
			.GetInstance();
	}
}
