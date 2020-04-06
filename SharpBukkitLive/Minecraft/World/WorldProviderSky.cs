// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldProviderSky : net.minecraft.src.WorldProvider
	{
		public WorldProviderSky()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            WorldProvider, WorldChunkManagerHell, BiomeGenBase, ChunkProviderSky, 
		//            World, Block, Material, IChunkProvider
		protected internal override void RegisterWorldChunkManager()
		{
			worldChunkMgr = new net.minecraft.src.WorldChunkManagerHell(net.minecraft.src.BiomeGenBase
				.field_28054_m, 0.5D, 0.0D);
			worldType = 1;
		}

		public override net.minecraft.src.IChunkProvider GetChunkProvider()
		{
			return new net.minecraft.src.ChunkProviderSky(worldObj, worldObj.GetRandomSeed());
		}

		public override float CalculateCelestialAngle(long l, float f)
		{
			return 0.0F;
		}

		public override bool CanCoordinateBeSpawn(int i, int j)
		{
			int k = worldObj.GetFirstUncoveredBlock(i, j);
			if (k == 0)
			{
				return false;
			}
			else
			{
				return net.minecraft.src.Block.blocksList[k].blockMaterial.GetIsSolid();
			}
		}
	}
}
