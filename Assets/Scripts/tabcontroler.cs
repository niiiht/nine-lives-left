using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tabcontroler : MonoBehaviour
{
    public Image[] tabimages;
    public GameObject[] pages;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activeTab(0);
    }

    public void activeTab(int tabNo)
    {
        for(int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabimages[i].color = Color.grey;
        }
        pages[tabNo].SetActive(true);
        tabimages[tabNo].color = Color.white;
    }
}
