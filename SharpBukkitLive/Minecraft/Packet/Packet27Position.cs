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
			field_22039_c = datainputstream.ReadBoolean();
			isInJump = datainputstream.ReadBoolean();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteFloat(strafeMovement);
			dataoutputstream.WriteFloat(fowardMovement);
			dataoutputstream.WriteFloat(pitchRotation);
			dataoutputstream.WriteFloat(yawRotation);
			dataoutputstream.WriteBoolean(field_22039_c);
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

		public virtual float Func_22031_c()
		{
			return strafeMovement;
		}

		public virtual float Func_22029_d()
		{
			return pitchRotation;
		}

		public virtual float Func_22028_e()
		{
			return fowardMovement;
		}

		public virtual float Func_22033_f()
		{
			return yawRotation;
		}

		public virtual bool Func_22032_g()
		{
			return field_22039_c;
		}

		public virtual bool Func_22030_h()
		{
			return isInJump;
		}

		private float strafeMovement;

		private float fowardMovement;

		private bool field_22039_c;

		private bool isInJump;

		private float pitchRotation;

		private float yawRotation;
	}
}
