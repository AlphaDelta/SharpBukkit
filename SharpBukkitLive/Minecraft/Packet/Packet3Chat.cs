// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class Packet3Chat : net.minecraft.src.Packet
    {
        public Packet3Chat()
        {
        }

        public Packet3Chat(string message)
        {
            // Referenced classes of package net.minecraft.src:
            //            Packet, NetHandler
            if (message.Length > 119)
            {
                message = message.Substring(0, 119);
            }
            this.message = message;
        }

        /// <exception cref="System.IO.IOException"/>
        public override void ReadPacketData(java.io.DataInputStream datainputstream)
        {
            message = ReadString(datainputstream, 119);
        }

        /// <exception cref="System.IO.IOException"/>
        public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
        {
            WriteString(message, dataoutputstream);
        }

        public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
        {
            nethandler.HandleChat(this);
        }

        public override int GetPacketSize()
        {
            return message.Length;
        }

        public string message;
    }
}
