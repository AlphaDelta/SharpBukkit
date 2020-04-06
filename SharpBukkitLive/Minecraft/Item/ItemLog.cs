// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemLog : net.minecraft.src.ItemBlock
	{
		public ItemLog(int i)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            ItemBlock
			SetMaxDamage(0);
			SetHasSubtypes(true);
		}

		public override int GetMetadata(int i)
		{
			return i;
		}
	}
}
