// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class MCHash
	{
		public MCHash()
		{
			// Referenced classes of package net.minecraft.src:
			//            MCHashEntry
			threshold = 12;
			slots = new net.minecraft.src.MCHashEntry[16];
		}

		private static int ComputeHash(int i)
		{
			i ^= (int)(((uint)i) >> 20) ^ (int)(((uint)i) >> 12);
			return i ^ (int)(((uint)i) >> 7) ^ (int)(((uint)i) >> 4);
		}

		private static int GetSlotIndex(int i, int j)
		{
			return i & j - 1;
		}

		public virtual object Lookup(int i)
		{
			int j = ComputeHash(i);
			for (net.minecraft.src.MCHashEntry mchashentry = slots[GetSlotIndex(j, slots.Length
				)]; mchashentry != null; mchashentry = mchashentry.nextEntry)
			{
				if (mchashentry.hashEntry == i)
				{
					return mchashentry.valueEntry;
				}
			}
			return null;
		}

		public virtual bool ContainsItem(int i)
		{
			return LookupEntry(i) != null;
		}

		internal net.minecraft.src.MCHashEntry LookupEntry(int i)
		{
			int j = ComputeHash(i);
			for (net.minecraft.src.MCHashEntry mchashentry = slots[GetSlotIndex(j, slots.Length
				)]; mchashentry != null; mchashentry = mchashentry.nextEntry)
			{
				if (mchashentry.hashEntry == i)
				{
					return mchashentry;
				}
			}
			return null;
		}

		public virtual void AddKey(int i, object obj)
		{
			int j = ComputeHash(i);
			int k = GetSlotIndex(j, slots.Length);
			for (net.minecraft.src.MCHashEntry mchashentry = slots[k]; mchashentry != null; mchashentry
				 = mchashentry.nextEntry)
			{
				if (mchashentry.hashEntry == i)
				{
					mchashentry.valueEntry = obj;
				}
			}
			versionStamp++;
			Insert(j, i, obj, k);
		}

		private void Grow(int i)
		{
			net.minecraft.src.MCHashEntry[] amchashentry = slots;
			int j = amchashentry.Length;
			if (j == 0x40000000)
			{
				threshold = 0x7fffffff;
				return;
			}
			else
			{
				net.minecraft.src.MCHashEntry[] amchashentry1 = new net.minecraft.src.MCHashEntry
					[i];
				CopyTo(amchashentry1);
				slots = amchashentry1;
				threshold = (int)((float)i * growFactor);
				return;
			}
		}

		private void CopyTo(net.minecraft.src.MCHashEntry[] amchashentry)
		{
			net.minecraft.src.MCHashEntry[] amchashentry1 = slots;
			int i = amchashentry.Length;
			for (int j = 0; j < amchashentry1.Length; j++)
			{
				net.minecraft.src.MCHashEntry mchashentry = amchashentry1[j];
				if (mchashentry == null)
				{
					continue;
				}
				amchashentry1[j] = null;
				do
				{
					net.minecraft.src.MCHashEntry mchashentry1 = mchashentry.nextEntry;
					int k = GetSlotIndex(mchashentry.slotHash, i);
					mchashentry.nextEntry = amchashentry[k];
					amchashentry[k] = mchashentry;
					mchashentry = mchashentry1;
				}
				while (mchashentry != null);
			}
		}

		public virtual object RemoveObject(int i)
		{
			net.minecraft.src.MCHashEntry mchashentry = RemoveEntry(i);
			return mchashentry != null ? mchashentry.valueEntry : null;
		}

		internal net.minecraft.src.MCHashEntry RemoveEntry(int i)
		{
			int j = ComputeHash(i);
			int k = GetSlotIndex(j, slots.Length);
			net.minecraft.src.MCHashEntry mchashentry = slots[k];
			net.minecraft.src.MCHashEntry mchashentry1;
			net.minecraft.src.MCHashEntry mchashentry2;
			for (mchashentry1 = mchashentry; mchashentry1 != null; mchashentry1 = mchashentry2)
			{
				mchashentry2 = mchashentry1.nextEntry;
				if (mchashentry1.hashEntry == i)
				{
					versionStamp++;
					count--;
					if (mchashentry == mchashentry1)
					{
						slots[k] = mchashentry2;
					}
					else
					{
						mchashentry.nextEntry = mchashentry2;
					}
					return mchashentry1;
				}
				mchashentry = mchashentry1;
			}
			return mchashentry1;
		}

		public virtual void ClearMap()
		{
			versionStamp++;
			net.minecraft.src.MCHashEntry[] amchashentry = slots;
			for (int i = 0; i < amchashentry.Length; i++)
			{
				amchashentry[i] = null;
			}
			count = 0;
		}

		private void Insert(int i, int j, object obj, int k)
		{
			net.minecraft.src.MCHashEntry mchashentry = slots[k];
			slots[k] = new net.minecraft.src.MCHashEntry(i, j, obj, mchashentry);
			if (count++ >= threshold)
			{
				Grow(2 * slots.Length);
			}
		}

		internal static int GetHash(int i)
		{
			return ComputeHash(i);
		}

		[System.NonSerialized]
		private net.minecraft.src.MCHashEntry[] slots;

		[System.NonSerialized]
		private int count;

		private int threshold;

		private readonly float growFactor = 0.75F;

		[System.NonSerialized]
		private volatile int versionStamp;
	}
}
