// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockObsidian : net.minecraft.src.BlockStone
	{
		public BlockObsidian(int i, int j)
			: base(i, j)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            BlockStone, Block
		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 1;
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Block.obsidian.blockID;
		}
	}
}
