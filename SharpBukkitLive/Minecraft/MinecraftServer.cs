using SharpBukkitLive.SharpBukkit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;

namespace net.minecraft.server
{

	public class MinecraftServer : net.minecraft.src.ICommandListener
	{
		public MinecraftServer()
		{
			serverRunning = true;
			serverStopped = false;
			deathTime = 0;
			field_9010_p = new System.Collections.ArrayList();
			commands = ArrayList.Synchronized(new System.Collections.ArrayList());
			entityTracker = new net.minecraft.src.EntityTracker[2];
			//new net.minecraft.src.ThreadSleepForever(this);
		}

		/// <exception cref="java.net.UnknownHostException"/>
		private bool StartServer()
		{
			commandHandler = new net.minecraft.src.ConsoleCommandHandler(this);
			Thread t = new Thread(() => { new net.minecraft.src.ThreadCommandReader(this).Run(); });
			t.IsBackground = true;//threadcommandreader.SetDaemon(true);
			t.Start();//threadcommandreader.Start();
			net.minecraft.src.ConsoleLogManager.Init();
			logger.Info("Starting minecraft server version Beta 1.7.3");
			//if (java.lang.Runtime.GetRuntime().MaxMemory() / 1024L / 1024L < 512L)
			//{
			//	logger.Warning("**** NOT ENOUGH RAM!");
			//	logger.Warning("To start the server with more ram, launch it as \"java -Xmx1024M -Xms1024M -jar minecraft_server.jar\""
			//		);
			//}
			logger.Info("Loading properties");
			propertyManagerObj = new net.minecraft.src.PropertyManager("server.properties");
			string s = propertyManagerObj.GetStringProperty("server-ip", string.Empty);
			onlineMode = propertyManagerObj.GetBooleanProperty("online-mode", true);
			spawnPeacefulMobs = propertyManagerObj.GetBooleanProperty("spawn-animals", true);
			pvpOn = propertyManagerObj.GetBooleanProperty("pvp", true);
			allowFlight = propertyManagerObj.GetBooleanProperty("allow-flight", false);
			IPAddress inetaddress = null;
			if (s.Length > 0)
			{
				inetaddress = IPAddress.Parse(s);
			}
			int i = propertyManagerObj.GetIntProperty("server-port", 25565);
			logger.Info((new java.lang.StringBuilder()).Append("Starting Minecraft server on "
				).Append(s.Length != 0 ? s : "*").Append(":").Append(i).ToString());
			try
			{
				networkServer = new net.minecraft.src.NetworkListenThread(this, inetaddress, i);
			}
			catch (System.IO.IOException ioexception)
			{
				logger.Warning("**** FAILED TO BIND TO PORT!");
				logger.Warning((new java.lang.StringBuilder()).Append
					("The exception was: ").Append(ioexception.ToString()).ToString());
				logger.Warning("Perhaps a server is already running on that port?");
				return false;
			}
			if (!onlineMode)
			{
				logger.Warning("**** SERVER IS RUNNING IN OFFLINE/INSECURE MODE!");
				logger.Warning("The server will make no attempt to authenticate usernames. Beware."
					);
				logger.Warning("While this makes the game possible to play without internet access, it also opens up the ability for hackers to connect with any username they choose."
					);
				logger.Warning("To change this, set \"online-mode\" to \"true\" in the server.settings file."
					);
			}
			configManager = new net.minecraft.src.ServerConfigurationManager(this);
			entityTracker[0] = new net.minecraft.src.EntityTracker(this, 0);
			entityTracker[1] = new net.minecraft.src.EntityTracker(this, -1);
			DateTime l = DateTime.Now;
			string s1 = propertyManagerObj.GetStringProperty("level-name", "world");
			string s2 = propertyManagerObj.GetStringProperty("level-seed", string.Empty);
			long l1 = (new SharpRandom()).NextLong();
			if (s2.Length > 0)
			{
				try
				{
					l1 = long.Parse(s2);
				}
				catch (System.FormatException)
				{
					l1 = s2.GetHashCode();
				}
			}
			logger.Info((new java.lang.StringBuilder()).Append("Preparing level \"").Append(s1
				).Append("\"").ToString());
			InitWorld(new net.minecraft.src.SaveConverterMcRegion("."), s1,
				l1);
			logger.Info((new java.lang.StringBuilder()).Append("Done (").Append((DateTime.Now - l).Milliseconds).Append("ms)! For help, type \"help\" or \"?\"").ToString());
			return true;
		}

