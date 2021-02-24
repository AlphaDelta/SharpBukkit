using SharpBukkitLive.Interface;
using SharpBukkitLive.Interface.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBukkitLive
{
    public class BasicCommands : SharpBukkitCommandController
    {
        [SharpBukkitCommand("Prints available commands")]
        public void Help(int page = 1)
        {
            var resp = PagedList<ReflSharpBukkitCommand>(
                PluginManager.Commands.Where(p => /*!p.Attr.Admin && */ !p.Attr.HideFromSearch).OrderBy(p => p.Name)
                , p => $"{FormattingCodes.Yellow}{p.Name.ToLower()}{(p.Signature.Length > 0 ? " " + FormattingCodes.DarkYellow + p.Signature : "")}{(String.IsNullOrWhiteSpace(p.Attr.Description) ? "" : $" {FormattingCodes.White}- {FormattingCodes.Grey}" + p.Attr.Description)}"
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

        [SharpBukkitCommand("Initiates a shutdown of the server", OPOnly = true)]
        public void Stop()
        {
            Server.InitiateShutdown();
        }
    }
}
