// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class NBTTagList : net.minecraft.src.NBTBase
	{
		public NBTTagList()
		{
			// Referenced classes of package net.minecraft.src:
			//            NBTBase
			tagList = new System.Collections.ArrayList();
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void WriteTagContents(java.io.DataOutput dataoutput)
		{
			if (tagList.Count > 0)
			{
				tagType = ((net.minecraft.src.NBTBase)tagList[0]).GetType();
			}
			else
			{
				tagType = 1;
			}
			dataoutput.WriteByte(tagType);
			dataoutput.WriteInt(tagList.Count);
			for (int i = 0; i < tagList.Count; i++)
			{
				((net.minecraft.src.NBTBase)tagList[i]).WriteTagContents(dataoutput);
			}
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void ReadTagContents(java.io.DataInput datainput)
		{
			tagType = datainput.ReadByte();
			int i = datainput.ReadInt();
			tagList = new System.Collections.ArrayList();
			for (int j = 0; j < i; j++)
			{
				net.minecraft.src.NBTBase nbtbase = net.minecraft.src.NBTBase.CreateTagOfType(tagType
					);
				nbtbase.ReadTagContents(datainput);
				tagList.Add(nbtbase);
			}
		}

		public override byte GetType()
		{
			return 9;
		}

		public override string ToString()
		{
			return (new java.lang.StringBuilder()).Append(string.Empty).Append(tagList.Count)
				.Append(" entries of type ").Append(net.minecraft.src.NBTBase.GetTagName(tagType
				)).ToString();
		}

		public virtual void SetTag(net.minecraft.src.NBTBase nbtbase)
		{
			tagType = nbtbase.GetType();
			tagList.Add(nbtbase);
		}

		public virtual net.minecraft.src.NBTBase TagAt(int i)
		{
			return (net.minecraft.src.NBTBase)tagList[i];
		}

		public virtual int TagCount()
		{
			return tagList.Count;
		}

		private System.Collections.IList tagList;

		private byte tagType;
	}
}
