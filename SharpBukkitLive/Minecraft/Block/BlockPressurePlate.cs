// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockPressurePlate : net.minecraft.src.Block
	{
		protected internal BlockPressurePlate(int i, int j, net.minecraft.src.EnumMobType
			 enummobtype, net.minecraft.src.Material material)
			: base(i, j, material)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, World, EnumMobType, AxisAlignedBB, 
			//            EntityLiving, EntityPlayer, IBlockAccess, Material, 
			//            Entity
			triggerMobType = enummobtype;
			SetTickOnLoad(true);
			float f = 0.0625F;
			SetBlockBounds(f, 0.0F, f, 1.0F - f, 0.03125F, 1.0F - f);
		}

		public override int TickRate()
		{
			return 20;
		}

		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			return null;
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		public override bool IsACube()
		{
			return false;
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			return world.IsBlockNormalCube(i, j - 1, k);
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			bool flag = false;
			if (!world.IsBlockNormalCube(i, j - 1, k))
			{
				flag = true;
			}
			if (flag)
			{
				DropBlockAsItem(world, i, j, k, world.GetBlockMetadata(i, j, k));
				world.SetBlockWithNotify(i, j, k, 0);
			}
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			if (world.GetBlockMetadata(i, j, k) == 0)
			{
				return;
			}
			else
			{
				SetStateIfMobInteractsWithPlate(world, i, j, k);
				return;
			}
		}

		public override void OnEntityCollidedWithBlock(net.minecraft.src.World world, int
			 i, int j, int k, net.minecraft.src.Entity entity)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			if (world.GetBlockMetadata(i, j, k) == 1)
			{
				return;
			}
			else
			{
				SetStateIfMobInteractsWithPlate(world, i, j, k);
				return;
			}
		}

		private void SetStateIfMobInteractsWithPlate(net.minecraft.src.World world, int i
			, int j, int k)
		{
			bool flag = world.GetBlockMetadata(i, j, k) == 1;
			bool flag1 = false;
			float f = 0.125F;
			System.Collections.IList list = null;
			if (triggerMobType == net.minecraft.src.EnumMobType.everything)
			{
				list = world.GetEntitiesWithinAABBExcludingEntity(null, net.minecraft.src.AxisAlignedBB
					.GetBoundingBoxFromPool((float)i + f, j, (float)k + f, (float)(i + 1) - f, (double
					)j + 0.25D, (float)(k + 1) - f));
			}
			if (triggerMobType == net.minecraft.src.EnumMobType.mobs)
			{
				list = world.GetEntitiesWithinAABB(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityLiving
					)), net.minecraft.src.AxisAlignedBB.GetBoundingBoxFromPool((float)i + f, j, (float
					)k + f, (float)(i + 1) - f, (double)j + 0.25D, (float)(k + 1) - f));
			}
			if (triggerMobType == net.minecraft.src.EnumMobType.players)
			{
				list = world.GetEntitiesWithinAABB(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityPlayer
					)), net.minecraft.src.AxisAlignedBB.GetBoundingBoxFromPool((float)i + f, j, (float
					)k + f, (float)(i + 1) - f, (double)j + 0.25D, (float)(k + 1) - f));
			}
			if (list.Count > 0)
			{
				flag1 = true;
			}
			if (flag1 && !flag)
			{
				world.SetBlockMetadataWithNotify(i, j, k, 1);
				world.NotifyBlocksOfNeighborChange(i, j, k, blockID);
				world.NotifyBlocksOfNeighborChange(i, j - 1, k, blockID);
				world.MarkBlocksDirty(i, j, k, i, j, k);
				world.PlaySoundEffect((double)i + 0.5D, (double)j + 0.10000000000000001D, (double
					)k + 0.5D, "random.click", 0.3F, 0.6F);
			}
			if (!flag1 && flag)
			{
				world.SetBlockMetadataWithNotify(i, j, k, 0);
				world.NotifyBlocksOfNeighborChange(i, j, k, blockID);
				world.NotifyBlocksOfNeighborChange(i, j - 1, k, blockID);
				world.MarkBlocksDirty(i, j, k, i, j, k);
				world.PlaySoundEffect((double)i + 0.5D, (double)j + 0.10000000000000001D, (double
					)k + 0.5D, "random.click", 0.3F, 0.5F);
			}
			if (flag1)
			{
				world.ScheduleUpdateTick(i, j, k, blockID, TickRate());
			}
		}

		public override void OnBlockRemoval(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			int l = world.GetBlockMetadata(i, j, k);
			if (l > 0)
			{
				world.NotifyBlocksOfNeighborChange(i, j, k, blockID);
				world.NotifyBlocksOfNeighborChange(i, j - 1, k, blockID);
			}
			base.OnBlockRemoval(world, i, j, k);
		}

		public override void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k)
		{
			bool flag = iblockaccess.GetBlockMetadata(i, j, k) == 1;
			float f = 0.0625F;
			if (flag)
			{
				SetBlockBounds(f, 0.0F, f, 1.0F - f, 0.03125F, 1.0F - f);
			}
			else
			{
				SetBlockBounds(f, 0.0F, f, 1.0F - f, 0.0625F, 1.0F - f);
			}
		}

		public override bool IsPoweringTo(net.minecraft.src.IBlockAccess iblockaccess, int
			 i, int j, int k, int l)
		{
			return iblockaccess.GetBlockMetadata(i, j, k) > 0;
		}

		public override bool IsIndirectlyPoweringTo(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			if (world.GetBlockMetadata(i, j, k) == 0)
			{
				return false;
			}
			else
			{
				return l == 1;
			}
		}

		public override bool CanProvidePower()
		{
			return true;
		}

		public override int GetMobilityFlag()
		{
			return 1;
		}

		private net.minecraft.src.EnumMobType triggerMobType;
	}
}
