// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class PathEntity
	{
		public PathEntity(net.minecraft.src.PathPoint[] apathpoint)
		{
			// Referenced classes of package net.minecraft.src:
			//            PathPoint, Entity, Vec3D
			points = apathpoint;
			pathLength = apathpoint.Length;
		}

		public virtual void IncrementPathIndex()
		{
			pathIndex++;
		}

		public virtual bool IsFinished()
		{
			return pathIndex >= points.Length;
		}

		public virtual net.minecraft.src.PathPoint Func_22211_c()
		{
			if (pathLength > 0)
			{
				return points[pathLength - 1];
			}
			else
			{
				return null;
			}
		}

		public virtual net.minecraft.src.Vec3D GetPosition(net.minecraft.src.Entity entity
			)
		{
			double d = (double)points[pathIndex].xCoord + (double)(int)(entity.width + 1.0F) 
				* 0.5D;
			double d1 = points[pathIndex].yCoord;
			double d2 = (double)points[pathIndex].zCoord + (double)(int)(entity.width + 1.0F)
				 * 0.5D;
			return net.minecraft.src.Vec3D.CreateVector(d, d1, d2);
		}

		private readonly net.minecraft.src.PathPoint[] points;

		public readonly int pathLength;

		private int pathIndex;
	}
}
