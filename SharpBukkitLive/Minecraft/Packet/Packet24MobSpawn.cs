// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet24MobSpawn : net.minecraft.src.Packet
	{
		public Packet24MobSpawn()
		{
		}

		public Packet24MobSpawn(net.minecraft.src.EntityLiving entityliving)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, EntityLiving, EntityList, MathHelper, 
			//            DataWatcher, NetHandler
			entityId = entityliving.entityId;
			type = unchecked((byte)net.minecraft.src.EntityList.GetEntityID(entityliving));
			xPosition = net.minecraft.src.MathHelper.Floor_double(entityliving.posX * 32D);
			yPosition = net.minecraft.src.MathHelper.Floor_double(entityliving.posY * 32D);
			zPosition = net.minecraft.src.MathHelper.Floor_double(entityliving.posZ * 32D);
			yaw = unchecked((byte)(int)((entityliving.rotationYaw * 256F) / 360F));
			pitch = unchecked((byte)(int)((entityliving.rotationPitch * 256F) / 360F));
			metaData = entityliving.GetDataWatcher();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			entityId = datainputstream.ReadInt();
			type = datainputstream.ReadByte();
			xPosition = datainputstream.ReadInt();
			yPosition = datainputstream.ReadInt();
			zPosition = datainputstream.ReadInt();
			yaw = datainputstream.ReadByte();
			pitch = datainputstream.ReadByte();
			receivedMetadata = net.minecraft.src.DataWatcher.ReadWatchableObjects(datainputstream
				);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(entityId);
			dataoutputstream.WriteByte(type);
			dataoutputstream.WriteInt(xPosition);
			dataoutputstream.WriteInt(yPosition);
			dataoutputstream.WriteInt(zPosition);
			dataoutputstream.WriteByte(yaw);
			dataoutputstream.WriteByte(pitch);
			metaData.WriteWatchableObjects(dataoutputstream);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleMobSpawn(this);
		}

		public override int GetPacketSize()
		{
			return 20;
		}

		public int entityId;

		public byte type;

		public int xPosition;

		public int yPosition;

		public int zPosition;

		public byte yaw;

		public byte pitch;

		private net.minecraft.src.DataWatcher metaData;

		private System.Collections.IList receivedMetadata;
	}
}
