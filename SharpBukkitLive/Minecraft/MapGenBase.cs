// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class MapGenBase
	{
		public MapGenBase()
		{
			// Referenced classes of package net.minecraft.src:
			//            World, IChunkProvider
			field_947_a = 8;
			rand = new SharpBukkitLive.SharpBukkit.SharpRandom();
		}

		public virtual void Func_667_a(net.minecraft.src.IChunkProvider ichunkprovider, net.minecraft.src.World
			 world, int i, int j, byte[] abyte0)
		{
			int k = field_947_a;
			rand.SetSeed(world.GetRandomSeed());
			long l = (rand.NextLong() / 2L) * 2L + 1L;
			long l1 = (rand.NextLong() / 2L) * 2L + 1L;
			for (int i1 = i - k; i1 <= i + k; i1++)
			{
				for (int j1 = j - k; j1 <= j + k; j1++)
				{
					rand.SetSeed((long)i1 * l + (long)j1 * l1 ^ world.GetRandomSeed());
					Func_666_a(world, i1, j1, i, j, abyte0);
				}
			}
		}

		protected internal virtual void Func_666_a(net.minecraft.src.World world, int i, 
			int j, int k, int l, byte[] abyte0)
		{
		}

		protected internal int field_947_a;

		protected internal SharpBukkitLive.SharpBukkit.SharpRandom rand;
	}
}
