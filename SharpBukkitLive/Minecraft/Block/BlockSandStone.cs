// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockSandStone : net.minecraft.src.Block
	{
		public BlockSandStone(int i)
			: base(i, 192, net.minecraft.src.Material.rock)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Block, Material
		public override int GetBlockTextureFromSide(int i)
		{
			if (i == 1)
			{
				return blockIndexInTexture - 16;
			}
			if (i == 0)
			{
				return blockIndexInTexture + 16;
			}
			else
			{
				return blockIndexInTexture;
			}
		}
	}
}
