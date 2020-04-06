// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ChunkProviderGenerate : net.minecraft.src.IChunkProvider
	{
		public ChunkProviderGenerate(net.minecraft.src.World world, long l)
		{
			// Referenced classes of package net.minecraft.src:
			//            IChunkProvider, MapGenCaves, NoiseGeneratorOctaves, Block, 
			//            BiomeGenBase, Chunk, World, WorldChunkManager, 
			//            MapGenBase, BlockSand, WorldGenLakes, WorldGenDungeons, 
			//            WorldGenClay, WorldGenMinable, WorldGenerator, WorldGenFlowers, 
			//            BlockFlower, WorldGenTallGrass, BlockTallGrass, WorldGenDeadBush, 
			//            BlockDeadBush, WorldGenReed, WorldGenPumpkin, WorldGenCactus, 
			//            WorldGenLiquids, Material, IProgressUpdate
			sandNoise = new double[256];
			gravelNoise = new double[256];
			stoneNoise = new double[256];
			field_695_u = new net.minecraft.src.MapGenCaves();
			field_707_i = new int[][] { new int[32], new int[32], new int[32], new int[32], new 
				int[32], new int[32], new int[32], new int[32], new int[32], new int[32], new int
				[32], new int[32], new int[32], new int[32], new int[32], new int[32], new int[32
				], new int[32], new int[32], new int[32], new int[32], new int[32], new int[32], 
				new int[32], new int[32], new int[32], new int[32], new int[32], new int[32], new 
				int[32], new int[32], new int[32] };
			worldObj = world;
			rand = new SharpBukkitLive.SharpBukkit.SharpRandom(l);
			field_705_k = new net.minecraft.src.NoiseGeneratorOctaves(rand, 16);
			field_704_l = new net.minecraft.src.NoiseGeneratorOctaves(rand, 16);
			field_703_m = new net.minecraft.src.NoiseGeneratorOctaves(rand, 8);
			field_702_n = new net.minecraft.src.NoiseGeneratorOctaves(rand, 4);
			field_701_o = new net.minecraft.src.NoiseGeneratorOctaves(rand, 4);
			field_715_a = new net.minecraft.src.NoiseGeneratorOctaves(rand, 10);
			field_714_b = new net.minecraft.src.NoiseGeneratorOctaves(rand, 16);
			mobSpawnerNoise = new net.minecraft.src.NoiseGeneratorOctaves(rand, 8);
		}

		public virtual void GenerateTerrain(int i, int j, byte[] abyte0, net.minecraft.src.BiomeGenBase
			[] abiomegenbase, double[] ad)
		{
			byte byte0 = 4;
			byte byte1 = 64;
			int k = byte0 + 1;
			byte byte2 = 17;
			int l = byte0 + 1;
			field_4224_q = Func_4058_a(field_4224_q, i * byte0, 0, j * byte0, k, byte2, l);
			for (int i1 = 0; i1 < byte0; i1++)
			{
				for (int j1 = 0; j1 < byte0; j1++)
				{
					for (int k1 = 0; k1 < 16; k1++)
					{
						double d = 0.125D;
						double d1 = field_4224_q[((i1 + 0) * l + (j1 + 0)) * byte2 + (k1 + 0)];
						double d2 = field_4224_q[((i1 + 0) * l + (j1 + 1)) * byte2 + (k1 + 0)];
						double d3 = field_4224_q[((i1 + 1) * l + (j1 + 0)) * byte2 + (k1 + 0)];
						double d4 = field_4224_q[((i1 + 1) * l + (j1 + 1)) * byte2 + (k1 + 0)];
						double d5 = (field_4224_q[((i1 + 0) * l + (j1 + 0)) * byte2 + (k1 + 1)] - d1) * d;
						double d6 = (field_4224_q[((i1 + 0) * l + (j1 + 1)) * byte2 + (k1 + 1)] - d2) * d;
						double d7 = (field_4224_q[((i1 + 1) * l + (j1 + 0)) * byte2 + (k1 + 1)] - d3) * d;
						double d8 = (field_4224_q[((i1 + 1) * l + (j1 + 1)) * byte2 + (k1 + 1)] - d4) * d;
						for (int l1 = 0; l1 < 8; l1++)
						{
							double d9 = 0.25D;
							double d10 = d1;
							double d11 = d2;
							double d12 = (d3 - d1) * d9;
							double d13 = (d4 - d2) * d9;
							for (int i2 = 0; i2 < 4; i2++)
							{
								int j2 = i2 + i1 * 4 << 11 | 0 + j1 * 4 << 7 | k1 * 8 + l1;
								short c = 128;// '\200';
								double d14 = 0.25D;
								double d15 = d10;
								double d16 = (d11 - d10) * d14;
								for (int k2 = 0; k2 < 4; k2++)
								{
									double d17 = ad[(i1 * 4 + i2) * 16 + (j1 * 4 + k2)];
									int l2 = 0;
									if (k1 * 8 + l1 < byte1)
									{
										if (d17 < 0.5D && k1 * 8 + l1 >= byte1 - 1)
										{
											l2 = net.minecraft.src.Block.ice.blockID;
										}
										else
										{
											l2 = net.minecraft.src.Block.waterStill.blockID;
										}
									}
									if (d15 > 0.0D)
									{
										l2 = net.minecraft.src.Block.stone.blockID;
									}
									abyte0[j2] = unchecked((byte)l2);
									j2 += c;
									d15 += d16;
								}
								d10 += d12;
								d11 += d13;
							}
							d1 += d5;
							d2 += d6;
							d3 += d7;
							d4 += d8;
						}
					}
				}
			}
		}

		public virtual void ReplaceBlocksForBiome(int i, int j, byte[] abyte0, net.minecraft.src.BiomeGenBase
			[] abiomegenbase)
		{
			byte byte0 = 64;
			double d = 0.03125D;
			sandNoise = field_702_n.GenerateNoiseOctaves(sandNoise, i * 16, j * 16, 0.0D, 16, 
				16, 1, d, d, 1.0D);
			gravelNoise = field_702_n.GenerateNoiseOctaves(gravelNoise, i * 16, 109.0134D, j 
				* 16, 16, 1, 16, d, 1.0D, d);
			stoneNoise = field_701_o.GenerateNoiseOctaves(stoneNoise, i * 16, j * 16, 0.0D, 16
				, 16, 1, d * 2D, d * 2D, d * 2D);
			for (int k = 0; k < 16; k++)
			{
				for (int l = 0; l < 16; l++)
				{
					net.minecraft.src.BiomeGenBase biomegenbase = abiomegenbase[k + l * 16];
					bool flag = sandNoise[k + l * 16] + rand.NextDouble() * 0.20000000000000001D > 0.0D;
					bool flag1 = gravelNoise[k + l * 16] + rand.NextDouble() * 0.20000000000000001D >
						 3D;
					int i1 = (int)(stoneNoise[k + l * 16] / 3D + 3D + rand.NextDouble() * 0.25D);
					int j1 = -1;
					byte byte1 = biomegenbase.topBlock;
					byte byte2 = biomegenbase.fillerBlock;
					for (int k1 = 127; k1 >= 0; k1--)
					{
						int l1 = (l * 16 + k) * 128 + k1;
						if (k1 <= 0 + rand.Next(5))
						{
							abyte0[l1] = unchecked((byte)net.minecraft.src.Block.bedrock.blockID);
							continue;
						}
						byte byte3 = abyte0[l1];
						if (byte3 == 0)
						{
							j1 = -1;
							continue;
						}
						if (byte3 != net.minecraft.src.Block.stone.blockID)
						{
							continue;
						}
						if (j1 == -1)
						{
							if (i1 <= 0)
							{
								byte1 = 0;
								byte2 = unchecked((byte)net.minecraft.src.Block.stone.blockID);
							}
							else
							{
								if (k1 >= byte0 - 4 && k1 <= byte0 + 1)
								{
									byte1 = biomegenbase.topBlock;
									byte2 = biomegenbase.fillerBlock;
									if (flag1)
									{
										byte1 = 0;
									}
									if (flag1)
									{
										byte2 = unchecked((byte)net.minecraft.src.Block.gravel.blockID);
									}
									if (flag)
									{
										byte1 = unchecked((byte)net.minecraft.src.Block.sand.blockID);
									}
									if (flag)
									{
										byte2 = unchecked((byte)net.minecraft.src.Block.sand.blockID);
									}
								}
							}
							if (k1 < byte0 && byte1 == 0)
							{
								byte1 = unchecked((byte)net.minecraft.src.Block.waterStill.blockID);
							}
							j1 = i1;
							if (k1 >= byte0 - 1)
							{
								abyte0[l1] = byte1;
							}
							else
							{
								abyte0[l1] = byte2;
							}
							continue;
						}
						if (j1 <= 0)
						{
							continue;
						}
						j1--;
						abyte0[l1] = byte2;
						if (j1 == 0 && byte2 == net.minecraft.src.Block.sand.blockID)
						{
							j1 = rand.Next(4);
							byte2 = unchecked((byte)net.minecraft.src.Block.sandStone.blockID);
						}
					}
				}
			}
		}

		public virtual net.minecraft.src.Chunk LoadChunk(int i, int j)
		{
			return ProvideChunk(i, j);
		}

		public virtual net.minecraft.src.Chunk ProvideChunk(int i, int j)
		{
			rand.SetSeed((long)i * unchecked((long)(0x4f9939f508L)) + (long)j * unchecked((long
				)(0x1ef1565bd5L)));
			byte[] abyte0 = new byte[32768];
			net.minecraft.src.Chunk chunk = new net.minecraft.src.Chunk(worldObj, abyte0, i, 
				j);
			biomesForGeneration = worldObj.GetWorldChunkManager().LoadBlockGeneratorData(biomesForGeneration
				, i * 16, j * 16, 16, 16);
			double[] ad = worldObj.GetWorldChunkManager().temperature;
			GenerateTerrain(i, j, abyte0, biomesForGeneration, ad);
			ReplaceBlocksForBiome(i, j, abyte0, biomesForGeneration);
			field_695_u.Func_667_a(this, worldObj, i, j, abyte0);
			chunk.Func_353_b();
			return chunk;
		}

		private double[] Func_4058_a(double[] ad, int i, int j, int k, int l, int i1, int
			 j1)
		{
			if (ad == null)
			{
				ad = new double[l * i1 * j1];
			}
			double d = 684.41200000000003D;
			double d1 = 684.41200000000003D;
			double[] ad1 = worldObj.GetWorldChunkManager().temperature;
			double[] ad2 = worldObj.GetWorldChunkManager().humidity;
			field_4226_g = field_715_a.Func_4103_a(field_4226_g, i, k, l, j1, 1.121D, 1.121D, 
				0.5D);
			field_4225_h = field_714_b.Func_4103_a(field_4225_h, i, k, l, j1, 200D, 200D, 0.5D
				);
			field_4229_d = field_703_m.GenerateNoiseOctaves(field_4229_d, i, j, k, l, i1, j1, 
				d / 80D, d1 / 160D, d / 80D);
			field_4228_e = field_705_k.GenerateNoiseOctaves(field_4228_e, i, j, k, l, i1, j1, 
				d, d1, d);
			field_4227_f = field_704_l.GenerateNoiseOctaves(field_4227_f, i, j, k, l, i1, j1, 
				d, d1, d);
			int k1 = 0;
			int l1 = 0;
			int i2 = 16 / l;
			for (int j2 = 0; j2 < l; j2++)
			{
				int k2 = j2 * i2 + i2 / 2;
				for (int l2 = 0; l2 < j1; l2++)
				{
					int i3 = l2 * i2 + i2 / 2;
					double d2 = ad1[k2 * 16 + i3];
					double d3 = ad2[k2 * 16 + i3] * d2;
					double d4 = 1.0D - d3;
					d4 *= d4;
					d4 *= d4;
					d4 = 1.0D - d4;
					double d5 = (field_4226_g[l1] + 256D) / 512D;
					d5 *= d4;
					if (d5 > 1.0D)
					{
						d5 = 1.0D;
					}
					double d6 = field_4225_h[l1] / 8000D;
					if (d6 < 0.0D)
					{
						d6 = -d6 * 0.29999999999999999D;
					}
					d6 = d6 * 3D - 2D;
					if (d6 < 0.0D)
					{
						d6 /= 2D;
						if (d6 < -1D)
						{
							d6 = -1D;
						}
						d6 /= 1.3999999999999999D;
						d6 /= 2D;
						d5 = 0.0D;
					}
					else
					{
						if (d6 > 1.0D)
						{
							d6 = 1.0D;
						}
						d6 /= 8D;
					}
					if (d5 < 0.0D)
					{
						d5 = 0.0D;
					}
					d5 += 0.5D;
					d6 = (d6 * (double)i1) / 16D;
					double d7 = (double)i1 / 2D + d6 * 4D;
					l1++;
					for (int j3 = 0; j3 < i1; j3++)
					{
						double d8 = 0.0D;
						double d9 = (((double)j3 - d7) * 12D) / d5;
						if (d9 < 0.0D)
						{
							d9 *= 4D;
						}
						double d10 = field_4228_e[k1] / 512D;
						double d11 = field_4227_f[k1] / 512D;
						double d12 = (field_4229_d[k1] / 10D + 1.0D) / 2D;
						if (d12 < 0.0D)
						{
							d8 = d10;
						}
						else
						{
							if (d12 > 1.0D)
							{
								d8 = d11;
							}
							else
							{
								d8 = d10 + (d11 - d10) * d12;
							}
						}
						d8 -= d9;
						if (j3 > i1 - 4)
						{
							double d13 = (float)(j3 - (i1 - 4)) / 3F;
							d8 = d8 * (1.0D - d13) + -10D * d13;
						}
						ad[k1] = d8;
						k1++;
					}
				}
			}
			return ad;
		}

		public virtual bool ChunkExists(int i, int j)
		{
			return true;
		}

		public virtual void Populate(net.minecraft.src.IChunkProvider ichunkprovider, int
			 i, int j)
		{
			net.minecraft.src.BlockSand.fallInstantly = true;
			int k = i * 16;
			int l = j * 16;
			net.minecraft.src.BiomeGenBase biomegenbase = worldObj.GetWorldChunkManager().GetBiomeGenAt
				(k + 16, l + 16);
			rand.SetSeed(worldObj.GetRandomSeed());
			long l1 = (rand.NextLong() / 2L) * 2L + 1L;
			long l2 = (rand.NextLong() / 2L) * 2L + 1L;
			rand.SetSeed((long)i * l1 + (long)j * l2 ^ worldObj.GetRandomSeed());
			double d = 0.25D;
			if (rand.Next(4) == 0)
			{
				int i1 = k + rand.Next(16) + 8;
				int l4 = rand.Next(128);
				int i8 = l + rand.Next(16) + 8;
				(new net.minecraft.src.WorldGenLakes(net.minecraft.src.Block.waterStill.blockID))
					.Generate(worldObj, rand, i1, l4, i8);
			}
			if (rand.Next(8) == 0)
			{
				int j1 = k + rand.Next(16) + 8;
				int i5 = rand.Next(rand.Next(120) + 8);
				int j8 = l + rand.Next(16) + 8;
				if (i5 < 64 || rand.Next(10) == 0)
				{
					(new net.minecraft.src.WorldGenLakes(net.minecraft.src.Block.lavaStill.blockID)).
						Generate(worldObj, rand, j1, i5, j8);
				}
			}
			for (int k1 = 0; k1 < 8; k1++)
			{
				int j5 = k + rand.Next(16) + 8;
				int k8 = rand.Next(128);
				int j11 = l + rand.Next(16) + 8;
				(new net.minecraft.src.WorldGenDungeons()).Generate(worldObj, rand, j5, k8, j11);
			}
			for (int i2 = 0; i2 < 10; i2++)
			{
				int k5 = k + rand.Next(16);
				int l8 = rand.Next(128);
				int k11 = l + rand.Next(16);
				(new net.minecraft.src.WorldGenClay(32)).Generate(worldObj, rand, k5, l8, k11);
			}
			for (int j2 = 0; j2 < 20; j2++)
			{
				int l5 = k + rand.Next(16);
				int i9 = rand.Next(128);
				int l11 = l + rand.Next(16);
				(new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.dirt.blockID, 32))
					.Generate(worldObj, rand, l5, i9, l11);
			}
			for (int k2 = 0; k2 < 10; k2++)
			{
				int i6 = k + rand.Next(16);
				int j9 = rand.Next(128);
				int i12 = l + rand.Next(16);
				(new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.gravel.blockID, 32
					)).Generate(worldObj, rand, i6, j9, i12);
			}
			for (int i3 = 0; i3 < 20; i3++)
			{
				int j6 = k + rand.Next(16);
				int k9 = rand.Next(128);
				int j12 = l + rand.Next(16);
				(new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.oreCoal.blockID, 16
					)).Generate(worldObj, rand, j6, k9, j12);
			}
			for (int j3 = 0; j3 < 20; j3++)
			{
				int k6 = k + rand.Next(16);
				int l9 = rand.Next(64);
				int k12 = l + rand.Next(16);
				(new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.oreIron.blockID, 8
					)).Generate(worldObj, rand, k6, l9, k12);
			}
			for (int k3 = 0; k3 < 2; k3++)
			{
				int l6 = k + rand.Next(16);
				int i10 = rand.Next(32);
				int l12 = l + rand.Next(16);
				(new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.oreGold.blockID, 8
					)).Generate(worldObj, rand, l6, i10, l12);
			}
			for (int l3 = 0; l3 < 8; l3++)
			{
				int i7 = k + rand.Next(16);
				int j10 = rand.Next(16);
				int i13 = l + rand.Next(16);
				(new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.oreRedstone.blockID
					, 7)).Generate(worldObj, rand, i7, j10, i13);
			}
			for (int i4 = 0; i4 < 1; i4++)
			{
				int j7 = k + rand.Next(16);
				int k10 = rand.Next(16);
				int j13 = l + rand.Next(16);
				(new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.oreDiamond.blockID
					, 7)).Generate(worldObj, rand, j7, k10, j13);
			}
			for (int j4 = 0; j4 < 1; j4++)
			{
				int k7 = k + rand.Next(16);
				int l10 = rand.Next(16) + rand.Next(16);
				int k13 = l + rand.Next(16);
				(new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.oreLapis.blockID, 
					6)).Generate(worldObj, rand, k7, l10, k13);
			}
			d = 0.5D;
			int k4 = (int)((mobSpawnerNoise.Func_647_a((double)k * d, (double)l * d) / 8D + rand
				.NextDouble() * 4D + 4D) / 3D);
			int l7 = 0;
			if (rand.Next(10) == 0)
			{
				l7++;
			}
			if (biomegenbase == net.minecraft.src.BiomeGenBase.forest)
			{
				l7 += k4 + 5;
			}
			if (biomegenbase == net.minecraft.src.BiomeGenBase.rainforest)
			{
				l7 += k4 + 5;
			}
			if (biomegenbase == net.minecraft.src.BiomeGenBase.seasonalForest)
			{
				l7 += k4 + 2;
			}
			if (biomegenbase == net.minecraft.src.BiomeGenBase.taiga)
			{
				l7 += k4 + 5;
			}
			if (biomegenbase == net.minecraft.src.BiomeGenBase.desert)
			{
				l7 -= 20;
			}
			if (biomegenbase == net.minecraft.src.BiomeGenBase.tundra)
			{
				l7 -= 20;
			}
			if (biomegenbase == net.minecraft.src.BiomeGenBase.plains)
			{
				l7 -= 20;
			}
			for (int i11 = 0; i11 < l7; i11++)
			{
				int l13 = k + rand.Next(16) + 8;
				int j14 = l + rand.Next(16) + 8;
				net.minecraft.src.WorldGenerator worldgenerator = biomegenbase.GetRandomWorldGenForTrees
					(rand);
				worldgenerator.Func_420_a(1.0D, 1.0D, 1.0D);
				worldgenerator.Generate(worldObj, rand, l13, worldObj.GetHeightValue(l13, j14), j14
					);
			}
			byte byte0 = 0;
			if (biomegenbase == net.minecraft.src.BiomeGenBase.forest)
			{
				byte0 = 2;
			}
			if (biomegenbase == net.minecraft.src.BiomeGenBase.seasonalForest)
			{
				byte0 = 4;
			}
			if (biomegenbase == net.minecraft.src.BiomeGenBase.taiga)
			{
				byte0 = 2;
			}
			if (biomegenbase == net.minecraft.src.BiomeGenBase.plains)
			{
				byte0 = 3;
			}
			for (int i14 = 0; i14 < byte0; i14++)
			{
				int k14 = k + rand.Next(16) + 8;
				int l16 = rand.Next(128);
				int k19 = l + rand.Next(16) + 8;
				(new net.minecraft.src.WorldGenFlowers(net.minecraft.src.Block.plantYellow.blockID
					)).Generate(worldObj, rand, k14, l16, k19);
			}
			byte byte1 = 0;
			if (biomegenbase == net.minecraft.src.BiomeGenBase.forest)
			{
				byte1 = 2;
			}
			if (biomegenbase == net.minecraft.src.BiomeGenBase.rainforest)
			{
				byte1 = 10;
			}
			if (biomegenbase == net.minecraft.src.BiomeGenBase.seasonalForest)
			{
				byte1 = 2;
			}
			if (biomegenbase == net.minecraft.src.BiomeGenBase.taiga)
			{
				byte1 = 1;
			}
			if (biomegenbase == net.minecraft.src.BiomeGenBase.plains)
			{
				byte1 = 10;
			}
			for (int l14 = 0; l14 < byte1; l14++)
			{
				byte byte2 = 1;
				if (biomegenbase == net.minecraft.src.BiomeGenBase.rainforest && rand.Next(3) 
					!= 0)
				{
					byte2 = 2;
				}
				int l19 = k + rand.Next(16) + 8;
				int k22 = rand.Next(128);
				int j24 = l + rand.Next(16) + 8;
				(new net.minecraft.src.WorldGenTallGrass(net.minecraft.src.Block.tallGrass.blockID
					, byte2)).Generate(worldObj, rand, l19, k22, j24);
			}
			byte1 = 0;
			if (biomegenbase == net.minecraft.src.BiomeGenBase.desert)
			{
				byte1 = 2;
			}
			for (int i15 = 0; i15 < byte1; i15++)
			{
				int i17 = k + rand.Next(16) + 8;
				int i20 = rand.Next(128);
				int l22 = l + rand.Next(16) + 8;
				(new net.minecraft.src.WorldGenDeadBush(net.minecraft.src.Block.deadBush.blockID)
					).Generate(worldObj, rand, i17, i20, l22);
			}
			if (rand.Next(2) == 0)
			{
				int j15 = k + rand.Next(16) + 8;
				int j17 = rand.Next(128);
				int j20 = l + rand.Next(16) + 8;
				(new net.minecraft.src.WorldGenFlowers(net.minecraft.src.Block.plantRed.blockID))
					.Generate(worldObj, rand, j15, j17, j20);
			}
			if (rand.Next(4) == 0)
			{
				int k15 = k + rand.Next(16) + 8;
				int k17 = rand.Next(128);
				int k20 = l + rand.Next(16) + 8;
				(new net.minecraft.src.WorldGenFlowers(net.minecraft.src.Block.mushroomBrown.blockID
					)).Generate(worldObj, rand, k15, k17, k20);
			}
			if (rand.Next(8) == 0)
			{
				int l15 = k + rand.Next(16) + 8;
				int l17 = rand.Next(128);
				int l20 = l + rand.Next(16) + 8;
				(new net.minecraft.src.WorldGenFlowers(net.minecraft.src.Block.mushroomRed.blockID
					)).Generate(worldObj, rand, l15, l17, l20);
			}
			for (int i16 = 0; i16 < 10; i16++)
			{
				int i18 = k + rand.Next(16) + 8;
				int i21 = rand.Next(128);
				int i23 = l + rand.Next(16) + 8;
				(new net.minecraft.src.WorldGenReed()).Generate(worldObj, rand, i18, i21, i23);
			}
			if (rand.Next(32) == 0)
			{
				int j16 = k + rand.Next(16) + 8;
				int j18 = rand.Next(128);
				int j21 = l + rand.Next(16) + 8;
				(new net.minecraft.src.WorldGenPumpkin()).Generate(worldObj, rand, j16, j18, j21);
			}
			int k16 = 0;
			if (biomegenbase == net.minecraft.src.BiomeGenBase.desert)
			{
				k16 += 10;
			}
			for (int k18 = 0; k18 < k16; k18++)
			{
				int k21 = k + rand.Next(16) + 8;
				int j23 = rand.Next(128);
				int k24 = l + rand.Next(16) + 8;
				(new net.minecraft.src.WorldGenCactus()).Generate(worldObj, rand, k21, j23, k24);
			}
			for (int l18 = 0; l18 < 50; l18++)
			{
				int l21 = k + rand.Next(16) + 8;
				int k23 = rand.Next(rand.Next(120) + 8);
				int l24 = l + rand.Next(16) + 8;
				(new net.minecraft.src.WorldGenLiquids(net.minecraft.src.Block.waterMoving.blockID
					)).Generate(worldObj, rand, l21, k23, l24);
			}
			for (int i19 = 0; i19 < 20; i19++)
			{
				int i22 = k + rand.Next(16) + 8;
				int l23 = rand.Next(rand.Next(rand.Next(112) + 8) + 8);
				int i25 = l + rand.Next(16) + 8;
				(new net.minecraft.src.WorldGenLiquids(net.minecraft.src.Block.lavaMoving.blockID
					)).Generate(worldObj, rand, i22, l23, i25);
			}
			generatedTemperatures = worldObj.GetWorldChunkManager().GetTemperatures(generatedTemperatures
				, k + 8, l + 8, 16, 16);
			for (int j19 = k + 8; j19 < k + 8 + 16; j19++)
			{
				for (int j22 = l + 8; j22 < l + 8 + 16; j22++)
				{
					int i24 = j19 - (k + 8);
					int j25 = j22 - (l + 8);
					int k25 = worldObj.GetTopSolidOrLiquidBlock(j19, j22);
					double d1 = generatedTemperatures[i24 * 16 + j25] - ((double)(k25 - 64) / 64D) * 
						0.29999999999999999D;
					if (d1 < 0.5D && k25 > 0 && k25 < 128 && worldObj.IsAirBlock(j19, k25, j22) && worldObj
						.GetBlockMaterial(j19, k25 - 1, j22).GetIsSolid() && worldObj.GetBlockMaterial(j19
						, k25 - 1, j22) != net.minecraft.src.Material.ice)
					{
						worldObj.SetBlockWithNotify(j19, k25, j22, net.minecraft.src.Block.snow.blockID);
					}
				}
			}
			net.minecraft.src.BlockSand.fallInstantly = false;
		}

		public virtual bool SaveChunks(bool flag, net.minecraft.src.IProgressUpdate iprogressupdate
			)
		{
			return true;
		}

		public virtual bool Func_361_a()
		{
			return false;
		}

		public virtual bool Func_364_b()
		{
			return true;
		}

		private SharpBukkitLive.SharpBukkit.SharpRandom rand;

		private net.minecraft.src.NoiseGeneratorOctaves field_705_k;

		private net.minecraft.src.NoiseGeneratorOctaves field_704_l;

		private net.minecraft.src.NoiseGeneratorOctaves field_703_m;

		private net.minecraft.src.NoiseGeneratorOctaves field_702_n;

		private net.minecraft.src.NoiseGeneratorOctaves field_701_o;

		public net.minecraft.src.NoiseGeneratorOctaves field_715_a;

		public net.minecraft.src.NoiseGeneratorOctaves field_714_b;

		public net.minecraft.src.NoiseGeneratorOctaves mobSpawnerNoise;

		private net.minecraft.src.World worldObj;

		private double[] field_4224_q;

		private double[] sandNoise;

		private double[] gravelNoise;

		private double[] stoneNoise;

		private net.minecraft.src.MapGenBase field_695_u;

		private net.minecraft.src.BiomeGenBase[] biomesForGeneration;

		internal double[] field_4229_d;

		internal double[] field_4228_e;

		internal double[] field_4227_f;

		internal double[] field_4226_g;

		internal double[] field_4225_h;

		internal int[][] field_707_i;

		private double[] generatedTemperatures;
	}
}
