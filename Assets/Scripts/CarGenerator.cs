using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    //Modelos de carro
    [SerializeField] private List<GameObject> carsList = new List<GameObject>();

    //Almacenar carros
    [SerializeField] private Transform carsHolder;


    // Start is called before the first frame update
    void Start()
    {
        GeneradorCarro();
        
        //InvokeRepeating("GeneradorCarro", 0, Random.Range(2, 5));

    }

    public void GeneradorCarro()
    {
        int carroType = Random.Range(0, 101);

        if (carroType <= 80)
        {
            int carModel = Random.Range(0, 3);
            GameObject cars = Instantiate(carsList[carModel], transform.position + new Vector3 (-5,0,0), Quaternion.identity);

            cars.transform.parent = carsHolder;
        }
        else if (carroType <= 90)
        {
            GameObject cars = Instantiate(carsList[3], transform.position + new Vector3(-5, 0, 0), Quaternion.identity);
            cars.transform.parent = carsHolder;
        }
        else if (carroType <= 100)
        {
            int carModel = Random.Range(4, 6);
            GameObject cars = Instantiate(carsList[carModel], transform.position + new Vector3(-5, 0, 0), Quaternion.identity);
            cars.transform.parent = carsHolder;
        }
    }
}
