// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System;

namespace net.minecraft.src
{
	public class ChunkCoordinates : IComparable
	{
		public ChunkCoordinates()
		{
		}

		public ChunkCoordinates(int i, int j, int k)
		{
			posX = i;
			posY = j;
			posZ = k;
		}

		public ChunkCoordinates(net.minecraft.src.ChunkCoordinates chunkcoordinates)
		{
			posX = chunkcoordinates.posX;
			posY = chunkcoordinates.posY;
			posZ = chunkcoordinates.posZ;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is net.minecraft.src.ChunkCoordinates))
			{
				return false;
			}
			else
			{
				net.minecraft.src.ChunkCoordinates chunkcoordinates = (net.minecraft.src.ChunkCoordinates
					)obj;
				return posX == chunkcoordinates.posX && posY == chunkcoordinates.posY && posZ == 
					chunkcoordinates.posZ;
			}
		}

		public override int GetHashCode()
		{
			return posX + posZ << 8 + posY << 16;
		}

		public virtual int CompareChunkCoordinate(net.minecraft.src.ChunkCoordinates chunkcoordinates
			)
		{
			if (posY == chunkcoordinates.posY)
			{
				if (posZ == chunkcoordinates.posZ)
				{
					return posX - chunkcoordinates.posX;
				}
				else
				{
					return posZ - chunkcoordinates.posZ;
				}
			}
			else
			{
				return posY - chunkcoordinates.posY;
			}
		}

		public virtual double GetSqDistanceTo(int i, int j, int k)
		{
			int l = posX - i;
			int i1 = posY - j;
			int j1 = posZ - k;
			return System.Math.Sqrt(l * l + i1 * i1 + j1 * j1);
		}

		public virtual int CompareTo(object obj)
		{
			return CompareChunkCoordinate((net.minecraft.src.ChunkCoordinates)obj);
		}

		public int posX;

		public int posY;

		public int posZ;
	}
}
