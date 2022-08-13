using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeMover : MonoBehaviour
{
    public UnityAction<Vector3> Spawn;
    public Cube Cube;
    [SerializeField] private InterAd _interAd;
    private int _fireCost;
    private PlayerInput _playerInput;
    private bool _isMove;
    private void Start()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        _playerInput.Move += Move;
        _playerInput.Fire += Fire;
        Spawn?.Invoke(new Vector3(0, 0.25f, -3));
    }
    private void Move()
    {
        if (_isMove == true) return;
        Vector2 delta = Input.GetTouch(0).deltaPosition;

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            Vector3 position = Cube.transform.position;
            position.x += 0.2f * delta.x * Time.deltaTime;
            Cube.transform.position = new Vector3(Mathf.Clamp(position.x, -1, 1), position.y, Cube.transform.position.z);
        }
    }
    private void Fire()
    {
        if (_isMove == true) return;
        Vector3 positionCube = Cube.transform.position;
        Cube.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 20);
        StartCoroutine(SpawnDelay(positionCube));
        _isMove = true;
        AdControll();
    }
    IEnumerator SpawnDelay(Vector3 vector3)
    {
        yield return new WaitForSeconds(0.5f);
        Spawn?.Invoke(vector3);
        _isMove = false;
    }
    private void AdControll()
    {
        _fireCost++;
        if (_fireCost >= Random.RandomRange(10, 20))
        {
            _interAd.ShowAd();
            _fireCost = 0;
        }
    }
    private void OnDisable()
    {
        _playerInput.Move -= Move;
        _playerInput.Fire -= Fire;
    }
}
