using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using UnityEngine;

namespace CommandSamp
{
    class CommandMe : IRocketCommand
    {
        public List<string> Aliases
        {
            get
            {
                return new List<string> { };
            }
        }

        public AllowedCaller AllowedCaller
        {
            get
            {
                return AllowedCaller.Player;
            }
        }

        public string Help
        {
            get
            {
                return "";
            }
        }

        public string Name
        {
            get
            {
                return "me";
            }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string> { "command.me" };
            }
        }

        public string Syntax
        {
            get
            {
                return "";
            }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            string message;
            message = string.Join(" ", command);
            UnturnedPlayer[] otherplayer = Plugin.GetUnturnedPlayerInRadius(player.Position, Plugin.Instance.Configuration.Instance.radius_me);
            if (otherplayer != null)
            {
                for (int i = 0; i < otherplayer.Length; i++)
                {
                    UnturnedChat.Say(otherplayer[i], player.DisplayName + ": " + message, UnturnedChat.GetColorFromName(Plugin.Instance.Configuration.Instance.color_me, Color.white));
                }
            }
        }
    }
}
