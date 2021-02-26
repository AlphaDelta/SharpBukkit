// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System.Net.Sockets;
using System.Threading;

namespace net.minecraft.src
{
    public class NetLoginHandler : net.minecraft.src.NetHandler
    {
        /// <exception cref="System.IO.IOException"/>
        public NetLoginHandler(net.minecraft.server.MinecraftServer minecraftserver, Socket socket, string s)
        {
            // Referenced classes of package net.minecraft.src:
            //            NetHandler, NetworkManager, Packet255KickDisconnect, Packet2Handshake, 
            //            Packet1Login, ThreadLoginVerifier, ServerConfigurationManager, EntityPlayerMP, 
            //            WorldServer, NetServerHandler, WorldProvider, Packet6SpawnPosition, 
            //            ChunkCoordinates, Packet3Chat, NetworkListenThread, Packet4UpdateTime, 
            //            Packet
            finishedProcessing = false;
            loginTimer = 0;
            username = null;
            packet1login = null;
            serverId = string.Empty;
            mcServer = minecraftserver;
            netManager = new net.minecraft.src.NetworkManager(socket, s, this);
            netManager.chunkDataSendCounter = 0;
        }

        public virtual void TryLogin()
        {
            if (packet1login != null)
            {
                DoLogin(packet1login);
                packet1login = null;
            }
            if (loginTimer++ == 600)
            {
                KickUser("Took too long to log in");
            }
            else
            {
                netManager.ProcessReadPackets();
            }
        }

        public virtual void KickUser(string s)
        {
            try
            {
                logger.Info((new java.lang.StringBuilder()).Append("Disconnecting ").Append(GetUserAndIPString
                    ()).Append(": ").Append(s).ToString());
                netManager.AddToSendQueue(new net.minecraft.src.Packet255KickDisconnect(s));
                netManager.ServerShutdown();
                finishedProcessing = true;
            }
            catch (System.Exception exception)
            {
                Sharpen.Runtime.PrintStackTrace(exception);
            }
        }

        public override void HandleHandshake(net.minecraft.src.Packet2Handshake packet2handshake
            )
        {
            if (mcServer.onlineMode)
            {
                serverId = rand.NextLong().ToString("X");
                netManager.AddToSendQueue(new net.minecraft.src.Packet2Handshake(serverId));
            }
            else
            {
                netManager.AddToSendQueue(new net.minecraft.src.Packet2Handshake("-"));
            }
        }

        public override void HandleLogin(net.minecraft.src.Packet1Login packet1login)
        {
            username = packet1login.username;
            if (packet1login.protocolVersion != 14)
            {
                if (packet1login.protocolVersion > 14)
                {
                    KickUser("Outdated server!");
                }
                else
                {
                    KickUser("Outdated client!");
                }
                return;
            }
            if (!mcServer.onlineMode)
            {
                DoLogin(packet1login);
            }
            else
            {
                Thread t = new Thread(() => (new net.minecraft.src.ThreadLoginVerifier(this, packet1login)).Run());
                t.Start();
                //(new net.minecraft.src.ThreadLoginVerifier(this, packet1login)).Start();
            }
        }

        public virtual void DoLogin(net.minecraft.src.Packet1Login packet1login)
        {
            net.minecraft.src.EntityPlayerMP entityplayermp = mcServer.configManager.Login(this, packet1login.username);
            if (entityplayermp != null)
            {
                mcServer.configManager.ReadPlayerDataFromFile(entityplayermp);
                entityplayermp.SetWorldHandler(mcServer.GetWorldManager(entityplayermp.dimension));

                //TODO: Cleanup all java.lang.StringBuilder instances
                //logger.Info((new java.lang.StringBuilder()).Append(GetUserAndIPString()).Append(" logged in with entity id ").Append(entityplayermp.entityId).Append(" at (").Append(entityplayermp.posX).Append(", ").Append(entityplayermp.posY).Append(", ").Append(entityplayermp.posZ).Append(")").ToString());
                logger.Info($"{GetUserAndIPString()} logged in with entity id {entityplayermp.entityId} at ({entityplayermp.posX}, {entityplayermp.posY}, {entityplayermp.posZ})");

                net.minecraft.src.WorldServer worldserver = mcServer.GetWorldManager(entityplayermp.dimension);
                net.minecraft.src.ChunkCoordinates chunkcoordinates = worldserver.GetSpawnPoint();
                net.minecraft.src.NetServerHandler netserverhandler = new net.minecraft.src.NetServerHandler(mcServer, netManager, entityplayermp);

                netserverhandler.SendPacket(new net.minecraft.src.Packet1Login(string.Empty, entityplayermp.entityId, worldserver.GetRandomSeed(), unchecked((byte)worldserver.worldProvider.worldType)));
                netserverhandler.SendPacket(new net.minecraft.src.Packet6SpawnPosition(chunkcoordinates.posX, chunkcoordinates.posY, chunkcoordinates.posZ));

                mcServer.configManager.Func_28170_a(entityplayermp, worldserver);

                //TODO: Defer login message to hook
                //mcServer.configManager.SendPacketToAllPlayers(new net.minecraft.src.Packet3Chat((new java.lang.StringBuilder()).Append("\xf7e").Append(entityplayermp.username).Append(" joined the game.").ToString()));
                mcServer.configManager.SendPacketToAllPlayers(new net.minecraft.src.Packet3Chat($"§e{entityplayermp.username} joined the game."));
                mcServer.configManager.PlayerLoggedIn(entityplayermp);

                netserverhandler.TeleportTo(entityplayermp.posX, entityplayermp.posY, entityplayermp.posZ, entityplayermp.rotationYaw, entityplayermp.rotationPitch);
                mcServer.networkServer.AddPlayer(netserverhandler);

                netserverhandler.SendPacket(new net.minecraft.src.Packet4UpdateTime(worldserver.GetWorldTime()));

                entityplayermp.Func_20057_k();
            }
            finishedProcessing = true;
        }

        public override void HandleErrorMessage(string s, object[] aobj)
        {
            //logger.Info((new java.lang.StringBuilder()).Append(GetUserAndIPString()).Append(" lost connection").ToString());
            logger.Info($"{GetUserAndIPString()} lost connection");
            finishedProcessing = true;
        }

        public override void RegisterPacket(net.minecraft.src.Packet packet)
        {
            KickUser("Protocol error");
        }

        public virtual string GetUserAndIPString()
        {
            if (username != null)
            {
                //return (new java.lang.StringBuilder()).Append(username).Append(" [").Append(netManager.GetRemoteAddress().ToString()).Append("]").ToString();
                return $"{username} [{netManager.GetRemoteAddress()}]";
            }
            else
            {
                return netManager.GetRemoteAddress().ToString();
            }
        }

        public override bool IsServerHandler()
        {
            return true;
        }

        internal static string GetServerId(net.minecraft.src.NetLoginHandler netloginhandler
            )
        {
            return netloginhandler.serverId;
        }

        internal static net.minecraft.src.Packet1Login SetLoginPacket(net.minecraft.src.NetLoginHandler
             netloginhandler, net.minecraft.src.Packet1Login packet1login)
        {
            return netloginhandler.packet1login = packet1login;
        }

        public static Logger logger = Logger.GetLogger();

        private static SharpBukkitLive.SharpBukkit.SharpRandom rand = new SharpBukkitLive.SharpBukkit.SharpRandom();

        public net.minecraft.src.NetworkManager netManager;

        public bool finishedProcessing;

        private net.minecraft.server.MinecraftServer mcServer;

        private int loginTimer;

        private string username;

        private net.minecraft.src.Packet1Login packet1login;

        private string serverId;
    }
}
