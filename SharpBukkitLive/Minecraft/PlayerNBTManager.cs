// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System.Collections.Generic;
using System.IO;

namespace net.minecraft.src
{
    public class PlayerNBTManager : net.minecraft.src.IPlayerFileData, net.minecraft.src.ISaveHandler
    {
        public PlayerNBTManager(string file, string s, bool flag)
        {
            // Referenced classes of package net.minecraft.src:
            //            IPlayerFileData, ISaveHandler, MinecraftException, WorldProviderHell, 
            //            ChunkLoader, CompressedStreamTools, NBTTagCompound, WorldInfo, 
            //            EntityPlayer, WorldProvider, IChunkLoader
            worldDir = System.IO.Path.Combine(file, s);
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(worldDir));
            //worldDir.Mkdirs();
            worldFile = System.IO.Path.Combine(worldDir, "players");
            field_28112_d = System.IO.Path.Combine(worldDir, "data");
            //field_28112_d.Mkdirs();
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(field_28112_d));
            if (flag)
            {
                //worldFile.Mkdirs();
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(worldFile));
            }
            Func_22098_f();
        }

        private void Func_22098_f()
        {
            try
            {
                string file = System.IO.Path.Combine(worldDir, "session.lock");

                using (FileStream fs = File.OpenWrite(file))
                {
                    java.io.DataOutputStream dataoutputstream = new java.io.DataOutputStream(fs);
                    try
                    {
                        dataoutputstream.WriteLong(field_22100_d);
                    }
                    finally
                    {
                        dataoutputstream.Close();
                    }
                }
            }
            catch (System.IO.IOException ioexception)
            {
                Sharpen.Runtime.PrintStackTrace(ioexception);
                throw new System.Exception("Failed to check session lock, aborting");
            }
        }

        protected internal virtual string GetWorldDir()
        {
            return worldDir;
        }

        public virtual void Func_22091_b()
        {
            try
            {
                string file = System.IO.Path.Combine(worldDir, "session.lock");
                using (FileStream fs = File.OpenRead(file))
                {
                    java.io.DataInputStream datainputstream = new java.io.DataInputStream(fs);
                    try
                    {
                        if (datainputstream.ReadLong() != field_22100_d)
                        {
                            throw new net.minecraft.src.MinecraftException("The save is being accessed from another location, aborting"
                                );
                        }
                    }
                    finally
                    {
                        datainputstream.Close();
                    }
                }
            }
            catch (System.IO.IOException)
            {
                throw new net.minecraft.src.MinecraftException("Failed to check session lock, aborting"
                    );
            }
        }

        public virtual net.minecraft.src.IChunkLoader Func_22092_a(net.minecraft.src.WorldProvider
             worldprovider)
        {
            if (worldprovider is net.minecraft.src.WorldProviderHell)
            {
                string file = System.IO.Path.Combine(worldDir, "DIM-1");
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(file));
                //file.Mkdirs();
                return new net.minecraft.src.ChunkLoader(file, true);
            }
            else
            {
                return new net.minecraft.src.ChunkLoader(worldDir, true);
            }
        }

        public virtual net.minecraft.src.WorldInfo Func_22096_c()
        {
            string file = System.IO.Path.Combine(worldDir, "level.dat");
            if (File.Exists(file))
            {
                try
                {
                    using (FileStream fs = File.OpenRead(file))
                    {
                        net.minecraft.src.NBTTagCompound nbttagcompound = net.minecraft.src.CompressedStreamTools.Func_770_a(fs);
                        net.minecraft.src.NBTTagCompound nbttagcompound2 = nbttagcompound.GetCompoundTag("Data");
                        return new net.minecraft.src.WorldInfo(nbttagcompound2);
                    }
                }
                catch (System.Exception exception)
                {
                    Sharpen.Runtime.PrintStackTrace(exception);
                }
            }
            file = System.IO.Path.Combine(worldDir, "level.dat_old");
            if (File.Exists(file))
            {
                try
                {
                    using (FileStream fs = File.OpenRead(file))
                    {
                        net.minecraft.src.NBTTagCompound nbttagcompound1 = net.minecraft.src.CompressedStreamTools.Func_770_a(fs);
                        net.minecraft.src.NBTTagCompound nbttagcompound3 = nbttagcompound1.GetCompoundTag("Data");
                        return new net.minecraft.src.WorldInfo(nbttagcompound3);
                    }
                }
                catch (System.Exception exception1)
                {
                    Sharpen.Runtime.PrintStackTrace(exception1);
                }
            }
            return null;
        }

        public virtual void Func_22095_a(net.minecraft.src.WorldInfo worldinfo, List<EntityPlayer> list)
        {
            net.minecraft.src.NBTTagCompound nbttagcompound = worldinfo.Func_22183_a(list);
            net.minecraft.src.NBTTagCompound nbttagcompound1 = new net.minecraft.src.NBTTagCompound
                ();
            nbttagcompound1.SetTag("Data", nbttagcompound);
            try
            {
                string file = System.IO.Path.Combine(worldDir, "level.dat_new");
                string file1 = System.IO.Path.Combine(worldDir, "level.dat_old");
                string file2 = System.IO.Path.Combine(worldDir, "level.dat");
                using (FileStream fs = File.OpenWrite(file))
                    net.minecraft.src.CompressedStreamTools.WriteGzippedCompoundToOutputStream(nbttagcompound1, fs);
                if (File.Exists(file1))
                {
                    File.Delete(file1);
                }
                if (File.Exists(file2))
                {
                    File.Move(file2, file1);
                    //File.Delete(file2);
                }
                if (File.Exists(file))
                {
                    File.Move(file, file2);
                    //File.Delete(file);
                }
            }
            catch (System.Exception exception)
            {
                Sharpen.Runtime.PrintStackTrace(exception);
            }
        }

        public virtual void Func_22094_a(net.minecraft.src.WorldInfo worldinfo)
        {
            net.minecraft.src.NBTTagCompound nbttagcompound = worldinfo.Func_22185_a();
            net.minecraft.src.NBTTagCompound nbttagcompound1 = new net.minecraft.src.NBTTagCompound
                ();
            nbttagcompound1.SetTag("Data", nbttagcompound);
            try
            {
                string file = System.IO.Path.Combine(worldDir, "level.dat_new");
                string file1 = System.IO.Path.Combine(worldDir, "level.dat_old");
                string file2 = System.IO.Path.Combine(worldDir, "level.dat");
                using (FileStream fs = File.OpenWrite(file))
                    net.minecraft.src.CompressedStreamTools.WriteGzippedCompoundToOutputStream(nbttagcompound1, fs);
                if (File.Exists(file1))
                {
                    File.Delete(file1);
                }
                File.Move(file2, file1);
                if (File.Exists(file2))
                {
                    File.Delete(file2);
                }
                File.Move(file, file2);
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
            catch (System.Exception exception)
            {
                Sharpen.Runtime.PrintStackTrace(exception);
            }
        }

        public virtual void WritePlayerData(net.minecraft.src.EntityPlayer entityplayer)
        {
            try
            {
                net.minecraft.src.NBTTagCompound nbttagcompound = new net.minecraft.src.NBTTagCompound
                    ();
                entityplayer.WriteToNBT(nbttagcompound);
                string file = System.IO.Path.Combine(worldFile, "_tmp_.dat");
                string file1 = System.IO.Path.Combine(worldFile, (new java.lang.StringBuilder()).Append(entityplayer.username).Append(".dat").ToString());
                using (FileStream fs = File.OpenRead(file))
                    net.minecraft.src.CompressedStreamTools.WriteGzippedCompoundToOutputStream(nbttagcompound, fs);
                if (File.Exists(file1))
                {
                    File.Delete(file1);
                }
                File.Move(file, file1);
            }
            catch (System.Exception)
            {
                logger.Warning((new java.lang.StringBuilder()).Append("Failed to save player data for "
                    ).Append(entityplayer.username).ToString());
            }
        }

        public virtual void ReadPlayerData(net.minecraft.src.EntityPlayer entityplayer)
        {
            net.minecraft.src.NBTTagCompound nbttagcompound = GetPlayerData(entityplayer.username
                );
            if (nbttagcompound != null)
            {
                entityplayer.ReadFromNBT(nbttagcompound);
            }
        }

        public virtual net.minecraft.src.NBTTagCompound GetPlayerData(string s)
        {
            try
            {
                string file = System.IO.Path.Combine(worldFile, (new java.lang.StringBuilder()).Append(s).Append(".dat").ToString());
                if (File.Exists(file))
                {
                    using (FileStream fs = File.OpenRead(file))
                        return net.minecraft.src.CompressedStreamTools.Func_770_a(fs);
                }
            }
            catch (System.Exception)
            {
                logger.Warning((new java.lang.StringBuilder()).Append("Failed to load player data for "
                    ).Append(s).ToString());
            }
            return null;
        }

        public virtual net.minecraft.src.IPlayerFileData Func_22090_d()
        {
            return this;
        }

        public virtual void Func_22093_e()
        {
        }

        public virtual string Func_28111_b(string s)
        {
            return System.IO.Path.Combine(field_28112_d, (new java.lang.StringBuilder()).Append(s).
                Append(".dat").ToString());
        }

        private static readonly Logger logger = Logger.GetLogger();
        //private static readonly java.util.logging.Logger logger = java.util.logging.Logger.GetLogger("Minecraft");

        private readonly string worldDir;
        private readonly string worldFile;
        private readonly string field_28112_d;

        private readonly long field_22100_d = Sharpen.Runtime.CurrentTimeMillis();
    }
}
