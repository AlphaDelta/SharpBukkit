// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class MaterialTransparent : net.minecraft.src.Material
	{
		public MaterialTransparent(net.minecraft.src.MapColor mapcolor)
			: base(mapcolor)
		{
			// Referenced classes of package net.minecraft.src:
			//            Material, MapColor
			Func_27089_f();
		}

		public override bool IsSolid()
		{
			return false;
		}

		public override bool GetCanBlockGrass()
		{
			return false;
		}

		public override bool GetIsSolid()
		{
			return false;
		}
	}
}
