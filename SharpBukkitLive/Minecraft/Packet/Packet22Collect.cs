// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class Packet22Collect : net.minecraft.src.Packet
    {
        public Packet22Collect()
        {
        }

        public Packet22Collect(int collectedEntityId, int collectorEntityId)
        {
            // Referenced classes of package net.minecraft.src:
            //            Packet, NetHandler
            this.collectedEntityId = collectedEntityId;
            this.collectorEntityId = collectorEntityId;
        }

        /// <exception cref="System.IO.IOException"/>
        public override void ReadPacketData(java.io.DataInputStream datainputstream)
        {
            collectedEntityId = datainputstream.ReadInt();
            collectorEntityId = datainputstream.ReadInt();
        }

        /// <exception cref="System.IO.IOException"/>
        public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
        {
            dataoutputstream.WriteInt(collectedEntityId);
            dataoutputstream.WriteInt(collectorEntityId);
        }

        public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
        {
            nethandler.HandleCollect(this);
        }

        public override int GetPacketSize()
        {
            return 8;
        }

        public int collectedEntityId;

        public int collectorEntityId;
    }
}
