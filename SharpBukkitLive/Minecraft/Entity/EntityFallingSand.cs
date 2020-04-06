// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityFallingSand : net.minecraft.src.Entity
	{
		public EntityFallingSand(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            Entity, MathHelper, World, BlockSand, 
			//            NBTTagCompound
			fallTime = 0;
		}

		public EntityFallingSand(net.minecraft.src.World world, double d, double d1, double
			 d2, int i)
			: base(world)
		{
			fallTime = 0;
			blockID = i;
			preventEntitySpawning = true;
			SetSize(0.98F, 0.98F);
			yOffset = height / 2.0F;
			SetPosition(d, d1, d2);
			motionX = 0.0D;
			motionY = 0.0D;
			motionZ = 0.0D;
			prevPosX = d;
			prevPosY = d1;
			prevPosZ = d2;
		}

		protected internal override bool Func_25017_l()
		{
			return false;
		}

		protected internal override void EntityInit()
		{
		}

		public override bool CanBeCollidedWith()
		{
			return !isDead;
		}

		public override void OnUpdate()
		{
			if (blockID == 0)
			{
				SetEntityDead();
				return;
			}
			prevPosX = posX;
			prevPosY = posY;
			prevPosZ = posZ;
			fallTime++;
			motionY -= 0.039999999105930328D;
			MoveEntity(motionX, motionY, motionZ);
			motionX *= 0.98000001907348633D;
			motionY *= 0.98000001907348633D;
			motionZ *= 0.98000001907348633D;
			int i = net.minecraft.src.MathHelper.Floor_double(posX);
			int j = net.minecraft.src.MathHelper.Floor_double(posY);
			int k = net.minecraft.src.MathHelper.Floor_double(posZ);
			if (worldObj.GetBlockId(i, j, k) == blockID)
			{
				worldObj.SetBlockWithNotify(i, j, k, 0);
			}
			if (onGround)
			{
				motionX *= 0.69999998807907104D;
				motionZ *= 0.69999998807907104D;
				motionY *= -0.5D;
				SetEntityDead();
				if ((!worldObj.CanBlockBePlacedAt(blockID, i, j, k, true, 1) || net.minecraft.src.BlockSand
					.CanFallBelow(worldObj, i, j - 1, k) || !worldObj.SetBlockWithNotify(i, j, k, blockID
					)) && !worldObj.singleplayerWorld)
				{
					DropItem(blockID, 1);
				}
			}
			else
			{
				if (fallTime > 100 && !worldObj.singleplayerWorld)
				{
					DropItem(blockID, 1);
					SetEntityDead();
				}
			}
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			nbttagcompound.SetByte("Tile", unchecked((byte)blockID));
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			blockID = nbttagcompound.GetByte("Tile") & unchecked((int)(0xff));
		}

		public int blockID;

		public int fallTime;
	}
}
