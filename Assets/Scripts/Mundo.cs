using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mundo : MonoBehaviour
{
    public int worldLimit = 0;

    //Distancia de generado
    [SerializeField] private int minDistanceFromPlayer;
    
    //Cantidad Máxima del mundo
    [SerializeField] private int maxTerrainCount;

    //Terreno
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();

    //Distintos modelos de pasto
    [SerializeField] private List<GameObject> grassList = new List<GameObject>();
    private bool lastIPar = false;

    //Almacenador de terrenos
    [SerializeField] private Transform terrainHolder;


        
    private List<GameObject> currentTerrains = new List<GameObject>();

   

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
        if ((worldLimit - playerPos.z < minDistanceFromPlayer)|| (isStart))
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

                    GameObject terrain = Instantiate(grassList[randomGrass], Vector3.forward * worldLimit, Quaternion.identity, terrainHolder);
                    currentTerrains.Add(terrain);
                    worldLimit++;
                }
                else if (whichTerrain == 1)//road 
                {
                    GameObject terrain = Instantiate(terrainDatas[whichTerrain].terrain, Vector3.forward * worldLimit, Quaternion.Euler(0, 90, 0), terrainHolder);
                    currentTerrains.Add(terrain);
                    worldLimit++;
                }                
                else if (whichTerrain == 0)//water
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

                        GameObject terrain = Instantiate(grassList[randomGrass], Vector3.forward * worldLimit, Quaternion.identity, terrainHolder);
                        currentTerrains.Add(terrain);
                        worldLimit++;
                    }                    
                    if (i<terrainInSuccession)
                    {
                        GameObject terrain = Instantiate(terrainDatas[whichTerrain].terrain, Vector3.forward * worldLimit, Quaternion.identity, terrainHolder);
                        currentTerrains.Add(terrain);
                        worldLimit++;
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

                        GameObject terrain = Instantiate(grassList[randomGrass], Vector3.forward * worldLimit, Quaternion.identity, terrainHolder);
                        currentTerrains.Add(terrain);
                        worldLimit++;
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
