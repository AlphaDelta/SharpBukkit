// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockRedstoneOre : net.minecraft.src.Block
	{
		public BlockRedstoneOre(int i, int j, bool flag)
			: base(i, j, net.minecraft.src.Material.rock)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, World, Item, 
			//            EntityPlayer, Entity
			if (flag)
			{
				SetTickOnLoad(true);
			}
			field_665_a = flag;
		}

		public override int TickRate()
		{
			return 30;
		}

		public override void OnBlockClicked(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			Func_321_g(world, i, j, k);
			base.OnBlockClicked(world, i, j, k, entityplayer);
		}

		public override void OnEntityWalking(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.Entity entity)
		{
			Func_321_g(world, i, j, k);
			base.OnEntityWalking(world, i, j, k, entity);
		}

		public override bool BlockActivated(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			Func_321_g(world, i, j, k);
			return base.BlockActivated(world, i, j, k, entityplayer);
		}

		private void Func_321_g(net.minecraft.src.World world, int i, int j, int k)
		{
			Func_320_h(world, i, j, k);
			if (blockID == net.minecraft.src.Block.REDSTONE_ORE.blockID)
			{
				world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.GLOWING_REDSTONE_ORE.blockID
					);
			}
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (blockID == net.minecraft.src.Block.GLOWING_REDSTONE_ORE.blockID)
			{
				world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.REDSTONE_ORE.blockID);
			}
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Item.redstone.shiftedIndex;
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 4 + random.Next(2);
		}

		private void Func_320_h(net.minecraft.src.World world, int i, int j, int k)
		{
			SharpBukkitLive.SharpBukkit.SharpRandom random = world.rand;
			double d = 0.0625D;
			for (int l = 0; l < 6; l++)
			{
				double d1 = (float)i + ((float)random.NextDouble());
				double d2 = (float)j + ((float)random.NextDouble());
				double d3 = (float)k + ((float)random.NextDouble());
				if (l == 0 && !world.IsBlockOpaqueCube(i, j + 1, k))
				{
					d2 = (double)(j + 1) + d;
				}
				if (l == 1 && !world.IsBlockOpaqueCube(i, j - 1, k))
				{
					d2 = (double)(j + 0) - d;
				}
				if (l == 2 && !world.IsBlockOpaqueCube(i, j, k + 1))
				{
					d3 = (double)(k + 1) + d;
				}
				if (l == 3 && !world.IsBlockOpaqueCube(i, j, k - 1))
				{
					d3 = (double)(k + 0) - d;
				}
				if (l == 4 && !world.IsBlockOpaqueCube(i + 1, j, k))
				{
					d1 = (double)(i + 1) + d;
				}
				if (l == 5 && !world.IsBlockOpaqueCube(i - 1, j, k))
				{
					d1 = (double)(i + 0) - d;
				}
				if (d1 < (double)i || d1 > (double)(i + 1) || d2 < 0.0D || d2 > (double)(j + 1) ||
					 d3 < (double)k || d3 > (double)(k + 1))
				{
					world.SpawnParticle("reddust", d1, d2, d3, 0.0D, 0.0D, 0.0D);
				}
			}
		}

		private bool field_665_a;
	}
}
