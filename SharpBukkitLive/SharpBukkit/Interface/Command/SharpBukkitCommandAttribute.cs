using System;
using System.Collections.Generic;
using System.Text;

namespace SharpBukkitLive.Interface.Command
{
    public class SharpBukkitCommandAttribute : Attribute
    {
        public string Name, Description;
        public bool OPOnly, PlayerOnly;
        public bool HideFromSearch;

        public SharpBukkitCommandAttribute(string Description = null, string Name = null, bool OPOnly = false, bool PlayerOnly = false, bool HideFromSearch = false)
        {
            this.Name = Name;
            this.Description = Description;
            this.OPOnly = OPOnly;
            this.PlayerOnly = PlayerOnly;
            this.HideFromSearch = HideFromSearch;
        }
    }
}
