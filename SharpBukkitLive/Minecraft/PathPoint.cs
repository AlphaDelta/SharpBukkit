// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class PathPoint
	{
		public PathPoint(int i, int j, int k)
		{
			// Referenced classes of package net.minecraft.src:
			//            MathHelper
			index = -1;
			isFirst = false;
			xCoord = i;
			yCoord = j;
			zCoord = k;
			hash = Func_22203_a(i, j, k);
		}

		public static int Func_22203_a(int i, int j, int k)
		{
			return j & unchecked((int)(0xff)) | (i & unchecked((int)(0x7fff))) << 8 | (k & unchecked(
				(int)(0x7fff))) << 24 | (i >= 0 ? 0 : unchecked((int)(0x80000000))) | (k >= 0 ? 
				0 : unchecked((int)(0x8000)));
		}

		public virtual float DistanceTo(net.minecraft.src.PathPoint pathpoint)
		{
			float f = pathpoint.xCoord - xCoord;
			float f1 = pathpoint.yCoord - yCoord;
			float f2 = pathpoint.zCoord - zCoord;
			return net.minecraft.src.MathHelper.Sqrt_float(f * f + f1 * f1 + f2 * f2);
		}

		public override bool Equals(object obj)
		{
			if (obj is net.minecraft.src.PathPoint)
			{
				net.minecraft.src.PathPoint pathpoint = (net.minecraft.src.PathPoint)obj;
				return hash == pathpoint.hash && xCoord == pathpoint.xCoord && yCoord == pathpoint
					.yCoord && zCoord == pathpoint.zCoord;
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return hash;
		}

		public virtual bool IsAssigned()
		{
			return index >= 0;
		}

		public override string ToString()
		{
			return (new java.lang.StringBuilder()).Append(xCoord).Append(", ").Append(yCoord)
				.Append(", ").Append(zCoord).ToString();
		}

		public readonly int xCoord;

		public readonly int yCoord;

		public readonly int zCoord;

		private readonly int hash;

		internal int index;

		internal float totalPathDistance;

		internal float distanceToNext;

		internal float distanceToTarget;

		internal net.minecraft.src.PathPoint previous;

		public bool isFirst;
	}
}
