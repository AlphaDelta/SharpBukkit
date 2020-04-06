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
			if (blockID == net.minecraft.src.Block.oreCoal.blockID)
			{
				return net.minecraft.src.Item.coal.shiftedIndex;
			}
			if (blockID == net.minecraft.src.Block.oreDiamond.blockID)
			{
				return net.minecraft.src.Item.diamond.shiftedIndex;
			}
			if (blockID == net.minecraft.src.Block.oreLapis.blockID)
			{
				return net.minecraft.src.Item.dyePowder.shiftedIndex;
			}
			else
			{
				return blockID;
			}
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (blockID == net.minecraft.src.Block.oreLapis.blockID)
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
			return blockID != net.minecraft.src.Block.oreLapis.blockID ? 0 : 4;
		}
	}
}
