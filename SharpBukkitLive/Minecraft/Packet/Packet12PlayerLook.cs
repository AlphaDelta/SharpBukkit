// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet12PlayerLook : net.minecraft.src.Packet10Flying
	{
		public Packet12PlayerLook()
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet10Flying
			rotating = true;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			yaw = datainputstream.ReadFloat();
			pitch = datainputstream.ReadFloat();
			base.ReadPacketData(datainputstream);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteFloat(yaw);
			dataoutputstream.WriteFloat(pitch);
			base.WritePacketData(dataoutputstream);
		}

		public override int GetPacketSize()
		{
			return 9;
		}
	}
}
