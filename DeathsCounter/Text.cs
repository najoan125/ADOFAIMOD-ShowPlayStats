using System;
using UnityEngine;

namespace ShowPlayStats
{
	// Token: 0x02000004 RID: 4
	public class Text : MonoBehaviour
	{
		private void Start()
        {
			bool fontShadow = Main.setting.fontshadow;
			if (fontShadow)
            {
				this.ShadowTextStyle.font = RDString.GetFontDataForLanguage(RDString.language).font;
				this.ShadowTextStyle.fontSize = Main.setting.fontsize;
				this.ShadowTextStyle.fontStyle = FontStyle.Normal;
				this.ShadowTextStyle.normal.textColor = new Color(0f, 0f, 0f, 0.45f);
			}
        }

		private void OnGUI()
		{
			bool fontshadow = Main.setting.fontshadow;
			GUIStyle style = GUI.skin.GetStyle("DeathsCounter_text");
			style.fontSize = Main.setting.fontsize;
			this.ShadowTextStyle.fontSize = Main.setting.fontsize;
			style.font = RDString.GetFontDataForLanguage(RDString.language).font;

			/*
			style.normal.textColor = Color.black;
			style.fontStyle = FontStyle.Bold;
			GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content, "TileCounter_text");*/
			this.ShadowTextLocation = new Rect((float)(Main.setting.x + 2 + 10f), (float)(Main.setting.y - 10f + 2), (float)Main.setting.x, (float)Main.setting.y - 10f);
			style.normal.textColor = Color.white;
			style.fontStyle = FontStyle.Normal;
			if (fontshadow)
			{
				GUI.Label(this.ShadowTextLocation, Text.Content, this.ShadowTextStyle);
			}
			GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content, "TileCounter_text");

