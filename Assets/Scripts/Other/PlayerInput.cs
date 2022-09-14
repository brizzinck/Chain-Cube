using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityAction<float> Move;
    public UnityAction Fire;
    public UnityAction AddShow;
    private bool _isPlay = false;
    public void Play()
    {
        _isPlay = true;
    }
    private void Update()
    {
        if (_isPlay == false) return;
        if (Application.isEditor)
        {
            Move?.Invoke(Input.GetAxis("Horizontal") * 4);
            if (Input.GetMouseButtonUp(0))
            {
                Fire?.Invoke();
            }
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                Move?.Invoke(Input.GetTouch(0).deltaPosition.x / 4);
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended)
                {
                    Fire?.Invoke();
                }
            }
        }
    }
}
