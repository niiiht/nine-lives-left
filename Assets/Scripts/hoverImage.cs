using UnityEngine;
using UnityEngine.EventSystems;

public class hoverImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverButton;
    public void OnPointerEnter(PointerEventData hover)
    {
        hoverButton.SetActive(true);
        hoverButton.transform.position = transform.position;
    }

    public void OnPointerExit(PointerEventData hover)
    {
        hoverButton.SetActive(false);
    }
}