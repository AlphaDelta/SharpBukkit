// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public interface IChunkProvider
	{
		// Referenced classes of package net.minecraft.src:
		//            Chunk, IProgressUpdate
		bool ChunkExists(int i, int j);

		net.minecraft.src.Chunk ProvideChunk(int i, int j);

		net.minecraft.src.Chunk LoadChunk(int i, int j);

		void Populate(net.minecraft.src.IChunkProvider ichunkprovider, int i, int j);

		bool SaveChunks(bool flag, net.minecraft.src.IProgressUpdate iprogressupdate);

		bool Func_361_a();

		bool CanSave();
	}
}
