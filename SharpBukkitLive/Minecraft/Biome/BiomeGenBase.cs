// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System;
using System.Collections.Generic;

namespace net.minecraft.src
{
    public class BiomeGenBase
    {
        protected internal BiomeGenBase()
        {
            // Referenced classes of package net.minecraft.src:
            //            Block, BlockGrass, SpawnListEntry, EntitySpider, 
            //            EntityZombie, EntitySkeleton, EntityCreeper, EntitySlime, 
            //            EntitySheep, EntityPig, EntityChicken, EntityCow, 
            //            EntitySquid, WorldGenBigTree, WorldGenTrees, EnumCreatureType, 
            //            BiomeGenRainforest, BiomeGenSwamp, BiomeGenForest, BiomeGenDesert, 
            //            BiomeGenTaiga, BiomeGenHell, BiomeGenSky, WorldGenerator
            topBlock = unchecked((byte)net.minecraft.src.Block.GRASS.ID);
            fillerBlock = unchecked((byte)net.minecraft.src.Block.DIRT.ID);
            field_6161_q = 0x4ee031;
            spawnableMonsterList = new List<SpawnListEntry>();
            spawnableCreatureList = new List<SpawnListEntry>();
            spawnableWaterCreatureList = new List<SpawnListEntry>();
            enableRain = true;
            spawnableMonsterList.Add(new net.minecraft.src.SpawnListEntry(typeof(net.minecraft.src.EntitySpider), 10));
            spawnableMonsterList.Add(new net.minecraft.src.SpawnListEntry(typeof(net.minecraft.src.EntityZombie), 10));
            spawnableMonsterList.Add(new net.minecraft.src.SpawnListEntry(typeof(net.minecraft.src.EntitySkeleton), 10));
            spawnableMonsterList.Add(new net.minecraft.src.SpawnListEntry(typeof(net.minecraft.src.EntityCreeper), 10));
            spawnableMonsterList.Add(new net.minecraft.src.SpawnListEntry(typeof(net.minecraft.src.EntitySlime), 10));
            spawnableCreatureList.Add(new net.minecraft.src.SpawnListEntry(typeof(net.minecraft.src.EntitySheep), 12));
            spawnableCreatureList.Add(new net.minecraft.src.SpawnListEntry(typeof(net.minecraft.src.EntityPig), 10));
            spawnableCreatureList.Add(new net.minecraft.src.SpawnListEntry(typeof(net.minecraft.src.EntityChicken), 10));
            spawnableCreatureList.Add(new net.minecraft.src.SpawnListEntry(typeof(net.minecraft.src.EntityCow), 8));
            spawnableWaterCreatureList.Add(new net.minecraft.src.SpawnListEntry(typeof(net.minecraft.src.EntitySquid), 10));
        }

        private net.minecraft.src.BiomeGenBase SetDisableRain()
        {
            enableRain = false;
            return this;
        }

