// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System.Collections.Generic;
using System.IO;

namespace net.minecraft.src
{
    public class ServerConfigurationManager
    {
        public ServerConfigurationManager(net.minecraft.server.MinecraftServer minecraftserver
            )
        {
            // Referenced classes of package net.minecraft.src:
            //            PlayerManager, PropertyManager, WorldServer, ISaveHandler, 
            //            EntityPlayerMP, ChunkProviderServer, IPlayerFileData, NetLoginHandler, 
            //            NetworkManager, NetServerHandler, ItemInWorldManager, EntityTracker, 
            //            EntityPlayer, ChunkCoordinates, Packet70Bed, Packet9Respawn, 
            //            Teleporter, Packet3Chat, Packet4UpdateTime, Packet, 
            //            TileEntity
            playerEntities = new List<EntityPlayerMP>();
            bannedPlayers = new HashSet<string>();
            bannedIPs = new HashSet<string>();
            ops = new HashSet<string>();
            whiteListedIPs = new HashSet<string>();
            playerManagerObj = new net.minecraft.src.PlayerManager[2];
            mcServer = minecraftserver;
            bannedPlayersFile = minecraftserver.GetFile("banned-players.txt");
            ipBanFile = minecraftserver.GetFile("banned-ips.txt");
            opFile = minecraftserver.GetFile("ops.txt");
            whitelistPlayersFile = minecraftserver.GetFile("white-list.txt");
            int i = minecraftserver.propertyManagerObj.GetIntProperty("view-distance", 10);
            playerManagerObj[0] = new net.minecraft.src.PlayerManager(minecraftserver, 0, i);
            playerManagerObj[1] = new net.minecraft.src.PlayerManager(minecraftserver, -1, i);
            maxPlayers = minecraftserver.propertyManagerObj.GetIntProperty("max-players", 20);
            whiteListEnforced = minecraftserver.propertyManagerObj.GetBooleanProperty("white-list"
                , false);
            ReadBannedPlayers();
            LoadBannedList();
            LoadOps();
            LoadWhiteList();
            WriteBannedPlayers();
            SaveBannedList();
            SaveOps();
            SaveWhiteList();
        }

        public virtual void SetPlayerManager(net.minecraft.src.WorldServer[] aworldserver
            )
        {
            playerNBTManagerObj = aworldserver[0].GetWorldFile().Func_22090_d();
        }

        public virtual void Func_28172_a(net.minecraft.src.EntityPlayerMP entityplayermp)
        {
            playerManagerObj[0].RemovePlayer(entityplayermp);
            playerManagerObj[1].RemovePlayer(entityplayermp);
            GetPlayerManager(entityplayermp.dimension).AddPlayer(entityplayermp);
            net.minecraft.src.WorldServer worldserver = mcServer.GetWorldManager(entityplayermp
                .dimension);
            worldserver.chunkProviderServer.LoadChunk((int)entityplayermp.posX >> 4, (int)entityplayermp
                .posZ >> 4);
        }

        public virtual int GetMaxTrackingDistance()
        {
            return playerManagerObj[0].GetMaxTrackingDistance();
        }

        private net.minecraft.src.PlayerManager GetPlayerManager(int i)
        {
            return i != -1 ? playerManagerObj[0] : playerManagerObj[1];
        }

        public virtual void ReadPlayerDataFromFile(net.minecraft.src.EntityPlayerMP entityplayermp
            )
        {
            playerNBTManagerObj.ReadPlayerData(entityplayermp);
        }

        public virtual void PlayerLoggedIn(net.minecraft.src.EntityPlayerMP entityplayermp
            )
        {
            playerEntities.Add(entityplayermp);
            net.minecraft.src.WorldServer worldserver = mcServer.GetWorldManager(entityplayermp
                .dimension);
            worldserver.chunkProviderServer.LoadChunk((int)entityplayermp.posX >> 4, (int)entityplayermp
                .posZ >> 4);
            for (; worldserver.GetCollidingBoundingBoxes(entityplayermp, entityplayermp.boundingBox
                ).Count != 0; entityplayermp.SetPosition(entityplayermp.posX, entityplayermp.posY
                 + 1.0D, entityplayermp.posZ))
            {
            }
            worldserver.EntityJoinedWorld(entityplayermp);
            GetPlayerManager(entityplayermp.dimension).AddPlayer(entityplayermp);
        }

        public virtual void Func_613_b(net.minecraft.src.EntityPlayerMP entityplayermp)
        {
            GetPlayerManager(entityplayermp.dimension).Func_543_c(entityplayermp);
        }

