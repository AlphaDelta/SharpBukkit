// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive;
using Sharpen;
using System;
using System.Collections.Generic;

namespace net.minecraft.src
{
    public class RegionFileCache
    {
        private RegionFileCache()
        {
        }

        // Referenced classes of package net.minecraft.src:
        //            RegionFile
        public static net.minecraft.src.RegionFile Func_22123_a(string file, int i,
            int j)
        {
            lock (typeof(RegionFileCache))
            {
                string file1 = System.IO.Path.Combine(file, "region");
                string file2 = System.IO.Path.Combine(file1, (new java.lang.StringBuilder()).Append("r.").Append(i >> 5).Append(".").Append(j >> 5).Append(".mcr").ToString());
                WeakReference reference = (WeakReference)field_22125_a[file2];
                if (reference != null && reference.IsAlive)
                {
                    net.minecraft.src.RegionFile regionfile = (net.minecraft.src.RegionFile)reference.Target;
                    if (regionfile != null)
                    {
                        return regionfile;
                    }
                }
                if (!System.IO.File.Exists(file1))
                {
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(file1));
                }
                if (field_22125_a.Count >= 256)
                {
                    Func_22122_a();
                }
                net.minecraft.src.RegionFile regionfile1 = new net.minecraft.src.RegionFile(file2);
                field_22125_a[file2] = new WeakReference(regionfile1);
                return regionfile1;
            }
        }

        public static void Func_22122_a()
        {
            lock (typeof(RegionFileCache))
            {
                System.Collections.IEnumerator iterator = field_22125_a.Values.GetEnumerator();
                do
                {
                    if (!iterator.MoveNext())
                    {
                        break;
                    }
                    WeakReference reference = (WeakReference)iterator.Current;
                    try
                    {
                        net.minecraft.src.RegionFile regionfile = (net.minecraft.src.RegionFile)reference.Target;
                        if (regionfile != null)
                        {
                            regionfile.Close();
                        }
                    }
                    catch (System.IO.IOException ioexception)
                    {
                        Sharpen.Runtime.PrintStackTrace(ioexception);
                    }
                }
                while (true);
                field_22125_a.Clear();
            }
        }

        public static int Func_22121_b(string file, int i, int j)
        {
            net.minecraft.src.RegionFile regionfile = Func_22123_a(file, i, j);
            return regionfile.GetSizeDelta();
        }

        public static java.io.DataInputStream Func_22124_c(string file, int i, int
            j)
        {
            net.minecraft.src.RegionFile regionfile = Func_22123_a(file, i, j);
            return regionfile.GetChunkDataInputStream(i & 0x1f, j & 0x1f);
        }

        public static java.io.DataOutputStream Func_22120_d(string file, int i, int
             j)
        {
            net.minecraft.src.RegionFile regionfile = Func_22123_a(file, i, j);
            return regionfile.GetChunkDataOutputStream(i & 0x1f, j & 0x1f);
        }

        private static readonly SharpBukkitLive.NullSafeDictionary<string, WeakReference> field_22125_a = new NullSafeDictionary<string, WeakReference>();
    }
}
