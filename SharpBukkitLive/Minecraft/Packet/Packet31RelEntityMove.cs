// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet31RelEntityMove : net.minecraft.src.Packet30Entity
	{
		public Packet31RelEntityMove()
		{
		}

		public Packet31RelEntityMove(int i, byte byte0, byte byte1, byte byte2)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet30Entity
			xPosition = byte0;
			yPosition = byte1;
			zPosition = byte2;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			base.ReadPacketData(datainputstream);
			xPosition = datainputstream.ReadByte();
			yPosition = datainputstream.ReadByte();
			zPosition = datainputstream.ReadByte();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			base.WritePacketData(dataoutputstream);
			dataoutputstream.WriteByte(xPosition);
			dataoutputstream.WriteByte(yPosition);
			dataoutputstream.WriteByte(zPosition);
		}

		public override int GetPacketSize()
		{
			return 7;
		}
	}
}
