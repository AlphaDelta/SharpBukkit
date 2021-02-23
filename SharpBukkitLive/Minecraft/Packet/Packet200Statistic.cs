// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class Packet200Statistic : net.minecraft.src.Packet
    {
        public Packet200Statistic()
        {
        }

        public Packet200Statistic(int statId, int statValue)
        {
            // Referenced classes of package net.minecraft.src:
            //            Packet, NetHandler
            this.statId = statId;
            this.statValue = statValue;
        }

        public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
        {
            nethandler.HandleStatistic(this);
        }

        /// <exception cref="System.IO.IOException"/>
        public override void ReadPacketData(java.io.DataInputStream datainputstream)
        {
            statId = datainputstream.ReadInt();
            statValue = datainputstream.ReadByte();
        }

        /// <exception cref="System.IO.IOException"/>
        public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
        {
            dataoutputstream.WriteInt(statId);
            dataoutputstream.WriteByte(statValue);
        }

        public override int GetPacketSize()
        {
            return 6;
        }

        public int statId;

        public int statValue;
    }
}
