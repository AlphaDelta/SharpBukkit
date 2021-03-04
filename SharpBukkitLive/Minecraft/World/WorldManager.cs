// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class WorldManager : net.minecraft.src.IWorldAccess
    {
        public WorldManager(net.minecraft.server.MinecraftServer minecraftserver, net.minecraft.src.WorldServer worldserver)
        {
            // Referenced classes of package net.minecraft.src:
            //            IWorldAccess, WorldServer, WorldProvider, EntityTracker, 
            //            ServerConfigurationManager, Packet61DoorChange, Entity, TileEntity, 
            //            EntityPlayer
            mcServer = minecraftserver;
            field_28134_b = worldserver;
        }

        public virtual void SpawnParticle(string s, double d, double d1, double d2, double d3, double d4, double d5)
        {
        }

        public virtual void ObtainEntitySkin(net.minecraft.src.Entity entity)
        {
            mcServer.GetEntityTracker(field_28134_b.worldProvider.worldType).TrackEntity(entity);
        }

        public virtual void ReleaseEntitySkin(net.minecraft.src.Entity entity)
        {
            mcServer.GetEntityTracker(field_28134_b.worldProvider.worldType).UntrackEntity(entity);
        }

        public virtual void PlaySound(string s, double d, double d1, double d2, float f, float f1)
        {
        }

        public virtual void MarkBlockRangeNeedsUpdate(int i, int j, int k, int l, int i1, int j1)
        {
        }

        public virtual void UpdateAllRenderers()
        {
        }

        public virtual void MarkBlockNeedsUpdate(int i, int j, int k)
        {
            mcServer.serverConfigurationManager.MarkBlockNeedsUpdate(i, j, k, field_28134_b.worldProvider.worldType);
        }

        public virtual void PlayRecord(string s, int i, int j, int k)
        {
        }

        public virtual void DoNothingWithTileEntity(int i, int j, int k, net.minecraft.src.TileEntity tileentity)
        {
            mcServer.serverConfigurationManager.SentTileEntityToPlayer(i, j, k, tileentity);
        }

        public virtual void SendSoundEffectToAllPlayersWithin64(net.minecraft.src.EntityPlayer entityplayer, int i, int pointX, int pointY, int pointZ, int i1)
        {
            mcServer.serverConfigurationManager.SendPacketToPlayersAroundPoint(entityplayer, pointX, pointY, pointZ, 64D, field_28134_b.worldProvider.worldType, new net.minecraft.src.Packet61SoundEffect(i, pointX, pointY, pointZ, i1));
        }

        private net.minecraft.server.MinecraftServer mcServer;

        private net.minecraft.src.WorldServer field_28134_b;
    }
}
