// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityFlying : net.minecraft.src.EntityLiving
	{
		public EntityFlying(net.minecraft.src.World world)
			: base(world)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            EntityLiving, MathHelper, AxisAlignedBB, World, 
		//            Block
		protected internal override void Fall(float f)
		{
		}

		public override void MoveEntityWithHeading(float f, float f1)
		{
			if (IsInWater())
			{
				MoveFlying(f, f1, 0.02F);
				MoveEntity(motionX, motionY, motionZ);
				motionX *= 0.80000001192092896D;
				motionY *= 0.80000001192092896D;
				motionZ *= 0.80000001192092896D;
			}
			else
			{
				if (HandleLavaMovement())
				{
					MoveFlying(f, f1, 0.02F);
					MoveEntity(motionX, motionY, motionZ);
					motionX *= 0.5D;
					motionY *= 0.5D;
					motionZ *= 0.5D;
				}
				else
				{
					float f2 = 0.91F;
					if (onGround)
					{
						f2 = 0.5460001F;
						int i = worldObj.GetBlockId(net.minecraft.src.MathHelper.Floor_double(posX), net.minecraft.src.MathHelper
							.Floor_double(boundingBox.minY) - 1, net.minecraft.src.MathHelper.Floor_double(posZ
							));
						if (i > 0)
						{
							f2 = net.minecraft.src.Block.blocksList[i].slipperiness * 0.91F;
						}
					}
					float f3 = 0.1627714F / (f2 * f2 * f2);
					MoveFlying(f, f1, onGround ? 0.1F * f3 : 0.02F);
					f2 = 0.91F;
					if (onGround)
					{
						f2 = 0.5460001F;
						int j = worldObj.GetBlockId(net.minecraft.src.MathHelper.Floor_double(posX), net.minecraft.src.MathHelper
							.Floor_double(boundingBox.minY) - 1, net.minecraft.src.MathHelper.Floor_double(posZ
							));
						if (j > 0)
						{
							f2 = net.minecraft.src.Block.blocksList[j].slipperiness * 0.91F;
						}
					}
					MoveEntity(motionX, motionY, motionZ);
					motionX *= f2;
					motionY *= f2;
					motionZ *= f2;
				}
			}
			field_9142_bc = field_9141_bd;
			double d = posX - prevPosX;
			double d1 = posZ - prevPosZ;
			float f4 = net.minecraft.src.MathHelper.Sqrt_double(d * d + d1 * d1) * 4F;
			if (f4 > 1.0F)
			{
				f4 = 1.0F;
			}
			field_9141_bd += (f4 - field_9141_bd) * 0.4F;
			field_386_ba += field_9141_bd;
		}

		public override bool IsOnLadder()
		{
			return false;
		}
	}
}
