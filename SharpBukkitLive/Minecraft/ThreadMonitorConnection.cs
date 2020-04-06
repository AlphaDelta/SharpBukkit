// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Threading;

namespace net.minecraft.src
{
	internal class ThreadMonitorConnection// : java.lang.Thread
	{
		internal ThreadMonitorConnection(net.minecraft.src.NetworkManager networkmanager)
		{
			// Referenced classes of package net.minecraft.src:
			//            NetworkManager
			//        super();
			netManager = networkmanager;
		}

		public void Run()
		{
			try
			{
				Thread.Sleep(2000);
				if (net.minecraft.src.NetworkManager.IsRunning(netManager))
				{
					net.minecraft.src.NetworkManager.GetWriteThread(netManager).Interrupt();
					netManager.NetworkShutdown("disconnect.closed", new object[0]);
				}
			}
			catch (System.Exception exception)
			{
				Sharpen.Runtime.PrintStackTrace(exception);
			}
		}

		internal readonly net.minecraft.src.NetworkManager netManager;
 /* synthetic field */
	}
}
