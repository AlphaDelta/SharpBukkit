// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Threading;

namespace net.minecraft.src
{
	internal class NetworkWriterThread// : java.lang.Thread
	{
		internal NetworkWriterThread(net.minecraft.src.NetworkManager networkmanager, string
			 s)
			//: base(s)
		{
			// Referenced classes of package net.minecraft.src:
			//            NetworkManager
			netManager = networkmanager;
		}

		public void Run()
		{
			lock (net.minecraft.src.NetworkManager.threadSyncObject)
			{
				net.minecraft.src.NetworkManager.numWriteThreads++;
			}
			try
			{
				do
				{
					if (!net.minecraft.src.NetworkManager.IsRunning(netManager))
					{
						break;
					}
					while (net.minecraft.src.NetworkManager.SendNetworkPacket(netManager))
					{
					}
					try
					{
						Thread.Sleep(100);
					}
					catch (System.Exception)
					{
					}
					try
					{
						if (net.minecraft.src.NetworkManager.Func_28136_f(netManager) != null)
						{
							net.minecraft.src.NetworkManager.Func_28136_f(netManager).Flush();
						}
					}
					catch (System.IO.IOException ioexception)
					{
						if (!net.minecraft.src.NetworkManager.Func_28135_e(netManager))
						{
							net.minecraft.src.NetworkManager.Func_30007_a(netManager, ioexception);
						}
						Sharpen.Runtime.PrintStackTrace(ioexception);
					}
				}
				while (true);
			}
			finally
			{
				lock (net.minecraft.src.NetworkManager.threadSyncObject)
				{
					net.minecraft.src.NetworkManager.numWriteThreads--;
				}
			}
		}

		internal readonly net.minecraft.src.NetworkManager netManager;
 /* synthetic field */
	}
}