			if (Main.setting.DeathCount)
			{/*
				style.normal.textColor = Color.black;
				style.fontStyle = FontStyle.Bold;
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content2, "TileCounter_text2");*/
				style.normal.textColor = Color.white;
				style.fontStyle = FontStyle.Normal;
				this.ShadowTextLocation = new Rect((float)(Main.setting.x + 2 + 10f), (float)(Main.setting.y - 10f + 2 + Main.setting.interval), (float)Main.setting.x, (float)Main.setting.y - 10f + Main.setting.interval);
				if (fontshadow)
				{
					GUI.Label(this.ShadowTextLocation, Text.Content2, this.ShadowTextStyle);
				}
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content2, "TileCounter_text2");
			}
			if (!Main.setting.DeathCount)
            {/*
				style.normal.textColor = Color.black;
				style.fontStyle = FontStyle.Bold;
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content2, "TileCounter_text2");*/
				style.normal.textColor = Color.white;
				style.fontStyle = FontStyle.Normal;
				this.ShadowTextLocation = new Rect((float)(Main.setting.x + 2 + 10f), (float)(Main.setting.y - 10f + 2), (float)Main.setting.x, (float)Main.setting.y - 10f);
				if (fontshadow)
				{
					GUI.Label(this.ShadowTextLocation, Text.Content2, this.ShadowTextStyle);
				}
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content2, "TileCounter_text2");
			}

			if (Main.setting.Progress && Main.setting.DeathCount)
			{/*
				style.normal.textColor = Color.black;
				style.fontStyle = FontStyle.Bold;
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval * 2 + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content3, "TileCounter_text3");*/
				style.normal.textColor = Color.white;
				style.fontStyle = FontStyle.Normal;
				this.ShadowTextLocation = new Rect((float)(Main.setting.x + 2 + 10f), (float)(Main.setting.y - 10f + 2 + Main.setting.interval * 2), (float)Main.setting.x, (float)Main.setting.y - 10f + Main.setting.interval * 2);
				if (fontshadow)
				{
					GUI.Label(this.ShadowTextLocation, Text.Content3, this.ShadowTextStyle);
				}
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval * 2 + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content3, "TileCounter_text3");
			}
			if (Main.setting.Progress && !Main.setting.DeathCount || !Main.setting.Progress && Main.setting.DeathCount)
            {/*
				style.normal.textColor = Color.black;
				style.fontStyle = FontStyle.Bold;
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content3, "TileCounter_text3");*/
				style.normal.textColor = Color.white;
				style.fontStyle = FontStyle.Normal;
				this.ShadowTextLocation = new Rect((float)(Main.setting.x + 2 + 10f), (float)(Main.setting.y - 10f + 2 + Main.setting.interval), (float)Main.setting.x, (float)Main.setting.y - 10f + Main.setting.interval);
				if (fontshadow)
				{
					GUI.Label(this.ShadowTextLocation, Text.Content3, this.ShadowTextStyle);
				}
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content3, "TileCounter_text3");
			}
			if (!Main.setting.Progress && !Main.setting.DeathCount)
            {/*
				style.normal.textColor = Color.black;
				style.fontStyle = FontStyle.Bold;
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content3, "TileCounter_text3");*/
				style.normal.textColor = Color.white;
				style.fontStyle = FontStyle.Normal;
				this.ShadowTextLocation = new Rect((float)(Main.setting.x + 2 + 10f), (float)(Main.setting.y - 10f + 2), (float)Main.setting.x, (float)Main.setting.y - 10f);
				if (fontshadow)
				{
					GUI.Label(this.ShadowTextLocation, Text.Content3, this.ShadowTextStyle);
				}
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content3, "TileCounter_text3");
			}

			if (Main.setting.DeathCount && Main.setting.Progress && Main.setting.Accuracy)
			{/*
				style.normal.textColor = Color.black;
				style.fontStyle = FontStyle.Bold;
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval * 3 + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content4, "TileCounter_text4");*/
				style.normal.textColor = Color.white;
				style.fontStyle = FontStyle.Normal;
				this.ShadowTextLocation = new Rect((float)(Main.setting.x + 2 + 10f), (float)(Main.setting.y - 10f + 2 + Main.setting.interval * 3), (float)Main.setting.x, (float)Main.setting.y - 10f + Main.setting.interval * 3);
				if (fontshadow)
				{
					GUI.Label(this.ShadowTextLocation, Text.Content4, this.ShadowTextStyle);
				}
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval * 3 + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content4, "TileCounter_text4");
			}
			if (!Main.setting.DeathCount && Main.setting.Progress && Main.setting.Accuracy ||
				Main.setting.DeathCount && !Main.setting.Progress && Main.setting.Accuracy ||
				Main.setting.DeathCount && Main.setting.Progress && !Main.setting.Accuracy)
            {/*
				style.normal.textColor = Color.black;
				style.fontStyle = FontStyle.Bold;
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval * 2 + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content4, "TileCounter_text4");*/
				style.normal.textColor = Color.white;
				style.fontStyle = FontStyle.Normal;
				this.ShadowTextLocation = new Rect((float)(Main.setting.x + 2 + 10f), (float)(Main.setting.y - 10f + 2 + Main.setting.interval * 2), (float)Main.setting.x, (float)Main.setting.y - 10f + Main.setting.interval * 2);
				if (fontshadow)
				{
					GUI.Label(this.ShadowTextLocation, Text.Content4, this.ShadowTextStyle);
				}
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval * 2 + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content4, "TileCounter_text4");
			}
			if (!Main.setting.DeathCount && !Main.setting.Progress && Main.setting.Accuracy ||
				Main.setting.DeathCount && !Main.setting.Progress && !Main.setting.Accuracy ||
				!Main.setting.DeathCount && Main.setting.Progress && !Main.setting.Accuracy)
            {/*
				style.normal.textColor = Color.black;
				style.fontStyle = FontStyle.Bold;
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content4, "TileCounter_text4");*/
				style.normal.textColor = Color.white;
				style.fontStyle = FontStyle.Normal;
				this.ShadowTextLocation = new Rect((float)(Main.setting.x + 2 + 10f), (float)(Main.setting.y - 10f + 2 + Main.setting.interval), (float)Main.setting.x, (float)Main.setting.y - 10f + Main.setting.interval);
				if (fontshadow)
				{
					GUI.Label(this.ShadowTextLocation, Text.Content4, this.ShadowTextStyle);
				}
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content4, "TileCounter_text4");
			}
			if (!Main.setting.DeathCount && !Main.setting.Progress && !Main.setting.Accuracy)
            {/*
				style.normal.textColor = Color.black;
				style.fontStyle = FontStyle.Bold;
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content4, "TileCounter_text4");*/
				style.normal.textColor = Color.white;
				style.fontStyle = FontStyle.Normal;
				this.ShadowTextLocation = new Rect((float)(Main.setting.x + 2 + 10f), (float)(Main.setting.y - 10f + 2), (float)Main.setting.x, (float)Main.setting.y - 10f);
				if (fontshadow)
				{
					GUI.Label(this.ShadowTextLocation, Text.Content4, this.ShadowTextStyle);
				}
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content4, "TileCounter_text4");
			}

			if (Main.setting.DeathCount && Main.setting.Progress && Main.setting.Accuracy && Main.setting.combo)
			{/*
				style.normal.textColor = Color.black;
				style.fontStyle = FontStyle.Bold;
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval * 4 + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content5, "TileCounter_text5");*/
				style.normal.textColor = Color.white;
				style.fontStyle = FontStyle.Normal;
				this.ShadowTextLocation = new Rect((float)(Main.setting.x + 2 + 10f), (float)(Main.setting.y - 10f + 2 + Main.setting.interval * 4), (float)Main.setting.x, (float)Main.setting.y - 10f + Main.setting.interval * 4);
				if (fontshadow)
				{
					GUI.Label(this.ShadowTextLocation, Text.Content5, this.ShadowTextStyle);
				}
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval * 4 + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content5, "TileCounter_text5");
			}
			if (!Main.setting.DeathCount && Main.setting.Progress && Main.setting.Accuracy && Main.setting.combo ||
				Main.setting.DeathCount && !Main.setting.Progress && Main.setting.Accuracy && Main.setting.combo ||
				Main.setting.DeathCount && Main.setting.Progress && !Main.setting.Accuracy && Main.setting.combo ||
				Main.setting.DeathCount && Main.setting.Progress && Main.setting.Accuracy && !Main.setting.combo)
            {/*
				style.normal.textColor = Color.black;
				style.fontStyle = FontStyle.Bold;
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval * 3 + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content5, "TileCounter_text5");*/
				style.normal.textColor = Color.white;
				style.fontStyle = FontStyle.Normal;
				this.ShadowTextLocation = new Rect((float)(Main.setting.x + 2 + 10f), (float)(Main.setting.y - 10f + 2 + Main.setting.interval * 3), (float)Main.setting.x, (float)Main.setting.y - 10f + Main.setting.interval * 3);
				if (fontshadow)
				{
					GUI.Label(this.ShadowTextLocation, Text.Content5, this.ShadowTextStyle);
				}
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval * 3 + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content5, "TileCounter_text5");
			}
			if (!Main.setting.DeathCount && !Main.setting.Progress && Main.setting.Accuracy && Main.setting.combo ||
				!Main.setting.DeathCount && Main.setting.Progress && !Main.setting.Accuracy && Main.setting.combo ||
				!Main.setting.DeathCount && Main.setting.Progress && Main.setting.Accuracy && !Main.setting.combo ||
				Main.setting.DeathCount && !Main.setting.Progress && !Main.setting.Accuracy && Main.setting.combo ||
				Main.setting.DeathCount && !Main.setting.Progress && Main.setting.Accuracy && !Main.setting.combo ||
				Main.setting.DeathCount && Main.setting.Progress && !Main.setting.Accuracy && !Main.setting.combo)
            {/*
				style.normal.textColor = Color.black;
				style.fontStyle = FontStyle.Bold;
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval * 2 + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content5, "TileCounter_text5");*/
				style.normal.textColor = Color.white;
				style.fontStyle = FontStyle.Normal;
				this.ShadowTextLocation = new Rect((float)(Main.setting.x + 2 + 10f), (float)(Main.setting.y - 10f + 2 + Main.setting.interval * 2), (float)Main.setting.x, (float)Main.setting.y - 10f + Main.setting.interval * 2);
				if (fontshadow)
				{
					GUI.Label(this.ShadowTextLocation, Text.Content5, this.ShadowTextStyle);
				}
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval * 2 + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content5, "TileCounter_text5");
			}
			if (!Main.setting.DeathCount && !Main.setting.Progress && !Main.setting.Accuracy && Main.setting.combo ||
				!Main.setting.DeathCount && Main.setting.Progress && !Main.setting.Accuracy && !Main.setting.combo ||
				!Main.setting.DeathCount && !Main.setting.Progress && Main.setting.Accuracy && !Main.setting.combo ||
				Main.setting.DeathCount && !Main.setting.Progress && !Main.setting.Accuracy && !Main.setting.combo)
            {/*
				style.normal.textColor = Color.black;
				style.fontStyle = FontStyle.Bold;
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content5, "TileCounter_text5");*/
				style.normal.textColor = Color.white;
				style.fontStyle = FontStyle.Normal;
				this.ShadowTextLocation = new Rect((float)(Main.setting.x + 2 + 10f), (float)(Main.setting.y - 10f + 2 + Main.setting.interval), (float)Main.setting.x, (float)Main.setting.y - 10f + Main.setting.interval);
				if (fontshadow)
				{
					GUI.Label(this.ShadowTextLocation, Text.Content5, this.ShadowTextStyle);
				}
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.interval + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content5, "TileCounter_text5");
			}
			if (!Main.setting.DeathCount && !Main.setting.Progress && !Main.setting.Accuracy && !Main.setting.combo)
            {/*
				style.normal.textColor = Color.black;
				style.fontStyle = FontStyle.Bold;
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content5, "TileCounter_text5");*/
				style.normal.textColor = Color.white;
				style.fontStyle = FontStyle.Normal;
				this.ShadowTextLocation = new Rect((float)(Main.setting.x + 2 + 10f), (float)(Main.setting.y - 10f + 2), (float)Main.setting.x, (float)Main.setting.y - 10f);
				if (fontshadow)
				{
					GUI.Label(this.ShadowTextLocation, Text.Content5, this.ShadowTextStyle);
				}
				GUI.Label(new Rect(10f + Main.setting.x, -10f + Main.setting.y, (float)Screen.width, (float)Screen.height), Text.Content5, "TileCounter_text5");
			}
		}

		// Token: 0x04000006 RID: 6
		public static string Content = " ";
		public static string Content2 = " ";
		public static string Content3 = " ";
		public static string Content4 = " ";
		public static string Content5 = " ";

		private Rect ShadowTextLocation;
		private GUIStyle ShadowTextStyle = new GUIStyle();
	}
}
