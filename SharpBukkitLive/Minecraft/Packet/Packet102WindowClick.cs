// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet102WindowClick : net.minecraft.src.Packet
	{
		public Packet102WindowClick()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Packet, NetHandler, ItemStack
		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.Func_20007_a(this);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			window_Id = datainputstream.ReadByte();
			inventorySlot = datainputstream.ReadShort();
			mouseClick = datainputstream.ReadByte();
			action = datainputstream.ReadShort();
			field_27039_f = datainputstream.ReadBoolean();
			short word0 = datainputstream.ReadShort();
			if (word0 >= 0)
			{
				byte byte0 = datainputstream.ReadByte();
				short word1 = datainputstream.ReadShort();
				itemStack = new net.minecraft.src.ItemStack(word0, byte0, word1);
			}
			else
			{
				itemStack = null;
			}
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteByte(window_Id);
			dataoutputstream.WriteShort(inventorySlot);
			dataoutputstream.WriteByte(mouseClick);
			dataoutputstream.WriteShort(action);
			dataoutputstream.WriteBoolean(field_27039_f);
			if (itemStack == null)
			{
				dataoutputstream.WriteShort(-1);
			}
			else
			{
				dataoutputstream.WriteShort(itemStack.itemID);
				dataoutputstream.WriteByte(itemStack.stackSize);
				dataoutputstream.WriteShort(itemStack.GetItemDamage());
			}
		}

		public override int GetPacketSize()
		{
			return 11;
		}

		public int window_Id;

		public int inventorySlot;

		public int mouseClick;

		public short action;

		public net.minecraft.src.ItemStack itemStack;

		public bool field_27039_f;
	}
}
