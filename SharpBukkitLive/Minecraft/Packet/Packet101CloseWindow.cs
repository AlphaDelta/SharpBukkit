// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet101CloseWindow : net.minecraft.src.Packet
	{
		public Packet101CloseWindow()
		{
		}

		public Packet101CloseWindow(int i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			windowId = i;
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleCraftingGuiClosedPacked(this);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			windowId = datainputstream.ReadByte();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteByte(windowId);
		}

		public override int GetPacketSize()
		{
			return 1;
		}

		public int windowId;
	}
}
