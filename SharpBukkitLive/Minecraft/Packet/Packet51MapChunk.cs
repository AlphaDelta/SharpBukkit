// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
//using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using LibDeflate;
using Microsoft.Toolkit.HighPerformance.Buffers;
using Sharpen;
using System;
using System.IO;
using System.IO.Compression;

namespace net.minecraft.src
{

    public class Packet51MapChunk : net.minecraft.src.Packet, IDisposable
    {
        // CRAFTBUKKIT consts
        const int CHUNK_SIZE = 16 * 128 * 16 * 5 / 2;
        const int REDUCED_DEFLATE_THRESHOLD = CHUNK_SIZE / 4;
        const int DEFLATE_LEVEL_CHUNKS = 6;
        const int DEFLATE_LEVEL_PARTS = 1;

        public Packet51MapChunk()
        {
            // Referenced classes of package net.minecraft.src:
            //            Packet, World, NetHandler
            isChunkDataPacket = true;
        }

        public Packet51MapChunk(int x, int y, int z, int xSize, int ySize, int zSize, net.minecraft.src.World world)
        {
            isChunkDataPacket = true;
            xPosition = x;
            yPosition = y;
            zPosition = z;
            this.xSize = xSize;
            this.ySize = ySize;
            this.zSize = zSize;
            byte[] abyte0 = world.GetChunkData(x, y, z, xSize, ySize, zSize);
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

            using (Compressor compressor = new LibDeflate.ZlibCompressor(abyte0.Length < REDUCED_DEFLATE_THRESHOLD ? DEFLATE_LEVEL_PARTS : DEFLATE_LEVEL_CHUNKS))
            {

                chunk = compressor.Compress(abyte0, true);
                if (chunk == null) throw new System.Exception($"Chunk data was too small to effectively compress or some other error occurred??? (Size: {abyte0.Length})");

                chunkSize = chunk.Length;
                //ms.CopyTo(ds);
                //ds.Flush();
                //chunk = output.ToArray();
                //chunkSize = chunk.Length;
            }
        }

        /// <exception cref="System.IO.IOException"/>
        //Never used???
        public override void ReadPacketData(java.io.DataInputStream datainputstream) { }
        //public override void ReadPacketData(java.io.DataInputStream datainputstream)
        //{
        //    xPosition = datainputstream.ReadInt();
        //    yPosition = datainputstream.ReadShort();
        //    zPosition = datainputstream.ReadInt();
        //    xSize = datainputstream.Read() + 1;
        //    ySize = datainputstream.Read() + 1;
        //    zSize = datainputstream.Read() + 1;
        //    chunkSize = datainputstream.ReadInt();
        //    byte[] abyte0 = new byte[chunkSize];
        //    datainputstream.ReadFully(abyte0);

        //    using (MemoryStream ms = new MemoryStream(abyte0))
        //    using (MemoryStream output = new MemoryStream())
        //    using (InflaterInputStream ds = new InflaterInputStream(ms))
        //    {
        //        ds.CopyTo(output);
        //        ds.Flush();
        //        chunk = output.ToArray();
        //    }
        //    //chunk = new byte[(xSize * ySize * zSize * 5) / 2];
        //    //java.util.zip.Inflater inflater = new java.util.zip.Inflater();
        //    //inflater.SetInput(abyte0);
        //    //try
        //    //{
        //    //	inflater.Inflate(chunk);
        //    //}
        //    //catch (java.util.zip.DataFormatException)
        //    //{
        //    //	throw new System.IO.IOException("Bad compressed data format");
        //    //}
        //    //finally
        //    //{
        //    //	inflater.End();
        //    //}
        //}

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
            dataoutputstream.Write(chunk.Span);//, 0, chunkSize);
        }

        //Never used???
        public override void ProcessPacket(net.minecraft.src.NetHandler nethandler) { }
        //public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
        //{
        //    nethandler.HandleMapChunk(this);
        //}

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

        public MemoryOwner<byte> chunk;

        private int chunkSize;

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    chunk.Dispose();
                }

                chunk = null;
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
