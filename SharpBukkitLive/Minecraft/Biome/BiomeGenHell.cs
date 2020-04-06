// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BiomeGenHell : net.minecraft.src.BiomeGenBase
	{
		public BiomeGenHell()
		{
			// Referenced classes of package net.minecraft.src:
			//            BiomeGenBase, SpawnListEntry, EntityGhast, EntityPigZombie
			spawnableMonsterList.Clear();
			spawnableCreatureList.Clear();
			spawnableWaterCreatureList.Clear();
			spawnableMonsterList.Add(new net.minecraft.src.SpawnListEntry(Sharpen.Runtime.GetClassForType
				(typeof(net.minecraft.src.EntityGhast)), 10));
			spawnableMonsterList.Add(new net.minecraft.src.SpawnListEntry(Sharpen.Runtime.GetClassForType
				(typeof(net.minecraft.src.EntityPigZombie)), 10));
		}
	}
}
