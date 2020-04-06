// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ServerCommand
	{
		public ServerCommand(string s, net.minecraft.src.ICommandListener icommandlistener
			)
		{
			// Referenced classes of package net.minecraft.src:
			//            ICommandListener
			command = s;
			commandListener = icommandlistener;
		}

		public readonly string command;

		public readonly net.minecraft.src.ICommandListener commandListener;
	}
}
