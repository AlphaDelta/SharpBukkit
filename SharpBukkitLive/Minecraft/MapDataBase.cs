// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public abstract class MapDataBase
	{
		public MapDataBase(string s)
		{
			// Referenced classes of package net.minecraft.src:
			//            NBTTagCompound
			field_28152_a = s;
		}

		public abstract void Func_28148_a(net.minecraft.src.NBTTagCompound nbttagcompound
			);

		public abstract void Func_28147_b(net.minecraft.src.NBTTagCompound nbttagcompound
			);

		public virtual void Func_28146_a()
		{
			Func_28149_a(true);
		}

		public virtual void Func_28149_a(bool flag)
		{
			field_28151_b = flag;
		}

		public virtual bool Func_28150_b()
		{
			return field_28151_b;
		}

		public readonly string field_28152_a;

		private bool field_28151_b;
	}
}
