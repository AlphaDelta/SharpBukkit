// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockFlowing : net.minecraft.src.BlockFluid
	{
		protected internal BlockFlowing(int i, net.minecraft.src.Material material)
			: base(i, material)
		{
			// Referenced classes of package net.minecraft.src:
			//            BlockFluid, World, Material, WorldProvider, 
			//            Block
			field_659_a = 0;
			field_658_b = new bool[4];
			field_660_c = new int[4];
		}

		private void Func_30004_i(net.minecraft.src.World world, int i, int j, int k)
		{
			int l = world.GetBlockMetadata(i, j, k);
			world.SetBlockAndMetadata(i, j, k, blockID + 1, l);
			world.MarkBlocksDirty(i, j, k, i, j, k);
			world.MarkBlockNeedsUpdate(i, j, k);
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			int l = Func_301_g(world, i, j, k);
			byte byte0 = 1;
			if (blockMaterial == net.minecraft.src.Material.lava && !world.worldProvider.isHellWorld)
			{
				byte0 = 2;
			}
			bool flag = true;
			if (l > 0)
			{
				int i1 = -100;
				field_659_a = 0;
				i1 = Func_307_e(world, i - 1, j, k, i1);
				i1 = Func_307_e(world, i + 1, j, k, i1);
				i1 = Func_307_e(world, i, j, k - 1, i1);
				i1 = Func_307_e(world, i, j, k + 1, i1);
				int j1 = i1 + byte0;
				if (j1 >= 8 || i1 < 0)
				{
					j1 = -1;
				}
				if (Func_301_g(world, i, j + 1, k) >= 0)
				{
					int l1 = Func_301_g(world, i, j + 1, k);
					if (l1 >= 8)
					{
						j1 = l1;
					}
					else
					{
						j1 = l1 + 8;
					}
				}
				if (field_659_a >= 2 && blockMaterial == net.minecraft.src.Material.water)
				{
					if (world.GetBlockMaterial(i, j - 1, k).IsSolid())
					{
						j1 = 0;
					}
					else
					{
						if (world.GetBlockMaterial(i, j - 1, k) == blockMaterial && world.GetBlockMetadata
							(i, j, k) == 0)
						{
							j1 = 0;
						}
					}
				}
				if (blockMaterial == net.minecraft.src.Material.lava && l < 8 && j1 < 8 && j1 > l
					 && random.Next(4) != 0)
				{
					j1 = l;
					flag = false;
				}
				if (j1 != l)
				{
					l = j1;
					if (l < 0)
					{
						world.SetBlockWithNotify(i, j, k, 0);
					}
					else
					{
						world.SetBlockMetadataWithNotify(i, j, k, l);
						world.ScheduleUpdateTick(i, j, k, blockID, TickRate());
						world.NotifyBlocksOfNeighborChange(i, j, k, blockID);
					}
				}
				else
				{
					if (flag)
					{
						Func_30004_i(world, i, j, k);
					}
				}
			}
			else
			{
				Func_30004_i(world, i, j, k);
			}
			if (Func_312_l(world, i, j - 1, k))
			{
				if (l >= 8)
				{
					world.SetBlockAndMetadataWithNotify(i, j - 1, k, blockID, l);
				}
				else
				{
					world.SetBlockAndMetadataWithNotify(i, j - 1, k, blockID, l + 8);
				}
			}
			else
			{
				if (l >= 0 && (l == 0 || Func_309_k(world, i, j - 1, k)))
				{
					bool[] aflag = Func_4035_j(world, i, j, k);
					int k1 = l + byte0;
					if (l >= 8)
					{
						k1 = 1;
					}
					if (k1 >= 8)
					{
						return;
					}
					if (aflag[0])
					{
						Func_311_f(world, i - 1, j, k, k1);
					}
					if (aflag[1])
					{
						Func_311_f(world, i + 1, j, k, k1);
					}
					if (aflag[2])
					{
						Func_311_f(world, i, j, k - 1, k1);
					}
					if (aflag[3])
					{
						Func_311_f(world, i, j, k + 1, k1);
					}
				}
			}
		}

		private void Func_311_f(net.minecraft.src.World world, int i, int j, int k, int l
			)
		{
			if (Func_312_l(world, i, j, k))
			{
				int i1 = world.GetBlockId(i, j, k);
				if (i1 > 0)
				{
					if (blockMaterial == net.minecraft.src.Material.lava)
					{
						Func_300_h(world, i, j, k);
					}
					else
					{
						net.minecraft.src.Block.blocksList[i1].DropBlockAsItem(world, i, j, k, world.GetBlockMetadata
							(i, j, k));
					}
				}
				world.SetBlockAndMetadataWithNotify(i, j, k, blockID, l);
			}
		}

		private int Func_4034_a(net.minecraft.src.World world, int i, int j, int k, int l
			, int i1)
		{
			int j1 = 1000;
			for (int k1 = 0; k1 < 4; k1++)
			{
				if (k1 == 0 && i1 == 1 || k1 == 1 && i1 == 0 || k1 == 2 && i1 == 3 || k1 == 3 && 
					i1 == 2)
				{
					continue;
				}
				int l1 = i;
				int i2 = j;
				int j2 = k;
				if (k1 == 0)
				{
					l1--;
				}
				if (k1 == 1)
				{
					l1++;
				}
				if (k1 == 2)
				{
					j2--;
				}
				if (k1 == 3)
				{
					j2++;
				}
				if (Func_309_k(world, l1, i2, j2) || world.GetBlockMaterial(l1, i2, j2) == blockMaterial
					 && world.GetBlockMetadata(l1, i2, j2) == 0)
				{
					continue;
				}
				if (!Func_309_k(world, l1, i2 - 1, j2))
				{
					return l;
				}
				if (l >= 4)
				{
					continue;
				}
				int k2 = Func_4034_a(world, l1, i2, j2, l + 1, k1);
				if (k2 < j1)
				{
					j1 = k2;
				}
			}
			return j1;
		}

		private bool[] Func_4035_j(net.minecraft.src.World world, int i, int j, int k)
		{
			for (int l = 0; l < 4; l++)
			{
				field_660_c[l] = 1000;
				int j1 = i;
				int i2 = j;
				int j2 = k;
				if (l == 0)
				{
					j1--;
				}
				if (l == 1)
				{
					j1++;
				}
				if (l == 2)
				{
					j2--;
				}
				if (l == 3)
				{
					j2++;
				}
				if (Func_309_k(world, j1, i2, j2) || world.GetBlockMaterial(j1, i2, j2) == blockMaterial
					 && world.GetBlockMetadata(j1, i2, j2) == 0)
				{
					continue;
				}
				if (!Func_309_k(world, j1, i2 - 1, j2))
				{
					field_660_c[l] = 0;
				}
				else
				{
					field_660_c[l] = Func_4034_a(world, j1, i2, j2, 1, l);
				}
			}
			int i1 = field_660_c[0];
			for (int k1 = 1; k1 < 4; k1++)
			{
				if (field_660_c[k1] < i1)
				{
					i1 = field_660_c[k1];
				}
			}
			for (int l1 = 0; l1 < 4; l1++)
			{
				field_658_b[l1] = field_660_c[l1] == i1;
			}
			return field_658_b;
		}

		private bool Func_309_k(net.minecraft.src.World world, int x, int y, int z)
		{
			int l = world.GetBlockId(x, y, z);
			if (l == net.minecraft.src.Block.doorWood.blockID
				|| l == net.minecraft.src.Block.doorSteel.blockID
				|| l == net.minecraft.src.Block.signPost.blockID
				|| l == net.minecraft.src.Block.ladder.blockID
				|| l == net.minecraft.src.Block.reed.blockID)
			{
				return true;
			}
			if (l == 0)
			{
				return false;
			}
			net.minecraft.src.Material material = net.minecraft.src.Block.blocksList[l].blockMaterial;
			return material.GetIsSolid();
		}

		protected internal virtual int Func_307_e(net.minecraft.src.World world, int i, int
			 j, int k, int l)
		{
			int i1 = Func_301_g(world, i, j, k);
			if (i1 < 0)
			{
				return l;
			}
			if (i1 == 0)
			{
				field_659_a++;
			}
			if (i1 >= 8)
			{
				i1 = 0;
			}
			return l >= 0 && i1 >= l ? l : i1;
		}

		private bool Func_312_l(net.minecraft.src.World world, int i, int j, int k)
		{
			net.minecraft.src.Material material = world.GetBlockMaterial(i, j, k);
			if (material == blockMaterial)
			{
				return false;
			}
			if (material == net.minecraft.src.Material.lava)
			{
				return false;
			}
			else
			{
				return !Func_309_k(world, i, j, k);
			}
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			base.OnBlockAdded(world, i, j, k);
			if (world.GetBlockId(i, j, k) == blockID)
			{
				world.ScheduleUpdateTick(i, j, k, blockID, TickRate());
			}
		}

		internal int field_659_a;

		internal bool[] field_658_b;

		internal int[] field_660_c;
	}
}
