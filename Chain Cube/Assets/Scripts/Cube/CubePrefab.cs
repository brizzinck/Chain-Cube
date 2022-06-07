using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCube", menuName = "Cube", order = 51)]
public class CubePrefab : ScriptableObject
{
    public int Value;
    public Material Material;
}
