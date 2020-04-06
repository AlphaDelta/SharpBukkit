// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockGlowStone : net.minecraft.src.Block
	{
		public BlockGlowStone(int i, int j, net.minecraft.src.Material material)
			: base(i, j, material)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Block, Item, Material
		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 2 + random.Next(3);
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Item.lightStoneDust.shiftedIndex;
		}
	}
}
