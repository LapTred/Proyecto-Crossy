using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Movimiento : MonoBehaviour
{
    //-------------Variables----------------//
    private bool isMoving = false;
    [SerializeField] private Mundo mundo;
    public Scoring scoring;
    // Carril generado
    public int          carril;
    // Desplazamiento maximo lateral
    public int          lateral;
    // Posición del personaje
    public Vector3      posObjetivo;
    // Velocidad de desplazamiento
    public float        velocidad;
    public Transform    grafico;
    // Interacción con obstáculos
    public LayerMask    capaObstaculos;
    // Distancia para detectar objetos
    public float        distanciaVista = 1;
    // Puntaje
    public int          score;
    // Tiempo de desplazamiento
    public float        tiempo;
    // Posición inicial del personaje
    private int         posicionZ = 1;
    // Velocidad de movimiento del objeto.
    public float        moveSpeed = 5f;
    // Movimiento táctil
    Vector2             currentTouchPosition;
    Vector2             previousTouchPosition;
    // Ángulo de movimiento
    private float       angle;
    // Dirección de movimiento
    private bool        directionChosen;
    // Muertes
    public bool         vivo = true;


    private void Start()
    {
        InvokeRepeating("moving", 0f, tiempo);
        score = posicionZ;
    }

    private void moving()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarPosicion();
        if (!vivo)
        {
            return;
        }

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

        // Prueba 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    previousTouchPosition = touch.position;
                    currentTouchPosition = previousTouchPosition;
                    directionChosen = false;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    currentTouchPosition = touch.position;
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }
        if (directionChosen)
        {
            if (currentTouchPosition.y >= previousTouchPosition.y)
            {
                angle = Vector2.Angle(previousTouchPosition - currentTouchPosition, Vector2.right);
                Debug.Log("Ángulo de desplazamiento: " + angle);
            }
            //Abajo
            else if (currentTouchPosition.y < previousTouchPosition.y)
            {
                angle = -(Vector2.Angle(previousTouchPosition - currentTouchPosition, Vector2.right));
                Debug.Log("Ángulo de desplazamiento: " + angle);
            }

            //Arriba
            if (angle > 45 && angle < 135 || angle == 0)
            {
                Avanzar();
                isMoving = true;
                directionChosen = false;
            }
            //Izquierda
            else if (angle <= 45 && angle > -45)
            {
                Debug.Log(angle);
                MoverLados(-1);
                isMoving = true;
                directionChosen = false;
            }
            //Derecha
            else if (angle >= 135 || angle < -135)
            {
                MoverLados(1);
                isMoving = true;
                directionChosen = false;
            }
            //Abajo
            else if (angle < -45 && angle > -135)
            {
                Retroceder();
                isMoving = true;
                directionChosen = false;
            }
        }       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(grafico.position + Vector3.up * 0.5f, grafico.position + Vector3.up * 0.5f + grafico.forward * distanciaVista);        
    }

    public void ActualizarPosicion()
    {
        if (!vivo)
        {
            return;
        }
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
        if (posicionZ > score)
        {
            score = posicionZ-1;
            scoring.AddScore(1);
        }
        if (posicionZ > carril)
        {
            carril = posicionZ;
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Car"))
        {
            vivo = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
