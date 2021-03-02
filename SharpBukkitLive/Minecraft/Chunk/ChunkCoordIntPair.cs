// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ChunkCoordIntPair
	{
		public ChunkCoordIntPair(int i, int j)
		{
			X = i;
			Z = j;
		}

		public static int ChunkXZ2Int(int i, int j)
		{
			return (i >= 0 ? 0 : unchecked((int)(0x80000000))) | (i & 0x7fff) << 16 | (j >= 0 ? 0 : 0x8000) | j & 0x7fff;
		}

		public override int GetHashCode()
		{
			return ChunkXZ2Int(X, Z);
		}

		public override bool Equals(object obj)
		{
			net.minecraft.src.ChunkCoordIntPair chunkcoordintpair = (net.minecraft.src.ChunkCoordIntPair
				)obj;
			return chunkcoordintpair.X == X && chunkcoordintpair.Z ==
				 Z;
		}

		public readonly int X;

		public readonly int Z;
	}
}
