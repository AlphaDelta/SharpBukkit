// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldGenBigTree : net.minecraft.src.WorldGenerator
	{
		public WorldGenBigTree()
		{
			// Referenced classes of package net.minecraft.src:
			//            WorldGenerator, MathHelper, World
			random0 = new SharpBukkitLive.SharpBukkit.SharpRandom();
			field_756_e = 0;
			field_754_g = 0.61799999999999999D;
			field_753_h = 1.0D;
			field_752_i = 0.38100000000000001D;
			field_751_j = 1.0D;
			field_750_k = 1.0D;
			field_749_l = 1;
			field_748_m = 12;
			field_747_n = 4;
		}

		internal virtual void Func_424_a()
		{
			height = (int)((double)field_756_e * field_754_g);
			if (height >= field_756_e)
			{
				height = field_756_e - 1;
			}
			int i = (int)(1.3819999999999999D + System.Math.Pow((field_750_k * (double)field_756_e
				) / 13D, 2D));
			if (i < 1)
			{
				i = 1;
			}
			int[][] ai = new int[i * field_756_e][];
			for (int aii = 0; aii < ai.Length; aii++) ai[aii] = new int[4];
			int j = (basePos[1] + field_756_e) - field_747_n;
			int k = 1;
			int l = basePos[1] + height;
			int i1 = j - basePos[1];
			ai[0][0] = basePos[0];
			ai[0][1] = j;
			ai[0][2] = basePos[2];
			ai[0][3] = l;
			j--;
			while (i1 >= 0)
			{
				int j1 = 0;
				float f = Func_431_a(i1);
				if (f < 0.0F)
				{
					j--;
					i1--;
				}
				else
				{
					double d = 0.5D;
					for (; j1 < i; j1++)
					{
						double d1 = field_751_j * ((double)f * ((double)random0.NextFloat() + 0.32800000000000001D
							));
						double d2 = (double)random0.NextFloat() * 2D * 3.1415899999999999D;
						int k1 = net.minecraft.src.MathHelper.Floor_double(d1 * System.Math.Sin(d2) + (double
							)basePos[0] + d);
						int l1 = net.minecraft.src.MathHelper.Floor_double(d1 * System.Math.Cos(d2) + (double
							)basePos[2] + d);
						int[] ai1 = new int[] { k1, j, l1 };
						int[] ai2 = new int[] { k1, j + field_747_n, l1 };
						if (Func_427_a(ai1, ai2) != -1)
						{
							continue;
						}
						int[] ai3 = new int[] { basePos[0], basePos[1], basePos[2] };
						double d3 = System.Math.Sqrt(System.Math.Pow(System.Math.Abs(basePos[0] - ai1[0])
							, 2D) + System.Math.Pow(System.Math.Abs(basePos[2] - ai1[2]), 2D));
						double d4 = d3 * field_752_i;
						if ((double)ai1[1] - d4 > (double)l)
						{
							ai3[1] = l;
						}
						else
						{
							ai3[1] = (int)((double)ai1[1] - d4);
						}
						if (Func_427_a(ai3, ai1) == -1)
						{
							ai[k][0] = k1;
							ai[k][1] = j;
							ai[k][2] = l1;
							ai[k][3] = ai3[1];
							k++;
						}
					}
					j--;
					i1--;
				}
			}
			field_746_o = new int[k][];
			for (int aii = 0; aii < k; aii++) field_746_o[aii] = new int[4];
			System.Array.Copy(ai, 0, field_746_o, 0, k);
		}

		internal virtual void Func_426_a(int i, int j, int k, float f, byte byte0, int l)
		{
			int i1 = (int)((double)f + 0.61799999999999999D);
			byte byte1 = field_760_a[byte0];
			byte byte2 = field_760_a[byte0 + 3];
			int[] ai = new int[] { i, j, k };
			int[] ai1 = new int[] { 0, 0, 0 };
			int j1 = -i1;
			int k1 = -i1;
			ai1[byte0] = ai[byte0];
			for (; j1 <= i1; j1++)
			{
				ai1[byte1] = ai[byte1] + j1;
				for (int l1 = -i1; l1 <= i1; )
				{
					double d = System.Math.Sqrt(System.Math.Pow((double)System.Math.Abs(j1) + 0.5D, 2D
						) + System.Math.Pow((double)System.Math.Abs(l1) + 0.5D, 2D));
					if (d > (double)f)
					{
						l1++;
					}
					else
					{
						ai1[byte2] = ai[byte2] + l1;
						int i2 = worldObj.GetBlockId(ai1[0], ai1[1], ai1[2]);
						if (i2 != 0 && i2 != 18)
						{
							l1++;
						}
						else
						{
							worldObj.SetBlock(ai1[0], ai1[1], ai1[2], l);
							l1++;
						}
					}
				}
			}
		}

		internal virtual float Func_431_a(int i)
		{
			if ((double)i < (double)(float)field_756_e * 0.29999999999999999D)
			{
				return -1.618F;
			}
			float f = (float)field_756_e / 2.0F;
			float f1 = (float)field_756_e / 2.0F - (float)i;
			float f2;
			if (f1 == 0.0F)
			{
				f2 = f;
			}
			else
			{
				if (System.Math.Abs(f1) >= f)
				{
					f2 = 0.0F;
				}
				else
				{
					f2 = (float)System.Math.Sqrt(System.Math.Pow(System.Math.Abs(f), 2D) - System.Math
						.Pow(System.Math.Abs(f1), 2D));
				}
			}
			f2 *= 0.5F;
			return f2;
		}

		internal virtual float Func_429_b(int i)
		{
			if (i < 0 || i >= field_747_n)
			{
				return -1F;
			}
			return i != 0 && i != field_747_n - 1 ? 3F : 2.0F;
		}

		internal virtual void Func_423_a(int i, int j, int k)
		{
			int l = j;
			for (int i1 = j + field_747_n; l < i1; l++)
			{
				float f = Func_429_b(l - j);
				Func_426_a(i, l, k, f, unchecked((byte)1), 18);
			}
		}

		internal virtual void Func_425_a(int[] ai, int[] ai1, int i)
		{
			int[] ai2 = new int[] { 0, 0, 0 };
			byte byte0 = 0;
			int j = 0;
			for (; ((sbyte)byte0) < 3; byte0++)
			{
				ai2[byte0] = ai1[byte0] - ai[byte0];
				if (System.Math.Abs(ai2[byte0]) > System.Math.Abs(ai2[j]))
				{
					j = byte0;
				}
			}
			if (ai2[j] == 0)
			{
				return;
			}
			byte byte1 = field_760_a[j];
			byte byte2 = field_760_a[j + 3];
			byte byte3;
			if (ai2[j] > 0)
			{
				byte3 = 1;
			}
			else
			{
				byte3 = unchecked((byte)(-1));
			}
			double d = (double)ai2[byte1] / (double)ai2[j];
			double d1 = (double)ai2[byte2] / (double)ai2[j];
			int[] ai3 = new int[] { 0, 0, 0 };
			int k = 0;
			for (int l = ai2[j] + byte3; k != l; k += byte3)
			{
				ai3[j] = net.minecraft.src.MathHelper.Floor_double((double)(ai[j] + k) + 0.5D);
				ai3[byte1] = net.minecraft.src.MathHelper.Floor_double((double)ai[byte1] + (double
					)k * d + 0.5D);
				ai3[byte2] = net.minecraft.src.MathHelper.Floor_double((double)ai[byte2] + (double
					)k * d1 + 0.5D);
				worldObj.SetBlock(ai3[0], ai3[1], ai3[2], i);
			}
		}

		internal virtual void Func_421_b()
		{
			int i = 0;
			for (int j = field_746_o.Length; i < j; i++)
			{
				int k = field_746_o[i][0];
				int l = field_746_o[i][1];
				int i1 = field_746_o[i][2];
				Func_423_a(k, l, i1);
			}
		}

		internal virtual bool Func_430_c(int i)
		{
			return (double)i >= (double)field_756_e * 0.20000000000000001D;
		}

		internal virtual void Func_432_c()
		{
			int i = basePos[0];
			int j = basePos[1];
			int k = basePos[1] + height;
			int l = basePos[2];
			int[] ai = new int[] { i, j, l };
			int[] ai1 = new int[] { i, k, l };
			Func_425_a(ai, ai1, 17);
			if (field_749_l == 2)
			{
				ai[0]++;
				ai1[0]++;
				Func_425_a(ai, ai1, 17);
				ai[2]++;
				ai1[2]++;
				Func_425_a(ai, ai1, 17);
				ai[0]--;
				ai1[0]--;
				Func_425_a(ai, ai1, 17);
			}
		}

		internal virtual void Func_428_d()
		{
			int i = 0;
			int j = field_746_o.Length;
			int[] ai = new int[] { basePos[0], basePos[1], basePos[2] };
			for (; i < j; i++)
			{
				int[] ai1 = field_746_o[i];
				int[] ai2 = new int[] { ai1[0], ai1[1], ai1[2] };
				ai[1] = ai1[3];
				int k = ai[1] - basePos[1];
				if (Func_430_c(k))
				{
					Func_425_a(ai, ai2, 17);
				}
			}
		}

		internal virtual int Func_427_a(int[] ai, int[] ai1)
		{
			int[] ai2 = new int[] { 0, 0, 0 };
			byte byte0 = 0;
			int i = 0;
			for (; ((sbyte)byte0) < 3; byte0++)
			{
				ai2[byte0] = ai1[byte0] - ai[byte0];
				if (System.Math.Abs(ai2[byte0]) > System.Math.Abs(ai2[i]))
				{
					i = byte0;
				}
			}
			if (ai2[i] == 0)
			{
				return -1;
			}
			byte byte1 = field_760_a[i];
			byte byte2 = field_760_a[i + 3];
			byte byte3;
			if (ai2[i] > 0)
			{
				byte3 = 1;
			}
			else
			{
				byte3 = unchecked((byte)(-1));
			}
			double d = (double)ai2[byte1] / (double)ai2[i];
			double d1 = (double)ai2[byte2] / (double)ai2[i];
			int[] ai3 = new int[] { 0, 0, 0 };
			int j = 0;
			int k = ai2[i] + byte3;
			//TODO: FIX
			//do
			//{
			//	if (j == k)
			//	{
			//		break;
			//	}
			//	ai3[i] = ai[i] + j;
			//	ai3[byte1] = net.minecraft.src.MathHelper.Floor_double((double)ai[byte1] + (double
			//		)j * d);
			//	ai3[byte2] = net.minecraft.src.MathHelper.Floor_double((double)ai[byte2] + (double
			//		)j * d1);
			//	int l = worldObj.GetBlockId(ai3[0], ai3[1], ai3[2]);
			//	if (l != 0 && l != 18)
			//	{
			//		break;
			//	}
			//	j += byte3;
			//}
			//while (true);
			if (j == k)
			{
				return -1;
			}
			else
			{
				return System.Math.Abs(j);
			}
		}

		internal virtual bool Func_422_e()
		{
			int[] ai = new int[] { basePos[0], basePos[1], basePos[2] };
			int[] ai1 = new int[] { basePos[0], (basePos[1] + field_756_e) - 1, basePos[2] };
			int i = worldObj.GetBlockId(basePos[0], basePos[1] - 1, basePos[2]);
			if (i != 2 && i != 3)
			{
				return false;
			}
			int j = Func_427_a(ai, ai1);
			if (j == -1)
			{
				return true;
			}
			if (j < 6)
			{
				return false;
			}
			else
			{
				field_756_e = j;
				return true;
			}
		}

		public override void Func_420_a(double d, double d1, double d2)
		{
			field_748_m = (int)(d * 12D);
			if (d > 0.5D)
			{
				field_747_n = 5;
			}
			field_751_j = d1;
			field_750_k = d2;
		}

		public override bool Generate(net.minecraft.src.World world, SharpBukkitLive.SharpBukkit.SharpRandom random
			, int i, int j, int k)
		{
			worldObj = world;
			long l = random.NextLong();
			random0.SetSeed(l);
			basePos[0] = i;
			basePos[1] = j;
			basePos[2] = k;
			if (field_756_e == 0)
			{
				field_756_e = 5 + random0.NextInt(field_748_m);
			}
			if (!Func_422_e())
			{
				return false;
			}
			else
			{
				Func_424_a();
				Func_421_b();
				Func_432_c();
				Func_428_d();
				return true;
			}
		}

		internal static readonly byte[] field_760_a = new byte[] { 2, 0, 0, 1, 2, 1 };

		internal SharpBukkitLive.SharpBukkit.SharpRandom random0;

		internal net.minecraft.src.World worldObj;

		internal int[] basePos = new int[] { 0, 0, 0 };

		internal int field_756_e;

		internal int height;

		internal double field_754_g;

		internal double field_753_h;

		internal double field_752_i;

		internal double field_751_j;

		internal double field_750_k;

		internal int field_749_l;

		internal int field_748_m;

		internal int field_747_n;

		internal int[][] field_746_o;
	}
}
