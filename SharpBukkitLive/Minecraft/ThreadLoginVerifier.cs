// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;

namespace net.minecraft.src
{
	internal class ThreadLoginVerifier// : Thread
	{
		internal ThreadLoginVerifier(net.minecraft.src.NetLoginHandler netloginhandler, net.minecraft.src.Packet1Login
			 packet1login)
		{
			// Referenced classes of package net.minecraft.src:
			//            NetLoginHandler, Packet1Login
			//        super();
			loginHandler = netloginhandler;
			loginPacket = packet1login;
		}

		public void Run()
		{
			try
			{
				string s = net.minecraft.src.NetLoginHandler.GetServerId(loginHandler);
				Uri url = new Uri((new java.lang.StringBuilder()).Append("http://session.minecraft.net/game/checkserver.jsp?user="
					).Append(HttpUtility.UrlEncode(loginPacket.username, Encoding.UTF8)).Append("&serverId="
					).Append(HttpUtility.UrlEncode(s, Encoding.UTF8)).ToString());
				//java.io.BufferedReader bufferedreader = new java.io.BufferedReader(new java.io.InputStreamReader(url.OpenStream()));
				//string s1 = bufferedreader.ReadLine();
				//bufferedreader.Close();
				using (WebClient wc = new WebClient())
				{
					string s1 = wc.DownloadString(url);
					if (s1.Equals("YES"))
					{
						net.minecraft.src.NetLoginHandler.SetLoginPacket(loginHandler, loginPacket);
					}
					else
					{
						loginHandler.KickUser("Failed to verify username!");
					}
				}
			}
			catch (System.Exception exception)
			{
				loginHandler.KickUser((new java.lang.StringBuilder()).Append("Failed to verify username! [internal error "
					).Append(exception).Append("]").ToString());
				Sharpen.Runtime.PrintStackTrace(exception);
			}
		}

		internal readonly net.minecraft.src.Packet1Login loginPacket;

		internal readonly net.minecraft.src.NetLoginHandler loginHandler;
 /* synthetic field */
 /* synthetic field */
	}
}
