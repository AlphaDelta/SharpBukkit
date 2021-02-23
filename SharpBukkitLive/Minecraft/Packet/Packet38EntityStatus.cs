// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class Packet38EntityStatus : net.minecraft.src.Packet
    {
        public Packet38EntityStatus()
        {
        }

        public Packet38EntityStatus(int id, byte status)
        {
            // Referenced classes of package net.minecraft.src:
            //            Packet, NetHandler
            entityId = id;
            entityStatus = status;
        }

        /// <exception cref="System.IO.IOException"/>
        public override void ReadPacketData(java.io.DataInputStream datainputstream)
        {
            entityId = datainputstream.ReadInt();
            entityStatus = datainputstream.ReadByte();
        }

        /// <exception cref="System.IO.IOException"/>
        public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
        {
            dataoutputstream.WriteInt(entityId);
            dataoutputstream.WriteByte(entityStatus);
        }

        public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
        {
            nethandler.HandleEntityStatus(this);
        }

        public override int GetPacketSize()
        {
            return 5;
        }

        public int entityId;

        public byte entityStatus;
    }
}
