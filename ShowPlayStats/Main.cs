﻿using System;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;

namespace ShowPlayStats
{
	// Token: 0x02000002 RID: 2
	internal static class Main
	{
		public static bool isplaying = false;
		public static bool isdeath = false;
		public static int combo = 0;
		public static int score = 0;
        private static String 정확도 = "";
        private static String Combo = "";
		private static String Score = "";
		public static Setting setting;
		public static UnityModManager.ModEntry.ModLogger Logger;
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002057 File Offset: 0x00000257
		internal static bool IsEnabled { get; private set; }

		// Token: 0x06000003 RID: 3 RVA: 0x0000205F File Offset: 0x0000025F
		private static void Load(UnityModManager.ModEntry modEntry)
		{
			Main.Mod = modEntry;
			Main.Mod.OnToggle = new Func<UnityModManager.ModEntry, bool, bool>(Main.OnToggle);
			Main.Mod.OnUpdate = new Action<UnityModManager.ModEntry, float>(Main.OnUpdate);
			setting = new Setting();
			setting = UnityModManager.ModSettings.Load<Setting>(modEntry);
		}

		public static double Accuracy()
		{
			if (setting.accround)
				return Math.Round((double)(scrController.instance.mistakesManager.percentAcc * 100f) * Math.Pow(10.0, setting.acc)) / Math.Pow(10.0, setting.acc);
			else
				return Math.Truncate((double)(scrController.instance.mistakesManager.percentAcc * 100f) * Math.Pow(10.0, setting.acc)) / Math.Pow(10.0, setting.acc);
		}

        //private static float percent;

        // Token: 0x0600001B RID: 27 RVA: 0x00002DB0 File Offset: 0x00000FB0
        public static double Progress()
		{
			//return Math.Truncate((double)((float)scrController.instance.currentSeqID / (float)scrController.instance.lm.listFloors.Count * 100f) * Math.Pow(10.0, (double)2)) / Math.Pow(10.0, (double)2);
			return Math.Truncate((double)(scrController.instance.percentComplete * 100f) * Math.Pow(10.0, setting.per)) / Math.Pow(10.0, setting.per);
		}


		private static void OnUpdate(UnityModManager.ModEntry modEntry, float deltaTime)
        {
			if (!scrConductor.instance || !scrController.instance)
            {
				return;
            }
			isplaying = !scrController.instance.paused && scrConductor.instance.isGameWorld;
			if (isplaying)
            {
				if (setting.DeathCount && !setting.Overload && !setting.exceptOverload)
				{
					Text.Content = string.Concat(new string[]
					{
						setting.str_deathcount + " : ",
						//"죽은 횟수 : ",
						ChangeText.Death.ToString()
					});
				}
				if (setting.DeathCount && setting.Overload && !setting.exceptOverload)
				{
					Text.Content = string.Concat(new string[]
					{
						setting.str_deathcount + " : ",
						//"죽은 횟수 : ",
						ChangeText.Death.ToString(),
						" / " + setting.str_overload + " : ",
						ChangeText.Overload.ToString()
					});
				}

				if (setting.DeathCount && !setting.Overload && setting.exceptOverload)
				{
					Text.Content = string.Concat(new string[]
					{
						setting.str_deathcount + " : ",
						//"죽은 횟수 : ",
						ChangeText.exceptOverload.ToString()
					});
				}
				if (setting.DeathCount && setting.Overload && setting.exceptOverload)
				{
					Text.Content = string.Concat(new string[]
					{
						setting.str_deathcount + " : ",
						//"죽은 횟수 : ",
						ChangeText.exceptOverload.ToString(),
						" / " + setting.str_overload + " : ",
						ChangeText.Overload.ToString()
					});
				}

				if (!setting.DeathCount && setting.Overload)
				{
					Text.Content = string.Concat(new string[]
					{
						setting.str_overload + " : ",
						ChangeText.Overload.ToString()
					});
				}
				if (setting.Progress)
				{
					Text.Content2 = string.Concat(new string[]
					{
						setting.str_progress + " : ",
						//"진행도 : ",
						Progress().ToString(),
						"%"
					});
				}
                if (!isdeath || scrController.instance.noFail)
                {
					정확도 = Accuracy().ToString();
					Combo = combo.ToString();
					Score = score.ToString();
					if (setting.Accuracy)
					{
						Text.Content3 = string.Concat(new string[]
						{
							setting.str_accuracy + " : ",
							Accuracy().ToString(),
						"%"
						});
					}
					if (setting.combo)
					{
						Text.Content4 = string.Concat(new string[]
						{
							setting.str_combo + " : ",
							combo.ToString()
						});
					}
					if (setting.score)
					{
						Text.Content5 = string.Concat(new string[]
						{
							setting.str_score + " : ",
							score.ToString()
						});
					}
				}

				if (isdeath && !scrController.instance.noFail)
				{
					if (setting.Accuracy)
					{
						Text.Content3 = string.Concat(new string[]
						{
							setting.str_accuracy + " : ",
							정확도,
							"%"
						});
					}
					if (setting.combo)
					{
						Text.Content4 = string.Concat(new string[]
						{
							setting.str_combo + " : ",
							Combo
						});
					}
					if (setting.score)
					{
						Text.Content5 = string.Concat(new string[]
						{
							setting.str_score + " : ",
							Score
						});
					}
				}
			}
            else
            {
				Text.Content = " ";
				Text.Content2 = " ";
				Text.Content3 = " ";
				Text.Content4 = " ";
				Text.Content5 = " ";
			}
			if (!scrConductor.instance.isGameWorld)
            {
				ChangeText.Death = 0;
				ChangeText.Overload = 0;
				ChangeText.exceptOverload = 0;
				Main.combo = 0;
				Main.score = 0;
				isdeath = false;
            }
			if (ADOBase.isEditingLevel && scrController.instance.paused)
            {
				Main.combo = 0;
				Main.score = 0;
				//ChangeText.Death = 0;
				//ChangeText.Overload = 0;
			}
        }

