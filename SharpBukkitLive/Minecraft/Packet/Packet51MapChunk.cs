// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using Sharpen;
using System.IO;
using System.IO.Compression;

namespace net.minecraft.src
{
	public class Packet51MapChunk : net.minecraft.src.Packet
	{
		public Packet51MapChunk()
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, World, NetHandler
			isChunkDataPacket = true;
		}

		public Packet51MapChunk(int i, int j, int k, int l, int i1, int j1, net.minecraft.src.World
			 world)
		{
			isChunkDataPacket = true;
			xPosition = i;
			yPosition = j;
			zPosition = k;
			xSize = l;
			ySize = i1;
			zSize = j1;
			byte[] abyte0 = world.GetChunkData(i, j, k, l, i1, j1);
			//java.util.zip.Deflater deflater = new java.util.zip.Deflater(-1);
			//try
			//{
			//	deflater.SetInput(abyte0);
			//	deflater.Finish();
			//	chunk = new byte[(l * i1 * j1 * 5) / 2];
			//	chunkSize = deflater.Deflate(chunk);
			//}
			//finally
			//{
			//	deflater.End();
			//}
			using (MemoryStream ms = new MemoryStream(abyte0))
			using (MemoryStream output = new MemoryStream())
			using (DeflaterOutputStream ds = new DeflaterOutputStream(output))
			{
				ms.CopyTo(ds);
				ds.Flush();
				chunk = output.ToArray();
				chunkSize = chunk.Length;
			}
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			xPosition = datainputstream.ReadInt();
			yPosition = datainputstream.ReadShort();
			zPosition = datainputstream.ReadInt();
			xSize = datainputstream.Read() + 1;
			ySize = datainputstream.Read() + 1;
			zSize = datainputstream.Read() + 1;
			chunkSize = datainputstream.ReadInt();
			byte[] abyte0 = new byte[chunkSize];
			datainputstream.ReadFully(abyte0);

			using (MemoryStream ms = new MemoryStream(abyte0))
			using (MemoryStream output = new MemoryStream())
			using (InflaterInputStream ds = new InflaterInputStream(ms))
			{
				ds.CopyTo(output);
				ds.Flush();
				chunk = output.ToArray();
			}
			//chunk = new byte[(xSize * ySize * zSize * 5) / 2];
			//java.util.zip.Inflater inflater = new java.util.zip.Inflater();
			//inflater.SetInput(abyte0);
			//try
			//{
			//	inflater.Inflate(chunk);
			//}
			//catch (java.util.zip.DataFormatException)
			//{
			//	throw new System.IO.IOException("Bad compressed data format");
			//}
			//finally
			//{
			//	inflater.End();
			//}
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(xPosition);
			dataoutputstream.WriteShort(yPosition);
			dataoutputstream.WriteInt(zPosition);
			dataoutputstream.Write(xSize - 1);
			dataoutputstream.Write(ySize - 1);
			dataoutputstream.Write(zSize - 1);
			dataoutputstream.WriteInt(chunkSize);
			dataoutputstream.Write(chunk, 0, chunkSize);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleMapChunk(this);
		}

		public override int GetPacketSize()
		{
			return 17 + chunkSize;
		}

		public int xPosition;

		public int yPosition;

		public int zPosition;

		public int xSize;

		public int ySize;

		public int zSize;

		public byte[] chunk;

		private int chunkSize;
	}
}
