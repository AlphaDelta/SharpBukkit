// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class EntityPainting : net.minecraft.src.Entity
	{
		public EntityPainting(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            Entity, EnumArt, AxisAlignedBB, World, 
			//            EntityItem, ItemStack, Item, MathHelper, 
			//            Material, NBTTagCompound
			field_452_ad = 0;
			direction = 0;
			yOffset = 0.0F;
			SetSize(0.5F, 0.5F);
		}

		public EntityPainting(net.minecraft.src.World world, int i, int j, int k, int l)
			: this(world)
		{
			xPosition = i;
			yPosition = j;
			zPosition = k;
			List<EnumArt> arraylist = new List<EnumArt>();
			net.minecraft.src.EnumArt[] aenumart = net.minecraft.src.EnumArt.Values();
			int i1 = aenumart.Length;
			for (int j1 = 0; j1 < i1; j1++)
			{
				net.minecraft.src.EnumArt enumart = aenumart[j1];
				art = enumart;
				Func_179_a(l);
				if (OnValidSurface())
				{
					arraylist.Add(enumart);
				}
			}
			if (arraylist.Count > 0)
			{
				art = (net.minecraft.src.EnumArt)arraylist[rand.Next(arraylist.Count)];
			}
			Func_179_a(l);
		}

		protected internal override void EntityInit()
		{
		}

		public virtual void Func_179_a(int i)
		{
			direction = i;
			prevRotationYaw = rotationYaw = i * 90;
			float f = art.sizeX;
			float f1 = art.sizeY;
			float f2 = art.sizeX;
			if (i == 0 || i == 2)
			{
				f2 = 0.5F;
			}
			else
			{
				f = 0.5F;
			}
			f /= 32F;
			f1 /= 32F;
			f2 /= 32F;
			float f3 = (float)xPosition + 0.5F;
			float f4 = (float)yPosition + 0.5F;
			float f5 = (float)zPosition + 0.5F;
			float f6 = 0.5625F;
			if (i == 0)
			{
				f5 -= f6;
			}
			if (i == 1)
			{
				f3 -= f6;
			}
			if (i == 2)
			{
				f5 += f6;
			}
			if (i == 3)
			{
				f3 += f6;
			}
			if (i == 0)
			{
				f3 -= Func_180_c(art.sizeX);
			}
			if (i == 1)
			{
				f5 += Func_180_c(art.sizeX);
			}
			if (i == 2)
			{
				f3 += Func_180_c(art.sizeX);
			}
			if (i == 3)
			{
				f5 -= Func_180_c(art.sizeX);
			}
			f4 += Func_180_c(art.sizeY);
			SetPosition(f3, f4, f5);
			float f7 = -0.00625F;
			boundingBox.SetBounds(f3 - f - f7, f4 - f1 - f7, f5 - f2 - f7, f3 + f + f7, f4 + 
				f1 + f7, f5 + f2 + f7);
		}

		private float Func_180_c(int i)
		{
			if (i == 32)
			{
				return 0.5F;
			}
			return i != 64 ? 0.0F : 0.5F;
		}

		public override void OnUpdate()
		{
			if (field_452_ad++ == 100 && !worldObj.singleplayerWorld)
			{
				field_452_ad = 0;
				if (!OnValidSurface())
				{
					//TODO: Hook

					if (!this.isDead) // CRAFTBUKKIT -- Make sure it's not already dead
					{
						SetEntityDead();
						worldObj.AddEntity(new net.minecraft.src.EntityItem(worldObj, posX, posY, posZ, new net.minecraft.src.ItemStack(net.minecraft.src.Item.PAINTING)));
					}
				}
			}
		}

		public virtual bool OnValidSurface()
		{
			if (worldObj.GetCollidingBoundingBoxes(this, boundingBox).Count > 0)
			{
				return false;
			}
			int i = art.sizeX / 16;
			int j = art.sizeY / 16;
			int k = xPosition;
			int l = yPosition;
			int i1 = zPosition;
			if (direction == 0)
			{
				k = net.minecraft.src.MathHelper.Floor_double(posX - (double)((float)art.sizeX / 
					32F));
			}
			if (direction == 1)
			{
				i1 = net.minecraft.src.MathHelper.Floor_double(posZ - (double)((float)art.sizeX /
					 32F));
			}
			if (direction == 2)
			{
				k = net.minecraft.src.MathHelper.Floor_double(posX - (double)((float)art.sizeX / 
					32F));
			}
			if (direction == 3)
			{
				i1 = net.minecraft.src.MathHelper.Floor_double(posZ - (double)((float)art.sizeX /
					 32F));
			}
			l = net.minecraft.src.MathHelper.Floor_double(posY - (double)((float)art.sizeY / 
				32F));
			for (int j1 = 0; j1 < i; j1++)
			{
				for (int k1 = 0; k1 < j; k1++)
				{
					net.minecraft.src.Material material;
					if (direction == 0 || direction == 2)
					{
						material = worldObj.GetBlockMaterial(k + j1, l + k1, zPosition);
					}
					else
					{
						material = worldObj.GetBlockMaterial(xPosition, l + k1, i1 + j1);
					}
					if (!material.IsSolid())
					{
						return false;
					}
				}
			}
			System.Collections.Generic.List<Entity> list = worldObj.GetEntitiesWithinAABBExcludingEntity(this
				, boundingBox);
			for (int l1 = 0; l1 < list.Count; l1++)
			{
				if (list[l1] is net.minecraft.src.EntityPainting)
				{
					return false;
				}
			}
			return true;
		}

		public override bool CanBeCollidedWith()
		{
			return true;
		}

		public override bool AttackEntityFrom(net.minecraft.src.Entity entity, int i)
		{
			if (!isDead && !worldObj.singleplayerWorld)
			{
				SetEntityDead();
				SetBeenAttacked();
				worldObj.AddEntity(new net.minecraft.src.EntityItem(worldObj, posX, posY, 
					posZ, new net.minecraft.src.ItemStack(net.minecraft.src.Item.PAINTING)));
			}
			return true;
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			nbttagcompound.SetByte("Dir", unchecked((byte)direction));
			nbttagcompound.SetString("Motive", art.title);
			nbttagcompound.SetInteger("TileX", xPosition);
			nbttagcompound.SetInteger("TileY", yPosition);
			nbttagcompound.SetInteger("TileZ", zPosition);
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			direction = nbttagcompound.GetByte("Dir");
			xPosition = nbttagcompound.GetInteger("TileX");
			yPosition = nbttagcompound.GetInteger("TileY");
			zPosition = nbttagcompound.GetInteger("TileZ");
			string s = nbttagcompound.GetString("Motive");
			net.minecraft.src.EnumArt[] aenumart = net.minecraft.src.EnumArt.Values();
			int i = aenumart.Length;
			for (int j = 0; j < i; j++)
			{
				net.minecraft.src.EnumArt enumart = aenumart[j];
				if (enumart.title.Equals(s))
				{
					art = enumart;
				}
			}
			if (art == null)
			{
				art = net.minecraft.src.EnumArt.Kebab;
			}
			Func_179_a(direction);
		}

		public override void MoveEntity(double d, double d1, double d2)
		{
			if (!worldObj.singleplayerWorld && d * d + d1 * d1 + d2 * d2 > 0.0D)
			{
				SetEntityDead();
				worldObj.AddEntity(new net.minecraft.src.EntityItem(worldObj, posX, posY, 
					posZ, new net.minecraft.src.ItemStack(net.minecraft.src.Item.PAINTING)));
			}
		}

		public override void AddVelocity(double d, double d1, double d2)
		{
			if (!worldObj.singleplayerWorld && d * d + d1 * d1 + d2 * d2 > 0.0D)
			{
				SetEntityDead();
				worldObj.AddEntity(new net.minecraft.src.EntityItem(worldObj, posX, posY, 
					posZ, new net.minecraft.src.ItemStack(net.minecraft.src.Item.PAINTING)));
			}
		}

		private int field_452_ad;

		public int direction;

		public int xPosition;

		public int yPosition;

		public int zPosition;

		public net.minecraft.src.EnumArt art;
	}
}
