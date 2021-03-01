// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System;

namespace net.minecraft.src
{
    public class BlockBed : net.minecraft.src.Block
    {
        public BlockBed(int i)
            : base(i, 134, net.minecraft.src.Material.cloth)
        {
            // Referenced classes of package net.minecraft.src:
            //            Block, Material, World, WorldProvider, 
            //            EntityPlayer, ChunkCoordinates, EnumStatus, ModelBed, 
            //            Item, IBlockAccess
            SetBounds();
        }

        public override bool BlockActivated(net.minecraft.src.World world, int i, int j,
            int k, net.minecraft.src.EntityPlayer entityplayer)
        {
            if (world.singleplayerWorld)
            {
                return true;
            }
            int l = world.GetBlockMetadata(i, j, k);
            if (!Func_22020_d(l))
            {
                int i1 = Func_22019_c(l);
                i += field_22023_a[i1][0];
                k += field_22023_a[i1][1];
                if (world.GetBlockId(i, j, k) != blockID)
                {
                    return true;
                }
                l = world.GetBlockMetadata(i, j, k);
            }
            if (!world.worldProvider.Func_28108_d())
            {
                double d = (double)i + 0.5D;
                double d1 = (double)j + 0.5D;
                double d2 = (double)k + 0.5D;
                world.SetBlockWithNotify(i, j, k, 0);
                int j1 = Func_22019_c(l);
                i += field_22023_a[j1][0];
                k += field_22023_a[j1][1];
                if (world.GetBlockId(i, j, k) == blockID)
                {
                    world.SetBlockWithNotify(i, j, k, 0);
                    d = (d + (double)i + 0.5D) / 2D;
                    d1 = (d1 + (double)j + 0.5D) / 2D;
                    d2 = (d2 + (double)k + 0.5D) / 2D;
                }
                world.NewExplosion(null, (float)i + 0.5F, (float)j + 0.5F, (float)k + 0.5F, 5F, true
                    );
                return true;
            }
            if (Func_22018_f(l))
            {
                net.minecraft.src.EntityPlayer entityplayer1 = null;
                System.Collections.IEnumerator iterator = world.playerEntities.GetEnumerator();
                do
                {
                    if (!iterator.MoveNext())
                    {
                        break;
                    }
                    net.minecraft.src.EntityPlayer entityplayer2 = (net.minecraft.src.EntityPlayer)iterator
                        .Current;
                    if (entityplayer2.IsSleeping())
                    {
                        net.minecraft.src.ChunkCoordinates chunkcoordinates = entityplayer2.playerLocation;
                        if (chunkcoordinates.posX == i && chunkcoordinates.posY == j && chunkcoordinates.
                            posZ == k)
                        {
                            entityplayer1 = entityplayer2;
                        }
                    }
                }
                while (true);
                if (entityplayer1 == null)
                {
                    Func_22022_a(world, i, j, k, false);
                }
                else
                {
                    entityplayer.Func_22061_a("tile.bed.occupied");
                    return true;
                }
            }
            net.minecraft.src.EnumStatus enumstatus = entityplayer.GoToSleep(i, j, k);
            if (enumstatus == net.minecraft.src.EnumStatus.OK)
            {
                Func_22022_a(world, i, j, k, true);
                return true;
            }
            if (enumstatus == net.minecraft.src.EnumStatus.NOT_POSSIBLE_NOW)
            {
                entityplayer.Func_22061_a("tile.bed.noSleep");
            }
            return true;
        }

        public override int GetBlockTextureFromSideAndMetadata(int i, int j)
        {
            if (i == 0)
            {
                return net.minecraft.src.Block.WOOD.blockIndexInTexture;
            }
            int k = Func_22019_c(j);
            int l = net.minecraft.src.ModelBed.field_22155_c[k][i];
            if (Func_22020_d(j))
            {
                if (l == 2)
                {
                    return blockIndexInTexture + 2 + 16;
                }
                if (l == 5 || l == 4)
                {
                    return blockIndexInTexture + 1 + 16;
                }
                else
                {
                    return blockIndexInTexture + 1;
                }
            }
            if (l == 3)
            {
                return (blockIndexInTexture - 1) + 16;
            }
            if (l == 5 || l == 4)
            {
                return blockIndexInTexture + 16;
            }
            else
            {
                return blockIndexInTexture;
            }
        }

