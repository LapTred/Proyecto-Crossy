using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Movimiento movimiento;
    public float velocidad;
    private Vector3 vector;
    void Update()
    {
        if (movimiento.lateral >= 2)
        {
            vector = new Vector3(1, 0, movimiento.carril);
            transform.position = Vector3.Lerp(transform.position, vector, velocidad * Time.deltaTime);
        }
        if(movimiento.lateral <= -2)
        {
            vector = new Vector3(-1, 0, movimiento.carril);
            transform.position = Vector3.Lerp(transform.position, vector, velocidad * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, Vector3.forward * movimiento.carril, velocidad * Time.deltaTime);
        }
        //transform.position = Vector3.Lerp(transform.position, Vector3.forward * movimiento.carril, velocidad * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, vector, velocidad * Time.deltaTime);
    }
}
