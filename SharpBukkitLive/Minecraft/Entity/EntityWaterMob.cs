// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityWaterMob : net.minecraft.src.EntityCreature, net.minecraft.src.IAnimals
	{
		public EntityWaterMob(net.minecraft.src.World world)
			: base(world)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            EntityCreature, IAnimals, World, NBTTagCompound
		public override bool CanBreatheUnderwater()
		{
			return true;
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

		public override bool GetCanSpawnHere()
		{
			return worldObj.CheckIfAABBIsClear(boundingBox);
		}

		public override int GetTalkInterval()
		{
			return 120;
		}
	}
}
