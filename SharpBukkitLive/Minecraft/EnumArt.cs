// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    [System.Serializable]
    public sealed class EnumArt
    {
        public static readonly net.minecraft.src.EnumArt Kebab = new net.minecraft.src.EnumArt
            ("Kebab", 0, "Kebab", 16, 16, 0, 0);

        public static readonly net.minecraft.src.EnumArt Aztec = new net.minecraft.src.EnumArt
            ("Aztec", 1, "Aztec", 16, 16, 16, 0);

        public static readonly net.minecraft.src.EnumArt Alban = new net.minecraft.src.EnumArt
            ("Alban", 2, "Alban", 16, 16, 32, 0);

        public static readonly net.minecraft.src.EnumArt Aztec2 = new net.minecraft.src.EnumArt
            ("Aztec2", 3, "Aztec2", 16, 16, 48, 0);

        public static readonly net.minecraft.src.EnumArt Bomb = new net.minecraft.src.EnumArt
            ("Bomb", 4, "Bomb", 16, 16, 64, 0);

        public static readonly net.minecraft.src.EnumArt Plant = new net.minecraft.src.EnumArt
            ("Plant", 5, "Plant", 16, 16, 80, 0);

        public static readonly net.minecraft.src.EnumArt Wasteland = new net.minecraft.src.EnumArt
            ("Wasteland", 6, "Wasteland", 16, 16, 96, 0);

        public static readonly net.minecraft.src.EnumArt Pool = new net.minecraft.src.EnumArt
            ("Pool", 7, "Pool", 32, 16, 0, 32);

        public static readonly net.minecraft.src.EnumArt Courbet = new net.minecraft.src.EnumArt
            ("Courbet", 8, "Courbet", 32, 16, 32, 32);

        public static readonly net.minecraft.src.EnumArt Sea = new net.minecraft.src.EnumArt
            ("Sea", 9, "Sea", 32, 16, 64, 32);

        public static readonly net.minecraft.src.EnumArt Sunset = new net.minecraft.src.EnumArt
            ("Sunset", 10, "Sunset", 32, 16, 96, 32);

        public static readonly net.minecraft.src.EnumArt Creebet = new net.minecraft.src.EnumArt
            ("Creebet", 11, "Creebet", 32, 16, 128, 32);

        public static readonly net.minecraft.src.EnumArt Wanderer = new net.minecraft.src.EnumArt
            ("Wanderer", 12, "Wanderer", 16, 32, 0, 64);

        public static readonly net.minecraft.src.EnumArt Graham = new net.minecraft.src.EnumArt
            ("Graham", 13, "Graham", 16, 32, 16, 64);

        public static readonly net.minecraft.src.EnumArt Match = new net.minecraft.src.EnumArt
            ("Match", 14, "Match", 32, 32, 0, 128);

        public static readonly net.minecraft.src.EnumArt Bust = new net.minecraft.src.EnumArt
            ("Bust", 15, "Bust", 32, 32, 32, 128);

        public static readonly net.minecraft.src.EnumArt Stage = new net.minecraft.src.EnumArt
            ("Stage", 16, "Stage", 32, 32, 64, 128);

        public static readonly net.minecraft.src.EnumArt Void = new net.minecraft.src.EnumArt
            ("Void", 17, "Void", 32, 32, 96, 128);

        public static readonly net.minecraft.src.EnumArt SkullAndRoses = new net.minecraft.src.EnumArt
            ("SkullAndRoses", 18, "SkullAndRoses", 32, 32, 128, 128);

        public static readonly net.minecraft.src.EnumArt Fighters = new net.minecraft.src.EnumArt
            ("Fighters", 19, "Fighters", 64, 32, 0, 96);

        public static readonly net.minecraft.src.EnumArt Pointer = new net.minecraft.src.EnumArt
            ("Pointer", 20, "Pointer", 64, 64, 0, 192);

        public static readonly net.minecraft.src.EnumArt Pigscene = new net.minecraft.src.EnumArt
            ("Pigscene", 21, "Pigscene", 64, 64, 64, 192);

        public static readonly net.minecraft.src.EnumArt BurningSkull = new net.minecraft.src.EnumArt
            ("BurningSkull", 22, "BurningSkull", 64, 64, 128, 192);

        public static readonly net.minecraft.src.EnumArt Skeleton = new net.minecraft.src.EnumArt
            ("Skeleton", 23, "Skeleton", 64, 48, 192, 64);

        public static readonly net.minecraft.src.EnumArt DonkeyKong = new net.minecraft.src.EnumArt
            ("DonkeyKong", 24, "DonkeyKong", 64, 48, 192, 112);

        private EnumArt(string s, int i, string s1, int j, int k, int l, int i1)
        {
            /*

                public static EnumArt valueOf(String s)
                {
                    return (EnumArt)Enum.valueOf(net.minecraft.src.EnumArt.class, s);
                }
            */
            //        super(s, i);
            title = s1;
            sizeX = j;
            sizeY = k;
            offsetX = l;
            offsetY = i1;
        }

        public static readonly int LongestNameLength = "SkullAndRoses".Length;

        public readonly string title;

        public readonly int sizeX;

        public readonly int sizeY;

        public readonly int offsetX;

        public readonly int offsetY;

        private static readonly net.minecraft.src.EnumArt[] field_863_D;
        public static EnumArt[] Values()
        {
            return (EnumArt[])field_863_D.Clone();
        }

        static EnumArt()
        {
            /*
                public static final EnumArt Kebab;
                public static final EnumArt Aztec;
                public static final EnumArt Alban;
                public static final EnumArt Aztec2;
                public static final EnumArt Bomb;
                public static final EnumArt Plant;
                public static final EnumArt Wasteland;
                public static final EnumArt Pool;
                public static final EnumArt Courbet;
                public static final EnumArt Sea;
                public static final EnumArt Sunset;
                public static final EnumArt Creebet;
                public static final EnumArt Wanderer;
                public static final EnumArt Graham;
                public static final EnumArt Match;
                public static final EnumArt Bust;
                public static final EnumArt Stage;
                public static final EnumArt Void;
                public static final EnumArt SkullAndRoses;
                public static final EnumArt Fighters;
                public static final EnumArt Pointer;
                public static final EnumArt Pigscene;
                public static final EnumArt BurningSkull;
                public static final EnumArt Skeleton;
                public static final EnumArt DonkeyKong;
            */
            /* synthetic field */
            /*
                    Kebab = new EnumArt("Kebab", 0, "Kebab", 16, 16, 0, 0);
                    Aztec = new EnumArt("Aztec", 1, "Aztec", 16, 16, 16, 0);
                    Alban = new EnumArt("Alban", 2, "Alban", 16, 16, 32, 0);
                    Aztec2 = new EnumArt("Aztec2", 3, "Aztec2", 16, 16, 48, 0);
                    Bomb = new EnumArt("Bomb", 4, "Bomb", 16, 16, 64, 0);
                    Plant = new EnumArt("Plant", 5, "Plant", 16, 16, 80, 0);
                    Wasteland = new EnumArt("Wasteland", 6, "Wasteland", 16, 16, 96, 0);
                    Pool = new EnumArt("Pool", 7, "Pool", 32, 16, 0, 32);
                    Courbet = new EnumArt("Courbet", 8, "Courbet", 32, 16, 32, 32);
                    Sea = new EnumArt("Sea", 9, "Sea", 32, 16, 64, 32);
                    Sunset = new EnumArt("Sunset", 10, "Sunset", 32, 16, 96, 32);
                    Creebet = new EnumArt("Creebet", 11, "Creebet", 32, 16, 128, 32);
                    Wanderer = new EnumArt("Wanderer", 12, "Wanderer", 16, 32, 0, 64);
                    Graham = new EnumArt("Graham", 13, "Graham", 16, 32, 16, 64);
                    Match = new EnumArt("Match", 14, "Match", 32, 32, 0, 128);
                    Bust = new EnumArt("Bust", 15, "Bust", 32, 32, 32, 128);
                    Stage = new EnumArt("Stage", 16, "Stage", 32, 32, 64, 128);
                    Void = new EnumArt("Void", 17, "Void", 32, 32, 96, 128);
                    SkullAndRoses = new EnumArt("SkullAndRoses", 18, "SkullAndRoses", 32, 32, 128, 128);
                    Fighters = new EnumArt("Fighters", 19, "Fighters", 64, 32, 0, 96);
                    Pointer = new EnumArt("Pointer", 20, "Pointer", 64, 64, 0, 192);
                    Pigscene = new EnumArt("Pigscene", 21, "Pigscene", 64, 64, 64, 192);
                    BurningSkull = new EnumArt("BurningSkull", 22, "BurningSkull", 64, 64, 128, 192);
                    Skeleton = new EnumArt("Skeleton", 23, "Skeleton", 64, 48, 192, 64);
                    DonkeyKong = new EnumArt("DonkeyKong", 24, "DonkeyKong", 64, 48, 192, 112);
            */
            field_863_D = (new net.minecraft.src.EnumArt[] { net.minecraft.src.EnumArt.Kebab,
                net.minecraft.src.EnumArt.Aztec, net.minecraft.src.EnumArt.Alban, net.minecraft.src.EnumArt
                .Aztec2, net.minecraft.src.EnumArt.Bomb, net.minecraft.src.EnumArt.Plant, net.minecraft.src.EnumArt
                .Wasteland, net.minecraft.src.EnumArt.Pool, net.minecraft.src.EnumArt.Courbet, net.minecraft.src.EnumArt
                .Sea, net.minecraft.src.EnumArt.Sunset, net.minecraft.src.EnumArt.Creebet, net.minecraft.src.EnumArt
                .Wanderer, net.minecraft.src.EnumArt.Graham, net.minecraft.src.EnumArt.Match, net.minecraft.src.EnumArt
                .Bust, net.minecraft.src.EnumArt.Stage, net.minecraft.src.EnumArt.Void, net.minecraft.src.EnumArt
                .SkullAndRoses, net.minecraft.src.EnumArt.Fighters, net.minecraft.src.EnumArt.Pointer
                , net.minecraft.src.EnumArt.Pigscene, net.minecraft.src.EnumArt.BurningSkull, net.minecraft.src.EnumArt
                .Skeleton, net.minecraft.src.EnumArt.DonkeyKong });
        }
    }
}
