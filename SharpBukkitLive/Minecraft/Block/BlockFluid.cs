// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System;

namespace net.minecraft.src
{
	public abstract class BlockFluid : net.minecraft.src.Block
	{
		protected internal BlockFluid(int i, net.minecraft.src.Material material)
			: base(i, (material != net.minecraft.src.Material.lava ? 12 : 14) * 16 + 13, material
				)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, World, IBlockAccess, 
			//            Vec3D, AxisAlignedBB, Entity
			float f = 0.0F;
			float f1 = 0.0F;
			SetBlockBounds(0.0F + f1, 0.0F + f, 0.0F + f1, 1.0F + f1, 1.0F + f, 1.0F + f1);
			SetTickOnLoad(true);
		}

		public static float SetFluidHeight(int i)
		{
			if (i >= 8)
			{
				i = 0;
			}
			float f = (float)(i + 1) / 9F;
			return f;
		}

		public override int GetBlockTextureFromSide(int i)
		{
			if (i == 0 || i == 1)
			{
				return blockIndexInTexture;
			}
			else
			{
				return blockIndexInTexture + 1;
			}
		}

		protected internal virtual int Func_301_g(net.minecraft.src.World world, int i, int
			 j, int k)
		{
			if (world.GetBlockMaterial(i, j, k) != blockMaterial)
			{
				return -1;
			}
			else
			{
				return world.GetBlockMetadata(i, j, k);
			}
		}

		protected internal virtual int Func_303_b(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k)
		{
			if (iblockaccess.GetBlockMaterial(i, j, k) != blockMaterial)
			{
				return -1;
			}
			int l = iblockaccess.GetBlockMetadata(i, j, k);
			if (l >= 8)
			{
				l = 0;
			}
			return l;
		}

		public override bool IsACube()
		{
			return false;
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		public override bool CanCollideCheck(int i, bool flag)
		{
			return flag && i == 0;
		}

		public override bool ShouldSideBeRendered(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k, int l)
		{
			net.minecraft.src.Material material = iblockaccess.GetBlockMaterial(i, j, k);
			if (material == blockMaterial)
			{
				return false;
			}
			if (material == net.minecraft.src.Material.ice)
			{
				return false;
			}
			if (l == 1)
			{
				return true;
			}
			else
			{
				return base.ShouldSideBeRendered(iblockaccess, i, j, k, l);
			}
		}

		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			return null;
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 0;
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 0;
		}

		private net.minecraft.src.Vec3D Func_298_c(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k)
		{
			net.minecraft.src.Vec3D vec3d = net.minecraft.src.Vec3D.CreateVector(0.0D, 0.0D, 
				0.0D);
			int l = Func_303_b(iblockaccess, i, j, k);
			for (int i1 = 0; i1 < 4; i1++)
			{
				int j1 = i;
				int k1 = j;
				int l1 = k;
				if (i1 == 0)
				{
					j1--;
				}
				if (i1 == 1)
				{
					l1--;
				}
				if (i1 == 2)
				{
					j1++;
				}
				if (i1 == 3)
				{
					l1++;
				}
				int i2 = Func_303_b(iblockaccess, j1, k1, l1);
				if (i2 < 0)
				{
					if (iblockaccess.GetBlockMaterial(j1, k1, l1).GetIsSolid())
					{
						continue;
					}
					i2 = Func_303_b(iblockaccess, j1, k1 - 1, l1);
					if (i2 >= 0)
					{
						int j2 = i2 - (l - 8);
						vec3d = vec3d.AddVector((j1 - i) * j2, (k1 - j) * j2, (l1 - k) * j2);
					}
					continue;
				}
				if (i2 >= 0)
				{
					int k2 = i2 - l;
					vec3d = vec3d.AddVector((j1 - i) * k2, (k1 - j) * k2, (l1 - k) * k2);
				}
			}
			if (iblockaccess.GetBlockMetadata(i, j, k) >= 8)
			{
				bool flag = false;
				if (flag || ShouldSideBeRendered(iblockaccess, i, j, k - 1, 2))
				{
					flag = true;
				}
				if (flag || ShouldSideBeRendered(iblockaccess, i, j, k + 1, 3))
				{
					flag = true;
				}
				if (flag || ShouldSideBeRendered(iblockaccess, i - 1, j, k, 4))
				{
					flag = true;
				}
				if (flag || ShouldSideBeRendered(iblockaccess, i + 1, j, k, 5))
				{
					flag = true;
				}
				if (flag || ShouldSideBeRendered(iblockaccess, i, j + 1, k - 1, 2))
				{
					flag = true;
				}
				if (flag || ShouldSideBeRendered(iblockaccess, i, j + 1, k + 1, 3))
				{
					flag = true;
				}
				if (flag || ShouldSideBeRendered(iblockaccess, i - 1, j + 1, k, 4))
				{
					flag = true;
				}
				if (flag || ShouldSideBeRendered(iblockaccess, i + 1, j + 1, k, 5))
				{
					flag = true;
				}
				if (flag)
				{
					vec3d = vec3d.Normalize().AddVector(0.0D, -6D, 0.0D);
				}
			}
			vec3d = vec3d.Normalize();
			return vec3d;
		}

