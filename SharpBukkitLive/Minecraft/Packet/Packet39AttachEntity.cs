// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet39AttachEntity : net.minecraft.src.Packet
	{
		public Packet39AttachEntity()
		{
		}

		public Packet39AttachEntity(net.minecraft.src.Entity entity, net.minecraft.src.Entity
			 entity1)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, Entity, NetHandler
			entityId = entity.entityId;
			vehicleEntityId = entity1 == null ? -1 : entity1.entityId;
		}

		public override int GetPacketSize()
		{
			return 8;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			entityId = datainputstream.ReadInt();
			vehicleEntityId = datainputstream.ReadInt();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(entityId);
			dataoutputstream.WriteInt(vehicleEntityId);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.Func_6003_a(this);
		}

		public int entityId;

		public int vehicleEntityId;
	}
}
