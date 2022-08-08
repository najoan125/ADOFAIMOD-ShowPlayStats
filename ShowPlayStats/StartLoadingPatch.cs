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

        [PatchCondition("ShowPlayStats.scnEditorOpenLevelPatch","scnEditor", "ShowNotification")]
        public static class OpenLevelPatcher
        {
            public static void Prefix(string text)
            {
                if (text == RDString.Get("editor.notification.levelLoaded", null))
                {
                    ChangeText.Death = 0;
                    ChangeText.Overload = 0;
                    ChangeText.exceptOverload = 0;
                }
            }
        }

        [HarmonyPatch(typeof(scnEditor),"Play")]
        public static class PlayPatch
        {
            public static void Prefix()
            {
                Main.isdeath = false;
            }
        }
    }
}
