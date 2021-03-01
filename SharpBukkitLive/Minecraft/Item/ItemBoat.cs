// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemBoat : net.minecraft.src.Item
	{
		public ItemBoat(int i)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, EntityPlayer, Vec3D, MathHelper, 
			//            World, MovingObjectPosition, EnumMovingObjectType, Block, 
			//            EntityBoat, ItemStack
			maxStackSize = 1;
		}

		public override net.minecraft.src.ItemStack OnItemRightClick(net.minecraft.src.ItemStack
			 itemstack, net.minecraft.src.World world, net.minecraft.src.EntityPlayer entityplayer
			)
		{
			float f = 1.0F;
			float f1 = entityplayer.prevRotationPitch + (entityplayer.rotationPitch - entityplayer
				.prevRotationPitch) * f;
			float f2 = entityplayer.prevRotationYaw + (entityplayer.rotationYaw - entityplayer
				.prevRotationYaw) * f;
			double d = entityplayer.prevPosX + (entityplayer.posX - entityplayer.prevPosX) * 
				(double)f;
			double d1 = (entityplayer.prevPosY + (entityplayer.posY - entityplayer.prevPosY) 
				* (double)f + 1.6200000000000001D) - (double)entityplayer.yOffset;
			double d2 = entityplayer.prevPosZ + (entityplayer.posZ - entityplayer.prevPosZ) *
				 (double)f;
			net.minecraft.src.Vec3D vec3d = net.minecraft.src.Vec3D.CreateVector(d, d1, d2);
			float f3 = net.minecraft.src.MathHelper.Cos(-f2 * 0.01745329F - 3.141593F);
			float f4 = net.minecraft.src.MathHelper.Sin(-f2 * 0.01745329F - 3.141593F);
			float f5 = -net.minecraft.src.MathHelper.Cos(-f1 * 0.01745329F);
			float f6 = net.minecraft.src.MathHelper.Sin(-f1 * 0.01745329F);
			float f7 = f4 * f5;
			float f8 = f6;
			float f9 = f3 * f5;
			double d3 = 5D;
			net.minecraft.src.Vec3D vec3d1 = vec3d.AddVector((double)f7 * d3, (double)f8 * d3
				, (double)f9 * d3);
			net.minecraft.src.MovingObjectPosition movingobjectposition = world.RayTraceBlocks_do
				(vec3d, vec3d1, true);
			if (movingobjectposition == null)
			{
				return itemstack;
			}
			if (movingobjectposition.typeOfHit == net.minecraft.src.EnumMovingObjectType.TILE)
			{
				int i = movingobjectposition.blockX;
				int j = movingobjectposition.blockY;
				int k = movingobjectposition.blockZ;
				if (!world.singleplayerWorld)
				{
					if (world.GetBlockId(i, j, k) == net.minecraft.src.Block.snow.blockID)
					{
						j--;
					}
					world.AddEntity(new net.minecraft.src.EntityBoat(world, (float)i + 0.5F, 
						(float)j + 1.0F, (float)k + 0.5F));
				}
				itemstack.stackSize--;
			}
			return itemstack;
		}
	}
}
