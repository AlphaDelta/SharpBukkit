// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet6SpawnPosition : net.minecraft.src.Packet
	{
		public Packet6SpawnPosition()
		{
		}

		public Packet6SpawnPosition(int i, int j, int k)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			xPosition = i;
			yPosition = j;
			zPosition = k;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			xPosition = datainputstream.ReadInt();
			yPosition = datainputstream.ReadInt();
			zPosition = datainputstream.ReadInt();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(xPosition);
			dataoutputstream.WriteInt(yPosition);
			dataoutputstream.WriteInt(zPosition);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleSpawnPosition(this);
		}

		public override int GetPacketSize()
		{
			return 12;
		}

		public int xPosition;

		public int yPosition;

		public int zPosition;
	}
}
