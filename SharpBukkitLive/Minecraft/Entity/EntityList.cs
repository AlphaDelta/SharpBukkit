// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EntityList
	{
		public EntityList()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            World, Entity, NBTTagCompound, EntityArrow, 
		//            EntitySnowball, EntityItem, EntityPainting, EntityLiving, 
		//            EntityMob, EntityCreeper, EntitySkeleton, EntitySpider, 
		//            EntityGiantZombie, EntityZombie, EntitySlime, EntityGhast, 
		//            EntityPigZombie, EntityPig, EntitySheep, EntityCow, 
		//            EntityChicken, EntitySquid, EntityWolf, EntityTNTPrimed, 
		//            EntityFallingSand, EntityMinecart, EntityBoat
		private static void AddMapping(System.Type class1, string s, int i)
		{
			stringToClassMapping[s] = class1;
			classToStringMapping[class1] = s;
			IDtoClassMapping[i] = class1;
			classToIDMapping[class1] = i;
		}

		public static net.minecraft.src.Entity CreateEntityInWorld(string s, net.minecraft.src.World
			 world)
		{
			net.minecraft.src.Entity entity = null;
			try
			{
				System.Type class1 = (System.Type)stringToClassMapping[s];
				if (class1 != null)
				{
					entity = (net.minecraft.src.Entity)class1.GetConstructor(new System.Type[] { Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.World)) }).Invoke(new object[] { world });
				}
			}
			catch (System.Exception exception)
			{
				Sharpen.Runtime.PrintStackTrace(exception);
			}
			return entity;
		}

		public static net.minecraft.src.Entity CreateEntityFromNBT(net.minecraft.src.NBTTagCompound
			 nbttagcompound, net.minecraft.src.World world)
		{
			net.minecraft.src.Entity entity = null;
			try
			{
				System.Type class1 = (System.Type)stringToClassMapping[nbttagcompound.GetString
					("id")];
				if (class1 != null)
				{
					entity = (net.minecraft.src.Entity)class1.GetConstructor(new System.Type[] { Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.World)) }).Invoke(new object[] { world });
				}
			}
			catch (System.Exception exception)
			{
				Sharpen.Runtime.PrintStackTrace(exception);
			}
			if (entity != null)
			{
				entity.ReadFromNBT(nbttagcompound);
			}
			else
			{
				System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append("Skipping Entity with id "
					).Append(nbttagcompound.GetString("id")).ToString());
			}
			return entity;
		}

		public static int GetEntityID(net.minecraft.src.Entity entity)
		{
			return ((int)classToIDMapping[Sharpen.Runtime.GetClassForObject(entity)]);
		}

		public static string GetEntityString(net.minecraft.src.Entity entity)
		{
			return (string)classToStringMapping[Sharpen.Runtime.GetClassForObject(entity)];
		}

		private static System.Collections.IDictionary stringToClassMapping = new System.Collections.Hashtable
			();

		private static System.Collections.IDictionary classToStringMapping = new System.Collections.Hashtable
			();

		private static System.Collections.IDictionary IDtoClassMapping = new System.Collections.Hashtable
			();

		private static System.Collections.IDictionary classToIDMapping = new System.Collections.Hashtable
			();

		static EntityList()
		{
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityArrow))
				, "Arrow", 10);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntitySnowball
				)), "Snowball", 11);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityItem)), 
				"Item", 1);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityPainting
				)), "Painting", 9);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityLiving)
				), "Mob", 48);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityMob)), 
				"Monster", 49);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityCreeper
				)), "Creeper", 50);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntitySkeleton
				)), "Skeleton", 51);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntitySpider)
				), "Spider", 52);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityGiantZombie
				)), "Giant", 53);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityZombie)
				), "Zombie", 54);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntitySlime))
				, "Slime", 55);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityGhast))
				, "Ghast", 56);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityPigZombie
				)), "PigZombie", 57);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityPig)), 
				"Pig", 90);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntitySheep))
				, "Sheep", 91);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityCow)), 
				"Cow", 92);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityChicken
				)), "Chicken", 93);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntitySquid))
				, "Squid", 94);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityWolf)), 
				"Wolf", 95);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityTNTPrimed
				)), "PrimedTnt", 20);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityFallingSand
				)), "FallingSand", 21);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityMinecart
				)), "Minecart", 40);
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.EntityBoat)), 
				"Boat", 41);
		}
	}
}
