// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class BlockStairs : net.minecraft.src.Block
	{
		protected internal BlockStairs(int i, net.minecraft.src.Block block)
			: base(i, block.blockIndexInTexture, block.blockMaterial)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, World, EntityLiving, MathHelper, 
			//            IBlockAccess, AxisAlignedBB, EntityPlayer, Entity, 
			//            Vec3D
			modelBlock = block;
			SetHardness(block.blockHardness);
			SetResistance(block.blockResistance / 3F);
			SetStepSound(block.stepSound);
			SetLightOpacity(255);
		}

		public override void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
			, int i, int j, int k)
		{
			SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 1.0F, 1.0F);
		}

		public override net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
			 world, int i, int j, int k)
		{
			return base.GetCollisionBoundingBoxFromPool(world, i, j, k);
		}

		public override bool IsOpaqueCube()
		{
			return false;
		}

		public override bool IsACube()
		{
			return false;
		}

		public override void GetCollidingBoundingBoxes(net.minecraft.src.World world, int i, int j, int k, net.minecraft.src.AxisAlignedBB axisalignedbb, List<AxisAlignedBB> arraylist)
		{
			int l = world.GetBlockMetadata(i, j, k);
			if (l == 0)
			{
				SetBlockBounds(0.0F, 0.0F, 0.0F, 0.5F, 0.5F, 1.0F);
				base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
				SetBlockBounds(0.5F, 0.0F, 0.0F, 1.0F, 1.0F, 1.0F);
				base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
			}
			else
			{
				if (l == 1)
				{
					SetBlockBounds(0.0F, 0.0F, 0.0F, 0.5F, 1.0F, 1.0F);
					base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
					SetBlockBounds(0.5F, 0.0F, 0.0F, 1.0F, 0.5F, 1.0F);
					base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
				}
				else
				{
					if (l == 2)
					{
						SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 0.5F, 0.5F);
						base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
						SetBlockBounds(0.0F, 0.0F, 0.5F, 1.0F, 1.0F, 1.0F);
						base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
					}
					else
					{
						if (l == 3)
						{
							SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 1.0F, 0.5F);
							base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
							SetBlockBounds(0.0F, 0.0F, 0.5F, 1.0F, 0.5F, 1.0F);
							base.GetCollidingBoundingBoxes(world, i, j, k, axisalignedbb, arraylist);
						}
					}
				}
			}
			SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 1.0F, 1.0F);
		}

		public override void OnBlockClicked(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			modelBlock.OnBlockClicked(world, i, j, k, entityplayer);
		}

		public override void OnBlockDestroyedByPlayer(net.minecraft.src.World world, int 
			i, int j, int k, int l)
		{
			modelBlock.OnBlockDestroyedByPlayer(world, i, j, k, l);
		}

		public override float GetExplosionResistance(net.minecraft.src.Entity entity)
		{
			return modelBlock.GetExplosionResistance(entity);
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return modelBlock.IdDropped(i, random);
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return modelBlock.QuantityDropped(random);
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			return modelBlock.GetBlockTextureFromSideAndMetadata(i, j);
		}

		public override int GetBlockTextureFromSide(int i)
		{
			return modelBlock.GetBlockTextureFromSide(i);
		}

		public override int TickRate()
		{
			return modelBlock.TickRate();
		}

		public override void VelocityToAddToEntity(net.minecraft.src.World world, int i, 
			int j, int k, net.minecraft.src.Entity entity, net.minecraft.src.Vec3D vec3d)
		{
			modelBlock.VelocityToAddToEntity(world, i, j, k, entity, vec3d);
		}

		public override bool IsCollidable()
		{
			return modelBlock.IsCollidable();
		}

		public override bool CanCollideCheck(int i, bool flag)
		{
			return modelBlock.CanCollideCheck(i, flag);
		}

		public override bool CanPlaceBlockAt(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			return modelBlock.CanPlaceBlockAt(world, i, j, k);
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			OnNeighborBlockChange(world, i, j, k, 0);
			modelBlock.OnBlockAdded(world, i, j, k);
		}

		public override void OnBlockRemoval(net.minecraft.src.World world, int i, int j, 
			int k)
		{
			modelBlock.OnBlockRemoval(world, i, j, k);
		}

		public override void DropBlockAsItemWithChance(net.minecraft.src.World world, int
			 i, int j, int k, int l, float f)
		{
			modelBlock.DropBlockAsItemWithChance(world, i, j, k, l, f);
		}

		public override void OnEntityWalking(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.Entity entity)
		{
			modelBlock.OnEntityWalking(world, i, j, k, entity);
		}

		public override void UpdateTick(net.minecraft.src.World world, int i, int j, int 
			k, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			modelBlock.UpdateTick(world, i, j, k, random);
		}

		public override bool BlockActivated(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityPlayer entityplayer)
		{
			return modelBlock.BlockActivated(world, i, j, k, entityplayer);
		}

		public override void OnBlockDestroyedByExplosion(net.minecraft.src.World world, int
			 i, int j, int k)
		{
			modelBlock.OnBlockDestroyedByExplosion(world, i, j, k);
		}

		public override void OnBlockPlacedBy(net.minecraft.src.World world, int i, int j, 
			int k, net.minecraft.src.EntityLiving entityliving)
		{
			int l = net.minecraft.src.MathHelper.Floor_double((double)((entityliving.rotationYaw
				 * 4F) / 360F) + 0.5D) & 3;
			if (l == 0)
			{
				world.SetBlockMetadataWithNotify(i, j, k, 2);
			}
			if (l == 1)
			{
				world.SetBlockMetadataWithNotify(i, j, k, 1);
			}
			if (l == 2)
			{
				world.SetBlockMetadataWithNotify(i, j, k, 3);
			}
			if (l == 3)
			{
				world.SetBlockMetadataWithNotify(i, j, k, 0);
			}
		}

		private net.minecraft.src.Block modelBlock;
	}
}
