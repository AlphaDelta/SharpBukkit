// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet103SetSlot : net.minecraft.src.Packet
	{
		public Packet103SetSlot()
		{
		}

		public Packet103SetSlot(int i, int j, net.minecraft.src.ItemStack itemstack)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, ItemStack, NetHandler
			windowId = i;
			itemSlot = j;
			myItemStack = itemstack != null ? itemstack.Copy() : itemstack;
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandleSetSlot(this);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			windowId = datainputstream.ReadByte();
			itemSlot = datainputstream.ReadShort();
			short word0 = datainputstream.ReadShort();
			if (word0 >= 0)
			{
				byte byte0 = datainputstream.ReadByte();
				short word1 = datainputstream.ReadShort();
				myItemStack = new net.minecraft.src.ItemStack(word0, byte0, word1);
			}
			else
			{
				myItemStack = null;
			}
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteByte(windowId);
			dataoutputstream.WriteShort(itemSlot);
			if (myItemStack == null)
			{
				dataoutputstream.WriteShort(-1);
			}
			else
			{
				dataoutputstream.WriteShort(myItemStack.itemID);
				dataoutputstream.WriteByte(myItemStack.stackSize);
				dataoutputstream.WriteShort(myItemStack.GetItemDamage());
			}
		}

		public override int GetPacketSize()
		{
			return 8;
		}

		public int windowId;

		public int itemSlot;

		public net.minecraft.src.ItemStack myItemStack;
	}
}
