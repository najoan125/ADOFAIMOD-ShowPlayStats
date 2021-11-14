using DeatsCounter;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathsCounter
{
    [HarmonyPatch(typeof(PauseMenu), "Choose")]
    public static class Patch
    {
        public static void Prefix()
        {
            Main.score = 0;
            Main.combo = 0;
            ChangeText.Death = 0;
        }
    }
}
