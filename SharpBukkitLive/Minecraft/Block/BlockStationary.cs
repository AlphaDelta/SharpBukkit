// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockStationary : net.minecraft.src.BlockFluid
	{
		protected internal BlockStationary(int i, net.minecraft.src.Material material)
			: base(i, material)
		{
			// Referenced classes of package net.minecraft.src:
			//            BlockFluid, Material, World, Block, 
			//            BlockFire
			SetTickOnLoad(false);
			if (material == net.minecraft.src.Material.lava)
			{
				SetTickOnLoad(true);
			}
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			base.OnNeighborBlockChange(world, i, j, k, l);
			if (world.GetBlockId(i, j, k) == ID)
			{
				Func_30005_i(world, i, j, k);
			}
		}

		private void Func_30005_i(net.minecraft.src.World world, int i, int j, int k)
		{
			int l = world.GetBlockMetadata(i, j, k);
			world.editingBlocks = true;
			world.SetBlockAndMetadata(i, j, k, ID - 1, l);
			world.MarkBlocksDirty(i, j, k, i, j, k);
			world.ScheduleUpdateTick(i, j, k, ID - 1, TickRate());
			world.editingBlocks = false;
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (blockMaterial == net.minecraft.src.Material.lava)
			{
				int l = random.Next(3);
				for (int i1 = 0; i1 < l; i1++)
				{
					i += random.Next(3) - 1;
					j++;
					k += random.Next(3) - 1;
					int j1 = world.GetBlockId(i, j, k);
					if (j1 == 0)
					{
						if (Func_4033_j(world, i - 1, j, k) || Func_4033_j(world, i + 1, j, k) || Func_4033_j
							(world, i, j, k - 1) || Func_4033_j(world, i, j, k + 1) || Func_4033_j(world, i, 
							j - 1, k) || Func_4033_j(world, i, j + 1, k))
						{
							world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.FIRE.ID);
							return;
						}
						continue;
					}
					if (net.minecraft.src.Block.blocksList[j1].blockMaterial.GetIsSolid())
					{
						return;
					}
				}
			}
		}

		private bool Func_4033_j(net.minecraft.src.World world, int i, int j, int k)
		{
			return world.GetBlockMaterial(i, j, k).GetBurning();
		}
	}
}
