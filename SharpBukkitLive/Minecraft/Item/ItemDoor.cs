// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemDoor : net.minecraft.src.Item
	{
		public ItemDoor(int i, net.minecraft.src.Material material)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, Material, Block, EntityPlayer, 
			//            MathHelper, World, ItemStack
			field_260_a = material;
			maxStackSize = 1;
		}

		public override bool OnItemUse(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityPlayer
			 entityplayer, net.minecraft.src.World world, int i, int j, int k, int l)
		{
			if (l != 1)
			{
				return false;
			}
			j++;
			net.minecraft.src.Block block;
			if (field_260_a == net.minecraft.src.Material.wood)
			{
				block = net.minecraft.src.Block.WOODEN_DOOR;
			}
			else
			{
				block = net.minecraft.src.Block.IRON_DOOR_BLOCK;
			}
			if (!block.CanPlaceBlockAt(world, i, j, k))
			{
				return false;
			}
			int i1 = net.minecraft.src.MathHelper.Floor_double((double)(((entityplayer.rotationYaw
				 + 180F) * 4F) / 360F) - 0.5D) & 3;
			byte byte0 = 0;
			byte byte1 = 0;
			if (i1 == 0)
			{
				byte1 = 1;
			}
			if (i1 == 1)
			{
				byte0 = unchecked((byte)(-1));
			}
			if (i1 == 2)
			{
				byte1 = unchecked((byte)(-1));
			}
			if (i1 == 3)
			{
				byte0 = 1;
			}
			int j1 = (world.IsBlockNormalCube(i - byte0, j, k - byte1) ? 1 : 0) + (world.IsBlockNormalCube
				(i - byte0, j + 1, k - byte1) ? 1 : 0);
			int k1 = (world.IsBlockNormalCube(i + byte0, j, k + byte1) ? 1 : 0) + (world.IsBlockNormalCube
				(i + byte0, j + 1, k + byte1) ? 1 : 0);
			bool flag = world.GetBlockId(i - byte0, j, k - byte1) == block.ID || world.GetBlockId
				(i - byte0, j + 1, k - byte1) == block.ID;
			bool flag1 = world.GetBlockId(i + byte0, j, k + byte1) == block.ID || world.
				GetBlockId(i + byte0, j + 1, k + byte1) == block.ID;
			bool flag2 = false;
			if (flag && !flag1)
			{
				flag2 = true;
			}
			else
			{
				if (k1 > j1)
				{
					flag2 = true;
				}
			}
			if (flag2)
			{
				i1 = i1 - 1 & 3;
				i1 += 4;
			}
			world.editingBlocks = true;
			world.SetBlockAndMetadataWithNotify(i, j, k, block.ID, i1);
			world.SetBlockAndMetadataWithNotify(i, j + 1, k, block.ID, i1 + 8);
			world.editingBlocks = false;
			world.NotifyBlocksOfNeighborChange(i, j, k, block.ID);
			world.NotifyBlocksOfNeighborChange(i, j + 1, k, block.ID);
			itemstack.stackSize--;
			return true;
		}

		private net.minecraft.src.Material field_260_a;
	}
}
