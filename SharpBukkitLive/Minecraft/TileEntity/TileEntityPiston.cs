// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class TileEntityPiston : net.minecraft.src.TileEntity
	{
		public TileEntityPiston()
		{
		}

		public TileEntityPiston(int i, int j, int k, bool flag, bool flag1)
		{
			// Referenced classes of package net.minecraft.src:
			//            TileEntity, Block, BlockPistonMoving, World, 
			//            Entity, PistonBlockTextures, NBTTagCompound
			storedBlockID = i;
			storedMetadata = j;
			storedOrientation = k;
			isExtending = flag;
			field_31018_j = flag1;
		}

		public virtual int GetStoredBlockID()
		{
			return storedBlockID;
		}

		public override int Func_31005_e()
		{
			return storedMetadata;
		}

		public virtual bool Func_31010_c()
		{
			return isExtending;
		}

		public virtual int Func_31008_d()
		{
			return storedOrientation;
		}

		public virtual float Func_31007_a(float f)
		{
			if (f > 1.0F)
			{
				f = 1.0F;
			}
			return lastProgress + (progress - lastProgress) * f;
		}

		private void Func_31009_a(float f, float f1)
		{
			if (!isExtending)
			{
				f--;
			}
			else
			{
				f = 1.0F - f;
			}
			net.minecraft.src.AxisAlignedBB axisalignedbb = net.minecraft.src.Block.PISTON_MOVING
				.Func_31032_a(worldObj, xCoord, yCoord, zCoord, storedBlockID, f, storedOrientation
				);
			if (axisalignedbb != null)
			{
				List<Entity> list = worldObj.GetEntitiesWithinAABBExcludingEntity(null
					, axisalignedbb);
				if (list.Count > 0)
				{
					//Sharpen.Collections.AddAll(field_31013_m, list);
					field_31013_m.AddRange(list);
					net.minecraft.src.Entity entity;
					for (System.Collections.IEnumerator iterator = field_31013_m.GetEnumerator(); iterator
						.MoveNext(); entity.MoveEntity(f1 * (float)net.minecraft.src.PistonBlockTextures
						.field_31051_b[storedOrientation], f1 * (float)net.minecraft.src.PistonBlockTextures
						.field_31054_c[storedOrientation], f1 * (float)net.minecraft.src.PistonBlockTextures
						.field_31053_d[storedOrientation]))
					{
						entity = (net.minecraft.src.Entity)iterator.Current;
					}
					field_31013_m.Clear();
				}
			}
		}

		public virtual void ClearPistonTileEntity()
		{
			if (lastProgress < 1.0F)
			{
				lastProgress = progress = 1.0F;
				worldObj.RemoveBlockTileEntity(xCoord, yCoord, zCoord);
				Invalidate();
				if (worldObj.GetBlockId(xCoord, yCoord, zCoord) == net.minecraft.src.Block.PISTON_MOVING
					.ID)
				{
					worldObj.SetBlockAndMetadataWithNotify(xCoord, yCoord, zCoord, storedBlockID, storedMetadata
						);
				}
			}
		}

		public override void UpdateEntity()
		{
			if (this.worldObj == null) return; // CRAFTBUKKIT

			lastProgress = progress;
			if (lastProgress >= 1.0F)
			{
				Func_31009_a(1.0F, 0.25F);
				worldObj.RemoveBlockTileEntity(xCoord, yCoord, zCoord);
				Invalidate();
				if (worldObj.GetBlockId(xCoord, yCoord, zCoord) == net.minecraft.src.Block.PISTON_MOVING
					.ID)
				{
					worldObj.SetBlockAndMetadataWithNotify(xCoord, yCoord, zCoord, storedBlockID, storedMetadata
						);
				}
				return;
			}
			progress += 0.5F;
			if (progress >= 1.0F)
			{
				progress = 1.0F;
			}
			if (isExtending)
			{
				Func_31009_a(progress, (progress - lastProgress) + 0.0625F);
			}
		}

		public override void ReadFromNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.ReadFromNBT(nbttagcompound);
			storedBlockID = nbttagcompound.GetInteger("blockId");
			storedMetadata = nbttagcompound.GetInteger("blockData");
			storedOrientation = nbttagcompound.GetInteger("facing");
			lastProgress = progress = nbttagcompound.GetFloat("progress");
			isExtending = nbttagcompound.GetBoolean("extending");
		}

		public override void WriteToNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.WriteToNBT(nbttagcompound);
			nbttagcompound.SetInteger("blockId", storedBlockID);
			nbttagcompound.SetInteger("blockData", storedMetadata);
			nbttagcompound.SetInteger("facing", storedOrientation);
			nbttagcompound.SetFloat("progress", lastProgress);
			nbttagcompound.SetBoolean("extending", isExtending);
		}

		private int storedBlockID;

		private int storedMetadata;

		private int storedOrientation;

		private bool isExtending;

		private bool field_31018_j;

		private float progress;

		private float lastProgress;

		private static List<Entity> field_31013_m = new List<Entity>();
	}
}
