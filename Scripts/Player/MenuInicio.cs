using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuInicio : MonoBehaviour
{
    DATAGM data;
    Button BTNCargarDatos;
    // Start is called before the first frame update
    void Start()
    {
        data=GetComponent< DATAGM>();
        BTNCargarDatos.interactable = (data.LoadGame());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
