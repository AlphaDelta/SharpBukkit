// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace net.minecraft.src
{
    internal class NetworkAcceptThread// : java.lang.Thread
    {
        internal NetworkAcceptThread(net.minecraft.src.NetworkListenThread networklistenthread
            , string s, net.minecraft.server.MinecraftServer minecraftserver)
        //: base(s)
        {
            // Referenced classes of package net.minecraft.src:
            //            NetworkListenThread, NetLoginHandler
            NetListenThread = networklistenthread;
            mcServer = minecraftserver;
        }

        public async Task Run()
        {
            System.Collections.Hashtable hashmap = new System.Collections.Hashtable();
            TcpListener Listener = net.minecraft.src.NetworkListenThread.GetListener(NetListenThread);
            Task<Socket> TaskSocket = null;
            while (true)
            {
                if (!NetListenThread.Listening)
                    break;

                try
                {
                    Socket socket = TaskSocket == null ? null : await TaskSocket;
                    TaskSocket = Listener.AcceptSocketAsync(); //SHARP: Concurrent tasks, because it's good practice on blocking code. This will save no time because no other methods actually defer processing back to this task.

                    if (socket != null)
                    {
                        //java.net.InetAddress inetaddress = socket.GetInetAddress();
                        var inetaddress = ((IPEndPoint)socket.RemoteEndPoint);

                        if (hashmap.Contains(inetaddress) && inetaddress.Address.ToString() != "127.0.0.1" && Sharpen.Runtime.CurrentTimeMillis() - ((long)hashmap[inetaddress]) < 5000L)
                        {
                            //Ignore if the player connected in the last 5 seconds.
                            hashmap[inetaddress] = Sharpen.Runtime.CurrentTimeMillis();
                            socket.Close();
                        }
                        else
                        {
                            hashmap[inetaddress] = Sharpen.Runtime.CurrentTimeMillis();
                            net.minecraft.src.NetLoginHandler netloginhandler = new net.minecraft.src.NetLoginHandler(mcServer, socket, "Connection #" + net.minecraft.src.NetworkListenThread.IncrementConnectionCount(NetListenThread));
                            net.minecraft.src.NetworkListenThread.AddPendingConnectionToListenThread(NetListenThread, netloginhandler);
                        }
                    }
                }
                catch (System.IO.IOException ioexception)
                {
                    Sharpen.Runtime.PrintStackTrace(ioexception);
                }
            }
        }

        internal readonly net.minecraft.server.MinecraftServer mcServer;

        internal readonly net.minecraft.src.NetworkListenThread NetListenThread;
        /* synthetic field */
        /* synthetic field */
    }
}
