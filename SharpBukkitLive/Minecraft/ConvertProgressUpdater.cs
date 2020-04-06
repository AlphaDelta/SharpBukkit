// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ConvertProgressUpdater : net.minecraft.src.IProgressUpdate
	{
		public ConvertProgressUpdater(net.minecraft.server.MinecraftServer minecraftserver
			)
		{
			// Referenced classes of package net.minecraft.src:
			//            IProgressUpdate
			//        super();
			mcServer = minecraftserver;
			lastTimeMillis = Sharpen.Runtime.CurrentTimeMillis();
		}

		public virtual void Func_438_a(string s)
		{
		}

		public virtual void SetLoadingProgress(int i)
		{
			if (Sharpen.Runtime.CurrentTimeMillis() - lastTimeMillis >= 1000L)
			{
				lastTimeMillis = Sharpen.Runtime.CurrentTimeMillis();
				net.minecraft.server.MinecraftServer.logger.Info((new java.lang.StringBuilder()).
					Append("Converting... ").Append(i).Append("%").ToString());
			}
		}

		public virtual void DisplayLoadingString(string s)
		{
		}

		private long lastTimeMillis;

		internal readonly net.minecraft.server.MinecraftServer mcServer;
 /* synthetic field */
	}
}
