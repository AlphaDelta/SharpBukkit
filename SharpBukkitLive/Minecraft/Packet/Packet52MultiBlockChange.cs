// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class Packet52MultiBlockChange : net.minecraft.src.Packet
    {
        public Packet52MultiBlockChange()
        {
            // Referenced classes of package net.minecraft.src:
            //            Packet, World, Chunk, NetHandler
            isChunkDataPacket = true;
        }

        public Packet52MultiBlockChange(int x, int z, short[] aword0, int arraySize, net.minecraft.src.World world)
        {
            isChunkDataPacket = true;
            xPosition = x;
            zPosition = z;
            size = arraySize;
            coordinateArray = new short[arraySize];
            typeArray = new byte[arraySize];
            metadataArray = new byte[arraySize];
            net.minecraft.src.Chunk chunk = world.GetChunkFromChunkCoords(x, z);
            for (int l = 0; l < arraySize; l++)
            {
                int i1 = aword0[l] >> 12 & 0xf;
                int j1 = aword0[l] >> 8 & 0xf;
                int k1 = aword0[l] & 0xff;
                coordinateArray[l] = aword0[l];
                typeArray[l] = unchecked((byte)chunk.GetBlockID(i1, k1, j1));
                metadataArray[l] = unchecked((byte)chunk.GetBlockMetadata(i1, k1, j1));
            }
        }

        /// <exception cref="System.IO.IOException"/>
        public override void ReadPacketData(java.io.DataInputStream datainputstream)
        {
            xPosition = datainputstream.ReadInt();
            zPosition = datainputstream.ReadInt();
            size = datainputstream.ReadShort();
            coordinateArray = new short[size];
            typeArray = new byte[size];
            metadataArray = new byte[size];
            for (int i = 0; i < size; i++)
            {
                coordinateArray[i] = datainputstream.ReadShort();
            }
            datainputstream.ReadFully(typeArray);
            datainputstream.ReadFully(metadataArray);
        }

        /// <exception cref="System.IO.IOException"/>
        public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
        {
            dataoutputstream.WriteInt(xPosition);
            dataoutputstream.WriteInt(zPosition);
            dataoutputstream.WriteShort((short)size);
            for (int i = 0; i < size; i++)
            {
                dataoutputstream.WriteShort(coordinateArray[i]);
            }
            dataoutputstream.Write(typeArray);
            dataoutputstream.Write(metadataArray);
        }

        public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
        {
            nethandler.HandleMultiBlockChange(this);
        }

        public override int GetPacketSize()
        {
            return 10 + size * 4;
        }

        public int xPosition;

        public int zPosition;

        public short[] coordinateArray;

        public byte[] typeArray;

        public byte[] metadataArray;

        public int size;
    }
}
