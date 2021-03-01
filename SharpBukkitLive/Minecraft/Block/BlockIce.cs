// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockIce : net.minecraft.src.BlockBreakable
	{
		public BlockIce(int i, int j)
			: base(i, j, net.minecraft.src.Material.ice, false)
		{
			// Referenced classes of package net.minecraft.src:
			//            BlockBreakable, Material, World, Block, 
			//            EnumSkyBlock, EntityPlayer
			slipperiness = 0.98F;
			SetTickOnLoad(true);
		}

		public override void HarvestBlock(net.minecraft.src.World world, net.minecraft.src.EntityPlayer
			 entityplayer, int i, int j, int k, int l)
		{
			base.HarvestBlock(world, entityplayer, i, j, k, l);
			net.minecraft.src.Material material = world.GetBlockMaterial(i, j - 1, k);
			if (material.GetIsSolid() || material.GetIsLiquid())
			{
				world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.WATER.blockID);
			}
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 0;
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (world.GetSavedLightValue(net.minecraft.src.EnumSkyBlock.Block, i, j, k) > 11 
				- net.minecraft.src.Block.lightOpacity[blockID])
			{
				DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
				world.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.STATIONARY_WATER.blockID);
			}
		}

		public override int GetMobilityFlag()
		{
			return 0;
		}
	}
}