		private void InitWorld(net.minecraft.src.ISaveFormat isaveformat, string s, long
			l)
		{
			if (isaveformat.IsOldSaveType(s))
			{
				logger.Info("Converting map!");
				isaveformat.ConverMapToMCRegion(s, new net.minecraft.src.ConvertProgressUpdater(this
					));
			}
			worldMngr = new net.minecraft.src.WorldServer[2];
			net.minecraft.src.SaveOldDir saveolddir = new net.minecraft.src.SaveOldDir(".", s, true);
			for (int i = 0; i < worldMngr.Length; i++)
			{
				if (i == 0)
				{
					worldMngr[i] = new net.minecraft.src.WorldServer(this, saveolddir, s, i != 0 ? -1
						 : 0, l);
				}
				else
				{
					worldMngr[i] = new net.minecraft.src.WorldServerMulti(this, saveolddir, s, i != 0
						 ? -1 : 0, l, worldMngr[0]);
				}
				worldMngr[i].AddWorldAccess(new net.minecraft.src.WorldManager(this, worldMngr[i]
					));
				worldMngr[i].difficultySetting = propertyManagerObj.GetBooleanProperty("spawn-monsters"
					, true) ? 1 : 0;
				worldMngr[i].SetAllowedSpawnTypes(propertyManagerObj.GetBooleanProperty("spawn-monsters"
					, true), spawnPeacefulMobs);
				configManager.SetPlayerManager(worldMngr);
			}
			short c = 196;// '\304';
			long l1 = Sharpen.Runtime.CurrentTimeMillis();
			for (int j = 0; j < worldMngr.Length; j++)
			{
				logger.Info((new java.lang.StringBuilder()).Append("Preparing start region for level ").Append(j).ToString());
				if (j != 0 && !propertyManagerObj.GetBooleanProperty("allow-nether", true))
				{
					continue;
				}
				net.minecraft.src.WorldServer worldserver = worldMngr[j];
				net.minecraft.src.ChunkCoordinates chunkcoordinates = worldserver.GetSpawnPoint();
				int k = -c;
				//do
				for(; k <= c && serverRunning; k += 16)
				{
					//if (k > c || !serverRunning)
					//{
					//	break;
					//	//goto label0_continue;
					//}

					for (int i1 = -c; i1 <= c && serverRunning; i1 += 16)
					{
						long l2 = Sharpen.Runtime.CurrentTimeMillis();
						if (l2 < l1)
						{
							l1 = l2;
						}
						if (l2 > l1 + 1000L)
						{
							int j1 = (c * 2 + 1) * (c * 2 + 1);
							int k1 = (k + c) * (c * 2 + 1) + (i1 + 1);
							OutputPercentRemaining("Preparing spawn area", (k1 * 100) / j1);
							l1 = l2;
						}
						worldserver.chunkProviderServer.LoadChunk(chunkcoordinates.posX + k >> 4, chunkcoordinates
							.posZ + i1 >> 4);
						while (worldserver.DoLighting() && serverRunning)
						{
						}
					}
					//k += 16;
				}
				//while (true);
				//label0_continue:;
			}
			//label0_break:;
			ClearCurrentTask();
		}

		private void OutputPercentRemaining(string s, int i)
		{
			currentTask = s;
			percentDone = i;
			logger.Info((new java.lang.StringBuilder()).Append(s).Append(": ").Append(i).Append
				("%").ToString());
		}

		private void ClearCurrentTask()
		{
			currentTask = null;
			percentDone = 0;
		}

		private void SaveServerWorld()
		{
			logger.Info("Saving chunks");
			for (int i = 0; i < worldMngr.Length; i++)
			{
				net.minecraft.src.WorldServer worldserver = worldMngr[i];
				worldserver.SaveWorld(true, null);
				worldserver.Func_30006_w();
			}
		}

