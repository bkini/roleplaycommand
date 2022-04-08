using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using UnityEngine;

namespace CommandSamp
{
    class CommandDo : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "do";

        public string Help => "";

        public string Syntax => "/do <text>";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string> { "command.do" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            string message = string.Join(" ", command);

            UnturnedPlayer[] otherPlayers = Plugin.GetUnturnedPlayerInRadius(player.Position, Plugin.Instance.Configuration.Instance.radius_do);

            foreach (UnturnedPlayer otherPlayer in otherPlayers)
            {
                UnturnedChat.Say(otherPlayer, player.DisplayName + ": " + message, UnturnedChat.GetColorFromName(Plugin.Instance.Configuration.Instance.color_do, Color.white));
            }
        }
    }
}
