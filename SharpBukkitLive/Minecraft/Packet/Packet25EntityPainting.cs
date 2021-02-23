// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class Packet25EntityPainting : net.minecraft.src.Packet
    {
        public Packet25EntityPainting()
        {
        }

        public Packet25EntityPainting(net.minecraft.src.EntityPainting entitypainting)
        {
            // Referenced classes of package net.minecraft.src:
            //            Packet, EntityPainting, EnumArt, NetHandler
            entityId = entitypainting.entityId;
            xPosition = entitypainting.xPosition;
            yPosition = entitypainting.yPosition;
            zPosition = entitypainting.zPosition;
            direction = entitypainting.direction;
            title = entitypainting.art.title;
        }

        /// <exception cref="System.IO.IOException"/>
        public override void ReadPacketData(java.io.DataInputStream datainputstream)
        {
            entityId = datainputstream.ReadInt();
            title = ReadString(datainputstream, net.minecraft.src.EnumArt.LongestNameLength);
            xPosition = datainputstream.ReadInt();
            yPosition = datainputstream.ReadInt();
            zPosition = datainputstream.ReadInt();
            direction = datainputstream.ReadInt();
        }

        /// <exception cref="System.IO.IOException"/>
        public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
        {
            dataoutputstream.WriteInt(entityId);
            WriteString(title, dataoutputstream);
            dataoutputstream.WriteInt(xPosition);
            dataoutputstream.WriteInt(yPosition);
            dataoutputstream.WriteInt(zPosition);
            dataoutputstream.WriteInt(direction);
        }

        public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
        {
            nethandler.HandleEntityPainting(this);
        }

        public override int GetPacketSize()
        {
            return 24;
        }

        public int entityId;

        public int xPosition;

        public int yPosition;

        public int zPosition;

        public int direction;

        public string title;
    }
}
