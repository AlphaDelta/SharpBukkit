// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet105UpdateProgressbar : net.minecraft.src.Packet
	{
		public Packet105UpdateProgressbar()
		{
		}

		public Packet105UpdateProgressbar(int i, int j, int k)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			windowId = i;
			progressBar = j;
			progressBarValue = k;
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleUpdateProgressBar(this);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			windowId = datainputstream.ReadByte();
			progressBar = datainputstream.ReadShort();
			progressBarValue = datainputstream.ReadShort();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteByte(windowId);
			dataoutputstream.WriteShort(progressBar);
			dataoutputstream.WriteShort(progressBarValue);
		}

		public override int GetPacketSize()
		{
			return 5;
		}

		public int windowId;

		public int progressBar;

		public int progressBarValue;
	}
}
