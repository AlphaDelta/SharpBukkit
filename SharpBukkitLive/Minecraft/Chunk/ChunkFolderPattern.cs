// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Text.RegularExpressions;

namespace net.minecraft.src
{
	internal class ChunkFolderPattern// : java.io.FileFilter
	{
		private ChunkFolderPattern()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Empty2
		//public virtual bool Accept(java.io.File file)
		//{
		//	if (file.IsDirectory())
		//	{
		//		java.util.regex.Matcher matcher = field_22214_a.Matcher(file.GetName());
		//		return matcher.Matches();
		//	}
		//	else
		//	{
		//		return false;
		//	}
		//}

		//internal ChunkFolderPattern(net.minecraft.src.Empty2 empty2)
		//	: this()
		//{
		//}

		public static readonly Regex field_22214_a = new Regex("[0-9a-z]|([0-9a-z][0-9a-z])", RegexOptions.Compiled);
	}
}