        public virtual void PlayerLoggedOut(net.minecraft.src.EntityPlayerMP entityplayermp
            )
        {
            playerNBTManagerObj.WritePlayerData(entityplayermp);
            mcServer.GetWorldManager(entityplayermp.dimension).RemovePlayerForLogoff(entityplayermp
                );
            playerEntities.Remove(entityplayermp);
            GetPlayerManager(entityplayermp.dimension).RemovePlayer(entityplayermp);
        }

        public virtual net.minecraft.src.EntityPlayerMP Login(net.minecraft.src.NetLoginHandler
             netloginhandler, string s)
        {
            if (bannedPlayers.Contains(s.Trim().ToLower()))
            {
                netloginhandler.KickUser("You are banned from this server!");
                return null;
            }
            if (!IsAllowedToLogin(s))
            {
                netloginhandler.KickUser("You are not white-listed on this server!");
                return null;
            }
            string s1 = netloginhandler.netManager.GetRemoteAddress().ToString();
            s1 = s1.Substring(s1.IndexOf("/") + 1);
            s1 = s1.Substring(0, s1.IndexOf(":"));
            if (bannedIPs.Contains(s1))
            {
                netloginhandler.KickUser("Your IP address is banned from this server!");
                return null;
            }
            if (playerEntities.Count >= maxPlayers)
            {
                netloginhandler.KickUser("The server is full!");
                return null;
            }
            for (int i = 0; i < playerEntities.Count; i++)
            {
                net.minecraft.src.EntityPlayerMP entityplayermp = (net.minecraft.src.EntityPlayerMP
                    )playerEntities[i];
                if (entityplayermp.username.Equals(s, System.StringComparison.OrdinalIgnoreCase))
                {
                    entityplayermp.playerNetServerHandler.KickPlayer("You logged in from another location"
                        );
                }
            }
            return new net.minecraft.src.EntityPlayerMP(mcServer, mcServer.GetWorldManager(0)
                , s, new net.minecraft.src.ItemInWorldManager(mcServer.GetWorldManager(0)));
        }

        public virtual net.minecraft.src.EntityPlayerMP RecreatePlayerEntity(net.minecraft.src.EntityPlayerMP
             entityplayermp, int i)
        {
            mcServer.GetEntityTracker(entityplayermp.dimension).RemoveTrackedPlayerSymmetric(
                entityplayermp);
            mcServer.GetEntityTracker(entityplayermp.dimension).UntrackEntity(entityplayermp);
            GetPlayerManager(entityplayermp.dimension).RemovePlayer(entityplayermp);
            playerEntities.Remove(entityplayermp);
            mcServer.GetWorldManager(entityplayermp.dimension).RemovePlayer(entityplayermp);
            net.minecraft.src.ChunkCoordinates chunkcoordinates = entityplayermp.GetSpawnChunk
                ();
            entityplayermp.dimension = i;
            net.minecraft.src.EntityPlayerMP entityplayermp1 = new net.minecraft.src.EntityPlayerMP
                (mcServer, mcServer.GetWorldManager(entityplayermp.dimension), entityplayermp.username
                , new net.minecraft.src.ItemInWorldManager(mcServer.GetWorldManager(entityplayermp
                .dimension)));
            entityplayermp1.entityId = entityplayermp.entityId;
            entityplayermp1.playerNetServerHandler = entityplayermp.playerNetServerHandler;
            net.minecraft.src.WorldServer worldserver = mcServer.GetWorldManager(entityplayermp
                .dimension);
            if (chunkcoordinates != null)
            {
                net.minecraft.src.ChunkCoordinates chunkcoordinates1 = net.minecraft.src.EntityPlayer
                    .Func_25051_a(mcServer.GetWorldManager(entityplayermp.dimension), chunkcoordinates
                    );
                if (chunkcoordinates1 != null)
                {
                    entityplayermp1.SetLocationAndAngles((float)chunkcoordinates1.posX + 0.5F, (float
                        )chunkcoordinates1.posY + 0.1F, (float)chunkcoordinates1.posZ + 0.5F, 0.0F, 0.0F
                        );
                    entityplayermp1.SetSpawnChunk(chunkcoordinates);
                }
                else
                {
                    entityplayermp1.playerNetServerHandler.SendPacket(new net.minecraft.src.Packet70Bed
                        (0));
                }
            }
            worldserver.chunkProviderServer.LoadChunk((int)entityplayermp1.posX >> 4, (int)entityplayermp1
                .posZ >> 4);
            for (; worldserver.GetCollidingBoundingBoxes(entityplayermp1, entityplayermp1.boundingBox
                ).Count != 0; entityplayermp1.SetPosition(entityplayermp1.posX, entityplayermp1.
                posY + 1.0D, entityplayermp1.posZ))
            {
            }
            entityplayermp1.playerNetServerHandler.SendPacket(new net.minecraft.src.Packet9Respawn
                (unchecked((byte)entityplayermp1.dimension)));
            entityplayermp1.playerNetServerHandler.TeleportTo(entityplayermp1.posX, entityplayermp1
                .posY, entityplayermp1.posZ, entityplayermp1.rotationYaw, entityplayermp1.rotationPitch
                );
            Func_28170_a(entityplayermp1, worldserver);
            GetPlayerManager(entityplayermp1.dimension).AddPlayer(entityplayermp1);
            worldserver.EntityJoinedWorld(entityplayermp1);
            playerEntities.Add(entityplayermp1);
            entityplayermp1.Func_20057_k();
            entityplayermp1.Func_22068_s();
            return entityplayermp1;
        }

