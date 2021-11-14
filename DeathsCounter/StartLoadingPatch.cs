using DeatsCounter;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowPlayStats
{
    [HarmonyPatch(typeof(scrController), "CountValidKeysPressed")]
    public static class StartLoadingPatcher
    {
        public static void Postfix()
        {
            Main.isdeath = false;
        }
    }
}
