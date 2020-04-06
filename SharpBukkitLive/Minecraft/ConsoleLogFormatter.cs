// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	//internal sealed class ConsoleLogFormatter// : java.util.logging.Formatter
	//{
	//	internal ConsoleLogFormatter()
	//	{
	//		dateFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
	//	}

	//	public override string Format(java.util.logging.LogRecord logrecord)
	//	{
	//		java.lang.StringBuilder stringbuilder = new java.lang.StringBuilder();
	//		stringbuilder.Append(dateFormat.Format(long.ValueOf(logrecord.GetMillis())));
	//		java.util.logging.Level level = logrecord.GetLevel();
	//		if (level == java.util.logging.Level.FINEST)
	//		{
	//			stringbuilder.Append(" [FINEST] ");
	//		}
	//		else
	//		{
	//			if (level == java.util.logging.Level.FINER)
	//			{
	//				stringbuilder.Append(" [FINER] ");
	//			}
	//			else
	//			{
	//				if (level == java.util.logging.Level.FINE)
	//				{
	//					stringbuilder.Append(" [FINE] ");
	//				}
	//				else
	//				{
	//					if (level == java.util.logging.Level.INFO)
	//					{
	//						stringbuilder.Append(" [INFO] ");
	//					}
	//					else
	//					{
	//						if (level == java.util.logging.Level.WARNING)
	//						{
	//							stringbuilder.Append(" [WARNING] ");
	//						}
	//						else
	//						{
	//							if (level == java.util.logging.Level.SEVERE)
	//							{
	//								stringbuilder.Append(" [SEVERE] ");
	//							}
	//							else
	//							{
	//								if (level == java.util.logging.Level.SEVERE)
	//								{
	//									stringbuilder.Append((new java.lang.StringBuilder()).Append(" [").Append(level.GetLocalizedName
	//										()).Append("] ").ToString());
	//								}
	//							}
	//						}
	//					}
	//				}
	//			}
	//		}
	//		stringbuilder.Append(logrecord.GetMessage());
	//		stringbuilder.Append('\n');
	//		System.Exception throwable = logrecord.GetThrown();
	//		if (throwable != null)
	//		{
	//			System.IO.StringWriter stringwriter = new System.IO.StringWriter();
	//			Sharpen.Runtime.PrintStackTrace(throwable, new java.io.PrintWriter(stringwriter));
	//			stringbuilder.Append(stringwriter.ToString());
	//		}
	//		return stringbuilder.ToString();
	//	}

	//	private java.text.SimpleDateFormat dateFormat;
	//}
}
