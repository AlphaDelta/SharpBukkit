// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockTorch : net.minecraft.src.Block
	{
		protected internal BlockTorch(int i, int j)
			: base(i, j, net.minecraft.src.Material.circuits)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, World, AxisAlignedBB, 
			//            Vec3D, MovingObjectPosition
			SetTickOnLoad(true);
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

		private bool Func_31028_g(net.minecraft.src.World world, int i, int j, int k)
		{
			return world.IsBlockNormalCube(i, j, k) || world.GetBlockId(i, j, k) == net.minecraft.src.Block
				.FENCE.ID;
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			if (world.IsBlockNormalCube(i - 1, j, k))
			{
				return true;
			}
			if (world.IsBlockNormalCube(i + 1, j, k))
			{
				return true;
			}
			if (world.IsBlockNormalCube(i, j, k - 1))
			{
				return true;
			}
			if (world.IsBlockNormalCube(i, j, k + 1))
			{
				return true;
			}
			return Func_31028_g(world, i, j - 1, k);
		}

		public override void OnBlockPlaced(net.minecraft.src.World world, int i, int j, int
			 k, int l)
		{
			int i1 = world.GetBlockMetadata(i, j, k);
			if (l == 1 && Func_31028_g(world, i, j - 1, k))
			{
				i1 = 5;
			}
			if (l == 2 && world.IsBlockNormalCube(i, j, k + 1))
			{
				i1 = 4;
			}
			if (l == 3 && world.IsBlockNormalCube(i, j, k - 1))
			{
				i1 = 3;
			}
			if (l == 4 && world.IsBlockNormalCube(i + 1, j, k))
			{
				i1 = 2;
			}
			if (l == 5 && world.IsBlockNormalCube(i - 1, j, k))
			{
				i1 = 1;
			}
			world.SetBlockMetadataWithNotify(i, j, k, i1);
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			base.UpdateTick(world, i, j, k, random);
			if (world.GetBlockMetadata(i, j, k) == 0)
			{
				OnBlockAdded(world, i, j, k);
			}
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			if (world.IsBlockNormalCube(i - 1, j, k))
			{
				world.SetBlockMetadataWithNotify(i, j, k, 1);
			}
			else
			{
				if (world.IsBlockNormalCube(i + 1, j, k))
				{
					world.SetBlockMetadataWithNotify(i, j, k, 2);
				}
				else
				{
					if (world.IsBlockNormalCube(i, j, k - 1))
					{
						world.SetBlockMetadataWithNotify(i, j, k, 3);
					}
					else
					{
						if (world.IsBlockNormalCube(i, j, k + 1))
						{
							world.SetBlockMetadataWithNotify(i, j, k, 4);
						}
						else
						{
							if (Func_31028_g(world, i, j - 1, k))
							{
								world.SetBlockMetadataWithNotify(i, j, k, 5);
							}
						}
					}
				}
			}
			DropTorchIfCantStay(world, i, j, k);
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			if (DropTorchIfCantStay(world, i, j, k))
			{
				int i1 = world.GetBlockMetadata(i, j, k);
				bool flag = false;
				if (!world.IsBlockNormalCube(i - 1, j, k) && i1 == 1)
				{
					flag = true;
				}
				if (!world.IsBlockNormalCube(i + 1, j, k) && i1 == 2)
				{
					flag = true;
				}
				if (!world.IsBlockNormalCube(i, j, k - 1) && i1 == 3)
				{
					flag = true;
				}
				if (!world.IsBlockNormalCube(i, j, k + 1) && i1 == 4)
				{
					flag = true;
				}
				if (!Func_31028_g(world, i, j - 1, k) && i1 == 5)
				{
					flag = true;
				}
				if (flag)
				{
					DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
					world.SetBlockWithNotify(i, j, k, 0);
				}
			}
		}

		private bool DropTorchIfCantStay(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			if (!CanPlaceBlockAt(world, i, j, k))
			{
				DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
				world.SetBlockWithNotify(i, j, k, 0);
				return false;
			}
			else
			{
				return true;
			}
		}

		public override net.minecraft.src.MovingObjectPosition CollisionRayTrace(net.minecraft.src.World
			 world, int i, int j, int k, net.minecraft.src.Vec3D vec3d, net.minecraft.src.Vec3D
			 vec3d1)
		{
			int l = world.GetBlockMetadata(i, j, k) & 7;
			float f = 0.15F;
			if (l == 1)
			{
				SetBlockBounds(0.0F, 0.2F, 0.5F - f, f * 2.0F, 0.8F, 0.5F + f);
			}
			else
			{
				if (l == 2)
				{
					SetBlockBounds(1.0F - f * 2.0F, 0.2F, 0.5F - f, 1.0F, 0.8F, 0.5F + f);
				}
				else
				{
					if (l == 3)
					{
						SetBlockBounds(0.5F - f, 0.2F, 0.0F, 0.5F + f, 0.8F, f * 2.0F);
					}
					else
					{
						if (l == 4)
						{
							SetBlockBounds(0.5F - f, 0.2F, 1.0F - f * 2.0F, 0.5F + f, 0.8F, 1.0F);
						}
						else
						{
							float f1 = 0.1F;
							SetBlockBounds(0.5F - f1, 0.0F, 0.5F - f1, 0.5F + f1, 0.6F, 0.5F + f1);
						}
					}
				}
			}
			return base.CollisionRayTrace(world, i, j, k, vec3d, vec3d1);
		}
	}
}
