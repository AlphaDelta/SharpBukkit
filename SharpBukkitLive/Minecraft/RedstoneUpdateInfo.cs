// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	internal class RedstoneUpdateInfo
	{
		public RedstoneUpdateInfo(int i, int j, int k, long l)
		{
			x = i;
			y = j;
			z = k;
			updateTime = l;
		}

		internal int x;

		internal int y;

		internal int z;

		internal long updateTime;
	}
}
