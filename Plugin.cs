using Rocket.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using SDG.Unturned;
using UnityEngine;
using Rocket.API.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using System.IO;

namespace CommandSamp
{
    public class Plugin : RocketPlugin <Config>
    {
        public static Plugin Instance;
        public override TranslationList DefaultTranslations
        {
            get
            {
                TranslationList translitionList = new TranslationList();
                translitionList.Add("not_have_item", "Вы не имеете специального предмета в своем инвентаре.");
                translitionList.Add("syntax", "Используйте данный синтаксис: {0}");
                return translitionList;
            }
        }
        protected override void Load()
        {
            Instance = this;
            Console.WriteLine("#################Information#################", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("# Enabled:", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("          ");
            Console.Write("True", Console.ForegroundColor = ConsoleColor.Green);
            Console.Write("                    ");
            Console.Write("#\n", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("# VK:", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("               ");
            Console.Write("vk.com/ogyvan", Console.ForegroundColor = ConsoleColor.Magenta);
            Console.Write("           ");
            Console.Write("#\n", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("# Version:", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("          ");
            Console.Write("1.0", Console.ForegroundColor = ConsoleColor.White);
            Console.Write("                     ");
            Console.Write("#\n", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("# Build:", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("            ");
            Console.Write("#6 [27.04.2020]", Console.ForegroundColor = ConsoleColor.White);
            Console.Write("         ");
            Console.Write("#\n", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("# Author:", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("           ");
            Console.Write("Ogyvan ", Console.ForegroundColor = ConsoleColor.Magenta);
            Console.Write("                 ");
            Console.Write("#\n", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.WriteLine("#################Information#################", Console.ForegroundColor = ConsoleColor.Cyan);
        }

        protected override void Unload()
        {
            Console.WriteLine("#################Information#################", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("# Enabled:", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("          ");
            Console.Write("False", Console.ForegroundColor = ConsoleColor.Red);
            Console.Write("                   ");
            Console.Write("#\n", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("# VK:", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("               ");
            Console.Write("vk.com/ogyvan", Console.ForegroundColor = ConsoleColor.Magenta);
            Console.Write("           ");
            Console.Write("#\n", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("# Version:", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("          ");
            Console.Write("1.0", Console.ForegroundColor = ConsoleColor.White);
            Console.Write("                     ");
            Console.Write("#\n", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("# Build:", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("            ");
            Console.Write("#6 [27.04.2020]", Console.ForegroundColor = ConsoleColor.White);
            Console.Write("         ");
            Console.Write("#\n", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("# Author:", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("           ");
            Console.Write("Ogyvan ", Console.ForegroundColor = ConsoleColor.Magenta);
            Console.Write("                 ");
            Console.Write("#\n", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.WriteLine("#################Information#################", Console.ForegroundColor = ConsoleColor.Cyan);
        }
        public static UnturnedPlayer[] GetUnturnedPlayerInRadius(Vector3 center, float radius)
        {
            var playerList = new List<Player>();
            PlayerTool.getPlayersInRadius(center, radius * radius, playerList);
            var result = new UnturnedPlayer[playerList.Count];
            for (int i = 0; i < playerList.Count; i++)
            {
                result[i] = UnturnedPlayer.FromPlayer(playerList[i]);
            }
            return result;
        }
        public static bool IsHaveItem(UnturnedPlayer player, ushort ID)
        {
            try
            {
                for (int i = 0; i < PlayerInventory.PAGES; i++)
                {
                    for (byte b = 0; b < PlayerInventory.PAGES; b += 1)
                    {
                        byte itemCount = player.Player.inventory.getItemCount(b);
                        for (byte b2 = 0; b2 < itemCount; b2 += 1)
                        {
                            if (player.Player.inventory.getItem(b, b2).item.id == ID)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}
