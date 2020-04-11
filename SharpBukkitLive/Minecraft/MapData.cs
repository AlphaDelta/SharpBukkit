// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;
using System.Linq;

namespace net.minecraft.src
{
	public class MapData : net.minecraft.src.MapDataBase
	{
		public MapData(string s)
			: base(s)
		{
			// Referenced classes of package net.minecraft.src:
			//            MapDataBase, NBTTagCompound, MapInfo, EntityPlayer, 
			//            InventoryPlayer, MapCoord, ItemStack, World
			field_28160_f = new byte[16384];
			field_28158_h = new List<MapInfo>();
			field_28156_j = new SharpBukkitLive.NullSafeDictionary<EntityPlayer, MapInfo>();
			field_28157_i = new List<MapCoord>();
		}

		public override void Func_28148_a(net.minecraft.src.NBTTagCompound nbttagcompound
			)
		{
			field_28162_d = nbttagcompound.GetByte("dimension");
			field_28164_b = nbttagcompound.GetInteger("xCenter");
			field_28163_c = nbttagcompound.GetInteger("zCenter");
			field_28161_e = nbttagcompound.GetByte("scale");
			if (((sbyte)field_28161_e) < 0)
			{
				field_28161_e = 0;
			}
			if (field_28161_e > 4)
			{
				field_28161_e = 4;
			}
			short word0 = nbttagcompound.GetShort("width");
			short word1 = nbttagcompound.GetShort("height");
			if (word0 == 128 && word1 == 128)
			{
				field_28160_f = nbttagcompound.GetByteArray("colors");
			}
			else
			{
				byte[] abyte0 = nbttagcompound.GetByteArray("colors");
				field_28160_f = new byte[16384];
				int i = (128 - word0) / 2;
				int j = (128 - word1) / 2;
				for (int k = 0; k < word1; k++)
				{
					int l = k + j;
					if (l < 0 && l >= 128)
					{
						continue;
					}
					for (int i1 = 0; i1 < word0; i1++)
					{
						int j1 = i1 + i;
						if (j1 >= 0 || j1 < 128)
						{
							field_28160_f[j1 + l * 128] = abyte0[i1 + k * word0];
						}
					}
				}
			}
		}

		public override void Func_28147_b(net.minecraft.src.NBTTagCompound nbttagcompound
			)
		{
			nbttagcompound.SetByte("dimension", field_28162_d);
			nbttagcompound.SetInteger("xCenter", field_28164_b);
			nbttagcompound.SetInteger("zCenter", field_28163_c);
			nbttagcompound.SetByte("scale", field_28161_e);
			nbttagcompound.SetShort("width", (short)128);
			nbttagcompound.SetShort("height", (short)128);
			nbttagcompound.SetByteArray("colors", field_28160_f);
		}

		public virtual void Func_28155_a(net.minecraft.src.EntityPlayer entityplayer, net.minecraft.src.ItemStack
			 itemstack)
		{
			if (!field_28156_j.ContainsKey(entityplayer))
			{
				net.minecraft.src.MapInfo mapinfo = new net.minecraft.src.MapInfo(this, entityplayer
					);
				field_28156_j[entityplayer] = mapinfo;
				field_28158_h.Add(mapinfo);
			}
			field_28157_i.Clear();
			for (int i = 0; i < field_28158_h.Count; i++)
			{
				net.minecraft.src.MapInfo mapinfo1 = (net.minecraft.src.MapInfo)field_28158_h[i];
				if (mapinfo1.player.isDead || !mapinfo1.player.inventory.Func_28010_c
					(itemstack))
				{
					field_28156_j.Remove(mapinfo1.player);
					field_28158_h.Remove(mapinfo1);
					continue;
				}
				float f = (float)(mapinfo1.player.posX - (double)field_28164_b) / (float)(
					1 << field_28161_e);
				float f1 = (float)(mapinfo1.player.posZ - (double)field_28163_c) / (float)
					(1 << field_28161_e);
				int j = 64;
				int k = 64;
				if (f < (float)(-j) || f1 < (float)(-k) || f > (float)j || f1 > (float)k)
				{
					continue;
				}
				byte byte0 = 0;
				byte byte1 = unchecked((byte)(int)((double)(f * 2.0F) + 0.5D));
				byte byte2 = unchecked((byte)(int)((double)(f1 * 2.0F) + 0.5D));
				byte byte3 = unchecked((byte)(int)((double)((entityplayer.rotationYaw * 16F) / 360F
					) + 0.5D));
				if (((sbyte)field_28162_d) < 0)
				{
					int l = field_28159_g / 10;
					byte3 = unchecked((byte)(l * l * unchecked((int)(0x209a771)) + l * 121 >> 15 & unchecked(
						(int)(0xf))));
				}
				if (mapinfo1.player.dimension == field_28162_d)
				{
					field_28157_i.Add(new net.minecraft.src.MapCoord(this, byte0, byte1, byte2, byte3
						));
				}
			}
		}

		public virtual byte[] Func_28154_a(net.minecraft.src.ItemStack itemstack, net.minecraft.src.World
			 world, net.minecraft.src.EntityPlayer entityplayer)
		{
			net.minecraft.src.MapInfo mapinfo = (net.minecraft.src.MapInfo)field_28156_j[entityplayer
				];
			if (mapinfo == null)
			{
				return null;
			}
			else
			{
				byte[] abyte0 = mapinfo.Func_28118_a(itemstack);
				return abyte0;
			}
		}

		public virtual void Func_28153_a(int i, int j, int k)
		{
			base.Func_28146_a();
			for (int l = 0; l < field_28158_h.Count; l++)
			{
				net.minecraft.src.MapInfo mapinfo = (net.minecraft.src.MapInfo)field_28158_h[l];
				if (mapinfo.field_28119_b[i] < 0 || mapinfo.field_28119_b[i] > j)
				{
					mapinfo.field_28119_b[i] = j;
				}
				if (mapinfo.field_28125_c[i] < 0 || mapinfo.field_28125_c[i] < k)
				{
					mapinfo.field_28125_c[i] = k;
				}
			}
		}

		public int field_28164_b;

		public int field_28163_c;

		public byte field_28162_d;

		public byte field_28161_e;

		public byte[] field_28160_f;

		public int field_28159_g;

		public List<MapInfo> field_28158_h;

		private Dictionary<EntityPlayer, MapInfo> field_28156_j;

		public List<MapCoord> field_28157_i;
	}
}
