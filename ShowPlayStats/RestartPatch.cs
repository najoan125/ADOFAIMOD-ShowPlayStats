using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityModManagerNet;

namespace ShowPlayStats
{
    [HarmonyPatch(typeof(scrController), "Restart")]
    public static class RestartPatcher
    {
        public static void Postfix(bool fromBeginning = false)
        {
            if (fromBeginning)
            {
                Main.combo = 0;
                Main.score = 0;
                ChangeText.Death = 0;
                ChangeText.Overload = 0;
                ChangeText.exceptOverload = 0;
            }
        }
    }
}
