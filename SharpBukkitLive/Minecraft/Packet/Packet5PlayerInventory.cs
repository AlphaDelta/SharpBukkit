// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet5PlayerInventory : net.minecraft.src.Packet
	{
		public Packet5PlayerInventory()
		{
		}

		public Packet5PlayerInventory(int id, int slot, net.minecraft.src.ItemStack itemstack)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, ItemStack, NetHandler
			entityID = id;
			this.slot = slot;
			if (itemstack == null)
			{
				itemID = -1;
				itemDamage = 0;
			}
			else
			{
				itemID = itemstack.itemID;
				itemDamage = itemstack.GetItemDamage();
			}
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			entityID = datainputstream.ReadInt();
			slot = datainputstream.ReadShort();
			itemID = datainputstream.ReadShort();
			itemDamage = datainputstream.ReadShort();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(entityID);
			dataoutputstream.WriteShort(slot);
			dataoutputstream.WriteShort(itemID);
			dataoutputstream.WriteShort(itemDamage);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandlePlayerInventory(this);
		}

		public override int GetPacketSize()
		{
			return 8;
		}

		public int entityID;

		public int slot;

		public int itemID;

		public int itemDamage;
	}
}
