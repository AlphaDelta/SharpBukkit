// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockGlass : net.minecraft.src.BlockBreakable
	{
		public BlockGlass(int i, int j, net.minecraft.src.Material material, bool flag)
			: base(i, j, material, flag)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            BlockBreakable, Material
		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 0;
		}
	}
}
