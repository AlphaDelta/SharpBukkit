// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet130UpdateSign : net.minecraft.src.Packet
	{
		public Packet130UpdateSign()
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			isChunkDataPacket = true;
		}

		public Packet130UpdateSign(int i, int j, int k, string[] @as)
		{
			isChunkDataPacket = true;
			xPosition = i;
			yPosition = j;
			zPosition = k;
			signLines = @as;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			xPosition = datainputstream.ReadInt();
			yPosition = datainputstream.ReadShort();
			zPosition = datainputstream.ReadInt();
			signLines = new string[4];
			for (int i = 0; i < 4; i++)
			{
				signLines[i] = ReadString(datainputstream, 15);
			}
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(xPosition);
			dataoutputstream.WriteShort(yPosition);
			dataoutputstream.WriteInt(zPosition);
			for (int i = 0; i < 4; i++)
			{
				WriteString(signLines[i], dataoutputstream);
			}
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleUpdateSign(this);
		}

		public override int GetPacketSize()
		{
			int i = 0;
			for (int j = 0; j < 4; j++)
			{
				i += signLines[j].Length;
			}
			return i;
		}

		public int xPosition;

		public int yPosition;

		public int zPosition;

		public string[] signLines;
	}
}
