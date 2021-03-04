// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using SharpBukkitLive.SharpBukkit.Command;
using Sharpen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace net.minecraft.src
{
    public class ConsoleCommandHandler
    {
        public ConsoleCommandHandler(net.minecraft.server.MinecraftServer minecraftserver)
        {
            // Referenced classes of package net.minecraft.src:
            //            ServerCommand, ICommandListener, ServerConfigurationManager, WorldServer, 
            //            EntityPlayerMP, NetServerHandler, Item, ItemStack, 
            //            Packet3Chat, PropertyManager
            minecraftServer = minecraftserver;
        }

        public virtual void HandleCommand(net.minecraft.src.ServerCommand servercommand)
        {
            //TODO: Put this somewhere else
            /* SharpBukkit command handler */
            {
                PluginManager.ParseInvocation(servercommand.command, out string command, out string[] oargs);

                bool isOP = servercommand.commandListener is net.minecraft.server.MinecraftServer || (servercommand.commandListener is net.minecraft.src.NetServerHandler && minecraftServer.serverConfigurationManager.IsOp(servercommand.commandListener.GetUsername()));
                bool isPlayer = servercommand.commandListener is net.minecraft.src.NetServerHandler;
                IEnumerable<(ReflSharpBukkitCommand, string)> cmds =
                    PluginManager.Commands
                        .Where(p => p.Name == command)
                        .Select(p => (p, p.HasInvocationProblem(oargs, isOP, isPlayer)));

                if (cmds.Count() > 0)
                {
                    var vcmds = cmds.Where(p => p.Item2 == null);

                    (ReflSharpBukkitCommand nearestcommand, string invokeprob) = PluginManager.NearestSignature(oargs.Length, vcmds);


                    if (nearestcommand != null)
                    {
                        object[] args = nearestcommand.PrepareArgs(oargs);


                        SharpBukkitCommandController controller = null;
                        try
                        {
                            controller = (SharpBukkitCommandController)Activator.CreateInstance(nearestcommand.Method.DeclaringType);
                            controller.Server = minecraftServer;
                            controller.User = servercommand.commandListener;
                            controller.FullMessage = servercommand.command;
                            controller.CurrentCommand = nearestcommand;
                            if (controller.PreExecution())
                                try
                                {
                                    nearestcommand.Method.Invoke(controller, args);
                                }
                                finally
                                {
                                    if (controller != null)
                                        controller.AlwaysAfterExecute();
                                }
                        }
                        finally
                        {
                            if (controller != null)
                                controller.Always();
                        }
                    }
                    else
                        servercommand.commandListener.Log(PluginManager.NearestSignature(oargs.Length, cmds).Item2);
                }
                else
                    servercommand.commandListener.Log("Command not found");
            }
            /* ============================== */

            return; //TODO: comment all code after this
            string s = servercommand.command;
            net.minecraft.src.ICommandListener icommandlistener = servercommand.commandListener;
            string s1 = icommandlistener.GetUsername();
            net.minecraft.src.ServerConfigurationManager serverconfigurationmanager = minecraftServer.serverConfigurationManager;
            if (s.ToLower().StartsWith("help") || s.ToLower().StartsWith("?"))
            {
                PrintHelp(icommandlistener);
            }
            else
            {
                if (s.ToLower().StartsWith("list"))
                {
                    icommandlistener.Log((new java.lang.StringBuilder()).Append("Connected players: ").Append(serverconfigurationmanager.GetPlayerList()).ToString());
                }
                else
                {
                    if (s.ToLower().StartsWith("stop"))
                    {
                        SendNoticeToOps(s1, "Stopping the server..");
                        minecraftServer.InitiateShutdown();
                    }
                    else
                    {
                        if (s.ToLower().StartsWith("save-all"))
                        {
                            SendNoticeToOps(s1, "Forcing save..");
                            if (serverconfigurationmanager != null)
                            {
                                serverconfigurationmanager.SavePlayers();
                            }
                            for (int i = 0; i < minecraftServer.worlds.Count; i++)
                            {
                                net.minecraft.src.WorldServer worldserver = minecraftServer.worlds[i];
                                worldserver.SaveWorld(true, null);
                            }
                            SendNoticeToOps(s1, "Save complete.");
                        }
                        else
                        {
                            if (s.ToLower().StartsWith("save-off"))
                            {
                                SendNoticeToOps(s1, "Disabling level saving..");
                                for (int j = 0; j < minecraftServer.worlds.Count; j++)
                                {
                                    net.minecraft.src.WorldServer worldserver1 = minecraftServer.worlds[j];
                                    worldserver1.canSave = true;
                                }
                            }
                            else
                            {
                                if (s.ToLower().StartsWith("save-on"))
                                {
                                    SendNoticeToOps(s1, "Enabling level saving..");
                                    for (int k = 0; k < minecraftServer.worlds.Count; k++)
                                    {
                                        net.minecraft.src.WorldServer worldserver2 = minecraftServer.worlds[k];
                                        worldserver2.canSave = false;
                                    }
                                }
                                else
                                {
                                    if (s.ToLower().StartsWith("op "))
                                    {
                                        string s2 = s.Substring(s.IndexOf(" ")).Trim();
                                        serverconfigurationmanager.OpPlayer(s2);
                                        SendNoticeToOps(s1, (new java.lang.StringBuilder()).Append("Opping ").Append(s2).
                                            ToString());
                                        serverconfigurationmanager.SendChatMessageToPlayer(s2, "§eYou are now op!");
                                    }
                                    else
                                    {
                                        if (s.ToLower().StartsWith("deop "))
                                        {
                                            string s3 = s.Substring(s.IndexOf(" ")).Trim();
                                            serverconfigurationmanager.DeopPlayer(s3);
                                            serverconfigurationmanager.SendChatMessageToPlayer(s3, "§eYou are no longer op!"
                                                );
                                            SendNoticeToOps(s1, (new java.lang.StringBuilder()).Append("De-opping ").Append(s3
                                                ).ToString());
                                        }
                                        else
                                        {
                                            if (s.ToLower().StartsWith("ban-ip "))
                                            {
                                                string s4 = s.Substring(s.IndexOf(" ")).Trim();
                                                serverconfigurationmanager.BanIP(s4);
                                                SendNoticeToOps(s1, (new java.lang.StringBuilder()).Append("Banning ip ").Append(
                                                    s4).ToString());
                                            }
                                            else
                                            {
                                                if (s.ToLower().StartsWith("pardon-ip "))
                                                {
                                                    string s5 = s.Substring(s.IndexOf(" ")).Trim();
                                                    serverconfigurationmanager.PardonIP(s5);
                                                    SendNoticeToOps(s1, (new java.lang.StringBuilder()).Append("Pardoning ip ").Append
                                                        (s5).ToString());
                                                }
                                                else
                                                {
                                                    if (s.ToLower().StartsWith("ban "))
                                                    {
                                                        string s6 = s.Substring(s.IndexOf(" ")).Trim();
                                                        serverconfigurationmanager.BanPlayer(s6);
                                                        SendNoticeToOps(s1, (new java.lang.StringBuilder()).Append("Banning ").Append(s6)
                                                            .ToString());
                                                        net.minecraft.src.EntityPlayerMP entityplayermp = serverconfigurationmanager.GetPlayerEntity
                                                            (s6);
                                                        if (entityplayermp != null)
                                                        {
                                                            entityplayermp.netServerHandler.KickPlayer("Banned by admin");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (s.ToLower().StartsWith("pardon "))
                                                        {
                                                            string s7 = s.Substring(s.IndexOf(" ")).Trim();
                                                            serverconfigurationmanager.PardonPlayer(s7);
                                                            SendNoticeToOps(s1, (new java.lang.StringBuilder()).Append("Pardoning ").Append(s7
                                                                ).ToString());
                                                        }
                                                        else
                                                        {
                                                            if (s.ToLower().StartsWith("kick "))
                                                            {
                                                                string s8 = s.Substring(s.IndexOf(" ")).Trim();
                                                                net.minecraft.src.EntityPlayerMP entityplayermp1 = null;
                                                                for (int l = 0; l < serverconfigurationmanager.playerEntities.Count; l++)
                                                                {
                                                                    net.minecraft.src.EntityPlayerMP entityplayermp5 = (net.minecraft.src.EntityPlayerMP
                                                                        )serverconfigurationmanager.playerEntities[l];
                                                                    if (s8.Equals(entityplayermp5.username, System.StringComparison.OrdinalIgnoreCase))
                                                                    {
                                                                        entityplayermp1 = entityplayermp5;
                                                                    }
                                                                }
                                                                if (entityplayermp1 != null)
                                                                {
                                                                    entityplayermp1.netServerHandler.KickPlayer("Kicked by admin");
                                                                    SendNoticeToOps(s1, (new java.lang.StringBuilder()).Append("Kicking ").Append(entityplayermp1
                                                                        .username).ToString());
                                                                }
                                                                else
                                                                {
                                                                    icommandlistener.Log((new java.lang.StringBuilder()).Append("Can't find user ").Append
                                                                        (s8).Append(". No kick.").ToString());
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (s.ToLower().StartsWith("tp "))
                                                                {
                                                                    string[] @as = s.Split(" ");
                                                                    if (@as.Length == 3)
                                                                    {
                                                                        net.minecraft.src.EntityPlayerMP entityplayermp2 = serverconfigurationmanager.GetPlayerEntity
                                                                            (@as[1]);
                                                                        net.minecraft.src.EntityPlayerMP entityplayermp3 = serverconfigurationmanager.GetPlayerEntity
                                                                            (@as[2]);
                                                                        if (entityplayermp2 == null)
                                                                        {
                                                                            icommandlistener.Log((new java.lang.StringBuilder()).Append("Can't find user ").Append
                                                                                (@as[1]).Append(". No tp.").ToString());
                                                                        }
                                                                        else
                                                                        {
                                                                            if (entityplayermp3 == null)
                                                                            {
                                                                                icommandlistener.Log((new java.lang.StringBuilder()).Append("Can't find user ").Append
                                                                                    (@as[2]).Append(". No tp.").ToString());
                                                                            }
                                                                            else
                                                                            {
                                                                                if (entityplayermp2.dimension != entityplayermp3.dimension)
                                                                                {
                                                                                    icommandlistener.Log((new java.lang.StringBuilder()).Append("User ").Append(@as[1
                                                                                        ]).Append(" and ").Append(@as[2]).Append(" are in different dimensions. No tp.")
                                                                                        .ToString());
                                                                                }
                                                                                else
                                                                                {
                                                                                    entityplayermp2.netServerHandler.TeleportTo(entityplayermp3.posX, entityplayermp3
                                                                                        .posY, entityplayermp3.posZ, entityplayermp3.rotationYaw, entityplayermp3.rotationPitch
                                                                                        );
                                                                                    SendNoticeToOps(s1, (new java.lang.StringBuilder()).Append("Teleporting ").Append
                                                                                        (@as[1]).Append(" to ").Append(@as[2]).Append(".").ToString());
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        icommandlistener.Log("Syntax error, please provice a source and a target.");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (s.ToLower().StartsWith("give "))
                                                                    {
                                                                        string[] as1 = s.Split(" ");
                                                                        if (as1.Length != 3 && as1.Length != 4)
                                                                        {
                                                                            return;
                                                                        }
                                                                        string s9 = as1[1];
                                                                        net.minecraft.src.EntityPlayerMP entityplayermp4 = serverconfigurationmanager.GetPlayerEntity
                                                                            (s9);
                                                                        if (entityplayermp4 != null)
                                                                        {
                                                                            try
                                                                            {
                                                                                int j1 = System.Convert.ToInt32(as1[2]);
                                                                                if (net.minecraft.src.Item.itemsList[j1] != null)
                                                                                {
                                                                                    SendNoticeToOps(s1, (new java.lang.StringBuilder()).Append("Giving ").Append(entityplayermp4
                                                                                        .username).Append(" some ").Append(j1).ToString());
                                                                                    int i2 = 1;
                                                                                    if (as1.Length > 3)
                                                                                    {
                                                                                        i2 = TryParse(as1[3], 1);
                                                                                    }
                                                                                    if (i2 < 1)
                                                                                    {
                                                                                        i2 = 1;
                                                                                    }
                                                                                    if (i2 > 64)
                                                                                    {
                                                                                        i2 = 64;
                                                                                    }
                                                                                    entityplayermp4.DropPlayerItem(new net.minecraft.src.ItemStack(j1, i2, 0));
                                                                                }
                                                                                else
                                                                                {
                                                                                    icommandlistener.Log((new java.lang.StringBuilder()).Append("There's no item with id "
                                                                                        ).Append(j1).ToString());
                                                                                }
                                                                            }
                                                                            catch (System.FormatException)
                                                                            {
                                                                                icommandlistener.Log((new java.lang.StringBuilder()).Append("There's no item with id "
                                                                                    ).Append(as1[2]).ToString());
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            icommandlistener.Log((new java.lang.StringBuilder()).Append("Can't find user ").Append
                                                                                (s9).ToString());
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (s.ToLower().StartsWith("time "))
                                                                        {
                                                                            string[] as2 = s.Split(" ");
                                                                            if (as2.Length != 3)
                                                                            {
                                                                                return;
                                                                            }
                                                                            string s10 = as2[1];
                                                                            try
                                                                            {
                                                                                int i1 = System.Convert.ToInt32(as2[2]);
                                                                                if (s10.Equals("add", System.StringComparison.OrdinalIgnoreCase))
                                                                                {
                                                                                    for (int k1 = 0; k1 < minecraftServer.worlds.Count; k1++)
                                                                                    {
                                                                                        net.minecraft.src.WorldServer worldserver3 = minecraftServer.worlds[k1];
                                                                                        worldserver3.Func_32005_b(worldserver3.GetWorldTime() + (long)i1);
                                                                                    }
                                                                                    SendNoticeToOps(s1, (new java.lang.StringBuilder()).Append("Added ").Append(i1).Append(" to time").ToString());
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (s10.Equals("set", System.StringComparison.OrdinalIgnoreCase))
                                                                                    {
                                                                                        for (int l1 = 0; l1 < minecraftServer.worlds.Count; l1++)
                                                                                        {
                                                                                            net.minecraft.src.WorldServer worldserver4 = minecraftServer.worlds[l1];
                                                                                            worldserver4.Func_32005_b(i1);
                                                                                        }
                                                                                        SendNoticeToOps(s1, (new java.lang.StringBuilder()).Append("Set time to ").Append(i1).ToString());
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        icommandlistener.Log("Unknown method, use either \"add\" or \"set\"");
                                                                                    }
                                                                                }
                                                                            }
                                                                            catch (System.FormatException)
                                                                            {
                                                                                icommandlistener.Log((new java.lang.StringBuilder()).Append("Unable to convert time value, ").Append(as2[2]).ToString());
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (s.ToLower().StartsWith("say "))
                                                                            {
                                                                                s = s.Substring(s.IndexOf(" ")).Trim();
                                                                                minecraftLogger.Info((new java.lang.StringBuilder()).Append("[").Append(s1).Append("] ").Append(s).ToString());
                                                                                //Console.WriteLine((new java.lang.StringBuilder()).Append("[").Append(s1).Append("] ").Append(s).ToString());
                                                                                serverconfigurationmanager.SendPacketToAllPlayers(new net.minecraft.src.Packet3Chat
                                                                                    ((new java.lang.StringBuilder()).Append("§d[Server] ").Append(s).ToString()));
                                                                            }
                                                                            else
                                                                            {
                                                                                if (s.ToLower().StartsWith("tell "))
                                                                                {
                                                                                    string[] as3 = s.Split(" ");
                                                                                    if (as3.Length >= 3)
                                                                                    {
                                                                                        s = s.Substring(s.IndexOf(" ")).Trim();
                                                                                        s = s.Substring(s.IndexOf(" ")).Trim();
                                                                                        minecraftLogger.Info((new java.lang.StringBuilder()).Append("[").Append(s1).Append("->").Append(as3[1]).Append("] ").Append(s).ToString());
                                                                                        Console.WriteLine((new java.lang.StringBuilder()).Append("[").Append(s1).Append("->").Append(as3[1]).Append("] ").Append(s).ToString());
                                                                                        s = (new java.lang.StringBuilder()).Append("§7").Append(s1).Append(" whispers "
                                                                                            ).Append(s).ToString();
                                                                                        minecraftLogger.Info(s);
                                                                                        //Console.WriteLine(s);
                                                                                        if (!serverconfigurationmanager.SendPacketToPlayer(as3[1], new net.minecraft.src.Packet3Chat
                                                                                            (s)))
                                                                                        {
                                                                                            icommandlistener.Log("There's no player by that name online.");
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (s.ToLower().StartsWith("whitelist "))
                                                                                    {
                                                                                        HandleWhitelist(s1, s, icommandlistener);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        //Console.WriteLine("Unknown console command. Type \"help\" for help.");
                                                                                        minecraftLogger.Info("Unknown console command. Type \"help\" for help.");
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void HandleWhitelist(string s, string s1, net.minecraft.src.ICommandListener
             icommandlistener)
        {
            string[] @as = s1.Split(" ");
            if (@as.Length < 2)
            {
                return;
            }
            string s2 = @as[1].ToLower();
            if ("on".Equals(s2))
            {
                SendNoticeToOps(s, "Turned on white-listing");
                minecraftServer.propertyManager.SetProperty("white-list", true);
            }
            else
            {
                if ("off".Equals(s2))
                {
                    SendNoticeToOps(s, "Turned off white-listing");
                    minecraftServer.propertyManager.SetProperty("white-list", false);
                }
                else
                {
                    if ("list".Equals(s2))
                    {
                        HashSet<string> set = minecraftServer.serverConfigurationManager.GetWhiteListedIPs();
                        string s5 = string.Empty;
                        for (System.Collections.IEnumerator iterator = set.GetEnumerator(); iterator.MoveNext
                            ();)
                        {
                            string s6 = (string)iterator.Current;
                            s5 = (new java.lang.StringBuilder()).Append(s5).Append(s6).Append(" ").ToString();
                        }
                        icommandlistener.Log((new java.lang.StringBuilder()).Append("White-listed players: "
                            ).Append(s5).ToString());
                    }
                    else
                    {
                        if ("add".Equals(s2) && @as.Length == 3)
                        {
                            string s3 = @as[2].ToLower();
                            minecraftServer.serverConfigurationManager.AddToWhiteList(s3);
                            SendNoticeToOps(s, (new java.lang.StringBuilder()).Append("Added ").Append(s3).Append
                                (" to white-list").ToString());
                        }
                        else
                        {
                            if ("remove".Equals(s2) && @as.Length == 3)
                            {
                                string s4 = @as[2].ToLower();
                                minecraftServer.serverConfigurationManager.RemoveFromWhiteList(s4);
                                SendNoticeToOps(s, (new java.lang.StringBuilder()).Append("Removed ").Append(s4).
                                    Append(" from white-list").ToString());
                            }
                            else
                            {
                                if ("reload".Equals(s2))
                                {
                                    minecraftServer.serverConfigurationManager.ReloadWhiteList();
                                    SendNoticeToOps(s, "Reloaded white-list from file");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void PrintHelp(net.minecraft.src.ICommandListener icommandlistener)
        {
            icommandlistener.Log("To run the server without a gui, start it like this:");
            icommandlistener.Log("   java -Xmx1024M -Xms1024M -jar minecraft_server.jar nogui"
                );
            icommandlistener.Log("Console commands:");
            icommandlistener.Log("   help  or  ?               shows this message");
            icommandlistener.Log("   kick <player>             removes a player from the server"
                );
            icommandlistener.Log("   ban <player>              bans a player from the server"
                );
            icommandlistener.Log("   pardon <player>           pardons a banned player so that they can connect again"
                );
            icommandlistener.Log("   ban-ip <ip>               bans an IP address from the server"
                );
            icommandlistener.Log("   pardon-ip <ip>            pardons a banned IP address so that they can connect again"
                );
            icommandlistener.Log("   op <player>               turns a player into an op");
            icommandlistener.Log("   deop <player>             removes op status from a player"
                );
            icommandlistener.Log("   tp <player1> <player2>    moves one player to the same location as another player"
                );
            icommandlistener.Log("   give <player> <id> [num]  gives a player a resource");
            icommandlistener.Log("   tell <player> <message>   sends a private message to a player"
                );
            icommandlistener.Log("   stop                      gracefully stops the server");
            icommandlistener.Log("   save-all                  forces a server-wide level save"
                );
            icommandlistener.Log("   save-off                  disables terrain saving (useful for backup scripts)"
                );
            icommandlistener.Log("   save-on                   re-enables terrain saving");
            icommandlistener.Log("   list                      lists all currently connected players"
                );
            icommandlistener.Log("   say <message>             broadcasts a message to all players"
                );
            icommandlistener.Log("   time <add|set> <amount>   adds to or sets the world time (0-24000)"
                );
        }

        private void SendNoticeToOps(string s, string s1)
        {
            string s2 = (new java.lang.StringBuilder()).Append(s).Append(": ").Append(s1).ToString
                ();
            minecraftServer.serverConfigurationManager.SendChatMessageToAllOps((new java.lang.StringBuilder()).Append("§7(").Append(s2).Append(")").ToString());
            minecraftLogger.Info(s2);
            //Console.WriteLine(s2);
        }

        private int TryParse(string s, int i)
        {
            try
            {
                return System.Convert.ToInt32(s);
            }
            catch (System.FormatException)
            {
                return i;
            }
        }

        private static Logger minecraftLogger = Logger.GetLogger();
        //java.util.logging.Logger minecraftLogger = java.util.logging.Logger.GetLogger("Minecraft");

        private net.minecraft.server.MinecraftServer minecraftServer;
    }
}
