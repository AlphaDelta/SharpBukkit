// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Threading.Tasks;

namespace net.minecraft.src
{
    public class ChunkProviderSky : net.minecraft.src.IChunkProvider
    {
        public ChunkProviderSky(net.minecraft.src.World world, long l)
        {
            // Referenced classes of package net.minecraft.src:
            //            IChunkProvider, MapGenCaves, NoiseGeneratorOctaves, Block, 
            //            BiomeGenBase, Chunk, World, WorldChunkManager, 
            //            MapGenBase, BlockSand, WorldGenLakes, WorldGenDungeons, 
            //            WorldGenClay, WorldGenMinable, WorldGenerator, WorldGenFlowers, 
            //            BlockFlower, WorldGenReed, WorldGenPumpkin, WorldGenCactus, 
            //            WorldGenLiquids, Material, IProgressUpdate
            field_28077_r = new double[256];
            field_28076_s = new double[256];
            field_28075_t = new double[256];
            field_28074_u = new net.minecraft.src.MapGenCaves();
            field_28086_i = new int[][] { new int[32], new int[32], new int[32], new int[32],
                new int[32], new int[32], new int[32], new int[32], new int[32], new int[32], new
                int[32], new int[32], new int[32], new int[32], new int[32], new int[32], new int
                [32], new int[32], new int[32], new int[32], new int[32], new int[32], new int[32
                ], new int[32], new int[32], new int[32], new int[32], new int[32], new int[32],
                new int[32], new int[32], new int[32] };
            field_28079_p = world;
            field_28085_j = new SharpBukkitLive.SharpBukkit.SharpRandom(l);
            field_28084_k = new net.minecraft.src.NoiseGeneratorOctaves(field_28085_j, 16);
            field_28083_l = new net.minecraft.src.NoiseGeneratorOctaves(field_28085_j, 16);
            field_28082_m = new net.minecraft.src.NoiseGeneratorOctaves(field_28085_j, 8);
            field_28081_n = new net.minecraft.src.NoiseGeneratorOctaves(field_28085_j, 4);
            field_28080_o = new net.minecraft.src.NoiseGeneratorOctaves(field_28085_j, 4);
            field_28094_a = new net.minecraft.src.NoiseGeneratorOctaves(field_28085_j, 10);
            field_28093_b = new net.minecraft.src.NoiseGeneratorOctaves(field_28085_j, 16);
            field_28092_c = new net.minecraft.src.NoiseGeneratorOctaves(field_28085_j, 8);
        }

