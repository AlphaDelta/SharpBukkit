// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet18Animation : net.minecraft.src.Packet
	{
		public Packet18Animation()
		{
		}

		public Packet18Animation(net.minecraft.src.Entity entity, int i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, Entity, NetHandler
			entityId = entity.entityId;
			animate = i;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			entityId = datainputstream.ReadInt();
			animate = datainputstream.ReadByte();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(entityId);
			dataoutputstream.WriteByte(animate);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleArmAnimation(this);
		}

		public override int GetPacketSize()
		{
			return 5;
		}

		public int entityId;

		public int animate;
	}
}
