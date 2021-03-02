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

        public Packet61SoundEffect(int soundType, int blockX, int blockY, int blockZ, int ExtraInfo)
        {
            // Referenced classes of package net.minecraft.src:
            //            Packet, NetHandler
            SoundType = soundType;
            BlockX = blockX;
            BlockY = blockY;
            BlockZ = blockZ;
            this.ExtraInfo = ExtraInfo;
        }

        /// <exception cref="System.IO.IOException"/>
        public override void ReadPacketData(java.io.DataInputStream datainputstream)
        {
            SoundType = datainputstream.ReadInt();
            BlockX = datainputstream.ReadInt();
            BlockY = datainputstream.ReadByte();
            BlockZ = datainputstream.ReadInt();
            ExtraInfo = datainputstream.ReadInt();
        }

        /// <exception cref="System.IO.IOException"/>
        public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
        {
            dataoutputstream.WriteInt(SoundType);
            dataoutputstream.WriteInt(BlockX);
            dataoutputstream.WriteByte(BlockY);
            dataoutputstream.WriteInt(BlockZ);
            dataoutputstream.WriteInt(ExtraInfo);
        }

        public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
        {
            nethandler.HandleDoorChange(this);
        }

        public override int GetPacketSize()
        {
            return 20;
        }

        public int SoundType;

        public int ExtraInfo;

        public int BlockX;

        public int BlockY;

        public int BlockZ;
    }
}
