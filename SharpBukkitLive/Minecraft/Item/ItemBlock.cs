// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemBlock : net.minecraft.src.Item
	{
		public ItemBlock(int i)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, Block, World, ItemStack, 
			//            Material, StepSound, EntityPlayer
			blockID = i + 256;
			SetIconIndex(net.minecraft.src.Block.blocksList[i + 256].GetBlockTextureFromSide(
				2));
		}

		public override bool OnItemUse(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityPlayer
			 entityplayer, net.minecraft.src.World world, int i, int j, int k, int l)
		{
			if (world.GetBlockId(i, j, k) == net.minecraft.src.Block.SNOW.ID)
			{
				l = 0;
			}
			else
			{
				if (l == 0)
				{
					j--;
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
			}
			if (itemstack.stackSize == 0)
			{
				return false;
			}
			if (j == 127 && net.minecraft.src.Block.blocksList[blockID].blockMaterial.IsSolid
				())
			{
				return false;
			}
			if (world.CanBlockBePlacedAt(blockID, i, j, k, false, l))
			{
				net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[blockID];
				if (world.SetBlockAndMetadataWithNotify(i, j, k, blockID, GetMetadata(itemstack.GetItemDamage
					())))
				{
					net.minecraft.src.Block.blocksList[blockID].OnBlockPlaced(world, i, j, k, l);
					net.minecraft.src.Block.blocksList[blockID].OnBlockPlacedBy(world, i, j, k, entityplayer
						);
					world.PlaySoundEffect((float)i + 0.5F, (float)j + 0.5F, (float)k + 0.5F, block.stepSound
						.Func_737_c(), (block.stepSound.GetVolume() + 1.0F) / 2.0F, block.stepSound.GetPitch
						() * 0.8F);
					itemstack.stackSize--;
				}
				return true;
			}
			else
			{
				return false;
			}
		}

		public override string GetItemName()
		{
			return net.minecraft.src.Block.blocksList[blockID].GetBlockName();
		}

		private int blockID;
	}
}
