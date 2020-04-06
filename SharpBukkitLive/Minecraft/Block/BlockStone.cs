// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockStone : net.minecraft.src.Block
	{
		public BlockStone(int i, int j)
			: base(i, j, net.minecraft.src.Material.rock)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Block, Material
		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Block.cobblestone.blockID;
		}
	}
}
