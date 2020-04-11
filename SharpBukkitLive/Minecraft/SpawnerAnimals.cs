// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
    public sealed class SpawnerAnimals
    {
        public SpawnerAnimals()
        {
        }

        // Referenced classes of package net.minecraft.src:
        //            World, ChunkPosition, EntityPlayer, MathHelper, 
        //            ChunkCoordIntPair, EnumCreatureType, WorldChunkManager, BiomeGenBase, 
        //            SpawnListEntry, ChunkCoordinates, EntityLiving, Material, 
        //            EntitySpider, EntitySkeleton, EntitySheep, Pathfinder, 
        //            PathEntity, PathPoint, BlockBed, EntityZombie
        protected internal static net.minecraft.src.ChunkPosition GetRandomSpawningPointInChunk
            (net.minecraft.src.World world, int i, int j)
        {
            int k = i + world.rand.Next(16);
            int l = world.rand.Next(128);
            int i1 = j + world.rand.Next(16);
            return new net.minecraft.src.ChunkPosition(k, l, i1);
        }

        public static int PerformSpawning(net.minecraft.src.World var0, bool var1, bool var2
            )
        {
            if (!var1 && !var2)
            {
                return 0;
            }
            else
            {
                eligibleChunksForSpawning.Clear();
                int var3;
                int var6;
                for (var3 = 0; var3 < var0.playerEntities.Count; ++var3)
                {
                    net.minecraft.src.EntityPlayer var4 = (net.minecraft.src.EntityPlayer)var0.playerEntities
                        [var3];
                    int var5 = net.minecraft.src.MathHelper.Floor_double(var4.posX / 16.0D);
                    var6 = net.minecraft.src.MathHelper.Floor_double(var4.posZ / 16.0D);
                    byte var7 = 8;
                    for (int var8 = -var7; var8 <= var7; ++var8)
                    {
                        for (int var9 = -var7; var9 <= var7; ++var9)
                        {
                            eligibleChunksForSpawning.Add(new net.minecraft.src.ChunkCoordIntPair(var8 + var5, var9 + var6));
                        }
                    }
                }
                var3 = 0;
                net.minecraft.src.ChunkCoordinates var35 = var0.GetSpawnPoint();
                net.minecraft.src.EnumCreatureType[] var36 = net.minecraft.src.EnumCreatureType.Values();
                var6 = var36.Length;
                for (int var37 = 0; var37 < var6; ++var37)
                {
                    net.minecraft.src.EnumCreatureType var38 = var36[var37];
                    if ((!var38.Func_21103_d() || var2) && (var38.Func_21103_d() || var1) && var0.CountEntities
                        (var38.GetCreatureClass()) <= var38.GetMaxNumberOfCreature() * eligibleChunksForSpawning
                        .Count / 256)
                    {
                        System.Collections.IEnumerator var39 = eligibleChunksForSpawning.GetEnumerator();
                        while (var39.MoveNext())
                        {
                            net.minecraft.src.ChunkCoordIntPair var10 = (net.minecraft.src.ChunkCoordIntPair)
                                var39.Current;
                            net.minecraft.src.BiomeGenBase var11 = var0.GetWorldChunkManager().Func_4066_a(var10
                                );
                            System.Collections.IList var12 = var11.GetSpawnableList(var38);
                            if (var12 != null && var12.Count > 0)
                            {
                                int var13 = 0;
                                net.minecraft.src.SpawnListEntry var15;
                                for (System.Collections.IEnumerator var14 = var12.GetEnumerator(); var14.MoveNext
                                    (); var13 += var15.spawnRarityRate)
                                {
                                    var15 = (net.minecraft.src.SpawnListEntry)var14.Current;
                                }
                                int var40 = var0.rand.Next(var13);
                                var15 = (net.minecraft.src.SpawnListEntry)var12[0];
                                System.Collections.IEnumerator var16 = var12.GetEnumerator();
                                while (var16.MoveNext())
                                {
                                    net.minecraft.src.SpawnListEntry var17 = (net.minecraft.src.SpawnListEntry)var16.
                                        Current;
                                    var40 -= var17.spawnRarityRate;
                                    if (var40 < 0)
                                    {
                                        var15 = var17;
                                        break;
                                    }
                                }
                                net.minecraft.src.ChunkPosition var41 = GetRandomSpawningPointInChunk(var0, var10
                                    .chunkXPos * 16, var10.chunkZPos * 16);
                                int var42 = var41.x;
                                int var18 = var41.y;
                                int var19 = var41.z;
                                if (!var0.IsBlockNormalCube(var42, var18, var19) && var0.GetBlockMaterial(var42,
                                    var18, var19) == var38.GetCreatureMaterial())
                                {
                                    int var20 = 0;
                                    for (int var21 = 0; var21 < 3; ++var21)
                                    {
                                        int var22 = var42;
                                        int var23 = var18;
                                        int var24 = var19;
                                        byte var25 = 6;
                                        for (int var26 = 0; var26 < 4; ++var26)
                                        {
                                            var22 += var0.rand.Next(var25) - var0.rand.Next(var25);
                                            var23 += var0.rand.Next(1) - var0.rand.Next(1);
                                            var24 += var0.rand.Next(var25) - var0.rand.Next(var25);
                                            if (Func_21167_a(var38, var0, var22, var23, var24))
                                            {
                                                float var27 = (float)var22 + 0.5F;
                                                float var28 = (float)var23;
                                                float var29 = (float)var24 + 0.5F;
                                                if (var0.GetClosestPlayer((double)var27, (double)var28, (double)var29, 24.0D) ==
                                                    null)
                                                {
                                                    float var30 = var27 - (float)var35.posX;
                                                    float var31 = var28 - (float)var35.posY;
                                                    float var32 = var29 - (float)var35.posZ;
                                                    float var33 = var30 * var30 + var31 * var31 + var32 * var32;
                                                    if (var33 >= 576.0F)
                                                    {
                                                        net.minecraft.src.EntityLiving var43;
                                                        try
                                                        {
                                                            var43 = (net.minecraft.src.EntityLiving)(var15.entityClass.GetConstructor(new System.Type[] { typeof(net.minecraft.src.World) }).Invoke(new object[] { var0 }));
                                                        }
                                                        catch (System.Exception var34)
                                                        {
                                                            Sharpen.Runtime.PrintStackTrace(var34);
                                                            return var3;
                                                        }
                                                        var43.SetLocationAndAngles((double)var27, (double)var28, (double)var29, var0.rand
                                                            .NextFloat() * 360.0F, 0.0F);
                                                        if (var43.GetCanSpawnHere())
                                                        {
                                                            ++var20;
                                                            var0.EntityJoinedWorld(var43);
                                                            Func_21166_a(var43, var0, var27, var28, var29);
                                                            if (var20 >= var43.GetMaxSpawnedInChunk())
                                                            {
                                                                goto label113_continue;
                                                            }
                                                        }
                                                        var3 += var20;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            label113_continue:;
                        }
                        label113_break:;
                    }
                }
                return var3;
            }
        }

        private static bool Func_21167_a(net.minecraft.src.EnumCreatureType enumcreaturetype
            , net.minecraft.src.World world, int i, int j, int k)
        {
            if (enumcreaturetype.GetCreatureMaterial() == net.minecraft.src.Material.water)
            {
                return world.GetBlockMaterial(i, j, k).GetIsLiquid() && !world.IsBlockNormalCube(
                    i, j + 1, k);
            }
            else
            {
                return world.IsBlockNormalCube(i, j - 1, k) && !world.IsBlockNormalCube(i, j, k)
                    && !world.GetBlockMaterial(i, j, k).GetIsLiquid() && !world.IsBlockNormalCube(i,
                    j + 1, k);
            }
        }

        private static void Func_21166_a(net.minecraft.src.EntityLiving entityliving, net.minecraft.src.World
             world, float f, float f1, float f2)
        {
            if ((entityliving is net.minecraft.src.EntitySpider) && world.rand.Next(100) ==
                 0)
            {
                net.minecraft.src.EntitySkeleton entityskeleton = new net.minecraft.src.EntitySkeleton
                    (world);
                entityskeleton.SetLocationAndAngles(f, f1, f2, entityliving.rotationYaw, 0.0F);
                world.EntityJoinedWorld(entityskeleton);
                entityskeleton.MountEntity(entityliving);
            }
            else
            {
                if (entityliving is net.minecraft.src.EntitySheep)
                {
                    ((net.minecraft.src.EntitySheep)entityliving).SetFleeceColor(net.minecraft.src.EntitySheep
                        .Func_21066_a(world.rand));
                }
            }
        }

        public static bool PerformSleepSpawning(net.minecraft.src.World world, List<EntityPlayer> list)
        {
            bool flag = false;
            net.minecraft.src.Pathfinder pathfinder = new net.minecraft.src.Pathfinder(world);
            System.Collections.IEnumerator iterator = list.GetEnumerator();
            do
            {
                if (!iterator.MoveNext())
                {
                    break;
                }
                net.minecraft.src.EntityPlayer entityplayer = (net.minecraft.src.EntityPlayer)iterator
                    .Current;
                System.Type[] aclass = field_22213_a;
                if (aclass != null && aclass.Length != 0)
                {
                    bool flag1 = false;
                    int i = 0;
                    while (i < 20 && !flag1)
                    {
                        int j = (net.minecraft.src.MathHelper.Floor_double(entityplayer.posX) + world.rand
                            .NextInt(32)) - world.rand.Next(32);
                        int k = (net.minecraft.src.MathHelper.Floor_double(entityplayer.posZ) + world.rand
                            .NextInt(32)) - world.rand.Next(32);
                        int l = (net.minecraft.src.MathHelper.Floor_double(entityplayer.posY) + world.rand
                            .NextInt(16)) - world.rand.Next(16);
                        if (l < 1)
                        {
                            l = 1;
                        }
                        else
                        {
                            if (l > 128)
                            {
                                l = 128;
                            }
                        }
                        int i1 = world.rand.Next(aclass.Length);
                        int j1;
                        for (j1 = l; j1 > 2 && !world.IsBlockNormalCube(j, j1 - 1, k); j1--)
                        {
                        }
                        for (; !Func_21167_a(net.minecraft.src.EnumCreatureType.monster, world, j, j1, k)
                             && j1 < l + 16 && j1 < 128; j1++)
                        {
                        }
                        if (j1 >= l + 16 || j1 >= 128)
                        {
                            j1 = l;
                        }
                        else
                        {
                            float f = (float)j + 0.5F;
                            float f1 = j1;
                            float f2 = (float)k + 0.5F;
                            net.minecraft.src.EntityLiving entityliving;
                            try
                            {
                                entityliving = (net.minecraft.src.EntityLiving)(aclass[i1].GetConstructor(new System.Type[] { Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.World)) }).Invoke(new object[] { world }));
                            }
                            catch (System.Exception exception)
                            {
                                Sharpen.Runtime.PrintStackTrace(exception);
                                return flag;
                            }
                            entityliving.SetLocationAndAngles(f, f1, f2, world.rand.NextFloat() * 360F, 0.0F);
                            if (entityliving.GetCanSpawnHere())
                            {
                                net.minecraft.src.PathEntity pathentity = pathfinder.CreateEntityPathTo(entityliving
                                    , entityplayer, 32F);
                                if (pathentity != null && pathentity.pathLength > 1)
                                {
                                    net.minecraft.src.PathPoint pathpoint = pathentity.Func_22211_c();
                                    if (System.Math.Abs((double)pathpoint.xCoord - entityplayer.posX) < 1.5D && System.Math
                                        .Abs((double)pathpoint.zCoord - entityplayer.posZ) < 1.5D && System.Math.Abs((double
                                        )pathpoint.yCoord - entityplayer.posY) < 1.5D)
                                    {
                                        net.minecraft.src.ChunkCoordinates chunkcoordinates = net.minecraft.src.BlockBed.
                                            Func_22021_g(world, net.minecraft.src.MathHelper.Floor_double(entityplayer.posX)
                                            , net.minecraft.src.MathHelper.Floor_double(entityplayer.posY), net.minecraft.src.MathHelper
                                            .Floor_double(entityplayer.posZ), 1);
                                        if (chunkcoordinates == null)
                                        {
                                            chunkcoordinates = new net.minecraft.src.ChunkCoordinates(j, j1 + 1, k);
                                        }
                                        entityliving.SetLocationAndAngles((float)chunkcoordinates.posX + 0.5F, chunkcoordinates
                                            .posY, (float)chunkcoordinates.posZ + 0.5F, 0.0F, 0.0F);
                                        world.EntityJoinedWorld(entityliving);
                                        Func_21166_a(entityliving, world, (float)chunkcoordinates.posX + 0.5F, chunkcoordinates
                                            .posY, (float)chunkcoordinates.posZ + 0.5F);
                                        entityplayer.WakeUpPlayer(true, false, false);
                                        entityliving.PlayLivingSound();
                                        flag = true;
                                        flag1 = true;
                                    }
                                }
                            }
                        }
                        i++;
                    }
                }
            }
            while (true);
            return flag;
        }

        private static HashSet<ChunkCoordIntPair> eligibleChunksForSpawning = new HashSet<ChunkCoordIntPair>();

        protected internal static readonly System.Type[] field_22213_a;

        static SpawnerAnimals()
        {
            field_22213_a = (new System.Type[] { Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntitySpider
                )), Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityZombie)), Sharpen.Runtime.GetClassForType
                (typeof(net.minecraft.src.EntitySkeleton)) });
        }
    }
}