        public virtual void Func_28070_a(int i, int j, byte[] abyte0, net.minecraft.src.BiomeGenBase
            [] abiomegenbase, double[] ad)
        {
            byte byte0 = 2;
            int k = byte0 + 1;
            byte byte1 = 33;
            int l = byte0 + 1;
            field_28078_q = Func_28071_a(field_28078_q, i * byte0, 0, j * byte0, k, byte1, l);
            for (int i1 = 0; i1 < byte0; i1++)
            {
                for (int j1 = 0; j1 < byte0; j1++)
                {
                    for (int k1 = 0; k1 < 32; k1++)
                    {
                        double d = 0.25D;
                        double d1 = field_28078_q[((i1 + 0) * l + (j1 + 0)) * byte1 + (k1 + 0)];
                        double d2 = field_28078_q[((i1 + 0) * l + (j1 + 1)) * byte1 + (k1 + 0)];
                        double d3 = field_28078_q[((i1 + 1) * l + (j1 + 0)) * byte1 + (k1 + 0)];
                        double d4 = field_28078_q[((i1 + 1) * l + (j1 + 1)) * byte1 + (k1 + 0)];
                        double d5 = (field_28078_q[((i1 + 0) * l + (j1 + 0)) * byte1 + (k1 + 1)] - d1) *
                            d;
                        double d6 = (field_28078_q[((i1 + 0) * l + (j1 + 1)) * byte1 + (k1 + 1)] - d2) *
                            d;
                        double d7 = (field_28078_q[((i1 + 1) * l + (j1 + 0)) * byte1 + (k1 + 1)] - d3) *
                            d;
                        double d8 = (field_28078_q[((i1 + 1) * l + (j1 + 1)) * byte1 + (k1 + 1)] - d4) *
                            d;
                        for (int l1 = 0; l1 < 4; l1++)
                        {
                            double d9 = 0.125D;
                            double d10 = d1;
                            double d11 = d2;
                            double d12 = (d3 - d1) * d9;
                            double d13 = (d4 - d2) * d9;
                            for (int i2 = 0; i2 < 8; i2++)
                            {
                                int j2 = i2 + i1 * 8 << 11 | 0 + j1 * 8 << 7 | k1 * 4 + l1;
                                short c = 128;// '\200';
                                double d14 = 0.125D;
                                double d15 = d10;
                                double d16 = (d11 - d10) * d14;
                                for (int k2 = 0; k2 < 8; k2++)
                                {
                                    int l2 = 0;
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

        public virtual void Func_28069_a(int i, int j, byte[] abyte0, net.minecraft.src.BiomeGenBase
            [] abiomegenbase)
        {
            double d = 0.03125D;
            field_28077_r = field_28081_n.GenerateNoiseOctaves(field_28077_r, i * 16, j * 16, 0.0D, 16, 16, 1, d, d, 1.0D);
            field_28076_s = field_28081_n.GenerateNoiseOctaves(field_28076_s, i * 16, 109.0134D, j * 16, 16, 1, 16, d, 1.0D, d);
            field_28075_t = field_28080_o.GenerateNoiseOctaves(field_28075_t, i * 16, j * 16, 0.0D, 16, 16, 1, d * 2D, d * 2D, d * 2D);
            for (int k = 0; k < 16; k++)
            {
                for (int l = 0; l < 16; l++)
                {
                    net.minecraft.src.BiomeGenBase biomegenbase = abiomegenbase[k + l * 16];
                    int i1 = (int)(field_28075_t[k + l * 16] / 3D + 3D + field_28085_j.NextDouble() *
                         0.25D);
                    int j1 = -1;
                    byte byte0 = biomegenbase.topBlock;
                    byte byte1 = biomegenbase.fillerBlock;
                    for (int k1 = 127; k1 >= 0; k1--)
                    {
                        int l1 = (l * 16 + k) * 128 + k1;
                        byte byte2 = abyte0[l1];
                        if (byte2 == 0)
                        {
                            j1 = -1;
                            continue;
                        }
                        if (byte2 != net.minecraft.src.Block.stone.blockID)
                        {
                            continue;
                        }
                        if (j1 == -1)
                        {
                            if (i1 <= 0)
                            {
                                byte0 = 0;
                                byte1 = unchecked((byte)net.minecraft.src.Block.stone.blockID);
                            }
                            j1 = i1;
                            if (k1 >= 0)
                            {
                                abyte0[l1] = byte0;
                            }
                            else
                            {
                                abyte0[l1] = byte1;
                            }
                            continue;
                        }
                        if (j1 <= 0)
                        {
                            continue;
                        }
                        j1--;
                        abyte0[l1] = byte1;
                        if (j1 == 0 && byte1 == net.minecraft.src.Block.sand.blockID)
                        {
                            j1 = field_28085_j.NextInt(4);
                            byte1 = unchecked((byte)net.minecraft.src.Block.sandStone.blockID);
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
            field_28085_j.SetSeed((long)i * unchecked((long)(0x4f9939f508L)) + (long)j * unchecked(
                (long)(0x1ef1565bd5L)));
            byte[] abyte0 = new byte[32768];
            net.minecraft.src.Chunk chunk = new net.minecraft.src.Chunk(field_28079_p, abyte0
                , i, j);
            field_28073_v = field_28079_p.GetWorldChunkManager().LoadBlockGeneratorData(field_28073_v
                , i * 16, j * 16, 16, 16);
            double[] ad = field_28079_p.GetWorldChunkManager().temperature;
            Func_28070_a(i, j, abyte0, field_28073_v, ad);
            Func_28069_a(i, j, abyte0, field_28073_v);
            field_28074_u.Func_667_a(this, field_28079_p, i, j, abyte0);
            chunk.Func_353_b();
            return chunk;
        }

        private double[] Func_28071_a(double[] ad, int i, int j, int k, int l, int i1, int
             j1)
        {
            if (ad == null)
            {
                ad = new double[l * i1 * j1];
            }
            double d = 684.41200000000003D;
            double d1 = 684.41200000000003D;
            double[] ad1 = field_28079_p.GetWorldChunkManager().temperature;
            double[] ad2 = field_28079_p.GetWorldChunkManager().humidity;

            Task[] tasks = new Task[5];

            tasks[0] = Task.Run(() => { field_28088_g = field_28094_a.Func_4103_a(field_28088_g, i, k, l, j1, 1.121D, 1.121D, 0.5D); });
            tasks[1] = Task.Run(() => { field_28087_h = field_28093_b.Func_4103_a(field_28087_h, i, k, l, j1, 200D, 200D, 0.5D); });

            d *= 2D;

            tasks[2] = Task.Run(() => { field_28091_d = field_28082_m.GenerateNoiseOctaves(field_28091_d, i, j, k, l, i1, j1, d / 80D, d1 / 160D, d / 80D); });
            tasks[3] = Task.Run(() => { field_28090_e = field_28084_k.GenerateNoiseOctaves(field_28090_e, i, j, k, l, i1, j1, d, d1, d); });
            tasks[4] = Task.Run(() => { field_28089_f = field_28083_l.GenerateNoiseOctaves(field_28089_f, i, j, k, l, i1, j1, d, d1, d); });

            Task.WaitAll(tasks);

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
                    double d5 = (field_28088_g[l1] + 256D) / 512D;
                    d5 *= d4;
                    if (d5 > 1.0D)
                    {
                        d5 = 1.0D;
                    }
                    double d6 = field_28087_h[l1] / 8000D;
                    if (d6 < 0.0D)
                    {
                        d6 = -d6 * 0.29999999999999999D;
                    }
                    d6 = d6 * 3D - 2D;
                    if (d6 > 1.0D)
                    {
                        d6 = 1.0D;
                    }
                    d6 /= 8D;
                    d6 = 0.0D;
                    if (d5 < 0.0D)
                    {
                        d5 = 0.0D;
                    }
                    d5 += 0.5D;
                    d6 = (d6 * (double)i1) / 16D;
                    l1++;
                    double d7 = (double)i1 / 2D;
                    for (int j3 = 0; j3 < i1; j3++)
                    {
                        double d8 = 0.0D;
                        double d9 = (((double)j3 - d7) * 8D) / d5;
                        if (d9 < 0.0D)
                        {
                            d9 *= -1D;
                        }
                        double d10 = field_28090_e[k1] / 512D;
                        double d11 = field_28089_f[k1] / 512D;
                        double d12 = (field_28091_d[k1] / 10D + 1.0D) / 2D;
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
                        d8 -= 8D;
                        int k3 = 32;
                        if (j3 > i1 - k3)
                        {
                            double d13 = (float)(j3 - (i1 - k3)) / ((float)k3 - 1.0F);
                            d8 = d8 * (1.0D - d13) + -30D * d13;
                        }
                        k3 = 8;
                        if (j3 < k3)
                        {
                            double d14 = (float)(k3 - j3) / ((float)k3 - 1.0F);
                            d8 = d8 * (1.0D - d14) + -30D * d14;
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
            net.minecraft.src.BiomeGenBase biomegenbase = field_28079_p.GetWorldChunkManager(
                ).GetBiomeGenAt(k + 16, l + 16);
            field_28085_j.SetSeed(field_28079_p.GetRandomSeed());
            long l1 = (field_28085_j.NextLong() / 2L) * 2L + 1L;
            long l2 = (field_28085_j.NextLong() / 2L) * 2L + 1L;
            field_28085_j.SetSeed((long)i * l1 + (long)j * l2 ^ field_28079_p.GetRandomSeed()
                );
            double d = 0.25D;
            if (field_28085_j.NextInt(4) == 0)
            {
                int i1 = k + field_28085_j.NextInt(16) + 8;
                int l4 = field_28085_j.NextInt(128);
                int i8 = l + field_28085_j.NextInt(16) + 8;
                (new net.minecraft.src.WorldGenLakes(net.minecraft.src.Block.waterStill.blockID))
                    .Generate(field_28079_p, field_28085_j, i1, l4, i8);
            }
            if (field_28085_j.NextInt(8) == 0)
            {
                int j1 = k + field_28085_j.NextInt(16) + 8;
                int i5 = field_28085_j.NextInt(field_28085_j.NextInt(120) + 8);
                int j8 = l + field_28085_j.NextInt(16) + 8;
                if (i5 < 64 || field_28085_j.NextInt(10) == 0)
                {
                    (new net.minecraft.src.WorldGenLakes(net.minecraft.src.Block.lavaStill.blockID)).
                        Generate(field_28079_p, field_28085_j, j1, i5, j8);
                }
            }
            for (int k1 = 0; k1 < 8; k1++)
            {
                int j5 = k + field_28085_j.NextInt(16) + 8;
                int k8 = field_28085_j.NextInt(128);
                int i13 = l + field_28085_j.NextInt(16) + 8;
                (new net.minecraft.src.WorldGenDungeons()).Generate(field_28079_p, field_28085_j,
                    j5, k8, i13);
            }
            for (int i2 = 0; i2 < 10; i2++)
            {
                int k5 = k + field_28085_j.NextInt(16);
                int l8 = field_28085_j.NextInt(128);
                int j13 = l + field_28085_j.NextInt(16);
                (new net.minecraft.src.WorldGenClay(32)).Generate(field_28079_p, field_28085_j, k5
                    , l8, j13);
            }
            for (int j2 = 0; j2 < 20; j2++)
            {
                int l5 = k + field_28085_j.NextInt(16);
                int i9 = field_28085_j.NextInt(128);
                int k13 = l + field_28085_j.NextInt(16);
                (new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.dirt.blockID, 32))
                    .Generate(field_28079_p, field_28085_j, l5, i9, k13);
            }
            for (int k2 = 0; k2 < 10; k2++)
            {
                int i6 = k + field_28085_j.NextInt(16);
                int j9 = field_28085_j.NextInt(128);
                int l13 = l + field_28085_j.NextInt(16);
                (new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.gravel.blockID, 32
                    )).Generate(field_28079_p, field_28085_j, i6, j9, l13);
            }
            for (int i3 = 0; i3 < 20; i3++)
            {
                int j6 = k + field_28085_j.NextInt(16);
                int k9 = field_28085_j.NextInt(128);
                int i14 = l + field_28085_j.NextInt(16);
                (new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.oreCoal.blockID, 16
                    )).Generate(field_28079_p, field_28085_j, j6, k9, i14);
            }
            for (int j3 = 0; j3 < 20; j3++)
            {
                int k6 = k + field_28085_j.NextInt(16);
                int l9 = field_28085_j.NextInt(64);
                int j14 = l + field_28085_j.NextInt(16);
                (new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.oreIron.blockID, 8
                    )).Generate(field_28079_p, field_28085_j, k6, l9, j14);
            }
            for (int k3 = 0; k3 < 2; k3++)
            {
                int l6 = k + field_28085_j.NextInt(16);
                int i10 = field_28085_j.NextInt(32);
                int k14 = l + field_28085_j.NextInt(16);
                (new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.oreGold.blockID, 8
                    )).Generate(field_28079_p, field_28085_j, l6, i10, k14);
            }
            for (int l3 = 0; l3 < 8; l3++)
            {
                int i7 = k + field_28085_j.NextInt(16);
                int j10 = field_28085_j.NextInt(16);
                int l14 = l + field_28085_j.NextInt(16);
                (new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.oreRedstone.blockID
                    , 7)).Generate(field_28079_p, field_28085_j, i7, j10, l14);
            }
            for (int i4 = 0; i4 < 1; i4++)
            {
                int j7 = k + field_28085_j.NextInt(16);
                int k10 = field_28085_j.NextInt(16);
                int i15 = l + field_28085_j.NextInt(16);
                (new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.oreDiamond.blockID
                    , 7)).Generate(field_28079_p, field_28085_j, j7, k10, i15);
            }
            for (int j4 = 0; j4 < 1; j4++)
            {
                int k7 = k + field_28085_j.NextInt(16);
                int l10 = field_28085_j.NextInt(16) + field_28085_j.NextInt(16);
                int j15 = l + field_28085_j.NextInt(16);
                (new net.minecraft.src.WorldGenMinable(net.minecraft.src.Block.oreLapis.blockID,
                    6)).Generate(field_28079_p, field_28085_j, k7, l10, j15);
            }
            d = 0.5D;
            int k4 = (int)((field_28092_c.Func_647_a((double)k * d, (double)l * d) / 8D + field_28085_j
                .NextDouble() * 4D + 4D) / 3D);
            int l7 = 0;
            if (field_28085_j.NextInt(10) == 0)
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
                int k15 = k + field_28085_j.NextInt(16) + 8;
                int j18 = l + field_28085_j.NextInt(16) + 8;
                net.minecraft.src.WorldGenerator worldgenerator = biomegenbase.GetRandomWorldGenForTrees
                    (field_28085_j);
                worldgenerator.Func_420_a(1.0D, 1.0D, 1.0D);
                worldgenerator.Generate(field_28079_p, field_28085_j, k15, field_28079_p.GetHeightValue
                    (k15, j18), j18);
            }
            for (int j11 = 0; j11 < 2; j11++)
            {
                int l15 = k + field_28085_j.NextInt(16) + 8;
                int k18 = field_28085_j.NextInt(128);
                int i21 = l + field_28085_j.NextInt(16) + 8;
                (new net.minecraft.src.WorldGenFlowers(net.minecraft.src.Block.plantYellow.blockID
                    )).Generate(field_28079_p, field_28085_j, l15, k18, i21);
            }
            if (field_28085_j.NextInt(2) == 0)
            {
                int k11 = k + field_28085_j.NextInt(16) + 8;
                int i16 = field_28085_j.NextInt(128);
                int l18 = l + field_28085_j.NextInt(16) + 8;
                (new net.minecraft.src.WorldGenFlowers(net.minecraft.src.Block.plantRed.blockID))
                    .Generate(field_28079_p, field_28085_j, k11, i16, l18);
            }
            if (field_28085_j.NextInt(4) == 0)
            {
                int l11 = k + field_28085_j.NextInt(16) + 8;
                int j16 = field_28085_j.NextInt(128);
                int i19 = l + field_28085_j.NextInt(16) + 8;
                (new net.minecraft.src.WorldGenFlowers(net.minecraft.src.Block.mushroomBrown.blockID
                    )).Generate(field_28079_p, field_28085_j, l11, j16, i19);
            }
            if (field_28085_j.NextInt(8) == 0)
            {
                int i12 = k + field_28085_j.NextInt(16) + 8;
                int k16 = field_28085_j.NextInt(128);
                int j19 = l + field_28085_j.NextInt(16) + 8;
                (new net.minecraft.src.WorldGenFlowers(net.minecraft.src.Block.mushroomRed.blockID
                    )).Generate(field_28079_p, field_28085_j, i12, k16, j19);
            }
            for (int j12 = 0; j12 < 10; j12++)
            {
                int l16 = k + field_28085_j.NextInt(16) + 8;
                int k19 = field_28085_j.NextInt(128);
                int j21 = l + field_28085_j.NextInt(16) + 8;
                (new net.minecraft.src.WorldGenReed()).Generate(field_28079_p, field_28085_j, l16
                    , k19, j21);
            }
            if (field_28085_j.NextInt(32) == 0)
            {
                int k12 = k + field_28085_j.NextInt(16) + 8;
                int i17 = field_28085_j.NextInt(128);
                int l19 = l + field_28085_j.NextInt(16) + 8;
                (new net.minecraft.src.WorldGenPumpkin()).Generate(field_28079_p, field_28085_j,
                    k12, i17, l19);
            }
            int l12 = 0;
            if (biomegenbase == net.minecraft.src.BiomeGenBase.desert)
            {
                l12 += 10;
            }
            for (int j17 = 0; j17 < l12; j17++)
            {
                int i20 = k + field_28085_j.NextInt(16) + 8;
                int k21 = field_28085_j.NextInt(128);
                int k22 = l + field_28085_j.NextInt(16) + 8;
                (new net.minecraft.src.WorldGenCactus()).Generate(field_28079_p, field_28085_j, i20
                    , k21, k22);
            }
            for (int k17 = 0; k17 < 50; k17++)
            {
                int j20 = k + field_28085_j.NextInt(16) + 8;
                int l21 = field_28085_j.NextInt(field_28085_j.NextInt(120) + 8);
                int l22 = l + field_28085_j.NextInt(16) + 8;
                (new net.minecraft.src.WorldGenLiquids(net.minecraft.src.Block.waterMoving.blockID
                    )).Generate(field_28079_p, field_28085_j, j20, l21, l22);
            }
            for (int l17 = 0; l17 < 20; l17++)
            {
                int k20 = k + field_28085_j.NextInt(16) + 8;
                int i22 = field_28085_j.NextInt(field_28085_j.NextInt(field_28085_j.NextInt(112)
                    + 8) + 8);
                int i23 = l + field_28085_j.NextInt(16) + 8;
                (new net.minecraft.src.WorldGenLiquids(net.minecraft.src.Block.lavaMoving.blockID
                    )).Generate(field_28079_p, field_28085_j, k20, i22, i23);
            }
            field_28072_w = field_28079_p.GetWorldChunkManager().GetTemperatures(field_28072_w
                , k + 8, l + 8, 16, 16);
            for (int i18 = k + 8; i18 < k + 8 + 16; i18++)
            {
                for (int l20 = l + 8; l20 < l + 8 + 16; l20++)
                {
                    int j22 = i18 - (k + 8);
                    int j23 = l20 - (l + 8);
                    int k23 = field_28079_p.GetTopSolidOrLiquidBlock(i18, l20);
                    double d1 = field_28072_w[j22 * 16 + j23] - ((double)(k23 - 64) / 64D) * 0.29999999999999999D;
                    if (d1 < 0.5D && k23 > 0 && k23 < 128 && field_28079_p.IsAirBlock(i18, k23, l20)
                        && field_28079_p.GetBlockMaterial(i18, k23 - 1, l20).GetIsSolid() && field_28079_p
                        .GetBlockMaterial(i18, k23 - 1, l20) != net.minecraft.src.Material.ice)
                    {
                        field_28079_p.SetBlockWithNotify(i18, k23, l20, net.minecraft.src.Block.snow.blockID
                            );
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

        public virtual bool CanSave()
        {
            return true;
        }

        private SharpBukkitLive.SharpBukkit.SharpRandom field_28085_j;

        private net.minecraft.src.NoiseGeneratorOctaves field_28084_k;

        private net.minecraft.src.NoiseGeneratorOctaves field_28083_l;

        private net.minecraft.src.NoiseGeneratorOctaves field_28082_m;

        private net.minecraft.src.NoiseGeneratorOctaves field_28081_n;

        private net.minecraft.src.NoiseGeneratorOctaves field_28080_o;

        public net.minecraft.src.NoiseGeneratorOctaves field_28094_a;

        public net.minecraft.src.NoiseGeneratorOctaves field_28093_b;

        public net.minecraft.src.NoiseGeneratorOctaves field_28092_c;

        private net.minecraft.src.World field_28079_p;

        private double[] field_28078_q;

        private double[] field_28077_r;

        private double[] field_28076_s;

        private double[] field_28075_t;

        private net.minecraft.src.MapGenBase field_28074_u;

        private net.minecraft.src.BiomeGenBase[] field_28073_v;

        internal double[] field_28091_d;

        internal double[] field_28090_e;

        internal double[] field_28089_f;

        internal double[] field_28088_g;

        internal double[] field_28087_h;

        internal int[][] field_28086_i;

        private double[] field_28072_w;
    }
}
