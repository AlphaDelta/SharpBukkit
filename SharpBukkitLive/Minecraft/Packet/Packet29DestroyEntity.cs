// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet29DestroyEntity : net.minecraft.src.Packet
	{
		public Packet29DestroyEntity()
		{
		}

		public Packet29DestroyEntity(int i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			entityId = i;
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
			nethandler.HandleDestroyEntity(this);
		}

		public override int GetPacketSize()
		{
			return 4;
		}

		public int entityId;
	}
}
