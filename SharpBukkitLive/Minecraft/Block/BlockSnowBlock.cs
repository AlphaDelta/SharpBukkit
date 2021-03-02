// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockSnowBlock : net.minecraft.src.Block
	{
		protected internal BlockSnowBlock(int i, int j)
			: base(i, j, net.minecraft.src.Material.builtSnow)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, Item, EnumSkyBlock, 
			//            World
			SetTickOnLoad(true);
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Item.SNOW_BALL.ID;
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 4;
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (world.GetSavedLightValue(net.minecraft.src.EnumSkyBlock.Block, i, j, k) > 11)
			{
				DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
				world.SetBlockWithNotify(i, j, k, 0);
			}
		}
	}
}