        public virtual void SendPlayerToOtherDimension(net.minecraft.src.EntityPlayerMP entityplayermp
            )
        {
            net.minecraft.src.WorldServer worldserver = mcServer.GetWorldManager(entityplayermp
                .dimension);
            int i = 0;
            if (entityplayermp.dimension == -1)
            {
                i = 0;
            }
            else
            {
                i = -1;
            }
            entityplayermp.dimension = i;
            net.minecraft.src.WorldServer worldserver1 = mcServer.GetWorldManager(entityplayermp
                .dimension);
            entityplayermp.playerNetServerHandler.SendPacket(new net.minecraft.src.Packet9Respawn
                (unchecked((byte)entityplayermp.dimension)));
            worldserver.RemovePlayer(entityplayermp);
            entityplayermp.isDead = false;
            double d = entityplayermp.posX;
            double d1 = entityplayermp.posZ;
            double d2 = 8D;
            if (entityplayermp.dimension == -1)
            {
                d /= d2;
                d1 /= d2;
                entityplayermp.SetLocationAndAngles(d, entityplayermp.posY, d1, entityplayermp.rotationYaw
                    , entityplayermp.rotationPitch);
                if (entityplayermp.IsEntityAlive())
                {
                    worldserver.UpdateEntityWithOptionalForce(entityplayermp, false);
                }
            }
            else
            {
                d *= d2;
                d1 *= d2;
                entityplayermp.SetLocationAndAngles(d, entityplayermp.posY, d1, entityplayermp.rotationYaw
                    , entityplayermp.rotationPitch);
                if (entityplayermp.IsEntityAlive())
                {
                    worldserver.UpdateEntityWithOptionalForce(entityplayermp, false);
                }
            }
            if (entityplayermp.IsEntityAlive())
            {
                worldserver1.EntityJoinedWorld(entityplayermp);
                entityplayermp.SetLocationAndAngles(d, entityplayermp.posY, d1, entityplayermp.rotationYaw
                    , entityplayermp.rotationPitch);
                worldserver1.UpdateEntityWithOptionalForce(entityplayermp, false);
                worldserver1.chunkProviderServer.chunkLoadOverride = true;
                (new net.minecraft.src.Teleporter()).SetExitLocation(worldserver1, entityplayermp
                    );
                worldserver1.chunkProviderServer.chunkLoadOverride = false;
            }
            Func_28172_a(entityplayermp);
            entityplayermp.playerNetServerHandler.TeleportTo(entityplayermp.posX, entityplayermp
                .posY, entityplayermp.posZ, entityplayermp.rotationYaw, entityplayermp.rotationPitch
                );
            entityplayermp.SetWorldHandler(worldserver1);
            Func_28170_a(entityplayermp, worldserver1);
            Func_30008_g(entityplayermp);
        }

        public virtual void OnTick()
        {
            for (int i = 0; i < playerManagerObj.Length; i++)
            {
                playerManagerObj[i].UpdatePlayerInstances();
            }
        }

        public virtual void MarkBlockNeedsUpdate(int i, int j, int k, int l)
        {
            GetPlayerManager(l).MarkBlockNeedsUpdate(i, j, k);
        }

