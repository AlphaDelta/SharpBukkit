// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace net.minecraft.src
{
    public class SaveConverterMcRegion : net.minecraft.src.SaveFormatOld
    {
        public SaveConverterMcRegion(string file)
            : base(file)
        {
        }

        // Referenced classes of package net.minecraft.src:
        //            SaveFormatOld, SaveOldDir, WorldInfo, IProgressUpdate, 
        //            ISaveHandler, ChunkFolderPattern, ChunkFilePattern, ChunkFile, 
        //            RegionFileCache, RegionFile
        public override net.minecraft.src.ISaveHandler Func_22105_a(string s, bool flag)
        {
            return new net.minecraft.src.SaveOldDir(field_22106_a, s, flag);
        }

        public override bool IsOldSaveType(string s)
        {
            net.minecraft.src.WorldInfo worldinfo = GetWorldInfo(s);
            return worldinfo != null && worldinfo.GetVersion() == 0;
        }

        public override bool ConverMapToMCRegion(string s, net.minecraft.src.IProgressUpdate
             iprogressupdate)
        {
            iprogressupdate.SetLoadingProgress(0);
            List<ChunkFile> arraylist = new List<ChunkFile>();
            List<string> arraylist1 = new List<string>();
            List<ChunkFile> arraylist2 = new List<ChunkFile>();
            List<string> arraylist3 = new List<string>();
            string file = System.IO.Path.Combine(field_22106_a, s);
            string file1 = System.IO.Path.Combine(file, "DIM-1");
            System.Console.Out.WriteLine("Scanning folders...");
            Func_22108_a(file, arraylist, arraylist1);
            if (File.Exists(file1))
            {
                Func_22108_a(file1, arraylist2, arraylist3);
            }
            int i = arraylist.Count + arraylist2.Count + arraylist1.Count + arraylist3.Count;
            System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append("Total conversion count is ").Append(i).ToString());
            Func_22107_a(file, arraylist, 0, i, iprogressupdate);
            Func_22107_a(file1, arraylist2, arraylist.Count, i, iprogressupdate);
            net.minecraft.src.WorldInfo worldinfo = GetWorldInfo(s);
            worldinfo.SetVersion(19132);
            net.minecraft.src.ISaveHandler isavehandler = Func_22105_a(s, false);
            isavehandler.Func_22094_a(worldinfo);
            Func_22109_a(arraylist1, arraylist.Count + arraylist2.Count, i, iprogressupdate);
            if (File.Exists(file1))
            {
                Func_22109_a(arraylist3, arraylist.Count + arraylist2.Count + arraylist1.Count, i
                    , iprogressupdate);
            }
            return true;
        }

        private void Func_22108_a(string file, List<ChunkFile> arraylist, List<string> arraylist1)
        {
            //net.minecraft.src.ChunkFolderPattern chunkfolderpattern = new net.minecraft.src.ChunkFolderPattern(null);
            //net.minecraft.src.ChunkFilePattern chunkfilepattern = new net.minecraft.src.ChunkFilePattern(null);
            string[] afile = Directory.GetDirectories(file).Where(x => ChunkFolderPattern.field_22214_a.IsMatch(x)).ToArray();//.ListFiles(chunkfolderpattern);
            string[] afile1 = afile;
            int i = afile1.Length;
            for (int j = 0; j < i; j++)
            {
                string file1 = afile1[j];
                arraylist1.Add(file1);
                string[] afile2 = Directory.GetDirectories(file1).Where(x => ChunkFolderPattern.field_22214_a.IsMatch(x)).ToArray();// file1.ListFiles(chunkfolderpattern);
                string[] afile3 = afile2;
                int k = afile3.Length;
                for (int l = 0; l < k; l++)
                {
                    string file2 = afile3[l];
                    string[] afile4 = Directory.GetFiles(file2).Where(x => ChunkFilePattern.field_22119_a.IsMatch(x)).ToArray();// file2.ListFiles(chunkfilepattern);
                    string[] afile5 = afile4;
                    int i1 = afile5.Length;
                    for (int j1 = 0; j1 < i1; j1++)
                    {
                        string file3 = afile5[j1];
                        arraylist.Add(new net.minecraft.src.ChunkFile(file3));
                    }
                }
            }
        }

        private void Func_22107_a(string file, List<ChunkFile> arraylist, int i, int j, net.minecraft.src.IProgressUpdate iprogressupdate)
        {
            arraylist.Sort();
            byte[] abyte0 = new byte[4096];
            int i1;
            for (System.Collections.IEnumerator iterator = arraylist.GetEnumerator(); iterator
                .MoveNext(); iprogressupdate.SetLoadingProgress(i1))
            {
                net.minecraft.src.ChunkFile chunkfile = (net.minecraft.src.ChunkFile)iterator.Current;
                int k = chunkfile.Func_22205_b();
                int l = chunkfile.Func_22204_c();
                net.minecraft.src.RegionFile regionfile = net.minecraft.src.RegionFileCache.Func_22123_a
                    (file, k, l);
                if (!regionfile.IsChunkSaved(k & unchecked((int)(0x1f)), l & unchecked((int)(0x1f
                    ))))
                {
                    try
                    {
                        using (FileStream fs = File.OpenRead(chunkfile.Func_22207_a()))
                        using (GZipStream ds = new GZipStream(fs, CompressionMode.Decompress))
                        {
                            java.io.DataInputStream datainputstream = new java.io.DataInputStream(ds);
                            //java.io.DataInputStream datainputstream = new java.io.DataInputStream(new java.util.zip.GZIPInputStream(new java.io.FileInputStream(chunkfile.Func_22207_a())));
                            java.io.DataOutputStream dataoutputstream = regionfile.GetChunkDataOutputStream(k & unchecked((int)(0x1f)), l & unchecked((int)(0x1f)));
                            for (int j1 = 0; (j1 = datainputstream.Read(abyte0)) != -1;)
                            {
                                dataoutputstream.Write(abyte0, 0, j1);
                            }
                            dataoutputstream.Close();
                            datainputstream.Close();
                        }
                    }
                    catch (System.IO.IOException ioexception)
                    {
                        Sharpen.Runtime.PrintStackTrace(ioexception);
                    }
                }
                i++;
                i1 = (int)System.Math.Round((100D * (double)i) / (double)j);
            }
            net.minecraft.src.RegionFileCache.Func_22122_a();
        }

        private void Func_22109_a(List<string> arraylist, int i, int j, net.minecraft.src.IProgressUpdate iprogressupdate)
        {
            int k;
            for (System.Collections.IEnumerator iterator = arraylist.GetEnumerator(); iterator
                .MoveNext(); iprogressupdate.SetLoadingProgress(k))
            {
                string file = (string)iterator.Current;
                string[] afile = System.IO.Directory.GetFiles(file);
                Func_22104_a(afile);
                System.IO.File.Delete(file);
                i++;
                k = (int)System.Math.Round((100D * (double)i) / (double)j);
            }
        }
    }
}
