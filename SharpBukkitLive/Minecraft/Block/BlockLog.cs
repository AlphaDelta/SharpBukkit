// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockLog : net.minecraft.src.Block
	{
		protected internal BlockLog(int i)
			: base(i, net.minecraft.src.Material.wood)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, World, BlockLeaves, 
			//            EntityPlayer
			blockIndexInTexture = 20;
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 1;
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Block.LOG.blockID;
		}

		public override void HarvestBlock(net.minecraft.src.World world, net.minecraft.src.EntityPlayer
			 entityplayer, int i, int j, int k, int l)
		{
			base.HarvestBlock(world, entityplayer, i, j, k, l);
		}

		public override void OnBlockRemoval(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			byte byte0 = 4;
			int l = byte0 + 1;
			if (world.CheckChunksExist(i - l, j - l, k - l, i + l, j + l, k + l))
			{
				for (int i1 = -byte0; i1 <= byte0; i1++)
				{
					for (int j1 = -byte0; j1 <= byte0; j1++)
					{
						for (int k1 = -byte0; k1 <= byte0; k1++)
						{
							int l1 = world.GetBlockId(i + i1, j + j1, k + k1);
							if (l1 != net.minecraft.src.Block.LEAVES.blockID)
							{
								continue;
							}
							int i2 = world.GetBlockMetadata(i + i1, j + j1, k + k1);
							if ((i2 & 8) == 0)
							{
								world.SetBlockMetadata(i + i1, j + j1, k + k1, i2 | 8);
							}
						}
					}
				}
			}
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			if (i == 1)
			{
				return 21;
			}
			if (i == 0)
			{
				return 21;
			}
			if (j == 1)
			{
				return 116;
			}
			return j != 2 ? 20 : 117;
		}

		protected internal override int DamageDropped(int i)
		{
			return i;
		}
	}
}
