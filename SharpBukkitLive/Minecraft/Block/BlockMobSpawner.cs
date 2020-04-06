// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockMobSpawner : net.minecraft.src.BlockContainer
	{
		protected internal BlockMobSpawner(int i, int j)
			: base(i, j, net.minecraft.src.Material.rock)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            BlockContainer, Material, TileEntityMobSpawner, TileEntity
		protected internal override net.minecraft.src.TileEntity GetBlockEntity()
		{
			return new net.minecraft.src.TileEntityMobSpawner();
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 0;
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 0;
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}
	}
}
