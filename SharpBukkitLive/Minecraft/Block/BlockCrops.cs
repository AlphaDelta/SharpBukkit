// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockCrops : net.minecraft.src.BlockFlower
	{
		protected internal BlockCrops(int i, int j)
			: base(i, j)
		{
			// Referenced classes of package net.minecraft.src:
			//            BlockFlower, Block, World, EntityItem, 
			//            ItemStack, Item
			blockIndexInTexture = j;
			SetTickOnLoad(true);
			float f = 0.5F;
			SetBlockBounds(0.5F - f, 0.0F, 0.5F - f, 0.5F + f, 0.25F, 0.5F + f);
		}

		protected internal override bool CanThisPlantGrowOnThisBlockID(int i)
		{
			return i == net.minecraft.src.Block.tilledField.blockID;
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			base.UpdateTick(world, i, j, k, random);
			if (world.GetBlockLightValue(i, j + 1, k) >= 9)
			{
				int l = world.GetBlockMetadata(i, j, k);
				if (l < 7)
				{
					float f = GetGrowthRate(world, i, j, k);
					if (random.Next((int)(100F / f)) == 0)
					{
						l++;
						world.SetBlockMetadataWithNotify(i, j, k, l);
					}
				}
			}
		}

		public virtual void Fertilize(net.minecraft.src.World world, int i, int j, int k)
		{
			world.SetBlockMetadataWithNotify(i, j, k, 7);
		}

		private float GetGrowthRate(net.minecraft.src.World world, int i, int j, int k)
		{
			float f = 1.0F;
			int l = world.GetBlockId(i, j, k - 1);
			int i1 = world.GetBlockId(i, j, k + 1);
			int j1 = world.GetBlockId(i - 1, j, k);
			int k1 = world.GetBlockId(i + 1, j, k);
			int l1 = world.GetBlockId(i - 1, j, k - 1);
			int i2 = world.GetBlockId(i + 1, j, k - 1);
			int j2 = world.GetBlockId(i + 1, j, k + 1);
			int k2 = world.GetBlockId(i - 1, j, k + 1);
			bool flag = j1 == blockID || k1 == blockID;
			bool flag1 = l == blockID || i1 == blockID;
			bool flag2 = l1 == blockID || i2 == blockID || j2 == blockID || k2 == blockID;
			for (int l2 = i - 1; l2 <= i + 1; l2++)
			{
				for (int i3 = k - 1; i3 <= k + 1; i3++)
				{
					int j3 = world.GetBlockId(l2, j - 1, i3);
					float f1 = 0.0F;
					if (j3 == net.minecraft.src.Block.tilledField.blockID)
					{
						f1 = 1.0F;
						if (world.GetBlockMetadata(l2, j - 1, i3) > 0)
						{
							f1 = 3F;
						}
					}
					if (l2 != i || i3 != k)
					{
						f1 /= 4F;
					}
					f += f1;
				}
			}
			if (flag2 || flag && flag1)
			{
				f /= 2.0F;
			}
			return f;
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			if (j < 0)
			{
				j = 7;
			}
			return blockIndexInTexture + j;
		}

		public override void DropBlockAsItemWithChance(net.minecraft.src.World world, int
			 i, int j, int k, int l, float f)
		{
			base.DropBlockAsItemWithChance(world, i, j, k, l, f);
			if (world.singleplayerWorld)
			{
				return;
			}
			for (int i1 = 0; i1 < 3; i1++)
			{
				if (world.rand.Next(15) <= l)
				{
					float f1 = 0.7F;
					float f2 = world.rand.NextFloat() * f1 + (1.0F - f1) * 0.5F;
					float f3 = world.rand.NextFloat() * f1 + (1.0F - f1) * 0.5F;
					float f4 = world.rand.NextFloat() * f1 + (1.0F - f1) * 0.5F;
					net.minecraft.src.EntityItem entityitem = new net.minecraft.src.EntityItem(world, 
						(float)i + f2, (float)j + f3, (float)k + f4, new net.minecraft.src.ItemStack(net.minecraft.src.Item
						.seeds));
					entityitem.delayBeforeCanPickup = 10;
					world.AddEntity(entityitem);
				}
			}
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (i == 7)
			{
				return net.minecraft.src.Item.wheat.shiftedIndex;
			}
			else
			{
				return -1;
			}
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 1;
		}
	}
}
