using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowPlayStats
{
    internal static class Patches
    {
        //[HarmonyPatch(typeof(scrController), "CountValidKeysPressed")]
        [PatchCondition("ShowPlayStats.scrControllerCountdownPatch","scrController", "Countdown_Update")]
        public static class StartLoadingPatcher
        {
            public static void Postfix()
            {
                Main.isdeath = false;
            }
        }

        [PatchCondition("ShowPlayStats.scrControllerCheckpointPatch","scrController", "Checkpoint_Enter")]
        public static class CheckpointPatcher
        {
            public static void Postfix()
            {
                Main.isdeath = false;
            }
        }
    }
}
