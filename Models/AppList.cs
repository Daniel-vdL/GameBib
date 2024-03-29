﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Models
{
    public class App
    {
        public int appid { get; set; }
        public string name { get; set; }

        public static List<string> WantedGames { get; } = new List<string>();
    }

    public class AppList
    {
        public List<App> apps { get; set; }
    }

    public class RootObject
    {
        public AppList applist { get; set; }
    }
}
