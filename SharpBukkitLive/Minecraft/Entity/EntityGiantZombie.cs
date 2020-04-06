// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityGiantZombie : net.minecraft.src.EntityMob
	{
		public EntityGiantZombie(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityMob, World
			texture = "/mob/zombie.png";
			moveSpeed = 0.5F;
			attackStrength = 50;
			health *= 10;
			yOffset *= 6F;
			SetSize(width * 6F, height * 6F);
		}

		protected internal override float GetBlockPathWeight(int i, int j, int k)
		{
			return worldObj.GetLightBrightness(i, j, k) - 0.5F;
		}
	}
}
