using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class drag_gogles : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Transform original;
    private CanvasGroup cg;
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        original = transform.parent;
        transform.SetParent(transform.root);
         cg.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
       transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
         cg.blocksRaycasts = true;
    }
}
