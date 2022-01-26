using System;
using HarmonyLib;

namespace ShowPlayStats
{
	// Token: 0x02000003 RID: 3
	[HarmonyPatch(typeof(scrController), "PlayerControl_Update")]
	internal static class ChangeText
	{
		// Token: 0x06000007 RID: 7 RVA: 0x0000213C File Offset: 0x0000033C
		[HarmonyPatch(typeof(scrController), "FailAction")]
		private static void Prefix(bool overload = false)
		{
			bool isEnabled = Main.IsEnabled;
			if (isEnabled)
			{
				ChangeText.Death++;
				Main.isdeath = true;
				Main.combo = 0;
				Main.score = 0;
			}
			if (overload)
            {
				ChangeText.Overload++;
            }
		}

		// Token: 0x04000005 RID: 5
		public static int Death, Overload;
	}
}
