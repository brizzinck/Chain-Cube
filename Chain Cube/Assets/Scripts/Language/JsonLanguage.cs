using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonLanguage : MonoBehaviour
{
    private string _savePath;
    private string _saveFileName = "Language";

    public Language LoadFile()
    {
        if (File.Exists(_savePath))
        {
            string json = File.ReadAllText(_savePath);
            Language language = JsonUtility.FromJson<Language>(json);
            return language;
        }
        return new Language();
    }

    private void Awake()
    {
        _savePath = Path.Combine(Application.persistentDataPath, _saveFileName);
        SaveFile();
        LoadFile();
    }
    private void SaveFile()
    {
        Language language = new Language
        {
            RU = "Старт",
            EN = "Play"
        };
        string json = JsonUtility.ToJson(language, true);
        try
        {
            File.WriteAllText(_savePath, json);
        }
        catch
        {
            Debug.Log("Json Error");
        }
    }
}
