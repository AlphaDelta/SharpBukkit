// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet15Place : net.minecraft.src.Packet
	{
		public Packet15Place()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Packet, ItemStack, NetHandler
		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			xPosition = datainputstream.ReadInt();
			yPosition = datainputstream.Read();
			zPosition = datainputstream.ReadInt();
			direction = datainputstream.Read();
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
			dataoutputstream.WriteInt(xPosition);
			dataoutputstream.Write(yPosition);
			dataoutputstream.WriteInt(zPosition);
			dataoutputstream.Write(direction);
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

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.HandlePlace(this);
		}

		public override int GetPacketSize()
		{
			return 15;
		}

		public int xPosition;

		public int yPosition;

		public int zPosition;

		public int direction;

		public net.minecraft.src.ItemStack itemStack;
	}
}