		private void StopServer()
		{
			logger.Info("Stopping server");
			if (configManager != null)
			{
				configManager.SavePlayerStates();
			}
			for (int i = 0; i < worldMngr.Length; i++)
			{
				net.minecraft.src.WorldServer worldserver = worldMngr[i];
				if (worldserver != null)
				{
					SaveServerWorld();
				}
			}
		}

		public virtual void InitiateShutdown()
		{
			serverRunning = false;
		}

		public virtual void Run()
		{
			try
			{
				if (StartServer())
				{
					long l = Sharpen.Runtime.CurrentTimeMillis();
					long l1 = 0L;
					while (serverRunning)
					{
						long l2 = Sharpen.Runtime.CurrentTimeMillis();
						long l3 = l2 - l;
						if (l3 > 2000L)
						{
							logger.Warning("Can't keep up! Did the system time change, or is the server overloaded?"
								);
							l3 = 2000L;
						}
						if (l3 < 0L)
						{
							logger.Warning("Time ran backwards! Did the system time change?");
							l3 = 0L;
						}
						l1 += l3;
						l = l2;
						if (worldMngr[0].IsAllPlayersFullyAsleep())
						{
							DoTick();
							l1 = 0L;
						}
						else
						{
							while (l1 > 50L)
							{
								l1 -= 50L;
								//Console.WriteLine("Tick");
								DoTick();
							}
						}
						Thread.Sleep(1);
					}
				}
				else
				{
					while (serverRunning)
					{
						CommandLineParser();
						try
						{
							Thread.Sleep(10);
						}
						catch (System.Exception interruptedexception)
						{
							Sharpen.Runtime.PrintStackTrace(interruptedexception);
						}
					}
				}
			}
			//TODO: Uncomment
			//catch (System.Exception throwable1)
			//{
			//	Sharpen.Runtime.PrintStackTrace(throwable1);
			//	logger.Severe("Unexpected exception");
			//	//logger.Log(java.util.logging.Level.SEVERE, "Unexpected exception", throwable1);
			//	while (serverRunning)
			//	{
			//		CommandLineParser();
			//		try
			//		{
			//			Thread.Sleep(10);
			//		}
			//		catch (System.Exception interruptedexception1)
			//		{
			//			Sharpen.Runtime.PrintStackTrace(interruptedexception1);
			//		}
			//	}
			//}
			finally
			{
				try
				{
					StopServer();
					serverStopped = true;
				}
				catch (System.Exception throwable2)
				{
					Sharpen.Runtime.PrintStackTrace(throwable2);
				}
				finally
				{
					System.Environment.Exit(0);
				}
			}
		}

		private void DoTick()
		{
			List<string> arraylist = new List<string>();
			for (System.Collections.IEnumerator iterator = field_6037_b.Keys.GetEnumerator();
				iterator.MoveNext();)
			{
				string s = (string)iterator.Current;
				int i1 = ((int)field_6037_b[s]);
				if (i1 > 0)
				{
					field_6037_b[s] = i1 - 1;
				}
				else
				{
					arraylist.Add(s);
				}
			}
			for (int i = 0; i < arraylist.Count; i++)
			{
				field_6037_b.Remove(arraylist[i]); //arraylist[i]
			}
			net.minecraft.src.AxisAlignedBB.ClearBoundingBoxPool();
			net.minecraft.src.Vec3D.Initialize();
			deathTime++;
			for (int j = 0; j < worldMngr.Length; j++)
			{
				if (j != 0 && !propertyManagerObj.GetBooleanProperty("allow-nether", true))
				{
					continue;
				}
				net.minecraft.src.WorldServer worldserver = worldMngr[j];
				if (deathTime % 20 == 0)
				{
					configManager.SendPacketToAllPlayersInDimension(new net.minecraft.src.Packet4UpdateTime
						(worldserver.GetWorldTime()), worldserver.worldProvider.worldType);
				}
				worldserver.Tick();
				while (worldserver.DoLighting())
				{
				}
				worldserver.UpdateEntities();
			}
			networkServer.HandleNetworkListenThread();
			configManager.OnTick();
			for (int k = 0; k < entityTracker.Length; k++)
			{
				entityTracker[k].UpdateTrackedEntities();
			}
			for (int l = 0; l < field_9010_p.Count; l++)
			{
				((net.minecraft.src.IUpdatePlayerListBox)field_9010_p[l]).Update();
			}
			try
			{
				CommandLineParser();
			}
			catch (System.Exception exception)
			{
				logger.Warning("Unexpected exception while parsing console command");
				logger.Log(exception.ToString());
				//logger.Log(java.util.logging.Level.WARNING, "Unexpected exception while parsing console command", exception);
			}
		}

