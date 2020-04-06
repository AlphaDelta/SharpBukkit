// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class NBTTagString : net.minecraft.src.NBTBase
	{
		public NBTTagString()
		{
		}

		public NBTTagString(string s)
		{
			// Referenced classes of package net.minecraft.src:
			//            NBTBase
			stringValue = s;
			if (s == null)
			{
				throw new System.ArgumentException("Empty string not allowed");
			}
			else
			{
				return;
			}
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void WriteTagContents(java.io.DataOutput dataoutput)
		{
			dataoutput.WriteUTF(stringValue);
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void ReadTagContents(java.io.DataInput datainput)
		{
			stringValue = datainput.ReadUTF();
		}

		public override byte GetType()
		{
			return 8;
		}

		public override string ToString()
		{
			return (new java.lang.StringBuilder()).Append(string.Empty).Append(stringValue).ToString
				();
		}

		public string stringValue;
	}
}
