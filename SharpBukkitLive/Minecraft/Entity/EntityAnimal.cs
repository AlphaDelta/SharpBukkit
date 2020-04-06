// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public abstract class EntityAnimal : net.minecraft.src.EntityCreature, net.minecraft.src.IAnimals
	{
		public EntityAnimal(net.minecraft.src.World world)
			: base(world)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            EntityCreature, IAnimals, World, Block, 
		//            BlockGrass, MathHelper, AxisAlignedBB, NBTTagCompound
		protected internal override float GetBlockPathWeight(int i, int j, int k)
		{
			if (worldObj.GetBlockId(i, j - 1, k) == net.minecraft.src.Block.grass.blockID)
			{
				return 10F;
			}
			else
			{
				return worldObj.GetLightBrightness(i, j, k) - 0.5F;
			}
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
			int i = net.minecraft.src.MathHelper.Floor_double(posX);
			int j = net.minecraft.src.MathHelper.Floor_double(boundingBox.minY);
			int k = net.minecraft.src.MathHelper.Floor_double(posZ);
			return worldObj.GetBlockId(i, j - 1, k) == net.minecraft.src.Block.grass.blockID 
				&& worldObj.GetBlockLightValueNoChecks(i, j, k) > 8 && base.GetCanSpawnHere();
		}

		public override int GetTalkInterval()
		{
			return 120;
		}
	}
}
