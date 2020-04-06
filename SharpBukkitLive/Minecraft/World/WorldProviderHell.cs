// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WorldProviderHell : net.minecraft.src.WorldProvider
	{
		public WorldProviderHell()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            WorldProvider, WorldChunkManagerHell, BiomeGenBase, ChunkProviderHell, 
		//            World, Block, IChunkProvider
		protected internal override void RegisterWorldChunkManager()
		{
			worldChunkMgr = new net.minecraft.src.WorldChunkManagerHell(net.minecraft.src.BiomeGenBase
				.hell, 1.0D, 0.0D);
			field_6167_c = true;
			isHellWorld = true;
			field_4306_c = true;
			worldType = -1;
		}

		protected internal override void GenerateLightBrightnessTable()
		{
			float f = 0.1F;
			for (int i = 0; i <= 15; i++)
			{
				float f1 = 1.0F - (float)i / 15F;
				lightBrightnessTable[i] = ((1.0F - f1) / (f1 * 3F + 1.0F)) * (1.0F - f) + f;
			}
		}

		public override net.minecraft.src.IChunkProvider GetChunkProvider()
		{
			return new net.minecraft.src.ChunkProviderHell(worldObj, worldObj.GetRandomSeed()
				);
		}

		public override bool CanCoordinateBeSpawn(int i, int j)
		{
			int k = worldObj.GetFirstUncoveredBlock(i, j);
			if (k == net.minecraft.src.Block.bedrock.blockID)
			{
				return false;
			}
			if (k == 0)
			{
				return false;
			}
			return net.minecraft.src.Block.opaqueCubeLookup[k];
		}

		public override float CalculateCelestialAngle(long l, float f)
		{
			return 0.5F;
		}

		public override bool Func_28108_d()
		{
			return false;
		}
	}
}
