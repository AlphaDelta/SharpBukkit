// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemDye : net.minecraft.src.Item
	{
		public ItemDye(int i)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, ItemStack, World, Block, 
			//            BlockSapling, BlockCrops, BlockGrass, BlockTallGrass, 
			//            BlockFlower, EntitySheep, BlockCloth, EntityPlayer, 
			//            EntityLiving
			SetHasSubtypes(true);
			SetMaxDamage(0);
		}

		public override bool OnItemUse(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityPlayer
			 entityplayer, net.minecraft.src.World world, int i, int j, int k, int l)
		{
			if (itemstack.GetItemDamage() == 15)
			{
				int i1 = world.GetBlockId(i, j, k);
				if (i1 == net.minecraft.src.Block.SAPLING.ID)
				{
					if (!world.singleplayerWorld)
					{
						((net.minecraft.src.BlockSapling)net.minecraft.src.Block.SAPLING).GrowTree(world, 
							i, j, k, world.rand);
						itemstack.stackSize--;
					}
					return true;
				}
				if (i1 == net.minecraft.src.Block.CROPS.ID)
				{
					if (!world.singleplayerWorld)
					{
						((net.minecraft.src.BlockCrops)net.minecraft.src.Block.CROPS).Fertilize(world, i, 
							j, k);
						itemstack.stackSize--;
					}
					return true;
				}
				if (i1 == net.minecraft.src.Block.GRASS.ID)
				{
					if (!world.singleplayerWorld)
					{
						itemstack.stackSize--;
						for (int j1 = 0; j1 < 128; j1++)
						{
							int k1 = i;
							int l1 = j + 1;
							int i2 = k;
							for (int j2 = 0; j2 < j1 / 16; j2++)
							{
								k1 += itemRand.Next(3) - 1;
								l1 += ((itemRand.Next(3) - 1) * itemRand.Next(3)) / 2;
								i2 += itemRand.Next(3) - 1;
								if (world.GetBlockId(k1, l1 - 1, i2) != net.minecraft.src.Block.GRASS.ID || 
									world.IsBlockNormalCube(k1, l1, i2))
								{
									goto label0_continue;
								}
							}
							if (world.GetBlockId(k1, l1, i2) != 0)
							{
								continue;
							}
							if (itemRand.Next(10) != 0)
							{
								world.SetBlockAndMetadataWithNotify(k1, l1, i2, net.minecraft.src.Block.LONG_GRASS
									.ID, 1);
								continue;
							}
							if (itemRand.Next(3) != 0)
							{
								world.SetBlockWithNotify(k1, l1, i2, net.minecraft.src.Block.YELLOW_FLOWER.ID);
							}
							else
							{
								world.SetBlockWithNotify(k1, l1, i2, net.minecraft.src.Block.RED_ROSE.ID);
							}
label0_continue: ;
						}
label0_break: ;
					}
					return true;
				}
			}
			return false;
		}

		public override void SaddleEntity(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityLiving
			 entityliving)
		{
			if (entityliving is net.minecraft.src.EntitySheep)
			{
				net.minecraft.src.EntitySheep entitysheep = (net.minecraft.src.EntitySheep)entityliving;
				int i = net.minecraft.src.BlockCloth.Func_21033_c(itemstack.GetItemDamage());
				if (!entitysheep.Func_21069_f_() && entitysheep.GetFleeceColor() != i)
				{
					entitysheep.SetFleeceColor(i);
					itemstack.stackSize--;
				}
			}
		}

		public static readonly string[] dyeColors = new string[] { "black", "red", "green"
			, "brown", "blue", "purple", "cyan", "silver", "gray", "pink", "lime", "yellow", 
			"lightBlue", "magenta", "orange", "white" };

		public static readonly int[] field_31023_bk = new int[] { 0x1e1b1b, 0xb3312c, 0x3b511a, 0x51301a, 0x253192, 0x7b2fbe, 0x287697, 0x287697, 0x434343, 0xd88198, 0x41cd34, 0xdecf2a, 0x6689d3, 0xc354cd, 0xeb8844, 0xf0f0f0 };
	}
}
