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

		public Packet9Respawn(byte dimension)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			Dimension = dimension;
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleRespawnPacket(this);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			Dimension = datainputstream.ReadByte();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteByte(Dimension);
		}

		public override int GetPacketSize()
		{
			return 1;
		}

		public byte Dimension;
	}
}
