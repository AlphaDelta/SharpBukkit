// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet4UpdateTime : net.minecraft.src.Packet
	{
		public Packet4UpdateTime()
		{
		}

		public Packet4UpdateTime(long l)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			time = l;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			time = datainputstream.ReadLong();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteLong(time);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleUpdateTime(this);
		}

		public override int GetPacketSize()
		{
			return 8;
		}

		public long time;
	}
}
