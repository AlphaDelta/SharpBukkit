// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockFarmland : net.minecraft.src.Block
	{
		protected internal BlockFarmland(int i)
			: base(i, net.minecraft.src.Material.ground)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, AxisAlignedBB, World, 
			//            Entity
			blockIndexInTexture = 87;
			SetTickOnLoad(true);
			SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 0.9375F, 1.0F);
			SetLightOpacity(255);
		}

		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			return net.minecraft.src.AxisAlignedBB.GetBoundingBoxFromPool(i + 0, j + 0, k + 0
				, i + 1, j + 1, k + 1);
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		public override bool IsACube()
		{
			return false;
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			if (i == 1 && j > 0)
			{
				return blockIndexInTexture - 1;
			}
			if (i == 1)
			{
				return blockIndexInTexture;
			}
			else
			{
				return 2;
			}
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (random.Next(5) == 0)
			{
				if (IsWaterNearby(world, i, j, k) || world.CanLightningStrikeAt(i, j + 1, k))
				{
					world.SetBlockMetadataWithNotify(i, j, k, 7);
				}
				else
				{
					int l = world.GetBlockMetadata(i, j, k);
					if (l > 0)
					{
						world.SetBlockMetadataWithNotify(i, j, k, l - 1);
					}
					else
					{
						if (!IsCropsNearby(world, i, j, k))
						{
							world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.DIRT.blockID);
						}
					}
				}
			}
		}

		public override void OnEntityWalking(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.Entity entity)
		{
			if (world.rand.Next(4) == 0)
			{
				world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.DIRT.blockID);
			}
		}

		private bool IsCropsNearby(net.minecraft.src.World world, int i, int j, int k)
		{
			int l = 0;
			for (int i1 = i - l; i1 <= i + l; i1++)
			{
				for (int j1 = k - l; j1 <= k + l; j1++)
				{
					if (world.GetBlockId(i1, j + 1, j1) == net.minecraft.src.Block.CROPS.blockID)
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool IsWaterNearby(net.minecraft.src.World world, int i, int j, int k)
		{
			for (int l = i - 4; l <= i + 4; l++)
			{
				for (int i1 = j; i1 <= j + 1; i1++)
				{
					for (int j1 = k - 4; j1 <= k + 4; j1++)
					{
						if (world.GetBlockMaterial(l, i1, j1) == net.minecraft.src.Material.water)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			base.OnNeighborBlockChange(world, i, j, k, l);
			net.minecraft.src.Material material = world.GetBlockMaterial(i, j + 1, k);
			if (material.IsSolid())
			{
				world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.DIRT.blockID);
			}
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Block.DIRT.IdDropped(0, random);
		}
	}
}
