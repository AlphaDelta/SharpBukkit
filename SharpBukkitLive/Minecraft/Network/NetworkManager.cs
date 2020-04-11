// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace net.minecraft.src
{
    public class NetworkManager
    {
        /// <exception cref="System.IO.IOException"/>
        public NetworkManager(Socket socket, string s, net.minecraft.src.NetHandler nethandler)
        {
            // Referenced classes of package net.minecraft.src:
            //            NetworkReaderThread, NetworkWriterThread, Packet, NetHandler, 
            //            NetworkMasterThread, ThreadMonitorConnection
            sendQueueLock = new object();
            isRunning = true;
            readPackets = new ConcurrentQueue<Packet>();
            dataPackets = new ConcurrentQueue<Packet>();
            chunkDataPackets = new ConcurrentQueue<Packet>();//java.util.Collections.SynchronizedList(new System.Collections.ArrayList());
            isServerTerminating = false;
            isTerminating = false;
            terminationReason = string.Empty;
            timeSinceLastRead = 0;
            sendQueueByteLength = 0;
            chunkDataSendCounter = 0;
            field_20175_w = 50;
            networkSocket = socket;
            remoteSocketAddress = socket.RemoteEndPoint;//GetRemoteSocketAddress();
            netHandler = nethandler;
            try
            {
                //socket.SetSoTimeout(30000);
                //socket.SetTrafficClass(24);
                socket.ReceiveTimeout = 30000;
                socket.SendTimeout = 30000;
            }
            catch (System.Net.Sockets.SocketException socketexception)
            {
                System.Console.Error.WriteLine(socketexception.Message);
            }
            socketInputStream = new java.io.DataInputStream(new NetworkStream(socket, System.IO.FileAccess.Read));//new java.io.DataInputStream(socket.GetInputStream());
            socketOutputStream = new java.io.DataOutputStream(new NetworkStream(socket, System.IO.FileAccess.Write));//new java.io.DataOutputStream(new java.io.BufferedOutputStream(socket.GetOutputStream(), 5120));
            readThread = new Thread(() => { new net.minecraft.src.NetworkReaderThread(this, (new java.lang.StringBuilder()).Append(s).Append(" read thread").ToString()).Run(); });
            writeThread = new Thread(() => { new net.minecraft.src.NetworkWriterThread(this, (new java.lang.StringBuilder()).Append(s).Append(" write thread").ToString()).Run(); });
            readThread.Start();
            writeThread.Start();
        }

        public virtual void SetNetHandler(net.minecraft.src.NetHandler nethandler)
        {
            netHandler = nethandler;
        }

        public virtual void AddToSendQueue(net.minecraft.src.Packet packet)
        {
            if (isServerTerminating)
            {
                return;
            }
            lock (sendQueueLock)
            {
                sendQueueByteLength += packet.GetPacketSize() + 1;
                if (packet.isChunkDataPacket)
                {
                    chunkDataPackets.Enqueue(packet);
                }
                else
                {
                    dataPackets.Enqueue(packet);
                }
            }
        }

        private bool SendPacket()
        {
            bool flag = false;
            try
            {
                Packet ppeek;
                bool peek;
                bool t = false;
                peek = dataPackets.TryPeek(out ppeek);
                if (dataPackets.Count > 0 && peek
                    && (chunkDataSendCounter == 0 || Sharpen.Runtime.CurrentTimeMillis() - ((net.minecraft.src.Packet)ppeek).creationTimeMillis >= (long)chunkDataSendCounter))
                {
                    net.minecraft.src.Packet packet;
                    lock (sendQueueLock)
                    {
                        t = dataPackets.TryDequeue(out packet);
                        //packet = (net.minecraft.src.Packet)dataPackets.(0);
                        if (t)
                            sendQueueByteLength -= packet.GetPacketSize() + 1;
                    }
                    if (t)
                    {
                        net.minecraft.src.Packet.WritePacket(packet, socketOutputStream);
                        field_28140_e[packet.GetPacketId()] += packet.GetPacketSize() + 1;
                        flag = true;
                    }
                }
                peek = chunkDataPackets.TryPeek(out ppeek);
                if (field_20175_w-- <= 0 && chunkDataPackets.Count > 0 && peek
                    && (chunkDataSendCounter == 0 || Sharpen.Runtime.CurrentTimeMillis() - ((net.minecraft.src.Packet)ppeek).creationTimeMillis >= (long)chunkDataSendCounter))
                {
                    net.minecraft.src.Packet packet1;
                    lock (sendQueueLock)
                    {
                        t = chunkDataPackets.TryDequeue(out packet1);
                        //packet1 = (net.minecraft.src.Packet)
                        if (t)
                            sendQueueByteLength -= packet1.GetPacketSize() + 1;
                    }
                    if (t)
                    {
                        net.minecraft.src.Packet.WritePacket(packet1, socketOutputStream);
                        field_28140_e[packet1.GetPacketId()] += packet1.GetPacketSize() + 1;
                        field_20175_w = 0;
                        flag = true;
                    }
                }
            }
            catch (System.Exception exception)
            {
                if (!isTerminating)
                {
                    OnNetworkError(exception);
                }
                return false;
            }
            return flag;
        }

        public virtual void Func_28138_a()
        {
            readThread.Interrupt();
            writeThread.Interrupt();
        }

        private bool ReadPacket()
        {
            bool flag = false;
            try
            {
                net.minecraft.src.Packet packet = net.minecraft.src.Packet.ReadPacket(socketInputStream
                    , netHandler.IsServerHandler());
                if (packet != null)
                {
                    field_28141_d[packet.GetPacketId()] += packet.GetPacketSize() + 1;
                    readPackets.Enqueue(packet);
                    flag = true;
                }
                else
                {
                    NetworkShutdown("disconnect.endOfStream", new object[0]);
                }
            }
            catch (System.Exception exception)
            {
                if (!isTerminating)
                {
                    OnNetworkError(exception);
                }
                return false;
            }
            return flag;
        }

        private void OnNetworkError(System.Exception exception)
        {
            Sharpen.Runtime.PrintStackTrace(exception);
            NetworkShutdown("disconnect.genericReason", new object[] { (new java.lang.StringBuilder
                ()).Append("Internal exception: ").Append(exception.ToString()).ToString() });
        }

        public virtual void NetworkShutdown(string s, object[] aobj)
        {
            if (!isRunning)
            {
                return;
            }
            isTerminating = true;
            terminationReason = s;
            field_20176_t = aobj;
            Thread t = new Thread(() => { (new net.minecraft.src.NetworkMasterThread(this)).Run(); });
            t.Start();
            //(new net.minecraft.src.NetworkMasterThread(this)).Start();
            isRunning = false;
            try
            {
                socketInputStream.Close();
                socketInputStream = null;
            }
            catch
            {
            }
            try
            {
                socketOutputStream.Close();
                socketOutputStream = null;
            }
            catch
            {
            }
            try
            {
                networkSocket.Close();
                networkSocket = null;
            }
            catch
            {
            }
        }

        public virtual void ProcessReadPackets()
        {
            if (sendQueueByteLength > unchecked((int)(0x100000)))
            {
                NetworkShutdown("disconnect.overflow", new object[0]);
            }
            if (readPackets.Count < 1)
            {
                if (timeSinceLastRead++ == 1200)
                {
                    NetworkShutdown("disconnect.timeout", new object[0]);
                }
            }
            else
            {
                timeSinceLastRead = 0;
            }
            net.minecraft.src.Packet packet;
            for (int i = 100; readPackets.Count > 0 && i >= 0; i--)
            {
                if(readPackets.TryDequeue(out packet))
                    packet.ProcessPacket(netHandler);
                //packet = (net.minecraft.src.Packet)readPackets.Remove(0);
            }
            Func_28138_a();
            if (isTerminating && readPackets.Count < 1)
            {
                netHandler.HandleErrorMessage(terminationReason, field_20176_t);
            }
        }

        public virtual EndPoint GetRemoteAddress()
        {
            return remoteSocketAddress;
        }

        public virtual void ServerShutdown()
        {
            Func_28138_a();
            isServerTerminating = true;
            readThread.Interrupt();
            Thread t = new Thread(() => { new net.minecraft.src.ThreadMonitorConnection(this).Run(); });
            t.Start();
            //(new net.minecraft.src.ThreadMonitorConnection(this)).Start();
        }

        public virtual int GetNumChunkDataPackets()
        {
            return chunkDataPackets.Count;
        }

        internal static bool IsRunning(net.minecraft.src.NetworkManager networkmanager)
        {
            return networkmanager.isRunning;
        }

        internal static bool IsServerTerminating(net.minecraft.src.NetworkManager networkmanager
            )
        {
            return networkmanager.isServerTerminating;
        }

        internal static bool ReadNetworkPacket(net.minecraft.src.NetworkManager networkmanager
            )
        {
            return networkmanager.ReadPacket();
        }

        internal static bool SendNetworkPacket(net.minecraft.src.NetworkManager networkmanager
            )
        {
            return networkmanager.SendPacket();
        }

        internal static java.io.DataOutputStream Func_28136_f(net.minecraft.src.NetworkManager
             networkmanager)
        {
            return networkmanager.socketOutputStream;
        }

        internal static bool Func_28135_e(net.minecraft.src.NetworkManager networkmanager
            )
        {
            return networkmanager.isTerminating;
        }

        internal static void Func_30007_a(net.minecraft.src.NetworkManager networkmanager
            , System.Exception exception)
        {
            networkmanager.OnNetworkError(exception);
        }

        internal static Thread GetReadThread(net.minecraft.src.NetworkManager networkmanager
            )
        {
            return networkmanager.readThread;
        }

        internal static Thread GetWriteThread(net.minecraft.src.NetworkManager
            networkmanager)
        {
            return networkmanager.writeThread;
        }

        public static readonly object threadSyncObject = new object();

        public static int numReadThreads;

        public static int numWriteThreads;

        private object sendQueueLock;

        private Socket networkSocket;

        private readonly EndPoint remoteSocketAddress;

        private java.io.DataInputStream socketInputStream;

        private java.io.DataOutputStream socketOutputStream;

        private bool isRunning;

        private ConcurrentQueue<Packet> readPackets;

        private ConcurrentQueue<Packet> dataPackets;

        private ConcurrentQueue<Packet> chunkDataPackets;

        private net.minecraft.src.NetHandler netHandler;

        private bool isServerTerminating;

        private Thread writeThread;

        private Thread readThread;

        private bool isTerminating;

        private string terminationReason;

        private object[] field_20176_t;

        private int timeSinceLastRead;

        private int sendQueueByteLength;

        public static int[] field_28141_d = new int[256];

        public static int[] field_28140_e = new int[256];

        public int chunkDataSendCounter;

        private int field_20175_w;
    }
}
