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
			field_27043_a = entity.entityId;
			field_27042_b = net.minecraft.src.MathHelper.Floor_double(entity.posX * 32D);
			field_27046_c = net.minecraft.src.MathHelper.Floor_double(entity.posY * 32D);
			field_27045_d = net.minecraft.src.MathHelper.Floor_double(entity.posZ * 32D);
			if (entity is net.minecraft.src.EntityLightningBolt)
			{
				field_27044_e = 1;
			}
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			field_27043_a = datainputstream.ReadInt();
			field_27044_e = datainputstream.ReadByte();
			field_27042_b = datainputstream.ReadInt();
			field_27046_c = datainputstream.ReadInt();
			field_27045_d = datainputstream.ReadInt();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(field_27043_a);
			dataoutputstream.WriteByte(field_27044_e);
			dataoutputstream.WriteInt(field_27042_b);
			dataoutputstream.WriteInt(field_27046_c);
			dataoutputstream.WriteInt(field_27045_d);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.Func_27002_a(this);
		}

		public override int GetPacketSize()
		{
			return 17;
		}

		public int field_27043_a;

		public int field_27042_b;

		public int field_27046_c;

		public int field_27045_d;

		public int field_27044_e;
	}
}
