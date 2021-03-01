// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace net.minecraft.src
{
    public class NetworkListenThread
    {
        /// <exception cref="System.IO.IOException"/>
        public NetworkListenThread(net.minecraft.server.MinecraftServer minecraftserver, IPAddress inetaddress, int i)
        {
            // Referenced classes of package net.minecraft.src:
            //            NetworkAcceptThread, NetLoginHandler, NetworkManager, NetServerHandler
            Listening = false;
            ConnectionCount = 0;
            pendingConnections = new List<NetHandler>();
            playerList = new List<NetHandler>();
            mcServer = minecraftserver;
            if (inetaddress != null)
                serverSocket = new TcpListener(inetaddress, i);//new java.net.ServerSocket(i, 0, inetaddress);
            else
                serverSocket = new TcpListener(IPAddress.Any, i);

            serverSocket.Start();
            //serverSocket.SetPerformancePreferences(0, 2, 1);
            Listening = true;
            networkAcceptThread = new Thread(() =>
            {
                _ = (new net.minecraft.src.NetworkAcceptThread(this, "Listen thread", minecraftserver)).Run(); //SHARP: There really is no reason to await a task that will never realistically finish, so we just ignore the await warning by discarding the task with the '_' discard variable
            });
            networkAcceptThread.Start();
        }

        public virtual void AddPlayer(net.minecraft.src.NetServerHandler netserverhandler)
        {
            playerList.Add(netserverhandler);
        }

        private void AddPendingConnection(net.minecraft.src.NetLoginHandler netloginhandler)
        {
            if (netloginhandler == null)
            {
                throw new System.ArgumentException("Got null pendingconnection!");
            }
            else
            {
                pendingConnections.Add(netloginhandler);
                return;
            }
        }

        public virtual void HandleNetworkListenThread()
        {
            for (int i = 0; i < pendingConnections.Count; i++)
            {
                net.minecraft.src.NetLoginHandler netloginhandler = (net.minecraft.src.NetLoginHandler)pendingConnections[i];
                try
                {
                    netloginhandler.TryLogin();
                }
                catch (System.Exception exception)
                {
                    netloginhandler.KickUser("Internal server error");
                    logger.Warning((new java.lang.StringBuilder()).Append("Failed to handle packet: ").Append(exception).ToString());
                    logger.Log(exception.ToString());
                }
                if (netloginhandler.finishedProcessing)
                {
                    pendingConnections.RemoveAt(i--);
                }
                netloginhandler.netManager.InterruptThreads();
            }
            for (int j = 0; j < playerList.Count; j++)
            {
                net.minecraft.src.NetServerHandler netserverhandler = (net.minecraft.src.NetServerHandler)playerList[j];
                try
                {
                    netserverhandler.HandlePackets();
                }
                catch (System.Exception exception1)
                {
                    logger.Warning((new java.lang.StringBuilder()).Append("Failed to handle packet: ").Append(exception1).ToString());
                    logger.Log(exception1.ToString());
                    netserverhandler.KickPlayer("Internal server error");
                }
                if (netserverhandler.disconnected)
                {
                    playerList.RemoveAt(j--);
                }
                netserverhandler.netManager.InterruptThreads();
            }
        }

        internal static TcpListener GetListener(net.minecraft.src.NetworkListenThread networklistenthread)
        {
            return networklistenthread.serverSocket;
        }

        internal static int IncrementConnectionCount(net.minecraft.src.NetworkListenThread networklistenthread
            )
        {
            return networklistenthread.ConnectionCount++;
        }

        internal static void AddPendingConnectionToListenThread(net.minecraft.src.NetworkListenThread networklistenthread, net.minecraft.src.NetLoginHandler netloginhandler)
        {
            networklistenthread.AddPendingConnection(netloginhandler);
        }

        public static Logger logger = Logger.GetLogger();

        private TcpListener serverSocket;

        private Thread networkAcceptThread;

        public volatile bool Listening;

        private int ConnectionCount;

        private List<NetHandler> pendingConnections;

        private List<NetHandler> playerList;

        public net.minecraft.server.MinecraftServer mcServer;
    }
}
