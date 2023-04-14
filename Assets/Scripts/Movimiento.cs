using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private bool isMoving = false;

    //Variables
    [SerializeField] private Mundo mundo;
    public int          carril;
    public int          lateral;
    public Vector3      posObjetivo;
    public float        velocidad;
    public Transform    grafico;
    public LayerMask    capaObstaculos;
    public float        distanciaVista = 1;

    public float tiempo;

    int posicionZ = 1;

    private void Start()
    {
        InvokeRepeating("moving", 0f, tiempo);
    }

    private void moving()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarPosicion();

        if (Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            Avanzar();
            isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            Retroceder();
            isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            MoverLados(1);
            isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            MoverLados(-1);
            isMoving = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(grafico.position + Vector3.up * 0.5f, grafico.position + Vector3.up * 0.5f + grafico.forward * distanciaVista);        
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
        if(MirarAdelante())
        {
            return;
        }

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
        if (MirarAdelante())
        {
            return;
        }
        if (posicionZ>carril-3)
        { 
            posicionZ--;
        }
    }
    public void MoverLados(int cuanto)
    {
        grafico.eulerAngles = new Vector3(0, 90*cuanto, 0);
        if (MirarAdelante())
        {
            return;
        }

        lateral += cuanto;
        lateral = Mathf.Clamp(lateral, -4, 4);        
    }

    public bool MirarAdelante()
    {
        RaycastHit hit;
        Ray rayoCentro = new Ray(grafico.position + Vector3.up * 0.5f, grafico.forward);

        if (Physics.Raycast(rayoCentro,out hit, distanciaVista, capaObstaculos))
        {
            return true;
        }
        return false;
    }
}
