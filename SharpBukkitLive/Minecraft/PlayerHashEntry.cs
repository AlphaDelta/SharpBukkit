// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	internal class PlayerHashEntry
	{
		internal PlayerHashEntry(int i, long l, object obj, net.minecraft.src.PlayerHashEntry
			 playerhashentry)
		{
			// Referenced classes of package net.minecraft.src:
			//            PlayerHash
			value = obj;
			nextEntry = playerhashentry;
			key = l;
			field_1026_d = i;
		}

		public long Func_736_a()
		{
			return key;
		}

		public object Func_735_b()
		{
			return value;
		}

		public sealed override bool Equals(object obj)
		{
			if (!(obj is net.minecraft.src.PlayerHashEntry))
			{
				return false;
			}
			net.minecraft.src.PlayerHashEntry playerhashentry = (net.minecraft.src.PlayerHashEntry
				)obj;
			long long1 = Func_736_a();
			long long2 = playerhashentry.Func_736_a();
			if (long1 == long2 || long1 != null && long1.Equals(long2))
			{
				object obj1 = Func_735_b();
				object obj2 = playerhashentry.Func_735_b();
				if (obj1 == obj2 || obj1 != null && obj1.Equals(obj2))
				{
					return true;
				}
			}
			return false;
		}

		public sealed override int GetHashCode()
		{
			return net.minecraft.src.PlayerHash.GetHashCode(key);
		}

		public sealed override string ToString()
		{
			return (new java.lang.StringBuilder()).Append(Func_736_a()).Append("=").Append(Func_735_b
				()).ToString();
		}

		internal readonly long key;

		internal object value;

		internal net.minecraft.src.PlayerHashEntry nextEntry;

		internal readonly int field_1026_d;
	}
}
