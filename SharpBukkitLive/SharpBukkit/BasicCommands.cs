using SharpBukkitLive.SharpBukkit;
using SharpBukkitLive.SharpBukkit.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            PlayerEntity.worldObj.GetWorldChunkManager().LoadBlockGeneratorData((int)PlayerEntity.posX, (int)PlayerEntity.posZ, 1, 1);
            Respond("Temperature: " + PlayerEntity.worldObj.GetWorldChunkManager().temperature[0]);
            Respond("Humidity: " + PlayerEntity.worldObj.GetWorldChunkManager().humidity[0]);
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
    }
}
