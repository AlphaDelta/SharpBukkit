// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockDoor : net.minecraft.src.Block
	{
		protected internal BlockDoor(int i, net.minecraft.src.Material material)
			: base(i, material)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, IBlockAccess, World, 
			//            Item, AxisAlignedBB, EntityPlayer, Vec3D, 
			//            MovingObjectPosition
			blockIndexInTexture = 97;
			if (material == net.minecraft.src.Material.iron)
			{
				blockIndexInTexture++;
			}
			float f = 0.5F;
			float f1 = 1.0F;
			SetBlockBounds(0.5F - f, 0.0F, 0.5F - f, 0.5F + f, f1, 0.5F + f);
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			if (i == 0 || i == 1)
			{
				return blockIndexInTexture;
			}
			int k = Func_271_d(j);
			if ((k == 0 || k == 2) ^ (i <= 3))
			{
				return blockIndexInTexture;
			}
			int l = k / 2 + (i & 1 ^ k);
			l += (j & 4) / 4;
			int i1 = blockIndexInTexture - (j & 8) * 2;
			if ((l & 1) != 0)
			{
				i1 = -i1;
			}
			return i1;
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
			Func_273_b(Func_271_d(iblockaccess.GetBlockMetadata(i, j, k)));
		}

		public virtual void Func_273_b(int i)
		{
			float f = 0.1875F;
			SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 2.0F, 1.0F);
			if (i == 0)
			{
				SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 1.0F, f);
			}
			if (i == 1)
			{
				SetBlockBounds(1.0F - f, 0.0F, 0.0F, 1.0F, 1.0F, 1.0F);
			}
			if (i == 2)
			{
				SetBlockBounds(0.0F, 0.0F, 1.0F - f, 1.0F, 1.0F, 1.0F);
			}
			if (i == 3)
			{
				SetBlockBounds(0.0F, 0.0F, 0.0F, f, 1.0F, 1.0F);
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
			int l = world.GetBlockMetadata(i, j, k);
			if ((l & 8) != 0)
			{
				if (world.GetBlockId(i, j - 1, k) == blockID)
				{
					BlockActivated(world, i, j - 1, k, entityplayer);
				}
				return true;
			}
			if (world.GetBlockId(i, j + 1, k) == blockID)
			{
				world.SetBlockMetadataWithNotify(i, j + 1, k, (l ^ 4) + 8);
			}
			world.SetBlockMetadataWithNotify(i, j, k, l ^ 4);
			world.MarkBlocksDirty(i, j - 1, k, i, j, k);
			world.SendSoundEffectToAllPlayersWithin64(entityplayer, 1003, i, j, k, 0);
			return true;
		}

		public virtual void Func_272_a(net.minecraft.src.World world, int i, int j, int k
			, bool flag)
		{
			int l = world.GetBlockMetadata(i, j, k);
			if ((l & 8) != 0)
			{
				if (world.GetBlockId(i, j - 1, k) == blockID)
				{
					Func_272_a(world, i, j - 1, k, flag);
				}
				return;
			}
			bool flag1 = (world.GetBlockMetadata(i, j, k) & 4) > 0;
			if (flag1 == flag)
			{
				return;
			}
			if (world.GetBlockId(i, j + 1, k) == blockID)
			{
				world.SetBlockMetadataWithNotify(i, j + 1, k, (l ^ 4) + 8);
			}
			world.SetBlockMetadataWithNotify(i, j, k, l ^ 4);
			world.MarkBlocksDirty(i, j - 1, k, i, j, k);
			world.SendSoundEffectToAllPlayersWithin64(null, 1003, i, j, k, 0);
		}

		public override void OnNeighborBlockChange(net.minecraft.src.World world, int i, 
			int j, int k, int l)
		{
			int i1 = world.GetBlockMetadata(i, j, k);
			if ((i1 & 8) != 0)
			{
				if (world.GetBlockId(i, j - 1, k) != blockID)
				{
					world.SetBlockWithNotify(i, j, k, 0);
				}
				if (l > 0 && net.minecraft.src.Block.blocksList[l].CanProvidePower())
				{
					OnNeighborBlockChange(world, i, j - 1, k, l);
				}
			}
			else
			{
				bool flag = false;
				if (world.GetBlockId(i, j + 1, k) != blockID)
				{
					world.SetBlockWithNotify(i, j, k, 0);
					flag = true;
				}
				if (!world.IsBlockNormalCube(i, j - 1, k))
				{
					world.SetBlockWithNotify(i, j, k, 0);
					flag = true;
					if (world.GetBlockId(i, j + 1, k) == blockID)
					{
						world.SetBlockWithNotify(i, j + 1, k, 0);
					}
				}
				if (flag)
				{
					if (!world.singleplayerWorld)
					{
						DropBlockAsItem(world, i, j, k, i1);
					}
				}
				else
				{
					if (l > 0 && net.minecraft.src.Block.blocksList[l].CanProvidePower())
					{
						bool flag1 = world.IsBlockIndirectlyGettingPowered(i, j, k) || world.IsBlockIndirectlyGettingPowered
							(i, j + 1, k);
						Func_272_a(world, i, j, k, flag1);
					}
				}
			}
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			if ((i & 8) != 0)
			{
				return 0;
			}
			if (blockMaterial == net.minecraft.src.Material.iron)
			{
				return net.minecraft.src.Item.doorSteel.shiftedIndex;
			}
			else
			{
				return net.minecraft.src.Item.doorWood.shiftedIndex;
			}
		}

		public override net.minecraft.src.MovingObjectPosition CollisionRayTrace(net.minecraft.src.World
			 world, int i, int j, int k, net.minecraft.src.Vec3D vec3d, net.minecraft.src.Vec3D
			 vec3d1)
		{
			SetBlockBoundsBasedOnState(world, i, j, k);
			return base.CollisionRayTrace(world, i, j, k, vec3d, vec3d1);
		}

		public virtual int Func_271_d(int i)
		{
			if ((i & 4) == 0)
			{
				return i - 1 & 3;
			}
			else
			{
				return i & 3;
			}
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			if (j >= 127)
			{
				return false;
			}
			else
			{
				return world.IsBlockNormalCube(i, j - 1, k) && base.CanPlaceBlockAt(world, i, j, 
					k) && base.CanPlaceBlockAt(world, i, j + 1, k);
			}
		}

		public static bool Func_27036_e(int i)
		{
			return (i & 4) != 0;
		}

		public override int GetMobilityFlag()
		{
			return 1;
		}
	}
}
