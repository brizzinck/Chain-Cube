using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MergerController : MonoBehaviour
{
    public UnityAction<Cube, bool, int> Spawn;
    public UnityAction<int> Cast;
    public List<Merger> _mergers = new List<Merger>();
    [SerializeField] private Cube cube;
    private int valueCube;
    private Spawner _spawner;
    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
        _spawner.Spawn += AddMergers; 
    }
    private void AddMergers(Merger merger)
    {
        _mergers.Add(merger);
    }
    private void Update()
    {  
        int collisionMarger = 0;
        int numberMerges = 0;
        Vector3 vector = Vector3.zero;

        for (int i = 0; i < _mergers.Count; i++)
        {
            if (numberMerges >= 2)
            {
                _mergers[i].IsCollison = false;
            }
            else if (_mergers[i].IsCollison)
            {
                if (vector.z < _mergers[i].transform.position.z)
                    vector = _mergers[i].transform.position;
                valueCube = _mergers[i].GetComponent<Cube>().Value;
                Destroy(_mergers[i].gameObject);
                _mergers.RemoveAt(i);
                collisionMarger++;
                numberMerges++;
                i--;
            }
        }
        if (collisionMarger > 0)
        {
            Cube newCube = Instantiate(cube, vector, Quaternion.identity);
            Spawn?.Invoke(newCube, false, valueCube);
            newCube.GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
            newCube.GetComponent<Rigidbody>().AddTorque(
                new Vector3(Random.RandomRange(-2, 2), Random.RandomRange(-2, 2), Random.RandomRange(-2, 2)), 
                ForceMode.Impulse);
            _mergers.Add(newCube.GetComponent<Merger>());
            Cast?.Invoke(valueCube * 2);
        }

    }
    private void OnDisable()
    {
        _spawner.Spawn -= AddMergers;

    }
}
