﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetCrafterMod
{
    public static class WindowManager
    {
        private static int nextWindowID = 1;

        public static int GetNextWindowID()
        {
            return nextWindowID++;
        }
    }
}
