// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;
using System.IO;

namespace net.minecraft.src
{
	public class MapStorage
	{
		public MapStorage(net.minecraft.src.ISaveHandler isavehandler)
		{
			// Referenced classes of package net.minecraft.src:
			//            MapDataBase, ISaveHandler, CompressedStreamTools, NBTTagCompound, 
			//            NBTBase, NBTTagShort
			field_28179_b = new SharpBukkitLive.NullSafeDictionary<string, MapDataBase>();
			field_28182_c = new List<MapDataBase>();
			field_28181_d = new Dictionary<string, short>();
			field_28180_a = isavehandler;
			Func_28174_b();
		}

		public virtual net.minecraft.src.MapDataBase Func_28178_a(System.Type class1, 
			string s)
		{
			net.minecraft.src.MapDataBase mapdatabase = (net.minecraft.src.MapDataBase)field_28179_b
				[s];
			if (mapdatabase != null)
			{
				return mapdatabase;
			}
			if (field_28180_a != null)
			{
				try
				{
					string file = field_28180_a.Func_28111_b(s);
					if (file != null && File.Exists(file))
					{
						try
						{
							mapdatabase = (net.minecraft.src.MapDataBase)class1.GetConstructor(new System.Type
								[] { Sharpen.Runtime.GetClassForType(typeof(string)) }).Invoke(new object[] { s });
						}
						catch (System.Exception exception1)
						{
							throw new System.Exception((new java.lang.StringBuilder()).Append("Failed to instantiate "
								).Append(class1.ToString()).ToString(), exception1);
						}
						//java.io.FileInputStream fileinputstream = new java.io.FileInputStream(file);
						net.minecraft.src.NBTTagCompound nbttagcompound;
						using (FileStream fileinputstream = File.OpenRead(file))
							nbttagcompound = net.minecraft.src.CompressedStreamTools
								.Func_770_a(fileinputstream);
						mapdatabase.Func_28148_a(nbttagcompound.GetCompoundTag("data"));
					}
				}
				catch (System.Exception exception)
				{
					Sharpen.Runtime.PrintStackTrace(exception);
				}
			}
			if (mapdatabase != null)
			{
				field_28179_b[s] = mapdatabase;
				field_28182_c.Add(mapdatabase);
			}
			return mapdatabase;
		}

		public virtual void Func_28177_a(string s, net.minecraft.src.MapDataBase mapdatabase
			)
		{
			if (mapdatabase == null)
			{
				throw new System.Exception("Can't set null data");
			}
			if (field_28179_b.ContainsKey(s))
			{
				var x = field_28179_b[s];
				field_28179_b.Remove(s);
				field_28182_c.Remove(x);
			}
			field_28179_b[s] = mapdatabase;
			field_28182_c.Add(mapdatabase);
		}

		public virtual void Func_28176_a()
		{
			for (int i = 0; i < field_28182_c.Count; i++)
			{
				net.minecraft.src.MapDataBase mapdatabase = (net.minecraft.src.MapDataBase)field_28182_c
					[i];
				if (mapdatabase.Func_28150_b())
				{
					Func_28175_a(mapdatabase);
					mapdatabase.Func_28149_a(false);
				}
			}
		}

		private void Func_28175_a(net.minecraft.src.MapDataBase mapdatabase)
		{
			if (field_28180_a == null)
			{
				return;
			}
			try
			{
				string file = field_28180_a.Func_28111_b(mapdatabase.field_28152_a);
				if (file != null)
				{
					net.minecraft.src.NBTTagCompound nbttagcompound = new net.minecraft.src.NBTTagCompound
						();
					mapdatabase.Func_28147_b(nbttagcompound);
					net.minecraft.src.NBTTagCompound nbttagcompound1 = new net.minecraft.src.NBTTagCompound
						();
					nbttagcompound1.SetCompoundTag("data", nbttagcompound);
					using (FileStream fileoutputstream = File.OpenWrite(file))
						net.minecraft.src.CompressedStreamTools.WriteGzippedCompoundToOutputStream(nbttagcompound1
							, fileoutputstream);
				}
			}
			catch (System.Exception exception)
			{
				Sharpen.Runtime.PrintStackTrace(exception);
			}
		}

		private void Func_28174_b()
		{
			try
			{
				field_28181_d.Clear();
				if (field_28180_a == null)
				{
					return;
				}
				string file = field_28180_a.Func_28111_b("idcounts");
				if (file != null && File.Exists(file))
				{
					java.io.DataInputStream datainputstream = new java.io.DataInputStream(File.OpenRead(file));
					net.minecraft.src.NBTTagCompound nbttagcompound = net.minecraft.src.CompressedStreamTools
						.Func_774_a(datainputstream);
					datainputstream.Close();
					System.Collections.IEnumerator iterator = nbttagcompound.Func_28107_c().GetEnumerator
						();
					do
					{
						if (!iterator.MoveNext())
						{
							break;
						}
						net.minecraft.src.NBTBase nbtbase = (net.minecraft.src.NBTBase)iterator.Current;
						if (nbtbase is net.minecraft.src.NBTTagShort)
						{
							net.minecraft.src.NBTTagShort nbttagshort = (net.minecraft.src.NBTTagShort)nbtbase;
							string s = nbttagshort.GetKey();
							short word0 = nbttagshort.shortValue;
							field_28181_d[s] = word0;
						}
					}
					while (true);
				}
			}
			catch (System.Exception exception)
			{
				Sharpen.Runtime.PrintStackTrace(exception);
			}
		}

		public virtual int Func_28173_a(string s)
		{
			short short1 = (short)field_28181_d[s];
			if (short1 == null)
			{
				short1 = (short)0;
			}
			else
			{
				short short2 = short1;
				short short3 = short1 = (short)(short1 + 1);
				short _tmp = short2;
			}
			field_28181_d[s] = short1;
			if (field_28180_a == null)
			{
				return short1;
			}
			try
			{
				string file = field_28180_a.Func_28111_b("idcounts");
				if (file != null)
				{
					net.minecraft.src.NBTTagCompound nbttagcompound = new net.minecraft.src.NBTTagCompound
						();
					string s1;
					short word0;
					for (System.Collections.IEnumerator iterator = field_28181_d.Keys.GetEnumerator()
						; iterator.MoveNext(); nbttagcompound.SetShort(s1, word0))
					{
						s1 = (string)iterator.Current;
						word0 = ((short)field_28181_d[s1]);
					}
					java.io.DataOutputStream dataoutputstream = new java.io.DataOutputStream(File.OpenWrite(file));
					net.minecraft.src.CompressedStreamTools.Func_771_a(nbttagcompound, dataoutputstream);
					dataoutputstream.Close();
				}
			}
			catch (System.Exception exception)
			{
				Sharpen.Runtime.PrintStackTrace(exception);
			}
			return short1;
		}

		private net.minecraft.src.ISaveHandler field_28180_a;

		private Dictionary<string, MapDataBase> field_28179_b;

		private List<MapDataBase> field_28182_c;

		private Dictionary<string, short> field_28181_d;
	}
}
