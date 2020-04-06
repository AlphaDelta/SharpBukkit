// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class WatchableObject
	{
		public WatchableObject(int i, int j, object obj)
		{
			dataValueId = j;
			watchedObject = obj;
			objectType = i;
			isWatching = true;
		}

		public virtual int GetDataValueId()
		{
			return dataValueId;
		}

		public virtual void SetObject(object obj)
		{
			watchedObject = obj;
		}

		public virtual object GetObject()
		{
			return watchedObject;
		}

		public virtual int GetObjectType()
		{
			return objectType;
		}

		public virtual bool GetWatching()
		{
			return isWatching;
		}

		public virtual void SetWatching(bool flag)
		{
			isWatching = flag;
		}

		private readonly int objectType;

		private readonly int dataValueId;

		private object watchedObject;

		private bool isWatching;
	}
}
