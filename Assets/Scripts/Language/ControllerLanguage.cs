using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerLanguage : MonoBehaviour
{
    [SerializeField] private Text _textLanguage;
    private string RU;
    private string EN;

    public void SetLanguage(JsonLanguage jsonLanguage)
    {
        Language language = jsonLanguage.LoadFile();
        RU = language.RU;
        EN = language.EN;
    }

    public void ChangeLanguage(string language = "EN")
    {
        if (language == "EN") _textLanguage.text = EN;
        else _textLanguage.text = RU;
    }
}
