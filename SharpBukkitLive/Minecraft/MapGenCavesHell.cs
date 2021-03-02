// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class MapGenCavesHell : net.minecraft.src.MapGenBase
	{
		public MapGenCavesHell()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            MapGenBase, MathHelper, Block, BlockGrass, 
		//            World
		protected internal virtual void Func_4106_a(int i, int j, byte[] abyte0, double d
			, double d1, double d2)
		{
			Func_4105_a(i, j, abyte0, d, d1, d2, 1.0F + rand.NextFloat() * 6F, 0.0F, 0.0F, -1
				, -1, 0.5D);
		}

		protected internal virtual void Func_4105_a(int i, int j, byte[] abyte0, double d
			, double d1, double d2, float f, float f1, float f2, int k, int l, double d3)
		{
			double d4 = i * 16 + 8;
			double d5 = j * 16 + 8;
			float f3 = 0.0F;
			float f4 = 0.0F;
			SharpBukkitLive.SharpBukkit.SharpRandom random = new SharpBukkitLive.SharpBukkit.SharpRandom(rand.NextLong());
			if (l <= 0)
			{
				int i1 = field_947_a * 16 - 16;
				l = i1 - random.Next(i1 / 4);
			}
			bool flag = false;
			if (k == -1)
			{
				k = l / 2;
				flag = true;
			}
			int j1 = random.Next(l / 2) + l / 4;
			bool flag1 = random.Next(6) == 0;
			for (; k < l; k++)
			{
				double d6 = 1.5D + (double)(net.minecraft.src.MathHelper.Sin(((float)k * 3.141593F
					) / (float)l) * f * 1.0F);
				double d7 = d6 * d3;
				float f5 = net.minecraft.src.MathHelper.Cos(f2);
				float f6 = net.minecraft.src.MathHelper.Sin(f2);
				d += net.minecraft.src.MathHelper.Cos(f1) * f5;
				d1 += f6;
				d2 += net.minecraft.src.MathHelper.Sin(f1) * f5;
				if (flag1)
				{
					f2 *= 0.92F;
				}
				else
				{
					f2 *= 0.7F;
				}
				f2 += f4 * 0.1F;
				f1 += f3 * 0.1F;
				f4 *= 0.9F;
				f3 *= 0.75F;
				f4 += (((float)random.NextDouble()) - ((float)random.NextDouble())) * ((float)random.NextDouble()) * 2.0F;
				f3 += (((float)random.NextDouble()) - ((float)random.NextDouble())) * ((float)random.NextDouble()) * 4F;
				if (!flag && k == j1 && f > 1.0F)
				{
					Func_4105_a(i, j, abyte0, d, d1, d2, ((float)random.NextDouble()) * 0.5F + 0.5F, f1 - 1.570796F
						, f2 / 3F, k, l, 1.0D);
					Func_4105_a(i, j, abyte0, d, d1, d2, ((float)random.NextDouble()) * 0.5F + 0.5F, f1 + 1.570796F
						, f2 / 3F, k, l, 1.0D);
					return;
				}
				if (!flag && random.Next(4) == 0)
				{
					continue;
				}
				double d8a = d - d4;
				double d9a = d2 - d5;
				double d10a = l - k;
				double d11 = f + 2.0F + 16F;
				if ((d8a * d8a + d9a * d9a) - d10a * d10a > d11 * d11)
				{
					return;
				}
				if (d < d4 - 16D - d6 * 2D || d2 < d5 - 16D - d6 * 2D || d > d4 + 16D + d6 * 2D ||
					 d2 > d5 + 16D + d6 * 2D)
				{
					continue;
				}
				int d8 = net.minecraft.src.MathHelper.Floor_double(d - d6) - i * 16 - 1;
				int k1 = (net.minecraft.src.MathHelper.Floor_double(d + d6) - i * 16) + 1;
				int d9 = net.minecraft.src.MathHelper.Floor_double(d1 - d7) - 1;
				int l1 = net.minecraft.src.MathHelper.Floor_double(d1 + d7) + 1;
				int d10 = net.minecraft.src.MathHelper.Floor_double(d2 - d6) - j * 16 - 1;
				int i2 = (net.minecraft.src.MathHelper.Floor_double(d2 + d6) - j * 16) + 1;
				if (d8 < 0)
				{
					d8 = 0;
				}
				if (k1 > 16)
				{
					k1 = 16;
				}
				if (d9 < 1)
				{
					d9 = 1;
				}
				if (l1 > 120)
				{
					l1 = 120;
				}
				if (d10 < 0)
				{
					d10 = 0;
				}
				if (i2 > 16)
				{
					i2 = 16;
				}
				bool flag2 = false;
				for (int j2 = d8; !flag2 && j2 < k1; j2++)
				{
					for (int l2 = d10; !flag2 && l2 < i2; l2++)
					{
						for (int i3 = l1 + 1; !flag2 && i3 >= d9 - 1; i3--)
						{
							int j3 = (j2 * 16 + l2) * 128 + i3;
							if (i3 < 0 || i3 >= 128)
							{
								continue;
							}
							if (abyte0[j3] == net.minecraft.src.Block.LAVA.ID || abyte0[j3] == net.minecraft.src.Block
								.STATIONARY_LAVA.ID)
							{
								flag2 = true;
							}
							if (i3 != d9 - 1 && j2 != d8 && j2 != k1 - 1 && l2 != d10 && l2 != i2 - 1)
							{
								i3 = d9;
							}
						}
					}
				}
				if (flag2)
				{
					continue;
				}
				for (int k2 = d8; k2 < k1; k2++)
				{
					double d12 = (((double)(k2 + i * 16) + 0.5D) - d) / d6;
					for (int k3 = d10; k3 < i2; k3++)
					{
						double d13 = (((double)(k3 + j * 16) + 0.5D) - d2) / d6;
						int l3 = (k2 * 16 + k3) * 128 + l1;
						for (int i4 = l1 - 1; i4 >= d9; i4--)
						{
							double d14 = (((double)i4 + 0.5D) - d1) / d7;
							if (d14 > -0.69999999999999996D && d12 * d12 + d14 * d14 + d13 * d13 < 1.0D)
							{
								byte byte0 = abyte0[l3];
								if (byte0 == net.minecraft.src.Block.NETHERRACK.ID || byte0 == net.minecraft.src.Block
									.DIRT.ID || byte0 == net.minecraft.src.Block.GRASS.ID)
								{
									abyte0[l3] = 0;
								}
							}
							l3--;
						}
					}
				}
				if (flag)
				{
					break;
				}
			}
		}

		protected internal override void Func_666_a(net.minecraft.src.World world, int i, 
			int j, int k, int l, byte[] abyte0)
		{
			int i1 = rand.Next(rand.Next(rand.Next(10) + 1) + 1);
			if (rand.Next(5) != 0)
			{
				i1 = 0;
			}
			for (int j1 = 0; j1 < i1; j1++)
			{
				double d = i * 16 + rand.Next(16);
				double d1 = rand.Next(128);
				double d2 = j * 16 + rand.Next(16);
				int k1 = 1;
				if (rand.Next(4) == 0)
				{
					Func_4106_a(k, l, abyte0, d, d1, d2);
					k1 += rand.Next(4);
				}
				for (int l1 = 0; l1 < k1; l1++)
				{
					float f = rand.NextFloat() * 3.141593F * 2.0F;
					float f1 = ((rand.NextFloat() - 0.5F) * 2.0F) / 8F;
					float f2 = rand.NextFloat() * 2.0F + rand.NextFloat();
					Func_4105_a(k, l, abyte0, d, d1, d2, f2 * 2.0F, f, f1, 0, 0, 0.5D);
				}
			}
		}
	}
}
