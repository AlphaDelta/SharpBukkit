// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet30Entity : net.minecraft.src.Packet
	{
		public Packet30Entity()
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			rotating = false;
		}

		public Packet30Entity(int id)
		{
			rotating = false;
			entityId = id;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			entityId = datainputstream.ReadInt();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(entityId);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleEntity(this);
		}

		public override int GetPacketSize()
		{
			return 4;
		}

		public int entityId;

		public byte xPosition;

		public byte yPosition;

		public byte zPosition;

		public byte yaw;

		public byte pitch;

		public bool rotating;
	}
}
