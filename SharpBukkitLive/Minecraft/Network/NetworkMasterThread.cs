// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Threading;

namespace net.minecraft.src
{
	internal class NetworkMasterThread// : java.lang.Thread
	{
		internal NetworkMasterThread(net.minecraft.src.NetworkManager networkmanager)
		{
			// Referenced classes of package net.minecraft.src:
			//            NetworkManager
			//        super();
			netManager = networkmanager;
		}

		public void Run() //TODO: Make redundant
		{
			try
			{
				Thread.Sleep(5000);
				if (net.minecraft.src.NetworkManager.GetReadThread(netManager).IsAlive)
				{
					try
					{
						net.minecraft.src.NetworkManager.GetReadThread(netManager).Abort();
					}
					catch
					{
					}
				}
				if (net.minecraft.src.NetworkManager.GetWriteThread(netManager).IsAlive)
				{
					try
					{
						net.minecraft.src.NetworkManager.GetWriteThread(netManager).Abort();
					}
					catch
					{
					}
				}
			}
			catch (System.Exception interruptedexception)
			{
				Sharpen.Runtime.PrintStackTrace(interruptedexception);
			}
		}

		internal readonly net.minecraft.src.NetworkManager netManager;
 /* synthetic field */
	}
}
