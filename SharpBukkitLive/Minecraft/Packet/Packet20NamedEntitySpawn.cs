// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet20NamedEntitySpawn : net.minecraft.src.Packet
	{
		public Packet20NamedEntitySpawn()
		{
		}

		public Packet20NamedEntitySpawn(net.minecraft.src.EntityPlayer entityplayer)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, EntityPlayer, MathHelper, InventoryPlayer, 
			//            ItemStack, NetHandler
			entityId = entityplayer.entityId;
			name = entityplayer.username;
			xPosition = net.minecraft.src.MathHelper.Floor_double(entityplayer.posX * 32D);
			yPosition = net.minecraft.src.MathHelper.Floor_double(entityplayer.posY * 32D);
			zPosition = net.minecraft.src.MathHelper.Floor_double(entityplayer.posZ * 32D);
			rotation = unchecked((byte)(int)((entityplayer.rotationYaw * 256F) / 360F));
			pitch = unchecked((byte)(int)((entityplayer.rotationPitch * 256F) / 360F));
			net.minecraft.src.ItemStack itemstack = entityplayer.inventory.GetCurrentItem();
			currentItem = itemstack != null ? itemstack.itemID : 0;
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			entityId = datainputstream.ReadInt();
			name = ReadString(datainputstream, 16);
			xPosition = datainputstream.ReadInt();
			yPosition = datainputstream.ReadInt();
			zPosition = datainputstream.ReadInt();
			rotation = datainputstream.ReadByte();
			pitch = datainputstream.ReadByte();
			currentItem = datainputstream.ReadShort();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(entityId);
			WriteString(name, dataoutputstream);
			dataoutputstream.WriteInt(xPosition);
			dataoutputstream.WriteInt(yPosition);
			dataoutputstream.WriteInt(zPosition);
			dataoutputstream.WriteByte(rotation);
			dataoutputstream.WriteByte(pitch);
			dataoutputstream.WriteShort(currentItem);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleNamedEntitySpawn(this);
		}

		public override int GetPacketSize()
		{
			return 28;
		}

		public int entityId;

		public string name;

		public int xPosition;

		public int yPosition;

		public int zPosition;

		public byte rotation;

		public byte pitch;

		public int currentItem;
	}
}
