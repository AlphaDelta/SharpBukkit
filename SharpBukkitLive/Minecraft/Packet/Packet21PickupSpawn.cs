// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet21PickupSpawn : net.minecraft.src.Packet
	{
		public Packet21PickupSpawn()
		{
		}

		public Packet21PickupSpawn(net.minecraft.src.EntityItem entityitem)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, EntityItem, ItemStack, MathHelper, 
			//            NetHandler
			entityId = entityitem.entityId;
			itemID = entityitem.item.itemID;
			count = entityitem.item.stackSize;
			itemDamage = entityitem.item.GetItemDamage();
			xPosition = net.minecraft.src.MathHelper.Floor_double(entityitem.posX * 32D);
			yPosition = net.minecraft.src.MathHelper.Floor_double(entityitem.posY * 32D);
			zPosition = net.minecraft.src.MathHelper.Floor_double(entityitem.posZ * 32D);
			rotation = unchecked((byte)(int)(entityitem.motionX * 128D));
			pitch = unchecked((byte)(int)(entityitem.motionY * 128D));
			roll = unchecked((byte)(int)(entityitem.motionZ * 128D));
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			entityId = datainputstream.ReadInt();
			itemID = datainputstream.ReadShort();
			count = datainputstream.ReadByte();
			itemDamage = datainputstream.ReadShort();
			xPosition = datainputstream.ReadInt();
			yPosition = datainputstream.ReadInt();
			zPosition = datainputstream.ReadInt();
			rotation = datainputstream.ReadByte();
			pitch = datainputstream.ReadByte();
			roll = datainputstream.ReadByte();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(entityId);
			dataoutputstream.WriteShort(itemID);
			dataoutputstream.WriteByte(count);
			dataoutputstream.WriteShort(itemDamage);
			dataoutputstream.WriteInt(xPosition);
			dataoutputstream.WriteInt(yPosition);
			dataoutputstream.WriteInt(zPosition);
			dataoutputstream.WriteByte(rotation);
			dataoutputstream.WriteByte(pitch);
			dataoutputstream.WriteByte(roll);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandlePickupSpawn(this);
		}

		public override int GetPacketSize()
		{
			return 24;
		}

		public int entityId;

		public int xPosition;

		public int yPosition;

		public int zPosition;

		public byte rotation;

		public byte pitch;

		public byte roll;

		public int itemID;

		public int count;

		public int itemDamage;
	}
}
