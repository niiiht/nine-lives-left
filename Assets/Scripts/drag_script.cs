    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class TapePeelUI : MonoBehaviour, IDragHandler
    {
    public GameObject currentTape;
    public GameObject nextTape;

        private float dragAmount = 0f;
        public float maxDrag = 500f;

        public bool isDone = false;

        public void OnDrag(PointerEventData eventData)
        {
            if (isDone) return;

            float moveY = eventData.delta.y;

            if (moveY > 0)
            {
                dragAmount += moveY;
            }

            float progress = dragAmount / maxDrag;

  

            if (progress >= 1f)
            {
                isDone = true;
                SwitchTape();
                Debug.Log(gameObject.name + " done!");
            }
        }
        
    void SwitchTape()
    {
        currentTape.SetActive(false);
        nextTape.SetActive(true);
        isDone = false;
    }
    }