// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public interface ISaveFormat
	{
		// Referenced classes of package net.minecraft.src:
		//            IProgressUpdate
		bool IsOldSaveType(string s);

		bool ConverMapToMCRegion(string s, net.minecraft.src.IProgressUpdate iprogressupdate
			);
	}
}
