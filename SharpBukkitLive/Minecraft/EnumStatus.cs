// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	[System.Serializable]
	public sealed class EnumStatus
	{
		public static readonly net.minecraft.src.EnumStatus OK = new net.minecraft.src.EnumStatus
			("OK", 0);

		public static readonly net.minecraft.src.EnumStatus NOT_POSSIBLE_HERE = new net.minecraft.src.EnumStatus
			("NOT_POSSIBLE_HERE", 1);

		public static readonly net.minecraft.src.EnumStatus NOT_POSSIBLE_NOW = new net.minecraft.src.EnumStatus
			("NOT_POSSIBLE_NOW", 2);

		public static readonly net.minecraft.src.EnumStatus TOO_FAR_AWAY = new net.minecraft.src.EnumStatus
			("TOO_FAR_AWAY", 3);

		public static readonly net.minecraft.src.EnumStatus OTHER_PROBLEM = new net.minecraft.src.EnumStatus
			("OTHER_PROBLEM", 4);

		private EnumStatus(string s, int i)
		{
		}

		private static readonly net.minecraft.src.EnumStatus[] field_25140_f;

		static EnumStatus()
		{
/*
    public static EnumStatus[] values()
    {
        return (EnumStatus[])field_25140_f.clone();
    }

    public static EnumStatus valueOf(String s)
    {
        return (EnumStatus)Enum.valueOf(net.minecraft.src.EnumStatus.class, s);
    }
*/
			//        super(s, i);
/*
    public static final EnumStatus OK;
    public static final EnumStatus NOT_POSSIBLE_HERE;
    public static final EnumStatus NOT_POSSIBLE_NOW;
    public static final EnumStatus TOO_FAR_AWAY;
    public static final EnumStatus OTHER_PROBLEM;
*/
 /* synthetic field */
/*
        OK = new EnumStatus("OK", 0);
        NOT_POSSIBLE_HERE = new EnumStatus("NOT_POSSIBLE_HERE", 1);
        NOT_POSSIBLE_NOW = new EnumStatus("NOT_POSSIBLE_NOW", 2);
        TOO_FAR_AWAY = new EnumStatus("TOO_FAR_AWAY", 3);
        OTHER_PROBLEM = new EnumStatus("OTHER_PROBLEM", 4);
*/
			field_25140_f = (new net.minecraft.src.EnumStatus[] { net.minecraft.src.EnumStatus
				.OK, net.minecraft.src.EnumStatus.NOT_POSSIBLE_HERE, net.minecraft.src.EnumStatus
				.NOT_POSSIBLE_NOW, net.minecraft.src.EnumStatus.TOO_FAR_AWAY, net.minecraft.src.EnumStatus
				.OTHER_PROBLEM });
		}
	}
}
