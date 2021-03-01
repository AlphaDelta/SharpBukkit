// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class ItemSign : net.minecraft.src.Item
    {
        public ItemSign(int i)
            : base(i)
        {
            // Referenced classes of package net.minecraft.src:
            //            Item, World, Material, Block, 
            //            EntityPlayer, MathHelper, ItemStack, TileEntitySign
            maxStackSize = 1;
        }

        public override bool OnItemUse(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityPlayer entityplayer, net.minecraft.src.World world, int i, int j, int k, int l)
        {
            if (l == 0)
            {
                return false;
            }
            if (!world.GetBlockMaterial(i, j, k).IsSolid())
            {
                return false;
            }
            if (l == 1)
            {
                j++;
            }
            if (l == 2)
            {
                k--;
            }
            if (l == 3)
            {
                k++;
            }
            if (l == 4)
            {
                i--;
            }
            if (l == 5)
            {
                i++;
            }
            if (!net.minecraft.src.Block.SIGN_POST.CanPlaceBlockAt(world, i, j, k))
            {
                return false;
            }
            if (l == 1)
            {
                world.SetBlockAndMetadataWithNotify(
                    i, j, k,
                    net.minecraft.src.Block.SIGN_POST.blockID,
                    net.minecraft.src.MathHelper.Floor_double((double)(((entityplayer.rotationYaw + 180F) * 16F) / 360F) + 0.5D) & 0xf);
            }
            else
            {
                world.SetBlockAndMetadataWithNotify(i, j, k, net.minecraft.src.Block.WALL_SIGN.blockID, l);
            }
            itemstack.stackSize--;
            net.minecraft.src.TileEntitySign tileentitysign = (net.minecraft.src.TileEntitySign
                )world.GetBlockTileEntity(i, j, k);
            if (tileentitysign != null)
            {
                entityplayer.DisplayGUIEditSign(tileentitysign);
            }
            return true;
        }
    }
}