        public virtual void SendPacketToAllPlayers(net.minecraft.src.Packet packet)
        {
            for (int i = 0; i < playerEntities.Count; i++)
            {
                net.minecraft.src.EntityPlayerMP entityplayermp = (net.minecraft.src.EntityPlayerMP
                    )playerEntities[i];
                entityplayermp.playerNetServerHandler.SendPacket(packet);
            }
        }

        public virtual void SendPacketToAllPlayersInDimension(net.minecraft.src.Packet packet
            , int i)
        {
            for (int j = 0; j < playerEntities.Count; j++)
            {
                net.minecraft.src.EntityPlayerMP entityplayermp = (net.minecraft.src.EntityPlayerMP
                    )playerEntities[j];
                if (entityplayermp.dimension == i)
                {
                    entityplayermp.playerNetServerHandler.SendPacket(packet);
                }
            }
        }

        public virtual string GetPlayerList()
        {
            string s = string.Empty;
            for (int i = 0; i < playerEntities.Count; i++)
            {
                if (i > 0)
                {
                    s = (new java.lang.StringBuilder()).Append(s).Append(", ").ToString();
                }
                s = (new java.lang.StringBuilder()).Append(s).Append(((net.minecraft.src.EntityPlayerMP
                    )playerEntities[i]).username).ToString();
            }
            return s;
        }

        public virtual void BanPlayer(string s)
        {
            bannedPlayers.Add(s.ToLower());
            WriteBannedPlayers();
        }

        public virtual void PardonPlayer(string s)
        {
            bannedPlayers.Remove(s.ToLower());
            WriteBannedPlayers();
        }

        private void ReadBannedPlayers()
        {
            try
            {
                bannedPlayers.Clear();

                string[] entries = File.ReadAllLines(bannedPlayersFile);
                foreach (string s in entries)
                {
                    string e = s.Trim().ToLower();
                    if (e.Length > 0)
                        bannedPlayers.Add(e);
                }
                //java.io.BufferedReader bufferedreader = new java.io.BufferedReader(new java.io.FileReader
                //	(bannedPlayersFile));
                //for (string s = string.Empty; (s = bufferedreader.ReadLine()) != null; )
                //{
                //	bannedPlayers.Add(s.Trim().ToLower());
                //}
                //bufferedreader.Close();
            }
            catch (System.Exception exception)
            {
                logger.Warning((new java.lang.StringBuilder()).Append("Failed to load ban list: "
                    ).Append(exception).ToString());
            }
        }

        private void WriteBannedPlayers()
        {
            try
            {
                //java.io.PrintWriter printwriter = new java.io.PrintWriter(new java.io.FileWriter(bannedPlayersFile, false));
                //string s;
                //for (System.Collections.IEnumerator iterator = bannedPlayers.GetEnumerator(); iterator
                //	.MoveNext(); printwriter.Println(s))
                //{
                //	s = (string)iterator.Current;
                //}
                //printwriter.Close();
                File.WriteAllLines(bannedPlayersFile, bannedPlayers);
            }
            catch (System.Exception exception)
            {
                logger.Warning((new java.lang.StringBuilder()).Append("Failed to save ban list: "
                    ).Append(exception).ToString());
            }
        }

        public virtual void BanIP(string s)
        {
            bannedIPs.Add(s.ToLower());
            SaveBannedList();
        }

        public virtual void PardonIP(string s)
        {
            bannedIPs.Remove(s.ToLower());
            SaveBannedList();
        }

        private void LoadBannedList()
        {
            try
            {
                bannedIPs.Clear();

                string[] entries = File.ReadAllLines(ipBanFile);
                foreach (string s in entries)
                {
                    string e = s.Trim().ToLower();
                    if (e.Length > 0)
                        bannedIPs.Add(e);
                }
                //java.io.BufferedReader bufferedreader = new java.io.BufferedReader(new java.io.FileReader
                //	(ipBanFile));
                //for (string s = string.Empty; (s = bufferedreader.ReadLine()) != null; )
                //{
                //	bannedIPs.Add(s.Trim().ToLower());
                //}
                //bufferedreader.Close();
            }
            catch (System.Exception exception)
            {
                logger.Warning((new java.lang.StringBuilder()).Append("Failed to load ip ban list: "
                    ).Append(exception).ToString());
            }
        }

