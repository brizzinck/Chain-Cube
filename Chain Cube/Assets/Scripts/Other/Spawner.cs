using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public UnityAction<Merger> Spawn;
    [SerializeField] private MergerController _mergerController;
    [SerializeField] private Cube _cube;
    [SerializeField] private CubeMover _cubeMover;
    [SerializeField] private List<CubePrefab> _allCubes = new List<CubePrefab>();
    private List<CubePrefab> _currCubes = new List<CubePrefab>();
    private void Awake()
    {
        _cubeMover.Spawn += Spawning;
        _mergerController.Spawn += SetValueCube;
        _currCubes.Add(_allCubes[0]);
    }
    private void Spawning(Vector3 vector3)
    {
        Cube cube = Instantiate(_cube, vector3, Quaternion.identity);
        _cubeMover.Cube = cube;
        SetValueCube(cube, true, Random.RandomRange(0, _currCubes.Count));
        Spawn?.Invoke(cube.GetComponent<Merger>());
    }
    private void SetValueCube(Cube cube, bool random, int value)
    {
        if (random == false)
        {
            for (int i = 0; i < _currCubes.Count; i++)
            {
                if (value == _currCubes[i].Value)
                {
                    if (value == _currCubes[_currCubes.Count - 1].Value) _currCubes.Add(_allCubes[i + 1]);
                    value = i + 1;
                    break;
                }
            }
        }
        cube.Value = _currCubes[value].Value;
        cube.Material = _currCubes[value].Material;
        cube.gameObject.GetComponent<Renderer>().material = cube.Material;
    }
    private void OnDisable()
    {
        _cubeMover.Spawn -= Spawning;
        _mergerController.Spawn -= SetValueCube;
    }
}
