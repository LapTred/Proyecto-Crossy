using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "Terrain Data", menuName = "Terrain Data")]

public class TerrainData : ScriptableObject
{
    public GameObject terrain;
    public int maxInSuccesion;
}
