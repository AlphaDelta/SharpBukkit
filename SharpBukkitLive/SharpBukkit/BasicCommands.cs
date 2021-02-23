using SharpBukkitLive.Interface.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpBukkitLive
{
    public class BasicCommands : SharpBukkitCommandController
    {
        [SharpBukkitCommand("Prints available commands")]
        public void Help(int page = 0)
        {
            Respond($"Page = {page}");
        }

        [SharpBukkitCommand("Prints the available formatting codes")]
        public void FormattingCodes(int page = 0)
        {
            Respond("Color: §00§11§22§33§44§55§66§77§88§99§aa§bb§cc§dd§ee§ff§r");
            Respond("Reset: §rr");
        }

        [SharpBukkitCommand("Initiates a shutdown of the server", OPOnly = true)]
        public void Stop()
        {
            Server.InitiateShutdown();
        }
    }
}