        public static void GenerateBiomeLookup()
        {
            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    biomeLookupTable[i + j * 64] = GetBiome((float)i / 63F, (float)j / 63F);
                }
            }
            desert.topBlock = desert.fillerBlock = unchecked((byte)net.minecraft.src.Block.SAND
                .ID);
            iceDesert.topBlock = iceDesert.fillerBlock = unchecked((byte)net.minecraft.src.Block
                .SAND.ID);
        }

        public virtual net.minecraft.src.WorldGenerator GetRandomWorldGenForTrees(SharpRandom random)
        {
            if (random.Next(10) == 0)
            {
                return new net.minecraft.src.WorldGenBigTree();
            }
            else
            {
                return new net.minecraft.src.WorldGenTrees();
            }
        }

        protected internal virtual net.minecraft.src.BiomeGenBase SetEnableSnow()
        {
            enableSnow = true;
            return this;
        }

        protected internal virtual net.minecraft.src.BiomeGenBase SetBiomeName(string s)
        {
            biomeName = s;
            return this;
        }

        protected internal virtual net.minecraft.src.BiomeGenBase Func_4080_a(int i)
        {
            field_6161_q = i;
            return this;
        }

        protected internal virtual net.minecraft.src.BiomeGenBase SetColor(int i)
        {
            color = i;
            return this;
        }

        public static net.minecraft.src.BiomeGenBase GetBiomeFromLookup(double d, double
            d1)
        {
            int i = (int)(d * 63D);
            int j = (int)(d1 * 63D);
            return biomeLookupTable[i + j * 64];
        }

        public static net.minecraft.src.BiomeGenBase GetBiome(float f, float f1)
        {
            f1 *= f;
            if (f < 0.1F)
            {
                return tundra;
            }
            if (f1 < 0.2F)
            {
                if (f < 0.5F)
                {
                    return tundra;
                }
                if (f < 0.95F)
                {
                    return savanna;
                }
                else
                {
                    return desert;
                }
            }
            if (f1 > 0.5F && f < 0.7F)
            {
                return swampland;
            }
            if (f < 0.5F)
            {
                return taiga;
            }
            if (f < 0.97F)
            {
                if (f1 < 0.35F)
                {
                    return shrubland;
                }
                else
                {
                    return forest;
                }
            }
            if (f1 < 0.45F)
            {
                return plains;
            }
            if (f1 < 0.9F)
            {
                return seasonalForest;
            }
            else
            {
                return rainforest;
            }
        }

        public virtual List<SpawnListEntry> GetSpawnableList(net.minecraft.src.EnumCreatureType enumcreaturetype)
        {
            if (enumcreaturetype == net.minecraft.src.EnumCreatureType.monster)
            {
                return spawnableMonsterList;
            }
            if (enumcreaturetype == net.minecraft.src.EnumCreatureType.creature)
            {
                return spawnableCreatureList;
            }
            if (enumcreaturetype == net.minecraft.src.EnumCreatureType.waterCreature)
            {
                return spawnableWaterCreatureList;
            }
            else
            {
                return null;
            }
        }

        public virtual bool GetEnableSnow()
        {
            return enableSnow;
        }

        public virtual bool CanSpawnLightningBolt()
        {
            if (enableSnow)
            {
                return false;
            }
            else
            {
                return enableRain;
            }
        }

        public static readonly net.minecraft.src.BiomeGenBase rainforest = (new net.minecraft.src.BiomeGenRainforest
            ()).SetColor(0x8fa36).SetBiomeName("Rainforest").Func_4080_a(0x1ff458);

        public static readonly net.minecraft.src.BiomeGenBase swampland = (new net.minecraft.src.BiomeGenSwamp
            ()).SetColor(0x7f9b2).SetBiomeName("Swampland").Func_4080_a(0x8baf48);

        public static readonly net.minecraft.src.BiomeGenBase seasonalForest = (new net.minecraft.src.BiomeGenBase
            ()).SetColor(0x9be023).SetBiomeName("Seasonal Forest");

        public static readonly net.minecraft.src.BiomeGenBase forest = (new net.minecraft.src.BiomeGenForest
            ()).SetColor(0x56621).SetBiomeName("Forest").Func_4080_a(0x4eba31);

        public static readonly net.minecraft.src.BiomeGenBase savanna = (new net.minecraft.src.BiomeGenDesert
            ()).SetColor(0xd9e023).SetBiomeName("Savanna");

        public static readonly net.minecraft.src.BiomeGenBase shrubland = (new net.minecraft.src.BiomeGenBase
            ()).SetColor(0xa1ad20).SetBiomeName("Shrubland");

        public static readonly net.minecraft.src.BiomeGenBase taiga = (new net.minecraft.src.BiomeGenTaiga
            ()).SetColor(0x2eb153).SetBiomeName("Taiga").SetEnableSnow().Func_4080_a
            (0x7bb731);

        public static readonly net.minecraft.src.BiomeGenBase desert = (new net.minecraft.src.BiomeGenDesert
            ()).SetColor(0xfa9418).SetBiomeName("Desert").SetDisableRain();

        public static readonly net.minecraft.src.BiomeGenBase plains = (new net.minecraft.src.BiomeGenDesert
            ()).SetColor(0xffd910).SetBiomeName("Plains");

        public static readonly net.minecraft.src.BiomeGenBase iceDesert = (new net.minecraft.src.BiomeGenDesert
            ()).SetColor(0xffed93).SetBiomeName("Ice Desert").SetEnableSnow
            ().SetDisableRain().Func_4080_a(0xc4d339);

        public static readonly net.minecraft.src.BiomeGenBase tundra = (new net.minecraft.src.BiomeGenBase
            ()).SetColor(0x57ebf9).SetBiomeName("Tundra").SetEnableSnow().
            Func_4080_a(0xc4d339);

        public static readonly net.minecraft.src.BiomeGenBase hell = (new net.minecraft.src.BiomeGenHell
            ()).SetColor(0xff0000).SetBiomeName("Hell").SetDisableRain();

        public static readonly net.minecraft.src.BiomeGenBase field_28054_m = (new net.minecraft.src.BiomeGenSky
            ()).SetColor(0x8080ff).SetBiomeName("Sky").SetDisableRain();

        public string biomeName;

        public int color;

        public byte topBlock;

        public byte fillerBlock;

        public int field_6161_q;

        protected internal List<SpawnListEntry> spawnableMonsterList;
        protected internal List<SpawnListEntry> spawnableCreatureList;
        protected internal List<SpawnListEntry> spawnableWaterCreatureList;

        private bool enableSnow;

        private bool enableRain;

        private static net.minecraft.src.BiomeGenBase[] biomeLookupTable = new net.minecraft.src.BiomeGenBase
            [4096];

        static BiomeGenBase()
        {
            GenerateBiomeLookup();
        }
    }
}
