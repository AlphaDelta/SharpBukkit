// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockSand : net.minecraft.src.Block
	{
		public BlockSand(int i, int j)
			: base(i, j, net.minecraft.src.Material.sand)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Block, Material, World, EntityFallingSand, 
		//            BlockFire
		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			world.ScheduleUpdateTick(i, j, k, blockID, TickRate());
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			world.ScheduleUpdateTick(i, j, k, blockID, TickRate());
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			TryToFall(world, i, j, k);
		}

		private void TryToFall(net.minecraft.src.World world, int i, int j, int k)
		{
			int l = i;
			int i1 = j;
			int j1 = k;
			if (CanFallBelow(world, l, i1 - 1, j1) && i1 >= 0)
			{
				byte byte0 = 32;
				if (fallInstantly || !world.CheckChunksExist(i - byte0, j - byte0, k - byte0, i +
					 byte0, j + byte0, k + byte0))
				{
					world.SetBlockWithNotify(i, j, k, 0);
					for (; CanFallBelow(world, i, j - 1, k) && j > 0; j--)
					{
					}
					if (j > 0)
					{
						world.SetBlockWithNotify(i, j, k, blockID);
					}
				}
				else
				{
					net.minecraft.src.EntityFallingSand entityfallingsand = new net.minecraft.src.EntityFallingSand
						(world, (float)i + 0.5F, (float)j + 0.5F, (float)k + 0.5F, blockID);
					world.AddEntity(entityfallingsand);
				}
			}
		}

		public override int TickRate()
		{
			return 3;
		}

		public static bool CanFallBelow(net.minecraft.src.World world, int i, int j, int 
			k)
		{
			int l = world.GetBlockId(i, j, k);
			if (l == 0)
			{
				return true;
			}
			if (l == net.minecraft.src.Block.FIRE.blockID)
			{
				return true;
			}
			net.minecraft.src.Material material = net.minecraft.src.Block.blocksList[l].blockMaterial;
			if (material == net.minecraft.src.Material.water)
			{
				return true;
			}
			return material == net.minecraft.src.Material.lava;
		}

		public static bool fallInstantly = false;
	}
}
