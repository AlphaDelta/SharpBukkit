// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemArmor : net.minecraft.src.Item
	{
		public ItemArmor(int i, int j, int k, int l)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item
			armorLevel = j;
			armorType = l;
			renderIndex = k;
			damageReduceAmount = damageReduceAmountArray[l];
			SetMaxDamage(maxDamageArray[l] * 3 << j);
			maxStackSize = 1;
		}

		private static readonly int[] damageReduceAmountArray = new int[] { 3, 8, 6, 3 };

		private static readonly int[] maxDamageArray = new int[] { 11, 16, 15, 13 };

		public readonly int armorLevel;

		public readonly int armorType;

		public readonly int damageReduceAmount;

		public readonly int renderIndex;
	}
}
