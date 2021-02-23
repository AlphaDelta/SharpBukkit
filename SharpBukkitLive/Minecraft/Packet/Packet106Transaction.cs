// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet106Transaction : net.minecraft.src.Packet
	{
		public Packet106Transaction()
		{
		}

		public Packet106Transaction(int i, short word0, bool flag)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			windowId = i;
			shortWindowId = word0;
			field_20035_c = flag;
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleTransaction(this);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			windowId = datainputstream.ReadByte();
			shortWindowId = datainputstream.ReadShort();
			field_20035_c = datainputstream.ReadByte() != 0;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteByte(windowId);
			dataoutputstream.WriteShort(shortWindowId);
			dataoutputstream.WriteByte(field_20035_c ? 1 : 0);
		}

		public override int GetPacketSize()
		{
			return 4;
		}

		public int windowId;

		public short shortWindowId;

		public bool field_20035_c;
	}
}
