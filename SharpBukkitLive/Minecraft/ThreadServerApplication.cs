// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public sealed class ThreadServerApplication// : java.lang.Thread
	{
		public ThreadServerApplication(string s, net.minecraft.server.MinecraftServer minecraftserver
			)
			//: base(s)
		{
			mcServer = minecraftserver;
		}

		public void Run()
		{
			mcServer.Run();
		}

		internal readonly net.minecraft.server.MinecraftServer mcServer;
 /* synthetic field */
	}
}
