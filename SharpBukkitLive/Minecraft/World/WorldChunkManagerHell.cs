// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldChunkManagerHell : net.minecraft.src.WorldChunkManager
	{
		public WorldChunkManagerHell(net.minecraft.src.BiomeGenBase biomegenbase, double 
			d, double d1)
		{
			// Referenced classes of package net.minecraft.src:
			//            WorldChunkManager, BiomeGenBase, ChunkCoordIntPair
			field_4262_e = biomegenbase;
			field_4261_f = d;
			field_4260_g = d1;
		}

		public override net.minecraft.src.BiomeGenBase Func_4066_a(net.minecraft.src.ChunkCoordIntPair
			 chunkcoordintpair)
		{
			return field_4262_e;
		}

		public override net.minecraft.src.BiomeGenBase GetBiomeGenAt(int i, int j)
		{
			return field_4262_e;
		}

		public override net.minecraft.src.BiomeGenBase[] Func_4065_a(int i, int j, int k, 
			int l)
		{
			field_4256_d = LoadBlockGeneratorData(field_4256_d, i, j, k, l);
			return field_4256_d;
		}

		public override double[] GetTemperatures(double[] ad, int i, int j, int k, int l)
		{
			if (ad == null || ad.Length < k * l)
			{
				ad = new double[k * l];
			}
			SharpBukkitLive.SharpBukkit.SharpUtils.ArrayFill(ad, 0, k * l, field_4261_f);
			return ad;
		}

		public override net.minecraft.src.BiomeGenBase[] LoadBlockGeneratorData(net.minecraft.src.BiomeGenBase
			[] abiomegenbase, int i, int j, int k, int l)
		{
			if (abiomegenbase == null || abiomegenbase.Length < k * l)
			{
				abiomegenbase = new net.minecraft.src.BiomeGenBase[k * l];
			}
			if (temperature == null || temperature.Length < k * l)
			{
				temperature = new double[k * l];
				humidity = new double[k * l];
			}
			SharpBukkitLive.SharpBukkit.SharpUtils.ArrayFill(abiomegenbase, 0, k * l, field_4262_e);
			SharpBukkitLive.SharpBukkit.SharpUtils.ArrayFill(humidity, 0, k * l, field_4260_g);
			SharpBukkitLive.SharpBukkit.SharpUtils.ArrayFill(temperature, 0, k * l, field_4261_f);
			return abiomegenbase;
		}

		private net.minecraft.src.BiomeGenBase field_4262_e;

		private double field_4261_f;

		private double field_4260_g;
	}
}
