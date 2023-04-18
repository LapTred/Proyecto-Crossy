using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    //Modelos de carro
    [SerializeField] private List<GameObject> carsList = new List<GameObject>();

    //Almacenar carros
    [SerializeField] private Transform carsHolder;

    public int orientacion;
    public float velocidad;

    // Start is called before the first frame update
    void Start()
    {        
        orientacion = Random.Range(0, 2);
        velocidad = Random.Range(4f, 9f);
            
        Invoke("GeneradorCarro", Random.Range(0f,2f));
    }

    public void GeneradorCarro()
    {
        if (orientacion == 0)
        {
            int carroType = Random.Range(0, 101);

            if (carroType <= 80)
            {
                int carModel = Random.Range(0, 3);
                GameObject cars = Instantiate(carsList[carModel], transform.position + new Vector3(-9, 0, 0), Quaternion.identity);

                cars.transform.parent = carsHolder;
            }
            else if (carroType <= 90)
            {
                GameObject cars = Instantiate(carsList[3], transform.position + new Vector3(-9, 0, 0), Quaternion.identity);
                cars.transform.parent = carsHolder;
            }
            else if (carroType <= 100)
            {
                int carModel = Random.Range(4, 6);
                GameObject cars = Instantiate(carsList[carModel], transform.position + new Vector3(-9, 0, 0), Quaternion.identity);
                cars.transform.parent = carsHolder;
            }
        }
        else if (orientacion == 1)
        {
            int carroType = Random.Range(0, 101);

            if (carroType <= 80)
            {
                int carModel = Random.Range(0, 3);
                GameObject cars = Instantiate(carsList[carModel], transform.position + new Vector3(9, 0, 0), Quaternion.Euler(0,180,0));

                cars.transform.parent = carsHolder;
            }
            else if (carroType <= 90)
            {
                GameObject cars = Instantiate(carsList[3], transform.position + new Vector3(9, 0, 0), Quaternion.Euler(0, 180, 0));
                cars.transform.parent = carsHolder;
            }
            else if (carroType <= 100)
            {
                int carModel = Random.Range(4, 6);
                GameObject cars = Instantiate(carsList[carModel], transform.position + new Vector3(9, 0, 0), Quaternion.Euler(0, 180, 0));
                cars.transform.parent = carsHolder;
            }
        }
        Invoke("GeneradorCarro", Random.Range(1.2f, 3f));
    }
}
