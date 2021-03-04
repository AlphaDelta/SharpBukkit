// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ItemMap : net.minecraft.src.ItemMapBase
	{
		protected internal ItemMap(int i)
			: base(i)
		{
			// Referenced classes of package net.minecraft.src:
			//            ItemMapBase, ItemStack, MapData, World, 
			//            WorldInfo, WorldProvider, Entity, MathHelper, 
			//            Block, Chunk, Material, MapColor, 
			//            EntityPlayer, Packet131MapData, Item, Packet
			SetMaxStackSize(1);
		}

		public virtual net.minecraft.src.MapData Func_28023_a(net.minecraft.src.ItemStack
			 itemstack, net.minecraft.src.World world)
		{
			string s = (new java.lang.StringBuilder()).Append("map_").Append(itemstack.GetItemDamage
				()).ToString();
			net.minecraft.src.MapData mapdata = (net.minecraft.src.MapData)world.Func_28103_a
				(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.MapData)), (new java.lang.StringBuilder
				()).Append("map_").Append(itemstack.GetItemDamage()).ToString());
			if (mapdata == null)
			{
				itemstack.SetItemDamage(world.Func_28104_b("map"));
				string s1 = (new java.lang.StringBuilder()).Append("map_").Append(itemstack.GetItemDamage
					()).ToString();
				mapdata = new net.minecraft.src.MapData(s1);
				mapdata.field_28164_b = world.GetWorldInfo().GetSpawnX();
				mapdata.field_28163_c = world.GetWorldInfo().GetSpawnZ();
				mapdata.field_28161_e = 3;
				mapdata.field_28162_d = unchecked((byte)world.worldProvider.worldType);
				mapdata.Func_28146_a();
				world.Func_28102_a(s1, mapdata);
			}
			return mapdata;
		}

		public virtual void Func_28024_a(net.minecraft.src.World world, net.minecraft.src.Entity
			 entity, net.minecraft.src.MapData mapdata)
		{
			if (world.worldProvider.worldType != mapdata.field_28162_d)
			{
				return;
			}
			short c = 128;//'\200';
			short c1 = 128;//'\200';
			int i = 1 << mapdata.field_28161_e;
			int j = mapdata.field_28164_b;
			int k = mapdata.field_28163_c;
			int l = net.minecraft.src.MathHelper.Floor_double(entity.posX - (double)j) / i + 
				c / 2;
			int i1 = net.minecraft.src.MathHelper.Floor_double(entity.posZ - (double)k) / i +
				 c1 / 2;
			int j1 = 128 / i;
			if (world.worldProvider.worldHasSky)
			{
				j1 /= 2;
			}
			mapdata.field_28159_g++;
			for (int k1 = (l - j1) + 1; k1 < l + j1; k1++)
			{
				if ((k1 & 0xf) != (mapdata.field_28159_g & 0xf))
				{
					continue;
				}
				int l1 = 255;
				int i2 = 0;
				double d = 0.0D;
				for (int j2 = i1 - j1 - 1; j2 < i1 + j1; j2++)
				{
					if (k1 < 0 || j2 < -1 || k1 >= c || j2 >= c1)
					{
						continue;
					}
					int k2 = k1 - l;
					int l2 = j2 - i1;
					bool flag = k2 * k2 + l2 * l2 > (j1 - 2) * (j1 - 2);
					int i3 = ((j / i + k1) - c / 2) * i;
					int j3 = ((k / i + j2) - c1 / 2) * i;
					int k3 = 0;
					int l3 = 0;
					int i4 = 0;
					int[] ai = new int[256];
					net.minecraft.src.Chunk chunk = world.GetChunkFromBlockCoords(i3, j3);
					int j4 = i3 & 0xf;
					int k4 = j3 & 0xf;
					int l4 = 0;
					double d1 = 0.0D;
					if (world.worldProvider.worldHasSky)
					{
						int i5 = i3 + j3 * 0x389bf;
						i5 = i5 * i5 * 0x1dd6751 + i5 * 11;
						if ((i5 >> 20 & 1) == 0)
						{
							ai[net.minecraft.src.Block.DIRT.ID] += 10;
						}
						else
						{
							ai[net.minecraft.src.Block.STONE.ID] += 10;
						}
						d1 = 100D;
					}
					else
					{
						for (int j5 = 0; j5 < i; j5++)
						{
							for (int l5 = 0; l5 < i; l5++)
							{
								int j6 = chunk.GetHeightValue(j5 + j4, l5 + k4) + 1;
								int l6 = 0;
								if (j6 > 1)
								{
									bool flag1 = false;
									do
									{
										flag1 = true;
										l6 = chunk.GetBlockID(j5 + j4, j6 - 1, l5 + k4);
										if (l6 == 0)
										{
											flag1 = false;
										}
										else
										{
											if (j6 > 0 && l6 > 0 && net.minecraft.src.Block.blocksList[l6].blockMaterial.field_28131_A
												 == net.minecraft.src.MapColor.field_28199_b)
											{
												flag1 = false;
											}
										}
										if (!flag1)
										{
											j6--;
											l6 = chunk.GetBlockID(j5 + j4, j6 - 1, l5 + k4);
										}
									}
									while (!flag1);
									if (l6 != 0 && net.minecraft.src.Block.blocksList[l6].blockMaterial.GetIsLiquid())
									{
										int i7 = j6 - 1;
										int k7 = 0;
										do
										{
											k7 = chunk.GetBlockID(j5 + j4, i7--, l5 + k4);
											l4++;
										}
										while (i7 > 0 && k7 != 0 && net.minecraft.src.Block.blocksList[k7].blockMaterial.
											GetIsLiquid());
									}
								}
								d1 += (double)j6 / (double)(i * i);
								ai[l6]++;
							}
						}
					}
					l4 /= i * i;
					k3 /= i * i;
					l3 /= i * i;
					i4 /= i * i;
					int k5 = 0;
					int i6 = 0;
					for (int k6 = 0; k6 < 256; k6++)
					{
						if (ai[k6] > k5)
						{
							i6 = k6;
							k5 = ai[k6];
						}
					}
					double d2 = ((d1 - d) * 4D) / (double)(i + 4) + ((double)(k1 + j2 & 1) - 0.5D) * 
						0.40000000000000002D;
					byte byte0 = 1;
					if (d2 > 0.59999999999999998D)
					{
						byte0 = 2;
					}
					if (d2 < -0.59999999999999998D)
					{
						byte0 = 0;
					}
					int j7 = 0;
					if (i6 > 0)
					{
						net.minecraft.src.MapColor mapcolor = net.minecraft.src.Block.blocksList[i6].blockMaterial
							.field_28131_A;
						if (mapcolor == net.minecraft.src.MapColor.field_28187_n)
						{
							double d3 = (double)l4 * 0.10000000000000001D + (double)(k1 + j2 & 1) * 0.20000000000000001D;
							byte0 = 1;
							if (d3 < 0.5D)
							{
								byte0 = 2;
							}
							if (d3 > 0.90000000000000002D)
							{
								byte0 = 0;
							}
						}
						j7 = mapcolor.field_28184_q;
					}
					d = d1;
					if (j2 < 0 || k2 * k2 + l2 * l2 >= j1 * j1 || flag && (k1 + j2 & 1) == 0)
					{
						continue;
					}
					byte byte1 = mapdata.field_28160_f[k1 + j2 * c];
					byte byte2 = unchecked((byte)(j7 * 4 + byte0));
					if (byte1 == byte2)
					{
						continue;
					}
					if (l1 > j2)
					{
						l1 = j2;
					}
					if (i2 < j2)
					{
						i2 = j2;
					}
					mapdata.field_28160_f[k1 + j2 * c] = byte2;
				}
				if (l1 <= i2)
				{
					mapdata.Func_28153_a(k1, l1, i2);
				}
			}
		}

		public override void Func_28018_a(net.minecraft.src.ItemStack itemstack, net.minecraft.src.World
			 world, net.minecraft.src.Entity entity, int i, bool flag)
		{
			if (world.singleplayerWorld)
			{
				return;
			}
			net.minecraft.src.MapData mapdata = Func_28023_a(itemstack, world);
			if (entity is net.minecraft.src.EntityPlayer)
			{
				net.minecraft.src.EntityPlayer entityplayer = (net.minecraft.src.EntityPlayer)entity;
				mapdata.Func_28155_a(entityplayer, itemstack);
			}
			if (flag)
			{
				Func_28024_a(world, entity, mapdata);
			}
		}

		public override void Func_28020_c(net.minecraft.src.ItemStack itemstack, net.minecraft.src.World
			 world, net.minecraft.src.EntityPlayer entityplayer)
		{
			itemstack.SetItemDamage(world.Func_28104_b("map"));
			string s = (new java.lang.StringBuilder()).Append("map_").Append(itemstack.GetItemDamage
				()).ToString();
			net.minecraft.src.MapData mapdata = new net.minecraft.src.MapData(s);
			world.Func_28102_a(s, mapdata);
			mapdata.field_28164_b = net.minecraft.src.MathHelper.Floor_double(entityplayer.posX
				);
			mapdata.field_28163_c = net.minecraft.src.MathHelper.Floor_double(entityplayer.posZ
				);
			mapdata.field_28161_e = 3;
			mapdata.field_28162_d = unchecked((byte)world.worldProvider.worldType);
			mapdata.Func_28146_a();
		}

		public override net.minecraft.src.Packet Func_28022_b(net.minecraft.src.ItemStack
			 itemstack, net.minecraft.src.World world, net.minecraft.src.EntityPlayer entityplayer
			)
		{
			byte[] abyte0 = Func_28023_a(itemstack, world).Func_28154_a(itemstack, world, entityplayer
				);
			if (abyte0 == null)
			{
				return null;
			}
			else
			{
				return new net.minecraft.src.Packet131MapData((short)net.minecraft.src.Item.MAP
					.ID, (short)itemstack.GetItemDamage(), abyte0);
			}
		}
	}
}
