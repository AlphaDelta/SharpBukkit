// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet33RelEntityMoveLook : net.minecraft.src.Packet30Entity
	{
		public Packet33RelEntityMoveLook()
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet30Entity
			rotating = true;
		}

		public Packet33RelEntityMoveLook(int i, byte byte0, byte byte1, byte byte2, byte 
			byte3, byte byte4)
			: base(i)
		{
			xPosition = byte0;
			yPosition = byte1;
			zPosition = byte2;
			yaw = byte3;
			pitch = byte4;
			rotating = true;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			base.ReadPacketData(datainputstream);
			xPosition = datainputstream.ReadByte();
			yPosition = datainputstream.ReadByte();
			zPosition = datainputstream.ReadByte();
			yaw = datainputstream.ReadByte();
			pitch = datainputstream.ReadByte();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			base.WritePacketData(dataoutputstream);
			dataoutputstream.WriteByte(xPosition);
			dataoutputstream.WriteByte(yPosition);
			dataoutputstream.WriteByte(zPosition);
			dataoutputstream.WriteByte(yaw);
			dataoutputstream.WriteByte(pitch);
		}

		public override int GetPacketSize()
		{
			return 9;
		}
	}
}
