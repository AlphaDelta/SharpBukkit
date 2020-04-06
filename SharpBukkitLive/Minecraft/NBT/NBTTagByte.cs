// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class NBTTagByte : net.minecraft.src.NBTBase
	{
		public NBTTagByte()
		{
		}

		public NBTTagByte(byte byte0)
		{
			// Referenced classes of package net.minecraft.src:
			//            NBTBase
			byteValue = byte0;
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void WriteTagContents(java.io.DataOutput dataoutput)
		{
			dataoutput.WriteByte(byteValue);
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void ReadTagContents(java.io.DataInput datainput)
		{
			byteValue = datainput.ReadByte();
		}

		public override byte GetType()
		{
			return 1;
		}

		public override string ToString()
		{
			return (new java.lang.StringBuilder()).Append(string.Empty).Append(byteValue).ToString
				();
		}

		public byte byteValue;
	}
}
