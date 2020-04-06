// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	[System.Serializable]
	public sealed class EnumToolMaterial
	{
		public static readonly net.minecraft.src.EnumToolMaterial WOOD = new net.minecraft.src.EnumToolMaterial
			("WOOD", 0, 0, 59, 2.0F, 0);

		public static readonly net.minecraft.src.EnumToolMaterial STONE = new net.minecraft.src.EnumToolMaterial
			("STONE", 1, 1, 131, 4F, 1);

		public static readonly net.minecraft.src.EnumToolMaterial IRON = new net.minecraft.src.EnumToolMaterial
			("IRON", 2, 2, 250, 6F, 2);

		public static readonly net.minecraft.src.EnumToolMaterial EMERALD = new net.minecraft.src.EnumToolMaterial
			("EMERALD", 3, 3, 1561, 8F, 3);

		public static readonly net.minecraft.src.EnumToolMaterial GOLD = new net.minecraft.src.EnumToolMaterial
			("GOLD", 4, 0, 32, 12F, 0);

		private EnumToolMaterial(string s, int i, int j, int k, float f, int l)
		{
/*
    public static EnumToolMaterial[] values()
    {
        return (EnumToolMaterial[])field_21182_j.clone();
    }

    public static EnumToolMaterial valueOf(String s)
    {
        return (EnumToolMaterial)Enum.valueOf(net.minecraft.src.EnumToolMaterial.class, s);
    }
*/
			//        super(s, i);
			harvestLevel = j;
			maxUses = k;
			efficiencyOnProperMaterial = f;
			damageVsEntity = l;
		}

		public int GetMaxUses()
		{
			return maxUses;
		}

		public float GetEfficiencyOnProperMaterial()
		{
			return efficiencyOnProperMaterial;
		}

		public int GetDamageVsEntity()
		{
			return damageVsEntity;
		}

		public int GetHarvestLevel()
		{
			return harvestLevel;
		}

		private readonly int harvestLevel;

		private readonly int maxUses;

		private readonly float efficiencyOnProperMaterial;

		private readonly int damageVsEntity;

		private static readonly net.minecraft.src.EnumToolMaterial[] field_21182_j;

		static EnumToolMaterial()
		{
/*
    public static final EnumToolMaterial WOOD;
    public static final EnumToolMaterial STONE;
    public static final EnumToolMaterial IRON;
    public static final EnumToolMaterial EMERALD;
    public static final EnumToolMaterial GOLD;
*/
 /* synthetic field */
/*
        WOOD = new EnumToolMaterial("WOOD", 0, 0, 59, 2.0F, 0);
        STONE = new EnumToolMaterial("STONE", 1, 1, 131, 4F, 1);
        IRON = new EnumToolMaterial("IRON", 2, 2, 250, 6F, 2);
        EMERALD = new EnumToolMaterial("EMERALD", 3, 3, 1561, 8F, 3);
        GOLD = new EnumToolMaterial("GOLD", 4, 0, 32, 12F, 0);
*/
			field_21182_j = (new net.minecraft.src.EnumToolMaterial[] { net.minecraft.src.EnumToolMaterial
				.WOOD, net.minecraft.src.EnumToolMaterial.STONE, net.minecraft.src.EnumToolMaterial
				.IRON, net.minecraft.src.EnumToolMaterial.EMERALD, net.minecraft.src.EnumToolMaterial
				.GOLD });
		}
	}
}
