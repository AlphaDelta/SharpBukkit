// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class NBTTagLong : net.minecraft.src.NBTBase
	{
		public NBTTagLong()
		{
		}

		public NBTTagLong(long l)
		{
			// Referenced classes of package net.minecraft.src:
			//            NBTBase
			longValue = l;
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void WriteTagContents(java.io.DataOutput dataoutput)
		{
			dataoutput.WriteLong(longValue);
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void ReadTagContents(java.io.DataInput datainput)
		{
			longValue = datainput.ReadLong();
		}

		public override byte GetType()
		{
			return 4;
		}

		public override string ToString()
		{
			return (new java.lang.StringBuilder()).Append(string.Empty).Append(longValue).ToString
				();
		}

		public long longValue;
	}
}
