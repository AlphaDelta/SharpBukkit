// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System;

namespace net.minecraft.src
{
	public class TileEntity
	{
		public TileEntity()
		{
		}

		// Referenced classes of package net.minecraft.src:
		//            NBTTagCompound, World, TileEntityFurnace, TileEntityChest, 
		//            TileEntityRecordPlayer, TileEntityDispenser, TileEntitySign, TileEntityMobSpawner, 
		//            TileEntityNote, TileEntityPiston, Packet
		private static void AddMapping(System.Type class1, string s)
		{
			if (classToNameMap.Contains(s))
			{
				throw new System.ArgumentException((new java.lang.StringBuilder()).Append("Duplicate id: "
					).Append(s).ToString());
			}
			else
			{
				nameToClassMap[s] = class1;
				classToNameMap[class1] = s;
				return;
			}
		}

		public virtual void ReadFromNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			xCoord = nbttagcompound.GetInteger("x");
			yCoord = nbttagcompound.GetInteger("y");
			zCoord = nbttagcompound.GetInteger("z");
		}

		public virtual void WriteToNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			string s = (string)classToNameMap[this.GetType()];
			if (s == null)
			{
				throw new System.Exception((new java.lang.StringBuilder()).Append(this.GetType()).Append(" is missing a mapping! This is a bug!").ToString());
			}
			else
			{
				nbttagcompound.SetString("id", s);
				nbttagcompound.SetInteger("x", xCoord);
				nbttagcompound.SetInteger("y", yCoord);
				nbttagcompound.SetInteger("z", zCoord);
				return;
			}
		}

		public virtual void UpdateEntity()
		{
		}

		public static net.minecraft.src.TileEntity CreateAndLoadEntity(net.minecraft.src.NBTTagCompound
			 nbttagcompound)
		{
			net.minecraft.src.TileEntity tileentity = null;
			try
			{
				System.Type class1 = (System.Type)nameToClassMap[nbttagcompound.GetString
					("id")];
				if (class1 != null)
				{
					tileentity = (net.minecraft.src.TileEntity)Activator.CreateInstance(class1);
				}
			}
			catch (System.Exception exception)
			{
				Sharpen.Runtime.PrintStackTrace(exception);
			}
			if (tileentity != null)
			{
				tileentity.ReadFromNBT(nbttagcompound);
			}
			else
			{
				System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append("Skipping TileEntity with id "
					).Append(nbttagcompound.GetString("id")).ToString());
			}
			return tileentity;
		}

		public virtual int Func_31005_e()
		{
			return worldObj.GetBlockMetadata(xCoord, yCoord, zCoord);
		}

		public virtual void OnInventoryChanged()
		{
			if (worldObj != null)
			{
				worldObj.UpdateTileEntityChunkAndDoNothing(xCoord, yCoord, zCoord, this);
			}
		}

		public virtual net.minecraft.src.Packet GetDescriptionPacket()
		{
			return null;
		}

		public virtual bool IsInvalid()
		{
			return tileEntityInvalid;
		}

		public virtual void Invalidate()
		{
			tileEntityInvalid = true;
		}

		public virtual void Validate()
		{
			tileEntityInvalid = false;
		}

		//internal static System.Type _mthclass(string s)
		//{
		//	try
		//	{
		//		return System.Type.ForName(s);
		//	}
		//	catch (TypeN classnotfoundexception)
		//	{
		//		throw new java.lang.NoClassDefFoundError(classnotfoundexception.Message);
		//	}
		//}

		private static System.Collections.IDictionary nameToClassMap = new System.Collections.Hashtable
			();

		private static System.Collections.IDictionary classToNameMap = new System.Collections.Hashtable
			();

		public net.minecraft.src.World worldObj;

		public int xCoord;

		public int yCoord;

		public int zCoord;

		protected internal bool tileEntityInvalid;

		static TileEntity()
		{
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.TileEntityFurnace
				)), "Furnace");
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.TileEntityChest
				)), "Chest");
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.TileEntityRecordPlayer
				)), "RecordPlayer");
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.TileEntityDispenser
				)), "Trap");
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.TileEntitySign
				)), "Sign");
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.TileEntityMobSpawner
				)), "MobSpawner");
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.TileEntityNote
				)), "Music");
			AddMapping(Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.TileEntityPiston
				)), "Piston");
		}
	}
}
