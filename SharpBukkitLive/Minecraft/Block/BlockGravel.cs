// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockGravel : net.minecraft.src.BlockSand
	{
		public BlockGravel(int i, int j)
			: base(i, j)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            BlockSand, Item
		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (random.Next(10) == 0)
			{
				return net.minecraft.src.Item.flint.shiftedIndex;
			}
			else
			{
				return blockID;
			}
		}
	}
}
