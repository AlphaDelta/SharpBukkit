// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class Packet255KickDisconnect : net.minecraft.src.Packet
    {
        public Packet255KickDisconnect()
        {
        }

        public Packet255KickDisconnect(string reason)
        {
            // Referenced classes of package net.minecraft.src:
            //            Packet, NetHandler
            this.reason = reason;
        }

        /// <exception cref="System.IO.IOException"/>
        public override void ReadPacketData(java.io.DataInputStream datainputstream)
        {
            reason = ReadString(datainputstream, 100);
        }

        /// <exception cref="System.IO.IOException"/>
        public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
        {
            WriteString(reason, dataoutputstream);
        }

        public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
        {
            nethandler.HandleKickDisconnect(this);
        }

        public override int GetPacketSize()
        {
            return reason.Length;
        }

        public string reason;
    }
}
