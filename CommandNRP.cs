using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using UnityEngine;

namespace CommandSamp
{
    class CommandNRP : IRocketCommand
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
                return "nrp";
            }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string> { "command.nrp" };
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
            UnturnedPlayer[] otherplayer = Plugin.GetUnturnedPlayerInRadius(player.Position, Plugin.Instance.Configuration.Instance.radius_nrp);
            if (otherplayer != null)
            {
                for (int i = 0; i < otherplayer.Length; i++)
                {
                    if (Plugin.IsHaveItem(player, Plugin.Instance.Configuration.Instance.items) || Plugin.Instance.Configuration.Instance.items == 0)
                    {
                        UnturnedChat.Say(otherplayer[i], player.DisplayName + " [NRP]: " + message, UnturnedChat.GetColorFromName(Plugin.Instance.Configuration.Instance.color_nrp, Color.white));
                    }
                    else
                    {
                        UnturnedChat.Say(player, Plugin.Instance.Translate("not_have_item"));
                        return;
                    }
                }
            }
        }
    }
}
