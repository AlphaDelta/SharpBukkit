// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;

namespace net.minecraft.src
{
	public class ItemBucket : net.minecraft.src.Item
	{
		SharpRandom SharpRandom = new SharpRandom();
		public ItemBucket(int i, int j)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            Item, EntityPlayer, Vec3D, MathHelper, 
			//            World, MovingObjectPosition, EnumMovingObjectType, Material, 
			//            ItemStack, WorldProvider, Block, EntityCow
			maxStackSize = 1;
			isFull = j;
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
				(vec3d, vec3d1, isFull == 0);
			if (movingobjectposition == null)
			{
				return itemstack;
			}
			if (movingobjectposition.typeOfHit == net.minecraft.src.EnumMovingObjectType.TILE)
			{
				int i = movingobjectposition.blockX;
				int j = movingobjectposition.blockY;
				int k = movingobjectposition.blockZ;
				if (!world.CanMineBlock(entityplayer, i, j, k))
				{
					return itemstack;
				}
				if (isFull == 0)
				{
					if (world.GetBlockMaterial(i, j, k) == net.minecraft.src.Material.water && world.
						GetBlockMetadata(i, j, k) == 0)
					{
						world.SetBlockWithNotify(i, j, k, 0);
						return new net.minecraft.src.ItemStack(net.minecraft.src.Item.WATER_BUCKET);
					}
					if (world.GetBlockMaterial(i, j, k) == net.minecraft.src.Material.lava && world.GetBlockMetadata
						(i, j, k) == 0)
					{
						world.SetBlockWithNotify(i, j, k, 0);
						return new net.minecraft.src.ItemStack(net.minecraft.src.Item.LAVA_BUCKET);
					}
				}
				else
				{
					if (isFull < 0)
					{
						return new net.minecraft.src.ItemStack(net.minecraft.src.Item.BUCKET);
					}
					if (movingobjectposition.sideHit == 0)
					{
						j--;
					}
					if (movingobjectposition.sideHit == 1)
					{
						j++;
					}
					if (movingobjectposition.sideHit == 2)
					{
						k--;
					}
					if (movingobjectposition.sideHit == 3)
					{
						k++;
					}
					if (movingobjectposition.sideHit == 4)
					{
						i--;
					}
					if (movingobjectposition.sideHit == 5)
					{
						i++;
					}
					if (world.IsAirBlock(i, j, k) || !world.GetBlockMaterial(i, j, k).IsSolid())
					{
						if (world.worldProvider.isHellWorld && isFull == net.minecraft.src.Block.WATER
							.ID)
						{
							world.PlaySoundEffect(d + 0.5D, d1 + 0.5D, d2 + 0.5D, "random.fizz", 0.5F, 2.6F +
								 (world.rand.NextFloat() - world.rand.NextFloat()) * 0.8F);
							for (int l = 0; l < 8; l++)
							{
								world.SpawnParticle("largesmoke", (double)i + SharpRandom.NextDouble(), (double)j + SharpRandom.NextDouble(), (double)k + SharpRandom.NextDouble(), 0.0D, 0.0D, 0.0D);
							}
						}
						else
						{
							world.SetBlockAndMetadataWithNotify(i, j, k, isFull, 0);
						}
						return new net.minecraft.src.ItemStack(net.minecraft.src.Item.BUCKET);
					}
				}
			}
			else
			{
				if (isFull == 0 && (movingobjectposition.entityHit is net.minecraft.src.EntityCow
					))
				{
					return new net.minecraft.src.ItemStack(net.minecraft.src.Item.MILK_BUCKET);
				}
			}
			return itemstack;
		}

		private int isFull;
	}
}
