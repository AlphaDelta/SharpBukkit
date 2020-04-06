// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockDeadBush : net.minecraft.src.BlockFlower
	{
		protected internal BlockDeadBush(int i, int j)
			: base(i, j)
		{
			// Referenced classes of package net.minecraft.src:
			//            BlockFlower, Block
			float f = 0.4F;
			SetBlockBounds(0.5F - f, 0.0F, 0.5F - f, 0.5F + f, 0.8F, 0.5F + f);
		}

		protected internal override bool CanThisPlantGrowOnThisBlockID(int i)
		{
			return i == net.minecraft.src.Block.sand.blockID;
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			return blockIndexInTexture;
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return -1;
		}
	}
}
