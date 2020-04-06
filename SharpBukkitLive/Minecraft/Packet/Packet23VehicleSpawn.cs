// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet23VehicleSpawn : net.minecraft.src.Packet
	{
		public Packet23VehicleSpawn()
		{
		}

		public Packet23VehicleSpawn(net.minecraft.src.Entity entity, int i)
			: this(entity, i, 0)
		{
		}

		public Packet23VehicleSpawn(net.minecraft.src.Entity entity, int i, int j)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, Entity, MathHelper, NetHandler
			entityId = entity.entityId;
			xPosition = net.minecraft.src.MathHelper.Floor_double(entity.posX * 32D);
			yPosition = net.minecraft.src.MathHelper.Floor_double(entity.posY * 32D);
			zPosition = net.minecraft.src.MathHelper.Floor_double(entity.posZ * 32D);
			type = i;
			field_28041_i = j;
			if (j > 0)
			{
				double d = entity.motionX;
				double d1 = entity.motionY;
				double d2 = entity.motionZ;
				double d3 = 3.8999999999999999D;
				if (d < -d3)
				{
					d = -d3;
				}
				if (d1 < -d3)
				{
					d1 = -d3;
				}
				if (d2 < -d3)
				{
					d2 = -d3;
				}
				if (d > d3)
				{
					d = d3;
				}
				if (d1 > d3)
				{
					d1 = d3;
				}
				if (d2 > d3)
				{
					d2 = d3;
				}
				field_28044_e = (int)(d * 8000D);
				field_28043_f = (int)(d1 * 8000D);
				field_28042_g = (int)(d2 * 8000D);
			}
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			entityId = datainputstream.ReadInt();
			type = datainputstream.ReadByte();
			xPosition = datainputstream.ReadInt();
			yPosition = datainputstream.ReadInt();
			zPosition = datainputstream.ReadInt();
			field_28041_i = datainputstream.ReadInt();
			if (field_28041_i > 0)
			{
				field_28044_e = datainputstream.ReadShort();
				field_28043_f = datainputstream.ReadShort();
				field_28042_g = datainputstream.ReadShort();
			}
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(entityId);
			dataoutputstream.WriteByte(type);
			dataoutputstream.WriteInt(xPosition);
			dataoutputstream.WriteInt(yPosition);
			dataoutputstream.WriteInt(zPosition);
			dataoutputstream.WriteInt(field_28041_i);
			if (field_28041_i > 0)
			{
				dataoutputstream.WriteShort(field_28044_e);
				dataoutputstream.WriteShort(field_28043_f);
				dataoutputstream.WriteShort(field_28042_g);
			}
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleVehicleSpawn(this);
		}

		public override int GetPacketSize()
		{
			return 21 + field_28041_i <= 0 ? 0 : 6;
		}

		public int entityId;

		public int xPosition;

		public int yPosition;

		public int zPosition;

		public int field_28044_e;

		public int field_28043_f;

		public int field_28042_g;

		public int type;

		public int field_28041_i;
	}
}
