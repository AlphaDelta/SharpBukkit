// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class Packet27Position : net.minecraft.src.Packet
    {
        public Packet27Position()
        {
        }

        // Referenced classes of package net.minecraft.src:
        //            Packet, NetHandler
        /// <exception cref="System.IO.IOException"/>
        public override void ReadPacketData(java.io.DataInputStream datainputstream)
        {
            strafeMovement = datainputstream.ReadFloat();
            fowardMovement = datainputstream.ReadFloat();
            pitchRotation = datainputstream.ReadFloat();
            yawRotation = datainputstream.ReadFloat();
            isSneaking = datainputstream.ReadBoolean();
            isInJump = datainputstream.ReadBoolean();
        }

        /// <exception cref="System.IO.IOException"/>
        public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
        {
            dataoutputstream.WriteFloat(strafeMovement);
            dataoutputstream.WriteFloat(fowardMovement);
            dataoutputstream.WriteFloat(pitchRotation);
            dataoutputstream.WriteFloat(yawRotation);
            dataoutputstream.WriteBoolean(isSneaking);
            dataoutputstream.WriteBoolean(isInJump);
        }

        public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
        {
            nethandler.HandleMovementTypePacket(this);
        }

        public override int GetPacketSize()
        {
            return 18;
        }

        public virtual float GetStrafeMovement()
        {
            return strafeMovement;
        }

        public virtual float GetPitch()
        {
            return pitchRotation;
        }

        public virtual float GetForwardMovement()
        {
            return fowardMovement;
        }

        public virtual float GetYaw()
        {
            return yawRotation;
        }

        public virtual bool GetIsSneaking()
        {
            return isSneaking;
        }

        public virtual bool GetIsInJump()
        {
            return isInJump;
        }

        private float strafeMovement;

        private float fowardMovement;

        private bool isSneaking; //SHARP: Are these two variable names swapped?

        private bool isInJump; //SHARP: Are these two variable names swapped?

        private float pitchRotation;

        private float yawRotation;
    }
}
