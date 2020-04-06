// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet1Login : net.minecraft.src.Packet
	{
		public Packet1Login()
		{
		}

		public Packet1Login(string s, int i, long l, byte byte0)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, NetHandler
			username = s;
			protocolVersion = i;
			mapSeed = l;
			dimension = byte0;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			protocolVersion = datainputstream.ReadInt();
			username = ReadString(datainputstream, 16);
			mapSeed = datainputstream.ReadLong();
			dimension = datainputstream.ReadByte();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(protocolVersion);
			WriteString(username, dataoutputstream);
			dataoutputstream.WriteLong(mapSeed);
			dataoutputstream.WriteByte(dimension);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleLogin(this);
		}

		public override int GetPacketSize()
		{
			return 4 + username.Length + 4 + 5;
		}

		public int protocolVersion;

		public string username;

		public long mapSeed;

		public byte dimension;
	}
}
