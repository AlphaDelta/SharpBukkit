// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class PlayerHash
	{
		public PlayerHash()
		{
			// Referenced classes of package net.minecraft.src:
			//            PlayerHashEntry
			capacity = 12;
			hashArray = new net.minecraft.src.PlayerHashEntry[16];
		}

		private static int GetHashedKey(long l)
		{
			return Hash((int)(l ^ (long)(((ulong)l) >> 32)));
		}

		private static int Hash(int i)
		{
			i ^= (int)(((uint)i) >> 20) ^ (int)(((uint)i) >> 12);
			return i ^ (int)(((uint)i) >> 7) ^ (int)(((uint)i) >> 4);
		}

		private static int GetHashIndex(int i, int j)
		{
			return i & j - 1;
		}

		public virtual object GetValueByKey(long l)
		{
			int i = GetHashedKey(l);
			for (net.minecraft.src.PlayerHashEntry playerhashentry = hashArray[GetHashIndex(i
				, hashArray.Length)]; playerhashentry != null; playerhashentry = playerhashentry
				.nextEntry)
			{
				if (playerhashentry.key == l)
				{
					return playerhashentry.value;
				}
			}
			return null;
		}

		public virtual void Add(long l, object obj)
		{
			int i = GetHashedKey(l);
			int j = GetHashIndex(i, hashArray.Length);
			for (net.minecraft.src.PlayerHashEntry playerhashentry = hashArray[j]; playerhashentry
				 != null; playerhashentry = playerhashentry.nextEntry)
			{
				if (playerhashentry.key == l)
				{
					playerhashentry.value = obj;
				}
			}
			field_950_e++;
			CreateKey(i, l, obj, j);
		}

		private void ResizeTable(int i)
		{
			net.minecraft.src.PlayerHashEntry[] aplayerhashentry = hashArray;
			int j = aplayerhashentry.Length;
			if (j == 0x40000000)
			{
				capacity = 0x7fffffff;
				return;
			}
			else
			{
				net.minecraft.src.PlayerHashEntry[] aplayerhashentry1 = new net.minecraft.src.PlayerHashEntry
					[i];
				CopyHashTableTo(aplayerhashentry1);
				hashArray = aplayerhashentry1;
				capacity = (int)((float)i * percentUsable);
				return;
			}
		}

		private void CopyHashTableTo(net.minecraft.src.PlayerHashEntry[] aplayerhashentry
			)
		{
			net.minecraft.src.PlayerHashEntry[] aplayerhashentry1 = hashArray;
			int i = aplayerhashentry.Length;
			for (int j = 0; j < aplayerhashentry1.Length; j++)
			{
				net.minecraft.src.PlayerHashEntry playerhashentry = aplayerhashentry1[j];
				if (playerhashentry == null)
				{
					continue;
				}
				aplayerhashentry1[j] = null;
				do
				{
					net.minecraft.src.PlayerHashEntry playerhashentry1 = playerhashentry.nextEntry;
					int k = GetHashIndex(playerhashentry.field_1026_d, i);
					playerhashentry.nextEntry = aplayerhashentry[k];
					aplayerhashentry[k] = playerhashentry;
					playerhashentry = playerhashentry1;
				}
				while (playerhashentry != null);
			}
		}

		public virtual object Remove(long l)
		{
			net.minecraft.src.PlayerHashEntry playerhashentry = RemoveKey(l);
			return playerhashentry != null ? playerhashentry.value : null;
		}

		internal net.minecraft.src.PlayerHashEntry RemoveKey(long l)
		{
			int i = GetHashedKey(l);
			int j = GetHashIndex(i, hashArray.Length);
			net.minecraft.src.PlayerHashEntry playerhashentry = hashArray[j];
			net.minecraft.src.PlayerHashEntry playerhashentry1;
			net.minecraft.src.PlayerHashEntry playerhashentry2;
			for (playerhashentry1 = playerhashentry; playerhashentry1 != null; playerhashentry1
				 = playerhashentry2)
			{
				playerhashentry2 = playerhashentry1.nextEntry;
				if (playerhashentry1.key == l)
				{
					field_950_e++;
					numHashElements--;
					if (playerhashentry == playerhashentry1)
					{
						hashArray[j] = playerhashentry2;
					}
					else
					{
						playerhashentry.nextEntry = playerhashentry2;
					}
					return playerhashentry1;
				}
				playerhashentry = playerhashentry1;
			}
			return playerhashentry1;
		}

		private void CreateKey(int i, long l, object obj, int j)
		{
			net.minecraft.src.PlayerHashEntry playerhashentry = hashArray[j];
			hashArray[j] = new net.minecraft.src.PlayerHashEntry(i, l, obj, playerhashentry);
			if (numHashElements++ >= capacity)
			{
				ResizeTable(2 * hashArray.Length);
			}
		}

		internal static int GetHashCode(long l)
		{
			return GetHashedKey(l);
		}

		[System.NonSerialized]
		private net.minecraft.src.PlayerHashEntry[] hashArray;

		[System.NonSerialized]
		private int numHashElements;

		private int capacity;

		private readonly float percentUsable = 0.75F;

		[System.NonSerialized]
		private volatile int field_950_e;
	}
}
