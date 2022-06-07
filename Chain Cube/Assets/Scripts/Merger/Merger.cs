using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Cube))]
public class Merger : MonoBehaviour
{
    public bool IsCollison;
    [SerializeField] private Cube _cube;
    private int _maxValue = 2048;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube cube))
        {
            if (cube.Value == _maxValue) return;
            if (cube.Value == GetComponent<Cube>().Value)
            {
                IsCollison = true;
            }
        }
    }
}
