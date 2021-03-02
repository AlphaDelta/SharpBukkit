// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockLeaves : net.minecraft.src.BlockLeavesBase
	{
		protected internal BlockLeaves(int i, int j)
			: base(i, j, net.minecraft.src.Material.leaves, false)
		{
			// Referenced classes of package net.minecraft.src:
			//            BlockLeavesBase, Material, World, Block, 
			//            EntityPlayer, ItemStack, Item, ItemShears, 
			//            StatList, Entity
			baseIndexInPNG = j;
			SetTickOnLoad(true);
		}

		public override void OnBlockRemoval(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			int l = 1;
			int i1 = l + 1;
			if (world.CheckChunksExist(i - i1, j - i1, k - i1, i + i1, j + i1, k + i1))
			{
				for (int j1 = -l; j1 <= l; j1++)
				{
					for (int k1 = -l; k1 <= l; k1++)
					{
						for (int l1 = -l; l1 <= l; l1++)
						{
							int i2 = world.GetBlockId(i + j1, j + k1, k + l1);
							if (i2 == net.minecraft.src.Block.LEAVES.ID)
							{
								int j2 = world.GetBlockMetadata(i + j1, j + k1, k + l1);
								world.SetBlockMetadata(i + j1, j + k1, k + l1, j2 | 8);
							}
						}
					}
				}
			}
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			int l = world.GetBlockMetadata(i, j, k);
			if ((l & 8) != 0)
			{
				byte byte0 = 4;
				int i1 = byte0 + 1;
				byte byte1 = 32;
				int j1 = byte1 * byte1;
				int k1 = byte1 / 2;
				if (adjacentTreeBlocks == null)
				{
					adjacentTreeBlocks = new int[byte1 * byte1 * byte1];
				}
				if (world.CheckChunksExist(i - i1, j - i1, k - i1, i + i1, j + i1, k + i1))
				{
					for (int l1 = -byte0; l1 <= byte0; l1++)
					{
						for (int k2 = -byte0; k2 <= byte0; k2++)
						{
							for (int i3 = -byte0; i3 <= byte0; i3++)
							{
								int k3 = world.GetBlockId(i + l1, j + k2, k + i3);
								if (k3 == net.minecraft.src.Block.LOG.ID)
								{
									adjacentTreeBlocks[(l1 + k1) * j1 + (k2 + k1) * byte1 + (i3 + k1)] = 0;
									continue;
								}
								if (k3 == net.minecraft.src.Block.LEAVES.ID)
								{
									adjacentTreeBlocks[(l1 + k1) * j1 + (k2 + k1) * byte1 + (i3 + k1)] = -2;
								}
								else
								{
									adjacentTreeBlocks[(l1 + k1) * j1 + (k2 + k1) * byte1 + (i3 + k1)] = -1;
								}
							}
						}
					}
					for (int i2 = 1; i2 <= 4; i2++)
					{
						for (int l2 = -byte0; l2 <= byte0; l2++)
						{
							for (int j3 = -byte0; j3 <= byte0; j3++)
							{
								for (int l3 = -byte0; l3 <= byte0; l3++)
								{
									if (adjacentTreeBlocks[(l2 + k1) * j1 + (j3 + k1) * byte1 + (l3 + k1)] != i2 - 1)
									{
										continue;
									}
									if (adjacentTreeBlocks[((l2 + k1) - 1) * j1 + (j3 + k1) * byte1 + (l3 + k1)] == -
										2)
									{
										adjacentTreeBlocks[((l2 + k1) - 1) * j1 + (j3 + k1) * byte1 + (l3 + k1)] = i2;
									}
									if (adjacentTreeBlocks[(l2 + k1 + 1) * j1 + (j3 + k1) * byte1 + (l3 + k1)] == -2)
									{
										adjacentTreeBlocks[(l2 + k1 + 1) * j1 + (j3 + k1) * byte1 + (l3 + k1)] = i2;
									}
									if (adjacentTreeBlocks[(l2 + k1) * j1 + ((j3 + k1) - 1) * byte1 + (l3 + k1)] == -
										2)
									{
										adjacentTreeBlocks[(l2 + k1) * j1 + ((j3 + k1) - 1) * byte1 + (l3 + k1)] = i2;
									}
									if (adjacentTreeBlocks[(l2 + k1) * j1 + (j3 + k1 + 1) * byte1 + (l3 + k1)] == -2)
									{
										adjacentTreeBlocks[(l2 + k1) * j1 + (j3 + k1 + 1) * byte1 + (l3 + k1)] = i2;
									}
									if (adjacentTreeBlocks[(l2 + k1) * j1 + (j3 + k1) * byte1 + ((l3 + k1) - 1)] == -
										2)
									{
										adjacentTreeBlocks[(l2 + k1) * j1 + (j3 + k1) * byte1 + ((l3 + k1) - 1)] = i2;
									}
									if (adjacentTreeBlocks[(l2 + k1) * j1 + (j3 + k1) * byte1 + (l3 + k1 + 1)] == -2)
									{
										adjacentTreeBlocks[(l2 + k1) * j1 + (j3 + k1) * byte1 + (l3 + k1 + 1)] = i2;
									}
								}
							}
						}
					}
				}
				int j2 = adjacentTreeBlocks[k1 * j1 + k1 * byte1 + k1];
				if (j2 >= 0)
				{
					world.SetBlockMetadata(i, j, k, l & -9);
				}
				else
				{
					RemoveLeaves(world, i, j, k);
				}
			}
		}

		private void RemoveLeaves(net.minecraft.src.World world, int i, int j, int k)
		{
			DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
			world.SetBlockWithNotify(i, j, k, 0);
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return random.Next(20) != 0 ? 0 : 1;
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Block.SAPLING.ID;
		}

		public override void HarvestBlock(net.minecraft.src.World world, net.minecraft.src.EntityPlayer
			 entityplayer, int i, int j, int k, int l)
		{
			if (!world.singleplayerWorld && entityplayer.GetCurrentEquippedItem() != null && 
				entityplayer.GetCurrentEquippedItem().itemID == net.minecraft.src.Item.SHEARS
				.ID)
			{
				entityplayer.AddStat(net.minecraft.src.StatList.StatMinedBlocks[ID], 1);
				DropBlockAsItem_do(world, i, j, k, new net.minecraft.src.ItemStack(net.minecraft.src.Block
					.LEAVES.ID, 1, l & 3));
			}
			else
			{
				base.HarvestBlock(world, entityplayer, i, j, k, l);
			}
		}

		protected internal override int DamageDropped(int i)
		{
			return i & 3;
		}

		public override bool IsOpaqueCube()
		{
			return !graphicsLevel;
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			if ((j & 3) == 1)
			{
				return blockIndexInTexture + 80;
			}
			else
			{
				return blockIndexInTexture;
			}
		}

		public override void OnEntityWalking(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.Entity entity)
		{
			base.OnEntityWalking(world, i, j, k, entity);
		}

		private int baseIndexInPNG;

		internal int[] adjacentTreeBlocks;
	}
}
