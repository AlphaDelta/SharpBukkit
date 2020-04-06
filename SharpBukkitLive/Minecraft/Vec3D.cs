// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Vec3D
	{
		// Referenced classes of package net.minecraft.src:
		//            MathHelper
		public static net.minecraft.src.Vec3D CreateVectorHelper(double d, double d1, double
			 d2)
		{
			return new net.minecraft.src.Vec3D(d, d1, d2);
		}

		public static void Initialize()
		{
			nextVector = 0;
		}

		public static net.minecraft.src.Vec3D CreateVector(double d, double d1, double d2
			)
		{
			if (nextVector >= vectorList.Count)
			{
				vectorList.Add(CreateVectorHelper(0.0D, 0.0D, 0.0D));
			}
			return ((net.minecraft.src.Vec3D)vectorList[nextVector++]).SetComponents(d, d1, d2
				);
		}

		private Vec3D(double d, double d1, double d2)
		{
			if (d == -0D)
			{
				d = 0.0D;
			}
			if (d1 == -0D)
			{
				d1 = 0.0D;
			}
			if (d2 == -0D)
			{
				d2 = 0.0D;
			}
			xCoord = d;
			yCoord = d1;
			zCoord = d2;
		}

		private net.minecraft.src.Vec3D SetComponents(double d, double d1, double d2)
		{
			xCoord = d;
			yCoord = d1;
			zCoord = d2;
			return this;
		}

		public virtual net.minecraft.src.Vec3D Normalize()
		{
			double d = net.minecraft.src.MathHelper.Sqrt_double(xCoord * xCoord + yCoord * yCoord
				 + zCoord * zCoord);
			if (d < 0.0001D)
			{
				return CreateVector(0.0D, 0.0D, 0.0D);
			}
			else
			{
				return CreateVector(xCoord / d, yCoord / d, zCoord / d);
			}
		}

		public virtual net.minecraft.src.Vec3D AddVector(double d, double d1, double d2)
		{
			return CreateVector(xCoord + d, yCoord + d1, zCoord + d2);
		}

		public virtual double DistanceTo(net.minecraft.src.Vec3D vec3d)
		{
			double d = vec3d.xCoord - xCoord;
			double d1 = vec3d.yCoord - yCoord;
			double d2 = vec3d.zCoord - zCoord;
			return (double)net.minecraft.src.MathHelper.Sqrt_double(d * d + d1 * d1 + d2 * d2
				);
		}

		public virtual double SquareDistanceTo(net.minecraft.src.Vec3D vec3d)
		{
			double d = vec3d.xCoord - xCoord;
			double d1 = vec3d.yCoord - yCoord;
			double d2 = vec3d.zCoord - zCoord;
			return d * d + d1 * d1 + d2 * d2;
		}

		public virtual double SquareDistanceTo(double d, double d1, double d2)
		{
			double d3 = d - xCoord;
			double d4 = d1 - yCoord;
			double d5 = d2 - zCoord;
			return d3 * d3 + d4 * d4 + d5 * d5;
		}

		public virtual double LengthVector()
		{
			return (double)net.minecraft.src.MathHelper.Sqrt_double(xCoord * xCoord + yCoord 
				* yCoord + zCoord * zCoord);
		}

		public virtual net.minecraft.src.Vec3D GetIntermediateWithXValue(net.minecraft.src.Vec3D
			 vec3d, double d)
		{
			double d1 = vec3d.xCoord - xCoord;
			double d2 = vec3d.yCoord - yCoord;
			double d3 = vec3d.zCoord - zCoord;
			if (d1 * d1 < 1.0000000116860974E-007D)
			{
				return null;
			}
			double d4 = (d - xCoord) / d1;
			if (d4 < 0.0D || d4 > 1.0D)
			{
				return null;
			}
			else
			{
				return CreateVector(xCoord + d1 * d4, yCoord + d2 * d4, zCoord + d3 * d4);
			}
		}

		public virtual net.minecraft.src.Vec3D GetIntermediateWithYValue(net.minecraft.src.Vec3D
			 vec3d, double d)
		{
			double d1 = vec3d.xCoord - xCoord;
			double d2 = vec3d.yCoord - yCoord;
			double d3 = vec3d.zCoord - zCoord;
			if (d2 * d2 < 1.0000000116860974E-007D)
			{
				return null;
			}
			double d4 = (d - yCoord) / d2;
			if (d4 < 0.0D || d4 > 1.0D)
			{
				return null;
			}
			else
			{
				return CreateVector(xCoord + d1 * d4, yCoord + d2 * d4, zCoord + d3 * d4);
			}
		}

		public virtual net.minecraft.src.Vec3D GetIntermediateWithZValue(net.minecraft.src.Vec3D
			 vec3d, double d)
		{
			double d1 = vec3d.xCoord - xCoord;
			double d2 = vec3d.yCoord - yCoord;
			double d3 = vec3d.zCoord - zCoord;
			if (d3 * d3 < 1.0000000116860974E-007D)
			{
				return null;
			}
			double d4 = (d - zCoord) / d3;
			if (d4 < 0.0D || d4 > 1.0D)
			{
				return null;
			}
			else
			{
				return CreateVector(xCoord + d1 * d4, yCoord + d2 * d4, zCoord + d3 * d4);
			}
		}

		public override string ToString()
		{
			return (new java.lang.StringBuilder()).Append("(").Append(xCoord).Append(", ").Append
				(yCoord).Append(", ").Append(zCoord).Append(")").ToString();
		}

		private static System.Collections.IList vectorList = new System.Collections.ArrayList
			();

		private static int nextVector = 0;

		public double xCoord;

		public double yCoord;

		public double zCoord;
	}
}
