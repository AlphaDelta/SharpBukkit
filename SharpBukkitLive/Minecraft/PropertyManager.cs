// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System.IO;

namespace net.minecraft.src
{
	public class PropertyManager
	{
		public PropertyManager(string file)
		{
			serverProperties = new AlphaDelta.JavaProperties();
			serverPropertiesFile = file;
			if (File.Exists(file))
			{
				try
				{
					serverProperties.Load(file);
				}
				catch (System.Exception exception)
				{
					logger.Warning((new java.lang.StringBuilder()).Append("Failed to load ").Append(file).ToString());
					logger.Log(exception.ToString());
					GenerateNewProperties();
				}
			}
			else
			{
				logger.Warning((new java.lang.StringBuilder()).Append(file).Append(" does not exist").ToString());
				GenerateNewProperties();
			}
		}

		public virtual void GenerateNewProperties()
		{
			logger.Info("Generating new properties file");
			SaveProperties();
		}

		public virtual void SaveProperties()
		{
			try
			{
				serverProperties.Save(serverPropertiesFile);
			}
			catch (System.Exception exception)
			{
				logger.Warning((new java.lang.StringBuilder()).Append("Failed to save ").Append(serverPropertiesFile).ToString());
				logger.Log(exception.ToString());
				GenerateNewProperties();
			}
		}

		public virtual string GetStringProperty(string s, string s1)
		{
			if (!serverProperties.ContainsKey(s))
			{
				serverProperties[s] = s1;
				SaveProperties();
			}
			return serverProperties[s] ?? s1;
		}

		public virtual int GetIntProperty(string s, int i)
		{
			try
			{
				return System.Convert.ToInt32(GetStringProperty(s, (new java.lang.StringBuilder()).Append(string.Empty).Append(i).ToString()));
			}
			catch (System.Exception)
			{
				serverProperties[s] = (new java.lang.StringBuilder()).Append(string.Empty).Append(i).ToString();
			}
			return i;
		}

		public virtual bool GetBoolean(string s, bool flag)
		{
			try
			{
				return bool.Parse(GetStringProperty(s, (new java.lang.StringBuilder()).Append
					(string.Empty).Append(flag).ToString()));
			}
			catch (System.Exception)
			{
				serverProperties[s] = (new java.lang.StringBuilder()).Append(string.Empty).Append(flag).ToString();
			}
			return flag;
		}

		public virtual void SetProperty(string s, bool flag)
		{
			serverProperties[s] = (new java.lang.StringBuilder()).Append(string.Empty).Append(flag).ToString();
			SaveProperties();
		}

		public static Logger logger = Logger.GetLogger();
		//public static java.util.logging.Logger logger = java.util.logging.Logger.GetLogger("Minecraft");

		private AlphaDelta.JavaProperties serverProperties;

		private string serverPropertiesFile;
	}
}
