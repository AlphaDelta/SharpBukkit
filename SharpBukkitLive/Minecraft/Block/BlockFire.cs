// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockFire : net.minecraft.src.Block
	{
		protected internal BlockFire(int i, int j)
			: base(i, j, net.minecraft.src.Material.fire)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, BlockLeaves, BlockTallGrass, 
			//            World, IBlockAccess, BlockPortal, AxisAlignedBB
			chanceToEncourageFire = new int[256];
			abilityToCatchFire = new int[256];
			SetTickOnLoad(true);
		}

		protected internal override void SetFireBurnRates()
		{
			SetBurnRate(net.minecraft.src.Block.planks.blockID, 5, 20);
			SetBurnRate(net.minecraft.src.Block.fence.blockID, 5, 20);
			SetBurnRate(net.minecraft.src.Block.stairCompactPlanks.blockID, 5, 20);
			SetBurnRate(net.minecraft.src.Block.wood.blockID, 5, 5);
			SetBurnRate(net.minecraft.src.Block.leaves.blockID, 30, 60);
			SetBurnRate(net.minecraft.src.Block.bookShelf.blockID, 30, 20);
			SetBurnRate(net.minecraft.src.Block.tnt.blockID, 15, 100);
			SetBurnRate(net.minecraft.src.Block.tallGrass.blockID, 60, 100);
			SetBurnRate(net.minecraft.src.Block.cloth.blockID, 30, 60);
		}

		private void SetBurnRate(int i, int j, int k)
		{
			chanceToEncourageFire[i] = j;
			abilityToCatchFire[i] = k;
		}

		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			return null;
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		public override bool IsACube()
		{
			return false;
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 0;
		}

		public override int TickRate()
		{
			return 40;
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			bool flag = world.GetBlockId(i, j - 1, k) == net.minecraft.src.Block.bloodStone.blockID;
			if (!CanPlaceBlockAt(world, i, j, k))
			{
				world.SetBlockWithNotify(i, j, k, 0);
			}
			if (!flag && world.Func_27068_v() && (world.CanLightningStrikeAt(i, j, k) || world
				.CanLightningStrikeAt(i - 1, j, k) || world.CanLightningStrikeAt(i + 1, j, k) ||
				 world.CanLightningStrikeAt(i, j, k - 1) || world.CanLightningStrikeAt(i, j, k +
				 1)))
			{
				world.SetBlockWithNotify(i, j, k, 0);
				return;
			}
			int l = world.GetBlockMetadata(i, j, k);
			if (l < 15)
			{
				world.SetBlockMetadata(i, j, k, l + random.Next(3) / 2);
			}
			world.ScheduleUpdateTick(i, j, k, blockID, TickRate());
			if (!flag && !Func_268_g(world, i, j, k))
			{
				if (!world.IsBlockNormalCube(i, j - 1, k) || l > 3)
				{
					world.SetBlockWithNotify(i, j, k, 0);
				}
				return;
			}
			if (!flag && !CanBlockCatchFire(world, i, j - 1, k) && l == 15 && random.Next(
				4) == 0)
			{
				world.SetBlockWithNotify(i, j, k, 0);
				return;
			}
			TryToCatchBlockOnFire(world, i + 1, j, k, 300, random, l);
			TryToCatchBlockOnFire(world, i - 1, j, k, 300, random, l);
			TryToCatchBlockOnFire(world, i, j - 1, k, 250, random, l);
			TryToCatchBlockOnFire(world, i, j + 1, k, 250, random, l);
			TryToCatchBlockOnFire(world, i, j, k - 1, 300, random, l);
			TryToCatchBlockOnFire(world, i, j, k + 1, 300, random, l);
			for (int i1 = i - 1; i1 <= i + 1; i1++)
			{
				for (int j1 = k - 1; j1 <= k + 1; j1++)
				{
					for (int k1 = j - 1; k1 <= j + 4; k1++)
					{
						if (i1 == i && k1 == j && j1 == k)
						{
							continue;
						}
						int l1 = 100;
						if (k1 > j + 1)
						{
							l1 += (k1 - (j + 1)) * 100;
						}
						int i2 = GetChanceOfNeighborsEncouragingFire(world, i1, k1, j1);
						if (i2 <= 0)
						{
							continue;
						}
						int j2 = (i2 + 40) / (l + 30);
						if (j2 <= 0 || random.Next(l1) > j2 || world.Func_27068_v() && world.CanLightningStrikeAt
							(i1, k1, j1) || world.CanLightningStrikeAt(i1 - 1, k1, k) || world.CanLightningStrikeAt
							(i1 + 1, k1, j1) || world.CanLightningStrikeAt(i1, k1, j1 - 1) || world.CanLightningStrikeAt
							(i1, k1, j1 + 1))
						{
							continue;
						}
						int k2 = l + random.Next(5) / 4;
						if (k2 > 15)
						{
							k2 = 15;
						}
						world.SetBlockAndMetadataWithNotify(i1, k1, j1, blockID, k2);
					}
				}
			}
		}

		private void TryToCatchBlockOnFire(net.minecraft.src.World world, int i, int j, int
			 k, int l, SharpBukkitLive.SharpBukkit.SharpRandom random, int i1)
		{
			int j1 = abilityToCatchFire[world.GetBlockId(i, j, k)];
			if (random.Next(l) < j1)
			{
				bool flag = world.GetBlockId(i, j, k) == net.minecraft.src.Block.tnt.blockID;
				if (random.Next(i1 + 10) < 5 && !world.CanLightningStrikeAt(i, j, k))
				{
					int k1 = i1 + random.Next(5) / 4;
					if (k1 > 15)
					{
						k1 = 15;
					}
					world.SetBlockAndMetadataWithNotify(i, j, k, blockID, k1);
				}
				else
				{
					world.SetBlockWithNotify(i, j, k, 0);
				}
				if (flag)
				{
					net.minecraft.src.Block.tnt.OnBlockDestroyedByPlayer(world, i, j, k, 1);
				}
			}
		}

		private bool Func_268_g(net.minecraft.src.World world, int i, int j, int k)
		{
			if (CanBlockCatchFire(world, i + 1, j, k))
			{
				return true;
			}
			if (CanBlockCatchFire(world, i - 1, j, k))
			{
				return true;
			}
			if (CanBlockCatchFire(world, i, j - 1, k))
			{
				return true;
			}
			if (CanBlockCatchFire(world, i, j + 1, k))
			{
				return true;
			}
			if (CanBlockCatchFire(world, i, j, k - 1))
			{
				return true;
			}
			return CanBlockCatchFire(world, i, j, k + 1);
		}

		private int GetChanceOfNeighborsEncouragingFire(net.minecraft.src.World world, int
			 i, int j, int k)
		{
			int l = 0;
			if (!world.IsAirBlock(i, j, k))
			{
				return 0;
			}
			else
			{
				l = GetChanceToEncourageFire(world, i + 1, j, k, l);
				l = GetChanceToEncourageFire(world, i - 1, j, k, l);
				l = GetChanceToEncourageFire(world, i, j - 1, k, l);
				l = GetChanceToEncourageFire(world, i, j + 1, k, l);
				l = GetChanceToEncourageFire(world, i, j, k - 1, l);
				l = GetChanceToEncourageFire(world, i, j, k + 1, l);
				return l;
			}
		}

		public override bool IsCollidable()
		{
			return false;
		}

		public virtual bool CanBlockCatchFire(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k)
		{
			return chanceToEncourageFire[iblockaccess.GetBlockId(i, j, k)] > 0;
		}

		public virtual int GetChanceToEncourageFire(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			int i1 = chanceToEncourageFire[world.GetBlockId(i, j, k)];
			if (i1 > l)
			{
				return i1;
			}
			else
			{
				return l;
			}
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			return world.IsBlockNormalCube(i, j - 1, k) || Func_268_g(world, i, j, k);
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			if (!world.IsBlockNormalCube(i, j - 1, k) && !Func_268_g(world, i, j, k))
			{
				world.SetBlockWithNotify(i, j, k, 0);
				return;
			}
			else
			{
				return;
			}
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			if (world.GetBlockId(i, j - 1, k) == net.minecraft.src.Block.obsidian.blockID && 
				net.minecraft.src.Block.portal.TryToCreatePortal(world, i, j, k))
			{
				return;
			}
			if (!world.IsBlockNormalCube(i, j - 1, k) && !Func_268_g(world, i, j, k))
			{
				world.SetBlockWithNotify(i, j, k, 0);
				return;
			}
			else
			{
				world.ScheduleUpdateTick(i, j, k, blockID, TickRate());
				return;
			}
		}

		private int[] chanceToEncourageFire;

		private int[] abilityToCatchFire;
	}
}