		private static void OnGUI(UnityModManager.ModEntry modEntry)
        {
			GUILayout.Label(RDString.language == SystemLanguage.Korean ? "화면에 표시할 항목 설정" : "Set items to be displayed on the screen");
			bool toggleDeathCount = GUILayout.Toggle(setting.DeathCount, RDString.language == SystemLanguage.Korean ? "죽은 횟수 표시" : "Show Deaths");
			if (toggleDeathCount)
			{
				setting.DeathCount = true;
				GUILayout.BeginHorizontal();
				GUILayout.Space(30);
				bool exceptOverload = GUILayout.Toggle(setting.exceptOverload, RDString.language == SystemLanguage.Korean ? "과부하로 죽은 횟수 제외" : "Excluding number of deaths from overload");
				if (exceptOverload)
				{
					setting.exceptOverload = true;
				}
				if (!exceptOverload)
				{
					setting.exceptOverload = false;
				}
				GUILayout.EndHorizontal();

				GUILayout.BeginHorizontal();
				GUILayout.Space(30);
				GUILayout.Label(RDString.language == SystemLanguage.Korean ? "죽은 횟수 텍스트 : " : "Deaths Text : ");
				GUILayout.BeginHorizontal();
				String death = setting.str_deathcount;
				String deathtxt = GUILayout.TextField(death, GUILayout.Width(300));
				if (deathtxt != death)
				{
					setting.str_deathcount = deathtxt;
				}
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				GUILayout.EndHorizontal();
			}
			if (!toggleDeathCount)
			{
				setting.DeathCount = false;
				Text.Content = " ";
			}

			bool toggleOverload = GUILayout.Toggle(setting.Overload, RDString.language == SystemLanguage.Korean ? "과부하 표시" : "Show Overload");
			if (toggleOverload)
			{
				setting.Overload = true;
				GUILayout.BeginHorizontal();
				GUILayout.Space(30);
				GUILayout.Label(RDString.language == SystemLanguage.Korean ? "과부하 텍스트 : " : "Overload Text : ");
				GUILayout.BeginHorizontal();
				String overload = setting.str_overload;
				String overloadtxt = GUILayout.TextField(overload, GUILayout.Width(300));
				if (overloadtxt != overload)
				{
					setting.str_overload = overloadtxt;
				}
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				GUILayout.EndHorizontal();
			}
			if (!toggleOverload)
			{
				setting.Overload = false;
				//Text.Content = " ";
			}

			bool toggleProgress = GUILayout.Toggle(setting.Progress, RDString.language == SystemLanguage.Korean ? "진행도 표시" : "Show Progress");
			if (toggleProgress)
			{
				setting.Progress = true;
				GUILayout.BeginHorizontal();
				GUILayout.Space(30);
				GUILayout.Label(RDString.language == SystemLanguage.Korean ? "진행도 텍스트 : " : "Progress Text : ");
				GUILayout.BeginHorizontal();
				String progress = setting.str_progress;
				String progresstxt = GUILayout.TextField(progress, GUILayout.Width(300));
				if (progresstxt != progress)
				{
					setting.str_progress = progresstxt;
				}
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				GUILayout.EndHorizontal();

				GUILayout.Space(-5);
				GUILayout.BeginHorizontal();
				GUILayout.Space(30);
				GUILayout.Label(RDString.language == SystemLanguage.Korean ? "진행도 소수점 자리수 : " : "Progress decimal places : ");
				String pernum = setting.per.ToString();
				try
				{
					GUILayout.BeginHorizontal();
					String text = GUILayout.TextField(pernum);
					GUILayout.FlexibleSpace();
					GUILayout.EndHorizontal();
					if (text != pernum)
					{
						double result = double.Parse(text);
						setting.per = result;
					}
				}
				catch (FormatException)
				{
					setting.per = 0;
				}
				GUILayout.EndHorizontal();
			}
			if (!toggleProgress)
            {
				setting.Progress = false;
				Text.Content2 = " ";
            }

			bool toggleAccuracy = GUILayout.Toggle(setting.Accuracy, RDString.language == SystemLanguage.Korean ? "정확도 표시" : "Show Accuracy");
			if (toggleAccuracy)
			{
				setting.Accuracy = true;
				//GUILayout.Space(-5);
				GUILayout.BeginHorizontal();
				GUILayout.Space(30);
				bool accround = GUILayout.Toggle(setting.accround, RDString.language == SystemLanguage.Korean ? "정확도 반올림" : "Round up accuracy");
				if (accround)
				{
					setting.accround = true;
				}
				if (!accround)
				{
					setting.accround = false;
				}
				GUILayout.EndHorizontal();

				//GUILayout.Space(-5);
				GUILayout.BeginHorizontal();
				GUILayout.Space(30);
				GUILayout.Label(RDString.language == SystemLanguage.Korean ? "정확도 텍스트 : " : "Accuracy Text : ");
				GUILayout.BeginHorizontal();
				String acc = setting.str_accuracy;
				String acctxt = GUILayout.TextField(acc, GUILayout.Width(300));
				if (acctxt != acc)
				{
					setting.str_accuracy = acctxt;
				}
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				GUILayout.EndHorizontal();

				GUILayout.Space(-5);
				GUILayout.BeginHorizontal();
				GUILayout.Space(30);
				GUILayout.Label(RDString.language == SystemLanguage.Korean ? "정확도 소숫점 자리수 : " : "Accuracy decimal places : ");
				String accnum = setting.acc.ToString();
				try
				{
					GUILayout.BeginHorizontal();
					String text = GUILayout.TextField(accnum);
					GUILayout.FlexibleSpace();
					GUILayout.EndHorizontal();
					if (text != accnum)
					{
						double result = double.Parse(text);
						setting.acc = result;
					}
				}
				catch (FormatException)
				{
					setting.acc = 0;
				}
				GUILayout.EndHorizontal();
			}
			if (!toggleAccuracy)
            {
				setting.Accuracy = false;
				Text.Content3 = " ";
            }

			bool toggleCombo = GUILayout.Toggle(setting.combo, RDString.language == SystemLanguage.Korean ? "콤보 표시" : "Show combo");
			if (toggleCombo)
			{
				setting.combo = true;
				GUILayout.BeginHorizontal();
				GUILayout.Space(30);
				GUILayout.Label(RDString.language == SystemLanguage.Korean ? "콤보 텍스트 : " : "Combo Text : ");
				GUILayout.BeginHorizontal();
				String combo = setting.str_combo;
				String combotxt = GUILayout.TextField(combo, GUILayout.Width(300));
				if (combotxt != combo)
				{
					setting.str_combo = combotxt;
				}
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				GUILayout.EndHorizontal();
			}
			if (!toggleCombo)
            {
				setting.combo = false;
				Text.Content4 = " ";
            }

			bool toggleScore = GUILayout.Toggle(setting.score, RDString.language == SystemLanguage.Korean ? "점수 표시" : "Show Score");
			if (toggleScore)
			{
				setting.score = true;
				GUILayout.BeginHorizontal();
				GUILayout.Space(30);
				GUILayout.Label(RDString.language == SystemLanguage.Korean ? "점수 텍스트 : " : "Score Text : ");
				GUILayout.BeginHorizontal();
				String score = setting.str_score;
				String scoretxt = GUILayout.TextField(score, GUILayout.Width(300));
				if (scoretxt != score)
				{
					setting.str_score = scoretxt;
				}
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				GUILayout.EndHorizontal();
			}
			if (!toggleScore)
            {
				setting.score = false;
				Text.Content5 = " ";
            }

			GUILayout.Label(" ");
			GUILayout.BeginHorizontal();
			GUILayout.Label(RDString.language == SystemLanguage.Korean ? "폰트 크기(기본값: 40) : " : "Font Size(Default: 40) : ");
			String font = setting.fontsize.ToString();
			try
			{
				GUILayout.BeginHorizontal();
				String text = GUILayout.TextField(font);
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				if (text != font)
				{
					int result = Int32.Parse(text);
					setting.fontsize = result;
				}
			} catch(FormatException)
            {
				setting.fontsize = 0;
            }
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Label(RDString.language == SystemLanguage.Korean ? "텍스트 간격(기본값: 40) : " : "Text Interval(Default: 40) : ");
			String textInterval = setting.interval.ToString();
            try
            {
				GUILayout.BeginHorizontal();
				String text = GUILayout.TextField(textInterval);
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				if (text != textInterval)
                {
					float result = float.Parse(text);
					setting.interval = result;
                }
            } catch(FormatException)
            {
				setting.interval = 0f;
            }
			GUILayout.EndHorizontal();

			bool toggleshadow = GUILayout.Toggle(setting.fontshadow, RDString.language == SystemLanguage.Korean ? "텍스트 그림자 표시" : "Show Text Shadow");
			if (toggleshadow)
            {
				setting.fontshadow = true;
            }
			if (!toggleshadow)
            {
				setting.fontshadow = false;
            }

			GUILayout.Label(" ");
			GUILayout.Label(RDString.language == SystemLanguage.Korean ? "좌표 설정" : "Coordinate Setting");
			GUILayout.BeginHorizontal();
			GUILayout.Label(RDString.language == SystemLanguage.Korean ? "X좌표 : " : "X coordinate : ");
			GUILayout.BeginHorizontal();
			float newx = GUILayout.HorizontalSlider(setting.x, 0, 1650, GUILayout.Width(300));
			GUILayout.Label(setting.x.ToString(), GUILayout.Width(300));
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Label(RDString.language == SystemLanguage.Korean ? "Y좌표 : " : "Y coordinate : ");
			GUILayout.BeginHorizontal();
			float newy = GUILayout.HorizontalSlider(setting.y, 0, 890, GUILayout.Width(300));
			GUILayout.Label(setting.y.ToString(), GUILayout.Width(300));
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.EndHorizontal();
			if (newx != setting.x)
            {
				setting.x = newx;
            }
			if (newy != setting.y)
            {
				setting.y = newy;
            }

			GUILayout.Label(" ");

        }

