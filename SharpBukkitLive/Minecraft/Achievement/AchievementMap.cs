// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.Properties;
using Sharpen;
using System;

namespace net.minecraft.src
{
    public class AchievementMap
    {
        private AchievementMap()
        {
            field_25133_b = new System.Collections.Hashtable();
            string[] lines = Resources.map.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string[] spl = line.Split(",");
                int i = int.Parse(spl[0]);

                this.field_25133_b.Add(i, spl[1]);
            }
            //try
            //{
            //	java.io.BufferedReader bufferedreader = new java.io.BufferedReader(new java.io.InputStreamReader
            //		((Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.AchievementMap))).GetResourceAsStream
            //		("/achievement/map.txt")));
            //	string s;
            //	while ((s = bufferedreader.ReadLine()) != null)
            //	{
            //		string[] @as = s.Split(",");
            //		int i = System.Convert.ToInt32(@as[0]);
            //		field_25133_b[i] = @as[1];
            //	}
            //	bufferedreader.Close();
            //}
            //catch (System.Exception exception)
            //{
            //	Sharpen.Runtime.PrintStackTrace(exception);
            //}
        }

        public static string Func_25132_a(int i)
        {
            return (string)field_25134_a.field_25133_b[i];
        }

        public static net.minecraft.src.AchievementMap field_25134_a = new net.minecraft.src.AchievementMap
            ();

        private System.Collections.IDictionary field_25133_b;
    }
}
