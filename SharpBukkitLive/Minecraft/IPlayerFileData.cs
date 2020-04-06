// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public interface IPlayerFileData
	{
		// Referenced classes of package net.minecraft.src:
		//            EntityPlayer
		void WritePlayerData(net.minecraft.src.EntityPlayer entityplayer);

		void ReadPlayerData(net.minecraft.src.EntityPlayer entityplayer);
	}
}
