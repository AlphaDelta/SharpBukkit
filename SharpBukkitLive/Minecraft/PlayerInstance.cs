// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	internal class PlayerInstance
	{
		public PlayerInstance(net.minecraft.src.PlayerManager playermanager, int i, int j
			)
		{
			// Referenced classes of package net.minecraft.src:
			//            ChunkCoordIntPair, PlayerManager, WorldServer, ChunkProviderServer, 
			//            EntityPlayerMP, Packet50PreChunk, NetServerHandler, PlayerHash, 
			//            Packet53BlockChange, Block, Packet51MapChunk, TileEntity, 
			//            Packet52MultiBlockChange, Packet
			//        super();
			playerManager = playermanager;
			players = new List<EntityPlayerMP>();
			blocksToUpdate = new short[10];
			numBlocksToUpdate = 0;
			chunkX = i;
			chunkZ = j;
			currentChunk = new net.minecraft.src.ChunkCoordIntPair(i, j);
			playermanager.GetMinecraftServer().chunkProviderServer.LoadChunk(i, j);
		}

		public virtual void AddPlayer(net.minecraft.src.EntityPlayerMP entityplayermp)
		{
			if (players.Contains(entityplayermp))
			{
				throw new System.InvalidOperationException((new java.lang.StringBuilder()).Append
					("Failed to add player. ").Append(entityplayermp).Append(" already is in chunk "
					).Append(chunkX).Append(", ").Append(chunkZ).ToString());
			}
			else
			{
				entityplayermp.field_420_ah.Add(currentChunk);
				entityplayermp.playerNetServerHandler.SendPacket(new net.minecraft.src.Packet50PreChunk
					(currentChunk.chunkXPos, currentChunk.chunkZPos, true));
				players.Add(entityplayermp);
				entityplayermp.loadedChunks.Add(currentChunk);
				return;
			}
		}

		public virtual void RemovePlayer(net.minecraft.src.EntityPlayerMP entityplayermp)
		{
			if (!players.Contains(entityplayermp))
			{
				return;
			}
			players.Remove(entityplayermp);
			if (players.Count == 0)
			{
				long l = (long)chunkX + unchecked((long)(0x7fffffffL)) | (long)chunkZ + unchecked(
					(long)(0x7fffffffL)) << 32;
				net.minecraft.src.PlayerManager.GetPlayerInstances(playerManager).Remove(l);
				if (numBlocksToUpdate > 0)
				{
					net.minecraft.src.PlayerManager.GetPlayerInstancesToUpdate(playerManager).Remove(
						this);
				}
				playerManager.GetMinecraftServer().chunkProviderServer.Func_374_c(chunkX, chunkZ);
			}
			entityplayermp.loadedChunks.Remove(currentChunk);
			if (entityplayermp.field_420_ah.Contains(currentChunk))
			{
				entityplayermp.playerNetServerHandler.SendPacket(new net.minecraft.src.Packet50PreChunk
					(chunkX, chunkZ, false));
			}
		}

		public virtual void MarkBlockNeedsUpdate(int i, int j, int k)
		{
			if (numBlocksToUpdate == 0)
			{
				net.minecraft.src.PlayerManager.GetPlayerInstancesToUpdate(playerManager).Add(this
					);
				minX = maxX = i;
				minY = maxY = j;
				minZ = maxZ = k;
			}
			if (minX > i)
			{
				minX = i;
			}
			if (maxX < i)
			{
				maxX = i;
			}
			if (minY > j)
			{
				minY = j;
			}
			if (maxY < j)
			{
				maxY = j;
			}
			if (minZ > k)
			{
				minZ = k;
			}
			if (maxZ < k)
			{
				maxZ = k;
			}
			if (numBlocksToUpdate < 10)
			{
				short word0 = (short)(i << 12 | k << 8 | j);
				for (int l = 0; l < numBlocksToUpdate; l++)
				{
					if (blocksToUpdate[l] == word0)
					{
						return;
					}
				}
				blocksToUpdate[numBlocksToUpdate++] = word0;
			}
		}

		public virtual void SendPacketToPlayersInInstance(net.minecraft.src.Packet packet
			)
		{
			for (int i = 0; i < players.Count; i++)
			{
				net.minecraft.src.EntityPlayerMP entityplayermp = (net.minecraft.src.EntityPlayerMP
					)players[i];
				if (entityplayermp.field_420_ah.Contains(currentChunk))
				{
					entityplayermp.playerNetServerHandler.SendPacket(packet);
				}
			}
		}

		public virtual void OnUpdate()
		{
			net.minecraft.src.WorldServer worldserver = playerManager.GetMinecraftServer();
			if (numBlocksToUpdate == 0)
			{
				return;
			}
			if (numBlocksToUpdate == 1)
			{
				int i = chunkX * 16 + minX;
				int l = minY;
				int k1 = chunkZ * 16 + minZ;
				SendPacketToPlayersInInstance(new net.minecraft.src.Packet53BlockChange(i, l, k1, 
					worldserver));
				if (net.minecraft.src.Block.isBlockContainer[worldserver.GetBlockId(i, l, k1)])
				{
					UpdateTileEntity(worldserver.GetBlockTileEntity(i, l, k1));
				}
			}
			else
			{
				if (numBlocksToUpdate == 10)
				{
					minY = (minY / 2) * 2;
					maxY = (maxY / 2 + 1) * 2;
					int j = minX + chunkX * 16;
					int i1 = minY;
					int l1 = minZ + chunkZ * 16;
					int j2 = (maxX - minX) + 1;
					int l2 = (maxY - minY) + 2;
					int i3 = (maxZ - minZ) + 1;
					SendPacketToPlayersInInstance(new net.minecraft.src.Packet51MapChunk(j, i1, l1, j2
						, l2, i3, worldserver));
					List<TileEntity> list = worldserver.GetTileEntityList(j, i1, l1, j + j2, 
						i1 + l2, l1 + i3);
					for (int j3 = 0; j3 < list.Count; j3++)
					{
						UpdateTileEntity((net.minecraft.src.TileEntity)list[j3]);
					}
				}
				else
				{
					SendPacketToPlayersInInstance(new net.minecraft.src.Packet52MultiBlockChange(chunkX
						, chunkZ, blocksToUpdate, numBlocksToUpdate, worldserver));
					for (int k = 0; k < numBlocksToUpdate; k++)
					{
						int j1 = chunkX * 16 + (numBlocksToUpdate >> 12 & 0xf);
						int i2 = numBlocksToUpdate & 0xff;
						int k2 = chunkZ * 16 + (numBlocksToUpdate >> 8 & 0xf);
						if (net.minecraft.src.Block.isBlockContainer[worldserver.GetBlockId(j1, i2, k2)])
						{
							System.Console.Out.WriteLine("Sending!");
							UpdateTileEntity(worldserver.GetBlockTileEntity(j1, i2, k2));
						}
					}
				}
			}
			numBlocksToUpdate = 0;
		}

		private void UpdateTileEntity(net.minecraft.src.TileEntity tileentity)
		{
			if (tileentity != null)
			{
				net.minecraft.src.Packet packet = tileentity.GetDescriptionPacket();
				if (packet != null)
				{
					SendPacketToPlayersInInstance(packet);
				}
			}
		}

		private List<EntityPlayerMP> players;

		private int chunkX;

		private int chunkZ;

		private net.minecraft.src.ChunkCoordIntPair currentChunk;

		private short[] blocksToUpdate;

		private int numBlocksToUpdate;

		private int minX;

		private int maxX;

		private int minY;

		private int maxY;

		private int minZ;

		private int maxZ;

		internal readonly net.minecraft.src.PlayerManager playerManager;
 /* synthetic field */
	}
}