		public virtual void AddCommand(string s, net.minecraft.src.ICommandListener icommandlistener
			)
		{
			commands.Add(new net.minecraft.src.ServerCommand(s, icommandlistener));
		}

		public virtual void CommandLineParser()
		{
			net.minecraft.src.ServerCommand servercommand;
			for (; commands.Count > 0; commandHandler.HandleCommand(servercommand))
			{
				servercommand = (net.minecraft.src.ServerCommand)commands[0];
				commands.Remove(servercommand);
			}
		}

		public virtual void Func_6022_a(net.minecraft.src.IUpdatePlayerListBox iupdateplayerlistbox
			)
		{
			field_9010_p.Add(iupdateplayerlistbox);
		}

		/// <summary>
		/// ENTRY POINT
		/// </summary>
		//public static void Main(string[] args)
		//{
		//	net.minecraft.src.StatList.Func_27092_a();
		//	try
		//	{
		//		net.minecraft.server.MinecraftServer minecraftserver = new net.minecraft.server.MinecraftServer
		//			();
		//		//if (!java.awt.GraphicsEnvironment.IsHeadless() && (args.Length <= 0 || !args[0].Equals("nogui")))
		//		//{
		//		//	net.minecraft.src.ServerGUI.InitGui(minecraftserver);
		//		//}
		//		Thread t = new Thread(() => { (new net.minecraft.src.ThreadServerApplication("Server thread", minecraftserver)).Run(); });
		//		t.Start();
		//	}
		//	catch (System.Exception exception)
		//	{
		//		logger.Severe("Failed to start the minecraft server");
		//		logger.Log(exception.ToString());
		//		//logger.Log(java.util.logging.Level.SEVERE, "Failed to start the minecraft server", exception);
		//	}
		//}

		public virtual string GetFile(string s)
		{
			return s;
			//return new java.io.File(s);
		}

		public virtual void Log(string s)
		{
			logger.Info(s);
		}

		public virtual void LogWarning(string s)
		{
			logger.Warning(s);
		}

		public virtual string GetUsername()
		{
			return "CONSOLE";
		}

		public virtual net.minecraft.src.WorldServer GetWorldManager(int i)
		{
			if (i == -1)
			{
				return worldMngr[1];
			}
			else
			{
				return worldMngr[0];
			}
		}

		public virtual net.minecraft.src.EntityTracker GetEntityTracker(int i)
		{
			if (i == -1)
			{
				return entityTracker[1];
			}
			else
			{
				return entityTracker[0];
			}
		}

		public static bool IsServerRunning(net.minecraft.server.MinecraftServer minecraftserver
			)
		{
			return minecraftserver.serverRunning;
		}

		public static Logger logger = Logger.GetLogger();
		//public static java.util.logging.Logger logger = java.util.logging.Logger.GetLogger("Minecraft");

		public static Dictionary<string, int> field_6037_b = new Dictionary<string, int>();

		public net.minecraft.src.NetworkListenThread networkServer;

		public net.minecraft.src.PropertyManager propertyManagerObj;

		public net.minecraft.src.WorldServer[] worldMngr;

		public net.minecraft.src.ServerConfigurationManager configManager;

		private net.minecraft.src.ConsoleCommandHandler commandHandler;

		private bool serverRunning;

		public bool serverStopped;

		internal int deathTime;

		public string currentTask;

		public int percentDone;

		private System.Collections.IList field_9010_p;

		private IList commands;//List<net.minecraft.src.ServerCommand> commands;

		public net.minecraft.src.EntityTracker[] entityTracker;

		public bool onlineMode;

		public bool spawnPeacefulMobs;

		public bool pvpOn;

		public bool allowFlight;
	}
}
