using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;

namespace CommandSamp
{
    public class Config : IRocketPluginConfiguration
    {
        public float radius_try;
        public float radius_do;
        public float radius_me;
        public float radius_nrp;
        public float radius_s;
        public float radius_w;
        public ushort items;
        public string color_do;
        public string color_me;
        public string color_nrp;
        public string color_s;
        public string color_w;
        public void LoadDefaults()
        {
            radius_try = 30.1f;
            radius_do = 30.1f;
            radius_me = 30.1f;
            radius_nrp = 100.1f;
            radius_s = 300.1f;
            radius_w = 10.1f;
            items = 1176;
            color_do = "green";
            color_me = "magneta";
            color_nrp = "white";
            color_s = "white";
            color_w = "white";
        }
    }
}
