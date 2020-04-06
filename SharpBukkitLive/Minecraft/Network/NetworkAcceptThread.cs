// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Net;
using System.Net.Sockets;

namespace net.minecraft.src
{
	internal class NetworkAcceptThread// : java.lang.Thread
	{
		internal NetworkAcceptThread(net.minecraft.src.NetworkListenThread networklistenthread
			, string s, net.minecraft.server.MinecraftServer minecraftserver)
			//: base(s)
		{
			// Referenced classes of package net.minecraft.src:
			//            NetworkListenThread, NetLoginHandler
			field_985_b = networklistenthread;
			mcServer = minecraftserver;
		}

		public void Run()
		{
			System.Collections.Hashtable hashmap = new System.Collections.Hashtable();
			do
			{
				if (!field_985_b.field_973_b)
				{
					break;
				}
				try
				{
					Socket socket = net.minecraft.src.NetworkListenThread.Func_713_a(field_985_b).AcceptSocket();
					if (socket != null)
					{
						//java.net.InetAddress inetaddress = socket.GetInetAddress();
						var inetaddress = ((IPEndPoint)socket.RemoteEndPoint);
						if (hashmap.Contains(inetaddress) && !"127.0.0.1".Equals(inetaddress.Address) && Sharpen.Runtime.CurrentTimeMillis() - ((long)hashmap[inetaddress]) < 5000L)
						{
							hashmap[inetaddress] = Sharpen.Runtime.CurrentTimeMillis();
							socket.Close();
						}
						else
						{
							hashmap[inetaddress] = Sharpen.Runtime.CurrentTimeMillis();
							net.minecraft.src.NetLoginHandler netloginhandler = new net.minecraft.src.NetLoginHandler
								(mcServer, socket, (new java.lang.StringBuilder()).Append("Connection #").Append
								(net.minecraft.src.NetworkListenThread.Func_712_b(field_985_b)).ToString());
							net.minecraft.src.NetworkListenThread.Func_716_a(field_985_b, netloginhandler);
						}
					}
				}
				catch (System.IO.IOException ioexception)
				{
					Sharpen.Runtime.PrintStackTrace(ioexception);
				}
			}
			while (true);
		}

		internal readonly net.minecraft.server.MinecraftServer mcServer;

		internal readonly net.minecraft.src.NetworkListenThread field_985_b;
 /* synthetic field */
 /* synthetic field */
	}
}
