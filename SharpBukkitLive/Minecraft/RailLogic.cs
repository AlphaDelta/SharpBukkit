// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	internal class RailLogic
	{
		public RailLogic(net.minecraft.src.BlockRail blockrail, net.minecraft.src.World world
			, int i, int j, int k)
		{
			// Referenced classes of package net.minecraft.src:
			//            World, Block, BlockRail, ChunkPosition
			//        super();
			minecartTrack = blockrail;
			connectedTracks = new List<ChunkPosition>();
			worldObj = world;
			trackX = i;
			trackY = j;
			trackZ = k;
			int l = world.GetBlockId(i, j, k);
			int i1 = world.GetBlockMetadata(i, j, k);
			if (net.minecraft.src.BlockRail.Func_27033_a((net.minecraft.src.BlockRail)net.minecraft.src.Block
				.blocksList[l]))
			{
				field_27084_f = true;
				i1 &= -9;
			}
			else
			{
				field_27084_f = false;
			}
			Func_27083_a(i1);
		}

		private void Func_27083_a(int i)
		{
			connectedTracks.Clear();
			if (i == 0)
			{
				connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX, trackY, trackZ - 
					1));
				connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX, trackY, trackZ + 
					1));
			}
			else
			{
				if (i == 1)
				{
					connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX - 1, trackY, trackZ
						));
					connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX + 1, trackY, trackZ
						));
				}
				else
				{
					if (i == 2)
					{
						connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX - 1, trackY, trackZ
							));
						connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX + 1, trackY + 1, trackZ
							));
					}
					else
					{
						if (i == 3)
						{
							connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX - 1, trackY + 1, trackZ
								));
							connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX + 1, trackY, trackZ
								));
						}
						else
						{
							if (i == 4)
							{
								connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX, trackY + 1, trackZ
									 - 1));
								connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX, trackY, trackZ + 
									1));
							}
							else
							{
								if (i == 5)
								{
									connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX, trackY, trackZ - 
										1));
									connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX, trackY + 1, trackZ
										 + 1));
								}
								else
								{
									if (i == 6)
									{
										connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX + 1, trackY, trackZ
											));
										connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX, trackY, trackZ + 
											1));
									}
									else
									{
										if (i == 7)
										{
											connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX - 1, trackY, trackZ
												));
											connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX, trackY, trackZ + 
												1));
										}
										else
										{
											if (i == 8)
											{
												connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX - 1, trackY, trackZ
													));
												connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX, trackY, trackZ - 
													1));
											}
											else
											{
												if (i == 9)
												{
													connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX + 1, trackY, trackZ
														));
													connectedTracks.Add(new net.minecraft.src.ChunkPosition(trackX, trackY, trackZ - 
														1));
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private void Func_591_b()
		{
			for (int i = 0; i < connectedTracks.Count; i++)
			{
				net.minecraft.src.RailLogic raillogic = GetMinecartTrackLogic((net.minecraft.src.ChunkPosition
					)connectedTracks[i]);
				if (raillogic == null || !raillogic.IsConnectedTo(this))
				{
					connectedTracks.RemoveAt(i--);
				}
				else
				{
					connectedTracks[i] = new net.minecraft.src.ChunkPosition(raillogic.trackX, raillogic.trackY, raillogic.trackZ);
				}
			}
		}

		private bool IsMinecartTrack(int i, int j, int k)
		{
			if (net.minecraft.src.BlockRail.Func_27029_g(worldObj, i, j, k))
			{
				return true;
			}
			if (net.minecraft.src.BlockRail.Func_27029_g(worldObj, i, j + 1, k))
			{
				return true;
			}
			return net.minecraft.src.BlockRail.Func_27029_g(worldObj, i, j - 1, k);
		}

		private net.minecraft.src.RailLogic GetMinecartTrackLogic(net.minecraft.src.ChunkPosition
			 chunkposition)
		{
			if (net.minecraft.src.BlockRail.Func_27029_g(worldObj, chunkposition.x, chunkposition
				.y, chunkposition.z))
			{
				return new net.minecraft.src.RailLogic(minecartTrack, worldObj, chunkposition.x, 
					chunkposition.y, chunkposition.z);
			}
			if (net.minecraft.src.BlockRail.Func_27029_g(worldObj, chunkposition.x, chunkposition
				.y + 1, chunkposition.z))
			{
				return new net.minecraft.src.RailLogic(minecartTrack, worldObj, chunkposition.x, 
					chunkposition.y + 1, chunkposition.z);
			}
			if (net.minecraft.src.BlockRail.Func_27029_g(worldObj, chunkposition.x, chunkposition
				.y - 1, chunkposition.z))
			{
				return new net.minecraft.src.RailLogic(minecartTrack, worldObj, chunkposition.x, 
					chunkposition.y - 1, chunkposition.z);
			}
			else
			{
				return null;
			}
		}

		private bool IsConnectedTo(net.minecraft.src.RailLogic raillogic)
		{
			for (int i = 0; i < connectedTracks.Count; i++)
			{
				net.minecraft.src.ChunkPosition chunkposition = (net.minecraft.src.ChunkPosition)
					connectedTracks[i];
				if (chunkposition.x == raillogic.trackX && chunkposition.z == raillogic.trackZ)
				{
					return true;
				}
			}
			return false;
		}

		private bool Func_599_b(int i, int j, int k)
		{
			for (int l = 0; l < connectedTracks.Count; l++)
			{
				net.minecraft.src.ChunkPosition chunkposition = (net.minecraft.src.ChunkPosition)
					connectedTracks[l];
				if (chunkposition.x == i && chunkposition.z == k)
				{
					return true;
				}
			}
			return false;
		}

		private int GetAdjacentTracks()
		{
			int i = 0;
			if (IsMinecartTrack(trackX, trackY, trackZ - 1))
			{
				i++;
			}
			if (IsMinecartTrack(trackX, trackY, trackZ + 1))
			{
				i++;
			}
			if (IsMinecartTrack(trackX - 1, trackY, trackZ))
			{
				i++;
			}
			if (IsMinecartTrack(trackX + 1, trackY, trackZ))
			{
				i++;
			}
			return i;
		}

		private bool HandleKeyPress(net.minecraft.src.RailLogic raillogic)
		{
			if (IsConnectedTo(raillogic))
			{
				return true;
			}
			if (connectedTracks.Count == 2)
			{
				return false;
			}
			if (connectedTracks.Count == 0)
			{
				return true;
			}
			net.minecraft.src.ChunkPosition chunkposition = (net.minecraft.src.ChunkPosition)
				connectedTracks[0];
			return raillogic.trackY != trackY || chunkposition.y != trackY ? true : true;
		}

		private void Func_598_d(net.minecraft.src.RailLogic raillogic)
		{
			connectedTracks.Add(new net.minecraft.src.ChunkPosition(raillogic.trackX, raillogic
				.trackY, raillogic.trackZ));
			bool flag = Func_599_b(trackX, trackY, trackZ - 1);
			bool flag1 = Func_599_b(trackX, trackY, trackZ + 1);
			bool flag2 = Func_599_b(trackX - 1, trackY, trackZ);
			bool flag3 = Func_599_b(trackX + 1, trackY, trackZ);
			byte byte0 = unchecked((byte)(-1));
			if (flag || flag1)
			{
				byte0 = 0;
			}
			if (flag2 || flag3)
			{
				byte0 = 1;
			}
			if (!field_27084_f)
			{
				if (flag1 && flag3 && !flag && !flag2)
				{
					byte0 = 6;
				}
				if (flag1 && flag2 && !flag && !flag3)
				{
					byte0 = 7;
				}
				if (flag && flag2 && !flag1 && !flag3)
				{
					byte0 = 8;
				}
				if (flag && flag3 && !flag1 && !flag2)
				{
					byte0 = 9;
				}
			}
			if (byte0 == 0)
			{
				if (net.minecraft.src.BlockRail.Func_27029_g(worldObj, trackX, trackY + 1, trackZ
					 - 1))
				{
					byte0 = 4;
				}
				if (net.minecraft.src.BlockRail.Func_27029_g(worldObj, trackX, trackY + 1, trackZ
					 + 1))
				{
					byte0 = 5;
				}
			}
			if (byte0 == 1)
			{
				if (net.minecraft.src.BlockRail.Func_27029_g(worldObj, trackX + 1, trackY + 1, trackZ
					))
				{
					byte0 = 2;
				}
				if (net.minecraft.src.BlockRail.Func_27029_g(worldObj, trackX - 1, trackY + 1, trackZ
					))
				{
					byte0 = 3;
				}
			}
			if (((sbyte)byte0) < 0)
			{
				byte0 = 0;
			}
			int i = byte0;
			if (field_27084_f)
			{
				i = worldObj.GetBlockMetadata(trackX, trackY, trackZ) & 8 | byte0;
			}
			worldObj.SetBlockMetadataWithNotify(trackX, trackY, trackZ, i);
		}

		private bool Func_592_c(int i, int j, int k)
		{
			net.minecraft.src.RailLogic raillogic = GetMinecartTrackLogic(new net.minecraft.src.ChunkPosition
				(i, j, k));
			if (raillogic == null)
			{
				return false;
			}
			else
			{
				raillogic.Func_591_b();
				return raillogic.HandleKeyPress(this);
			}
		}

		public virtual void Func_596_a(bool flag, bool flag1)
		{
			bool flag2 = Func_592_c(trackX, trackY, trackZ - 1);
			bool flag3 = Func_592_c(trackX, trackY, trackZ + 1);
			bool flag4 = Func_592_c(trackX - 1, trackY, trackZ);
			bool flag5 = Func_592_c(trackX + 1, trackY, trackZ);
			byte byte0 = unchecked((byte)(-1));
			if ((flag2 || flag3) && !flag4 && !flag5)
			{
				byte0 = 0;
			}
			if ((flag4 || flag5) && !flag2 && !flag3)
			{
				byte0 = 1;
			}
			if (!field_27084_f)
			{
				if (flag3 && flag5 && !flag2 && !flag4)
				{
					byte0 = 6;
				}
				if (flag3 && flag4 && !flag2 && !flag5)
				{
					byte0 = 7;
				}
				if (flag2 && flag4 && !flag3 && !flag5)
				{
					byte0 = 8;
				}
				if (flag2 && flag5 && !flag3 && !flag4)
				{
					byte0 = 9;
				}
			}
			if (byte0 == -1)
			{
				if (flag2 || flag3)
				{
					byte0 = 0;
				}
				if (flag4 || flag5)
				{
					byte0 = 1;
				}
				if (!field_27084_f)
				{
					if (flag)
					{
						if (flag3 && flag5)
						{
							byte0 = 6;
						}
						if (flag4 && flag3)
						{
							byte0 = 7;
						}
						if (flag5 && flag2)
						{
							byte0 = 9;
						}
						if (flag2 && flag4)
						{
							byte0 = 8;
						}
					}
					else
					{
						if (flag2 && flag4)
						{
							byte0 = 8;
						}
						if (flag5 && flag2)
						{
							byte0 = 9;
						}
						if (flag4 && flag3)
						{
							byte0 = 7;
						}
						if (flag3 && flag5)
						{
							byte0 = 6;
						}
					}
				}
			}
			if (byte0 == 0)
			{
				if (net.minecraft.src.BlockRail.Func_27029_g(worldObj, trackX, trackY + 1, trackZ
					 - 1))
				{
					byte0 = 4;
				}
				if (net.minecraft.src.BlockRail.Func_27029_g(worldObj, trackX, trackY + 1, trackZ
					 + 1))
				{
					byte0 = 5;
				}
			}
			if (byte0 == 1)
			{
				if (net.minecraft.src.BlockRail.Func_27029_g(worldObj, trackX + 1, trackY + 1, trackZ
					))
				{
					byte0 = 2;
				}
				if (net.minecraft.src.BlockRail.Func_27029_g(worldObj, trackX - 1, trackY + 1, trackZ
					))
				{
					byte0 = 3;
				}
			}
			if (((sbyte)byte0) < 0)
			{
				byte0 = 0;
			}
			Func_27083_a(byte0);
			int i = byte0;
			if (field_27084_f)
			{
				i = worldObj.GetBlockMetadata(trackX, trackY, trackZ) & 8 | byte0;
			}
			if (flag1 || worldObj.GetBlockMetadata(trackX, trackY, trackZ) != i)
			{
				worldObj.SetBlockMetadataWithNotify(trackX, trackY, trackZ, i);
				for (int j = 0; j < connectedTracks.Count; j++)
				{
					net.minecraft.src.RailLogic raillogic = GetMinecartTrackLogic((net.minecraft.src.ChunkPosition
						)connectedTracks[j]);
					if (raillogic == null)
					{
						continue;
					}
					raillogic.Func_591_b();
					if (raillogic.HandleKeyPress(this))
					{
						raillogic.Func_598_d(this);
					}
				}
			}
		}

		internal static int GetNAdjacentTracks(net.minecraft.src.RailLogic raillogic)
		{
			return raillogic.GetAdjacentTracks();
		}

		private net.minecraft.src.World worldObj;

		private int trackX;

		private int trackY;

		private int trackZ;

		private readonly bool field_27084_f;

		private List<ChunkPosition> connectedTracks;

		internal readonly net.minecraft.src.BlockRail minecartTrack;
 /* synthetic field */
	}
}
