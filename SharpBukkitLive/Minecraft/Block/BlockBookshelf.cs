// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System;

namespace net.minecraft.src
{
    public class BlockBookshelf : net.minecraft.src.Block
    {
        public BlockBookshelf(int i, int j)
            : base(i, j, net.minecraft.src.Material.wood)
        {
        }

        // Referenced classes of package net.minecraft.src:
        //            Block, Material
        public override int GetBlockTextureFromSide(int i)
        {
            if (i <= 1)
            {
                return 4;
            }
            else
            {
                return blockIndexInTexture;
            }
        }

        public override int QuantityDropped(SharpRandom random)
        {
            return 0;
        }
    }
}
