// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockTNT : net.minecraft.src.Block
	{
		public BlockTNT(int i, int j)
			: base(i, j, net.minecraft.src.Material.tnt)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Block, Material, World, EntityTNTPrimed, 
		//            ItemStack, EntityPlayer, Item
		public override int GetBlockTextureFromSide(int i)
		{
			if (i == 0)
			{
				return blockIndexInTexture + 2;
			}
			if (i == 1)
			{
				return blockIndexInTexture + 1;
			}
			else
			{
				return blockIndexInTexture;
			}
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			base.OnBlockAdded(world, i, j, k);
			if (world.IsBlockIndirectlyGettingPowered(i, j, k))
			{
				OnBlockDestroyedByPlayer(world, i, j, k, 1);
				world.SetBlockWithNotify(i, j, k, 0);
			}
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			if (l > 0 && net.minecraft.src.Block.blocksList[l].CanProvidePower() && world.IsBlockIndirectlyGettingPowered
				(i, j, k))
			{
				OnBlockDestroyedByPlayer(world, i, j, k, 1);
				world.SetBlockWithNotify(i, j, k, 0);
			}
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return 0;
		}

		public override void OnBlockDestroyedByExplosion(net.minecraft.src.World world, int
			 i, int j, int k)
		{
			net.minecraft.src.EntityTNTPrimed entitytntprimed = new net.minecraft.src.EntityTNTPrimed
				(world, (float)i + 0.5F, (float)j + 0.5F, (float)k + 0.5F);
			entitytntprimed.fuse = world.rand.Next(entitytntprimed.fuse / 4) + entitytntprimed
				.fuse / 8;
			world.AddEntity(entitytntprimed);
		}

		public override void OnBlockDestroyedByPlayer(net.minecraft.src.World world, int 
			i, int j, int k, int l)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			if ((l & 1) == 0)
			{
				DropBlockAsItem_do(world, i, j, k, new net.minecraft.src.ItemStack(net.minecraft.src.Block
					.TNT.blockID, 1, 0));
			}
			else
			{
				net.minecraft.src.EntityTNTPrimed entitytntprimed = new net.minecraft.src.EntityTNTPrimed
					(world, (float)i + 0.5F, (float)j + 0.5F, (float)k + 0.5F);
				world.AddEntity(entitytntprimed);
				world.PlaySoundAtEntity(entitytntprimed, "random.fuse", 1.0F, 1.0F);
			}
		}

		public override void OnBlockClicked(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			if (entityplayer.GetCurrentEquippedItem() != null && entityplayer.GetCurrentEquippedItem
				().itemID == net.minecraft.src.Item.flintAndSteel.shiftedIndex)
			{
				world.SetBlockMetadata(i, j, k, 1);
			}
			base.OnBlockClicked(world, i, j, k, entityplayer);
		}

		public override bool BlockActivated(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			return base.BlockActivated(world, i, j, k, entityplayer);
		}
	}
}
