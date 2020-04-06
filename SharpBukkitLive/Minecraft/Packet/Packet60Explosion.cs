// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class Packet60Explosion : net.minecraft.src.Packet
	{
		public Packet60Explosion()
		{
		}

		public Packet60Explosion(double d, double d1, double d2, float f, HashSet<ChunkPosition> set)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, ChunkPosition, NetHandler
			explosionX = d;
			explosionY = d1;
			explosionZ = d2;
			explosionSize = f;
			destroyedBlockPositions = new HashSet<ChunkPosition>(set);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			explosionX = datainputstream.ReadDouble();
			explosionY = datainputstream.ReadDouble();
			explosionZ = datainputstream.ReadDouble();
			explosionSize = datainputstream.ReadFloat();
			int i = datainputstream.ReadInt();
			destroyedBlockPositions = new HashSet<ChunkPosition>();
			int j = (int)explosionX;
			int k = (int)explosionY;
			int l = (int)explosionZ;
			for (int i1 = 0; i1 < i; i1++)
			{
				int j1 = datainputstream.ReadByte() + j;
				int k1 = datainputstream.ReadByte() + k;
				int l1 = datainputstream.ReadByte() + l;
				destroyedBlockPositions.Add(new net.minecraft.src.ChunkPosition(j1, k1, l1));
			}
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteDouble(explosionX);
			dataoutputstream.WriteDouble(explosionY);
			dataoutputstream.WriteDouble(explosionZ);
			dataoutputstream.WriteFloat(explosionSize);
			dataoutputstream.WriteInt(destroyedBlockPositions.Count);
			int i = (int)explosionX;
			int j = (int)explosionY;
			int k = (int)explosionZ;
			int j1;
			for (System.Collections.IEnumerator iterator = destroyedBlockPositions.GetEnumerator
				(); iterator.MoveNext(); dataoutputstream.WriteByte(j1))
			{
				net.minecraft.src.ChunkPosition chunkposition = (net.minecraft.src.ChunkPosition)
					iterator.Current;
				int l = chunkposition.x - i;
				int i1 = chunkposition.y - j;
				j1 = chunkposition.z - k;
				dataoutputstream.WriteByte(l);
				dataoutputstream.WriteByte(i1);
			}
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.Func_12001_a(this);
		}

		public override int GetPacketSize()
		{
			return 32 + destroyedBlockPositions.Count * 3;
		}

		public double explosionX;

		public double explosionY;

		public double explosionZ;

		public float explosionSize;

		public HashSet<ChunkPosition> destroyedBlockPositions;
	}
}
