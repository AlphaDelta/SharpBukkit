// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet71Weather : net.minecraft.src.Packet
	{
		public Packet71Weather()
		{
		}

		public Packet71Weather(net.minecraft.src.Entity entity)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, Entity, MathHelper, EntityLightningBolt, 
			//            NetHandler
			EntityID = entity.entityId;
			EntityX = net.minecraft.src.MathHelper.Floor_double(entity.posX * 32D);
			EntityY = net.minecraft.src.MathHelper.Floor_double(entity.posY * 32D);
			EntityZ = net.minecraft.src.MathHelper.Floor_double(entity.posZ * 32D);
			if (entity is net.minecraft.src.EntityLightningBolt)
			{
				EntityType = 1;
			}
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			EntityID = datainputstream.ReadInt();
			EntityType = datainputstream.ReadByte();
			EntityX = datainputstream.ReadInt();
			EntityY = datainputstream.ReadInt();
			EntityZ = datainputstream.ReadInt();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(EntityID);
			dataoutputstream.WriteByte(EntityType);
			dataoutputstream.WriteInt(EntityX);
			dataoutputstream.WriteInt(EntityY);
			dataoutputstream.WriteInt(EntityZ);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleWeather(this);
		}

		public override int GetPacketSize()
		{
			return 17;
		}

		public int EntityID;

		public int EntityX;

		public int EntityY;

		public int EntityZ;

		public int EntityType;
	}
}