		private static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
			setting.Save(modEntry);
        }

		// Token: 0x06000004 RID: 4 RVA: 0x00002080 File Offset: 0x00000280
		private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
		{
			modEntry.OnGUI = OnGUI;
			modEntry.OnSaveGUI = OnSaveGUI;
			Main.IsEnabled = value;
			if (value)
			{
				Main.Start();
			}
			else
			{
				Main.Stop();
			}
			return true;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020B4 File Offset: 0x000002B4
		private static void Start()
		{
			Main._harmony = new Harmony(Main.Mod.Info.Id);
			Main._harmony.PatchAll(Assembly.GetExecutingAssembly());
			Main.text = new GameObject().AddComponent<Text>();
            UnityEngine.Object.DontDestroyOnLoad(Main.text);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002105 File Offset: 0x00000305
		private static void Stop()
		{
			Main._harmony.UnpatchAll(Main.Mod.Info.Id);
			Main._harmony = null;
			UnityEngine.Object.DestroyImmediate(Main.text);
			Main.text = null;
		}

		// Token: 0x04000002 RID: 2
		public static Text text;

		// Token: 0x04000003 RID: 3
		internal static UnityModManager.ModEntry Mod;

		// Token: 0x04000004 RID: 4
		private static Harmony _harmony;
	}
}
