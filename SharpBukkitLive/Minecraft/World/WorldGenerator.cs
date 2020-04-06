// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public abstract class WorldGenerator
	{
		public WorldGenerator()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            World
		public abstract bool Generate(net.minecraft.src.World world, SharpBukkitLive.SharpBukkit.SharpRandom random
			, int i, int j, int k);

		public virtual void Func_420_a(double d, double d1, double d2)
		{
		}
	}
}
