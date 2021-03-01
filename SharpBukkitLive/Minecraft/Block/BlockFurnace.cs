// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockFurnace : net.minecraft.src.BlockContainer
	{
		protected internal BlockFurnace(int i, bool flag)
			: base(i, net.minecraft.src.Material.rock)
		{
			// Referenced classes of package net.minecraft.src:
			//            BlockContainer, Material, Block, World, 
			//            TileEntityFurnace, EntityPlayer, TileEntity, EntityLiving, 
			//            MathHelper, IInventory, ItemStack, EntityItem
			field_28033_a = new SharpBukkitLive.SharpBukkit.SharpRandom();
			isActive = flag;
			blockIndexInTexture = 45;
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Block.stoneOvenIdle.blockID;
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			base.OnBlockAdded(world, i, j, k);
			SetDefaultDirection(world, i, j, k);
		}

		private void SetDefaultDirection(net.minecraft.src.World world, int i, int j, int
			 k)
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
				return blockIndexInTexture - 1;
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
				net.minecraft.src.TileEntityFurnace tileentityfurnace = (net.minecraft.src.TileEntityFurnace
					)world.GetBlockTileEntity(i, j, k);
				entityplayer.DisplayGUIFurnace(tileentityfurnace);
				return true;
			}
		}

		public static void UpdateFurnaceBlockState(bool flag, net.minecraft.src.World world
			, int i, int j, int k)
		{
			int l = world.GetBlockMetadata(i, j, k);
			net.minecraft.src.TileEntity tileentity = world.GetBlockTileEntity(i, j, k);
			if (tileentity == null) return; // CRAFTBUKKIT

			field_28034_c = true;
			if (flag)
			{
				world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.stoneOvenActive.blockID
					);
			}
			else
			{
				world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.stoneOvenIdle.blockID);
			}
			field_28034_c = false;
			world.SetBlockMetadataWithNotify(i, j, k, l);
			tileentity.Validate();
			world.SetBlockTileEntity(i, j, k, tileentity);
		}

		protected internal override net.minecraft.src.TileEntity GetBlockEntity()
		{
			return new net.minecraft.src.TileEntityFurnace();
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
			if (!field_28034_c)
			{
				net.minecraft.src.TileEntityFurnace tileentityfurnace = (net.minecraft.src.TileEntityFurnace)world.GetBlockTileEntity(i, j, k);
				if (tileentityfurnace == null) return; // CRAFTBUKKIT

				for (int l = 0; l < tileentityfurnace.GetSizeInventory(); l++)
				{
					net.minecraft.src.ItemStack itemstack = tileentityfurnace.GetStackInSlot(l);
					if (itemstack == null)
					{
						continue;
					}
					float f = field_28033_a.NextFloat() * 0.8F + 0.1F;
					float f1 = field_28033_a.NextFloat() * 0.8F + 0.1F;
					float f2 = field_28033_a.NextFloat() * 0.8F + 0.1F;
					do
					{
						if (itemstack.stackSize <= 0)
						{
							goto label0_continue;
						}
						int i1 = field_28033_a.Next(21) + 10;
						if (i1 > itemstack.stackSize)
						{
							i1 = itemstack.stackSize;
						}
						itemstack.stackSize -= i1;
						net.minecraft.src.EntityItem entityitem = new net.minecraft.src.EntityItem(world, 
							(float)i + f, (float)j + f1, (float)k + f2, new net.minecraft.src.ItemStack(itemstack
							.itemID, i1, itemstack.GetItemDamage()));
						float f3 = 0.05F;
						entityitem.motionX = (float)field_28033_a.NextGaussian() * f3;
						entityitem.motionY = (float)field_28033_a.NextGaussian() * f3 + 0.2F;
						entityitem.motionZ = (float)field_28033_a.NextGaussian() * f3;
						world.AddEntity(entityitem);
					}
					while (true);
label0_continue: ;
				}
label0_break: ;
			}
			base.OnBlockRemoval(world, i, j, k);
		}

		private SharpBukkitLive.SharpBukkit.SharpRandom field_28033_a;

		private readonly bool isActive;

		private static bool field_28034_c = false;
	}
}
