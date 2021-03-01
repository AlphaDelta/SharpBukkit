// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class TileEntityMobSpawner : net.minecraft.src.TileEntity
	{
		public TileEntityMobSpawner()
		{
			// Referenced classes of package net.minecraft.src:
			//            TileEntity, World, EntityList, EntityLiving, 
			//            AxisAlignedBB, NBTTagCompound
			delay = -1;
			yaw2 = 0.0D;
			mobID = "Pig";
			delay = 20;
		}

		public virtual void SetMobID(string s)
		{
			mobID = s;
		}

		public virtual bool AnyPlayerInRange()
		{
			return worldObj.GetClosestPlayer((double)xCoord + 0.5D, (double)yCoord + 0.5D, (double
				)zCoord + 0.5D, 16D) != null;
		}

		public override void UpdateEntity()
		{
			yaw2 = yaw;
			if (!AnyPlayerInRange())
			{
				return;
			}
			double d = (float)xCoord + worldObj.rand.NextFloat();
			double d2 = (float)yCoord + worldObj.rand.NextFloat();
			double d4 = (float)zCoord + worldObj.rand.NextFloat();
			worldObj.SpawnParticle("smoke", d, d2, d4, 0.0D, 0.0D, 0.0D);
			worldObj.SpawnParticle("flame", d, d2, d4, 0.0D, 0.0D, 0.0D);
			for (yaw += 1000F / ((float)delay + 200F); yaw > 360D; )
			{
				yaw -= 360D;
				yaw2 -= 360D;
			}
			if (!worldObj.singleplayerWorld)
			{
				if (delay == -1)
				{
					UpdateDelay();
				}
				if (delay > 0)
				{
					delay--;
					return;
				}
				byte byte0 = 4;
				for (int i = 0; i < byte0; i++)
				{
					net.minecraft.src.EntityLiving entityliving = (net.minecraft.src.EntityLiving)net.minecraft.src.EntityList
						.CreateEntityInWorld(mobID, worldObj);
					if (entityliving == null)
					{
						return;
					}
					int j = worldObj.GetEntitiesWithinAABB(entityliving.GetType(), net.minecraft.src.AxisAlignedBB.GetBoundingBoxFromPool(xCoord, yCoord, zCoord
						, xCoord + 1, yCoord + 1, zCoord + 1).Expand(8D, 4D, 8D)).Count;
					if (j >= 6)
					{
						UpdateDelay();
						return;
					}
					if (entityliving == null)
					{
						continue;
					}
					double d6 = (double)xCoord + (worldObj.rand.NextDouble() - worldObj.rand.NextDouble
						()) * 4D;
					double d7 = (yCoord + worldObj.rand.Next(3)) - 1;
					double d8 = (double)zCoord + (worldObj.rand.NextDouble() - worldObj.rand.NextDouble
						()) * 4D;
					entityliving.SetLocationAndAngles(d6, d7, d8, worldObj.rand.NextFloat() * 360F, 0.0F
						);
					if (!entityliving.GetCanSpawnHere())
					{
						continue;
					}
					worldObj.AddEntity(entityliving);
					for (int k = 0; k < 20; k++)
					{
						double d1 = (double)xCoord + 0.5D + ((double)worldObj.rand.NextFloat() - 0.5D) * 
							2D;
						double d3 = (double)yCoord + 0.5D + ((double)worldObj.rand.NextFloat() - 0.5D) * 
							2D;
						double d5 = (double)zCoord + 0.5D + ((double)worldObj.rand.NextFloat() - 0.5D) * 
							2D;
						worldObj.SpawnParticle("smoke", d1, d3, d5, 0.0D, 0.0D, 0.0D);
						worldObj.SpawnParticle("flame", d1, d3, d5, 0.0D, 0.0D, 0.0D);
					}
					entityliving.SpawnExplosionParticle();
					UpdateDelay();
				}
			}
			base.UpdateEntity();
		}

		private void UpdateDelay()
		{
			delay = 200 + worldObj.rand.Next(600);
		}

		public override void ReadFromNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.ReadFromNBT(nbttagcompound);
			mobID = nbttagcompound.GetString("EntityId");
			delay = nbttagcompound.GetShort("Delay");
		}

		public override void WriteToNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.WriteToNBT(nbttagcompound);
			nbttagcompound.SetString("EntityId", mobID);
			nbttagcompound.SetShort("Delay", (short)delay);
		}

		public int delay;

		private string mobID;

		public double yaw;

		public double yaw2;
	}
}
