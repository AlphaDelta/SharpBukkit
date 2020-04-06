// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class MovingObjectPosition
	{
		public MovingObjectPosition(int i, int j, int k, int l, net.minecraft.src.Vec3D vec3d
			)
		{
			// Referenced classes of package net.minecraft.src:
			//            EnumMovingObjectType, Vec3D, Entity
			typeOfHit = net.minecraft.src.EnumMovingObjectType.TILE;
			blockX = i;
			blockY = j;
			blockZ = k;
			sideHit = l;
			hitVec = net.minecraft.src.Vec3D.CreateVector(vec3d.xCoord, vec3d.yCoord, vec3d.zCoord
				);
		}

		public MovingObjectPosition(net.minecraft.src.Entity entity)
		{
			typeOfHit = net.minecraft.src.EnumMovingObjectType.ENTITY;
			entityHit = entity;
			hitVec = net.minecraft.src.Vec3D.CreateVector(entity.posX, entity.posY, entity.posZ
				);
		}

		public net.minecraft.src.EnumMovingObjectType typeOfHit;

		public int blockX;

		public int blockY;

		public int blockZ;

		public int sideHit;

		public net.minecraft.src.Vec3D hitVec;

		public net.minecraft.src.Entity entityHit;
	}
}
