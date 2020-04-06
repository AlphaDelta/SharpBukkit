// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	internal class PacketCounter
	{
		private PacketCounter()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Empty1
		public virtual void AddPacket(int i)
		{
			totalPackets++;
			totalBytes += i;
		}

		internal PacketCounter(net.minecraft.src.Empty1 empty1)
			: this()
		{
		}

		private int totalPackets;

		private long totalBytes;
	}
}
