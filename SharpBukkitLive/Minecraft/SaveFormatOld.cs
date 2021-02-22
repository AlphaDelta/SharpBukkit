// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.IO;

namespace net.minecraft.src
{
    public class SaveFormatOld : net.minecraft.src.ISaveFormat
    {
        public SaveFormatOld(string file)
        {
            // Referenced classes of package net.minecraft.src:
            //            ISaveFormat, CompressedStreamTools, NBTTagCompound, WorldInfo, 
            //            PlayerNBTManager, ISaveHandler, IProgressUpdate
            if (!File.Exists(file))
            {
                string dirname = System.IO.Path.GetDirectoryName(file);
                if (!string.IsNullOrWhiteSpace(dirname))
                    Directory.CreateDirectory(dirname);
                //file.Mkdirs();
            }
            field_22106_a = file;
        }

        public virtual net.minecraft.src.WorldInfo GetWorldInfo(string s)
        {
            string file = System.IO.Path.Combine(field_22106_a, s);
            if (!File.Exists(file))
            {
                return null;
            }
            string file1 = System.IO.Path.Combine(file, "level.dat");
            if (File.Exists(file1))
            {
                try
                {
                    using (FileStream stream = File.OpenRead(file1))
                    {
                        net.minecraft.src.NBTTagCompound nbttagcompound = net.minecraft.src.CompressedStreamTools.ReadCompoundFromStream(stream);
                        net.minecraft.src.NBTTagCompound nbttagcompound2 = nbttagcompound.GetCompoundTag("Data");
                        return new net.minecraft.src.WorldInfo(nbttagcompound2);
                    }
                }
                catch (System.Exception exception)
                {
                    Sharpen.Runtime.PrintStackTrace(exception);
                }
            }
            file1 = System.IO.Path.Combine(file, "level.dat_old");
            if (File.Exists(file1))
            {
                try
                {
                    using (FileStream stream = File.OpenRead(file1))
                    {
                        net.minecraft.src.NBTTagCompound nbttagcompound1 = net.minecraft.src.CompressedStreamTools.ReadCompoundFromStream(stream);
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

        protected internal static void Func_22104_a(string[] afile)
        {
            for (int i = 0; i < afile.Length; i++)
            {
                if (Directory.Exists(afile[i]))
                {
                    Func_22104_a(Directory.GetFiles(afile[i]));
                }
                File.Delete(afile[i]);
            }
        }

        public virtual net.minecraft.src.ISaveHandler Func_22105_a(string s, bool flag)
        {
            return new net.minecraft.src.PlayerNBTManager(field_22106_a, s, flag);
        }

        public virtual bool IsOldSaveType(string s)
        {
            return false;
        }

        public virtual bool ConverMapToMCRegion(string s, net.minecraft.src.IProgressUpdate
             iprogressupdate)
        {
            return false;
        }

        protected internal readonly string field_22106_a;
    }
}
