// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class WorldServer : net.minecraft.src.World
	{
		public WorldServer(net.minecraft.server.MinecraftServer minecraftserver, net.minecraft.src.ISaveHandler
			 isavehandler, string s, int i, long l)
			: base(isavehandler, s, l, net.minecraft.src.WorldProvider.Func_4091_a(i))
		{
			// Referenced classes of package net.minecraft.src:
			//            World, WorldProvider, MCHash, EntityAnimal, 
			//            EntityWaterMob, Entity, EntityPlayer, ISaveHandler, 
			//            ChunkProviderServer, TileEntity, WorldInfo, MathHelper, 
			//            ServerConfigurationManager, Packet71Weather, Packet38EntityStatus, EntityTracker, 
			//            Explosion, Packet60Explosion, Packet54PlayNoteBlock, Packet70Bed, 
			//            IChunkProvider
			field_819_z = false;
			field_20912_E = new net.minecraft.src.MCHash();
			mcServer = minecraftserver;
		}

		public override void UpdateEntityWithOptionalForce(net.minecraft.src.Entity entity
			, bool flag)
		{
			if (!mcServer.spawnPeacefulMobs && ((entity is net.minecraft.src.EntityAnimal) ||
				 (entity is net.minecraft.src.EntityWaterMob)))
			{
				entity.SetEntityDead();
			}
			if (entity.riddenByEntity == null || !(entity.riddenByEntity is net.minecraft.src.EntityPlayer
				))
			{
				base.UpdateEntityWithOptionalForce(entity, flag);
			}
		}

		public virtual void Func_12017_b(net.minecraft.src.Entity entity, bool flag)
		{
			base.UpdateEntityWithOptionalForce(entity, flag);
		}

		protected internal override net.minecraft.src.IChunkProvider CreateChunkProvider(
			)
		{
			net.minecraft.src.IChunkLoader ichunkloader = worldFile.Func_22092_a(worldProvider);
			chunkProviderServer = new net.minecraft.src.ChunkProviderServer(this, ichunkloader, worldProvider.GetChunkProvider());
			return chunkProviderServer;
		}

		public virtual List<TileEntity> GetTileEntityList(int i, int j, int k, int
			 l, int i1, int j1)
		{
			List<TileEntity> arraylist = new List<TileEntity>();
			for (int k1 = 0; k1 < loadedTileEntityList.Count; k1++)
			{
				net.minecraft.src.TileEntity tileentity = (net.minecraft.src.TileEntity)loadedTileEntityList
					[k1];
				if (tileentity.xCoord >= i && tileentity.yCoord >= j && tileentity.zCoord >= k &&
					 tileentity.xCoord < l && tileentity.yCoord < i1 && tileentity.zCoord < j1)
				{
					arraylist.Add(tileentity);
				}
			}
			return arraylist;
		}

		public override bool CanMineBlock(net.minecraft.src.EntityPlayer entityplayer, int
			 i, int j, int k)
		{
			int l = (int)net.minecraft.src.MathHelper.Abs(i - worldInfo.GetSpawnX());
			int i1 = (int)net.minecraft.src.MathHelper.Abs(k - worldInfo.GetSpawnZ());
			if (l > i1)
			{
				i1 = l;
			}
			return i1 > 16 || mcServer.configManager.IsOp(entityplayer.username);
		}

		protected internal override void ObtainEntitySkin(net.minecraft.src.Entity entity
			)
		{
			base.ObtainEntitySkin(entity);
			field_20912_E.AddKey(entity.entityId, entity);
		}

		protected internal override void ReleaseEntitySkin(net.minecraft.src.Entity entity
			)
		{
			base.ReleaseEntitySkin(entity);
			field_20912_E.RemoveObject(entity.entityId);
		}

		public virtual net.minecraft.src.Entity Func_6158_a(int i)
		{
			return (net.minecraft.src.Entity)field_20912_E.Lookup(i);
		}

		public override bool AddLightningBolt(net.minecraft.src.Entity entity)
		{
			if (base.AddLightningBolt(entity))
			{
				mcServer.configManager.SendPacketToPlayersAroundPoint(entity.posX, entity.posY, entity
					.posZ, 512D, worldProvider.worldType, new net.minecraft.src.Packet71Weather(entity
					));
				return true;
			}
			else
			{
				return false;
			}
		}

		public override void SendTrackedEntityStatusUpdatePacket(net.minecraft.src.Entity
			 entity, byte byte0)
		{
			net.minecraft.src.Packet38EntityStatus packet38entitystatus = new net.minecraft.src.Packet38EntityStatus
				(entity.entityId, byte0);
			mcServer.GetEntityTracker(worldProvider.worldType).SendPacketToTrackedPlayersAndTrackedEntity
				(entity, packet38entitystatus);
		}

		public override net.minecraft.src.Explosion NewExplosion(net.minecraft.src.Entity
			 entity, double d, double d1, double d2, float f, bool flag)
		{
			net.minecraft.src.Explosion explosion = new net.minecraft.src.Explosion(this, entity
				, d, d1, d2, f);
			explosion.isFlaming = flag;
			explosion.DoExplosion();
			explosion.DoEffects(false);
			mcServer.configManager.SendPacketToPlayersAroundPoint(d, d1, d2, 64D, worldProvider
				.worldType, new net.minecraft.src.Packet60Explosion(d, d1, d2, f, explosion.destroyedBlockPositions
				));
			return explosion;
		}

		public override void PlayNoteAt(int i, int j, int k, int l, int i1)
		{
			base.PlayNoteAt(i, j, k, l, i1);
			mcServer.configManager.SendPacketToPlayersAroundPoint(i, j, k, 64D, worldProvider
				.worldType, new net.minecraft.src.Packet54PlayNoteBlock(i, j, k, l, i1));
		}

		public virtual void Func_30006_w()
		{
			worldFile.Func_22093_e();
		}

		protected internal override void UpdateWeather()
		{
			bool flag = Func_27068_v();
			base.UpdateWeather();
			if (flag != Func_27068_v())
			{
				if (flag)
				{
					mcServer.configManager.SendPacketToAllPlayers(new net.minecraft.src.Packet70Bed(2
						));
				}
				else
				{
					mcServer.configManager.SendPacketToAllPlayers(new net.minecraft.src.Packet70Bed(1
						));
				}
			}
		}

		public net.minecraft.src.ChunkProviderServer chunkProviderServer;

		public bool field_819_z;

		public bool levelSaving;

		private net.minecraft.server.MinecraftServer mcServer;

		private net.minecraft.src.MCHash field_20912_E;
        public EntityTracker tracker; // CRAFTBUKKIT
    }
}
