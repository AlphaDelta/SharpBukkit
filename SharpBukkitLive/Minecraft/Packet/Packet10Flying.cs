// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet10Flying : net.minecraft.src.Packet
	{
		public Packet10Flying()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Packet, NetHandler
		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleFlying(this);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			onGround = datainputstream.Read() != 0;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.Write(onGround ? 1 : 0);
		}

		public override int GetPacketSize()
		{
			return 1;
		}

		public double xPosition;

		public double yPosition;

		public double zPosition;

		public double stance;

		public float yaw;

		public float pitch;

		public bool onGround;

		public bool moving;

		public bool rotating;
	}
}
