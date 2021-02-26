using net.minecraft.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpBukkitLive.SharpBukkit
{
    public class SharpBukkitPlayer
    {
        public readonly net.minecraft.src.NetServerHandler NetServerHandler;

        public EntityPlayerMP Entity => NetServerHandler.playerEntity;

        /// <summary>
        /// The player's network username.
        /// </summary>
        public string Username => NetServerHandler.GetUsername();

        //TODO
        /// <summary>
        /// Not currently in use
        /// </summary>
        public string DisplayName
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_DisplayName))
                    return Username;
                return _DisplayName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    value = null;

                _DisplayName = value;
            }
        }
        string _DisplayName = null;

        public SharpBukkitPlayer(EntityPlayerMP entityplayermp)
        {
            this.NetServerHandler = entityplayermp.playerNetServerHandler;
        }

        public Dictionary<string, object> Memory = new Dictionary<string, object>();

        /**
         * Methods
         **/
        public void SendPacket(Packet packet)
        {
            NetServerHandler.SendPacket(packet);
        }

        /// <summary>
        /// Plays a sound for the player at the position they're standing
        /// </summary>
        public void SendSound(SoundType type)
        {
            SendSound(type, (int)Entity.posX, (int)Entity.posY, (int)Entity.posZ);
        }
        /// <summary>
        /// Plays a sound for the player.
        /// </summary>
        public void SendSound(SoundType type, int x, int y, int z)
        {
            SendPacket(new Packet61DoorChange((int)type, x, y, z, 0));
        }

        /// <summary>
        /// Sends a chat message to the player
        /// </summary>
        public void SendMessage(string message)
        {
            SendPacket(new Packet3Chat(message));
        }
    }
}
