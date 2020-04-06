using SharpBukkitLive.SharpBukkit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sharpen
{
    public static class Runtime
    {
        public static Type GetClassForType(Type t) { return t; }

        public static double NextGaussian(this Random r, double mu = 0, double sigma = 1)
        {
            var u1 = r.NextDouble();
            var u2 = r.NextDouble();

            var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                Math.Sin(2.0 * Math.PI * u2);

            var rand_normal = mu + sigma * rand_std_normal;

            return rand_normal;
        }

        internal static Type GetClassForObject(object obj)
        {
            return obj.GetType();
        }

        public static float NextFloat(this Random r)
        {
            return (float)r.NextDouble();
        }

        public static void PrintStackTrace(Exception exception)
        {
            Logger.GetLogger().Warning(exception.ToString());
        }

        public static long CurrentTimeMillis()
        {
            return DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public static void RemoveAll(this IList c, IEnumerable i)
        {
            foreach (object t in i)
                c.Remove(t);
        }
    }
}

namespace java.lang
{
    public class StringBuilder
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        public StringBuilder()
        {

        }

        public StringBuilder Append(string s)
        {
            sb.Append(s);
            return this;
        }

        public StringBuilder Append(object s)
        {
            sb.Append(s.ToString());
            return this;
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}