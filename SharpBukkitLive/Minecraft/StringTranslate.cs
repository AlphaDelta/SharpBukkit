// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.Properties;
using Sharpen;

namespace net.minecraft.src
{
	public class StringTranslate
	{
		private StringTranslate()
		{
			translateTable = new AlphaDelta.JavaProperties();
			translateTable.IgnoreDuplicateKeyErrors = true;
			try
			{
				translateTable.LoadString(Resources.en_US);
				translateTable.LoadString(Resources.stats_US);
			}
			catch (System.IO.IOException ioexception)
			{
				Sharpen.Runtime.PrintStackTrace(ioexception);
			}
		}

		public static net.minecraft.src.StringTranslate GetInstance()
		{
			return instance;
		}

		public virtual string TranslateKey(string s)
		{
			return translateTable[s];
		}

		public virtual string TranslateKeyFormat(string s, object[] aobj)
		{
			string s1 = translateTable[s];
			return string.Format(s1, aobj);
		}

		private static net.minecraft.src.StringTranslate instance = new net.minecraft.src.StringTranslate
			();

		private AlphaDelta.JavaProperties translateTable;
	}
}
