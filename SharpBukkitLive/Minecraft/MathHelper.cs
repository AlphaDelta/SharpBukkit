// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class MathHelper
	{
		public MathHelper()
		{
		}

		public static float Sin(float f)
		{
			return SIN_TABLE[(int)(f * 10430.38F) & unchecked((int)(0xffff))];
		}

		public static float Cos(float f)
		{
			return SIN_TABLE[(int)(f * 10430.38F + 16384F) & unchecked((int)(0xffff))];
		}

		public static float Sqrt_float(float f)
		{
			return (float)System.Math.Sqrt(f);
		}

		public static float Sqrt_double(double d)
		{
			return (float)System.Math.Sqrt(d);
		}

		public static int Floor_float(float f)
		{
			int i = (int)f;
			return f >= (float)i ? i : i - 1;
		}

		public static int Floor_double(double d)
		{
			int i = (int)d;
			return d >= (double)i ? i : i - 1;
		}

		public static float Abs(float f)
		{
			return f < 0.0F ? -f : f;
		}

		public static double Abs_max(double d, double d1)
		{
			if (d < 0.0D)
			{
				d = -d;
			}
			if (d1 < 0.0D)
			{
				d1 = -d1;
			}
			return d <= d1 ? d1 : d;
		}

		private static float[] SIN_TABLE;

		static MathHelper()
		{
			SIN_TABLE = new float[unchecked((int)(0x10000))];
			for (int i = 0; i < unchecked((int)(0x10000)); i++)
			{
				SIN_TABLE[i] = (float)System.Math.Sin(((double)i * 3.1415926535897931D * 2D) / 65536D
					);
			}
		}
	}
}
