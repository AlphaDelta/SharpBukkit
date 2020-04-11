// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
	public class WorldInfo
	{
		public WorldInfo(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			// Referenced classes of package net.minecraft.src:
			//            NBTTagCompound, EntityPlayer
			randomSeed = nbttagcompound.GetLong("RandomSeed");
			spawnX = nbttagcompound.GetInteger("SpawnX");
			spawnY = nbttagcompound.GetInteger("SpawnY");
			spawnZ = nbttagcompound.GetInteger("SpawnZ");
			worldTime = nbttagcompound.GetLong("Time");
			lastTimePlayed = nbttagcompound.GetLong("LastPlayed");
			sizeOnDisk = nbttagcompound.GetLong("SizeOnDisk");
			levelName = nbttagcompound.GetString("LevelName");
			saveVersion = nbttagcompound.GetInteger("version");
			rainTime = nbttagcompound.GetInteger("rainTime");
			isRaining = nbttagcompound.GetBoolean("raining");
			thunderTime = nbttagcompound.GetInteger("thunderTime");
			isThundering = nbttagcompound.GetBoolean("thundering");
			if (nbttagcompound.HasKey("Player"))
			{
				field_22195_h = nbttagcompound.GetCompoundTag("Player");
				field_22194_i = field_22195_h.GetInteger("Dimension");
			}
		}

		public WorldInfo(long l, string s)
		{
			randomSeed = l;
			levelName = s;
		}

		public WorldInfo(net.minecraft.src.WorldInfo worldinfo)
		{
			randomSeed = worldinfo.randomSeed;
			spawnX = worldinfo.spawnX;
			spawnY = worldinfo.spawnY;
			spawnZ = worldinfo.spawnZ;
			worldTime = worldinfo.worldTime;
			lastTimePlayed = worldinfo.lastTimePlayed;
			sizeOnDisk = worldinfo.sizeOnDisk;
			field_22195_h = worldinfo.field_22195_h;
			field_22194_i = worldinfo.field_22194_i;
			levelName = worldinfo.levelName;
			saveVersion = worldinfo.saveVersion;
			rainTime = worldinfo.rainTime;
			isRaining = worldinfo.isRaining;
			thunderTime = worldinfo.thunderTime;
			isThundering = worldinfo.isThundering;
		}

		public virtual net.minecraft.src.NBTTagCompound Func_22185_a()
		{
			net.minecraft.src.NBTTagCompound nbttagcompound = new net.minecraft.src.NBTTagCompound
				();
			SaveNBTTag(nbttagcompound, field_22195_h);
			return nbttagcompound;
		}

		public virtual net.minecraft.src.NBTTagCompound Func_22183_a(List<EntityPlayer> list)
		{
			net.minecraft.src.NBTTagCompound nbttagcompound = new net.minecraft.src.NBTTagCompound
				();
			net.minecraft.src.EntityPlayer entityplayer = null;
			net.minecraft.src.NBTTagCompound nbttagcompound1 = null;
			if (list.Count > 0)
			{
				entityplayer = (net.minecraft.src.EntityPlayer)list[0];
			}
			if (entityplayer != null)
			{
				nbttagcompound1 = new net.minecraft.src.NBTTagCompound();
				entityplayer.WriteToNBT(nbttagcompound1);
			}
			SaveNBTTag(nbttagcompound, nbttagcompound1);
			return nbttagcompound;
		}

		private void SaveNBTTag(net.minecraft.src.NBTTagCompound nbttagcompound, net.minecraft.src.NBTTagCompound
			 nbttagcompound1)
		{
			nbttagcompound.SetLong("RandomSeed", randomSeed);
			nbttagcompound.SetInteger("SpawnX", spawnX);
			nbttagcompound.SetInteger("SpawnY", spawnY);
			nbttagcompound.SetInteger("SpawnZ", spawnZ);
			nbttagcompound.SetLong("Time", worldTime);
			nbttagcompound.SetLong("SizeOnDisk", sizeOnDisk);
			nbttagcompound.SetLong("LastPlayed", Sharpen.Runtime.CurrentTimeMillis());
			nbttagcompound.SetString("LevelName", levelName);
			nbttagcompound.SetInteger("version", saveVersion);
			nbttagcompound.SetInteger("rainTime", rainTime);
			nbttagcompound.SetBoolean("raining", isRaining);
			nbttagcompound.SetInteger("thunderTime", thunderTime);
			nbttagcompound.SetBoolean("thundering", isThundering);
			if (nbttagcompound1 != null)
			{
				nbttagcompound.SetCompoundTag("Player", nbttagcompound1);
			}
		}

		public virtual long GetRandomSeed()
		{
			return randomSeed;
		}

		public virtual int GetSpawnX()
		{
			return spawnX;
		}

		public virtual int GetSpawnY()
		{
			return spawnY;
		}

		public virtual int GetSpawnZ()
		{
			return spawnZ;
		}

		public virtual long GetWorldTime()
		{
			return worldTime;
		}

		public virtual long GetSizeOnDisk()
		{
			return sizeOnDisk;
		}

		public virtual int GetDimension()
		{
			return field_22194_i;
		}

		public virtual void SetWorldTime(long l)
		{
			worldTime = l;
		}

		public virtual void SetSizeOnDisk(long l)
		{
			sizeOnDisk = l;
		}

		public virtual void SetSpawnPosition(int i, int j, int k)
		{
			spawnX = i;
			spawnY = j;
			spawnZ = k;
		}

		public virtual void SetLevelName(string s)
		{
			levelName = s;
		}

		public virtual int GetVersion()
		{
			return saveVersion;
		}

		public virtual void SetVersion(int i)
		{
			saveVersion = i;
		}

		public virtual bool GetIsThundering()
		{
			return isThundering;
		}

		public virtual void SetIsThundering(bool flag)
		{
			isThundering = flag;
		}

		public virtual int GetThunderTime()
		{
			return thunderTime;
		}

		public virtual void SetThunderTime(int i)
		{
			thunderTime = i;
		}

		public virtual bool GetIsRaining()
		{
			return isRaining;
		}

		public virtual void SetIsRaining(bool flag)
		{
			isRaining = flag;
		}

		public virtual int GetRainTime()
		{
			return rainTime;
		}

		public virtual void SetRainTime(int i)
		{
			rainTime = i;
		}

		private long randomSeed;

		private int spawnX;

		private int spawnY;

		private int spawnZ;

		private long worldTime;

		private long lastTimePlayed;

		private long sizeOnDisk;

		private net.minecraft.src.NBTTagCompound field_22195_h;

		private int field_22194_i;

		private string levelName;

		private int saveVersion;

		private bool isRaining;

		private int rainTime;

		private bool isThundering;

		private int thunderTime;
	}
}
