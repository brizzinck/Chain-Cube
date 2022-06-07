using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Merger))]
public class Cube : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] valueText;
    private int _value;
    private Material material;
    public int Value { get => _value; set => _value = value; }
    public Material Material { get => material; set => material = value; }

    private void Start()
    {
        foreach (TextMeshProUGUI text in valueText)
        {
            text.text = _value.ToString();
        }
    }
}
