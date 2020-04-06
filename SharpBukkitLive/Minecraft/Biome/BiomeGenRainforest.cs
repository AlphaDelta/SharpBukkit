// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System;

namespace net.minecraft.src
{
	public class BiomeGenRainforest : net.minecraft.src.BiomeGenBase
	{
		public BiomeGenRainforest()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            BiomeGenBase, WorldGenBigTree, WorldGenTrees, WorldGenerator
		public override net.minecraft.src.WorldGenerator GetRandomWorldGenForTrees(SharpRandom random)
		{
			if (random.Next(3) == 0)
			{
				return new net.minecraft.src.WorldGenBigTree();
			}
			else
			{
				return new net.minecraft.src.WorldGenTrees();
			}
		}
	}
}
