// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public interface IBlockAccess
	{
		// Referenced classes of package net.minecraft.src:
		//            TileEntity, Material
		int GetBlockId(int i, int j, int k);

		net.minecraft.src.TileEntity GetBlockTileEntity(int i, int j, int k);

		int GetBlockMetadata(int i, int j, int k);

		net.minecraft.src.Material GetBlockMaterial(int i, int j, int k);

		bool IsBlockNormalCube(int i, int j, int k);
	}
}
