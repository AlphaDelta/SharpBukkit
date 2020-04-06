// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class NBTTagShort : net.minecraft.src.NBTBase
	{
		public NBTTagShort()
		{
		}

		public NBTTagShort(short word0)
		{
			// Referenced classes of package net.minecraft.src:
			//            NBTBase
			shortValue = word0;
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void WriteTagContents(java.io.DataOutput dataoutput)
		{
			dataoutput.WriteShort(shortValue);
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void ReadTagContents(java.io.DataInput datainput)
		{
			shortValue = datainput.ReadShort();
		}

		public override byte GetType()
		{
			return 2;
		}

		public override string ToString()
		{
			return (new java.lang.StringBuilder()).Append(string.Empty).Append(shortValue).ToString
				();
		}

		public short shortValue;
	}
}
