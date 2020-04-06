// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System;

namespace net.minecraft.src
{
    public class BlockButton : net.minecraft.src.Block
    {
        protected internal BlockButton(int i, int j)
            : base(i, j, net.minecraft.src.Material.circuits)
        {
            // Referenced classes of package net.minecraft.src:
            //            Block, Material, World, IBlockAccess, 
            //            AxisAlignedBB, EntityPlayer
            SetTickOnLoad(true);
        }

        public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
             world, int i, int j, int k)
        {
            return null;
        }

        public override int TickRate()
        {
            return 20;
        }

        public override bool IsOpaqueCube()
        {
            return false;
        }

        public override bool IsACube()
        {
            return false;
        }

        public override bool CanPlaceBlockOnSide(net.minecraft.src.World world, int i, int
             j, int k, int l)
        {
            if (l == 2 && world.IsBlockNormalCube(i, j, k + 1))
            {
                return true;
            }
            if (l == 3 && world.IsBlockNormalCube(i, j, k - 1))
            {
                return true;
            }
            if (l == 4 && world.IsBlockNormalCube(i + 1, j, k))
            {
                return true;
            }
            return l == 5 && world.IsBlockNormalCube(i - 1, j, k);
        }

        public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j,
            int k)
        {
            if (world.IsBlockNormalCube(i - 1, j, k))
            {
                return true;
            }
            if (world.IsBlockNormalCube(i + 1, j, k))
            {
                return true;
            }
            if (world.IsBlockNormalCube(i, j, k - 1))
            {
                return true;
            }
            return world.IsBlockNormalCube(i, j, k + 1);
        }

        public override void OnBlockPlaced(net.minecraft.src.World world, int i, int j, int
             k, int l)
        {
            int i1 = world.GetBlockMetadata(i, j, k);
            int j1 = i1 & 8;
            i1 &= 7;
            if (l == 2 && world.IsBlockNormalCube(i, j, k + 1))
            {
                i1 = 4;
            }
            else
            {
                if (l == 3 && world.IsBlockNormalCube(i, j, k - 1))
                {
                    i1 = 3;
                }
                else
                {
                    if (l == 4 && world.IsBlockNormalCube(i + 1, j, k))
                    {
                        i1 = 2;
                    }
                    else
                    {
                        if (l == 5 && world.IsBlockNormalCube(i - 1, j, k))
                        {
                            i1 = 1;
                        }
                        else
                        {
                            i1 = GetOrientation(world, i, j, k);
                        }
                    }
                }
            }
            world.SetBlockMetadataWithNotify(i, j, k, i1 + j1);
        }

        private int GetOrientation(net.minecraft.src.World world, int i, int j, int k)
        {
            if (world.IsBlockNormalCube(i - 1, j, k))
            {
                return 1;
            }
            if (world.IsBlockNormalCube(i + 1, j, k))
            {
                return 2;
            }
            if (world.IsBlockNormalCube(i, j, k - 1))
            {
                return 3;
            }
            return !world.IsBlockNormalCube(i, j, k + 1) ? 1 : 4;
        }

        public override void OnNeighborBlockChange(net.minecraft.src.World world, int i,
            int j, int k, int l)
        {
            if (Func_322_g(world, i, j, k))
            {
                int i1 = world.GetBlockMetadata(i, j, k) & 7;
                bool flag = false;
                if (!world.IsBlockNormalCube(i - 1, j, k) && i1 == 1)
                {
                    flag = true;
                }
                if (!world.IsBlockNormalCube(i + 1, j, k) && i1 == 2)
                {
                    flag = true;
                }
                if (!world.IsBlockNormalCube(i, j, k - 1) && i1 == 3)
                {
                    flag = true;
                }
                if (!world.IsBlockNormalCube(i, j, k + 1) && i1 == 4)
                {
                    flag = true;
                }
                if (flag)
                {
                    DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
                    world.SetBlockWithNotify(i, j, k, 0);
                }
            }
        }

        private bool Func_322_g(net.minecraft.src.World world, int i, int j, int k)
        {
            if (!CanPlaceBlockAt(world, i, j, k))
            {
                DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
                world.SetBlockWithNotify(i, j, k, 0);
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
            , int i, int j, int k)
        {
            int l = iblockaccess.GetBlockMetadata(i, j, k);
            int i1 = l & 7;
            bool flag = (l & 8) > 0;
            float f = 0.375F;
            float f1 = 0.625F;
            float f2 = 0.1875F;
            float f3 = 0.125F;
            if (flag)
            {
                f3 = 0.0625F;
            }
            if (i1 == 1)
            {
                SetBlockBounds(0.0F, f, 0.5F - f2, f3, f1, 0.5F + f2);
            }
            else
            {
                if (i1 == 2)
                {
                    SetBlockBounds(1.0F - f3, f, 0.5F - f2, 1.0F, f1, 0.5F + f2);
                }
                else
                {
                    if (i1 == 3)
                    {
                        SetBlockBounds(0.5F - f2, f, 0.0F, 0.5F + f2, f1, f3);
                    }
                    else
                    {
                        if (i1 == 4)
                        {
                            SetBlockBounds(0.5F - f2, f, 1.0F - f3, 0.5F + f2, f1, 1.0F);
                        }
                    }
                }
            }
        }

        public override void OnBlockClicked(net.minecraft.src.World world, int i, int j,
            int k, net.minecraft.src.EntityPlayer entityplayer)
        {
            BlockActivated(world, i, j, k, entityplayer);
        }

        public override bool BlockActivated(net.minecraft.src.World world, int i, int j,
            int k, net.minecraft.src.EntityPlayer entityplayer)
        {
            int l = world.GetBlockMetadata(i, j, k);
            int i1 = l & 7;
            int j1 = 8 - (l & 8);
            if (j1 == 0)
            {
                return true;
            }
            world.SetBlockMetadataWithNotify(i, j, k, i1 + j1);
            world.MarkBlocksDirty(i, j, k, i, j, k);
            world.PlaySoundEffect((double)i + 0.5D, (double)j + 0.5D, (double)k + 0.5D, "random.click"
                , 0.3F, 0.6F);
            world.NotifyBlocksOfNeighborChange(i, j, k, blockID);
            if (i1 == 1)
            {
                world.NotifyBlocksOfNeighborChange(i - 1, j, k, blockID);
            }
            else
            {
                if (i1 == 2)
                {
                    world.NotifyBlocksOfNeighborChange(i + 1, j, k, blockID);
                }
                else
                {
                    if (i1 == 3)
                    {
                        world.NotifyBlocksOfNeighborChange(i, j, k - 1, blockID);
                    }
                    else
                    {
                        if (i1 == 4)
                        {
                            world.NotifyBlocksOfNeighborChange(i, j, k + 1, blockID);
                        }
                        else
                        {
                            world.NotifyBlocksOfNeighborChange(i, j - 1, k, blockID);
                        }
                    }
                }
            }
            world.ScheduleUpdateTick(i, j, k, blockID, TickRate());
            return true;
        }

        public override void OnBlockRemoval(net.minecraft.src.World world, int i, int j,
            int k)
        {
            int l = world.GetBlockMetadata(i, j, k);
            if ((l & 8) > 0)
            {
                world.NotifyBlocksOfNeighborChange(i, j, k, blockID);
                int i1 = l & 7;
                if (i1 == 1)
                {
                    world.NotifyBlocksOfNeighborChange(i - 1, j, k, blockID);
                }
                else
                {
                    if (i1 == 2)
                    {
                        world.NotifyBlocksOfNeighborChange(i + 1, j, k, blockID);
                    }
                    else
                    {
                        if (i1 == 3)
                        {
                            world.NotifyBlocksOfNeighborChange(i, j, k - 1, blockID);
                        }
                        else
                        {
                            if (i1 == 4)
                            {
                                world.NotifyBlocksOfNeighborChange(i, j, k + 1, blockID);
                            }
                            else
                            {
                                world.NotifyBlocksOfNeighborChange(i, j - 1, k, blockID);
                            }
                        }
                    }
                }
            }
            base.OnBlockRemoval(world, i, j, k);
        }

        public override bool IsPoweringTo(net.minecraft.src.IBlockAccess iblockaccess, int
             i, int j, int k, int l)
        {
            return (iblockaccess.GetBlockMetadata(i, j, k) & 8) > 0;
        }

        public override bool IsIndirectlyPoweringTo(net.minecraft.src.World world, int i,
            int j, int k, int l)
        {
            int i1 = world.GetBlockMetadata(i, j, k);
            if ((i1 & 8) == 0)
            {
                return false;
            }
            int j1 = i1 & 7;
            if (j1 == 5 && l == 1)
            {
                return true;
            }
            if (j1 == 4 && l == 2)
            {
                return true;
            }
            if (j1 == 3 && l == 3)
            {
                return true;
            }
            if (j1 == 2 && l == 4)
            {
                return true;
            }
            return j1 == 1 && l == 5;
        }

        public override bool CanProvidePower()
        {
            return true;
        }

        public override void UpdateTick(net.minecraft.src.World world, int i, int j, int
            k, SharpRandom random)
        {
            if (world.singleplayerWorld)
            {
                return;
            }
            int l = world.GetBlockMetadata(i, j, k);
            if ((l & 8) == 0)
            {
                return;
            }
            world.SetBlockMetadataWithNotify(i, j, k, l & 7);
            world.NotifyBlocksOfNeighborChange(i, j, k, blockID);
            int i1 = l & 7;
            if (i1 == 1)
            {
                world.NotifyBlocksOfNeighborChange(i - 1, j, k, blockID);
            }
            else
            {
                if (i1 == 2)
                {
                    world.NotifyBlocksOfNeighborChange(i + 1, j, k, blockID);
                }
                else
                {
                    if (i1 == 3)
                    {
                        world.NotifyBlocksOfNeighborChange(i, j, k - 1, blockID);
                    }
                    else
                    {
                        if (i1 == 4)
                        {
                            world.NotifyBlocksOfNeighborChange(i, j, k + 1, blockID);
                        }
                        else
                        {
                            world.NotifyBlocksOfNeighborChange(i, j - 1, k, blockID);
                        }
                    }
                }
            }
            world.PlaySoundEffect((double)i + 0.5D, (double)j + 0.5D, (double)k + 0.5D, "random.click"
                , 0.3F, 0.5F);
            world.MarkBlocksDirty(i, j, k, i, j, k);
        }
    }
}
