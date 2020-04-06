// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet200Statistic : net.minecraft.src.Packet
	{
		public Packet200Statistic()
		{
		}

		public Packet200Statistic(int i, int j)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			field_27041_a = i;
			field_27040_b = j;
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.Func_27001_a(this);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			field_27041_a = datainputstream.ReadInt();
			field_27040_b = datainputstream.ReadByte();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(field_27041_a);
			dataoutputstream.WriteByte(field_27040_b);
		}

		public override int GetPacketSize()
		{
			return 6;
		}

		public int field_27041_a;

		public int field_27040_b;
	}
}
