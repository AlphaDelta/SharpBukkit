// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockTallGrass : net.minecraft.src.BlockFlower
	{
		protected internal BlockTallGrass(int i, int j)
			: base(i, j)
		{
			// Referenced classes of package net.minecraft.src:
			//            BlockFlower, Item
			float f = 0.4F;
			SetBlockBounds(0.5F - f, 0.0F, 0.5F - f, 0.5F + f, 0.8F, 0.5F + f);
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			if (j == 1)
			{
				return blockIndexInTexture;
			}
			if (j == 2)
			{
				return blockIndexInTexture + 16 + 1;
			}
			if (j == 0)
			{
				return blockIndexInTexture + 16;
			}
			else
			{
				return blockIndexInTexture;
			}
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (random.Next(8) == 0)
			{
				return net.minecraft.src.Item.seeds.shiftedIndex;
			}
			else
			{
				return -1;
			}
		}
	}
}
