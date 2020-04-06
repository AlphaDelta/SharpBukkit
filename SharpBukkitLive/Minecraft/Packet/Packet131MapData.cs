// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet131MapData : net.minecraft.src.Packet
	{
		public Packet131MapData()
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			isChunkDataPacket = true;
		}

		public Packet131MapData(short word0, short word1, byte[] abyte0)
		{
			isChunkDataPacket = true;
			field_28052_a = word0;
			field_28051_b = word1;
			field_28053_c = abyte0;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			field_28052_a = datainputstream.ReadShort();
			field_28051_b = datainputstream.ReadShort();
			field_28053_c = new byte[datainputstream.ReadByte() & unchecked((int)(0xff))];
			datainputstream.ReadFully(field_28053_c);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteShort(field_28052_a);
			dataoutputstream.WriteShort(field_28051_b);
			dataoutputstream.WriteByte(field_28053_c.Length);
			dataoutputstream.Write(field_28053_c);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.Func_28001_a(this);
		}

		public override int GetPacketSize()
		{
			return 4 + field_28053_c.Length;
		}

		public short field_28052_a;

		public short field_28051_b;

		public byte[] field_28053_c;
	}
}
