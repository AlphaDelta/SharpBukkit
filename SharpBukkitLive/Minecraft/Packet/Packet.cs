// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System;
using System.Collections.Generic;

namespace net.minecraft.src
{
    public abstract class Packet
    {
        public Packet()
        {
            // Referenced classes of package net.minecraft.src:
            //            PacketCounter, Packet0KeepAlive, Packet1Login, Packet2Handshake, 
            //            Packet3Chat, Packet4UpdateTime, Packet5PlayerInventory, Packet6SpawnPosition, 
            //            Packet7UseEntity, Packet8UpdateHealth, Packet9Respawn, Packet10Flying, 
            //            Packet11PlayerPosition, Packet12PlayerLook, Packet13PlayerLookMove, Packet14BlockDig, 
            //            Packet15Place, Packet16BlockItemSwitch, Packet17Sleep, Packet18Animation, 
            //            Packet19EntityAction, Packet20NamedEntitySpawn, Packet21PickupSpawn, Packet22Collect, 
            //            Packet23VehicleSpawn, Packet24MobSpawn, Packet25EntityPainting, Packet27Position, 
            //            Packet28EntityVelocity, Packet29DestroyEntity, Packet30Entity, Packet31RelEntityMove, 
            //            Packet32EntityLook, Packet33RelEntityMoveLook, Packet34EntityTeleport, Packet38EntityStatus, 
            //            Packet39AttachEntity, Packet40EntityMetadata, Packet50PreChunk, Packet51MapChunk, 
            //            Packet52MultiBlockChange, Packet53BlockChange, Packet54PlayNoteBlock, Packet60Explosion, 
            //            Packet61DoorChange, Packet70Bed, Packet71Weather, Packet100OpenWindow, 
            //            Packet101CloseWindow, Packet102WindowClick, Packet103SetSlot, Packet104WindowItems, 
            //            Packet105UpdateProgressbar, Packet106Transaction, Packet130UpdateSign, Packet131MapData, 
            //            Packet200Statistic, Packet255KickDisconnect, NetHandler
            isChunkDataPacket = false;
        }

        internal static void AddIdClassMapping(int i, bool flag, bool flag1, System.Type
             class1)
        {
            if (packetIdToClassMap.ContainsKey(i))
            {
                throw new System.ArgumentException((new java.lang.StringBuilder()).Append("Duplicate packet id:"
                    ).Append(i).ToString());
            }
            if (packetClassToIdMap.ContainsKey(class1))
            {
                throw new System.ArgumentException((new java.lang.StringBuilder()).Append("Duplicate packet class:"
                    ).Append(class1).ToString());
            }
            packetIdToClassMap[i] = class1;
            packetClassToIdMap[class1] = i;
            if (flag)
            {
                clientPacketIdList.Add(i);
            }
            if (flag1)
            {
                serverPacketIdList.Add(i);
            }
        }

        public static net.minecraft.src.Packet GetNewPacket(int i)
        {
            try
            {
                System.Type class1 = (System.Type)packetIdToClassMap[i];
                if (class1 == null)
                {
                    return null;
                }
                else
                {
                    return (net.minecraft.src.Packet)Activator.CreateInstance(class1);
                }
            }
            catch (System.Exception exception)
            {
                Sharpen.Runtime.PrintStackTrace(exception);
            }
            System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append("Skipping packet with id "
                ).Append(i).ToString());
            return null;
        }

        public int GetPacketId()
        {
            return ((int)packetClassToIdMap[this.GetType()]);
        }

        /// <exception cref="System.IO.IOException"/>
        public static net.minecraft.src.Packet ReadPacket(java.io.DataInputStream datainputstream
            , bool flag)
        {
            int i = 0;
            net.minecraft.src.Packet packet = null;
            try
            {
                i = datainputstream.Read();
                if (i == -1)
                {
                    return null;
                }
                if (flag && !serverPacketIdList.Contains(i) || !flag && !clientPacketIdList.Contains(i))
                {
                    throw new System.IO.IOException((new java.lang.StringBuilder()).Append("Bad packet id ").Append(i).ToString());
                }
                packet = GetNewPacket(i);
                if (packet == null)
                {
                    throw new System.IO.IOException((new java.lang.StringBuilder()).Append("Bad packet id ").Append(i).ToString());
                }
                packet.ReadPacketData(datainputstream);
            }
            catch (System.IO.EndOfStreamException e)
            {
                System.Console.Out.WriteLine("Reached end of stream");
                return null;
            }
            net.minecraft.src.PacketCounter packetcounter = (net.minecraft.src.PacketCounter)
                packetStats[i];
            if (packetcounter == null)
            {
                packetcounter = new net.minecraft.src.PacketCounter(null);
                packetStats[i] = packetcounter;
            }
            packetcounter.AddPacket(packet.GetPacketSize());
            totalPacketsCount++;
            if (totalPacketsCount % 1000 != 0)
            {
            }
            return packet;
        }

        /// <exception cref="System.IO.IOException"/>
        public static void WritePacket(net.minecraft.src.Packet packet, java.io.DataOutputStream
             dataoutputstream)
        {
            dataoutputstream.Write(packet.GetPacketId());
            packet.WritePacketData(dataoutputstream);
        }

        /// <exception cref="System.IO.IOException"/>
        public static void WriteString(string s, java.io.DataOutputStream dataoutputstream
            )
        {
            if (s.Length > 32767)
            {
                throw new System.IO.IOException("String too big");
            }
            else
            {
                dataoutputstream.WriteShort(s.Length);
                dataoutputstream.WriteChars(s);
                return;
            }
        }

