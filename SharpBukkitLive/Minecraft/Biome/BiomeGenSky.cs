// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BiomeGenSky : net.minecraft.src.BiomeGenBase
	{
		public BiomeGenSky()
		{
			// Referenced classes of package net.minecraft.src:
			//            BiomeGenBase, SpawnListEntry, EntityChicken
			spawnableMonsterList.Clear();
			spawnableCreatureList.Clear();
			spawnableWaterCreatureList.Clear();
			spawnableCreatureList.Add(new net.minecraft.src.SpawnListEntry(Sharpen.Runtime.GetClassForType
				(typeof(net.minecraft.src.EntityChicken)), 10));
		}
	}
}
