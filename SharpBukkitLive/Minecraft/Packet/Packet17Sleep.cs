// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet17Sleep : net.minecraft.src.Packet
	{
		public Packet17Sleep()
		{
		}

		public Packet17Sleep(net.minecraft.src.Entity entity, int i, int j, int k, int l)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, Entity, NetHandler
			field_22042_e = i;
			field_22040_b = j;
			field_22044_c = k;
			field_22043_d = l;
			field_22041_a = entity.entityId;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			field_22041_a = datainputstream.ReadInt();
			field_22042_e = datainputstream.ReadByte();
			field_22040_b = datainputstream.ReadInt();
			field_22044_c = datainputstream.ReadByte();
			field_22043_d = datainputstream.ReadInt();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(field_22041_a);
			dataoutputstream.WriteByte(field_22042_e);
			dataoutputstream.WriteInt(field_22040_b);
			dataoutputstream.WriteByte(field_22044_c);
			dataoutputstream.WriteInt(field_22043_d);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.Func_22002_a(this);
		}

		public override int GetPacketSize()
		{
			return 14;
		}

		public int field_22041_a;

		public int field_22040_b;

		public int field_22044_c;

		public int field_22043_d;

		public int field_22042_e;
	}
}
