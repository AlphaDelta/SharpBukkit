// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System;

namespace net.minecraft.src
{
	public class NextTickListEntry : IComparable
	{
		public NextTickListEntry(int i, int j, int k, int l)
		{
			tickEntryID = nextTickEntryID++;
			xCoord = i;
			yCoord = j;
			zCoord = k;
			blockID = l;
		}

		public override bool Equals(object obj)
		{
			if (obj is net.minecraft.src.NextTickListEntry)
			{
				net.minecraft.src.NextTickListEntry nextticklistentry = (net.minecraft.src.NextTickListEntry
					)obj;
				return xCoord == nextticklistentry.xCoord && yCoord == nextticklistentry.yCoord &&
					 zCoord == nextticklistentry.zCoord && blockID == nextticklistentry.blockID;
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return (xCoord * 128 * 1024 + zCoord * 128 + yCoord) * 256 + blockID;
		}

		public virtual net.minecraft.src.NextTickListEntry SetScheduledTime(long l)
		{
			scheduledTime = l;
			return this;
		}

		public virtual int Comparer(net.minecraft.src.NextTickListEntry nextticklistentry
			)
		{
			if (scheduledTime < nextticklistentry.scheduledTime)
			{
				return -1;
			}
			if (scheduledTime > nextticklistentry.scheduledTime)
			{
				return 1;
			}
			if (tickEntryID < nextticklistentry.tickEntryID)
			{
				return -1;
			}
			return tickEntryID <= nextticklistentry.tickEntryID ? 0 : 1;
		}

		public virtual int CompareTo(object obj)
		{
			return Comparer((net.minecraft.src.NextTickListEntry)obj);
		}

		private static long nextTickEntryID = 0L;

		public int xCoord;

		public int yCoord;

		public int zCoord;

		public int blockID;

		public long scheduledTime;

		private long tickEntryID;
	}
}
