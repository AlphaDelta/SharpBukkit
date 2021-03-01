// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockJukeBox : net.minecraft.src.BlockContainer
	{
		protected internal BlockJukeBox(int i, int j)
			: base(i, j, net.minecraft.src.Material.wood)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            BlockContainer, Material, World, TileEntityRecordPlayer, 
		//            EntityItem, ItemStack, EntityPlayer, TileEntity
		public override int GetBlockTextureFromSide(int i)
		{
			return blockIndexInTexture + (i != 1 ? 0 : 1);
		}

		public override bool BlockActivated(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			if (world.GetBlockMetadata(i, j, k) == 0)
			{
				return false;
			}
			else
			{
				Func_28035_b_(world, i, j, k);
				return true;
			}
		}

		public virtual void EjectRecord(net.minecraft.src.World world, int i, int j, int 
			k, int l)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			else
			{
				net.minecraft.src.TileEntityRecordPlayer tileentityrecordplayer = (net.minecraft.src.TileEntityRecordPlayer
					)world.GetBlockTileEntity(i, j, k);
				tileentityrecordplayer.field_28009_a = l;
				tileentityrecordplayer.OnInventoryChanged();
				world.SetBlockMetadataWithNotify(i, j, k, 1);
				return;
			}
		}

		public virtual void Func_28035_b_(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			net.minecraft.src.TileEntityRecordPlayer tileentityrecordplayer = (net.minecraft.src.TileEntityRecordPlayer)world.GetBlockTileEntity(i, j, k);
			if (tileentityrecordplayer == null) return; // CRAFTBUKKIT

			int l = tileentityrecordplayer.field_28009_a;
			if (l == 0)
			{
				return;
			}
			else
			{
				world.SendSoundEffectToAllPlayersWithin64(1005, i, j, k, 0);
				world.PlayRecord(null, i, j, k);
				tileentityrecordplayer.field_28009_a = 0;
				tileentityrecordplayer.OnInventoryChanged();
				world.SetBlockMetadataWithNotify(i, j, k, 0);
				int i1 = l;
				float f = 0.7F;
				double d = (double)(world.rand.NextFloat() * f) + (double)(1.0F - f) * 0.5D;
				double d1 = (double)(world.rand.NextFloat() * f) + (double)(1.0F - f) * 0.20000000000000001D
					 + 0.59999999999999998D;
				double d2 = (double)(world.rand.NextFloat() * f) + (double)(1.0F - f) * 0.5D;
				net.minecraft.src.EntityItem entityitem = new net.minecraft.src.EntityItem(world, 
					(double)i + d, (double)j + d1, (double)k + d2, new net.minecraft.src.ItemStack(i1
					, 1, 0));
				entityitem.delayBeforeCanPickup = 10;
				world.AddEntity(entityitem);
				return;
			}
		}

		public override void OnBlockRemoval(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			Func_28035_b_(world, i, j, k);
			base.OnBlockRemoval(world, i, j, k);
		}

		public override void DropBlockAsItemWithChance(net.minecraft.src.World world, int
			 i, int j, int k, int l, float f)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			else
			{
				base.DropBlockAsItemWithChance(world, i, j, k, l, f);
				return;
			}
		}

		protected internal override net.minecraft.src.TileEntity GetBlockEntity()
		{
			return new net.minecraft.src.TileEntityRecordPlayer();
		}
	}
}
