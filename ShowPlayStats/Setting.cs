using System.IO;
using System.Xml.Serialization;
using UnityModManagerNet;

public class Setting : UnityModManager.ModSettings
{
    public float x = 0;
    public float y = 0;
    public bool DeathCount = true;
    public bool Overload = true;
    public bool Progress = true;
    public bool Accuracy = true;
    public bool combo = true;
    public bool score = true;
    public int fontsize = 40;
    public float interval = 40f;

    public string str_progress = "진행도", str_accuracy = "정확도", str_combo = "Combo", str_deathcount = "죽은 횟수", str_overload = "과부하", str_score = "Score";
    public bool accround = true;
    public double acc = 2;
    public double per = 2;
    public bool fontshadow = true;
    public bool exceptOverload = false;

    public override void Save(UnityModManager.ModEntry modEntry)
    {
        var filepath = GetPath(modEntry);
        try
        {
            using (var writer = new StreamWriter(filepath))
            {
                var serializer = new XmlSerializer(GetType());
                serializer.Serialize(writer, this);
            }
        }
        catch
        {
        }
    }

    public override string GetPath(UnityModManager.ModEntry modEntry)
    {
        return Path.Combine(modEntry.Path, GetType().Name + ".xml");
    }

}