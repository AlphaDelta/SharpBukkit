// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
    public class EntityTrackerEntry
    {
        public EntityTrackerEntry(net.minecraft.src.Entity entity, int i, int j, bool flag
            )
        {
            // Referenced classes of package net.minecraft.src:
            //            Entity, MathHelper, Packet34EntityTeleport, Packet33RelEntityMoveLook, 
            //            Packet31RelEntityMove, Packet32EntityLook, Packet28EntityVelocity, DataWatcher, 
            //            Packet40EntityMetadata, EntityPlayerMP, NetServerHandler, Packet29DestroyEntity, 
            //            Packet5PlayerInventory, EntityPlayer, Packet17Sleep, EntityItem, 
            //            Packet21PickupSpawn, Packet20NamedEntitySpawn, EntityMinecart, Packet23VehicleSpawn, 
            //            EntityBoat, IAnimals, Packet24MobSpawn, EntityLiving, 
            //            EntityFish, EntityArrow, EntitySnowball, EntityFireball, 
            //            EntityEgg, EntityTNTPrimed, EntityFallingSand, Block, 
            //            EntityPainting, Packet25EntityPainting, Packet
            updateCounter = 0;
            firstUpdateDone = false;
            field_28165_t = 0;
            playerEntitiesUpdated = false;
            trackedPlayers = new HashSet<EntityPlayerMP>();
            trackedEntity = entity;
            trackingDistanceThreshold = i;
            field_9234_e = j;
            shouldSendMotionUpdates = flag;
            encodedPosX = net.minecraft.src.MathHelper.Floor_double(entity.posX * 32D);
            encodedPosY = net.minecraft.src.MathHelper.Floor_double(entity.posY * 32D);
            encodedPosZ = net.minecraft.src.MathHelper.Floor_double(entity.posZ * 32D);
            encodedRotationYaw = net.minecraft.src.MathHelper.Floor_float((entity.rotationYaw
                 * 256F) / 360F);
            encodedRotationPitch = net.minecraft.src.MathHelper.Floor_float((entity.rotationPitch
                 * 256F) / 360F);
        }

        public override bool Equals(object obj)
        {
            if (obj is net.minecraft.src.EntityTrackerEntry)
            {
                return ((net.minecraft.src.EntityTrackerEntry)obj).trackedEntity.entityId == trackedEntity
                    .entityId;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return trackedEntity.entityId;
        }

        public virtual void UpdatePlayerList(List<EntityPlayer> list)
        {
            playerEntitiesUpdated = false;
            if (!firstUpdateDone || trackedEntity.GetDistanceSq(lastTrackedEntityPosX, lastTrackedEntityPosY
                , lastTrackedEntityPosZ) > 16D)
            {
                lastTrackedEntityPosX = trackedEntity.posX;
                lastTrackedEntityPosY = trackedEntity.posY;
                lastTrackedEntityPosZ = trackedEntity.posZ;
                firstUpdateDone = true;
                playerEntitiesUpdated = true;
                UpdatePlayerEntities(list);
            }
            field_28165_t++;
            if (++updateCounter % field_9234_e == 0)
            {
                int i = net.minecraft.src.MathHelper.Floor_double(trackedEntity.posX * 32D);
                int j = net.minecraft.src.MathHelper.Floor_double(trackedEntity.posY * 32D);
                int k = net.minecraft.src.MathHelper.Floor_double(trackedEntity.posZ * 32D);
                int l = net.minecraft.src.MathHelper.Floor_float((trackedEntity.rotationYaw * 256F
                    ) / 360F);
                int i1 = net.minecraft.src.MathHelper.Floor_float((trackedEntity.rotationPitch *
                    256F) / 360F);
                int j1 = i - encodedPosX;
                int k1 = j - encodedPosY;
                int l1 = k - encodedPosZ;
                object obj = null;
                bool flag = System.Math.Abs(i) >= 8 || System.Math.Abs(j) >= 8 || System.Math.Abs
                    (k) >= 8;
                bool flag1 = System.Math.Abs(l - encodedRotationYaw) >= 8 || System.Math.Abs(i1 -
                     encodedRotationPitch) >= 8;
                if (j1 < -128 || j1 >= 128 || k1 < -128 || k1 >= 128 || l1 < -128 || l1 >= 128 ||
                     field_28165_t > 400)
                {
                    field_28165_t = 0;
                    trackedEntity.posX = (double)i / 32D;
                    trackedEntity.posY = (double)j / 32D;
                    trackedEntity.posZ = (double)k / 32D;
                    obj = new net.minecraft.src.Packet34EntityTeleport(trackedEntity.entityId, i, j,
                        k, unchecked((byte)l), unchecked((byte)i1));
                }
                else
                {
                    if (flag && flag1)
                    {
                        obj = new net.minecraft.src.Packet33RelEntityMoveLook(trackedEntity.entityId, unchecked(
                            (byte)j1), unchecked((byte)k1), unchecked((byte)l1), unchecked((byte)l), unchecked(
                            (byte)i1));
                    }
                    else
                    {
                        if (flag)
                        {
                            obj = new net.minecraft.src.Packet31RelEntityMove(trackedEntity.entityId, unchecked(
                                (byte)j1), unchecked((byte)k1), unchecked((byte)l1));
                        }
                        else
                        {
                            if (flag1)
                            {
                                obj = new net.minecraft.src.Packet32EntityLook(trackedEntity.entityId, unchecked(
                                    (byte)l), unchecked((byte)i1));
                            }
                        }
                    }
                }
                if (shouldSendMotionUpdates)
                {
                    double d = trackedEntity.motionX - lastTrackedEntityMotionX;
                    double d1 = trackedEntity.motionY - lastTrackedEntityMotionY;
                    double d2 = trackedEntity.motionZ - lastTrackedEntityMotionZ;
                    double d3 = 0.02D;
                    double d4 = d * d + d1 * d1 + d2 * d2;
                    if (d4 > d3 * d3 || d4 > 0.0D && trackedEntity.motionX == 0.0D && trackedEntity.motionY
                         == 0.0D && trackedEntity.motionZ == 0.0D)
                    {
                        lastTrackedEntityMotionX = trackedEntity.motionX;
                        lastTrackedEntityMotionY = trackedEntity.motionY;
                        lastTrackedEntityMotionZ = trackedEntity.motionZ;
                        SendPacketToTrackedPlayers(new net.minecraft.src.Packet28EntityVelocity(trackedEntity
                            .entityId, lastTrackedEntityMotionX, lastTrackedEntityMotionY, lastTrackedEntityMotionZ
                            ));
                    }
                }
                if (obj != null)
                {
                    SendPacketToTrackedPlayers(((net.minecraft.src.Packet)(obj)));
                }
                net.minecraft.src.DataWatcher datawatcher = trackedEntity.GetDataWatcher();
                if (datawatcher.HasObjectChanged())
                {
                    SendPacketToTrackedPlayersAndTrackedEntity(new net.minecraft.src.Packet40EntityMetadata
                        (trackedEntity.entityId, datawatcher));
                }
                if (flag)
                {
                    encodedPosX = i;
                    encodedPosY = j;
                    encodedPosZ = k;
                }
                if (flag1)
                {
                    encodedRotationYaw = l;
                    encodedRotationPitch = i1;
                }
            }
            if (trackedEntity.beenAttacked)
            {
                SendPacketToTrackedPlayersAndTrackedEntity(new net.minecraft.src.Packet28EntityVelocity
                    (trackedEntity));
                trackedEntity.beenAttacked = false;
            }
        }

        public virtual void SendPacketToTrackedPlayers(net.minecraft.src.Packet packet)
        {
            net.minecraft.src.EntityPlayerMP entityplayermp;
            for (System.Collections.IEnumerator iterator = trackedPlayers.GetEnumerator(); iterator
                .MoveNext(); entityplayermp.playerNetServerHandler.SendPacket(packet))
            {
                entityplayermp = (net.minecraft.src.EntityPlayerMP)iterator.Current;
            }
        }

        public virtual void SendPacketToTrackedPlayersAndTrackedEntity(net.minecraft.src.Packet
             packet)
        {
            SendPacketToTrackedPlayers(packet);
            if (trackedEntity is net.minecraft.src.EntityPlayerMP)
            {
                ((net.minecraft.src.EntityPlayerMP)trackedEntity).playerNetServerHandler.SendPacket
                    (packet);
            }
        }

        public virtual void SendDestroyEntityPacketToTrackedPlayers()
        {
            SendPacketToTrackedPlayers(new net.minecraft.src.Packet29DestroyEntity(trackedEntity
                .entityId));
        }

        public virtual void RemoveFromTrackedPlayers(net.minecraft.src.EntityPlayerMP entityplayermp
            )
        {
            if (trackedPlayers.Contains(entityplayermp))
            {
                trackedPlayers.Remove(entityplayermp);
            }
        }

        public virtual void UpdatePlayerEntity(net.minecraft.src.EntityPlayerMP entityplayermp
            )
        {
            if (entityplayermp == trackedEntity)
            {
                return;
            }
            double d = entityplayermp.posX - (double)(encodedPosX / 32);
            double d1 = entityplayermp.posZ - (double)(encodedPosZ / 32);
            if (d >= (double)(-trackingDistanceThreshold) && d <= (double)trackingDistanceThreshold
                 && d1 >= (double)(-trackingDistanceThreshold) && d1 <= (double)trackingDistanceThreshold)
            {
                if (!trackedPlayers.Contains(entityplayermp))
                {
                    trackedPlayers.Add(entityplayermp);
                    entityplayermp.playerNetServerHandler.SendPacket(GetSpawnPacket());
                    if (shouldSendMotionUpdates)
                    {
                        entityplayermp.playerNetServerHandler.SendPacket(new net.minecraft.src.Packet28EntityVelocity
                            (trackedEntity.entityId, trackedEntity.motionX, trackedEntity.motionY, trackedEntity
                            .motionZ));
                    }
                    net.minecraft.src.ItemStack[] aitemstack = trackedEntity.GetInventory();
                    if (aitemstack != null)
                    {
                        for (int i = 0; i < aitemstack.Length; i++)
                        {
                            entityplayermp.playerNetServerHandler.SendPacket(new net.minecraft.src.Packet5PlayerInventory
                                (trackedEntity.entityId, i, aitemstack[i]));
                        }
                    }
                    if (trackedEntity is net.minecraft.src.EntityPlayer)
                    {
                        net.minecraft.src.EntityPlayer entityplayer = (net.minecraft.src.EntityPlayer)trackedEntity;
                        if (entityplayer.IsSleeping())
                        {
                            entityplayermp.playerNetServerHandler.SendPacket(new net.minecraft.src.Packet17Sleep(
                                trackedEntity,
                                0,
                                net.minecraft.src.MathHelper.Floor_double(trackedEntity.posX),
                                net.minecraft.src.MathHelper.Floor_double(trackedEntity.posY),
                                net.minecraft.src.MathHelper.Floor_double(trackedEntity.posZ)
                            ));
                        }
                    }
                }
            }
            else
            {
                if (trackedPlayers.Contains(entityplayermp))
                {
                    trackedPlayers.Remove(entityplayermp);
                    entityplayermp.playerNetServerHandler.SendPacket(new net.minecraft.src.Packet29DestroyEntity
                        (trackedEntity.entityId));
                }
            }
        }

        public virtual void UpdatePlayerEntities(List<EntityPlayer> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                UpdatePlayerEntity((net.minecraft.src.EntityPlayerMP)list[i]);
            }
        }

        private net.minecraft.src.Packet GetSpawnPacket()
        {
            if (trackedEntity is net.minecraft.src.EntityItem)
            {
                net.minecraft.src.EntityItem entityitem = (net.minecraft.src.EntityItem)trackedEntity;
                net.minecraft.src.Packet21PickupSpawn packet21pickupspawn = new net.minecraft.src.Packet21PickupSpawn
                    (entityitem);
                entityitem.posX = (double)packet21pickupspawn.xPosition / 32D;
                entityitem.posY = (double)packet21pickupspawn.yPosition / 32D;
                entityitem.posZ = (double)packet21pickupspawn.zPosition / 32D;
                return packet21pickupspawn;
            }
            if (trackedEntity is net.minecraft.src.EntityPlayerMP)
            {
                // CRAFTBUKKIT start - limit name length to 16 characters
                if (((EntityPlayerMP)this.trackedEntity).username.Length > 16)
                {
                    ((EntityPlayerMP)this.trackedEntity).username = ((EntityPlayerMP)this.trackedEntity).username.Substring(0, 16);
                }
                // CRAFTBUKKIT end
                return new net.minecraft.src.Packet20NamedEntitySpawn((net.minecraft.src.EntityPlayer)trackedEntity);
            }
            if (trackedEntity is net.minecraft.src.EntityMinecart)
            {
                net.minecraft.src.EntityMinecart entityminecart = (net.minecraft.src.EntityMinecart
                    )trackedEntity;
                if (entityminecart.minecartType == 0)
                {
                    return new net.minecraft.src.Packet23VehicleSpawn(trackedEntity, 10);
                }
                if (entityminecart.minecartType == 1)
                {
                    return new net.minecraft.src.Packet23VehicleSpawn(trackedEntity, 11);
                }
                if (entityminecart.minecartType == 2)
                {
                    return new net.minecraft.src.Packet23VehicleSpawn(trackedEntity, 12);
                }
            }
            if (trackedEntity is net.minecraft.src.EntityBoat)
            {
                return new net.minecraft.src.Packet23VehicleSpawn(trackedEntity, 1);
            }
            if (trackedEntity is net.minecraft.src.IAnimals)
            {
                return new net.minecraft.src.Packet24MobSpawn((net.minecraft.src.EntityLiving)trackedEntity
                    );
            }
            if (trackedEntity is net.minecraft.src.EntityFish)
            {
                return new net.minecraft.src.Packet23VehicleSpawn(trackedEntity, 90);
            }
            if (trackedEntity is net.minecraft.src.EntityArrow)
            {
                net.minecraft.src.EntityLiving entityliving = ((net.minecraft.src.EntityArrow)trackedEntity
                    ).owner;
                return new net.minecraft.src.Packet23VehicleSpawn(trackedEntity, 60, entityliving
                     == null ? trackedEntity.entityId : entityliving.entityId);
            }
            if (trackedEntity is net.minecraft.src.EntitySnowball)
            {
                return new net.minecraft.src.Packet23VehicleSpawn(trackedEntity, 61);
            }
            if (trackedEntity is net.minecraft.src.EntityFireball)
            {
                net.minecraft.src.EntityFireball entityfireball = (net.minecraft.src.EntityFireball)trackedEntity;
                net.minecraft.src.Packet23VehicleSpawn packet23vehiclespawn = new net.minecraft.src.Packet23VehicleSpawn(trackedEntity, 63, ((net.minecraft.src.EntityFireball)trackedEntity).owner?.entityId ?? 1); // CRAFTBUKKIT -- added check for null shooter
                packet23vehiclespawn.motionX = (int)(entityfireball.field_9199_b * 8000D);
                packet23vehiclespawn.motionY = (int)(entityfireball.field_9198_c * 8000D);
                packet23vehiclespawn.motionZ = (int)(entityfireball.field_9196_d * 8000D);
                return packet23vehiclespawn;
            }
            if (trackedEntity is net.minecraft.src.EntityEgg)
            {
                return new net.minecraft.src.Packet23VehicleSpawn(trackedEntity, 62);
            }
            if (trackedEntity is net.minecraft.src.EntityTNTPrimed)
            {
                return new net.minecraft.src.Packet23VehicleSpawn(trackedEntity, 50);
            }
            if (trackedEntity is net.minecraft.src.EntityFallingSand)
            {
                net.minecraft.src.EntityFallingSand entityfallingsand = (net.minecraft.src.EntityFallingSand
                    )trackedEntity;
                if (entityfallingsand.blockID == net.minecraft.src.Block.SAND.ID)
                {
                    return new net.minecraft.src.Packet23VehicleSpawn(trackedEntity, 70);
                }
                if (entityfallingsand.blockID == net.minecraft.src.Block.GRAVEL.ID)
                {
                    return new net.minecraft.src.Packet23VehicleSpawn(trackedEntity, 71);
                }
            }
            if (trackedEntity is net.minecraft.src.EntityPainting)
            {
                return new net.minecraft.src.Packet25EntityPainting((net.minecraft.src.EntityPainting
                    )trackedEntity);
            }
            else
            {
                throw new System.ArgumentException((new java.lang.StringBuilder()).Append("Don't know how to add ").Append(trackedEntity.GetType()).Append("!").ToString());
            }
        }

        public virtual void RemoveTrackedPlayerSymmetric(net.minecraft.src.EntityPlayerMP
             entityplayermp)
        {
            if (trackedPlayers.Contains(entityplayermp))
            {
                trackedPlayers.Remove(entityplayermp);
                entityplayermp.playerNetServerHandler.SendPacket(new net.minecraft.src.Packet29DestroyEntity
                    (trackedEntity.entityId));
            }
        }

        public net.minecraft.src.Entity trackedEntity;

        public int trackingDistanceThreshold;

        public int field_9234_e;

        public int encodedPosX;

        public int encodedPosY;

        public int encodedPosZ;

        public int encodedRotationYaw;

        public int encodedRotationPitch;

        public double lastTrackedEntityMotionX;

        public double lastTrackedEntityMotionY;

        public double lastTrackedEntityMotionZ;

        public int updateCounter;

        private double lastTrackedEntityPosX;

        private double lastTrackedEntityPosY;

        private double lastTrackedEntityPosZ;

        private bool firstUpdateDone;

        private bool shouldSendMotionUpdates;

        private int field_28165_t;

        public bool playerEntitiesUpdated;

        public HashSet<EntityPlayerMP> trackedPlayers;
    }
}
