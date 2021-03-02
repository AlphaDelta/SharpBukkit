// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
    public class BlockRedstoneWire : net.minecraft.src.Block
    {
        public BlockRedstoneWire(int i, int j)
            : base(i, j, net.minecraft.src.Material.circuits)
        {
            // Referenced classes of package net.minecraft.src:
            //            Block, Material, World, ChunkPosition, 
            //            Item, IBlockAccess, ModelBed, AxisAlignedBB
            wiresProvidePower = true;
            field_21032_b = new HashSet<ChunkPosition>();
            SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 0.0625F, 1.0F);
        }

        public override int GetBlockTextureFromSideAndMetadata(int i, int j)
        {
            return blockIndexInTexture;
        }

        public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
             world, int i, int j, int k)
        {
            return null;
        }

        public override bool IsOpaqueCube()
        {
            return false;
        }

        public override bool IsACube()
        {
            return false;
        }

        public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j,
            int k)
        {
            return world.IsBlockNormalCube(i, j - 1, k);
        }

        private void UpdateAndPropagateCurrentStrength(net.minecraft.src.World world, int
             i, int j, int k)
        {
            Func_21031_a(world, i, j, k, i, j, k);
            List<ChunkPosition> arraylist = new List<ChunkPosition>(field_21032_b);
            field_21032_b.Clear();
            for (int l = 0; l < arraylist.Count; l++)
            {
                net.minecraft.src.ChunkPosition chunkposition = (net.minecraft.src.ChunkPosition)
                    arraylist[l];
                world.NotifyBlocksOfNeighborChange(chunkposition.x, chunkposition.y, chunkposition
                    .z, ID);
            }
        }

        private void Func_21031_a(net.minecraft.src.World world, int i, int j, int k, int
             l, int i1, int j1)
        {
            int k1 = world.GetBlockMetadata(i, j, k);
            int l1 = 0;
            wiresProvidePower = false;
            bool flag = world.IsBlockIndirectlyGettingPowered(i, j, k);
            wiresProvidePower = true;
            if (flag)
            {
                l1 = 15;
            }
            else
            {
                for (int i2 = 0; i2 < 4; i2++)
                {
                    int k2 = i;
                    int i3 = k;
                    if (i2 == 0)
                    {
                        k2--;
                    }
                    if (i2 == 1)
                    {
                        k2++;
                    }
                    if (i2 == 2)
                    {
                        i3--;
                    }
                    if (i2 == 3)
                    {
                        i3++;
                    }
                    if (k2 != l || j != i1 || i3 != j1)
                    {
                        l1 = GetMaxCurrentStrength(world, k2, j, i3, l1);
                    }
                    if (world.IsBlockNormalCube(k2, j, i3) && !world.IsBlockNormalCube(i, j + 1, k))
                    {
                        if (k2 != l || j + 1 != i1 || i3 != j1)
                        {
                            l1 = GetMaxCurrentStrength(world, k2, j + 1, i3, l1);
                        }
                        continue;
                    }
                    if (!world.IsBlockNormalCube(k2, j, i3) && (k2 != l || j - 1 != i1 || i3 != j1))
                    {
                        l1 = GetMaxCurrentStrength(world, k2, j - 1, i3, l1);
                    }
                }
                if (l1 > 0)
                {
                    l1--;
                }
                else
                {
                    l1 = 0;
                }
            }
            if (k1 != l1)
            {
                world.editingBlocks = true;
                world.SetBlockMetadataWithNotify(i, j, k, l1);
                world.MarkBlocksDirty(i, j, k, i, j, k);
                world.editingBlocks = false;
                for (int j2 = 0; j2 < 4; j2++)
                {
                    int l2 = i;
                    int j3 = k;
                    int k3 = j - 1;
                    if (j2 == 0)
                    {
                        l2--;
                    }
                    if (j2 == 1)
                    {
                        l2++;
                    }
                    if (j2 == 2)
                    {
                        j3--;
                    }
                    if (j2 == 3)
                    {
                        j3++;
                    }
                    if (world.IsBlockNormalCube(l2, j, j3))
                    {
                        k3 += 2;
                    }
                    int l3 = 0;
                    l3 = GetMaxCurrentStrength(world, l2, j, j3, -1);
                    l1 = world.GetBlockMetadata(i, j, k);
                    if (l1 > 0)
                    {
                        l1--;
                    }
                    if (l3 >= 0 && l3 != l1)
                    {
                        Func_21031_a(world, l2, j, j3, i, j, k);
                    }
                    l3 = GetMaxCurrentStrength(world, l2, k3, j3, -1);
                    l1 = world.GetBlockMetadata(i, j, k);
                    if (l1 > 0)
                    {
                        l1--;
                    }
                    if (l3 >= 0 && l3 != l1)
                    {
                        Func_21031_a(world, l2, k3, j3, i, j, k);
                    }
                }
                if (k1 == 0 || l1 == 0)
                {
                    field_21032_b.Add(new net.minecraft.src.ChunkPosition(i, j, k));
                    field_21032_b.Add(new net.minecraft.src.ChunkPosition(i - 1, j, k));
                    field_21032_b.Add(new net.minecraft.src.ChunkPosition(i + 1, j, k));
                    field_21032_b.Add(new net.minecraft.src.ChunkPosition(i, j - 1, k));
                    field_21032_b.Add(new net.minecraft.src.ChunkPosition(i, j + 1, k));
                    field_21032_b.Add(new net.minecraft.src.ChunkPosition(i, j, k - 1));
                    field_21032_b.Add(new net.minecraft.src.ChunkPosition(i, j, k + 1));
                }
            }
        }

        private void NotifyWireNeighborsOfNeighborChange(net.minecraft.src.World world, int
             i, int j, int k)
        {
            if (world.GetBlockId(i, j, k) != ID)
            {
                return;
            }
            else
            {
                world.NotifyBlocksOfNeighborChange(i, j, k, ID);
                world.NotifyBlocksOfNeighborChange(i - 1, j, k, ID);
                world.NotifyBlocksOfNeighborChange(i + 1, j, k, ID);
                world.NotifyBlocksOfNeighborChange(i, j, k - 1, ID);
                world.NotifyBlocksOfNeighborChange(i, j, k + 1, ID);
                world.NotifyBlocksOfNeighborChange(i, j - 1, k, ID);
                world.NotifyBlocksOfNeighborChange(i, j + 1, k, ID);
                return;
            }
        }

        public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
             k)
        {
            base.OnBlockAdded(world, i, j, k);
            if (world.singleplayerWorld)
            {
                return;
            }
            UpdateAndPropagateCurrentStrength(world, i, j, k);
            world.NotifyBlocksOfNeighborChange(i, j + 1, k, ID);
            world.NotifyBlocksOfNeighborChange(i, j - 1, k, ID);
            NotifyWireNeighborsOfNeighborChange(world, i - 1, j, k);
            NotifyWireNeighborsOfNeighborChange(world, i + 1, j, k);
            NotifyWireNeighborsOfNeighborChange(world, i, j, k - 1);
            NotifyWireNeighborsOfNeighborChange(world, i, j, k + 1);
            if (world.IsBlockNormalCube(i - 1, j, k))
            {
                NotifyWireNeighborsOfNeighborChange(world, i - 1, j + 1, k);
            }
            else
            {
                NotifyWireNeighborsOfNeighborChange(world, i - 1, j - 1, k);
            }
            if (world.IsBlockNormalCube(i + 1, j, k))
            {
                NotifyWireNeighborsOfNeighborChange(world, i + 1, j + 1, k);
            }
            else
            {
                NotifyWireNeighborsOfNeighborChange(world, i + 1, j - 1, k);
            }
            if (world.IsBlockNormalCube(i, j, k - 1))
            {
                NotifyWireNeighborsOfNeighborChange(world, i, j + 1, k - 1);
            }
            else
            {
                NotifyWireNeighborsOfNeighborChange(world, i, j - 1, k - 1);
            }
            if (world.IsBlockNormalCube(i, j, k + 1))
            {
                NotifyWireNeighborsOfNeighborChange(world, i, j + 1, k + 1);
            }
            else
            {
                NotifyWireNeighborsOfNeighborChange(world, i, j - 1, k + 1);
            }
        }

        public override void OnBlockRemoval(net.minecraft.src.World world, int i, int j,
            int k)
        {
            base.OnBlockRemoval(world, i, j, k);
            if (world.singleplayerWorld)
            {
                return;
            }
            world.NotifyBlocksOfNeighborChange(i, j + 1, k, ID);
            world.NotifyBlocksOfNeighborChange(i, j - 1, k, ID);
            UpdateAndPropagateCurrentStrength(world, i, j, k);
            NotifyWireNeighborsOfNeighborChange(world, i - 1, j, k);
            NotifyWireNeighborsOfNeighborChange(world, i + 1, j, k);
            NotifyWireNeighborsOfNeighborChange(world, i, j, k - 1);
            NotifyWireNeighborsOfNeighborChange(world, i, j, k + 1);
            if (world.IsBlockNormalCube(i - 1, j, k))
            {
                NotifyWireNeighborsOfNeighborChange(world, i - 1, j + 1, k);
            }
            else
            {
                NotifyWireNeighborsOfNeighborChange(world, i - 1, j - 1, k);
            }
            if (world.IsBlockNormalCube(i + 1, j, k))
            {
                NotifyWireNeighborsOfNeighborChange(world, i + 1, j + 1, k);
            }
            else
            {
                NotifyWireNeighborsOfNeighborChange(world, i + 1, j - 1, k);
            }
            if (world.IsBlockNormalCube(i, j, k - 1))
            {
                NotifyWireNeighborsOfNeighborChange(world, i, j + 1, k - 1);
            }
            else
            {
                NotifyWireNeighborsOfNeighborChange(world, i, j - 1, k - 1);
            }
            if (world.IsBlockNormalCube(i, j, k + 1))
            {
                NotifyWireNeighborsOfNeighborChange(world, i, j + 1, k + 1);
            }
            else
            {
                NotifyWireNeighborsOfNeighborChange(world, i, j - 1, k + 1);
            }
        }

        private int GetMaxCurrentStrength(net.minecraft.src.World world, int i, int j, int
             k, int l)
        {
            if (world.GetBlockId(i, j, k) != ID)
            {
                return l;
            }
            int i1 = world.GetBlockMetadata(i, j, k);
            if (i1 > l)
            {
                return i1;
            }
            else
            {
                return l;
            }
        }

        public override void OnNeighborBlockChange(net.minecraft.src.World world, int i,
            int j, int k, int l)
        {
            if (world.singleplayerWorld)
            {
                return;
            }
            int i1 = world.GetBlockMetadata(i, j, k);
            bool flag = CanPlaceBlockAt(world, i, j, k);
            if (!flag)
            {
                DropBlockAsItem(world, i, j, k, i1);
                world.SetBlockWithNotify(i, j, k, 0);
            }
            else
            {
                UpdateAndPropagateCurrentStrength(world, i, j, k);
            }
            base.OnNeighborBlockChange(world, i, j, k, l);
        }

        public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
        {
            return net.minecraft.src.Item.REDSTONE.ID;
        }

        public override bool IsIndirectlyPoweringTo(net.minecraft.src.World world, int i,
            int j, int k, int l)
        {
            if (!wiresProvidePower)
            {
                return false;
            }
            else
            {
                return IsPoweringTo(world, i, j, k, l);
            }
        }

        public override bool IsPoweringTo(net.minecraft.src.IBlockAccess iblockaccess, int
             i, int j, int k, int l)
        {
            if (!wiresProvidePower)
            {
                return false;
            }
            if (iblockaccess.GetBlockMetadata(i, j, k) == 0)
            {
                return false;
            }
            if (l == 1)
            {
                return true;
            }
            bool flag = IsPowerProviderOrWire(iblockaccess, i - 1, j, k, 1) || !iblockaccess.
                IsBlockNormalCube(i - 1, j, k) && IsPowerProviderOrWire(iblockaccess, i - 1, j -
                 1, k, -1);
            bool flag1 = IsPowerProviderOrWire(iblockaccess, i + 1, j, k, 3) || !iblockaccess
                .IsBlockNormalCube(i + 1, j, k) && IsPowerProviderOrWire(iblockaccess, i + 1, j
                - 1, k, -1);
            bool flag2 = IsPowerProviderOrWire(iblockaccess, i, j, k - 1, 2) || !iblockaccess
                .IsBlockNormalCube(i, j, k - 1) && IsPowerProviderOrWire(iblockaccess, i, j - 1,
                k - 1, -1);
            bool flag3 = IsPowerProviderOrWire(iblockaccess, i, j, k + 1, 0) || !iblockaccess
                .IsBlockNormalCube(i, j, k + 1) && IsPowerProviderOrWire(iblockaccess, i, j - 1,
                k + 1, -1);
            if (!iblockaccess.IsBlockNormalCube(i, j + 1, k))
            {
                if (iblockaccess.IsBlockNormalCube(i - 1, j, k) && IsPowerProviderOrWire(iblockaccess
                    , i - 1, j + 1, k, -1))
                {
                    flag = true;
                }
                if (iblockaccess.IsBlockNormalCube(i + 1, j, k) && IsPowerProviderOrWire(iblockaccess
                    , i + 1, j + 1, k, -1))
                {
                    flag1 = true;
                }
                if (iblockaccess.IsBlockNormalCube(i, j, k - 1) && IsPowerProviderOrWire(iblockaccess
                    , i, j + 1, k - 1, -1))
                {
                    flag2 = true;
                }
                if (iblockaccess.IsBlockNormalCube(i, j, k + 1) && IsPowerProviderOrWire(iblockaccess
                    , i, j + 1, k + 1, -1))
                {
                    flag3 = true;
                }
            }
            if (!flag2 && !flag1 && !flag && !flag3 && l >= 2 && l <= 5)
            {
                return true;
            }
            if (l == 2 && flag2 && !flag && !flag1)
            {
                return true;
            }
            if (l == 3 && flag3 && !flag && !flag1)
            {
                return true;
            }
            if (l == 4 && flag && !flag2 && !flag3)
            {
                return true;
            }
            return l == 5 && flag1 && !flag2 && !flag3;
        }

        public override bool CanProvidePower()
        {
            return wiresProvidePower;
        }

        public static bool IsPowerProviderOrWire(net.minecraft.src.IBlockAccess iblockaccess
            , int i, int j, int k, int l)
        {
            int i1 = iblockaccess.GetBlockId(i, j, k);
            if (i1 == net.minecraft.src.Block.REDSTONE_WIRE.ID)
            {
                return true;
            }
            if (i1 == 0)
            {
                return false;
            }
            if (net.minecraft.src.Block.blocksList[i1].CanProvidePower())
            {
                return true;
            }
            if (i1 == net.minecraft.src.Block.DIODE_OFF.ID || i1 == net.minecraft.src.Block
                .DIODE_ON.ID)
            {
                int j1 = iblockaccess.GetBlockMetadata(i, j, k);
                return l == net.minecraft.src.ModelBed.field_22153_b[j1 & 3];
            }
            else
            {
                return false;
            }
        }

        private bool wiresProvidePower;

        private HashSet<ChunkPosition> field_21032_b;
    }
}
