// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class TileEntityNote : net.minecraft.src.TileEntity
	{
		public TileEntityNote()
		{
			// Referenced classes of package net.minecraft.src:
			//            TileEntity, NBTTagCompound, World, Material
			note = 0;
			previousRedstoneState = false;
		}

		public override void WriteToNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.WriteToNBT(nbttagcompound);
			nbttagcompound.SetByte("note", note);
		}

		public override void ReadFromNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.ReadFromNBT(nbttagcompound);
			note = nbttagcompound.GetByte("note");
			if (((sbyte)note) < 0)
			{
				note = 0;
			}
			if (note > 24)
			{
				note = 24;
			}
		}

		public virtual void ChangePitch()
		{
			note = unchecked((byte)((note + 1) % 25));
			OnInventoryChanged();
		}

		public virtual void TriggerNote(net.minecraft.src.World world, int i, int j, int 
			k)
		{
			if (world.GetBlockMaterial(i, j + 1, k) != net.minecraft.src.Material.air)
			{
				return;
			}
			net.minecraft.src.Material material = world.GetBlockMaterial(i, j - 1, k);
			byte byte0 = 0;
			if (material == net.minecraft.src.Material.rock)
			{
				byte0 = 1;
			}
			if (material == net.minecraft.src.Material.sand)
			{
				byte0 = 2;
			}
			if (material == net.minecraft.src.Material.glass)
			{
				byte0 = 3;
			}
			if (material == net.minecraft.src.Material.wood)
			{
				byte0 = 4;
			}
			world.PlayNoteAt(i, j, k, byte0, note);
		}

		public byte note;

		public bool previousRedstoneState;
	}
}
