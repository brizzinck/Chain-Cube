using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] private Text _textScore;
    private MergerController _mergerController;
    private int _score;
    private void Start()
    {
        _mergerController = FindObjectOfType<MergerController>();
        _mergerController.Cast += Counting;
    }
    private void Counting(int value)
    {
        _score += value;
        _textScore.text = _score.ToString();
    }
    private void OnDisable()
    {
        _mergerController.Cast -= Counting;
    }
}
