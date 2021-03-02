// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldGenClay : net.minecraft.src.WorldGenerator
	{
		public WorldGenClay(int i)
		{
			// Referenced classes of package net.minecraft.src:
			//            WorldGenerator, Block, World, Material, 
			//            MathHelper
			clayBlockId = net.minecraft.src.Block.CLAY.ID;
			numberOfBlocks = i;
		}

		public override bool Generate(net.minecraft.src.World world, SharpBukkitLive.SharpBukkit.SharpRandom random
			, int i, int j, int k)
		{
			if (world.GetBlockMaterial(i, j, k) != net.minecraft.src.Material.water)
			{
				return false;
			}
			float f = ((float)random.NextDouble()) * 3.141593F;
			double d = (float)(i + 8) + (net.minecraft.src.MathHelper.Sin(f) * (float)numberOfBlocks
				) / 8F;
			double d1 = (float)(i + 8) - (net.minecraft.src.MathHelper.Sin(f) * (float)numberOfBlocks
				) / 8F;
			double d2 = (float)(k + 8) + (net.minecraft.src.MathHelper.Cos(f) * (float)numberOfBlocks
				) / 8F;
			double d3 = (float)(k + 8) - (net.minecraft.src.MathHelper.Cos(f) * (float)numberOfBlocks
				) / 8F;
			double d4 = j + random.Next(3) + 2;
			double d5 = j + random.Next(3) + 2;
			for (int l = 0; l <= numberOfBlocks; l++)
			{
				double d6 = d + ((d1 - d) * (double)l) / (double)numberOfBlocks;
				double d7 = d4 + ((d5 - d4) * (double)l) / (double)numberOfBlocks;
				double d8 = d2 + ((d3 - d2) * (double)l) / (double)numberOfBlocks;
				double d9 = (random.NextDouble() * (double)numberOfBlocks) / 16D;
				double d10 = (double)(net.minecraft.src.MathHelper.Sin(((float)l * 3.141593F) / (
					float)numberOfBlocks) + 1.0F) * d9 + 1.0D;
				double d11 = (double)(net.minecraft.src.MathHelper.Sin(((float)l * 3.141593F) / (
					float)numberOfBlocks) + 1.0F) * d9 + 1.0D;
				int i1 = net.minecraft.src.MathHelper.Floor_double(d6 - d10 / 2D);
				int j1 = net.minecraft.src.MathHelper.Floor_double(d6 + d10 / 2D);
				int k1 = net.minecraft.src.MathHelper.Floor_double(d7 - d11 / 2D);
				int l1 = net.minecraft.src.MathHelper.Floor_double(d7 + d11 / 2D);
				int i2 = net.minecraft.src.MathHelper.Floor_double(d8 - d10 / 2D);
				int j2 = net.minecraft.src.MathHelper.Floor_double(d8 + d10 / 2D);
				for (int k2 = i1; k2 <= j1; k2++)
				{
					for (int l2 = k1; l2 <= l1; l2++)
					{
						for (int i3 = i2; i3 <= j2; i3++)
						{
							double d12 = (((double)k2 + 0.5D) - d6) / (d10 / 2D);
							double d13 = (((double)l2 + 0.5D) - d7) / (d11 / 2D);
							double d14 = (((double)i3 + 0.5D) - d8) / (d10 / 2D);
							if (d12 * d12 + d13 * d13 + d14 * d14 >= 1.0D)
							{
								continue;
							}
							int j3 = world.GetBlockId(k2, l2, i3);
							if (j3 == net.minecraft.src.Block.SAND.ID)
							{
								world.SetBlock(k2, l2, i3, clayBlockId);
							}
						}
					}
				}
			}
			return true;
		}

		private int clayBlockId;

		private int numberOfBlocks;
	}
}
