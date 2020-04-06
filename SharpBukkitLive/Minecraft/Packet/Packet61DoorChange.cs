// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet61DoorChange : net.minecraft.src.Packet
	{
		public Packet61DoorChange()
		{
		}

		public Packet61DoorChange(int i, int j, int k, int l, int i1)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			field_28047_a = i;
			field_28050_c = j;
			field_28049_d = k;
			field_28048_e = l;
			field_28046_b = i1;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			field_28047_a = datainputstream.ReadInt();
			field_28050_c = datainputstream.ReadInt();
			field_28049_d = datainputstream.ReadByte();
			field_28048_e = datainputstream.ReadInt();
			field_28046_b = datainputstream.ReadInt();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(field_28047_a);
			dataoutputstream.WriteInt(field_28050_c);
			dataoutputstream.WriteByte(field_28049_d);
			dataoutputstream.WriteInt(field_28048_e);
			dataoutputstream.WriteInt(field_28046_b);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.Func_28002_a(this);
		}

		public override int GetPacketSize()
		{
			return 20;
		}

		public int field_28047_a;

		public int field_28046_b;

		public int field_28050_c;

		public int field_28049_d;

		public int field_28048_e;
	}
}
