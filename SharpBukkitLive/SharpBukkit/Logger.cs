using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SharpBukkitLive.SharpBukkit
{
    public class Logger
    {
        private Logger() { }
        static Logger _logger = null;
        public static Logger GetLogger()
        {
            if (_logger == null) _logger = new Logger();
            return _logger;
        }

        FileStream fs = null;
        public void Log(string s, ConsoleColor c = ConsoleColor.Gray) {
            Console.ForegroundColor = c;
            Console.WriteLine(s);
        }

        public void Finest(string s)  { Log("[FINEST] " + s); }
        public void Finer(string s)   { Log("[FINER ] " + s); }
        public void Fine(string s)    { Log("[ FINE ] " + s); }
        public void Info(string s)    { Log("[ INFO ] " + s, ConsoleColor.Cyan); }
        public void Warning(string s) { Log("[ WARN ] " + s, ConsoleColor.Yellow); }
        public void Severe(string s)  { Log("[SEVERE] " + s, ConsoleColor.Red); }

        public void AddHandler(string filehandler)
        {
            fs = File.OpenWrite(filehandler);
        }
    }
}
