// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntitySquid : net.minecraft.src.EntityWaterMob
	{
		public EntitySquid(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityWaterMob, ItemStack, Item, AxisAlignedBB, 
			//            Material, World, MathHelper, NBTTagCompound, 
			//            EntityPlayer
			field_21063_a = 0.0F;
			field_21062_b = 0.0F;
			field_21061_c = 0.0F;
			field_21059_f = 0.0F;
			field_21060_ak = 0.0F;
			field_21058_al = 0.0F;
			field_21057_am = 0.0F;
			field_21056_an = 0.0F;
			field_21055_ao = 0.0F;
			field_21054_ap = 0.0F;
			field_21053_aq = 0.0F;
			field_21052_ar = 0.0F;
			field_21051_as = 0.0F;
			field_21050_at = 0.0F;
			texture = "/mob/squid.png";
			SetSize(0.95F, 0.95F);
			field_21054_ap = (1.0F / (rand.NextFloat() + 1.0F)) * 0.2F;
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.WriteEntityToNBT(nbttagcompound);
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.ReadEntityFromNBT(nbttagcompound);
		}

		protected internal override string GetLivingSound()
		{
			return null;
		}

		protected internal override string GetHurtSound()
		{
			return null;
		}

		protected internal override string GetDeathSound()
		{
			return null;
		}

		protected internal override float GetSoundVolume()
		{
			return 0.4F;
		}

		protected internal override int GetDropItemId()
		{
			return 0;
		}

		protected internal override void DropFewItems()
		{
			int i = rand.Next(3) + 1;
			for (int j = 0; j < i; j++)
			{
				EntityDropItem(new net.minecraft.src.ItemStack(net.minecraft.src.Item.dyePowder, 
					1, 0), 0.0F);
			}
		}

		public override bool Interact(net.minecraft.src.EntityPlayer entityplayer)
		{
			return false;
		}

		public override bool IsInWater()
		{
			return worldObj.HandleMaterialAcceleration(boundingBox.Expand(0.0D, -0.60000002384185791D
				, 0.0D), net.minecraft.src.Material.water, this);
		}

		public override void OnLivingUpdate()
		{
			base.OnLivingUpdate();
			field_21062_b = field_21063_a;
			field_21059_f = field_21061_c;
			field_21058_al = field_21060_ak;
			field_21056_an = field_21057_am;
			field_21060_ak += field_21054_ap;
			if (field_21060_ak > 6.283185F)
			{
				field_21060_ak -= 6.283185F;
				if (rand.Next(10) == 0)
				{
					field_21054_ap = (1.0F / (rand.NextFloat() + 1.0F)) * 0.2F;
				}
			}
			if (IsInWater())
			{
				if (field_21060_ak < 3.141593F)
				{
					float f = field_21060_ak / 3.141593F;
					field_21057_am = net.minecraft.src.MathHelper.Sin(f * f * 3.141593F) * 3.141593F 
						* 0.25F;
					if ((double)f > 0.75D)
					{
						field_21055_ao = 1.0F;
						field_21053_aq = 1.0F;
					}
					else
					{
						field_21053_aq = field_21053_aq * 0.8F;
					}
				}
				else
				{
					field_21057_am = 0.0F;
					field_21055_ao = field_21055_ao * 0.9F;
					field_21053_aq = field_21053_aq * 0.99F;
				}
				if (!isMultiplayerEntity)
				{
					motionX = field_21052_ar * field_21055_ao;
					motionY = field_21051_as * field_21055_ao;
					motionZ = field_21050_at * field_21055_ao;
				}
				float f1 = net.minecraft.src.MathHelper.Sqrt_double(motionX * motionX + motionZ *
					 motionZ);
				renderYawOffset += ((-(float)System.Math.Atan2(motionX, motionZ) * 180F) / 3.141593F
					 - renderYawOffset) * 0.1F;
				rotationYaw = renderYawOffset;
				field_21061_c = field_21061_c + 3.141593F * field_21053_aq * 1.5F;
				field_21063_a += ((-(float)System.Math.Atan2(f1, motionY) * 180F) / 3.141593F - field_21063_a
					) * 0.1F;
			}
			else
			{
				field_21057_am = net.minecraft.src.MathHelper.Abs(net.minecraft.src.MathHelper.Sin
					(field_21060_ak)) * 3.141593F * 0.25F;
				if (!isMultiplayerEntity)
				{
					motionX = 0.0D;
					motionY -= 0.080000000000000002D;
					motionY *= 0.98000001907348633D;
					motionZ = 0.0D;
				}
				field_21063_a += (float)((double)(-90F - field_21063_a) * 0.02D);
			}
		}

		public override void MoveEntityWithHeading(float f, float f1)
		{
			MoveEntity(motionX, motionY, motionZ);
		}

		protected internal override void UpdatePlayerActionState()
		{
			if (rand.Next(50) == 0 || !inWater || field_21052_ar == 0.0F && field_21051_as
				 == 0.0F && field_21050_at == 0.0F)
			{
				float f = rand.NextFloat() * 3.141593F * 2.0F;
				field_21052_ar = net.minecraft.src.MathHelper.Cos(f) * 0.2F;
				field_21051_as = -0.1F + rand.NextFloat() * 0.2F;
				field_21050_at = net.minecraft.src.MathHelper.Sin(f) * 0.2F;
			}
			Func_27013_Q();
		}

		public float field_21063_a;

		public float field_21062_b;

		public float field_21061_c;

		public float field_21059_f;

		public float field_21060_ak;

		public float field_21058_al;

		public float field_21057_am;

		public float field_21056_an;

		private float field_21055_ao;

		private float field_21054_ap;

		private float field_21053_aq;

		private float field_21052_ar;

		private float field_21051_as;

		private float field_21050_at;
	}
}
