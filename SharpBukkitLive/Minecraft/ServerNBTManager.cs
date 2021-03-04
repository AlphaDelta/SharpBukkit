// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class ServerNBTManager : net.minecraft.src.PlayerNBTManager
	{
		public ServerNBTManager(string file, string s, bool flag)
			: base(file, s, flag)
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            PlayerNBTManager, WorldProviderHell, McRegionChunkLoader, WorldInfo, 
		//            RegionFileCache, WorldProvider, IChunkLoader
		public override net.minecraft.src.IChunkLoader Func_22092_a(net.minecraft.src.WorldProvider
			 worldprovider)
		{
			string file = GetWorldDir();
			if (worldprovider is net.minecraft.src.WorldProviderHell)
			{
				string file1 = System.IO.Path.Combine(file, "DIM-1");
				System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(file1));
				//file1.Mkdirs();
				return new net.minecraft.src.McRegionChunkLoader(file1);
			}
			else
			{
				return new net.minecraft.src.McRegionChunkLoader(file);
			}
		}

		public override void Func_22095_a(net.minecraft.src.WorldInfo worldinfo, List<EntityPlayer> list)
		{
			worldinfo.SetVersion(19132);
			base.Func_22095_a(worldinfo, list);
		}

		public override void Func_22093_e()
		{
			net.minecraft.src.RegionFileCache.Func_22122_a();
		}
	}
}
