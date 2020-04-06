// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Text.RegularExpressions;

namespace net.minecraft.src
{
    internal class ChunkFilePattern// : java.io.FilenameFilter
    {
        private ChunkFilePattern()
        {
        }

        // Referenced classes of package net.minecraft.src:
        //            Empty2
        //public virtual bool Accept(string file, string s)
        //{
        //    java.util.regex.Matcher matcher = field_22119_a.Matcher(s);
        //    return matcher.Matches();
        //}

        internal ChunkFilePattern(net.minecraft.src.Empty2 empty2)
            : this()
        {
        }

        public static readonly Regex field_22119_a = new Regex("c\\.(-?[0-9a-z]+)\\.(-?[0-9a-z]+)\\.dat", RegexOptions.Compiled);
    }
}
