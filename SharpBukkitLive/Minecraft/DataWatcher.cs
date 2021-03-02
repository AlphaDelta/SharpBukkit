// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
    public class DataWatcher
    {
        public DataWatcher()
        {
        }

        // Referenced classes of package net.minecraft.src:
        //            WatchableObject, Packet, ItemStack, Item, 
        //            ChunkCoordinates
        public virtual void AddObject(int i, object obj)
        {
            int integer = (int)dataTypes[Sharpen.Runtime.GetClassForObject(obj)];
            if (integer == null)
            {
                throw new System.ArgumentException((new java.lang.StringBuilder()).Append("Unknown data type: "
                    ).Append(Sharpen.Runtime.GetClassForObject(obj)).ToString());
            }
            if (i > 31)
            {
                throw new System.ArgumentException((new java.lang.StringBuilder()).Append("Data value id is too big with "
                    ).Append(i).Append("! (Max is ").Append(31).Append(")").ToString());
            }
            if (watchedObjects.Contains(i))
            {
                throw new System.ArgumentException((new java.lang.StringBuilder()).Append("Duplicate id value for "
                    ).Append(i).Append("!").ToString());
            }
            else
            {
                net.minecraft.src.WatchableObject watchableobject = new net.minecraft.src.WatchableObject
                    (integer, i, obj);
                watchedObjects[i] = watchableobject;
                return;
            }
        }

        public virtual byte GetWatchableObjectByte(int i)
        {
            return ((byte)((net.minecraft.src.WatchableObject)watchedObjects[i]).GetObject
                ());
        }

        public virtual int GetWatchableObjectInteger(int i)
        {
            return ((int)((net.minecraft.src.WatchableObject)watchedObjects[i]).GetObject
                ());
        }

        public virtual string GetWatchableObjectString(int i)
        {
            return (string)((net.minecraft.src.WatchableObject)watchedObjects[i]).
                GetObject();
        }

        public virtual void UpdateObject(int i, object obj)
        {
            net.minecraft.src.WatchableObject watchableobject = (net.minecraft.src.WatchableObject
                )watchedObjects[i];
            if (!obj.Equals(watchableobject.GetObject()))
            {
                watchableobject.SetObject(obj);
                watchableobject.SetWatching(true);
                objectChanged = true;
            }
        }

        public virtual bool HasObjectChanged()
        {
            return objectChanged;
        }

        /// <exception cref="System.IO.IOException"/>
        public static void WriteObjectsInListToStream(List<WatchableObject> list, java.io.DataOutputStream dataoutputstream)
        {
            if (list != null)
            {
                net.minecraft.src.WatchableObject watchableobject;
                for (System.Collections.IEnumerator iterator = list.GetEnumerator(); iterator.MoveNext
                    (); WriteWatchableObject(dataoutputstream, watchableobject))
                {
                    watchableobject = (net.minecraft.src.WatchableObject)iterator.Current;
                }
            }
            dataoutputstream.WriteByte(127);
        }

        public virtual List<WatchableObject> GetChangedObjects()
        {
            List<WatchableObject> arraylist = null;
            if (objectChanged)
            {
                System.Collections.IEnumerator iterator = watchedObjects.Values.GetEnumerator();
                do
                {
                    if (!iterator.MoveNext())
                    {
                        break;
                    }
                    net.minecraft.src.WatchableObject watchableobject = (net.minecraft.src.WatchableObject
                        )iterator.Current;
                    if (watchableobject.GetWatching())
                    {
                        watchableobject.SetWatching(false);
                        if (arraylist == null)
                        {
                            arraylist = new List<WatchableObject>();
                        }
                        arraylist.Add(watchableobject);
                    }
                }
                while (true);
            }
            objectChanged = false;
            return arraylist;
        }

        /// <exception cref="System.IO.IOException"/>
        public virtual void WriteWatchableObjects(java.io.DataOutputStream dataoutputstream
            )
        {
            net.minecraft.src.WatchableObject watchableobject;
            for (System.Collections.IEnumerator iterator = watchedObjects.Values.GetEnumerator
                (); iterator.MoveNext(); WriteWatchableObject(dataoutputstream, watchableobject))
            {
                watchableobject = (net.minecraft.src.WatchableObject)iterator.Current;
            }
            dataoutputstream.WriteByte(127);
        }

        /// <exception cref="System.IO.IOException"/>
        private static void WriteWatchableObject(java.io.DataOutputStream dataoutputstream, net.minecraft.src.WatchableObject watchableobject)
        {
            int i = (watchableobject.GetObjectType() << 5 | watchableobject.GetDataValueId()
                & 0x1f) & 0xff;
            dataoutputstream.WriteByte(i);
            switch (watchableobject.GetObjectType())
            {
                case 0:
                    {
                        // '\0'
                        dataoutputstream.WriteByte(((byte)watchableobject.GetObject()));
                        break;
                    }

                case 1:
                    {
                        // '\001'
                        dataoutputstream.WriteShort(((short)watchableobject.GetObject()));
                        break;
                    }

                case 2:
                    {
                        // '\002'
                        dataoutputstream.WriteInt(((int)watchableobject.GetObject()));
                        break;
                    }

                case 3:
                    {
                        // '\003'
                        dataoutputstream.WriteFloat(((float)watchableobject.GetObject()));
                        break;
                    }

                case 4:
                    {
                        // '\004'
                        net.minecraft.src.Packet.WriteString((string)watchableobject.GetObject(), dataoutputstream
                            );
                        break;
                    }

                case 5:
                    {
                        // '\005'
                        net.minecraft.src.ItemStack itemstack = (net.minecraft.src.ItemStack)watchableobject
                            .GetObject();
                        dataoutputstream.WriteShort(itemstack.GetItem().ID);
                        dataoutputstream.WriteByte(itemstack.stackSize);
                        dataoutputstream.WriteShort(itemstack.GetItemDamage());
                        break;
                    }

                case 6:
                    {
                        // '\006'
                        net.minecraft.src.ChunkCoordinates chunkcoordinates = (net.minecraft.src.ChunkCoordinates
                            )watchableobject.GetObject();
                        dataoutputstream.WriteInt(chunkcoordinates.posX);
                        dataoutputstream.WriteInt(chunkcoordinates.posY);
                        dataoutputstream.WriteInt(chunkcoordinates.posZ);
                        break;
                    }
            }
        }

        /// <exception cref="System.IO.IOException"/>
        public static List<WatchableObject> ReadWatchableObjects(java.io.DataInputStream
             datainputstream)
        {
            List<WatchableObject> arraylist = null;
            for (byte byte0 = datainputstream.ReadByte(); byte0 != 127; byte0 = datainputstream
                .ReadByte())
            {
                if (arraylist == null)
                {
                    arraylist = new List<WatchableObject>();
                }
                int i = (byte0 & 0xe0) >> 5;
                int j = byte0 & 0x1f;
                net.minecraft.src.WatchableObject watchableobject = null;
                switch (i)
                {
                    case 0:
                        {
                            // '\0'
                            watchableobject = new net.minecraft.src.WatchableObject(i, j, datainputstream.ReadByte());
                            break;
                        }

                    case 1:
                        {
                            // '\001'
                            watchableobject = new net.minecraft.src.WatchableObject(i, j, datainputstream.ReadShort());
                            break;
                        }

                    case 2:
                        {
                            // '\002'
                            watchableobject = new net.minecraft.src.WatchableObject(i, j, datainputstream.ReadInt());
                            break;
                        }

                    case 3:
                        {
                            // '\003'
                            watchableobject = new net.minecraft.src.WatchableObject(i, j, datainputstream.ReadFloat());
                            break;
                        }

                    case 4:
                        {
                            // '\004'
                            watchableobject = new net.minecraft.src.WatchableObject(i, j, net.minecraft.src.Packet.ReadString(datainputstream, 64));
                            break;
                        }

                    case 5:
                        {
                            // '\005'
                            short word0 = datainputstream.ReadShort();
                            byte byte1 = datainputstream.ReadByte();
                            short word1 = datainputstream.ReadShort();
                            watchableobject = new net.minecraft.src.WatchableObject(i, j, new net.minecraft.src.ItemStack
                                (word0, byte1, word1));
                            break;
                        }

                    case 6:
                        {
                            // '\006'
                            int k = datainputstream.ReadInt();
                            int l = datainputstream.ReadInt();
                            int i1 = datainputstream.ReadInt();
                            watchableobject = new net.minecraft.src.WatchableObject(i, j, new net.minecraft.src.ChunkCoordinates
                                (k, l, i1));
                            break;
                        }
                }
                arraylist.Add(watchableobject);
            }
            return arraylist;
        }

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

        private static readonly System.Collections.Hashtable dataTypes;

        private readonly System.Collections.IDictionary watchedObjects = new System.Collections.Hashtable
            ();

        private bool objectChanged;

        static DataWatcher()
        {
            dataTypes = new System.Collections.Hashtable();
            dataTypes[Sharpen.Runtime.GetClassForType(typeof(byte))] = 0;
            dataTypes[Sharpen.Runtime.GetClassForType(typeof(short))] = 1;
            dataTypes[Sharpen.Runtime.GetClassForType(typeof(int))] = 2;
            dataTypes[Sharpen.Runtime.GetClassForType(typeof(float))] = 3;
            dataTypes[Sharpen.Runtime.GetClassForType(typeof(string))] = 4;
            dataTypes[Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.ItemStack))] = 5;
            dataTypes[Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.ChunkCoordinates))] = 6;
        }
    }
}
