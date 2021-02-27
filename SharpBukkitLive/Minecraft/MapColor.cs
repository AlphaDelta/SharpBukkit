// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class MapColor
	{
		private MapColor(int i, int j)
		{
			field_28184_q = i;
			field_28185_p = j;
			field_28200_a[i] = this;
		}

		public static readonly net.minecraft.src.MapColor[] field_28200_a = new net.minecraft.src.MapColor
			[16];

		public static readonly net.minecraft.src.MapColor field_28199_b = new net.minecraft.src.MapColor
			(0, 0);

		public static readonly net.minecraft.src.MapColor field_28198_c = new net.minecraft.src.MapColor
			(1, 0x7fb238);

		public static readonly net.minecraft.src.MapColor field_28197_d = new net.minecraft.src.MapColor
			(2, 0xf7e9a3);

		public static readonly net.minecraft.src.MapColor field_28196_e = new net.minecraft.src.MapColor
			(3, 0xa7a7a7);

		public static readonly net.minecraft.src.MapColor field_28195_f = new net.minecraft.src.MapColor
			(4, 0xff0000);

		public static readonly net.minecraft.src.MapColor field_28194_g = new net.minecraft.src.MapColor
			(5, 0xa0a0ff);

		public static readonly net.minecraft.src.MapColor field_28193_h = new net.minecraft.src.MapColor
			(6, 0xa7a7a7);

		public static readonly net.minecraft.src.MapColor field_28192_i = new net.minecraft.src.MapColor
			(7, 31744);

		public static readonly net.minecraft.src.MapColor field_28191_j = new net.minecraft.src.MapColor
			(8, 0xffffff);

		public static readonly net.minecraft.src.MapColor field_28190_k = new net.minecraft.src.MapColor
			(9, 0xa4a8b8);

		public static readonly net.minecraft.src.MapColor field_28189_l = new net.minecraft.src.MapColor
			(10, 0xb76a2f);

		public static readonly net.minecraft.src.MapColor field_28188_m = new net.minecraft.src.MapColor
			(11, 0x707070);

		public static readonly net.minecraft.src.MapColor field_28187_n = new net.minecraft.src.MapColor
			(12, 0x4040ff);

		public static readonly net.minecraft.src.MapColor field_28186_o = new net.minecraft.src.MapColor
			(13, 0x685332);

		public readonly int field_28185_p;

		public readonly int field_28184_q;
	}
}
