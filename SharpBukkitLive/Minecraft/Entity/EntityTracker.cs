// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class EntityTracker
	{
		public EntityTracker(net.minecraft.server.MinecraftServer minecraftserver, int i)
		{
			// Referenced classes of package net.minecraft.src:
			//            MCHash, ServerConfigurationManager, EntityPlayerMP, EntityTrackerEntry, 
			//            EntityFish, EntityArrow, EntityFireball, EntitySnowball, 
			//            EntityEgg, EntityItem, EntityMinecart, EntityBoat, 
			//            EntitySquid, IAnimals, EntityTNTPrimed, EntityFallingSand, 
			//            EntityPainting, Entity, WorldServer, Packet
			trackedEntitySet = new HashSet<EntityTrackerEntry>();
			trackedEntityHashTable = new net.minecraft.src.MCHash();
			mcServer = minecraftserver;
			field_28113_e = i;
			maxTrackingDistanceThreshold = minecraftserver.configManager.GetMaxTrackingDistance
				();
		}

		public virtual void TrackEntity(net.minecraft.src.Entity entity)
		{
			if (entity is net.minecraft.src.EntityPlayerMP)
			{
				TrackEntity(entity, 512, 2);
				net.minecraft.src.EntityPlayerMP entityplayermp = (net.minecraft.src.EntityPlayerMP
					)entity;
				System.Collections.IEnumerator iterator = trackedEntitySet.GetEnumerator();
				do
				{
					if (!iterator.MoveNext())
					{
						break;
					}
					net.minecraft.src.EntityTrackerEntry entitytrackerentry = (net.minecraft.src.EntityTrackerEntry
						)iterator.Current;
					if (entitytrackerentry.trackedEntity != entityplayermp)
					{
						entitytrackerentry.UpdatePlayerEntity(entityplayermp);
					}
				}
				while (true);
			}
			else
			{
				if (entity is net.minecraft.src.EntityFish)
				{
					TrackEntity(entity, 64, 5, true);
				}
				else
				{
					if (entity is net.minecraft.src.EntityArrow)
					{
						TrackEntity(entity, 64, 20, false);
					}
					else
					{
						if (entity is net.minecraft.src.EntityFireball)
						{
							TrackEntity(entity, 64, 10, false);
						}
						else
						{
							if (entity is net.minecraft.src.EntitySnowball)
							{
								TrackEntity(entity, 64, 10, true);
							}
							else
							{
								if (entity is net.minecraft.src.EntityEgg)
								{
									TrackEntity(entity, 64, 10, true);
								}
								else
								{
									if (entity is net.minecraft.src.EntityItem)
									{
										TrackEntity(entity, 64, 20, true);
									}
									else
									{
										if (entity is net.minecraft.src.EntityMinecart)
										{
											TrackEntity(entity, 160, 5, true);
										}
										else
										{
											if (entity is net.minecraft.src.EntityBoat)
											{
												TrackEntity(entity, 160, 5, true);
											}
											else
											{
												if (entity is net.minecraft.src.EntitySquid)
												{
													TrackEntity(entity, 160, 3, true);
												}
												else
												{
													if (entity is net.minecraft.src.IAnimals)
													{
														TrackEntity(entity, 160, 3);
													}
													else
													{
														if (entity is net.minecraft.src.EntityTNTPrimed)
														{
															TrackEntity(entity, 160, 10, true);
														}
														else
														{
															if (entity is net.minecraft.src.EntityFallingSand)
															{
																TrackEntity(entity, 160, 20, true);
															}
															else
															{
																if (entity is net.minecraft.src.EntityPainting)
																{
																	TrackEntity(entity, 160, 0x7fffffff, false);
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
					}
				}
			}
		}

		public virtual void TrackEntity(net.minecraft.src.Entity entity, int i, int j)
		{
			TrackEntity(entity, i, j, false);
		}

		public virtual void TrackEntity(net.minecraft.src.Entity entity, int i, int j, bool
			 flag)
		{
			if (i > maxTrackingDistanceThreshold)
			{
				i = maxTrackingDistanceThreshold;
			}
			if (trackedEntityHashTable.ContainsItem(entity.entityId))
			{
				throw new System.InvalidOperationException("Entity is already tracked!");
			}
			else
			{
				net.minecraft.src.EntityTrackerEntry entitytrackerentry = new net.minecraft.src.EntityTrackerEntry
					(entity, i, j, flag);
				trackedEntitySet.Add(entitytrackerentry);
				trackedEntityHashTable.AddKey(entity.entityId, entitytrackerentry);
				entitytrackerentry.UpdatePlayerEntities(mcServer.GetWorldManager(field_28113_e).playerEntities);
				return;
			}
		}

		public virtual void UntrackEntity(net.minecraft.src.Entity entity)
		{
			if (entity is net.minecraft.src.EntityPlayerMP)
			{
				net.minecraft.src.EntityPlayerMP entityplayermp = (net.minecraft.src.EntityPlayerMP
					)entity;
				net.minecraft.src.EntityTrackerEntry entitytrackerentry1;
				for (System.Collections.IEnumerator iterator = trackedEntitySet.GetEnumerator(); 
					iterator.MoveNext(); entitytrackerentry1.RemoveFromTrackedPlayers(entityplayermp
					))
				{
					entitytrackerentry1 = (net.minecraft.src.EntityTrackerEntry)iterator.Current;
				}
			}
			net.minecraft.src.EntityTrackerEntry entitytrackerentry = (net.minecraft.src.EntityTrackerEntry
				)trackedEntityHashTable.RemoveObject(entity.entityId);
			if (entitytrackerentry != null)
			{
				trackedEntitySet.Remove(entitytrackerentry);
				entitytrackerentry.SendDestroyEntityPacketToTrackedPlayers();
			}
		}

		public virtual void UpdateTrackedEntities()
		{
			List<EntityPlayerMP> arraylist = new List<EntityPlayerMP>();
			System.Collections.IEnumerator iterator = trackedEntitySet.GetEnumerator();
			do
			{
				if (!iterator.MoveNext())
				{
					break;
				}
				net.minecraft.src.EntityTrackerEntry entitytrackerentry = (net.minecraft.src.EntityTrackerEntry
					)iterator.Current;
				entitytrackerentry.UpdatePlayerList(mcServer.GetWorldManager(field_28113_e).playerEntities
					);
				if (entitytrackerentry.playerEntitiesUpdated && (entitytrackerentry.trackedEntity
					 is net.minecraft.src.EntityPlayerMP))
				{
					arraylist.Add((net.minecraft.src.EntityPlayerMP)entitytrackerentry.trackedEntity);
				}
			}
			while (true);
			for (int i = 0; i < arraylist.Count; i++)
			{
				net.minecraft.src.EntityPlayerMP entityplayermp = (net.minecraft.src.EntityPlayerMP
					)arraylist[i];
				System.Collections.IEnumerator iterator1 = trackedEntitySet.GetEnumerator();
				do
				{
					if (!iterator1.MoveNext())
					{
						goto label0_continue;
					}
					net.minecraft.src.EntityTrackerEntry entitytrackerentry1 = (net.minecraft.src.EntityTrackerEntry
						)iterator1.Current;
					if (entitytrackerentry1.trackedEntity != entityplayermp)
					{
						entitytrackerentry1.UpdatePlayerEntity(entityplayermp);
					}
				}
				while (true);
label0_continue: ;
			}
label0_break: ;
		}

		public virtual void SendPacketToTrackedPlayers(net.minecraft.src.Entity entity, net.minecraft.src.Packet
			 packet)
		{
			net.minecraft.src.EntityTrackerEntry entitytrackerentry = (net.minecraft.src.EntityTrackerEntry
				)trackedEntityHashTable.Lookup(entity.entityId);
			if (entitytrackerentry != null)
			{
				entitytrackerentry.SendPacketToTrackedPlayers(packet);
			}
		}

		public virtual void SendPacketToTrackedPlayersAndTrackedEntity(net.minecraft.src.Entity
			 entity, net.minecraft.src.Packet packet)
		{
			net.minecraft.src.EntityTrackerEntry entitytrackerentry = (net.minecraft.src.EntityTrackerEntry
				)trackedEntityHashTable.Lookup(entity.entityId);
			if (entitytrackerentry != null)
			{
				entitytrackerentry.SendPacketToTrackedPlayersAndTrackedEntity(packet);
			}
		}

		public virtual void RemoveTrackedPlayerSymmetric(net.minecraft.src.EntityPlayerMP
			 entityplayermp)
		{
			net.minecraft.src.EntityTrackerEntry entitytrackerentry;
			for (System.Collections.IEnumerator iterator = trackedEntitySet.GetEnumerator(); 
				iterator.MoveNext(); entitytrackerentry.RemoveTrackedPlayerSymmetric(entityplayermp
				))
			{
				entitytrackerentry = (net.minecraft.src.EntityTrackerEntry)iterator.Current;
			}
		}

		private HashSet<EntityTrackerEntry> trackedEntitySet;

		private net.minecraft.src.MCHash trackedEntityHashTable;

		private net.minecraft.server.MinecraftServer mcServer;

		private int maxTrackingDistanceThreshold;

		private int field_28113_e;
	}
}
