// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.IO;
using System.IO.Compression;

namespace net.minecraft.src
{
    public class CompressedStreamTools
    {
        public CompressedStreamTools()
        {
        }

        // Referenced classes of package net.minecraft.src:
        //            NBTBase, NBTTagCompound
        /// <exception cref="System.IO.IOException"/>
        public static net.minecraft.src.NBTTagCompound Func_770_a(Stream inputstream)
        {
            using (Stream s = new GZipStream(inputstream, CompressionMode.Decompress))
            {
                java.io.DataInputStream datainputstream = new java.io.DataInputStream(s);
                try
                {
                    net.minecraft.src.NBTTagCompound nbttagcompound = Func_774_a(datainputstream);
                    return nbttagcompound;
                }
                finally
                {
                    datainputstream.Close();
                }
            }
        }

        /// <exception cref="System.IO.IOException"/>
        public static void WriteGzippedCompoundToOutputStream(net.minecraft.src.NBTTagCompound nbttagcompound, Stream outputstream)
        {
            using (Stream s = new GZipStream(outputstream, CompressionLevel.Fastest))
            {
                java.io.DataOutputStream dataoutputstream = new java.io.DataOutputStream(s);
                try
                {
                    Func_771_a(nbttagcompound, dataoutputstream);
                }
                finally
                {
                    dataoutputstream.Flush();
                    dataoutputstream.Close();
                }
            }
        }

        /// <exception cref="System.IO.IOException"/>
        public static net.minecraft.src.NBTTagCompound Func_774_a(java.io.DataInput datainput)
        {
            net.minecraft.src.NBTBase nbtbase = net.minecraft.src.NBTBase.ReadTag(datainput);
            if (nbtbase is net.minecraft.src.NBTTagCompound)
            {
                return (net.minecraft.src.NBTTagCompound)nbtbase;
            }
            else
            {
                throw new System.IO.IOException("Root tag must be a named compound tag");
            }
        }

        /// <exception cref="System.IO.IOException"/>
        public static void Func_771_a(net.minecraft.src.NBTTagCompound nbttagcompound, java.io.DataOutput
             dataoutput)
        {
            net.minecraft.src.NBTBase.WriteTag(nbttagcompound, dataoutput);
        }
    }
}
