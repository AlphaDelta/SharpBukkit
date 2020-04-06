// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockOreStorage : net.minecraft.src.Block
	{
		public BlockOreStorage(int i, int j)
			: base(i, net.minecraft.src.Material.iron)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material
			blockIndexInTexture = j;
		}

		public override int GetBlockTextureFromSide(int i)
		{
			return blockIndexInTexture;
		}
	}
}
