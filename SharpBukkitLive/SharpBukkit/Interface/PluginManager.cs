using SharpBukkitLive.Interface.Command;
using SharpBukkitLive.SharpBukkit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SharpBukkitLive.Interface
{
    internal static class PluginManager
    {
        public static List<ReflSharpBukkitCommand> Commands = new List<ReflSharpBukkitCommand>();
        internal static List<Assembly> Modules;
        internal static void LoadAllFromDisk()
        {
            /* Load plugins */
            Entrypoint.logger.Info("Loading SharpBukkit plugins");
            Assembly asm = Assembly.GetExecutingAssembly();
            string expath = Path.Combine(Path.GetDirectoryName(asm.Location), "plugins");
            int loaded = 0;
            if (!Directory.Exists(expath)) Directory.CreateDirectory(expath);
            if (Directory.Exists(expath)) //Edge case
            {
                string[] files = Directory.GetFiles(expath, "*.dll");

                foreach (string f in files)
                {
                    string fname = Path.GetFileNameWithoutExtension(f);
                    if (fname == "SharpBukkitLive" || !fname.StartsWith("SharpBukkit.")) continue;

                    System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(f);
                    loaded++;
                }
            }

            Modules = AppDomain.CurrentDomain.GetAssemblies().Where(p => p.FullName.StartsWith("SharpBukkit.")).ToList();
            Modules.Add(asm);

            Entrypoint.logger.Info($"Loaded {loaded} ancillary plugins");
        }

        internal static void LoadCommands()
        {
            Entrypoint.logger.Info($"Loading commands");

            LoadCommandsFromAssemblies(Modules);

            Entrypoint.logger.Info($"Loaded {Commands.Count} commands");
        }

        internal static void LoadCommandsFromAssemblies(IEnumerable<Assembly> modules)
        {
            Type attr = typeof(SharpBukkitCommandAttribute);

            foreach (Assembly asm in modules)
            {
                Type[] ts = asm.GetExportedTypes();
                foreach (Type t in ts)
                {
                    if (t.Namespace.StartsWith("net.minecraft") || !t.IsSubclassOf(typeof(SharpBukkitCommandController))) continue;

                    MethodInfo[] mis = t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                    List<ReflSharpBukkitCommand> tempcommands = new List<ReflSharpBukkitCommand>();
                    foreach (MethodInfo mi in mis)
                    {
                        //if (mi.ReturnType != typeof(Task) || mi.IsStatic) continue; //Maybe one day I'll make it async
                        if (mi.IsStatic) continue;

                        IEnumerable<Attribute> coms = mi.GetCustomAttributes(attr);
                        Attribute com = coms.FirstOrDefault(a => a.GetType() == attr);

                        if (com == null) continue;

                        tempcommands.Add(new ReflSharpBukkitCommand(mi, (SharpBukkitCommandAttribute)com));
                    }

                    Commands.AddRange(tempcommands);
                }
            }
        }


        public static void ParseInvocation(string str, out string command, out string[] oargs)
        {
            command = null;
            oargs = null;

            /* Command */
            string cstr = str.Trim();
            int cmdi = cstr.IndexOf(' ');
            if (cmdi < 0)
            {
                command = cstr;
                oargs = new string[0];
                return;
            }

            command = cstr.Substring(0, cmdi).ToLower();
            cstr = cstr.Substring(cmdi + 1);

            /* Arguments */
            string[] spl = cstr.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<string> args = new List<string>();
            bool inquote = false;
            int q = -1;
            for (int i = 0; i < spl.Length; i++)
            {
                if (!inquote)
                {
                    if (spl[i][0] != '"')
                        args.Add(spl[i].Replace("\\\"", "\""));
                    else
                    {
                        if (spl[i].EndsWith('"') && (spl[i].Length < 2 || spl[i][spl[i].Length - 2] != '\\'))
                        {
                            if (spl[i].Length > 2)
                                args.Add(spl[i].Substring(1, spl[i].Length - 2).Replace("\\\"", "\""));
                        }
                        else
                        {
                            q = i;
                            inquote = true;
                        }
                    }
                }
                else if (spl[i].EndsWith('"') && (spl[i].Length < 2 || spl[i][spl[i].Length - 2] != '\\'))
                {
                    inquote = false;

                    string join = String.Join(' ', spl, q, i - q + 1);
                    args.Add(join.Substring(1, join.Length - 2).Replace("\\\"", "\""));
                }
            }

            if (inquote)
            {
                for (int i = q; i < spl.Length; i++)
                    args.Add(spl[i].Replace("\\\"", "\""));
            }

            oargs = args.ToArray();
        }


        internal static (ReflSharpBukkitCommand, string) NearestSignature(int length, IEnumerable<(ReflSharpBukkitCommand, string)> vcmds)
        {
            (ReflSharpBukkitCommand, string) valid;
            if (vcmds.Count() > 1)
            {
                valid = vcmds.FirstOrDefault(p => p.Item1.Params.Length == length);

                if (valid.Item1 == null)
                    valid = vcmds.Where(p => p.Item1.Params.Length > length).OrderBy(p => p.Item1.Params.Count()).FirstOrDefault();

                if (valid.Item1 == null)
                    valid = vcmds.OrderByDescending(p => p.Item1.Params.Length).FirstOrDefault();
            }
            else valid = vcmds.FirstOrDefault();

            return valid;
        }
    }
}
