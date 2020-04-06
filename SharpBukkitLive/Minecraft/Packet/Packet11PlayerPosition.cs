// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet11PlayerPosition : net.minecraft.src.Packet10Flying
	{
		public Packet11PlayerPosition()
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet10Flying
			moving = true;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			xPosition = datainputstream.ReadDouble();
			yPosition = datainputstream.ReadDouble();
			stance = datainputstream.ReadDouble();
			zPosition = datainputstream.ReadDouble();
			base.ReadPacketData(datainputstream);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteDouble(xPosition);
			dataoutputstream.WriteDouble(yPosition);
			dataoutputstream.WriteDouble(stance);
			dataoutputstream.WriteDouble(zPosition);
			base.WritePacketData(dataoutputstream);
		}

		public override int GetPacketSize()
		{
			return 33;
		}
	}
}
