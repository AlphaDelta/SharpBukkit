// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockLockedChest : net.minecraft.src.Block
	{
		protected internal BlockLockedChest(int i)
			: base(i, net.minecraft.src.Material.wood)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, World
			blockIndexInTexture = 26;
		}

		public override int GetBlockTextureFromSide(int i)
		{
			if (i == 1)
			{
				return blockIndexInTexture - 1;
			}
			if (i == 0)
			{
				return blockIndexInTexture - 1;
			}
			if (i == 3)
			{
				return blockIndexInTexture + 1;
			}
			else
			{
				return blockIndexInTexture;
			}
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			return true;
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			world.SetBlockWithNotify(i, j, k, 0);
		}
	}
}
