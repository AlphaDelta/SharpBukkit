// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ChunkBlockMap
	{
		public ChunkBlockMap()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            Block
		public static void Func_26001_a(byte[] abyte0)
		{
			for (int i = 0; i < abyte0.Length; i++)
			{
				abyte0[i] = field_26002_a[abyte0[i]];
			}
		}

		private static byte[] field_26002_a;

		static ChunkBlockMap()
		{
			field_26002_a = new byte[256];
			try
			{
				for (int i = 0; i < 256; i++)
				{
					byte byte0 = unchecked((byte)i);
					if (byte0 != 0 && net.minecraft.src.Block.blocksList[byte0] == null)
					{
						byte0 = 0;
					}
					field_26002_a[i] = byte0;
				}
			}
			catch (System.Exception exception)
			{
				Sharpen.Runtime.PrintStackTrace(exception);
			}
		}
	}
}
