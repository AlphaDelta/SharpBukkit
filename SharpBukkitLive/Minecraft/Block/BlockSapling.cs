// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockSapling : net.minecraft.src.BlockFlower
	{
		protected internal BlockSapling(int i, int j)
			: base(i, j)
		{
			// Referenced classes of package net.minecraft.src:
			//            BlockFlower, World, WorldGenTaiga2, WorldGenForest, 
			//            WorldGenTrees, WorldGenBigTree, WorldGenerator
			float f = 0.4F;
			SetBlockBounds(0.5F - f, 0.0F, 0.5F - f, 0.5F + f, f * 2.0F, 0.5F + f);
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			base.UpdateTick(world, i, j, k, random);
			if (world.GetBlockLightValue(i, j + 1, k) >= 9 && random.Next(30) == 0)
			{
				int l = world.GetBlockMetadata(i, j, k);
				if ((l & 8) == 0)
				{
					world.SetBlockMetadataWithNotify(i, j, k, l | 8);
				}
				else
				{
					GrowTree(world, i, j, k, random);
				}
			}
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			j &= 3;
			if (j == 1)
			{
				return 63;
			}
			if (j == 2)
			{
				return 79;
			}
			else
			{
				return base.GetBlockTextureFromSideAndMetadata(i, j);
			}
		}

		public virtual void GrowTree(net.minecraft.src.World world, int i, int j, int k, 
			SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			int l = world.GetBlockMetadata(i, j, k) & 3;
			world.SetBlock(i, j, k, 0);
			object obj = null;
			if (l == 1) //TODO: Bukkit fix???
			{
				obj = new net.minecraft.src.WorldGenTaiga2();
			}
			else
			{
				if (l == 2)
				{
					obj = new net.minecraft.src.WorldGenForest();
				}
				else
				{
					obj = new net.minecraft.src.WorldGenTrees();
					if (random.Next(10) == 0)
					{
						obj = new net.minecraft.src.WorldGenBigTree();
					}
				}
			}
			if (!((net.minecraft.src.WorldGenerator)(obj)).Generate(world, random, i, j, k))
			{
				world.SetBlockAndMetadata(i, j, k, ID, l);
			}
		}

		protected internal override int DamageDropped(int i)
		{
			return i & 3;
		}
	}
}
