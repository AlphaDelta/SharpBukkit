// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockTrapDoor : net.minecraft.src.Block
	{
		protected internal BlockTrapDoor(int i, net.minecraft.src.Material material)
			: base(i, material)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, IBlockAccess, World, 
			//            AxisAlignedBB, EntityPlayer, Vec3D, MovingObjectPosition
			blockIndexInTexture = 84;
			if (material == net.minecraft.src.Material.iron)
			{
				blockIndexInTexture++;
			}
			float f = 0.5F;
			float f1 = 1.0F;
			SetBlockBounds(0.5F - f, 0.0F, 0.5F - f, 0.5F + f, f1, 0.5F + f);
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		public override bool IsACube()
		{
			return false;
		}

		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			SetBlockBoundsBasedOnState(world, i, j, k);
			return base.GetCollisionBoundingBoxFromPool(world, i, j, k);
		}

		public override void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k)
		{
			Func_28039_c(iblockaccess.GetBlockMetadata(i, j, k));
		}

		public virtual void Func_28039_c(int i)
		{
			float f = 0.1875F;
			SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, f, 1.0F);
			if (Func_28038_d(i))
			{
				if ((i & 3) == 0)
				{
					SetBlockBounds(0.0F, 0.0F, 1.0F - f, 1.0F, 1.0F, 1.0F);
				}
				if ((i & 3) == 1)
				{
					SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 1.0F, f);
				}
				if ((i & 3) == 2)
				{
					SetBlockBounds(1.0F - f, 0.0F, 0.0F, 1.0F, 1.0F, 1.0F);
				}
				if ((i & 3) == 3)
				{
					SetBlockBounds(0.0F, 0.0F, 0.0F, f, 1.0F, 1.0F);
				}
			}
		}

		public override void OnBlockClicked(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			BlockActivated(world, i, j, k, entityplayer);
		}

		public override bool BlockActivated(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			if (blockMaterial == net.minecraft.src.Material.iron)
			{
				return true;
			}
			else
			{
				int l = world.GetBlockMetadata(i, j, k);
				world.SetBlockMetadataWithNotify(i, j, k, l ^ 4);
				world.SendSoundEffectToAllPlayersWithin64(entityplayer, 1003, i, j, k, 0);
				return true;
			}
		}

		public virtual void Func_28040_a(net.minecraft.src.World world, int i, int j, int
			 k, bool flag)
		{
			int l = world.GetBlockMetadata(i, j, k);
			bool flag1 = (l & 4) > 0;
			if (flag1 == flag)
			{
				return;
			}
			else
			{
				world.SetBlockMetadataWithNotify(i, j, k, l ^ 4);
				world.SendSoundEffectToAllPlayersWithin64(null, 1003, i, j, k, 0);
				return;
			}
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			int i1 = world.GetBlockMetadata(i, j, k);
			int j1 = i;
			int k1 = k;
			if ((i1 & 3) == 0)
			{
				k1++;
			}
			if ((i1 & 3) == 1)
			{
				k1--;
			}
			if ((i1 & 3) == 2)
			{
				j1++;
			}
			if ((i1 & 3) == 3)
			{
				j1--;
			}
			if (!world.IsBlockNormalCube(j1, j, k1))
			{
				world.SetBlockWithNotify(i, j, k, 0);
				DropBlockAsItem(world, i, j, k, i1);
			}
			if (l > 0 && net.minecraft.src.Block.blocksList[l].CanProvidePower())
			{
				bool flag = world.IsBlockIndirectlyGettingPowered(i, j, k);
				Func_28040_a(world, i, j, k, flag);
			}
		}

		public override net.minecraft.src.MovingObjectPosition CollisionRayTrace(net.minecraft.src.World
			 world, int i, int j, int k, net.minecraft.src.Vec3D vec3d, net.minecraft.src.Vec3D
			 vec3d1)
		{
			SetBlockBoundsBasedOnState(world, i, j, k);
			return base.CollisionRayTrace(world, i, j, k, vec3d, vec3d1);
		}

		public override void OnBlockPlaced(net.minecraft.src.World world, int i, int j, int
			 k, int l)
		{
			byte byte0 = 0;
			if (l == 2)
			{
				byte0 = 0;
			}
			if (l == 3)
			{
				byte0 = 1;
			}
			if (l == 4)
			{
				byte0 = 2;
			}
			if (l == 5)
			{
				byte0 = 3;
			}
			world.SetBlockMetadataWithNotify(i, j, k, byte0);
			OnNeighborBlockChange(world, i, j, k, Block.REDSTONE_WIRE.ID); // CRAFTBUKKIT
		}

		public override bool CanPlaceBlockOnSide(net.minecraft.src.World world, int i, int
			 j, int k, int l)
		{
			if (l == 0)
			{
				return false;
			}
			if (l == 1)
			{
				return false;
			}
			if (l == 2)
			{
				k++;
			}
			if (l == 3)
			{
				k--;
			}
			if (l == 4)
			{
				i++;
			}
			if (l == 5)
			{
				i--;
			}
			return world.IsBlockNormalCube(i, j, k);
		}

		public static bool Func_28038_d(int i)
		{
			return (i & 4) != 0;
		}
	}
}
