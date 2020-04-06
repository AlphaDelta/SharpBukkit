// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public interface IChunkLoader
	{
		// Referenced classes of package net.minecraft.src:
		//            World, Chunk
		/// <exception cref="System.IO.IOException"/>
		net.minecraft.src.Chunk LoadChunk(net.minecraft.src.World world, int i, int j);

		/// <exception cref="System.IO.IOException"/>
		void SaveChunk(net.minecraft.src.World world, net.minecraft.src.Chunk chunk);

		/// <exception cref="System.IO.IOException"/>
		void SaveExtraChunkData(net.minecraft.src.World world, net.minecraft.src.Chunk chunk
			);

		void Func_661_a();

		void SaveExtraData();
	}
}
