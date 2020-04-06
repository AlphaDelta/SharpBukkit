// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet14BlockDig : net.minecraft.src.Packet
	{
		public Packet14BlockDig()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Packet, NetHandler
		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			status = datainputstream.Read();
			xPosition = datainputstream.ReadInt();
			yPosition = datainputstream.Read();
			zPosition = datainputstream.ReadInt();
			face = datainputstream.Read();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.Write(status);
			dataoutputstream.WriteInt(xPosition);
			dataoutputstream.Write(yPosition);
			dataoutputstream.WriteInt(zPosition);
			dataoutputstream.Write(face);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleBlockDig(this);
		}

		public override int GetPacketSize()
		{
			return 11;
		}

		public int xPosition;

		public int yPosition;

		public int zPosition;

		public int face;

		public int status;
	}
}
