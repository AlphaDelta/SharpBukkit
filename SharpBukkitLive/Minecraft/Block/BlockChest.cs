// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockChest : net.minecraft.src.BlockContainer
	{
		protected internal BlockChest(int i)
			: base(i, net.minecraft.src.Material.wood)
		{
			// Referenced classes of package net.minecraft.src:
			//            BlockContainer, Material, World, TileEntityChest, 
			//            IInventory, ItemStack, EntityItem, InventoryLargeChest, 
			//            EntityPlayer, TileEntity
			random = new SharpBukkitLive.SharpBukkit.SharpRandom();
			blockIndexInTexture = 26;
		}

		public override int GetBlockTextureFromSide(int i)
		{
			if (i == 1)
			{
				return blockIndexInTexture - 1;
			}
			if (i == 0)
			{
				return blockIndexInTexture - 1;
			}
			if (i == 3)
			{
				return blockIndexInTexture + 1;
			}
			else
			{
				return blockIndexInTexture;
			}
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			int l = 0;
			if (world.GetBlockId(i - 1, j, k) == ID)
			{
				l++;
			}
			if (world.GetBlockId(i + 1, j, k) == ID)
			{
				l++;
			}
			if (world.GetBlockId(i, j, k - 1) == ID)
			{
				l++;
			}
			if (world.GetBlockId(i, j, k + 1) == ID)
			{
				l++;
			}
			if (l > 1)
			{
				return false;
			}
			if (IsThereANeighborChest(world, i - 1, j, k))
			{
				return false;
			}
			if (IsThereANeighborChest(world, i + 1, j, k))
			{
				return false;
			}
			if (IsThereANeighborChest(world, i, j, k - 1))
			{
				return false;
			}
			return !IsThereANeighborChest(world, i, j, k + 1);
		}

		private bool IsThereANeighborChest(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			if (world.GetBlockId(i, j, k) != ID)
			{
				return false;
			}
			if (world.GetBlockId(i - 1, j, k) == ID)
			{
				return true;
			}
			if (world.GetBlockId(i + 1, j, k) == ID)
			{
				return true;
			}
			if (world.GetBlockId(i, j, k - 1) == ID)
			{
				return true;
			}
			return world.GetBlockId(i, j, k + 1) == ID;
		}

		public override void OnBlockRemoval(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			net.minecraft.src.TileEntityChest tileentitychest = (net.minecraft.src.TileEntityChest
				)world.GetBlockTileEntity(i, j, k);
			for (int l = 0; l < tileentitychest.GetSizeInventory(); l++)
			{
				net.minecraft.src.ItemStack itemstack = tileentitychest.GetStackInSlot(l);
				if (itemstack == null)
				{
					continue;
				}
				float f = ((float)random.NextDouble()) * 0.8F + 0.1F;
				float f1 = ((float)random.NextDouble()) * 0.8F + 0.1F;
				float f2 = ((float)random.NextDouble()) * 0.8F + 0.1F;
				do
				{
					if (itemstack.stackSize <= 0)
					{
						goto label0_continue;
					}
					int i1 = random.Next(21) + 10;
					if (i1 > itemstack.stackSize)
					{
						i1 = itemstack.stackSize;
					}
					itemstack.stackSize -= i1;
					net.minecraft.src.EntityItem entityitem = new net.minecraft.src.EntityItem(world, 
						(float)i + f, (float)j + f1, (float)k + f2, new net.minecraft.src.ItemStack(itemstack
						.itemID, i1, itemstack.GetItemDamage()));
					float f3 = 0.05F;
					entityitem.motionX = (float)random.NextGaussian() * f3;
					entityitem.motionY = (float)random.NextGaussian() * f3 + 0.2F;
					entityitem.motionZ = (float)random.NextGaussian() * f3;
					world.AddEntity(entityitem);
				}
				while (true);
label0_continue: ;
			}
label0_break: ;
			base.OnBlockRemoval(world, i, j, k);
		}

		public override bool BlockActivated(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			object obj = (net.minecraft.src.TileEntityChest)world.GetBlockTileEntity(i, j, k);
			if (world.IsBlockNormalCube(i, j + 1, k))
			{
				return true;
			}
			if (world.GetBlockId(i - 1, j, k) == ID && world.IsBlockNormalCube(i - 1, j 
				+ 1, k))
			{
				return true;
			}
			if (world.GetBlockId(i + 1, j, k) == ID && world.IsBlockNormalCube(i + 1, j 
				+ 1, k))
			{
				return true;
			}
			if (world.GetBlockId(i, j, k - 1) == ID && world.IsBlockNormalCube(i, j + 1, 
				k - 1))
			{
				return true;
			}
			if (world.GetBlockId(i, j, k + 1) == ID && world.IsBlockNormalCube(i, j + 1, 
				k + 1))
			{
				return true;
			}
			if (world.GetBlockId(i - 1, j, k) == ID)
			{
				obj = new net.minecraft.src.InventoryLargeChest("Large chest", (net.minecraft.src.TileEntityChest
					)world.GetBlockTileEntity(i - 1, j, k), ((net.minecraft.src.IInventory)(obj)));
			}
			if (world.GetBlockId(i + 1, j, k) == ID)
			{
				obj = new net.minecraft.src.InventoryLargeChest("Large chest", ((net.minecraft.src.IInventory
					)(obj)), (net.minecraft.src.TileEntityChest)world.GetBlockTileEntity(i + 1, j, k
					));
			}
			if (world.GetBlockId(i, j, k - 1) == ID)
			{
				obj = new net.minecraft.src.InventoryLargeChest("Large chest", (net.minecraft.src.TileEntityChest
					)world.GetBlockTileEntity(i, j, k - 1), ((net.minecraft.src.IInventory)(obj)));
			}
			if (world.GetBlockId(i, j, k + 1) == ID)
			{
				obj = new net.minecraft.src.InventoryLargeChest("Large chest", ((net.minecraft.src.IInventory
					)(obj)), (net.minecraft.src.TileEntityChest)world.GetBlockTileEntity(i, j, k + 1
					));
			}
			if (world.singleplayerWorld)
			{
				return true;
			}
			else
			{
				entityplayer.DisplayGUIChest(((net.minecraft.src.IInventory)(obj)));
				return true;
			}
		}

		protected internal override net.minecraft.src.TileEntity GetBlockEntity()
		{
			return new net.minecraft.src.TileEntityChest();
		}

		private SharpBukkitLive.SharpBukkit.SharpRandom random;
	}
}
