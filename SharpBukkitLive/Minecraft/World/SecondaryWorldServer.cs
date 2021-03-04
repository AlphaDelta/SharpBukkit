// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class SecondaryWorldServer : net.minecraft.src.WorldServer
	{
		public SecondaryWorldServer(net.minecraft.server.MinecraftServer minecraftserver, net.minecraft.src.ISaveHandler
			 isavehandler, string s, int i, long l, net.minecraft.src.WorldServer worldserver
			)
			: base(minecraftserver, isavehandler, s, i, l)
		{
			// Referenced classes of package net.minecraft.src:
			//            WorldServer, ISaveHandler
			WorldMaps = worldserver.WorldMaps;
		}
	}
}
