// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Path
	{
		public Path(string field_22106_a)
		{
			// Referenced classes of package net.minecraft.src:
			//            PathPoint
			pathPoints = new net.minecraft.src.PathPoint[1024];
			count = 0;
		}

		public virtual net.minecraft.src.PathPoint AddPoint(net.minecraft.src.PathPoint pathpoint
			)
		{
			if (pathpoint.index >= 0)
			{
				throw new System.InvalidOperationException("OW KNOWS!");
			}
			if (count == pathPoints.Length)
			{
				net.minecraft.src.PathPoint[] apathpoint = new net.minecraft.src.PathPoint[count << 1];
				System.Array.Copy(pathPoints, 0, apathpoint, 0, count);
				pathPoints = apathpoint;
			}
			pathPoints[count] = pathpoint;
			pathpoint.index = count;
			SortBack(count++);
			return pathpoint;
		}

		public virtual void ClearPath()
		{
			count = 0;
		}

		public virtual net.minecraft.src.PathPoint Dequeue()
		{
			net.minecraft.src.PathPoint pathpoint = pathPoints[0];
			pathPoints[0] = pathPoints[--count];
			pathPoints[count] = null;
			if (count > 0)
			{
				SortForward(0);
			}
			pathpoint.index = -1;
			return pathpoint;
		}

		public virtual void ChangeDistance(net.minecraft.src.PathPoint pathpoint, float f
			)
		{
			float f1 = pathpoint.distanceToTarget;
			pathpoint.distanceToTarget = f;
			if (f < f1)
			{
				SortBack(pathpoint.index);
			}
			else
			{
				SortForward(pathpoint.index);
			}
		}

		private void SortBack(int i)
		{
			net.minecraft.src.PathPoint pathpoint = pathPoints[i];
			float f = pathpoint.distanceToTarget;
			do
			{
				if (i <= 0)
				{
					break;
				}
				int j = i - 1 >> 1;
				net.minecraft.src.PathPoint pathpoint1 = pathPoints[j];
				if (f >= pathpoint1.distanceToTarget)
				{
					break;
				}
				pathPoints[i] = pathpoint1;
				pathpoint1.index = i;
				i = j;
			}
			while (true);
			pathPoints[i] = pathpoint;
			pathpoint.index = i;
		}

		private void SortForward(int i)
		{
			net.minecraft.src.PathPoint pathpoint = pathPoints[i];
			float f = pathpoint.distanceToTarget;
			do
			{
				int j = 1 + (i << 1);
				int k = j + 1;
				if (j >= count)
				{
					break;
				}
				net.minecraft.src.PathPoint pathpoint1 = pathPoints[j];
				float f1 = pathpoint1.distanceToTarget;
				net.minecraft.src.PathPoint pathpoint2;
				float f2;
				if (k >= count)
				{
					pathpoint2 = null;
					f2 = (1.0F / 0.0F);
				}
				else
				{
					pathpoint2 = pathPoints[k];
					f2 = pathpoint2.distanceToTarget;
				}
				if (f1 < f2)
				{
					if (f1 >= f)
					{
						break;
					}
					pathPoints[i] = pathpoint1;
					pathpoint1.index = i;
					i = j;
					continue;
				}
				if (f2 >= f)
				{
					break;
				}
				pathPoints[i] = pathpoint2;
				pathpoint2.index = i;
				i = k;
			}
			while (true);
			pathPoints[i] = pathpoint;
			pathpoint.index = i;
		}

		public virtual bool IsPathEmpty()
		{
			return count == 0;
		}

		private net.minecraft.src.PathPoint[] pathPoints;

		private int count;
	}
}
