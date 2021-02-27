// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockCloth : net.minecraft.src.Block
	{
		public BlockCloth()
			: base(35, 64, net.minecraft.src.Material.cloth)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Block, Material
		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			if (j == 0)
			{
				return blockIndexInTexture;
			}
			else
			{
				j = ~(j & 0xf);
				return 113 + ((j & 8) >> 3) + (j & 7) * 16;
			}
		}

		protected internal override int DamageDropped(int i)
		{
			return i;
		}

		public static int Func_21033_c(int i)
		{
			return ~i & 0xf;
		}

		public static int Func_21034_d(int i)
		{
			return ~i & 0xf;
		}
	}
}
