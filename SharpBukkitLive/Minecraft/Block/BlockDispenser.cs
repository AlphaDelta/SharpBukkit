// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockDispenser : net.minecraft.src.BlockContainer
	{
		protected internal BlockDispenser(int i)
			: base(i, net.minecraft.src.Material.rock)
		{
			// Referenced classes of package net.minecraft.src:
			//            BlockContainer, Material, Block, World, 
			//            TileEntityDispenser, EntityPlayer, ItemStack, Item, 
			//            EntityArrow, EntityEgg, EntitySnowball, EntityItem, 
			//            EntityLiving, MathHelper, IInventory, TileEntity
			field_28032_a = new SharpBukkitLive.SharpBukkit.SharpRandom();
			blockIndexInTexture = 45;
		}

		public override int TickRate()
		{
			return 4;
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Block.dispenser.blockID;
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			base.OnBlockAdded(world, i, j, k);
			SetDispenserDefaultDirection(world, i, j, k);
		}

		private void SetDispenserDefaultDirection(net.minecraft.src.World world, int i, int
			 j, int k)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			int l = world.GetBlockId(i, j, k - 1);
			int i1 = world.GetBlockId(i, j, k + 1);
			int j1 = world.GetBlockId(i - 1, j, k);
			int k1 = world.GetBlockId(i + 1, j, k);
			byte byte0 = 3;
			if (net.minecraft.src.Block.opaqueCubeLookup[l] && !net.minecraft.src.Block.opaqueCubeLookup
				[i1])
			{
				byte0 = 3;
			}
			if (net.minecraft.src.Block.opaqueCubeLookup[i1] && !net.minecraft.src.Block.opaqueCubeLookup
				[l])
			{
				byte0 = 2;
			}
			if (net.minecraft.src.Block.opaqueCubeLookup[j1] && !net.minecraft.src.Block.opaqueCubeLookup
				[k1])
			{
				byte0 = 5;
			}
			if (net.minecraft.src.Block.opaqueCubeLookup[k1] && !net.minecraft.src.Block.opaqueCubeLookup
				[j1])
			{
				byte0 = 4;
			}
			world.SetBlockMetadataWithNotify(i, j, k, byte0);
		}

		public override int GetBlockTextureFromSide(int i)
		{
			if (i == 1)
			{
				return blockIndexInTexture + 17;
			}
			if (i == 0)
			{
				return blockIndexInTexture + 17;
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

		public override bool BlockActivated(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			if (world.singleplayerWorld)
			{
				return true;
			}
			else
			{
				net.minecraft.src.TileEntityDispenser tileentitydispenser = (net.minecraft.src.TileEntityDispenser
					)world.GetBlockTileEntity(i, j, k);
				entityplayer.DisplayGUIDispenser(tileentitydispenser);
				return true;
			}
		}

		private void DispenseItem(net.minecraft.src.World world, int i, int j, int k, SharpBukkitLive.SharpBukkit.SharpRandom
			 random)
		{
			int l = world.GetBlockMetadata(i, j, k);
			int i1 = 0;
			int j1 = 0;
			if (l == 3)
			{
				j1 = 1;
			}
			else
			{
				if (l == 2)
				{
					j1 = -1;
				}
				else
				{
					if (l == 5)
					{
						i1 = 1;
					}
					else
					{
						i1 = -1;
					}
				}
			}
			net.minecraft.src.TileEntityDispenser tileentitydispenser = (net.minecraft.src.TileEntityDispenser
				)world.GetBlockTileEntity(i, j, k);
			net.minecraft.src.ItemStack itemstack = tileentitydispenser.GetRandomStackFromInventory
				();
			double d = (double)i + (double)i1 * 0.59999999999999998D + 0.5D;
			double d1 = (double)j + 0.5D;
			double d2 = (double)k + (double)j1 * 0.59999999999999998D + 0.5D;
			if (itemstack == null)
			{
				world.Func_28097_e(1001, i, j, k, 0);
			}
			else
			{
				if (itemstack.itemID == net.minecraft.src.Item.arrow.shiftedIndex)
				{
					net.minecraft.src.EntityArrow entityarrow = new net.minecraft.src.EntityArrow(world
						, d, d1, d2);
					entityarrow.SetArrowHeading(i1, 0.10000000149011612D, j1, 1.1F, 6F);
					entityarrow.field_28012_a = true;
					world.EntityJoinedWorld(entityarrow);
					world.Func_28097_e(1002, i, j, k, 0);
				}
				else
				{
					if (itemstack.itemID == net.minecraft.src.Item.egg.shiftedIndex)
					{
						net.minecraft.src.EntityEgg entityegg = new net.minecraft.src.EntityEgg(world, d, 
							d1, d2);
						entityegg.Func_20078_a(i1, 0.10000000149011612D, j1, 1.1F, 6F);
						world.EntityJoinedWorld(entityegg);
						world.Func_28097_e(1002, i, j, k, 0);
					}
					else
					{
						if (itemstack.itemID == net.minecraft.src.Item.snowball.shiftedIndex)
						{
							net.minecraft.src.EntitySnowball entitysnowball = new net.minecraft.src.EntitySnowball
								(world, d, d1, d2);
							entitysnowball.Func_6141_a(i1, 0.10000000149011612D, j1, 1.1F, 6F);
							world.EntityJoinedWorld(entitysnowball);
							world.Func_28097_e(1002, i, j, k, 0);
						}
						else
						{
							net.minecraft.src.EntityItem entityitem = new net.minecraft.src.EntityItem(world, 
								d, d1 - 0.29999999999999999D, d2, itemstack);
							double d3 = random.NextDouble() * 0.10000000000000001D + 0.20000000000000001D;
							entityitem.motionX = (double)i1 * d3;
							entityitem.motionY = 0.20000000298023224D;
							entityitem.motionZ = (double)j1 * d3;
							entityitem.motionX += random.NextGaussian() * 0.0074999998323619366D * 6D;
							entityitem.motionY += random.NextGaussian() * 0.0074999998323619366D * 6D;
							entityitem.motionZ += random.NextGaussian() * 0.0074999998323619366D * 6D;
							world.EntityJoinedWorld(entityitem);
							world.Func_28097_e(1000, i, j, k, 0);
						}
					}
				}
				world.Func_28097_e(2000, i, j, k, i1 + 1 + (j1 + 1) * 3);
			}
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			if (l > 0 && net.minecraft.src.Block.blocksList[l].CanProvidePower())
			{
				bool flag = world.IsBlockIndirectlyGettingPowered(i, j, k) || world.IsBlockIndirectlyGettingPowered
					(i, j + 1, k);
				if (flag)
				{
					world.ScheduleUpdateTick(i, j, k, blockID, TickRate());
				}
			}
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (world.IsBlockIndirectlyGettingPowered(i, j, k) || world.IsBlockIndirectlyGettingPowered
				(i, j + 1, k))
			{
				DispenseItem(world, i, j, k, random);
			}
		}

		protected internal override net.minecraft.src.TileEntity GetBlockEntity()
		{
			return new net.minecraft.src.TileEntityDispenser();
		}

		public override void OnBlockPlacedBy(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityLiving entityliving)
		{
			int l = net.minecraft.src.MathHelper.Floor_double((double)((entityliving.rotationYaw
				 * 4F) / 360F) + 0.5D) & 3;
			if (l == 0)
			{
				world.SetBlockMetadataWithNotify(i, j, k, 2);
			}
			if (l == 1)
			{
				world.SetBlockMetadataWithNotify(i, j, k, 5);
			}
			if (l == 2)
			{
				world.SetBlockMetadataWithNotify(i, j, k, 3);
			}
			if (l == 3)
			{
				world.SetBlockMetadataWithNotify(i, j, k, 4);
			}
		}

		public override void OnBlockRemoval(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			net.minecraft.src.TileEntityDispenser tileentitydispenser = (net.minecraft.src.TileEntityDispenser
				)world.GetBlockTileEntity(i, j, k);
			for (int l = 0; l < tileentitydispenser.GetSizeInventory(); l++)
			{
				net.minecraft.src.ItemStack itemstack = tileentitydispenser.GetStackInSlot(l);
				if (itemstack == null)
				{
					continue;
				}
				float f = field_28032_a.NextFloat() * 0.8F + 0.1F;
				float f1 = field_28032_a.NextFloat() * 0.8F + 0.1F;
				float f2 = field_28032_a.NextFloat() * 0.8F + 0.1F;
				do
				{
					if (itemstack.stackSize <= 0)
					{
						goto label0_continue;
					}
					int i1 = field_28032_a.Next(21) + 10;
					if (i1 > itemstack.stackSize)
					{
						i1 = itemstack.stackSize;
					}
					itemstack.stackSize -= i1;
					net.minecraft.src.EntityItem entityitem = new net.minecraft.src.EntityItem(world, 
						(float)i + f, (float)j + f1, (float)k + f2, new net.minecraft.src.ItemStack(itemstack
						.itemID, i1, itemstack.GetItemDamage()));
					float f3 = 0.05F;
					entityitem.motionX = (float)field_28032_a.NextGaussian() * f3;
					entityitem.motionY = (float)field_28032_a.NextGaussian() * f3 + 0.2F;
					entityitem.motionZ = (float)field_28032_a.NextGaussian() * f3;
					world.EntityJoinedWorld(entityitem);
				}
				while (true);
label0_continue: ;
			}
label0_break: ;
			base.OnBlockRemoval(world, i, j, k);
		}

		private SharpBukkitLive.SharpBukkit.SharpRandom field_28032_a;
	}
}
