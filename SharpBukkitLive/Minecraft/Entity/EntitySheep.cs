// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntitySheep : net.minecraft.src.EntityAnimal
	{
		public EntitySheep(net.minecraft.src.World world)
			: base(world)
		{
			// Referenced classes of package net.minecraft.src:
			//            EntityAnimal, DataWatcher, ItemStack, Block, 
			//            EntityPlayer, InventoryPlayer, Item, ItemShears, 
			//            World, EntityItem, NBTTagCompound, Entity
			texture = "/mob/sheep.png";
			SetSize(0.9F, 1.3F);
		}

		protected internal override void EntityInit()
		{
			base.EntityInit();
			dataWatcher.AddObject(16, unchecked((byte)0));
		}

		public override bool AttackEntityFrom(net.minecraft.src.Entity entity, int i)
		{
			return base.AttackEntityFrom(entity, i);
		}

		protected internal override void DropFewItems()
		{
			if (!Func_21069_f_())
			{
				EntityDropItem(new net.minecraft.src.ItemStack(net.minecraft.src.Block.cloth.blockID
					, 1, GetFleeceColor()), 0.0F);
			}
		}

		protected internal override int GetDropItemId()
		{
			return net.minecraft.src.Block.cloth.blockID;
		}

		public override bool Interact(net.minecraft.src.EntityPlayer entityplayer)
		{
			net.minecraft.src.ItemStack itemstack = entityplayer.inventory.GetCurrentItem();
			if (itemstack != null && itemstack.itemID == net.minecraft.src.Item.field_31022_bc
				.shiftedIndex && !Func_21069_f_())
			{
				if (!worldObj.singleplayerWorld)
				{
					SetSheared(true);
					int i = 2 + rand.Next(3);
					for (int j = 0; j < i; j++)
					{
						net.minecraft.src.EntityItem entityitem = EntityDropItem(new net.minecraft.src.ItemStack
							(net.minecraft.src.Block.cloth.blockID, 1, GetFleeceColor()), 1.0F);
						entityitem.motionY += rand.NextFloat() * 0.05F;
						entityitem.motionX += (rand.NextFloat() - rand.NextFloat()) * 0.1F;
						entityitem.motionZ += (rand.NextFloat() - rand.NextFloat()) * 0.1F;
					}
				}
				itemstack.DamageItem(1, entityplayer);
			}
			return false;
		}

		protected internal override void WriteEntityToNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.WriteEntityToNBT(nbttagcompound);
			nbttagcompound.SetBoolean("Sheared", Func_21069_f_());
			nbttagcompound.SetByte("Color", unchecked((byte)GetFleeceColor()));
		}

		protected internal override void ReadEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			base.ReadEntityFromNBT(nbttagcompound);
			SetSheared(nbttagcompound.GetBoolean("Sheared"));
			SetFleeceColor(nbttagcompound.GetByte("Color"));
		}

		protected internal override string GetLivingSound()
		{
			return "mob.sheep";
		}

		protected internal override string GetHurtSound()
		{
			return "mob.sheep";
		}

		protected internal override string GetDeathSound()
		{
			return "mob.sheep";
		}

		public virtual int GetFleeceColor()
		{
			return dataWatcher.GetWatchableObjectByte(16) & unchecked((int)(0xf));
		}

		public virtual void SetFleeceColor(int i)
		{
			byte byte0 = dataWatcher.GetWatchableObjectByte(16);
			dataWatcher.UpdateObject(16, (byte)(unchecked((byte)(byte0 & unchecked((int)(0xf0)) | i & unchecked((int)(0xf))))));
		}

		public virtual bool Func_21069_f_()
		{
			return (dataWatcher.GetWatchableObjectByte(16) & unchecked((int)(0x10))) != 0;
		}

		public virtual void SetSheared(bool flag)
		{
			byte byte0 = dataWatcher.GetWatchableObjectByte(16);
			if (flag)
			{
				dataWatcher.UpdateObject(16, (byte)(unchecked((byte)(byte0 | unchecked((int
					)(0x10))))));
			}
			else
			{
				dataWatcher.UpdateObject(16, (byte)(unchecked((byte)(byte0 & unchecked((int
					)(0xffffffef))))));
			}
		}

		public static int Func_21066_a(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			int i = random.Next(100);
			if (i < 5)
			{
				return 15;
			}
			if (i < 10)
			{
				return 7;
			}
			if (i < 15)
			{
				return 8;
			}
			if (i < 18)
			{
				return 12;
			}
			return random.Next(500) != 0 ? 0 : 6;
		}

		public static readonly float[][] field_21071_a = new float[][] { new float[] { 1.0F
			, 1.0F, 1.0F }, new float[] { 0.95F, 0.7F, 0.2F }, new float[] { 0.9F, 0.5F, 0.85F
			 }, new float[] { 0.6F, 0.7F, 0.95F }, new float[] { 0.9F, 0.9F, 0.2F }, new float
			[] { 0.5F, 0.8F, 0.1F }, new float[] { 0.95F, 0.7F, 0.8F }, new float[] { 0.3F, 
			0.3F, 0.3F }, new float[] { 0.6F, 0.6F, 0.6F }, new float[] { 0.3F, 0.6F, 0.7F }
			, new float[] { 0.7F, 0.4F, 0.9F }, new float[] { 0.2F, 0.4F, 0.8F }, new float[
			] { 0.5F, 0.4F, 0.3F }, new float[] { 0.4F, 0.5F, 0.2F }, new float[] { 0.8F, 0.3F
			, 0.3F }, new float[] { 0.1F, 0.1F, 0.1F } };
	}
}
