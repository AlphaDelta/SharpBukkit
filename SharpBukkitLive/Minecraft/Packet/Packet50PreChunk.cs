// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet50PreChunk : net.minecraft.src.Packet
	{
		public Packet50PreChunk()
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			isChunkDataPacket = false;
		}

		public Packet50PreChunk(int i, int j, bool flag)
		{
			isChunkDataPacket = false;
			xPosition = i;
			yPosition = j;
			mode = flag;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			xPosition = datainputstream.ReadInt();
			yPosition = datainputstream.ReadInt();
			mode = datainputstream.Read() != 0;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(xPosition);
			dataoutputstream.WriteInt(yPosition);
			dataoutputstream.Write(mode ? 1 : 0);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandlePreChunk(this);
		}

		public override int GetPacketSize()
		{
			return 9;
		}

		public int xPosition;

		public int yPosition;

		public bool mode;
	}
}