        /// <exception cref="System.IO.IOException"/>
        public static string ReadString(java.io.DataInputStream datainputstream, int i)
        {
            short word0 = datainputstream.ReadShort();
            if (word0 > i)
            {
                throw new System.IO.IOException((new java.lang.StringBuilder()).Append("Received string length longer than maximum allowed ("
                    ).Append(word0).Append(" > ").Append(i).Append(")").ToString());
            }
            if (word0 < 0)
            {
                throw new System.IO.IOException("Received string length is less than zero! Weird string!"
                    );
            }
            java.lang.StringBuilder stringbuilder = new java.lang.StringBuilder();
            for (int j = 0; j < word0; j++)
            {
                stringbuilder.Append(datainputstream.ReadChar());
            }
            return stringbuilder.ToString();
        }

        /// <exception cref="System.IO.IOException"/>
        public abstract void ReadPacketData(java.io.DataInputStream datainputstream);

        /// <exception cref="System.IO.IOException"/>
        public abstract void WritePacketData(java.io.DataOutputStream dataoutputstream);

        public abstract void ProcessPacket(net.minecraft.src.NetHandler nethandler);

        public abstract int GetPacketSize();

        //internal static System.Type _mthclass(string s)
        //{
        //    try
        //    {
        //        return System.Type.ForName(s);
        //    }
        //    catch (System.TypeNotFoundException classnotfoundexception)
        //    {
        //        throw new java.lang.NoClassDefFoundError(classnotfoundexception.Message);
        //    }
        //}

        private static Dictionary<int, Type> packetIdToClassMap = new SharpBukkitLive.NullSafeDictionary<int, Type>();
        private static Dictionary<Type, int> packetClassToIdMap = new Dictionary<Type, int>();

        private static HashSet<int> clientPacketIdList = new HashSet<int>();
        private static HashSet<int> serverPacketIdList = new HashSet<int>();

        public readonly long creationTimeMillis = Sharpen.Runtime.CurrentTimeMillis();

        public bool isChunkDataPacket;

        private static System.Collections.Hashtable packetStats = new System.Collections.Hashtable();

        private static int totalPacketsCount = 0;

        static Packet()
        {
            AddIdClassMapping(0, true, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet0KeepAlive)));
            AddIdClassMapping(1, true, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet1Login)));
            AddIdClassMapping(2, true, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet2Handshake)));
            AddIdClassMapping(3, true, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet3Chat)));
            AddIdClassMapping(4, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet4UpdateTime)));
            AddIdClassMapping(5, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet5PlayerInventory)));
            AddIdClassMapping(6, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet6SpawnPosition)));
            AddIdClassMapping(7, false, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet7UseEntity)));
            AddIdClassMapping(8, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet8UpdateHealth)));
            AddIdClassMapping(9, true, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet9Respawn)));
            AddIdClassMapping(10, true, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet10Flying)));
            AddIdClassMapping(11, true, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet11PlayerPosition)));
            AddIdClassMapping(12, true, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet12PlayerLook)));
            AddIdClassMapping(13, true, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet13PlayerLookMove)));
            AddIdClassMapping(14, false, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet14BlockDig)));
            AddIdClassMapping(15, false, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet15Place)));
            AddIdClassMapping(16, false, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet16BlockItemSwitch)));
            AddIdClassMapping(17, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet17Sleep)));
            AddIdClassMapping(18, true, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet18Animation)));
            AddIdClassMapping(19, false, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet19EntityAction)));
            AddIdClassMapping(20, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet20NamedEntitySpawn)));
            AddIdClassMapping(21, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet21PickupSpawn)));
            AddIdClassMapping(22, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet22Collect)));
            AddIdClassMapping(23, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet23VehicleSpawn)));
            AddIdClassMapping(24, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet24MobSpawn)));
            AddIdClassMapping(25, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet25EntityPainting)));
            AddIdClassMapping(27, false, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet27Position)));
            AddIdClassMapping(28, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet28EntityVelocity)));
            AddIdClassMapping(29, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet29DestroyEntity)));
            AddIdClassMapping(30, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet30Entity)));
            AddIdClassMapping(31, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet31RelEntityMove)));
            AddIdClassMapping(32, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet32EntityLook)));
            AddIdClassMapping(33, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet33RelEntityMoveLook)));
            AddIdClassMapping(34, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet34EntityTeleport)));
            AddIdClassMapping(38, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet38EntityStatus)));
            AddIdClassMapping(39, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet39AttachEntity)));
            AddIdClassMapping(40, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet40EntityMetadata)));
            AddIdClassMapping(50, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet50PreChunk)));
            AddIdClassMapping(51, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet51MapChunk)));
            AddIdClassMapping(52, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet52MultiBlockChange)));
            AddIdClassMapping(53, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet53BlockChange)));
            AddIdClassMapping(54, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet54PlayNoteBlock)));
            AddIdClassMapping(60, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet60Explosion)));
            AddIdClassMapping(61, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet61DoorChange)));
            AddIdClassMapping(70, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet70Bed)));
            AddIdClassMapping(71, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet71Weather)));
            AddIdClassMapping(100, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet100OpenWindow)));
            AddIdClassMapping(101, true, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet101CloseWindow)));
            AddIdClassMapping(102, false, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet102WindowClick)));
            AddIdClassMapping(103, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet103SetSlot)));
            AddIdClassMapping(104, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet104WindowItems)));
            AddIdClassMapping(105, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet105UpdateProgressbar)));
            AddIdClassMapping(106, true, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet106Transaction)));
            AddIdClassMapping(130, true, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet130UpdateSign)));
            AddIdClassMapping(131, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet131MapData)));
            AddIdClassMapping(200, true, false, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet200Statistic)));
            AddIdClassMapping(255, true, true, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.Packet255KickDisconnect)));
        }
    }
}
