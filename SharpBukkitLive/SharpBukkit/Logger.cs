using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SharpBukkitLive.SharpBukkit
{
    public class Logger
    {
        static Dictionary<char, ConsoleColor> FormattingCodeTable = new Dictionary<char, ConsoleColor>();
        static Logger()
        {
            FormattingCodeTable['0'] = ConsoleColor.Black;
            FormattingCodeTable['1'] = ConsoleColor.DarkBlue;
            FormattingCodeTable['2'] = ConsoleColor.DarkGreen;
            FormattingCodeTable['3'] = ConsoleColor.DarkCyan;
            FormattingCodeTable['4'] = ConsoleColor.DarkRed;
            FormattingCodeTable['5'] = ConsoleColor.DarkMagenta;
            FormattingCodeTable['6'] = ConsoleColor.DarkYellow;
            FormattingCodeTable['7'] = ConsoleColor.Gray;
            FormattingCodeTable['8'] = ConsoleColor.DarkGray;
            FormattingCodeTable['9'] = ConsoleColor.Blue;
            FormattingCodeTable['a'] = ConsoleColor.Green;
            FormattingCodeTable['b'] = ConsoleColor.Cyan;
            FormattingCodeTable['c'] = ConsoleColor.Red;
            FormattingCodeTable['d'] = ConsoleColor.Magenta;
            FormattingCodeTable['e'] = ConsoleColor.Yellow;
            FormattingCodeTable['f'] = ConsoleColor.White;
            FormattingCodeTable['r'] = ConsoleColor.Gray;
        }

        private Logger() { }
        static Logger _logger = null;
        public static Logger GetLogger()
        {
            if (_logger == null) _logger = new Logger();
            return _logger;
        }

        FileStream fs = null;
        public void Log(string s, ConsoleColor c = ConsoleColor.Gray)
        {
            Console.ForegroundColor = c;
            if (!s.Contains("§"))
            {
                Console.WriteLine(s);
            }
            else
            {
                string[] strs = s.Split('§', StringSplitOptions.None);
                bool firstline = true;
                foreach (string cs in strs)
                {
                    if (String.IsNullOrEmpty(cs)) continue;
                    if (cs.Length < 2) continue;

                    if (FormattingCodeTable.ContainsKey(cs[0]))
                    {
                        if (!firstline) Console.ForegroundColor = FormattingCodeTable[cs[0]];
                        Console.Write(cs.Substring(1));
                    } else Console.Write(cs);

                    firstline = false;
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Finest(string s) { Log("[FINEST] " + s); }
        public void Finer(string s) { Log("[FINER ] " + s); }
        public void Fine(string s) { Log("[ FINE ] " + s); }
        public void Info(string s) { Log("[ INFO ] " + s, ConsoleColor.Cyan); }
        public void Warning(string s) { Log("[ WARN ] " + s, ConsoleColor.Yellow); }
        public void Severe(string s) { Log("[SEVERE] " + s, ConsoleColor.Red); }

        public void AddHandler(string filehandler)
        {
            fs = File.OpenWrite(filehandler);
        }

    }
}
