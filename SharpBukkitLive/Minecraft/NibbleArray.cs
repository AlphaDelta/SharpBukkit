// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class NibbleArray
    {
        public NibbleArray(int i)
        {
            data = new byte[i >> 1];
        }

        public NibbleArray(byte[] abyte0)
        {
            data = abyte0;
        }

        //TODO: Seen IndexOutOfRangeException. 64 * 5 TNT test, occurred 5 minutes after explostion. World.DoLighting() -> MetadataChunkBlock.Func_4107_a(World) -> Here???
        public virtual int GetNibble(int i, int j, int k)
        {
            int l = i << 11 | k << 7 | j;
            int i1 = l >> 1;
            int j1 = l & 1;
            if (j1 == 0)
            {
                return data[i1] & unchecked((int)(0xf));
            }
            else
            {
                return data[i1] >> 4 & unchecked((int)(0xf));
            }
        }

        public virtual void SetNibble(int i, int j, int k, int l)
        {
            int i1 = i << 11 | k << 7 | j;
            int j1 = i1 >> 1;
            int k1 = i1 & 1;
            if (k1 == 0)
            {
                data[j1] = unchecked((byte)(data[j1] & unchecked((int)(0xf0)) | l & unchecked((int
                    )(0xf))));
            }
            else
            {
                data[j1] = unchecked((byte)(data[j1] & unchecked((int)(0xf)) | (l & unchecked((int
                    )(0xf))) << 4));
            }
        }

        public virtual bool IsValid()
        {
            return data != null;
        }

        public readonly byte[] data;
    }
}
