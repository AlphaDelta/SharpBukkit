// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet70Bed : net.minecraft.src.Packet
	{
		public Packet70Bed()
		{
		}

		public Packet70Bed(int i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			field_25015_b = i;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			field_25015_b = datainputstream.ReadByte();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteByte(field_25015_b);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.Func_25001_a(this);
		}

		public override int GetPacketSize()
		{
			return 1;
		}

		public static readonly string[] field_25016_a = new string[] { "tile.bed.notValid"
			, null, null };

		public int field_25015_b;
	}
}
