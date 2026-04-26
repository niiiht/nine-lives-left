using UnityEngine;
using UnityEngine.EventSystems;
public class hover_over : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    public GameObject hoverPanel;
    public GameObject nextPage;
    public GameObject currentPage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverPanel.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      
       if (nextPage != null)
        {
              nextPage.SetActive(true);
             currentPage.SetActive(false);
             hoverPanel.SetActive(false);
            
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverPanel.SetActive(false);
    }

}
