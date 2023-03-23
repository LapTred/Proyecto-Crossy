using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mundo : MonoBehaviour
{
    public int limiteDeMundo = 0;
    /*public GameObject[] pisos;
    public int pisosDiferencia;*/

    [SerializeField] private int minDistanceFromPlayer;

    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();

    [SerializeField] private Transform terrainHolder;

    private List<GameObject> currentTerrains = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(true, new Vector3(0, 0, 0));
        }
        maxTerrainCount = currentTerrains.Count;
        /*for(int i = 0; i<pisosDiferencia; i++) 
        {
            CrearPiso();
        }*/
    }

    /*public void CrearPiso()
    {
        Instantiate(pisos[Random.Range(0,pisos.Length)],Vector3.forward*carril, Quaternion.identity);
        carril++;
    }*/

    public void SpawnTerrain(bool isStart, Vector3 playerPos)
    {
        if ((limiteDeMundo - playerPos.z < minDistanceFromPlayer)|| (isStart))
        {
            int whichTerrain = Random.Range(0, terrainDatas.Count);
            int terrainInSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccesion);

            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain = Instantiate(terrainDatas[whichTerrain].terrain, Vector3.forward * limiteDeMundo, Quaternion.identity, terrainHolder);
                currentTerrains.Add(terrain);

                if (!isStart)
                {
                    if (currentTerrains.Count > maxTerrainCount)
                    {
                        Destroy(currentTerrains[0]);
                        currentTerrains.RemoveAt(0);
                    }
                }

                limiteDeMundo++;
            }
        }
    }
    
}
