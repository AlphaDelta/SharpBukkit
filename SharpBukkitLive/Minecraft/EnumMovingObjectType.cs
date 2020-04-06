// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	[System.Serializable]
	public sealed class EnumMovingObjectType
	{
		public static readonly net.minecraft.src.EnumMovingObjectType TILE = new net.minecraft.src.EnumMovingObjectType
			("TILE", 0);

		public static readonly net.minecraft.src.EnumMovingObjectType ENTITY = new net.minecraft.src.EnumMovingObjectType
			("ENTITY", 1);

		private EnumMovingObjectType(string s, int i)
		{
		}

		private static readonly net.minecraft.src.EnumMovingObjectType[] field_21124_c;

		static EnumMovingObjectType()
		{
/*
    public static EnumMovingObjectType[] values()
    {
        return (EnumMovingObjectType[])field_21124_c.clone();
    }

    public static EnumMovingObjectType valueOf(String s)
    {
        return (EnumMovingObjectType)Enum.valueOf(net.minecraft.src.EnumMovingObjectType.class, s);
    }
*/
			//        super(s, i);
/*
    public static final EnumMovingObjectType TILE;
    public static final EnumMovingObjectType ENTITY;
*/
 /* synthetic field */
/*
        TILE = new EnumMovingObjectType("TILE", 0);
        ENTITY = new EnumMovingObjectType("ENTITY", 1);
*/
			field_21124_c = (new net.minecraft.src.EnumMovingObjectType[] { net.minecraft.src.EnumMovingObjectType
				.TILE, net.minecraft.src.EnumMovingObjectType.ENTITY });
		}
	}
}
