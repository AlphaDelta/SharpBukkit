// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class NBTTagByteArray : net.minecraft.src.NBTBase
	{
		public NBTTagByteArray()
		{
		}

		public NBTTagByteArray(byte[] abyte0)
		{
			// Referenced classes of package net.minecraft.src:
			//            NBTBase
			byteArray = abyte0;
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void WriteTagContents(java.io.DataOutput dataoutput)
		{
			dataoutput.WriteInt(byteArray.Length);
			dataoutput.Write(byteArray);
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void ReadTagContents(java.io.DataInput datainput)
		{
			int i = datainput.ReadInt();
			byteArray = new byte[i];
			datainput.ReadFully(byteArray);
		}

		public override byte GetType()
		{
			return 7;
		}

		public override string ToString()
		{
			return (new java.lang.StringBuilder()).Append("[").Append(byteArray.Length).Append
				(" bytes]").ToString();
		}

		public byte[] byteArray;
	}
}
