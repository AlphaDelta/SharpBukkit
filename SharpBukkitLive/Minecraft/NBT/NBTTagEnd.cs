// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class NBTTagEnd : net.minecraft.src.NBTBase
	{
		public NBTTagEnd()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            NBTBase
		/// <exception cref="System.IO.IOException"/>
		internal override void ReadTagContents(java.io.DataInput datainput)
		{
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void WriteTagContents(java.io.DataOutput dataoutput)
		{
		}

		public override byte GetType()
		{
			return 0;
		}

		public override string ToString()
		{
			return "END";
		}
	}
}
