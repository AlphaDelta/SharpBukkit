// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldGenLakes : net.minecraft.src.WorldGenerator
	{
		public WorldGenLakes(int i)
		{
			// Referenced classes of package net.minecraft.src:
			//            WorldGenerator, World, Material, Block, 
			//            EnumSkyBlock, BlockGrass
			field_15005_a = i;
		}

		public override bool Generate(net.minecraft.src.World world, SharpBukkitLive.SharpBukkit.SharpRandom random
			, int i, int j, int k)
		{
			i -= 8;
			for (k -= 8; j > 0 && world.IsAirBlock(i, j, k); j--)
			{
			}
			j -= 4;
			bool[] aflag = new bool[2048];
			int l = random.Next(4) + 4;
			for (int i1 = 0; i1 < l; i1++)
			{
				double d = random.NextDouble() * 6D + 3D;
				double d1 = random.NextDouble() * 4D + 2D;
				double d2 = random.NextDouble() * 6D + 3D;
				double d3 = random.NextDouble() * (16D - d - 2D) + 1.0D + d / 2D;
				double d4 = random.NextDouble() * (8D - d1 - 4D) + 2D + d1 / 2D;
				double d5 = random.NextDouble() * (16D - d2 - 2D) + 1.0D + d2 / 2D;
				for (int j4 = 1; j4 < 15; j4++)
				{
					for (int k4 = 1; k4 < 15; k4++)
					{
						for (int l4 = 1; l4 < 7; l4++)
						{
							double d6 = ((double)j4 - d3) / (d / 2D);
							double d7 = ((double)l4 - d4) / (d1 / 2D);
							double d8 = ((double)k4 - d5) / (d2 / 2D);
							double d9 = d6 * d6 + d7 * d7 + d8 * d8;
							if (d9 < 1.0D)
							{
								aflag[(j4 * 16 + k4) * 8 + l4] = true;
							}
						}
					}
				}
			}
			for (int j1 = 0; j1 < 16; j1++)
			{
				for (int j2 = 0; j2 < 16; j2++)
				{
					for (int j3 = 0; j3 < 8; j3++)
					{
						bool flag = !aflag[(j1 * 16 + j2) * 8 + j3] && (j1 < 15 && aflag[((j1 + 1) * 16 +
							 j2) * 8 + j3] || j1 > 0 && aflag[((j1 - 1) * 16 + j2) * 8 + j3] || j2 < 15 && aflag
							[(j1 * 16 + (j2 + 1)) * 8 + j3] || j2 > 0 && aflag[(j1 * 16 + (j2 - 1)) * 8 + j3
							] || j3 < 7 && aflag[(j1 * 16 + j2) * 8 + (j3 + 1)] || j3 > 0 && aflag[(j1 * 16 
							+ j2) * 8 + (j3 - 1)]);
						if (!flag)
						{
							continue;
						}
						net.minecraft.src.Material material = world.GetBlockMaterial(i + j1, j + j3, k + 
							j2);
						if (j3 >= 4 && material.GetIsLiquid())
						{
							return false;
						}
						if (j3 < 4 && !material.IsSolid() && world.GetBlockId(i + j1, j + j3, k + j2) != 
							field_15005_a)
						{
							return false;
						}
					}
				}
			}
			for (int k1 = 0; k1 < 16; k1++)
			{
				for (int k2 = 0; k2 < 16; k2++)
				{
					for (int k3 = 0; k3 < 8; k3++)
					{
						if (aflag[(k1 * 16 + k2) * 8 + k3])
						{
							world.SetBlock(i + k1, j + k3, k + k2, k3 < 4 ? field_15005_a : 0);
						}
					}
				}
			}
			for (int l1 = 0; l1 < 16; l1++)
			{
				for (int l2 = 0; l2 < 16; l2++)
				{
					for (int l3 = 4; l3 < 8; l3++)
					{
						if (aflag[(l1 * 16 + l2) * 8 + l3] && world.GetBlockId(i + l1, (j + l3) - 1, k + 
							l2) == net.minecraft.src.Block.DIRT.ID && world.GetSavedLightValue(net.minecraft.src.EnumSkyBlock
							.Sky, i + l1, j + l3, k + l2) > 0)
						{
							world.SetBlock(i + l1, (j + l3) - 1, k + l2, net.minecraft.src.Block.GRASS.ID
								);
						}
					}
				}
			}
			if (net.minecraft.src.Block.blocksList[field_15005_a].blockMaterial == net.minecraft.src.Material
				.lava)
			{
				for (int i2 = 0; i2 < 16; i2++)
				{
					for (int i3 = 0; i3 < 16; i3++)
					{
						for (int i4 = 0; i4 < 8; i4++)
						{
							bool flag1 = !aflag[(i2 * 16 + i3) * 8 + i4] && (i2 < 15 && aflag[((i2 + 1) * 16 
								+ i3) * 8 + i4] || i2 > 0 && aflag[((i2 - 1) * 16 + i3) * 8 + i4] || i3 < 15 && 
								aflag[(i2 * 16 + (i3 + 1)) * 8 + i4] || i3 > 0 && aflag[(i2 * 16 + (i3 - 1)) * 8
								 + i4] || i4 < 7 && aflag[(i2 * 16 + i3) * 8 + (i4 + 1)] || i4 > 0 && aflag[(i2 
								* 16 + i3) * 8 + (i4 - 1)]);
							if (flag1 && (i4 < 4 || random.Next(2) != 0) && world.GetBlockMaterial(i + i2, 
								j + i4, k + i3).IsSolid())
							{
								world.SetBlock(i + i2, j + i4, k + i3, net.minecraft.src.Block.STONE.ID);
							}
						}
					}
				}
			}
			return true;
		}

		private int field_15005_a;
	}
}
