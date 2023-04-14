using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mundo : MonoBehaviour
{
    public int limiteDeMundo = 0;

    [SerializeField] private int minDistanceFromPlayer;
    
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();

    [SerializeField] private List<GameObject> grassList = new List<GameObject>();

    [SerializeField] private Transform terrainHolder;

    private List<GameObject> currentTerrains = new List<GameObject>();

    private bool lastIPar = false;

    private void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(true, new Vector3(0, 0, 0));
        }
        maxTerrainCount = currentTerrains.Count;
    }

    public void SpawnTerrain(bool isStart, Vector3 playerPos)
    {
        if ((limiteDeMundo - playerPos.z < minDistanceFromPlayer)|| (isStart))
        {
            int whichTerrain = Random.Range(0, 3);//terrainDatas.Count
            int terrainInSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccesion);
            int randomGrass;

            for (int i = 0; i < terrainInSuccession; i++)
            {
                if (whichTerrain == 2)//grass
                {
                    if(lastIPar == false )
                    {
                        randomGrass = Random.Range(5, 10);
                        lastIPar= true;
                    }
                    else
                    {
                        randomGrass = Random.Range(0, 5);
                        lastIPar= false;
                    }

                    GameObject terrain = Instantiate(grassList[randomGrass], Vector3.forward * limiteDeMundo, Quaternion.identity, terrainHolder);
                    currentTerrains.Add(terrain);
                    limiteDeMundo++;
                }
                else if (whichTerrain == 1) 
                {
                    GameObject terrain = Instantiate(terrainDatas[whichTerrain].terrain, Vector3.forward * limiteDeMundo, Quaternion.Euler(0, 90, 0), terrainHolder);
                    currentTerrains.Add(terrain);
                    limiteDeMundo++;
                }                
                else if (whichTerrain == 0)
                {
                    if (i == 0)
                    {
                        if (lastIPar == false)
                        {
                            randomGrass = Random.Range(5, 10);
                            lastIPar = true;
                        }
                        else
                        {
                            randomGrass = Random.Range(0, 5);
                            lastIPar = false;
                        }

                        GameObject terrain = Instantiate(grassList[randomGrass], Vector3.forward * limiteDeMundo, Quaternion.identity, terrainHolder);
                        currentTerrains.Add(terrain);
                        limiteDeMundo++;
                    }                    
                    if (i<terrainInSuccession)
                    {
                        GameObject terrain = Instantiate(terrainDatas[whichTerrain].terrain, Vector3.forward * limiteDeMundo, Quaternion.identity, terrainHolder);
                        currentTerrains.Add(terrain);
                        limiteDeMundo++;
                    }
                    if (i == terrainInSuccession -1)
                    {
                        if (lastIPar == false)
                        {
                            randomGrass = Random.Range(5, 10);
                            lastIPar = true;
                        }
                        else
                        {
                            randomGrass = Random.Range(0, 5);
                            lastIPar = false;
                        }

                        GameObject terrain = Instantiate(grassList[randomGrass], Vector3.forward * limiteDeMundo, Quaternion.identity, terrainHolder);
                        currentTerrains.Add(terrain);
                        limiteDeMundo++;
                    }
                }                

                if (!isStart)
                {
                    if (currentTerrains.Count > maxTerrainCount)
                    {
                        Destroy(currentTerrains[0]);
                        currentTerrains.RemoveAt(0);
                    }
                }

                //limiteDeMundo++;
            }
        }
    }
    
}
