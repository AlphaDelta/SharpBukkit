// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class BlockRedstoneTorch : net.minecraft.src.BlockTorch
	{
		// Referenced classes of package net.minecraft.src:
		//            BlockTorch, Block, RedstoneUpdateInfo, World, 
		//            IBlockAccess
		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			if (i == 1)
			{
				return net.minecraft.src.Block.REDSTONE_WIRE.GetBlockTextureFromSideAndMetadata(i, 
					j);
			}
			else
			{
				return base.GetBlockTextureFromSideAndMetadata(i, j);
			}
		}

		private bool CheckForBurnout(net.minecraft.src.World world, int i, int j, int k, 
			bool flag)
		{
			if (flag)
			{
				torchUpdates.Add(new net.minecraft.src.RedstoneUpdateInfo(i, j, k, world.GetWorldTime
					()));
			}
			int l = 0;
			for (int i1 = 0; i1 < torchUpdates.Count; i1++)
			{
				net.minecraft.src.RedstoneUpdateInfo redstoneupdateinfo = (net.minecraft.src.RedstoneUpdateInfo
					)torchUpdates[i1];
				if (redstoneupdateinfo.x == i && redstoneupdateinfo.y == j && redstoneupdateinfo.
					z == k && ++l >= 8)
				{
					return true;
				}
			}
			return false;
		}

		protected internal BlockRedstoneTorch(int i, int j, bool flag)
			: base(i, j)
		{
			torchActive = false;
			torchActive = flag;
			SetTickOnLoad(true);
		}

		public override int TickRate()
		{
			return 2;
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			if (world.GetBlockMetadata(i, j, k) == 0)
			{
				base.OnBlockAdded(world, i, j, k);
			}
			if (torchActive)
			{
				world.NotifyBlocksOfNeighborChange(i, j - 1, k, ID);
				world.NotifyBlocksOfNeighborChange(i, j + 1, k, ID);
				world.NotifyBlocksOfNeighborChange(i - 1, j, k, ID);
				world.NotifyBlocksOfNeighborChange(i + 1, j, k, ID);
				world.NotifyBlocksOfNeighborChange(i, j, k - 1, ID);
				world.NotifyBlocksOfNeighborChange(i, j, k + 1, ID);
			}
		}

		public override void OnBlockRemoval(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			if (torchActive)
			{
				world.NotifyBlocksOfNeighborChange(i, j - 1, k, ID);
				world.NotifyBlocksOfNeighborChange(i, j + 1, k, ID);
				world.NotifyBlocksOfNeighborChange(i - 1, j, k, ID);
				world.NotifyBlocksOfNeighborChange(i + 1, j, k, ID);
				world.NotifyBlocksOfNeighborChange(i, j, k - 1, ID);
				world.NotifyBlocksOfNeighborChange(i, j, k + 1, ID);
			}
		}

		public override bool IsPoweringTo(net.minecraft.src.IBlockAccess iblockaccess, int
			 i, int j, int k, int l)
		{
			if (!torchActive)
			{
				return false;
			}
			int i1 = iblockaccess.GetBlockMetadata(i, j, k);
			if (i1 == 5 && l == 1)
			{
				return false;
			}
			if (i1 == 3 && l == 3)
			{
				return false;
			}
			if (i1 == 4 && l == 2)
			{
				return false;
			}
			if (i1 == 1 && l == 5)
			{
				return false;
			}
			return i1 != 2 || l != 4;
		}

		private bool Func_30003_g(net.minecraft.src.World world, int i, int j, int k)
		{
			int l = world.GetBlockMetadata(i, j, k);
			if (l == 5 && world.IsBlockIndirectlyProvidingPowerTo(i, j - 1, k, 0))
			{
				return true;
			}
			if (l == 3 && world.IsBlockIndirectlyProvidingPowerTo(i, j, k - 1, 2))
			{
				return true;
			}
			if (l == 4 && world.IsBlockIndirectlyProvidingPowerTo(i, j, k + 1, 3))
			{
				return true;
			}
			if (l == 1 && world.IsBlockIndirectlyProvidingPowerTo(i - 1, j, k, 4))
			{
				return true;
			}
			return l == 2 && world.IsBlockIndirectlyProvidingPowerTo(i + 1, j, k, 5);
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			bool flag = Func_30003_g(world, i, j, k);
			for (; torchUpdates.Count > 0 && world.GetWorldTime() - ((net.minecraft.src.RedstoneUpdateInfo
				)torchUpdates[0]).updateTime > 100L; torchUpdates.RemoveAt(0))
			{
			}
			if (torchActive)
			{
				if (flag)
				{
					world.SetBlockAndMetadataWithNotify(i, j, k, net.minecraft.src.Block.REDSTONE_TORCH_OFF
						.ID, world.GetBlockMetadata(i, j, k));
					if (CheckForBurnout(world, i, j, k, true))
					{
						world.PlaySoundEffect((float)i + 0.5F, (float)j + 0.5F, (float)k + 0.5F, "random.fizz"
							, 0.5F, 2.6F + (world.rand.NextFloat() - world.rand.NextFloat()) * 0.8F);
						for (int l = 0; l < 5; l++)
						{
							double d = (double)i + random.NextDouble() * 0.59999999999999998D + 0.20000000000000001D;
							double d1 = (double)j + random.NextDouble() * 0.59999999999999998D + 0.20000000000000001D;
							double d2 = (double)k + random.NextDouble() * 0.59999999999999998D + 0.20000000000000001D;
							world.SpawnParticle("smoke", d, d1, d2, 0.0D, 0.0D, 0.0D);
						}
					}
				}
			}
			else
			{
				if (!flag && !CheckForBurnout(world, i, j, k, false))
				{
					world.SetBlockAndMetadataWithNotify(i, j, k, net.minecraft.src.Block.REDSTONE_TORCH_ON
						.ID, world.GetBlockMetadata(i, j, k));
				}
			}
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			base.OnNeighborBlockChange(world, i, j, k, l);
			world.ScheduleUpdateTick(i, j, k, ID, TickRate());
		}

		public override bool IsIndirectlyPoweringTo(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			if (l == 0)
			{
				return IsPoweringTo(world, i, j, k, l);
			}
			else
			{
				return false;
			}
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Block.REDSTONE_TORCH_ON.ID;
		}

		public override bool CanProvidePower()
		{
			return true;
		}

		private bool torchActive;

		private static List<RedstoneUpdateInfo> torchUpdates = new List<RedstoneUpdateInfo>();
	}
}
