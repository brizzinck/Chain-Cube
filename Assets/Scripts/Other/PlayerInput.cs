using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityAction Move;
    public UnityAction Fire;
    public UnityAction AddShow;
    private bool _isPlay;
    public void StartGame()
    {
        _isPlay = true;
    }
    private void Update()
    {
        if (_isPlay == false) return;
        if (Input.touchCount > 0)
        {
            Move?.Invoke();
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                Fire?.Invoke();
            }
        }
    }
}
