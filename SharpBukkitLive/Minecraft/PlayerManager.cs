// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class PlayerManager
	{
		public PlayerManager(net.minecraft.server.MinecraftServer minecraftserver, int i, 
			int j)
		{
			// Referenced classes of package net.minecraft.src:
			//            PlayerHash, PlayerInstance, EntityPlayerMP, WorldServer
			players = new List<EntityPlayerMP>();
			playerInstances = new net.minecraft.src.PlayerHash();
			playerInstancesToUpdate = new List<PlayerInstance>();
			if (j > 15)
			{
				throw new System.ArgumentException("Too big view radius!");
			}
			if (j < 3)
			{
				throw new System.ArgumentException("Too small view radius!");
			}
			else
			{
				playerViewRadius = j;
				mcServer = minecraftserver;
				field_28110_e = i;
				return;
			}
		}

		public virtual net.minecraft.src.WorldServer GetMinecraftServer()
		{
			return mcServer.GetWorldManager(field_28110_e);
		}

		public virtual void UpdatePlayerInstances()
		{
			for (int i = 0; i < playerInstancesToUpdate.Count; i++)
			{
				((net.minecraft.src.PlayerInstance)playerInstancesToUpdate[i]).OnUpdate();
			}
			playerInstancesToUpdate.Clear();
		}

		private net.minecraft.src.PlayerInstance GetPlayerInstance(int i, int j, bool flag
			)
		{
			long l = (long)i + unchecked((long)(0x7fffffffL)) | (long)j + unchecked((long)(0x7fffffffL
				)) << 32;
			net.minecraft.src.PlayerInstance playerinstance = (net.minecraft.src.PlayerInstance
				)playerInstances.GetValueByKey(l);
			if (playerinstance == null && flag)
			{
				playerinstance = new net.minecraft.src.PlayerInstance(this, i, j);
				playerInstances.Add(l, playerinstance);
			}
			return playerinstance;
		}

		public virtual void MarkBlockNeedsUpdate(int i, int j, int k)
		{
			int l = i >> 4;
			int i1 = k >> 4;
			net.minecraft.src.PlayerInstance playerinstance = GetPlayerInstance(l, i1, false);
			if (playerinstance != null)
			{
				playerinstance.MarkBlockNeedsUpdate(i & 0xf, j, k & 0xf);
			}
		}

		public virtual void AddPlayer(net.minecraft.src.EntityPlayerMP entityplayermp)
		{
			int i = (int)entityplayermp.posX >> 4;
			int j = (int)entityplayermp.posZ >> 4;
			entityplayermp.field_9155_d = entityplayermp.posX;
			entityplayermp.field_9154_e = entityplayermp.posZ;
			int k = 0;
			int l = playerViewRadius;
			int i1 = 0;
			int j1 = 0;
			GetPlayerInstance(i, j, true).AddPlayer(entityplayermp);
			for (int k1 = 1; k1 <= l * 2; k1++)
			{
				for (int i2 = 0; i2 < 2; i2++)
				{
					int[] ai = field_22089_e[k++ % 4];
					for (int j2 = 0; j2 < k1; j2++)
					{
						i1 += ai[0];
						j1 += ai[1];
						GetPlayerInstance(i + i1, j + j1, true).AddPlayer(entityplayermp);
					}
				}
			}
			k %= 4;
			for (int l1 = 0; l1 < l * 2; l1++)
			{
				i1 += field_22089_e[k][0];
				j1 += field_22089_e[k][1];
				GetPlayerInstance(i + i1, j + j1, true).AddPlayer(entityplayermp);
			}
			players.Add(entityplayermp);
		}

		public virtual void RemovePlayer(net.minecraft.src.EntityPlayerMP entityplayermp)
		{
			int i = (int)entityplayermp.field_9155_d >> 4;
			int j = (int)entityplayermp.field_9154_e >> 4;
			for (int k = i - playerViewRadius; k <= i + playerViewRadius; k++)
			{
				for (int l = j - playerViewRadius; l <= j + playerViewRadius; l++)
				{
					net.minecraft.src.PlayerInstance playerinstance = GetPlayerInstance(k, l, false);
					if (playerinstance != null)
					{
						playerinstance.RemovePlayer(entityplayermp);
					}
				}
			}
			players.Remove(entityplayermp);
		}

		private bool Func_544_a(int i, int j, int k, int l)
		{
			int i1 = i - k;
			int j1 = j - l;
			if (i1 < -playerViewRadius || i1 > playerViewRadius)
			{
				return false;
			}
			return j1 >= -playerViewRadius && j1 <= playerViewRadius;
		}

		public virtual void Func_543_c(net.minecraft.src.EntityPlayerMP entityplayermp)
		{
			int i = (int)entityplayermp.posX >> 4;
			int j = (int)entityplayermp.posZ >> 4;
			double d = entityplayermp.field_9155_d - entityplayermp.posX;
			double d1 = entityplayermp.field_9154_e - entityplayermp.posZ;
			double d2 = d * d + d1 * d1;
			if (d2 < 64D)
			{
				return;
			}
			int k = (int)entityplayermp.field_9155_d >> 4;
			int l = (int)entityplayermp.field_9154_e >> 4;
			int i1 = i - k;
			int j1 = j - l;
			if (i1 == 0 && j1 == 0)
			{
				return;
			}
			for (int k1 = i - playerViewRadius; k1 <= i + playerViewRadius; k1++)
			{
				for (int l1 = j - playerViewRadius; l1 <= j + playerViewRadius; l1++)
				{
					if (!Func_544_a(k1, l1, k, l))
					{
						GetPlayerInstance(k1, l1, true).AddPlayer(entityplayermp);
					}
					if (Func_544_a(k1 - i1, l1 - j1, i, j))
					{
						continue;
					}
					net.minecraft.src.PlayerInstance playerinstance = GetPlayerInstance(k1 - i1, l1 -
						 j1, false);
					if (playerinstance != null)
					{
						playerinstance.RemovePlayer(entityplayermp);
					}
				}
			}
			entityplayermp.field_9155_d = entityplayermp.posX;
			entityplayermp.field_9154_e = entityplayermp.posZ;
		}

		public virtual int GetMaxTrackingDistance()
		{
			return playerViewRadius * 16 - 16;
		}

		internal static net.minecraft.src.PlayerHash GetPlayerInstances(net.minecraft.src.PlayerManager
			 playermanager)
		{
			return playermanager.playerInstances;
		}

		internal static System.Collections.IList GetPlayerInstancesToUpdate(net.minecraft.src.PlayerManager playermanager)
		{
			return playermanager.playerInstancesToUpdate;
		}

		public List<EntityPlayerMP> players;

		private net.minecraft.src.PlayerHash playerInstances;

		private List<PlayerInstance> playerInstancesToUpdate;

		private net.minecraft.server.MinecraftServer mcServer;

		private int field_28110_e;

		private int playerViewRadius;

		private readonly int[][] field_22089_e = new int[][] { new int[] { 1, 0 }, new int[
			] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
	}
}
