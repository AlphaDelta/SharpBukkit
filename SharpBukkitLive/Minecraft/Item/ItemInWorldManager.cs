// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemInWorldManager
	{
		public ItemInWorldManager(net.minecraft.src.WorldServer worldserver)
		{
			// Referenced classes of package net.minecraft.src:
			//            WorldServer, Block, EntityPlayer, ItemStack, 
			//            EntityPlayerMP, Packet53BlockChange, NetServerHandler, InventoryPlayer, 
			//            World
			field_672_d = 0.0F;
			thisWorld = worldserver;
		}

		public virtual void Func_328_a()
		{
			field_22051_j++;
			if (field_22050_k)
			{
				int i = field_22051_j - field_22046_o;
				int j = thisWorld.GetBlockId(field_22049_l, field_22048_m, field_22047_n);
				if (j != 0)
				{
					net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[j];
					float f = block.BlockStrength(thisPlayer) * (float)(i + 1);
					if (f >= 1.0F)
					{
						field_22050_k = false;
						Func_325_c(field_22049_l, field_22048_m, field_22047_n);
					}
				}
				else
				{
					field_22050_k = false;
				}
			}
		}

		public virtual void Func_324_a(int i, int j, int k, int l)
		{
			thisWorld.Func_28096_a(null, i, j, k, l);
			field_22055_d = field_22051_j;
			int i1 = thisWorld.GetBlockId(i, j, k);
			if (i1 > 0)
			{
				net.minecraft.src.Block.blocksList[i1].OnBlockClicked(thisWorld, i, j, k, thisPlayer
					);
			}
			if (i1 > 0 && net.minecraft.src.Block.blocksList[i1].BlockStrength(thisPlayer) >=
				 1.0F)
			{
				Func_325_c(i, j, k);
			}
			else
			{
				field_22054_g = i;
				field_22053_h = j;
				field_22052_i = k;
			}
		}

		public virtual void Func_22045_b(int i, int j, int k)
		{
			if (i == field_22054_g && j == field_22053_h && k == field_22052_i)
			{
				int l = field_22051_j - field_22055_d;
				int i1 = thisWorld.GetBlockId(i, j, k);
				if (i1 != 0)
				{
					net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[i1];
					float f = block.BlockStrength(thisPlayer) * (float)(l + 1);
					if (f >= 0.7F)
					{
						Func_325_c(i, j, k);
					}
					else
					{
						if (!field_22050_k)
						{
							field_22050_k = true;
							field_22049_l = i;
							field_22048_m = j;
							field_22047_n = k;
							field_22046_o = field_22055_d;
						}
					}
				}
			}
			field_672_d = 0.0F;
		}

		public virtual bool RemoveBlock(int i, int j, int k)
		{
			net.minecraft.src.Block block = net.minecraft.src.Block.blocksList[thisWorld.GetBlockId
				(i, j, k)];
			int l = thisWorld.GetBlockMetadata(i, j, k);
			bool flag = thisWorld.SetBlockWithNotify(i, j, k, 0);
			if (block != null && flag)
			{
				block.OnBlockDestroyedByPlayer(thisWorld, i, j, k, l);
			}
			return flag;
		}

		public virtual bool Func_325_c(int i, int j, int k)
		{
			int l = thisWorld.GetBlockId(i, j, k);
			int i1 = thisWorld.GetBlockMetadata(i, j, k);
			thisWorld.SendSoundEffectToAllPlayersWithin64(thisPlayer, 2001, i, j, k, l + thisWorld.GetBlockMetadata(
				i, j, k) * 256);
			bool flag = RemoveBlock(i, j, k);
			net.minecraft.src.ItemStack itemstack = thisPlayer.GetCurrentEquippedItem();
			if (itemstack != null)
			{
				itemstack.Func_25124_a(l, i, j, k, thisPlayer);
				if (itemstack.stackSize == 0)
				{
					itemstack.Func_577_a(thisPlayer);
					thisPlayer.DestroyCurrentEquippedItem();
				}
			}
			if (flag && thisPlayer.CanHarvestBlock(net.minecraft.src.Block.blocksList[l]))
			{
				net.minecraft.src.Block.blocksList[l].HarvestBlock(thisWorld, thisPlayer, i, j, k
					, i1);
				((net.minecraft.src.EntityPlayerMP)thisPlayer).netServerHandler.SendPacket(
					new net.minecraft.src.Packet53BlockChange(i, j, k, thisWorld));
			}
			return flag;
		}

		public virtual bool Func_6154_a(net.minecraft.src.EntityPlayer entityplayer, net.minecraft.src.World
			 world, net.minecraft.src.ItemStack itemstack)
		{
			int i = itemstack.stackSize;
			net.minecraft.src.ItemStack itemstack1 = itemstack.UseItemRightClick(world, entityplayer
				);
			if (itemstack1 != itemstack || itemstack1 != null && itemstack1.stackSize != i)
			{
				entityplayer.inventory.mainInventory[entityplayer.inventory.currentItem] = itemstack1;
				if (itemstack1.stackSize == 0)
				{
					entityplayer.inventory.mainInventory[entityplayer.inventory.currentItem] = null;
				}
				return true;
			}
			else
			{
				return false;
			}
		}

		public virtual bool ActiveBlockOrUseItem(net.minecraft.src.EntityPlayer entityplayer
			, net.minecraft.src.World world, net.minecraft.src.ItemStack itemstack, int i, int
			 j, int k, int l)
		{
			int i1 = world.GetBlockId(i, j, k);
			if (i1 > 0 && net.minecraft.src.Block.blocksList[i1].BlockActivated(world, i, j, 
				k, entityplayer))
			{
				return true;
			}
			if (itemstack == null)
			{
				return false;
			}
			else
			{
				return itemstack.UseItem(entityplayer, world, i, j, k, l);
			}
		}

		private net.minecraft.src.WorldServer thisWorld;

		public net.minecraft.src.EntityPlayer thisPlayer;

		private float field_672_d;

		private int field_22055_d;

		private int field_22054_g;

		private int field_22053_h;

		private int field_22052_i;

		private int field_22051_j;

		private bool field_22050_k;

		private int field_22049_l;

		private int field_22048_m;

		private int field_22047_n;

		private int field_22046_o;
	}
}
