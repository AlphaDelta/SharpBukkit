// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet16BlockItemSwitch : net.minecraft.src.Packet
	{
		public Packet16BlockItemSwitch()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Packet, NetHandler
		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			id = datainputstream.ReadShort();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteShort(id);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleBlockItemSwitch(this);
		}

		public override int GetPacketSize()
		{
			return 2;
		}

		public int id;
	}
}
