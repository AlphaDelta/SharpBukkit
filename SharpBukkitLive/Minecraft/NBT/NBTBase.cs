// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public abstract class NBTBase
	{
		public NBTBase()
		{
			// Referenced classes of package net.minecraft.src:
			//            NBTTagEnd, NBTTagByte, NBTTagShort, NBTTagInt, 
			//            NBTTagLong, NBTTagFloat, NBTTagDouble, NBTTagByteArray, 
			//            NBTTagString, NBTTagList, NBTTagCompound
			key = null;
		}

		/// <exception cref="System.IO.IOException"/>
		internal abstract void WriteTagContents(java.io.DataOutput dataoutput);

		/// <exception cref="System.IO.IOException"/>
		internal abstract void ReadTagContents(java.io.DataInput datainput);

		public abstract byte GetType();

		public virtual string GetKey()
		{
			if (key == null)
			{
				return string.Empty;
			}
			else
			{
				return key;
			}
		}

		public virtual net.minecraft.src.NBTBase SetKey(string s)
		{
			key = s;
			return this;
		}

		/// <exception cref="System.IO.IOException"/>
		public static net.minecraft.src.NBTBase ReadTag(java.io.DataInput datainput)
		{
			byte byte0 = datainput.ReadByte();
			if (byte0 == 0)
			{
				return new net.minecraft.src.NBTTagEnd();
			}
			else
			{
				net.minecraft.src.NBTBase nbtbase = CreateTagOfType(byte0);
				nbtbase.key = datainput.ReadUTF();
				nbtbase.ReadTagContents(datainput);
				return nbtbase;
			}
		}

		/// <exception cref="System.IO.IOException"/>
		public static void WriteTag(net.minecraft.src.NBTBase nbtbase, java.io.DataOutput
			 dataoutput)
		{
			dataoutput.WriteByte(nbtbase.GetType());
			if (nbtbase.GetType() == 0)
			{
				return;
			}
			else
			{
				dataoutput.WriteUTF(nbtbase.GetKey());
				nbtbase.WriteTagContents(dataoutput);
				return;
			}
		}

		public static net.minecraft.src.NBTBase CreateTagOfType(byte byte0)
		{
			switch (byte0)
			{
				case 0:
				{
					// '\0'
					return new net.minecraft.src.NBTTagEnd();
				}

				case 1:
				{
					// '\001'
					return new net.minecraft.src.NBTTagByte();
				}

				case 2:
				{
					// '\002'
					return new net.minecraft.src.NBTTagShort();
				}

				case 3:
				{
					// '\003'
					return new net.minecraft.src.NBTTagInt();
				}

				case 4:
				{
					// '\004'
					return new net.minecraft.src.NBTTagLong();
				}

				case 5:
				{
					// '\005'
					return new net.minecraft.src.NBTTagFloat();
				}

				case 6:
				{
					// '\006'
					return new net.minecraft.src.NBTTagDouble();
				}

				case 7:
				{
					// '\007'
					return new net.minecraft.src.NBTTagByteArray();
				}

				case 8:
				{
					// '\b'
					return new net.minecraft.src.NBTTagString();
				}

				case 9:
				{
					// '\t'
					return new net.minecraft.src.NBTTagList();
				}

				case 10:
				{
					// '\n'
					return new net.minecraft.src.NBTTagCompound();
				}
			}
			return null;
		}

		public static string GetTagName(byte byte0)
		{
			switch (byte0)
			{
				case 0:
				{
					// '\0'
					return "TAG_End";
				}

				case 1:
				{
					// '\001'
					return "TAG_Byte";
				}

				case 2:
				{
					// '\002'
					return "TAG_Short";
				}

				case 3:
				{
					// '\003'
					return "TAG_Int";
				}

				case 4:
				{
					// '\004'
					return "TAG_Long";
				}

				case 5:
				{
					// '\005'
					return "TAG_Float";
				}

				case 6:
				{
					// '\006'
					return "TAG_Double";
				}

				case 7:
				{
					// '\007'
					return "TAG_Byte_Array";
				}

				case 8:
				{
					// '\b'
					return "TAG_String";
				}

				case 9:
				{
					// '\t'
					return "TAG_List";
				}

				case 10:
				{
					// '\n'
					return "TAG_Compound";
				}
			}
			return "UNKNOWN";
		}

		private string key;
	}
}
