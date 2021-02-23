// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Threading;

namespace net.minecraft.src
{
    internal class NetworkReaderThread// : java.lang.Thread
    {
        internal NetworkReaderThread(net.minecraft.src.NetworkManager networkmanager, string s)
        //: base(s)
        {
            // Referenced classes of package net.minecraft.src:
            //            NetworkManager
            netManager = networkmanager;
        }

        public void Run()
        {
            lock (net.minecraft.src.NetworkManager.threadSyncObject)
            {
                net.minecraft.src.NetworkManager.numReadThreads++;
            }
            try
            {
                while (net.minecraft.src.NetworkManager.IsRunning(netManager) && !net.minecraft.src.NetworkManager.IsServerTerminating(netManager))
                {
                    try
                    {
                        while (net.minecraft.src.NetworkManager.ReadNetworkPacket(netManager))
                        {
                        }
                        Thread.Sleep(100);
                    }
                    catch (ThreadInterruptedException) { }
                }
            }
            finally
            {
                lock (net.minecraft.src.NetworkManager.threadSyncObject)
                {
                    net.minecraft.src.NetworkManager.numReadThreads--;
                }
            }
        }

        internal readonly net.minecraft.src.NetworkManager netManager;
        /* synthetic field */
    }
}
