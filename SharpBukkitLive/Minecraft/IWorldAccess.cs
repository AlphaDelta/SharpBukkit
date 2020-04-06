// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public interface IWorldAccess
	{
		// Referenced classes of package net.minecraft.src:
		//            Entity, TileEntity, EntityPlayer
		void MarkBlockNeedsUpdate(int i, int j, int k);

		void MarkBlockRangeNeedsUpdate(int i, int j, int k, int l, int i1, int j1);

		void PlaySound(string s, double d, double d1, double d2, float f, float f1);

		void SpawnParticle(string s, double d, double d1, double d2, double d3, double d4
			, double d5);

		void ObtainEntitySkin(net.minecraft.src.Entity entity);

		void ReleaseEntitySkin(net.minecraft.src.Entity entity);

		void UpdateAllRenderers();

		void PlayRecord(string s, int i, int j, int k);

		void DoNothingWithTileEntity(int i, int j, int k, net.minecraft.src.TileEntity tileentity
			);

		void Func_28133_a(net.minecraft.src.EntityPlayer entityplayer, int i, int j, int 
			k, int l, int i1);
	}
}
