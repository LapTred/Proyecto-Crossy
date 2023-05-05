using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public float speed = 0.01f;
    public float offsetX = 0f;
    public float minX = 0f;
    public float maxX = 0.1f;

    void Update()
    {        
        offsetX = Mathf.PingPong(Time.time * speed, maxX - minX) + minX;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, 0f);
    }
}
