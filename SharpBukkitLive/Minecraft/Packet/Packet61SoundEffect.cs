// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class Packet61SoundEffect : net.minecraft.src.Packet
    {
        public Packet61SoundEffect()
        {
        }

        public Packet61SoundEffect(int i, int blockX, int blockY, int blockZ, int blockShiftedIndex)
        {
            // Referenced classes of package net.minecraft.src:
            //            Packet, NetHandler
            field_28047_a = i;
            BlockX = blockX;
            BlockY = blockY;
            BlockZ = blockZ;
            BlockShiftedIndex = blockShiftedIndex;
        }

        /// <exception cref="System.IO.IOException"/>
        public override void ReadPacketData(java.io.DataInputStream datainputstream)
        {
            field_28047_a = datainputstream.ReadInt();
            BlockX = datainputstream.ReadInt();
            BlockY = datainputstream.ReadByte();
            BlockZ = datainputstream.ReadInt();
            BlockShiftedIndex = datainputstream.ReadInt();
        }

        /// <exception cref="System.IO.IOException"/>
        public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
        {
            dataoutputstream.WriteInt(field_28047_a);
            dataoutputstream.WriteInt(BlockX);
            dataoutputstream.WriteByte(BlockY);
            dataoutputstream.WriteInt(BlockZ);
            dataoutputstream.WriteInt(BlockShiftedIndex);
        }

        public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
        {
            nethandler.HandleDoorChange(this);
        }

        public override int GetPacketSize()
        {
            return 20;
        }

        public int field_28047_a;

        public int BlockShiftedIndex;

        public int BlockX;

        public int BlockY;

        public int BlockZ;
    }
}
