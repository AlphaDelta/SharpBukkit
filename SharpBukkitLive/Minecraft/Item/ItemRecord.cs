// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemRecord : net.minecraft.src.Item
	{
		protected internal ItemRecord(int i, string s)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, World, Block, BlockJukeBox, 
			//            ItemStack, EntityPlayer
			recordName = s;
			maxStackSize = 1;
		}

		public override bool OnItemUse(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityPlayer
			 entityplayer, net.minecraft.src.World world, int i, int j, int k, int l)
		{
			if (world.GetBlockId(i, j, k) == net.minecraft.src.Block.jukebox.blockID && world
				.GetBlockMetadata(i, j, k) == 0)
			{
				if (world.singleplayerWorld)
				{
					return true;
				}
				else
				{
					((net.minecraft.src.BlockJukeBox)net.minecraft.src.Block.jukebox).EjectRecord(world
						, i, j, k, shiftedIndex);
					world.Func_28101_a(null, 1005, i, j, k, shiftedIndex);
					itemstack.stackSize--;
					return true;
				}
			}
			else
			{
				return false;
			}
		}

		public readonly string recordName;
	}
}
