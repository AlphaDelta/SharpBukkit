// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.IO;

namespace net.minecraft.src
{
	internal class RegionFileChunkBuffer : MemoryStream
	{
		public RegionFileChunkBuffer(net.minecraft.src.RegionFile regionfile, int i, int 
			j)
			//: base(8096)
		{
			// Referenced classes of package net.minecraft.src:
			//            RegionFile
			field_22157_a = regionfile;
			field_22156_b = i;
			field_22158_c = j;
		}

		public override void Close()
		{
			byte[] buf = this.GetBuffer();
			field_22157_a.Write(field_22156_b, field_22158_c, buf, buf.Length);
			base.Close();
		}

		private int field_22156_b;

		private int field_22158_c;

		internal readonly net.minecraft.src.RegionFile field_22157_a;
 /* synthetic field */
	}
}
