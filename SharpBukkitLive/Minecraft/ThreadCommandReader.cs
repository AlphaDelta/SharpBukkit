// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System;

namespace net.minecraft.src
{
	public class ThreadCommandReader// : java.lang.Thread
	{
		public ThreadCommandReader(net.minecraft.server.MinecraftServer minecraftserver)
		{
			//        super();
			mcServer = minecraftserver;
		}

		public void Run()
		{
			//java.io.BufferedReader bufferedreader = new java.io.BufferedReader(new java.io.InputStreamReader(Sharpen.Runtime.@in));
			string s = null;
			try
			{
				while (!mcServer.serverStopped && net.minecraft.server.MinecraftServer.IsServerRunning(mcServer) && (s = Console.ReadLine()) != null)
				{
					mcServer.AddCommand(s, mcServer);
				}
			}
			catch (System.IO.IOException ioexception)
			{
				Sharpen.Runtime.PrintStackTrace(ioexception);
			}
		}

		internal readonly net.minecraft.server.MinecraftServer mcServer;
 /* synthetic field */
	}
}
