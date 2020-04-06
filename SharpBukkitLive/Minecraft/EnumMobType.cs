// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	[System.Serializable]
	public sealed class EnumMobType
	{
		public static readonly net.minecraft.src.EnumMobType everything = new net.minecraft.src.EnumMobType
			("everything", 0);

		public static readonly net.minecraft.src.EnumMobType mobs = new net.minecraft.src.EnumMobType
			("mobs", 1);

		public static readonly net.minecraft.src.EnumMobType players = new net.minecraft.src.EnumMobType
			("players", 2);

		private EnumMobType(string s, int i)
		{
		}

		private static readonly net.minecraft.src.EnumMobType[] field_990_d;

		static EnumMobType()
		{
/*
    public static EnumMobType[] values()
    {
        return (EnumMobType[])field_990_d.clone();
    }

    public static EnumMobType valueOf(String s)
    {
        return (EnumMobType)Enum.valueOf(net.minecraft.src.EnumMobType.class, s);
    }
*/
			//        super(s, i);
/*
    public static final EnumMobType everything;
    public static final EnumMobType mobs;
    public static final EnumMobType players;
*/
 /* synthetic field */
/*
        everything = new EnumMobType("everything", 0);
        mobs = new EnumMobType("mobs", 1);
        players = new EnumMobType("players", 2);
*/
			field_990_d = (new net.minecraft.src.EnumMobType[] { net.minecraft.src.EnumMobType
				.everything, net.minecraft.src.EnumMobType.mobs, net.minecraft.src.EnumMobType.players
				 });
		}
	}
}
