// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet2Handshake : net.minecraft.src.Packet
	{
		public Packet2Handshake()
		{
		}

		public Packet2Handshake(string s)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			username = s;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			username = ReadString(datainputstream, 32);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			WriteString(username, dataoutputstream);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleHandshake(this);
		}

		public override int GetPacketSize()
		{
			return 4 + username.Length + 4;
		}

		public string username;
	}
}
