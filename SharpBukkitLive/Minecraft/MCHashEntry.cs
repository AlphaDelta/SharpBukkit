// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	internal class MCHashEntry
	{
		internal MCHashEntry(int i, int j, object obj, net.minecraft.src.MCHashEntry mchashentry
			)
		{
			// Referenced classes of package net.minecraft.src:
			//            MCHash
			valueEntry = obj;
			nextEntry = mchashentry;
			hashEntry = j;
			slotHash = i;
		}

		public int GetHash()
		{
			return hashEntry;
		}

		public object GetValue()
		{
			return valueEntry;
		}

		public sealed override bool Equals(object obj)
		{
			if (!(obj is net.minecraft.src.MCHashEntry))
			{
				return false;
			}
			net.minecraft.src.MCHashEntry mchashentry = (net.minecraft.src.MCHashEntry)obj;
			int integer = GetHash();
			int integer1 = mchashentry.GetHash();
			if (integer == integer1 || integer != null && integer.Equals(integer1))
			{
				object obj1 = GetValue();
				object obj2 = mchashentry.GetValue();
				if (obj1 == obj2 || obj1 != null && obj1.Equals(obj2))
				{
					return true;
				}
			}
			return false;
		}

		public sealed override int GetHashCode()
		{
			return net.minecraft.src.MCHash.GetHash(hashEntry);
		}

		public sealed override string ToString()
		{
			return (new java.lang.StringBuilder()).Append(GetHash()).Append("=").Append(GetValue
				()).ToString();
		}

		internal readonly int hashEntry;

		internal object valueEntry;

		internal net.minecraft.src.MCHashEntry nextEntry;

		internal readonly int slotHash;
	}
}
