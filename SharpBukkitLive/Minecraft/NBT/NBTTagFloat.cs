// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class NBTTagFloat : net.minecraft.src.NBTBase
	{
		public NBTTagFloat()
		{
		}

		public NBTTagFloat(float f)
		{
			// Referenced classes of package net.minecraft.src:
			//            NBTBase
			floatValue = f;
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void WriteTagContents(java.io.DataOutput dataoutput)
		{
			dataoutput.WriteFloat(floatValue);
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void ReadTagContents(java.io.DataInput datainput)
		{
			floatValue = datainput.ReadFloat();
		}

		public override byte GetType()
		{
			return 5;
		}

		public override string ToString()
		{
			return (new java.lang.StringBuilder()).Append(string.Empty).Append(floatValue).ToString
				();
		}

		public float floatValue;
	}
}
