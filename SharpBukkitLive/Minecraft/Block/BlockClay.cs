// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockClay : net.minecraft.src.Block
	{
		public BlockClay(int i, int j)
			: base(i, j, net.minecraft.src.Material.clay)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Block, Material, Item
		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Item.CLAY_BALL.ID;
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 4;
		}
	}
}
