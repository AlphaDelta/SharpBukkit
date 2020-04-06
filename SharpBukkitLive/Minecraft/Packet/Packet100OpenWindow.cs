// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet100OpenWindow : net.minecraft.src.Packet
	{
		public Packet100OpenWindow()
		{
		}

		public Packet100OpenWindow(int i, int j, string s, int k)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			windowId = i;
			inventoryType = j;
			windowTitle = s;
			slotsCount = k;
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.Func_20004_a(this);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			windowId = datainputstream.ReadByte();
			inventoryType = datainputstream.ReadByte();
			windowTitle = datainputstream.ReadUTF();
			slotsCount = datainputstream.ReadByte();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteByte(windowId);
			dataoutputstream.WriteByte(inventoryType);
			dataoutputstream.WriteUTF(windowTitle);
			dataoutputstream.WriteByte(slotsCount);
		}

		public override int GetPacketSize()
		{
			return 3 + windowTitle.Length;
		}

		public int windowId;

		public int inventoryType;

		public string windowTitle;

		public int slotsCount;
	}
}
