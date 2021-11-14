using DeatsCounter;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathsCounter
{
    [HarmonyPatch(typeof(scrMistakesManager), "AddHit")]
    public static class AddhitPatcher
    {
        public static void Postfix(scrMistakesManager __instance, HitMargin hit)
        {
            if (hit == HitMargin.Perfect)
            {
                Main.combo++;
            }
            else
            {
                Main.combo = 0;
            }

            switch (hit)
            {
                case HitMargin.VeryEarly:
                case HitMargin.VeryLate:
                    Main.score += 91;
                    break;
                case HitMargin.EarlyPerfect:
                case HitMargin.LatePerfect:
                    Main.score += 150;
                    break;
                case HitMargin.Perfect:
                    Main.score += 300;
                    break;
            }
        }
    }
}
