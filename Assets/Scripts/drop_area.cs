
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    public GameObject target;     
    public GameObject nextPage;
    public GameObject currentPage;   
    public GameObject gogles;   

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped!");

        if (target != null && nextPage != null)
        {
            nextPage.SetActive(true);
            currentPage.SetActive(false);
            gogles.SetActive(false);

        
    }
}
}

