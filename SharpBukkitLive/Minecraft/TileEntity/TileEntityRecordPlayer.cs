// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class TileEntityRecordPlayer : net.minecraft.src.TileEntity
	{
		public TileEntityRecordPlayer()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            TileEntity, NBTTagCompound
		public override void ReadFromNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.ReadFromNBT(nbttagcompound);
			field_28009_a = nbttagcompound.GetInteger("Record");
		}

		public override void WriteToNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.WriteToNBT(nbttagcompound);
			if (field_28009_a > 0)
			{
				nbttagcompound.SetInteger("Record", field_28009_a);
			}
		}

		public int field_28009_a;
	}
}
