// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityChicken : net.minecraft.src.EntityAnimal
	{
		public EntityChicken(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityAnimal, World, Item, NBTTagCompound
			field_392_a = false;
			field_391_b = 0.0F;
			field_395_ad = 0.0F;
			field_390_ai = 1.0F;
			texture = "/mob/chicken.png";
			SetSize(0.3F, 0.4F);
			health = 4;
			timeUntilNextEgg = rand.Next(6000) + 6000;
		}

		public override void OnLivingUpdate()
		{
			base.OnLivingUpdate();
			field_393_af = field_391_b;
			field_394_ae = field_395_ad;
			field_395_ad += (float)((double)(onGround ? -1 : 4) * 0.29999999999999999D);
			if (field_395_ad < 0.0F)
			{
				field_395_ad = 0.0F;
			}
			if (field_395_ad > 1.0F)
			{
				field_395_ad = 1.0F;
			}
			if (!onGround && field_390_ai < 1.0F)
			{
				field_390_ai = 1.0F;
			}
			field_390_ai *= .9f;//0.90000000000000002D;
			if (!onGround && motionY < 0.0D)
			{
				motionY *= .6f;//0.59999999999999998D;
			}
			field_391_b += field_390_ai * 2.0F;
			if (!worldObj.singleplayerWorld && --timeUntilNextEgg <= 0)
			{
				worldObj.PlaySoundAtEntity(this, "mob.chickenplop", 1.0F, (rand.NextFloat() - rand
					.NextFloat()) * 0.2F + 1.0F);
				DropItem(net.minecraft.src.Item.egg.shiftedIndex, 1);
				timeUntilNextEgg = rand.Next(6000) + 6000;
			}
		}

		protected internal override void Fall(float f)
		{
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
			return "mob.chicken";
		}

		protected internal override string GetHurtSound()
		{
			return "mob.chickenhurt";
		}

		protected internal override string GetDeathSound()
		{
			return "mob.chickenhurt";
		}

		protected internal override int GetDropItemId()
		{
			return net.minecraft.src.Item.feather.shiftedIndex;
		}

		public bool field_392_a;

		public float field_391_b;

		public float field_395_ad;

		public float field_394_ae;

		public float field_393_af;

		public float field_390_ai;

		public int timeUntilNextEgg;
	}
}
