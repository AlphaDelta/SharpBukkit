// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet8UpdateHealth : net.minecraft.src.Packet
	{
		public Packet8UpdateHealth()
		{
		}

		public Packet8UpdateHealth(int i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			healthMP = i;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			healthMP = datainputstream.ReadShort();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteShort(healthMP);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleHealth(this);
		}

		public override int GetPacketSize()
		{
			return 2;
		}

		public int healthMP;
	}
}
