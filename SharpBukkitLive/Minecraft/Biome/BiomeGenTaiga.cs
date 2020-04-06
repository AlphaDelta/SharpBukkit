// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System;

namespace net.minecraft.src
{
	public class BiomeGenTaiga : net.minecraft.src.BiomeGenBase
	{
		public BiomeGenTaiga()
		{
			// Referenced classes of package net.minecraft.src:
			//            BiomeGenBase, SpawnListEntry, EntityWolf, WorldGenTaiga1, 
			//            WorldGenTaiga2, WorldGenerator
			spawnableCreatureList.Add(new net.minecraft.src.SpawnListEntry(Sharpen.Runtime.GetClassForType
				(typeof(net.minecraft.src.EntityWolf)), 2));
		}

		public override net.minecraft.src.WorldGenerator GetRandomWorldGenForTrees(SharpRandom random)
		{
			if (random.Next(3) == 0)
			{
				return new net.minecraft.src.WorldGenTaiga1();
			}
			else
			{
				return new net.minecraft.src.WorldGenTaiga2();
			}
		}
	}
}
