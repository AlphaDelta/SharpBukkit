using net.minecraft.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBukkitLive.Interface.Command
{
    public class SharpBukkitCommandController
    {
        public net.minecraft.server.MinecraftServer Server { get; internal set; }
        public ICommandListener User { get; internal set; }
        public string FullMessage { get; internal set; }
        public ReflSharpBukkitCommand CurrentCommand { get; internal set; }

        /// <summary>
        /// This function is run before a command is executed in the controller
        /// </summary>
        /// <returns>True if the command should be executed, false if it should be terminated.</returns>
        public virtual bool PreExecution() { return true; }

        /// <summary>
        /// This function will always run after the end of command processing. Use this for disposing objects.
        /// </summary>
        public virtual void Always() { }

        /// <summary>
        /// This function will always run after the end of command execution. Use this for resolving locks.
        /// </summary>
        /// <returns></returns>
        public virtual void AlwaysAfterExecute() { }


        /* Useful functions */
        public void Respond(string[] message)
        {
            foreach (string s in message)
                Respond(s);
        }
        public void Respond(string message)
        {
            User.Log(message);
        }

        public PagedListResult PagedList<T>(IEnumerable<T> items, Func<T, string> tostring, out string output, int page = 1, int itemsperpage = 15, string title = "Results")
        {
            output = "";
            page--;

            if (page < 0) page = 0;
            if (itemsperpage < 1) page = 15;

            int count = items.Count();
            if (count < 1) return PagedListResult.NoItems;
            int pages = (int)Math.Ceiling((float)count / (float)itemsperpage);
            if (page >= pages) return PagedListResult.PageDoesNotExist;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"--- {title} ({count} items, page {page + 1} of {pages}) ---");

            var taken = items.Skip(itemsperpage * page).Take(itemsperpage);
            foreach (T item in taken)
                sb.AppendLine(tostring(item));

            output = sb.ToString();
            return PagedListResult.Success;
        }

        public string[] SplitStringByLines(string s, bool removeEmptyEntries = true)
        {
            return s.Split(new string[] { "\r\n", "\n", "\r", "\\n" }, removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
        }
    }
}