        private void SaveBannedList()
        {
            try
            {
                //java.io.PrintWriter printwriter = new java.io.PrintWriter(new java.io.FileWriter(
                //	ipBanFile, false));
                //string s;
                //for (System.Collections.IEnumerator iterator = bannedIPs.GetEnumerator(); iterator
                //	.MoveNext(); printwriter.Println(s))
                //{
                //	s = (string)iterator.Current;
                //}
                //printwriter.Close();
                File.WriteAllLines(ipBanFile, bannedIPs);
            }
            catch (System.Exception exception)
            {
                logger.Warning((new java.lang.StringBuilder()).Append("Failed to save ip ban list: "
                    ).Append(exception).ToString());
            }
        }

        public virtual void OpPlayer(string s)
        {
            ops.Add(s.ToLower());
            SaveOps();
        }

        public virtual void DeopPlayer(string s)
        {
            ops.Remove(s.ToLower());
            SaveOps();
        }

        private void LoadOps()
        {
            try
            {
                ops.Clear();

                string[] entries = File.ReadAllLines(opFile);
                foreach (string s in entries)
                {
                    string e = s.Trim().ToLower();
                    if (e.Length > 0)
                        ops.Add(e);
                }
                //java.io.BufferedReader bufferedreader = new java.io.BufferedReader(new java.io.FileReader
                //	(opFile));
                //for (string s = string.Empty; (s = bufferedreader.ReadLine()) != null; )
                //{
                //	ops.Add(s.Trim().ToLower());
                //}
                //bufferedreader.Close();
            }
            catch (System.Exception exception)
            {
                logger.Warning((new java.lang.StringBuilder()).Append("Failed to load ip ban list: "
                    ).Append(exception).ToString());
            }
        }

        private void SaveOps()
        {
            try
            {
                //java.io.PrintWriter printwriter = new java.io.PrintWriter(new java.io.FileWriter(
                //	opFile, false));
                //string s;
                //for (System.Collections.IEnumerator iterator = ops.GetEnumerator(); iterator.MoveNext
                //	(); printwriter.Println(s))
                //{
                //	s = (string)iterator.Current;
                //}
                //printwriter.Close();
                File.WriteAllLines(opFile, ops);
            }
            catch (System.Exception exception)
            {
                logger.Warning((new java.lang.StringBuilder()).Append("Failed to save ip ban list: "
                    ).Append(exception).ToString());
            }
        }

        private void LoadWhiteList()
        {
            try
            {
                whiteListedIPs.Clear();
                //java.io.BufferedReader bufferedreader = new java.io.BufferedReader(new java.io.FileReader(whitelistPlayersFile));
                string[] entries = File.ReadAllLines(whitelistPlayersFile);
                foreach (string s in entries)
                {
                    string e = s.Trim().ToLower();
                    if (e.Length > 0)
                        whiteListedIPs.Add(e);
                }
                //bufferedreader.Close();
            }
            catch (System.Exception exception)
            {
                logger.Warning((new java.lang.StringBuilder()).Append("Failed to load white-list: "
                    ).Append(exception).ToString());
            }
        }

        private void SaveWhiteList()
        {
            try
            {
                //java.io.PrintWriter printwriter = new java.io.PrintWriter(new java.io.FileWriter(whitelistPlayersFile, false));
                //string s;
                //for (System.Collections.IEnumerator iterator = whiteListedIPs.GetEnumerator(); iterator
                //	.MoveNext(); printwriter.Println(s))
                //{
                //	s = (string)iterator.Current;
                //}
                //printwriter.Close();
                File.WriteAllLines(whitelistPlayersFile, whiteListedIPs);
            }
            catch (System.Exception exception)
            {
                logger.Warning((new java.lang.StringBuilder()).Append("Failed to save white-list: "
                    ).Append(exception).ToString());
            }
        }

        public virtual bool IsAllowedToLogin(string s)
        {
            s = s.Trim().ToLower();
            return !whiteListEnforced || ops.Contains(s) || whiteListedIPs.Contains(s);
        }

        public virtual bool IsOp(string s)
        {
            return ops.Contains(s.Trim().ToLower());
        }

        public virtual net.minecraft.src.EntityPlayerMP GetPlayerEntity(string s)
        {
            for (int i = 0; i < playerEntities.Count; i++)
            {
                net.minecraft.src.EntityPlayerMP entityplayermp = playerEntities[i];
                if (entityplayermp.username.Equals(s, System.StringComparison.OrdinalIgnoreCase))
                {
                    return entityplayermp;
                }
            }
            return null;
        }

        public virtual void SendChatMessageToPlayer(string s, string s1)
        {
            net.minecraft.src.EntityPlayerMP entityplayermp = GetPlayerEntity(s);
            if (entityplayermp != null)
            {
                entityplayermp.playerNetServerHandler.SendPacket(new net.minecraft.src.Packet3Chat(s1));
            }
        }

