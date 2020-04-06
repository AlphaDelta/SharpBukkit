// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System;

namespace net.minecraft.src
{
    public class BlockCactus : net.minecraft.src.Block
    {
        protected internal BlockCactus(int i, int j)
            : base(i, j, net.minecraft.src.Material.cactus)
        {
            // Referenced classes of package net.minecraft.src:
            //            Block, Material, World, AxisAlignedBB, 
            //            Entity
            SetTickOnLoad(true);
        }

        public override void UpdateTick(net.minecraft.src.World world, int i, int j, int
            k, SharpRandom random)
        {
            if (world.IsAirBlock(i, j + 1, k))
            {
                int l;
                for (l = 1; world.GetBlockId(i, j - l, k) == blockID; l++)
                {
                }
                if (l < 3)
                {
                    int i1 = world.GetBlockMetadata(i, j, k);
                    if (i1 == 15)
                    {
                        world.SetBlockWithNotify(i, j + 1, k, blockID);
                        world.SetBlockMetadataWithNotify(i, j, k, 0);
                    }
                    else
                    {
                        world.SetBlockMetadataWithNotify(i, j, k, i1 + 1);
                    }
                }
            }
        }

        public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
             world, int i, int j, int k)
        {
            float f = 0.0625F;
            return net.minecraft.src.AxisAlignedBB.GetBoundingBoxFromPool((float)i + f, j, (float
                )k + f, (float)(i + 1) - f, (float)(j + 1) - f, (float)(k + 1) - f);
        }

        public override int GetBlockTextureFromSide(int i)
        {
            if (i == 1)
            {
                return blockIndexInTexture - 1;
            }
            if (i == 0)
            {
                return blockIndexInTexture + 1;
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

        public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j,
            int k)
        {
            if (!base.CanPlaceBlockAt(world, i, j, k))
            {
                return false;
            }
            else
            {
                return CanBlockStay(world, i, j, k);
            }
        }

        public override void OnNeighborBlockChange(net.minecraft.src.World world, int i,
            int j, int k, int l)
        {
            if (!CanBlockStay(world, i, j, k))
            {
                DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
                world.SetBlockWithNotify(i, j, k, 0);
            }
        }

        public override bool CanBlockStay(net.minecraft.src.World world, int i, int j, int
             k)
        {
            if (world.GetBlockMaterial(i - 1, j, k).IsSolid())
            {
                return false;
            }
            if (world.GetBlockMaterial(i + 1, j, k).IsSolid())
            {
                return false;
            }
            if (world.GetBlockMaterial(i, j, k - 1).IsSolid())
            {
                return false;
            }
            if (world.GetBlockMaterial(i, j, k + 1).IsSolid())
            {
                return false;
            }
            else
            {
                int l = world.GetBlockId(i, j - 1, k);
                return l == net.minecraft.src.Block.cactus.blockID || l == net.minecraft.src.Block
                    .sand.blockID;
            }
        }

        public override void OnEntityCollidedWithBlock(net.minecraft.src.World world, int
             i, int j, int k, net.minecraft.src.Entity entity)
        {
            entity.AttackEntityFrom(null, 1);
        }
    }
}
