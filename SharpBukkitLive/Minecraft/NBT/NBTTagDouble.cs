// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class NBTTagDouble : net.minecraft.src.NBTBase
	{
		public NBTTagDouble()
		{
		}

		public NBTTagDouble(double d)
		{
			// Referenced classes of package net.minecraft.src:
			//            NBTBase
			doubleValue = d;
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void WriteTagContents(java.io.DataOutput dataoutput)
		{
			dataoutput.WriteDouble(doubleValue);
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void ReadTagContents(java.io.DataInput datainput)
		{
			doubleValue = datainput.ReadDouble();
		}

		public override byte GetType()
		{
			return 6;
		}

		public override string ToString()
		{
			return (new java.lang.StringBuilder()).Append(string.Empty).Append(doubleValue).ToString
				();
		}

		public double doubleValue;
	}
}
