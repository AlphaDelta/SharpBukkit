// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet13PlayerLookMove : net.minecraft.src.Packet10Flying
	{
		public Packet13PlayerLookMove()
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet10Flying
			rotating = true;
			moving = true;
		}

		public Packet13PlayerLookMove(double d, double d1, double d2, double d3, float f, 
			float f1, bool flag)
		{
			xPosition = d;
			yPosition = d1;
			stance = d2;
			zPosition = d3;
			yaw = f;
			pitch = f1;
			onGround = flag;
			rotating = true;
			moving = true;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			xPosition = datainputstream.ReadDouble();
			yPosition = datainputstream.ReadDouble();
			stance = datainputstream.ReadDouble();
			zPosition = datainputstream.ReadDouble();
			yaw = datainputstream.ReadFloat();
			pitch = datainputstream.ReadFloat();
			base.ReadPacketData(datainputstream);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteDouble(xPosition);
			dataoutputstream.WriteDouble(yPosition);
			dataoutputstream.WriteDouble(stance);
			dataoutputstream.WriteDouble(zPosition);
			dataoutputstream.WriteFloat(yaw);
			dataoutputstream.WriteFloat(pitch);
			base.WritePacketData(dataoutputstream);
		}

		public override int GetPacketSize()
		{
			return 41;
		}
	}
}
