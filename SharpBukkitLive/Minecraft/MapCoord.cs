// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class MapCoord
	{
		public MapCoord(net.minecraft.src.MapData mapdata, byte byte0, byte byte1, byte byte2
			, byte byte3)
		{
			// Referenced classes of package net.minecraft.src:
			//            MapData
			//        super();
			field_28203_e = mapdata;
			field_28202_a = byte0;
			field_28201_b = byte1;
			field_28205_c = byte2;
			field_28204_d = byte3;
		}

		public byte field_28202_a;

		public byte field_28201_b;

		public byte field_28205_c;

		public byte field_28204_d;

		internal readonly net.minecraft.src.MapData field_28203_e;
 /* synthetic field */
	}
}
