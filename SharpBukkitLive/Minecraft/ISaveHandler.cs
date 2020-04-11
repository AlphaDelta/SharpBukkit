// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public interface ISaveHandler
	{
		// Referenced classes of package net.minecraft.src:
		//            WorldInfo, WorldProvider, IChunkLoader, IPlayerFileData
		net.minecraft.src.WorldInfo Func_22096_c();

		void Func_22091_b();

		net.minecraft.src.IChunkLoader Func_22092_a(net.minecraft.src.WorldProvider worldprovider);

		void Func_22095_a(net.minecraft.src.WorldInfo worldinfo, List<EntityPlayer> list);

		void Func_22094_a(net.minecraft.src.WorldInfo worldinfo);

		net.minecraft.src.IPlayerFileData Func_22090_d();

		void Func_22093_e();

		string Func_28111_b(string s);
	}
}
