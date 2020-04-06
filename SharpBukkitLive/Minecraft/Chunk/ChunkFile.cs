// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System;

namespace net.minecraft.src
{
	internal class ChunkFile : IComparable
	{
		public ChunkFile(string file)
		{
			// Referenced classes of package net.minecraft.src:
			//            ChunkFilePattern
			field_22209_a = file;
			//java.util.regex.Matcher matcher = net.minecraft.src.ChunkFilePattern.field_22119_a
			//	.Matcher(file.GetName());
			var m = ChunkFilePattern.field_22119_a.Match(file);
			if (m.Success)
			{
				field_22208_b = (int)Base36.Decode(m.Groups[1].Value);
				field_22210_c = (int)Base36.Decode(m.Groups[2].Value);
			}
			else
			{
				field_22208_b = 0;
				field_22210_c = 0;
			}
		}

		public virtual int Func_22206_a(net.minecraft.src.ChunkFile chunkfile)
		{
			int i = field_22208_b >> 5;
			int j = chunkfile.field_22208_b >> 5;
			if (i == j)
			{
				int k = field_22210_c >> 5;
				int l = chunkfile.field_22210_c >> 5;
				return k - l;
			}
			else
			{
				return i - j;
			}
		}

		public virtual string Func_22207_a()
		{
			return field_22209_a;
		}

		public virtual int Func_22205_b()
		{
			return field_22208_b;
		}

		public virtual int Func_22204_c()
		{
			return field_22210_c;
		}

		public virtual int CompareTo(object obj)
		{
			return Func_22206_a((net.minecraft.src.ChunkFile)obj);
		}

		private readonly string field_22209_a;

		private readonly int field_22208_b;

		private readonly int field_22210_c;
	}
}
