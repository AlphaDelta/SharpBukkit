// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	[System.Serializable]
	public sealed class EnumSkyBlock
	{
		public static readonly net.minecraft.src.EnumSkyBlock Sky = new net.minecraft.src.EnumSkyBlock
			("Sky", 0, 15);

		public static readonly net.minecraft.src.EnumSkyBlock Block = new net.minecraft.src.EnumSkyBlock
			("Block", 1, 0);

		private EnumSkyBlock(string s, int i, int j)
		{
/*
    public static EnumSkyBlock[] values()
    {
        return (EnumSkyBlock[])field_983_d.clone();
    }

    public static EnumSkyBlock valueOf(String s)
    {
        return (EnumSkyBlock)Enum.valueOf(net.minecraft.src.EnumSkyBlock.class, s);
    }
*/
			//        super(s, i);
			field_984_c = j;
		}

		public readonly int field_984_c;

		private static readonly net.minecraft.src.EnumSkyBlock[] field_983_d;

		static EnumSkyBlock()
		{
/*
    public static final EnumSkyBlock Sky;
    public static final EnumSkyBlock Block;
*/
 /* synthetic field */
/*
        Sky = new EnumSkyBlock("Sky", 0, 15);
        Block = new EnumSkyBlock("Block", 1, 0);
*/
			field_983_d = (new net.minecraft.src.EnumSkyBlock[] { net.minecraft.src.EnumSkyBlock
				.Sky, net.minecraft.src.EnumSkyBlock.Block });
		}
	}
}