        public virtual void SendPacketToPlayersAroundPoint(double x, double y, double z
            , double radius, int dimension, net.minecraft.src.Packet packet)
        {
            SendPacketToPlayersAroundPoint(null, x, y, z, radius, dimension, packet);
        }

        public virtual void SendPacketToPlayersAroundPoint(net.minecraft.src.EntityPlayer entityplayer, double
             pointX, double pointY, double pointZ, double radius, int dimension, net.minecraft.src.Packet packet)
        {
            for (int j = 0; j < playerEntities.Count; j++)
            {
                net.minecraft.src.EntityPlayerMP entityplayermp = (net.minecraft.src.EntityPlayerMP
                    )playerEntities[j];
                if (entityplayermp == entityplayer || entityplayermp.dimension != dimension)
                {
                    continue;
                }
                double deltaX = pointX - entityplayermp.posX;
                double deltaY = pointY - entityplayermp.posY;
                double deltaZ = pointZ - entityplayermp.posZ;
                if (deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ < radius * radius)
                {
                    entityplayermp.playerNetServerHandler.SendPacket(packet);
                }
            }
        }

        public virtual void SendChatMessageToAllOps(string s)
        {
            net.minecraft.src.Packet3Chat packet3chat = new net.minecraft.src.Packet3Chat(s);
            for (int i = 0; i < playerEntities.Count; i++)
            {
                net.minecraft.src.EntityPlayerMP entityplayermp = (net.minecraft.src.EntityPlayerMP
                    )playerEntities[i];
                if (IsOp(entityplayermp.username))
                {
                    entityplayermp.playerNetServerHandler.SendPacket(packet3chat);
                }
            }
        }

        public virtual bool SendPacketToPlayer(string s, net.minecraft.src.Packet packet)
        {
            net.minecraft.src.EntityPlayerMP entityplayermp = GetPlayerEntity(s);
            if (entityplayermp != null)
            {
                entityplayermp.playerNetServerHandler.SendPacket(packet);
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual void SavePlayerStates()
        {
            for (int i = 0; i < playerEntities.Count; i++)
            {
                playerNBTManagerObj.WritePlayerData((net.minecraft.src.EntityPlayer)playerEntities[i]);
            }
        }

        public virtual void SentTileEntityToPlayer(int i, int j, int k, net.minecraft.src.TileEntity tileentity)
        {
        }

        public virtual void AddToWhiteList(string s)
        {
            whiteListedIPs.Add(s);
            SaveWhiteList();
        }

        public virtual void RemoveFromWhiteList(string s)
        {
            whiteListedIPs.Remove(s);
            SaveWhiteList();
        }

        public virtual HashSet<string> GetWhiteListedIPs()
        {
            return whiteListedIPs;
        }

        public virtual void ReloadWhiteList()
        {
            LoadWhiteList();
        }

        public virtual void Func_28170_a(net.minecraft.src.EntityPlayerMP entityplayermp,
            net.minecraft.src.WorldServer worldserver)
        {
            entityplayermp.playerNetServerHandler.SendPacket(new net.minecraft.src.Packet4UpdateTime
                (worldserver.GetWorldTime()));
            if (worldserver.Func_27068_v())
            {
                entityplayermp.playerNetServerHandler.SendPacket(new net.minecraft.src.Packet70Bed
                    (1));
            }
        }

        public virtual void Func_30008_g(net.minecraft.src.EntityPlayerMP entityplayermp)
        {
            entityplayermp.Func_28017_a(entityplayermp.personalCraftingInventory);
            entityplayermp.Func_30001_B();
        }

        public static Logger logger = Logger.GetLogger();
        //public static java.util.logging.Logger logger = java.util.logging.Logger.GetLogger("Minecraft");

        public List<EntityPlayerMP> playerEntities;

        private net.minecraft.server.MinecraftServer mcServer;

        private net.minecraft.src.PlayerManager[] playerManagerObj;

        private int maxPlayers;

        private HashSet<string> bannedPlayers;

        private HashSet<string> bannedIPs;

        private HashSet<string> ops;

        private HashSet<string> whiteListedIPs;

        private string bannedPlayersFile;

        private string ipBanFile;

        private string opFile;

        private string whitelistPlayersFile;

        private net.minecraft.src.IPlayerFileData playerNBTManagerObj;

        private bool whiteListEnforced;
    }
}
