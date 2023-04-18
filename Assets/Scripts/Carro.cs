using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    [SerializeField] private CarGenerator carGenerator;

    private void Start()
    {
        carGenerator = gameObject.transform.parent.GetComponent<CarGenerator>();
    }

    void Update()
    {
        if (carGenerator.orientacion == 0)
        {
            transform.Translate(carGenerator.velocidad * Time.deltaTime, 0, 0);
        }
        else if (carGenerator.orientacion==1) 
        {
            transform.Translate(carGenerator.velocidad * Time.deltaTime, 0, 0);
        }        
    }   
}