		public override void VelocityToAddToEntity(net.minecraft.src.World world, int i, 
			int j, int k, net.minecraft.src.Entity entity, net.minecraft.src.Vec3D vec3d)
		{
			net.minecraft.src.Vec3D vec3d1 = Func_298_c(world, i, j, k);
			vec3d.xCoord += vec3d1.xCoord;
			vec3d.yCoord += vec3d1.yCoord;
			vec3d.zCoord += vec3d1.zCoord;
		}

		public override int TickRate()
		{
			if (blockMaterial == net.minecraft.src.Material.water)
			{
				return 5;
			}
			return blockMaterial != net.minecraft.src.Material.lava ? 0 : 30;
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			base.UpdateTick(world, i, j, k, random);
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			CheckForHarden(world, i, j, k);
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			CheckForHarden(world, i, j, k);
		}

		private void CheckForHarden(net.minecraft.src.World world, int i, int j, int k)
		{
			if (world.GetBlockId(i, j, k) != ID)
			{
				return;
			}
			if (blockMaterial == net.minecraft.src.Material.lava)
			{
				bool flag = false;
				if (flag || world.GetBlockMaterial(i, j, k - 1) == net.minecraft.src.Material.water)
				{
					flag = true;
				}
				if (flag || world.GetBlockMaterial(i, j, k + 1) == net.minecraft.src.Material.water)
				{
					flag = true;
				}
				if (flag || world.GetBlockMaterial(i - 1, j, k) == net.minecraft.src.Material.water)
				{
					flag = true;
				}
				if (flag || world.GetBlockMaterial(i + 1, j, k) == net.minecraft.src.Material.water)
				{
					flag = true;
				}
				if (flag || world.GetBlockMaterial(i, j + 1, k) == net.minecraft.src.Material.water)
				{
					flag = true;
				}
				if (flag)
				{
					int l = world.GetBlockMetadata(i, j, k);
					if (l == 0)
					{
						world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.OBSISIAN.ID);
					}
					else
					{
						if (l <= 4)
						{
							world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.COBBLESTONE.ID);
						}
					}
					Func_300_h(world, i, j, k);
				}
			}
		}

		SharpRandom rng = new SharpRandom();
		protected internal virtual void Func_300_h(net.minecraft.src.World world, int i, 
			int j, int k)
		{
			world.PlaySoundEffect((float)i + 0.5F, (float)j + 0.5F, (float)k + 0.5F, "random.fizz"
				, 0.5F, 2.6F + (world.rand.NextFloat() - world.rand.NextFloat()) * 0.8F);
			for (int l = 0; l < 8; l++)
			{
				world.SpawnParticle("largesmoke", (double)i + rng.NextDouble(), (double)j + 1.2D
					, (double)k + rng.NextDouble(), 0.0D, 0.0D, 0.0D);
			}
		}
	}
}
