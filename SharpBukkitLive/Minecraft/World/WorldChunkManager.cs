// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldChunkManager
	{
		protected internal WorldChunkManager()
		{
		}

		public WorldChunkManager(net.minecraft.src.World world)
		{
			// Referenced classes of package net.minecraft.src:
			//            NoiseGeneratorOctaves2, World, ChunkCoordIntPair, BiomeGenBase
			field_4255_e = new net.minecraft.src.NoiseGeneratorOctaves2(new SharpBukkitLive.SharpBukkit.SharpRandom(world.GetRandomSeed() * 9871L), 4);
			field_4254_f = new net.minecraft.src.NoiseGeneratorOctaves2(new SharpBukkitLive.SharpBukkit.SharpRandom(world.GetRandomSeed() * 39811L), 4);
			field_4253_g = new net.minecraft.src.NoiseGeneratorOctaves2(new SharpBukkitLive.SharpBukkit.SharpRandom(world.GetRandomSeed() * unchecked((long)(0x84a59L))), 2);
		}

		public virtual net.minecraft.src.BiomeGenBase Func_4066_a(net.minecraft.src.ChunkCoordIntPair
			 chunkcoordintpair)
		{
			return GetBiomeGenAt(chunkcoordintpair.X << 4, chunkcoordintpair.Z
				 << 4);
		}

		public virtual net.minecraft.src.BiomeGenBase GetBiomeGenAt(int i, int j)
		{
			return LoadBlockGeneratorData(i, j, 1, 1)[0];
		}

		public virtual net.minecraft.src.BiomeGenBase[] LoadBlockGeneratorData(int i, int j, int k, 
			int l)
		{
			field_4256_d = LoadBlockGeneratorData(field_4256_d, i, j, k, l);
			return field_4256_d;
		}

		public virtual double[] GetTemperatures(double[] ad, int i, int j, int k, int l)
		{
			if (ad == null || ad.Length < k * l)
			{
				ad = new double[k * l];
			}
			ad = field_4255_e.Func_4101_a(ad, i, j, k, l, 0.02500000037252903D, 0.02500000037252903D
				, 0.25D);
			field_4257_c = field_4253_g.Func_4101_a(field_4257_c, i, j, k, l, 0.25D, 0.25D, 0.58823529411764708D
				);
			int i1 = 0;
			for (int j1 = 0; j1 < k; j1++)
			{
				for (int k1 = 0; k1 < l; k1++)
				{
					double d = field_4257_c[i1] * 1.1000000000000001D + 0.5D;
					double d1 = 0.01D;
					double d2 = 1.0D - d1;
					double d3 = (ad[i1] * 0.14999999999999999D + 0.69999999999999996D) * d2 + d * d1;
					d3 = 1.0D - (1.0D - d3) * (1.0D - d3);
					if (d3 < 0.0D)
					{
						d3 = 0.0D;
					}
					if (d3 > 1.0D)
					{
						d3 = 1.0D;
					}
					ad[i1] = d3;
					i1++;
				}
			}
			return ad;
		}

		public virtual net.minecraft.src.BiomeGenBase[] LoadBlockGeneratorData(net.minecraft.src.BiomeGenBase
			[] abiomegenbase, int i, int j, int k, int l)
		{
			if (abiomegenbase == null || abiomegenbase.Length < k * l)
			{
				abiomegenbase = new net.minecraft.src.BiomeGenBase[k * l];
			}
			temperature = field_4255_e.Func_4101_a(temperature, i, j, k, k, 0.02500000037252903D, 0.02500000037252903D, 0.25D);
			humidity = field_4254_f.Func_4101_a(humidity, i, j, k, k, 0.05000000074505806D, 0.05000000074505806D, 0.33333333333333331D);
			field_4257_c = field_4253_g.Func_4101_a(field_4257_c, i, j, k, k, 0.25D, 0.25D, 0.58823529411764708D);
			int i1 = 0;
			for (int j1 = 0; j1 < k; j1++)
			{
				for (int k1 = 0; k1 < l; k1++)
				{
					double d = field_4257_c[i1] * 1.1000000000000001D + 0.5D;
					double d1 = 0.01D;
					double d2 = 1.0D - d1;
					double d3 = (temperature[i1] * 0.14999999999999999D + 0.69999999999999996D) * d2 
						+ d * d1;
					d1 = 0.002D;
					d2 = 1.0D - d1;
					double d4 = (humidity[i1] * 0.14999999999999999D + 0.5D) * d2 + d * d1;
					d3 = 1.0D - (1.0D - d3) * (1.0D - d3);
					if (d3 < 0.0D)
					{
						d3 = 0.0D;
					}
					if (d4 < 0.0D)
					{
						d4 = 0.0D;
					}
					if (d3 > 1.0D)
					{
						d3 = 1.0D;
					}
					if (d4 > 1.0D)
					{
						d4 = 1.0D;
					}
					temperature[i1] = d3;
					humidity[i1] = d4;
					abiomegenbase[i1++] = net.minecraft.src.BiomeGenBase.GetBiomeFromLookup(d3, d4);
				}
			}
			return abiomegenbase;
		}

		// CraftBukkit start
		public double getHumidity(int x, int z)
		{
			return this.field_4254_f.Func_4101_a(this.humidity, (double)x, (double)z, 1, 1, 0.05000000074505806D, 0.05000000074505806D, 0.3333333333333333D)[0];
		}
		// CraftBukkit end

		private net.minecraft.src.NoiseGeneratorOctaves2 field_4255_e;

		private net.minecraft.src.NoiseGeneratorOctaves2 field_4254_f;

		private net.minecraft.src.NoiseGeneratorOctaves2 field_4253_g;

		public double[] temperature;

		public double[] humidity;

		public double[] field_4257_c;

		public net.minecraft.src.BiomeGenBase[] field_4256_d;
	}
}
