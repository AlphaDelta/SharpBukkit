// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class BlockDetectorRail : net.minecraft.src.BlockRail
	{
		public BlockDetectorRail(int i, int j)
			: base(i, j, true)
		{
			// Referenced classes of package net.minecraft.src:
			//            BlockRail, World, IBlockAccess, EntityMinecart, 
			//            AxisAlignedBB, Entity
			SetTickOnLoad(true);
		}

		public override int TickRate()
		{
			return 20;
		}

		public override bool CanProvidePower()
		{
			return true;
		}

		public override void OnEntityCollidedWithBlock(net.minecraft.src.World world, int
			 i, int j, int k, net.minecraft.src.Entity entity)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			int l = world.GetBlockMetadata(i, j, k);
			if ((l & 8) != 0)
			{
				return;
			}
			else
			{
				Func_27035_f(world, i, j, k, l);
				return;
			}
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			int l = world.GetBlockMetadata(i, j, k);
			if ((l & 8) == 0)
			{
				return;
			}
			else
			{
				Func_27035_f(world, i, j, k, l);
				return;
			}
		}

		public override bool IsPoweringTo(net.minecraft.src.IBlockAccess iblockaccess, int
			 i, int j, int k, int l)
		{
			return (iblockaccess.GetBlockMetadata(i, j, k) & 8) != 0;
		}

		public override bool IsIndirectlyPoweringTo(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			if ((world.GetBlockMetadata(i, j, k) & 8) == 0)
			{
				return false;
			}
			else
			{
				return l == 1;
			}
		}

		private void Func_27035_f(net.minecraft.src.World world, int i, int j, int k, int
			 l)
		{
			bool flag = (l & 8) != 0;
			bool flag1 = false;
			float f = 0.125F;
			List<Entity> list = world.GetEntitiesWithinAABB(Sharpen.Runtime.GetClassForType
				(typeof(net.minecraft.src.EntityMinecart)), net.minecraft.src.AxisAlignedBB.GetBoundingBoxFromPool
				((float)i + f, j, (float)k + f, (float)(i + 1) - f, (double)j + 0.25D, (float)(k
				 + 1) - f));
			if (list.Count > 0)
			{
				flag1 = true;
			}
			if (flag1 && !flag)
			{
				world.SetBlockMetadataWithNotify(i, j, k, l | 8);
				world.NotifyBlocksOfNeighborChange(i, j, k, blockID);
				world.NotifyBlocksOfNeighborChange(i, j - 1, k, blockID);
				world.MarkBlocksDirty(i, j, k, i, j, k);
			}
			if (!flag1 && flag)
			{
				world.SetBlockMetadataWithNotify(i, j, k, l & 7);
				world.NotifyBlocksOfNeighborChange(i, j, k, blockID);
				world.NotifyBlocksOfNeighborChange(i, j - 1, k, blockID);
				world.MarkBlocksDirty(i, j, k, i, j, k);
			}
			if (flag1)
			{
				world.ScheduleUpdateTick(i, j, k, blockID, TickRate());
			}
		}
	}
}
