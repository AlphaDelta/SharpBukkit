using Sharpen;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpBukkitLive.SharpBukkit
{
    public class SharpRandom
    {
        Random rng;

        public SharpRandom() { rng = new Random(); }
        public SharpRandom(int i) { SetSeed(i); }
        public SharpRandom(long l) { SetSeed(l); }

        public void SetSeed(int i) { rng = new Random(i); }
        public void SetSeed(long l) { rng = new Random((int)l); }

        public int Next() { return rng.Next(); }
        public int NextInt() { return Next(); }
        public int Next(int i) { return rng.Next(i); }
        public int NextInt(int i) { return Next(i); }
        public int Next(int i, int i2) { return rng.Next(i, i2); }
        public int NextInt(int i, int i2) { return Next(i, i2); }

        public double NextDouble() { return rng.NextDouble(); }
        public float NextFloat() { return (float)NextDouble(); }

        public double NextGaussian(double mu = 0, double sigma = 1)
        {
            var u1 = rng.NextDouble();
            var u2 = rng.NextDouble();

            var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                Math.Sin(2.0 * Math.PI * u2);

            var rand_normal = mu + sigma * rand_std_normal;

            return rand_normal;
        }

        public long NextLong()
        {
            return ((long)rng.Next() << 32) & (long)rng.Next();//(long)(long.MaxValue * rng.NextDouble());
        }

        public bool NextBoolean()
        {
            return rng.NextFloat() >= 0.5;
        }
    }
}
