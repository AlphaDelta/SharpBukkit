// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class NBTTagCompound : net.minecraft.src.NBTBase
	{
		public NBTTagCompound()
		{
			// Referenced classes of package net.minecraft.src:
			//            NBTBase, NBTTagByte, NBTTagShort, NBTTagInt, 
			//            NBTTagLong, NBTTagFloat, NBTTagDouble, NBTTagString, 
			//            NBTTagByteArray, NBTTagList
			tagMap = new System.Collections.Hashtable();
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void WriteTagContents(java.io.DataOutput dataoutput)
		{
			net.minecraft.src.NBTBase nbtbase;
			for (System.Collections.IEnumerator iterator = tagMap.Values.GetEnumerator(); iterator
				.MoveNext(); net.minecraft.src.NBTBase.WriteTag(nbtbase, dataoutput))
			{
				nbtbase = (net.minecraft.src.NBTBase)iterator.Current;
			}
			dataoutput.WriteByte(0);
		}

		/// <exception cref="System.IO.IOException"/>
		internal override void ReadTagContents(java.io.DataInput datainput)
		{
			tagMap.Clear();
			net.minecraft.src.NBTBase nbtbase;
			for (; (nbtbase = net.minecraft.src.NBTBase.ReadTag(datainput)).GetType() != 0; tagMap
				[nbtbase.GetKey()] = nbtbase)
			{
			}
		}

		public virtual System.Collections.ICollection Func_28107_c()
		{
			return tagMap.Values;
		}

		public override byte GetType()
		{
			return 10;
		}

		public virtual void SetTag(string s, net.minecraft.src.NBTBase nbtbase)
		{
			tagMap[s] = nbtbase.SetKey(s);
		}

		public virtual void SetByte(string s, byte byte0)
		{
			tagMap[s] = (new net.minecraft.src.NBTTagByte(byte0)).SetKey(s);
		}

		public virtual void SetShort(string s, short word0)
		{
			tagMap[s] = (new net.minecraft.src.NBTTagShort(word0)).SetKey(s);
		}

		public virtual void SetInteger(string s, int i)
		{
			tagMap[s] = (new net.minecraft.src.NBTTagInt(i)).SetKey(s);
		}

		public virtual void SetLong(string s, long l)
		{
			tagMap[s] = (new net.minecraft.src.NBTTagLong(l)).SetKey(s);
		}

		public virtual void SetFloat(string s, float f)
		{
			tagMap[s] = (new net.minecraft.src.NBTTagFloat(f)).SetKey(s);
		}

		public virtual void SetDouble(string s, double d)
		{
			tagMap[s] = (new net.minecraft.src.NBTTagDouble(d)).SetKey(s);
		}

		public virtual void SetString(string s, string s1)
		{
			tagMap[s] = (new net.minecraft.src.NBTTagString(s1)).SetKey(s);
		}

		public virtual void SetByteArray(string s, byte[] abyte0)
		{
			tagMap[s] = (new net.minecraft.src.NBTTagByteArray(abyte0)).SetKey(s);
		}

		public virtual void SetCompoundTag(string s, net.minecraft.src.NBTTagCompound nbttagcompound
			)
		{
			tagMap[s] = nbttagcompound.SetKey(s);
		}

		public virtual void SetBoolean(string s, bool flag)
		{
			SetByte(s, (unchecked((byte)(flag ? 1 : 0))));
		}

		public virtual bool HasKey(string s)
		{
			return tagMap.Contains(s);
		}

		public virtual byte GetByte(string s)
		{
			if (!tagMap.Contains(s))
			{
				return 0;
			}
			else
			{
				return ((net.minecraft.src.NBTTagByte)tagMap[s]).byteValue;
			}
		}

		public virtual short GetShort(string s)
		{
			if (!tagMap.Contains(s))
			{
				return 0;
			}
			else
			{
				return ((net.minecraft.src.NBTTagShort)tagMap[s]).shortValue;
			}
		}

		public virtual int GetInteger(string s)
		{
			if (!tagMap.Contains(s))
			{
				return 0;
			}
			else
			{
				return ((net.minecraft.src.NBTTagInt)tagMap[s]).intValue;
			}
		}

		public virtual long GetLong(string s)
		{
			if (!tagMap.Contains(s))
			{
				return 0L;
			}
			else
			{
				return ((net.minecraft.src.NBTTagLong)tagMap[s]).longValue;
			}
		}

		public virtual float GetFloat(string s)
		{
			if (!tagMap.Contains(s))
			{
				return 0.0F;
			}
			else
			{
				return ((net.minecraft.src.NBTTagFloat)tagMap[s]).floatValue;
			}
		}

		public virtual double GetDouble(string s)
		{
			if (!tagMap.Contains(s))
			{
				return 0.0D;
			}
			else
			{
				return ((net.minecraft.src.NBTTagDouble)tagMap[s]).doubleValue;
			}
		}

		public virtual string GetString(string s)
		{
			if (!tagMap.Contains(s))
			{
				return string.Empty;
			}
			else
			{
				return ((net.minecraft.src.NBTTagString)tagMap[s]).stringValue;
			}
		}

		public virtual byte[] GetByteArray(string s)
		{
			if (!tagMap.Contains(s))
			{
				return new byte[0];
			}
			else
			{
				return ((net.minecraft.src.NBTTagByteArray)tagMap[s]).byteArray;
			}
		}

		public virtual net.minecraft.src.NBTTagCompound GetCompoundTag(string s)
		{
			if (!tagMap.Contains(s))
			{
				return new net.minecraft.src.NBTTagCompound();
			}
			else
			{
				return (net.minecraft.src.NBTTagCompound)tagMap[s];
			}
		}

		public virtual net.minecraft.src.NBTTagList GetTagList(string s)
		{
			if (!tagMap.Contains(s))
			{
				return new net.minecraft.src.NBTTagList();
			}
			else
			{
				return (net.minecraft.src.NBTTagList)tagMap[s];
			}
		}

		public virtual bool GetBoolean(string s)
		{
			return GetByte(s) != 0;
		}

		public override string ToString()
		{
			return (new java.lang.StringBuilder()).Append(string.Empty).Append(tagMap.Count).
				Append(" entries").ToString();
		}

		private System.Collections.IDictionary tagMap;
	}
}
