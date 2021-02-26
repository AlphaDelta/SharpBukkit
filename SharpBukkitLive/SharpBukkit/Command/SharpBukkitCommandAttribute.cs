using System;
using System.Collections.Generic;
using System.Text;

namespace SharpBukkitLive.SharpBukkit.Command
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SharpBukkitCommandAttribute : Attribute
    {
        public readonly string Name, Description;
        public bool OPOnly, PlayerOnly;
        public bool HideFromSearch;

        public SharpBukkitCommandAttribute(string Description = null, string Name = null)
        {
            this.Name = Name;
            this.Description = Description;
        }
    }
}
