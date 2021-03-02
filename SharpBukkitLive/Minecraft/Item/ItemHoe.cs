// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemHoe : net.minecraft.src.Item
	{
		public ItemHoe(int i, net.minecraft.src.EnumToolMaterial enumtoolmaterial)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, EnumToolMaterial, World, Block, 
			//            BlockGrass, StepSound, ItemStack, EntityPlayer
			maxStackSize = 1;
			SetMaxDamage(enumtoolmaterial.GetMaxUses());
		}

		public override bool OnItemUse(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityPlayer
			 entityplayer, net.minecraft.src.World world, int i, int j, int k, int l)
		{
			int i1 = world.GetBlockId(i, j, k);
			int j1 = world.GetBlockId(i, j + 1, k);
			if (l != 0 && j1 == 0 && i1 == net.minecraft.src.Block.GRASS.ID || i1 == net.minecraft.src.Block
				.DIRT.ID)
			{
				net.minecraft.src.Block block = net.minecraft.src.Block.SOIL;
				world.PlaySoundEffect((float)i + 0.5F, (float)j + 0.5F, (float)k + 0.5F, block.stepSound
					.Func_737_c(), (block.stepSound.GetVolume() + 1.0F) / 2.0F, block.stepSound.GetPitch
					() * 0.8F);
				if (world.singleplayerWorld)
				{
					return true;
				}
				else
				{
					world.SetBlockWithNotify(i, j, k, block.ID);
					itemstack.DamageItem(1, entityplayer);
					return true;
				}
			}
			else
			{
				return false;
			}
		}
	}
}
