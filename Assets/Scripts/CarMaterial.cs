using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMaterial : MonoBehaviour
{
    private new Renderer renderer;
    

    [SerializeField] private List<Material> carMaterialList = new List<Material>();

    // Start is called before the first frame update
    void Start()
    {
        renderer= GetComponent<Renderer>();       

        if (gameObject.name == "Car 1"|| gameObject.name == "Car 2" || gameObject.name == "Car 3")
        {
            renderer.material = carMaterialList[Random.Range(0, 4)];
        }
        else
        {
            Transform childTransform = transform.GetChild(0);
            Renderer childRenderer= childTransform.GetComponent<Renderer>();
            childRenderer.material = carMaterialList[Random.Range(0, 4)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
