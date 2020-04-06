// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet28EntityVelocity : net.minecraft.src.Packet
	{
		public Packet28EntityVelocity()
		{
		}

		public Packet28EntityVelocity(net.minecraft.src.Entity entity)
			: this(entity.entityId, entity.motionX, entity.motionY, entity.motionZ)
		{
		}

		public Packet28EntityVelocity(int i, double d, double d1, double d2)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, Entity, NetHandler
			entityId = i;
			double d3 = 3.8999999999999999D;
			if (d < -d3)
			{
				d = -d3;
			}
			if (d1 < -d3)
			{
				d1 = -d3;
			}
			if (d2 < -d3)
			{
				d2 = -d3;
			}
			if (d > d3)
			{
				d = d3;
			}
			if (d1 > d3)
			{
				d1 = d3;
			}
			if (d2 > d3)
			{
				d2 = d3;
			}
			motionX = (int)(d * 8000D);
			motionY = (int)(d1 * 8000D);
			motionZ = (int)(d2 * 8000D);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			entityId = datainputstream.ReadInt();
			motionX = datainputstream.ReadShort();
			motionY = datainputstream.ReadShort();
			motionZ = datainputstream.ReadShort();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(entityId);
			dataoutputstream.WriteShort(motionX);
			dataoutputstream.WriteShort(motionY);
			dataoutputstream.WriteShort(motionZ);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.Func_6002_a(this);
		}

		public override int GetPacketSize()
		{
			return 10;
		}

		public int entityId;

		public int motionX;

		public int motionY;

		public int motionZ;
	}
}