        public override bool IsACube()
        {
            return false;
        }

        public override bool IsOpaqueCube()
        {
            return false;
        }

        public override void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
            , int i, int j, int k)
        {
            SetBounds();
        }

        public override void OnNeighborBlockChange(net.minecraft.src.World world, int i,
            int j, int k, int l)
        {
            int i1 = world.GetBlockMetadata(i, j, k);
            int j1 = Func_22019_c(i1);
            if (Func_22020_d(i1))
            {
                if (world.GetBlockId(i - field_22023_a[j1][0], j, k - field_22023_a[j1][1]) != blockID)
                {
                    world.SetBlockWithNotify(i, j, k, 0);
                }
            }
            else
            {
                if (world.GetBlockId(i + field_22023_a[j1][0], j, k + field_22023_a[j1][1]) != blockID)
                {
                    world.SetBlockWithNotify(i, j, k, 0);
                    if (!world.singleplayerWorld)
                    {
                        DropBlockAsItem(world, i, j, k, i1);
                    }
                }
            }
        }

        public override int IdDropped(int i, SharpRandom random)
        {
            if (Func_22020_d(i))
            {
                return 0;
            }
            else
            {
                return net.minecraft.src.Item.bed.shiftedIndex;
            }
        }

        private void SetBounds()
        {
            SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 0.5625F, 1.0F);
        }

        public static int Func_22019_c(int i)
        {
            return i & 3;
        }

        public static bool Func_22020_d(int i)
        {
            return (i & 8) != 0;
        }

        public static bool Func_22018_f(int i)
        {
            return (i & 4) != 0;
        }

        public static void Func_22022_a(net.minecraft.src.World world, int i, int j, int
            k, bool flag)
        {
            int l = world.GetBlockMetadata(i, j, k);
            if (flag)
            {
                l |= 4;
            }
            else
            {
                l &= -5;
            }
            world.SetBlockMetadataWithNotify(i, j, k, l);
        }

        public static net.minecraft.src.ChunkCoordinates Func_22021_g(net.minecraft.src.World
             world, int i, int j, int k, int l)
        {
            int i1 = world.GetBlockMetadata(i, j, k);
            int j1 = Func_22019_c(i1);
            for (int k1 = 0; k1 <= 1; k1++)
            {
                int l1 = i - field_22023_a[j1][0] * k1 - 1;
                int i2 = k - field_22023_a[j1][1] * k1 - 1;
                int j2 = l1 + 2;
                int k2 = i2 + 2;
                for (int l2 = l1; l2 <= j2; l2++)
                {
                    for (int i3 = i2; i3 <= k2; i3++)
                    {
                        if (!world.IsBlockNormalCube(l2, j - 1, i3) || !world.IsAirBlock(l2, j, i3) || !world
                            .IsAirBlock(l2, j + 1, i3))
                        {
                            continue;
                        }
                        if (l > 0)
                        {
                            l--;
                        }
                        else
                        {
                            return new net.minecraft.src.ChunkCoordinates(l2, j, i3);
                        }
                    }
                }
            }
            return null;
        }

        public override void DropBlockAsItemWithChance(net.minecraft.src.World world, int
             i, int j, int k, int l, float f)
        {
            if (!Func_22020_d(l))
            {
                base.DropBlockAsItemWithChance(world, i, j, k, l, f);
            }
        }

        public override int GetMobilityFlag()
        {
            return 1;
        }

        public static readonly int[][] field_22023_a = new int[][] { new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 }, new int[] { 1, 0 } };
    }
}
