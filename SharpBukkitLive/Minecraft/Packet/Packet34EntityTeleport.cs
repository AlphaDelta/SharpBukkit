// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet34EntityTeleport : net.minecraft.src.Packet
	{
		public Packet34EntityTeleport()
		{
		}

		public Packet34EntityTeleport(net.minecraft.src.Entity entity)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, Entity, MathHelper, NetHandler
			entityId = entity.entityId;
			xPosition = net.minecraft.src.MathHelper.Floor_double(entity.posX * 32D);
			yPosition = net.minecraft.src.MathHelper.Floor_double(entity.posY * 32D);
			zPosition = net.minecraft.src.MathHelper.Floor_double(entity.posZ * 32D);
			yaw = unchecked((byte)(int)((entity.rotationYaw * 256F) / 360F));
			pitch = unchecked((byte)(int)((entity.rotationPitch * 256F) / 360F));
		}

		public Packet34EntityTeleport(int i, int j, int k, int l, byte byte0, byte byte1)
		{
			entityId = i;
			xPosition = j;
			yPosition = k;
			zPosition = l;
			yaw = byte0;
			pitch = byte1;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			entityId = datainputstream.ReadInt();
			xPosition = datainputstream.ReadInt();
			yPosition = datainputstream.ReadInt();
			zPosition = datainputstream.ReadInt();
			yaw = unchecked((byte)datainputstream.Read());
			pitch = unchecked((byte)datainputstream.Read());
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(entityId);
			dataoutputstream.WriteInt(xPosition);
			dataoutputstream.WriteInt(yPosition);
			dataoutputstream.WriteInt(zPosition);
			dataoutputstream.Write(yaw);
			dataoutputstream.Write(pitch);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleEntityTeleport(this);
		}

		public override int GetPacketSize()
		{
			return 34;
		}

		public int entityId;

		public int xPosition;

		public int yPosition;

		public int zPosition;

		public byte yaw;

		public byte pitch;
	}
}
