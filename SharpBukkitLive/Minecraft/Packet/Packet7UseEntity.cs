// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet7UseEntity : net.minecraft.src.Packet
	{
		public Packet7UseEntity()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Packet, NetHandler
		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			playerEntityId = datainputstream.ReadInt();
			targetEntity = datainputstream.ReadInt();
			isLeftClick = datainputstream.ReadByte();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(playerEntityId);
			dataoutputstream.WriteInt(targetEntity);
			dataoutputstream.WriteByte(isLeftClick);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.Func_6006_a(this);
		}

		public override int GetPacketSize()
		{
			return 9;
		}

		public int playerEntityId;

		public int targetEntity;

		public int isLeftClick;
	}
}
