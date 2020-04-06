// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;

namespace net.minecraft.src
{
	public class ConsoleLogManager
	{
		public ConsoleLogManager()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            ConsoleLogFormatter
		public static void Init()
		{
			//net.minecraft.src.ConsoleLogFormatter consolelogformatter = new net.minecraft.src.ConsoleLogFormatter();
			//logger.SetUseParentHandlers(false);
			//java.util.logging.ConsoleHandler consolehandler = new java.util.logging.ConsoleHandler();
			//consolehandler.SetFormatter(consolelogformatter);
			//logger.AddHandler(consolehandler);
			try
			{
				//java.util.logging.FileHandler filehandler = new java.util.logging.FileHandler("server.log", true);
				//filehandler.SetFormatter(consolelogformatter);
				logger.AddHandler("server.log");
			}
			catch (System.Exception exception)
			{
				logger.Severe("Failed to log to server.log");
				logger.Log(exception.ToString());
				//logger.Log(java.util.logging.Level.WARNING, "Failed to log to server.log", exception);
			}
		}

		public static Logger logger = Logger.GetLogger();
		//public static java.util.logging.Logger logger = java.util.logging.Logger.GetLogger("Minecraft");
	}
}
