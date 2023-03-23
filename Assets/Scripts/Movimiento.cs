using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private Mundo mundo;
    public int          carril;
    public int          lateral;
    public Vector3      posObjetivo;
    public float        velocidad;
    public Transform    grafico;
    public int          posicionZ;

    // Update is called once per frame
    void Update()
    {
        ActualizarPosicion();
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            Avanzar();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Retroceder();
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            MoverLados(1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MoverLados(-1);
            
        }
    }

    public void ActualizarPosicion()
    {
        //movimiento suave
        posObjetivo = new Vector3(lateral, 0, posicionZ);
        transform.position = Vector3.Lerp(transform.position,posObjetivo,velocidad*Time.deltaTime);        
    }

    public void Avanzar()
    {
        grafico.eulerAngles = Vector3.zero;
        posicionZ++;
        if(posicionZ > carril)
        {
            carril = posicionZ;
            //mundo.CrearPiso();
            mundo.SpawnTerrain(false, transform.position);
        }
    }

    public void Retroceder()
    {
        grafico.eulerAngles = new Vector3(0, 180, 0);
        if(posicionZ>carril-3)
        { 
            posicionZ--;
        }
    }
    public void MoverLados(int cuanto)
    {
        grafico.eulerAngles = new Vector3(0, 90*cuanto, 0);

        lateral += cuanto;
        lateral = Mathf.Clamp(lateral, -4, 4);        
    }
}
