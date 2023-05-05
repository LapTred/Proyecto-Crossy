using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggleController : MonoBehaviour
{
    public GameObject objetoActivar;

    private Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate { ActivarObjeto(); });
    }

    private void ActivarObjeto()
    {
        if (!toggle.isOn)
        {
            objetoActivar.SetActive(true);
        }
        else
        {
            objetoActivar.SetActive(false);
        }
    }
}
