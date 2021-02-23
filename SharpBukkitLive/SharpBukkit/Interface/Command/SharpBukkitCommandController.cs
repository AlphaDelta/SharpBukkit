using net.minecraft.src;
using System;
using System.Collections.Generic;
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
        public void Respond(string message)
        {
            User.Log(message);
        }
    }
}
