using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using UnityEngine;

namespace CommandSamp
{
    class CommandTry : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "try";

        public string Help => "";

        public string Syntax => "/try <text | Удачно/Неудачно>";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string> { "command.try" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            string message = string.Join(" ", command);

            Color mainColor = player.Color;

            if (message.ToLower().Contains("неудачно")) mainColor = Color.red;
            else if (message.ToLower().Contains("удачно")) mainColor = Color.green;
            else
            {
                UnturnedChat.Say(player, Plugin.Instance.Translate("syntax"), Color.red);
                return;
            }

            UnturnedPlayer[] otherPlayers = Plugin.GetUnturnedPlayerInRadius(player.Position, Plugin.Instance.Configuration.Instance.radius_try);

            foreach (UnturnedPlayer otherPlayer in otherPlayers)
            {
                UnturnedChat.Say(otherPlayer, player.DisplayName + ": " + message, mainColor);
            }
        }
    }
}
