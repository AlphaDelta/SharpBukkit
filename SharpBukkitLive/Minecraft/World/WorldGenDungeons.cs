// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldGenDungeons : net.minecraft.src.WorldGenerator
	{
		public WorldGenDungeons()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            WorldGenerator, World, Material, Block, 
		//            TileEntityChest, TileEntityMobSpawner, ItemStack, Item
		public override bool Generate(net.minecraft.src.World world, SharpBukkitLive.SharpBukkit.SharpRandom random
			, int i, int j, int k)
		{
			byte byte0 = 3;
			int l = random.Next(2) + 2;
			int i1 = random.Next(2) + 2;
			int j1 = 0;
			for (int k1 = i - l - 1; k1 <= i + l + 1; k1++)
			{
				for (int j2 = j - 1; j2 <= j + byte0 + 1; j2++)
				{
					for (int i3 = k - i1 - 1; i3 <= k + i1 + 1; i3++)
					{
						net.minecraft.src.Material material = world.GetBlockMaterial(k1, j2, i3);
						if (j2 == j - 1 && !material.IsSolid())
						{
							return false;
						}
						if (j2 == j + byte0 + 1 && !material.IsSolid())
						{
							return false;
						}
						if ((k1 == i - l - 1 || k1 == i + l + 1 || i3 == k - i1 - 1 || i3 == k + i1 + 1) 
							&& j2 == j && world.IsAirBlock(k1, j2, i3) && world.IsAirBlock(k1, j2 + 1, i3))
						{
							j1++;
						}
					}
				}
			}
			if (j1 < 1 || j1 > 5)
			{
				return false;
			}
			for (int l1 = i - l - 1; l1 <= i + l + 1; l1++)
			{
				for (int k2 = j + byte0; k2 >= j - 1; k2--)
				{
					for (int j3 = k - i1 - 1; j3 <= k + i1 + 1; j3++)
					{
						if (l1 == i - l - 1 || k2 == j - 1 || j3 == k - i1 - 1 || l1 == i + l + 1 || k2 ==
							 j + byte0 + 1 || j3 == k + i1 + 1)
						{
							if (k2 >= 0 && !world.GetBlockMaterial(l1, k2 - 1, j3).IsSolid())
							{
								world.SetBlockWithNotify(l1, k2, j3, 0);
								continue;
							}
							if (!world.GetBlockMaterial(l1, k2, j3).IsSolid())
							{
								continue;
							}
							if (k2 == j - 1 && random.Next(4) != 0)
							{
								world.SetBlockWithNotify(l1, k2, j3, net.minecraft.src.Block.MOSSY_COBBLESTONE.ID
									);
							}
							else
							{
								world.SetBlockWithNotify(l1, k2, j3, net.minecraft.src.Block.COBBLESTONE.ID);
							}
						}
						else
						{
							world.SetBlockWithNotify(l1, k2, j3, 0);
						}
					}
				}
			}
			for (int i2 = 0; i2 < 2; i2++)
			{
				for (int l2 = 0; l2 < 3; l2++)
				{
					int k3 = (i + random.Next(l * 2 + 1)) - l;
					int l3 = j;
					int i4 = (k + random.Next(i1 * 2 + 1)) - i1;
					if (!world.IsAirBlock(k3, l3, i4))
					{
						continue;
					}
					int j4 = 0;
					if (world.GetBlockMaterial(k3 - 1, l3, i4).IsSolid())
					{
						j4++;
					}
					if (world.GetBlockMaterial(k3 + 1, l3, i4).IsSolid())
					{
						j4++;
					}
					if (world.GetBlockMaterial(k3, l3, i4 - 1).IsSolid())
					{
						j4++;
					}
					if (world.GetBlockMaterial(k3, l3, i4 + 1).IsSolid())
					{
						j4++;
					}
					if (j4 != 1)
					{
						continue;
					}
					world.SetBlockWithNotify(k3, l3, i4, net.minecraft.src.Block.CHEST.ID);
					net.minecraft.src.TileEntityChest tileentitychest = (net.minecraft.src.TileEntityChest
						)world.GetBlockTileEntity(k3, l3, i4);
					int k4 = 0;
					do
					{
						if (k4 >= 8)
						{
							goto label0_break;
						}
						net.minecraft.src.ItemStack itemstack = PickCheckLootItem(random);
						if (itemstack != null)
						{
							tileentitychest.SetInventorySlotContents(random.Next(tileentitychest.GetSizeInventory
								()), itemstack);
						}
						k4++;
					}
					while (true);
label0_continue: ;
				}
label0_break: ;
			}
			world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.MOB_SPAWNER.ID);
			net.minecraft.src.TileEntityMobSpawner tileentitymobspawner = (net.minecraft.src.TileEntityMobSpawner
				)world.GetBlockTileEntity(i, j, k);
			tileentitymobspawner.SetMobID(PickMobSpawner(random));
			return true;
		}

		private net.minecraft.src.ItemStack PickCheckLootItem(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			int i = random.Next(11);
			if (i == 0)
			{
				return new net.minecraft.src.ItemStack(net.minecraft.src.Item.SADDLE);
			}
			if (i == 1)
			{
				return new net.minecraft.src.ItemStack(net.minecraft.src.Item.IRON_INGOT, random.NextInt
					(4) + 1);
			}
			if (i == 2)
			{
				return new net.minecraft.src.ItemStack(net.minecraft.src.Item.BREAD);
			}
			if (i == 3)
			{
				return new net.minecraft.src.ItemStack(net.minecraft.src.Item.WHEAT, random.NextInt
					(4) + 1);
			}
			if (i == 4)
			{
				return new net.minecraft.src.ItemStack(net.minecraft.src.Item.SULPHUR, random.NextInt
					(4) + 1);
			}
			if (i == 5)
			{
				return new net.minecraft.src.ItemStack(net.minecraft.src.Item.STRING, random.NextInt
					(4) + 1);
			}
			if (i == 6)
			{
				return new net.minecraft.src.ItemStack(net.minecraft.src.Item.BUCKET);
			}
			if (i == 7 && random.Next(100) == 0)
			{
				return new net.minecraft.src.ItemStack(net.minecraft.src.Item.GOLDEN_APPLE);
			}
			if (i == 8 && random.Next(2) == 0)
			{
				return new net.minecraft.src.ItemStack(net.minecraft.src.Item.REDSTONE, random.NextInt
					(4) + 1);
			}
			if (i == 9 && random.Next(10) == 0)
			{
				return new net.minecraft.src.ItemStack(net.minecraft.src.Item.itemsList[net.minecraft.src.Item
					.GOLD_RECORD.ID + random.Next(2)]);
			}
			if (i == 10)
			{
				return new net.minecraft.src.ItemStack(net.minecraft.src.Item.INK_SACK, 1, 3);
			}
			else
			{
				return null;
			}
		}

		private string PickMobSpawner(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			int i = random.Next(4);
			if (i == 0)
			{
				return "Skeleton";
			}
			if (i == 1)
			{
				return "Zombie";
			}
			if (i == 2)
			{
				return "Zombie";
			}
			if (i == 3)
			{
				return "Spider";
			}
			else
			{
				return string.Empty;
			}
		}
	}
}
