// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockBreakable : net.minecraft.src.Block
	{
		protected internal BlockBreakable(int i, int j, net.minecraft.src.Material material
			, bool flag)
			: base(i, j, material)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material
			field_6084_a = flag;
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		private bool field_6084_a;
	}
}
