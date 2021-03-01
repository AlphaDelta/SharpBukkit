// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Pathfinder
	{
		public Pathfinder(net.minecraft.src.IBlockAccess iblockaccess)
		{
			// Referenced classes of package net.minecraft.src:
			//            Path, MCHash, PathPoint, Entity, 
			//            AxisAlignedBB, MathHelper, IBlockAccess, Block, 
			//            BlockDoor, Material, PathEntity
			path = new net.minecraft.src.Path(null);
			pointMap = new net.minecraft.src.MCHash();
			pathOptions = new net.minecraft.src.PathPoint[32];
			worldMap = iblockaccess;
		}

		public virtual net.minecraft.src.PathEntity CreateEntityPathTo(net.minecraft.src.Entity
			 entity, net.minecraft.src.Entity entity1, float f)
		{
			return CreateEntityPathTo(entity, entity1.posX, entity1.boundingBox.minY, entity1
				.posZ, f);
		}

		public virtual net.minecraft.src.PathEntity CreateEntityPathTo(net.minecraft.src.Entity
			 entity, int i, int j, int k, float f)
		{
			return CreateEntityPathTo(entity, (float)i + 0.5F, (float)j + 0.5F, (float)k + 0.5F
				, f);
		}

		private net.minecraft.src.PathEntity CreateEntityPathTo(net.minecraft.src.Entity 
			entity, double d, double d1, double d2, float f)
		{
			path.ClearPath();
			pointMap.ClearMap();
			net.minecraft.src.PathPoint pathpoint = OpenPoint(net.minecraft.src.MathHelper.Floor_double
				(entity.boundingBox.minX), net.minecraft.src.MathHelper.Floor_double(entity.boundingBox
				.minY), net.minecraft.src.MathHelper.Floor_double(entity.boundingBox.minZ));
			net.minecraft.src.PathPoint pathpoint1 = OpenPoint(net.minecraft.src.MathHelper.Floor_double
				(d - (double)(entity.width / 2.0F)), net.minecraft.src.MathHelper.Floor_double(d1
				), net.minecraft.src.MathHelper.Floor_double(d2 - (double)(entity.width / 2.0F))
				);
			net.minecraft.src.PathPoint pathpoint2 = new net.minecraft.src.PathPoint(net.minecraft.src.MathHelper
				.Floor_float(entity.width + 1.0F), net.minecraft.src.MathHelper.Floor_float(entity
				.height + 1.0F), net.minecraft.src.MathHelper.Floor_float(entity.width + 1.0F));
			net.minecraft.src.PathEntity pathentity = AddToPath(entity, pathpoint, pathpoint1
				, pathpoint2, f);
			return pathentity;
		}

		private net.minecraft.src.PathEntity AddToPath(net.minecraft.src.Entity entity, net.minecraft.src.PathPoint
			 pathpoint, net.minecraft.src.PathPoint pathpoint1, net.minecraft.src.PathPoint 
			pathpoint2, float f)
		{
			pathpoint.totalPathDistance = 0.0F;
			pathpoint.distanceToNext = pathpoint.DistanceTo(pathpoint1);
			pathpoint.distanceToTarget = pathpoint.distanceToNext;
			path.ClearPath();
			path.AddPoint(pathpoint);
			net.minecraft.src.PathPoint pathpoint3 = pathpoint;
			while (!path.IsPathEmpty())
			{
				net.minecraft.src.PathPoint pathpoint4 = path.Dequeue();
				if (pathpoint4.Equals(pathpoint1))
				{
					return CreateEntityPath(pathpoint, pathpoint1);
				}
				if (pathpoint4.DistanceTo(pathpoint1) < pathpoint3.DistanceTo(pathpoint1))
				{
					pathpoint3 = pathpoint4;
				}
				pathpoint4.isFirst = true;
				int i = FindPathOptions(entity, pathpoint4, pathpoint2, pathpoint1, f);
				int j = 0;
				while (j < i)
				{
					net.minecraft.src.PathPoint pathpoint5 = pathOptions[j];
					float f1 = pathpoint4.totalPathDistance + pathpoint4.DistanceTo(pathpoint5);
					if (!pathpoint5.IsAssigned() || f1 < pathpoint5.totalPathDistance)
					{
						pathpoint5.previous = pathpoint4;
						pathpoint5.totalPathDistance = f1;
						pathpoint5.distanceToNext = pathpoint5.DistanceTo(pathpoint1);
						if (pathpoint5.IsAssigned())
						{
							path.ChangeDistance(pathpoint5, pathpoint5.totalPathDistance + pathpoint5.distanceToNext
								);
						}
						else
						{
							pathpoint5.distanceToTarget = pathpoint5.totalPathDistance + pathpoint5.distanceToNext;
							path.AddPoint(pathpoint5);
						}
					}
					j++;
				}
			}
			if (pathpoint3 == pathpoint)
			{
				return null;
			}
			else
			{
				return CreateEntityPath(pathpoint, pathpoint3);
			}
		}

		private int FindPathOptions(net.minecraft.src.Entity entity, net.minecraft.src.PathPoint
			 pathpoint, net.minecraft.src.PathPoint pathpoint1, net.minecraft.src.PathPoint 
			pathpoint2, float f)
		{
			int i = 0;
			int j = 0;
			if (GetVerticalOffset(entity, pathpoint.xCoord, pathpoint.yCoord + 1, pathpoint.zCoord
				, pathpoint1) == 1)
			{
				j = 1;
			}
			net.minecraft.src.PathPoint pathpoint3 = GetSafePoint(entity, pathpoint.xCoord, pathpoint
				.yCoord, pathpoint.zCoord + 1, pathpoint1, j);
			net.minecraft.src.PathPoint pathpoint4 = GetSafePoint(entity, pathpoint.xCoord - 
				1, pathpoint.yCoord, pathpoint.zCoord, pathpoint1, j);
			net.minecraft.src.PathPoint pathpoint5 = GetSafePoint(entity, pathpoint.xCoord + 
				1, pathpoint.yCoord, pathpoint.zCoord, pathpoint1, j);
			net.minecraft.src.PathPoint pathpoint6 = GetSafePoint(entity, pathpoint.xCoord, pathpoint
				.yCoord, pathpoint.zCoord - 1, pathpoint1, j);
			if (pathpoint3 != null && !pathpoint3.isFirst && pathpoint3.DistanceTo(pathpoint2
				) < f)
			{
				pathOptions[i++] = pathpoint3;
			}
			if (pathpoint4 != null && !pathpoint4.isFirst && pathpoint4.DistanceTo(pathpoint2
				) < f)
			{
				pathOptions[i++] = pathpoint4;
			}
			if (pathpoint5 != null && !pathpoint5.isFirst && pathpoint5.DistanceTo(pathpoint2
				) < f)
			{
				pathOptions[i++] = pathpoint5;
			}
			if (pathpoint6 != null && !pathpoint6.isFirst && pathpoint6.DistanceTo(pathpoint2
				) < f)
			{
				pathOptions[i++] = pathpoint6;
			}
			return i;
		}

		private net.minecraft.src.PathPoint GetSafePoint(net.minecraft.src.Entity entity, 
			int i, int j, int k, net.minecraft.src.PathPoint pathpoint, int l)
		{
			net.minecraft.src.PathPoint pathpoint1 = null;
			if (GetVerticalOffset(entity, i, j, k, pathpoint) == 1)
			{
				pathpoint1 = OpenPoint(i, j, k);
			}
			if (pathpoint1 == null && l > 0 && GetVerticalOffset(entity, i, j + l, k, pathpoint
				) == 1)
			{
				pathpoint1 = OpenPoint(i, j + l, k);
				j += l;
			}
			if (pathpoint1 != null)
			{
				int i1 = 0;
				int j1 = 0;
				do
				{
					if (j <= 0 || (j1 = GetVerticalOffset(entity, i, j - 1, k, pathpoint)) != 1)
					{
						break;
					}
					if (++i1 >= 4)
					{
						return null;
					}
					if (--j > 0)
					{
						pathpoint1 = OpenPoint(i, j, k);
					}
				}
				while (true);
				if (j1 == -2)
				{
					return null;
				}
			}
			return pathpoint1;
		}

		private net.minecraft.src.PathPoint OpenPoint(int i, int j, int k)
		{
			int l = net.minecraft.src.PathPoint.Func_22203_a(i, j, k);
			net.minecraft.src.PathPoint pathpoint = (net.minecraft.src.PathPoint)pointMap.Lookup
				(l);
			if (pathpoint == null)
			{
				pathpoint = new net.minecraft.src.PathPoint(i, j, k);
				pointMap.AddKey(l, pathpoint);
			}
			return pathpoint;
		}

		private int GetVerticalOffset(net.minecraft.src.Entity entity, int i, int j, int 
			k, net.minecraft.src.PathPoint pathpoint)
		{
			for (int l = i; l < i + pathpoint.xCoord; l++)
			{
				for (int i1 = j; i1 < j + pathpoint.yCoord; i1++)
				{
					for (int j1 = k; j1 < k + pathpoint.zCoord; j1++)
					{
						int k1 = worldMap.GetBlockId(l, i1, j1);
						if (k1 <= 0)
						{
							continue;
						}
						if (k1 == net.minecraft.src.Block.IRON_DOOR_BLOCK.blockID || k1 == net.minecraft.src.Block
							.WOODEN_DOOR.blockID)
						{
							int l1 = worldMap.GetBlockMetadata(l, i1, j1);
							if (!net.minecraft.src.BlockDoor.Func_27036_e(l1))
							{
								return 0;
							}
							continue;
						}
						net.minecraft.src.Material material = net.minecraft.src.Block.blocksList[k1].blockMaterial;
						if (material.GetIsSolid())
						{
							return 0;
						}
						if (material == net.minecraft.src.Material.water)
						{
							return -1;
						}
						if (material == net.minecraft.src.Material.lava)
						{
							return -2;
						}
					}
				}
			}
			return 1;
		}

		private net.minecraft.src.PathEntity CreateEntityPath(net.minecraft.src.PathPoint
			 pathpoint, net.minecraft.src.PathPoint pathpoint1)
		{
			int i = 1;
			for (net.minecraft.src.PathPoint pathpoint2 = pathpoint1; pathpoint2.previous != 
				null; pathpoint2 = pathpoint2.previous)
			{
				i++;
			}
			net.minecraft.src.PathPoint[] apathpoint = new net.minecraft.src.PathPoint[i];
			net.minecraft.src.PathPoint pathpoint3 = pathpoint1;
			for (apathpoint[--i] = pathpoint3; pathpoint3.previous != null; apathpoint[--i] =
				 pathpoint3)
			{
				pathpoint3 = pathpoint3.previous;
			}
			return new net.minecraft.src.PathEntity(apathpoint);
		}

		private net.minecraft.src.IBlockAccess worldMap;

		private net.minecraft.src.Path path;

		private net.minecraft.src.MCHash pointMap;

		private net.minecraft.src.PathPoint[] pathOptions;
	}
}
