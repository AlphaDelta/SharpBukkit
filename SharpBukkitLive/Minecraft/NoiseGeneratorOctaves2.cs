// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class NoiseGeneratorOctaves2 : net.minecraft.src.NoiseGenerator
	{
		public NoiseGeneratorOctaves2(SharpBukkitLive.SharpBukkit.SharpRandom random, int i)
		{
			// Referenced classes of package net.minecraft.src:
			//            NoiseGenerator, NoiseGenerator2
			field_4307_b = i;
			field_4308_a = new net.minecraft.src.NoiseGenerator2[i];
			for (int j = 0; j < i; j++)
			{
				field_4308_a[j] = new net.minecraft.src.NoiseGenerator2(random);
			}
		}

		public virtual double[] Func_4101_a(double[] ad, double d, double d1, int i, int 
			j, double d2, double d3, double d4)
		{
			return Func_4100_a(ad, d, d1, i, j, d2, d3, d4, 0.5D);
		}

		public virtual double[] Func_4100_a(double[] ad, double d, double d1, int i, int 
			j, double d2, double d3, double d4, double d5)
		{
			d2 /= 1.5D;
			d3 /= 1.5D;
			if (ad == null || ad.Length < i * j)
			{
				ad = new double[i * j];
			}
			else
			{
				for (int k = 0; k < ad.Length; k++)
				{
					ad[k] = 0.0D;
				}
			}
			double d6 = 1.0D;
			double d7 = 1.0D;
			for (int l = 0; l < field_4307_b; l++)
			{
				field_4308_a[l].Func_4115_a(ad, d, d1, i, j, d2 * d7, d3 * d7, 0.55000000000000004D
					 / d6);
				d7 *= d4;
				d6 *= d5;
			}
			return ad;
		}

		private net.minecraft.src.NoiseGenerator2[] field_4308_a;

		private int field_4307_b;
	}
}
