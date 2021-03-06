﻿using SharpBukkitLive.SharpBukkit;
using SharpBukkitLive.SharpBukkit.Command;
using SharpBukkitLive.SharpBukkit.TypeConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBukkitLive
{
    public class BasicCommands : SharpBukkitCommandController
    {
        public static Func<ReflSharpBukkitCommand, string> CommandInfoFormat =
            p =>
                (p.Attr.OPOnly ? FormattingCodes.Magenta : FormattingCodes.Yellow) + p.Name.ToLower()
                + (p.Signature.Length <= 0 ? "" : " " + FormattingCodes.DarkYellow + p.Signature)
                + (String.IsNullOrWhiteSpace(p.Attr.Description) ? "" : $" {FormattingCodes.White}-{FormattingCodes.Grey} {p.Attr.Description}")
            ;//$"{FormattingCodes.Yellow}{p.Name.ToLower()}{(p.Signature.Length > 0 ? " " + FormattingCodes.DarkYellow + p.Signature : "")}{(String.IsNullOrWhiteSpace(p.Attr.Description) ? "" : $" {FormattingCodes.White}- {FormattingCodes.Grey} {p.Attr.Description}")}";

        /***
         * User Commands
         ***/
        [SharpBukkitCommand("Prints available commands")]
        public void Help(int page = 1)
        {
            var resp = PagedList<ReflSharpBukkitCommand>(
                PluginManager.Commands.Where(p =>
                    (p.Attr.OPOnly ? IsUserOP : true)
                    && (p.Attr.PlayerOnly ? IsUserPlayer : true)
                    && !p.Attr.HideFromSearch)
                .OrderBy(p => p.Name) //TODO: Logic for listing different commands for different permissions
                , CommandInfoFormat
                , out string output
                , page
            );

            if (resp == PagedListResult.PageDoesNotExist)
                Respond($"{FormattingCodes.Red}Error:{FormattingCodes.Reset} That page does not exist");
            else if (resp == PagedListResult.NoItems)
                Respond($"{FormattingCodes.Red}Error:{FormattingCodes.Reset} Couldn't find any commands???");
            else
                Respond(SplitStringByLines(FormattingCodes.Grey + output));
        }

        [SharpBukkitCommand("Prints the available formatting codes")]
        public void Colors()
        {
            Respond("Color: §00§11§22§33§44§55§66§77§88§99§aa§bb§cc§dd§ee§ff§r");
            Respond("Reset: §rr");
        }

        [SharpBukkitCommand]
        public void Date(DateTime dt)
        {
            Respond(dt.ToString("R"));
        }

        [SharpBukkitCommand("Prints the temperature and humidity where you're currently standing", "temp", PlayerOnly = true)]
        public void GetTemperature()
        {
            Player.Entity.worldObj.GetWorldChunkManager().LoadBlockGeneratorData((int)Player.Entity.posX, (int)Player.Entity.posZ, 1, 1);
            Respond($"{FormattingCodes.Yellow}Temperature{FormattingCodes.Reset}: {Player.Entity.worldObj.GetWorldChunkManager().temperature[0]:0.00}");
            Respond($"{FormattingCodes.Cyan}Humidity{FormattingCodes.Reset}: {Player.Entity.worldObj.GetWorldChunkManager().humidity[0]:0.00}");
        }

        [SharpBukkitCommand("Pings a player with a sound and a message")]
        public void Ping(string Username)
        {
            SharpBukkitPlayer player = FindPlayer(Username);

            if (player == null)
            {
                Respond($"{FormattingCodes.Red}Error:{FormattingCodes.Reset} Could not find any player by that username");
                return;
            }

            Task.Run(async () =>
            {
                player.SendSound(SoundType.CLICK1);
                await Task.Delay(100);
                player.SendSound(SoundType.CLICK1);
                await Task.Delay(100);
                player.SendSound(SoundType.CLICK1);
            });
            player.SendMessage($"{FormattingCodes.Magenta}* You have been pinged by {User.GetUsername()}");
        }

        /***
         * Admin Commands
         ***/
        [SharpBukkitCommand("Initiates a shutdown of the server", OPOnly = true)]
        public void Stop()
        {
            Server.InitiateShutdown();
        }

        [SharpBukkitCommand("Adds a player to the list of operators", OPOnly = true)]
        public void OP(string Username)
        {
            SendMessageToOPs($"{FormattingCodes.Yellow}{Username} has been OP'ed by {User.GetUsername()}");
            ConfigManager.OpPlayer(Username);
            ConfigManager.SendChatMessageToPlayer(Username, $"{FormattingCodes.Yellow}You have been OP'ed");
        }

        [SharpBukkitCommand("Removes a player to the list of operators", OPOnly = true)]
        public void DeOP(string Username)
        {
            ConfigManager.DeopPlayer(Username);
            SendMessageToOPs($"{FormattingCodes.DarkYellow}{Username} has been De-OP'ed by {User.GetUsername()}");
            ConfigManager.SendChatMessageToPlayer(Username, $"{FormattingCodes.DarkYellow}You have been De-OP'ed");
        }

        [SharpBukkitCommand("", "banip", HideFromSearch = true)]
        [SharpBukkitCommand("Bans an IP address", "ban-ip", OPOnly = true)]
        public void BanIP(string IP)
        {
            ConfigManager.BanIP(IP);
            SendMessageToOPs($"{FormattingCodes.DarkYellow}The IP {FormattingCodes.DarkRed}{IP}{FormattingCodes.DarkYellow} has been banned by {User.GetUsername()}");
        }

        [SharpBukkitCommand("", "unbanip", HideFromSearch = true)]
        [SharpBukkitCommand("", "pardonip", HideFromSearch = true)]
        [SharpBukkitCommand("Unbans an IP address", "pardon-ip", OPOnly = true)]
        public void UnbanIP(string IP)
        {
            ConfigManager.PardonIP(IP);
            SendMessageToOPs($"{FormattingCodes.DarkYellow}The IP {FormattingCodes.DarkRed}{IP}{FormattingCodes.DarkYellow} has been unbanned by {User.GetUsername()}");
        }

        [SharpBukkitCommand("Bans a player", "ban", OPOnly = true)]
        public void BanPlayer(string Username)
        {
            ConfigManager.BanPlayer(Username);
            SendMessageToOPs($"{FormattingCodes.DarkYellow}The player {FormattingCodes.DarkRed}{Username}{FormattingCodes.DarkYellow} has been banned by {User.GetUsername()}");
        }

        [SharpBukkitCommand("", "unban", HideFromSearch = true)]
        [SharpBukkitCommand("Unbans a player", "pardon", OPOnly = true)]
        public void UnbanPlayer(string Username)
        {
            ConfigManager.PardonPlayer(Username);
            SendMessageToOPs($"{FormattingCodes.DarkYellow}The player {FormattingCodes.DarkRed}{Username}{FormattingCodes.DarkYellow} has been unbanned by {User.GetUsername()}");
        }

        [SharpBukkitCommand("Gives you an item", OPOnly = true, PlayerOnly = true)]
        public void Give(string item, int amount = 1)
        {
            Give(User.GetUsername(), item, amount);
        }
        [SharpBukkitCommand("Gives a player an item", OPOnly = true, PlayerOnly = true)]
        public void Give(string Username, string item, int amount = 1)
        {
            SharpBukkitPlayer player = FindPlayer(Username);
            if (player == null)
            {
                Respond($"{FormattingCodes.Red}Error:{FormattingCodes.Reset} Could not find any player by that username");
                return;
            }

            if(!MinecraftItemConverter.ItemDict.ContainsKey(item))
            {
                Respond($"{FormattingCodes.Red}Error:{FormattingCodes.Reset} Could not find any item by the name of '{item}'");
                return;
            }

            if(amount <= 0)
            {
                Respond($"{FormattingCodes.Red}Error:{FormattingCodes.Reset} Amount must be above 0");
                return;
            }

            player.Entity.DropPlayerItem(new net.minecraft.src.ItemStack(MinecraftItemConverter.ItemDict[item], amount, 0));
        }
    }
}
