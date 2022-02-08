using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowPlayStats
{
    [HarmonyPatch(typeof(scrController), "Restart")]
    public static class RestartPatcher
    {
        public static void Postfix()
        {
            Main.combo = 0;
            Main.score = 0;
            ChangeText.Death = 0;
            ChangeText.Overload = 0;
        }
    }
}
