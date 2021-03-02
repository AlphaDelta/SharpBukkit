// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public abstract class WorldProvider
	{
		public WorldProvider()
		{
			// Referenced classes of package net.minecraft.src:
			//            WorldChunkManager, ChunkProviderGenerate, World, Block, 
			//            WorldProviderHell, WorldProviderSurface, WorldProviderSky, IChunkProvider
			field_6167_c = false;
			isHellWorld = false;
			field_4306_c = false;
			lightBrightnessTable = new float[16];
			worldType = 0;
			field_6164_h = new float[4];
		}

		public void RegisterWorld(net.minecraft.src.World world)
		{
			worldObj = world;
			RegisterWorldChunkManager();
			GenerateLightBrightnessTable();
		}

		protected internal virtual void GenerateLightBrightnessTable()
		{
			float f = 0.05F;
			for (int i = 0; i <= 15; i++)
			{
				float f1 = 1.0F - (float)i / 15F;
				lightBrightnessTable[i] = ((1.0F - f1) / (f1 * 3F + 1.0F)) * (1.0F - f) + f;
			}
		}

		protected internal virtual void RegisterWorldChunkManager()
		{
			worldChunkMgr = new net.minecraft.src.WorldChunkManager(worldObj);
		}

		public virtual net.minecraft.src.IChunkProvider GetChunkProvider()
		{
			return new net.minecraft.src.ChunkProviderGenerate(worldObj, worldObj.GetRandomSeed());
		}

		public virtual bool CanCoordinateBeSpawn(int i, int j)
		{
			int k = worldObj.GetFirstUncoveredBlock(i, j);
			return k == net.minecraft.src.Block.SAND.ID;
		}

		public virtual float CalculateCelestialAngle(long l, float f)
		{
			int i = (int)(l % 24000L);
			float f1 = ((float)i + f) / 24000F - 0.25F;
			if (f1 < 0.0F)
			{
				f1++;
			}
			if (f1 > 1.0F)
			{
				f1--;
			}
			float f2 = f1;
			f1 = 1.0F - (float)((System.Math.Cos((double)f1 * 3.1415926535897931D) + 1.0D) / 
				2D);
			f1 = f2 + (f1 - f2) / 3F;
			return f1;
		}

		public virtual bool Func_28108_d()
		{
			return true;
		}

		public static net.minecraft.src.WorldProvider Func_4091_a(int i)
		{
			if (i == -1)
			{
				return new net.minecraft.src.WorldProviderHell();
			}
			if (i == 0)
			{
				return new net.minecraft.src.WorldProviderSurface();
			}
			if (i == 1)
			{
				return new net.minecraft.src.WorldProviderSky();
			}
			else
			{
				return null;
			}
		}

		public net.minecraft.src.World worldObj;

		public net.minecraft.src.WorldChunkManager worldChunkMgr;

		public bool field_6167_c;

		public bool isHellWorld;

		public bool field_4306_c;

		public float[] lightBrightnessTable;

		public int worldType;

		private float[] field_6164_h;
	}
}
