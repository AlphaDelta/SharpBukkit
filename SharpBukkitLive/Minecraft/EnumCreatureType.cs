// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    [System.Serializable]
    public sealed class EnumCreatureType
    {
        public static readonly net.minecraft.src.EnumCreatureType monster = new net.minecraft.src.EnumCreatureType("monster", 0, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.IMob)), 70, net.minecraft.src.Material.air, false);

        public static readonly net.minecraft.src.EnumCreatureType creature = new net.minecraft.src.EnumCreatureType("creature", 1, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityAnimal)), 15, net.minecraft.src.Material.air, true);

        public static readonly net.minecraft.src.EnumCreatureType waterCreature = new net.minecraft.src.EnumCreatureType("waterCreature", 2, Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityWaterMob)), 5, net.minecraft.src.Material.water, true);

        private EnumCreatureType(string s, int i, System.Type class1, int j, net.minecraft.src.Material
             material, bool flag)
        {
            // Referenced classes of package net.minecraft.src:
            //            IMob, Material, EntityAnimal, EntityWaterMob
            /*

                public static EnumCreatureType valueOf(String s)
                {
                    return (EnumCreatureType)Enum.valueOf(net.minecraft.src.EnumCreatureType.class, s);
                }
            */
            //        super(s, i);
            creatureClass = class1;
            maxNumberOfCreature = j;
            creatureMaterial = material;
            field_21106_g = flag;
        }

        public System.Type GetCreatureClass()
        {
            return creatureClass;
        }

        public int GetMaxNumberOfCreature()
        {
            return maxNumberOfCreature;
        }

        public net.minecraft.src.Material GetCreatureMaterial()
        {
            return creatureMaterial;
        }

        public bool Func_21103_d()
        {
            return field_21106_g;
        }

        private readonly System.Type creatureClass;

        private readonly int maxNumberOfCreature;

        private readonly net.minecraft.src.Material creatureMaterial;

        private readonly bool field_21106_g;

        private static readonly net.minecraft.src.EnumCreatureType[] field_6155_e;
        public static EnumCreatureType[] Values()
        {
            return (EnumCreatureType[])field_6155_e.Clone();
        }

        static EnumCreatureType()
        {
            /*
                public static final EnumCreatureType monster;
                public static final EnumCreatureType creature;
                public static final EnumCreatureType waterCreature;
            */
            /* synthetic field */
            /*
                    monster = new EnumCreatureType("monster", 0, net.minecraft.src.IMob.class, 70, Material.air, false);
                    creature = new EnumCreatureType("creature", 1, net.minecraft.src.EntityAnimal.class, 15, Material.air, true);
                    waterCreature = new EnumCreatureType("waterCreature", 2, net.minecraft.src.EntityWaterMob.class, 5, Material.water, true);
            */
            field_6155_e = (new net.minecraft.src.EnumCreatureType[] { net.minecraft.src.EnumCreatureType
                .monster, net.minecraft.src.EnumCreatureType.creature, net.minecraft.src.EnumCreatureType
                .waterCreature });
        }
    }
}
