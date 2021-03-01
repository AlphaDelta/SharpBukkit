// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockWorkbench : net.minecraft.src.Block
	{
		protected internal BlockWorkbench(int i)
			: base(i, net.minecraft.src.Material.wood)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, World, EntityPlayer
			blockIndexInTexture = 59;
		}

		public override int GetBlockTextureFromSide(int i)
		{
			if (i == 1)
			{
				return blockIndexInTexture - 16;
			}
			if (i == 0)
			{
				return net.minecraft.src.Block.WOOD.GetBlockTextureFromSide(0);
			}
			if (i == 2 || i == 4)
			{
				return blockIndexInTexture + 1;
			}
			else
			{
				return blockIndexInTexture;
			}
		}

		public override bool BlockActivated(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			if (world.singleplayerWorld)
			{
				return true;
			}
			else
			{
				entityplayer.DisplayWorkbenchGUI(i, j, k);
				return true;
			}
		}
	}
}
