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
        [SharpBukkitCommand("Initiates a shutdown of the server", OPOnly = true)]
        public void Stop()
        {
            Server.InitiateShutdown();
        }
    }
}
