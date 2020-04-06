// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockNote : net.minecraft.src.BlockContainer
	{
		public BlockNote(int i)
			: base(i, 74, net.minecraft.src.Material.wood)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            BlockContainer, Material, Block, World, 
		//            TileEntityNote, EntityPlayer, TileEntity
		public override int GetBlockTextureFromSide(int i)
		{
			return blockIndexInTexture;
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			if (l > 0 && net.minecraft.src.Block.blocksList[l].CanProvidePower())
			{
				bool flag = world.IsBlockGettingPowered(i, j, k);
				net.minecraft.src.TileEntityNote tileentitynote = (net.minecraft.src.TileEntityNote
					)world.GetBlockTileEntity(i, j, k);
				if (tileentitynote.previousRedstoneState != flag)
				{
					if (flag)
					{
						tileentitynote.TriggerNote(world, i, j, k);
					}
					tileentitynote.previousRedstoneState = flag;
				}
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
				net.minecraft.src.TileEntityNote tileentitynote = (net.minecraft.src.TileEntityNote
					)world.GetBlockTileEntity(i, j, k);
				tileentitynote.ChangePitch();
				tileentitynote.TriggerNote(world, i, j, k);
				return true;
			}
		}

		public override void OnBlockClicked(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			else
			{
				net.minecraft.src.TileEntityNote tileentitynote = (net.minecraft.src.TileEntityNote
					)world.GetBlockTileEntity(i, j, k);
				tileentitynote.TriggerNote(world, i, j, k);
				return;
			}
		}

		protected internal override net.minecraft.src.TileEntity GetBlockEntity()
		{
			return new net.minecraft.src.TileEntityNote();
		}

		public override void PlayBlock(net.minecraft.src.World world, int i, int j, int k
			, int l, int i1)
		{
			float f = (float)System.Math.Pow(2D, (double)(i1 - 12) / 12D);
			string s = "harp";
			if (l == 1)
			{
				s = "bd";
			}
			if (l == 2)
			{
				s = "snare";
			}
			if (l == 3)
			{
				s = "hat";
			}
			if (l == 4)
			{
				s = "bassattack";
			}
			world.PlaySoundEffect((double)i + 0.5D, (double)j + 0.5D, (double)k + 0.5D, (new 
				java.lang.StringBuilder()).Append("note.").Append(s).ToString(), 3F, f);
			world.SpawnParticle("note", (double)i + 0.5D, (double)j + 1.2D, (double)k + 0.5D, 
				(double)i1 / 24D, 0.0D, 0.0D);
		}
	}
}
