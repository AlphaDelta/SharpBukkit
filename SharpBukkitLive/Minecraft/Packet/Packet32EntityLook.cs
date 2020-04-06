// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet32EntityLook : net.minecraft.src.Packet30Entity
	{
		public Packet32EntityLook()
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet30Entity
			rotating = true;
		}

		public Packet32EntityLook(int i, byte byte0, byte byte1)
			: base(i)
		{
			yaw = byte0;
			pitch = byte1;
			rotating = true;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			base.ReadPacketData(datainputstream);
			yaw = datainputstream.ReadByte();
			pitch = datainputstream.ReadByte();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			base.WritePacketData(dataoutputstream);
			dataoutputstream.WriteByte(yaw);
			dataoutputstream.WriteByte(pitch);
		}

		public override int GetPacketSize()
		{
			return 6;
		}
	}
}
