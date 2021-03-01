// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityLightningBolt : net.minecraft.src.EntityWeatherEffect
	{
		public EntityLightningBolt(net.minecraft.src.World world, double d, double d1, double
			 d2)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityWeatherEffect, World, MathHelper, Block, 
			//            BlockFire, AxisAlignedBB, Entity, NBTTagCompound
			field_27019_a = 0L;
			SetLocationAndAngles(d, d1, d2, 0.0F, 0.0F);
			field_27018_b = 2;
			field_27019_a = rand.NextLong();
			field_27020_c = rand.Next(3) + 1;
			if (world.difficultySetting >= 2 && world.DoChunksNearChunkExist(net.minecraft.src.MathHelper
				.Floor_double(d), net.minecraft.src.MathHelper.Floor_double(d1), net.minecraft.src.MathHelper
				.Floor_double(d2), 10))
			{
				int i = net.minecraft.src.MathHelper.Floor_double(d);
				int k = net.minecraft.src.MathHelper.Floor_double(d1);
				int i1 = net.minecraft.src.MathHelper.Floor_double(d2);
				if (world.GetBlockId(i, k, i1) == 0 && net.minecraft.src.Block.FIRE.CanPlaceBlockAt
					(world, i, k, i1))
				{
					world.SetBlockWithNotify(i, k, i1, net.minecraft.src.Block.FIRE.blockID);
				}
				for (int j = 0; j < 4; j++)
				{
					int l = (net.minecraft.src.MathHelper.Floor_double(d) + rand.Next(3)) - 1;
					int j1 = (net.minecraft.src.MathHelper.Floor_double(d1) + rand.Next(3)) - 1;
					int k1 = (net.minecraft.src.MathHelper.Floor_double(d2) + rand.Next(3)) - 1;
					if (world.GetBlockId(l, j1, k1) == 0 && net.minecraft.src.Block.FIRE.CanPlaceBlockAt
						(world, l, j1, k1))
					{
						world.SetBlockWithNotify(l, j1, k1, net.minecraft.src.Block.FIRE.blockID);
					}
				}
			}
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			if (field_27018_b == 2)
			{
				worldObj.PlaySoundEffect(posX, posY, posZ, "ambient.weather.thunder", 10000F, 0.8F
					 + rand.NextFloat() * 0.2F);
				worldObj.PlaySoundEffect(posX, posY, posZ, "random.explode", 2.0F, 0.5F + rand.NextFloat
					() * 0.2F);
			}
			field_27018_b--;
			if (field_27018_b < 0)
			{
				if (field_27020_c == 0)
				{
					SetEntityDead();
				}
				else
				{
					if (field_27018_b < -rand.Next(10))
					{
						field_27020_c--;
						field_27018_b = 1;
						field_27019_a = rand.NextLong();
						if (worldObj.DoChunksNearChunkExist(net.minecraft.src.MathHelper.Floor_double(posX
							), net.minecraft.src.MathHelper.Floor_double(posY), net.minecraft.src.MathHelper
							.Floor_double(posZ), 10))
						{
							int i = net.minecraft.src.MathHelper.Floor_double(posX);
							int j = net.minecraft.src.MathHelper.Floor_double(posY);
							int k = net.minecraft.src.MathHelper.Floor_double(posZ);
							if (worldObj.GetBlockId(i, j, k) == 0 && net.minecraft.src.Block.FIRE.CanPlaceBlockAt
								(worldObj, i, j, k))
							{
								worldObj.SetBlockWithNotify(i, j, k, net.minecraft.src.Block.FIRE.blockID);
							}
						}
					}
				}
			}
			if (field_27018_b >= 0)
			{
				double d = 3D;
				System.Collections.Generic.List<Entity> list = worldObj.GetEntitiesWithinAABBExcludingEntity(this
					, net.minecraft.src.AxisAlignedBB.GetBoundingBoxFromPool(posX - d, posY - d, posZ
					 - d, posX + d, posY + 6D + d, posZ + d));
				for (int l = 0; l < list.Count; l++)
				{
					net.minecraft.src.Entity entity = (net.minecraft.src.Entity)list[l];
					entity.OnStruckByLightning(this);
				}
				worldObj.field_27080_i = 2;
			}
		}

		protected internal override void EntityInit()
		{
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
		}

		private int field_27018_b;

		public long field_27019_a;

		private int field_27020_c;
	}
}
