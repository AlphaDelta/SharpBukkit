﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SharpBukkitLive.SharpBukkit
{
    public static class Entrypoint
    {
		public static Logger logger = Logger.GetLogger();
		public static void Main(string[] args)
		{
			net.minecraft.src.StatList.Func_27092_a();
			try
			{
				net.minecraft.server.MinecraftServer minecraftserver = new net.minecraft.server.MinecraftServer
					();
				//if (!java.awt.GraphicsEnvironment.IsHeadless() && (args.Length <= 0 || !args[0].Equals("nogui")))
				//{
				//	net.minecraft.src.ServerGUI.InitGui(minecraftserver);
				//}
				Thread t = new Thread(() => { (new net.minecraft.src.ThreadServerApplication("Server thread", minecraftserver)).Run(); });
				t.Start();
			}
			catch (System.Exception exception)
			{
				logger.Severe("Failed to start the minecraft server");
				logger.Log(exception.ToString());
				//logger.Log(java.util.logging.Level.SEVERE, "Failed to start the minecraft server", exception);
			}
		}
	}
}