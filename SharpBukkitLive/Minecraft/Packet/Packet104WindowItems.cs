// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet104WindowItems : net.minecraft.src.Packet
	{
		public Packet104WindowItems()
		{
		}

		public Packet104WindowItems(int i, System.Collections.IList list)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, ItemStack, NetHandler
			windowId = i;
			itemStack = new net.minecraft.src.ItemStack[list.Count];
			for (int j = 0; j < itemStack.Length; j++)
			{
				net.minecraft.src.ItemStack itemstack = (net.minecraft.src.ItemStack)list[j];
				itemStack[j] = itemstack != null ? itemstack.Copy() : null;
			}
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			windowId = datainputstream.ReadByte();
			short word0 = datainputstream.ReadShort();
			itemStack = new net.minecraft.src.ItemStack[word0];
			for (int i = 0; i < word0; i++)
			{
				short word1 = datainputstream.ReadShort();
				if (word1 >= 0)
				{
					byte byte0 = datainputstream.ReadByte();
					short word2 = datainputstream.ReadShort();
					itemStack[i] = new net.minecraft.src.ItemStack(word1, byte0, word2);
				}
			}
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteByte(windowId);
			dataoutputstream.WriteShort(itemStack.Length);
			for (int i = 0; i < itemStack.Length; i++)
			{
				if (itemStack[i] == null)
				{
					dataoutputstream.WriteShort(-1);
				}
				else
				{
					dataoutputstream.WriteShort((short)itemStack[i].itemID);
					dataoutputstream.WriteByte(unchecked((byte)itemStack[i].stackSize));
					dataoutputstream.WriteShort((short)itemStack[i].GetItemDamage());
				}
			}
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.Func_20001_a(this);
		}

		public override int GetPacketSize()
		{
			return 3 + itemStack.Length * 5;
		}

		public int windowId;

		public net.minecraft.src.ItemStack[] itemStack;
	}
}
