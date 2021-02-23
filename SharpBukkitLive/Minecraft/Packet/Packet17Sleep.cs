// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class Packet17Sleep : net.minecraft.src.Packet
    {
        public Packet17Sleep()
        {
        }

        public Packet17Sleep(net.minecraft.src.Entity entity, int i, int x, int y, int z)
        {
            // Referenced classes of package net.minecraft.src:
            //            Packet, Entity, NetHandler
            UnknownByte = i;
            EntityX = x;
            EntityY = y;
            EntityZ = z;
            EntityID = entity.entityId;
        }

        /// <exception cref="System.IO.IOException"/>
        public override void ReadPacketData(java.io.DataInputStream datainputstream)
        {
            EntityID = datainputstream.ReadInt();
            UnknownByte = datainputstream.ReadByte();
            EntityX = datainputstream.ReadInt();
            EntityY = datainputstream.ReadByte();
            EntityZ = datainputstream.ReadInt();
        }

        /// <exception cref="System.IO.IOException"/>
        public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
        {
            dataoutputstream.WriteInt(EntityID);
            dataoutputstream.WriteByte(UnknownByte);
            dataoutputstream.WriteInt(EntityX);
            dataoutputstream.WriteByte(EntityY);
            dataoutputstream.WriteInt(EntityZ);
        }

        public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
        {
            nethandler.HandleSleep(this);
        }

        public override int GetPacketSize()
        {
            return 14;
        }

        public int EntityID;

        public int EntityX;

        public int EntityY;

        public int EntityZ;

        public int UnknownByte;
    }
}
