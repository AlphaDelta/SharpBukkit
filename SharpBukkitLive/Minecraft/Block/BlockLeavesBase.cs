// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockLeavesBase : net.minecraft.src.Block
	{
		protected internal BlockLeavesBase(int i, int j, net.minecraft.src.Material material
			, bool flag)
			: base(i, j, material)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material
			graphicsLevel = flag;
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		protected internal bool graphicsLevel;
	}
}
