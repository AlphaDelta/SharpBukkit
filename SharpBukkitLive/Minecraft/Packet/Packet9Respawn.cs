// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet9Respawn : net.minecraft.src.Packet
	{
		public Packet9Respawn()
		{
		}

		public Packet9Respawn(byte byte0)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			field_28045_a = byte0;
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleRespawnPacket(this);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			field_28045_a = datainputstream.ReadByte();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteByte(field_28045_a);
		}

		public override int GetPacketSize()
		{
			return 1;
		}

		public byte field_28045_a;
	}
}
