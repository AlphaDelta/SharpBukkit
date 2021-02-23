// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class Packet54PlayNoteBlock : net.minecraft.src.Packet
    {
        public Packet54PlayNoteBlock()
        {
        }

        public Packet54PlayNoteBlock(int x, int y, int z, int instrument, int pitch)
        {
            // Referenced classes of package net.minecraft.src:
            //            Packet, NetHandler
            xLocation = x;
            yLocation = y;
            zLocation = z;
            instrumentType = instrument;
            this.pitch = pitch;
        }

        /// <exception cref="System.IO.IOException"/>
        public override void ReadPacketData(java.io.DataInputStream datainputstream)
        {
            xLocation = datainputstream.ReadInt();
            yLocation = datainputstream.ReadShort();
            zLocation = datainputstream.ReadInt();
            instrumentType = datainputstream.Read();
            pitch = datainputstream.Read();
        }

        /// <exception cref="System.IO.IOException"/>
        public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
        {
            dataoutputstream.WriteInt(xLocation);
            dataoutputstream.WriteShort(yLocation);
            dataoutputstream.WriteInt(zLocation);
            dataoutputstream.Write(instrumentType);
            dataoutputstream.Write(pitch);
        }

        public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
        {
            nethandler.HandlePlayNoteBlock(this);
        }

        public override int GetPacketSize()
        {
            return 12;
        }

        public int xLocation;

        public int yLocation;

        public int zLocation;

        public int instrumentType;

        public int pitch;
    }
}
