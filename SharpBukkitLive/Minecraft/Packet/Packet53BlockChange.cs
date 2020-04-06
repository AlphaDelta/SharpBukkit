// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet53BlockChange : net.minecraft.src.Packet
	{
		public Packet53BlockChange()
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, World, NetHandler
			isChunkDataPacket = true;
		}

		public Packet53BlockChange(int i, int j, int k, net.minecraft.src.World world)
		{
			isChunkDataPacket = true;
			xPosition = i;
			yPosition = j;
			zPosition = k;
			type = world.GetBlockId(i, j, k);
			metadata = world.GetBlockMetadata(i, j, k);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			xPosition = datainputstream.ReadInt();
			yPosition = datainputstream.Read();
			zPosition = datainputstream.ReadInt();
			type = datainputstream.Read();
			metadata = datainputstream.Read();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(xPosition);
			dataoutputstream.Write(yPosition);
			dataoutputstream.WriteInt(zPosition);
			dataoutputstream.Write(type);
			dataoutputstream.Write(metadata);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleBlockChange(this);
		}

		public override int GetPacketSize()
		{
			return 11;
		}

		public int xPosition;

		public int yPosition;

		public int zPosition;

		public int type;

		public int metadata;
	}
}
