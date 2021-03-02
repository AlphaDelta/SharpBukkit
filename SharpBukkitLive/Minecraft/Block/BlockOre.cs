// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockOre : net.minecraft.src.Block
	{
		public BlockOre(int i, int j)
			: base(i, j, net.minecraft.src.Material.rock)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Block, Material, Item
		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (ID == net.minecraft.src.Block.COAL_ORE.ID)
			{
				return net.minecraft.src.Item.COAL.ID;
			}
			if (ID == net.minecraft.src.Block.DIAMOND_ORE.ID)
			{
				return net.minecraft.src.Item.DIAMOND.ID;
			}
			if (ID == net.minecraft.src.Block.LAPIS_ORE.ID)
			{
				return net.minecraft.src.Item.INK_SACK.ID;
			}
			else
			{
				return ID;
			}
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (ID == net.minecraft.src.Block.LAPIS_ORE.ID)
			{
				return 4 + random.Next(5);
			}
			else
			{
				return 1;
			}
		}

		protected internal override int DamageDropped(int i)
		{
			return ID != net.minecraft.src.Block.LAPIS_ORE.ID ? 0 : 4;
		}
	}
}
