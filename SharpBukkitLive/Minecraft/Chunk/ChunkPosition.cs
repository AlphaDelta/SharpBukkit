// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ChunkPosition
	{
		public ChunkPosition(int i, int j, int k)
		{
			x = i;
			y = j;
			z = k;
		}

		public override bool Equals(object obj)
		{
			if (obj is net.minecraft.src.ChunkPosition)
			{
				net.minecraft.src.ChunkPosition chunkposition = (net.minecraft.src.ChunkPosition)
					obj;
				return chunkposition.x == x && chunkposition.y == y && chunkposition.z == z;
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return x * 0x88f9fa + y * 0xef88b + z;
		}

		public readonly int x;

		public readonly int y;

		public readonly int z;
	}
}
