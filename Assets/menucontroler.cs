using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menucontroler : MonoBehaviour
{
    public GameObject Menucanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Menucanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            Menucanvas.SetActive(!Menucanvas.activeSelf);
        }
    }
}
