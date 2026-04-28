using UnityEngine;

public class itemCollection : MonoBehaviour
{
    private inventoryControl inventorycontrol;
    void Start()
    {
        inventorycontrol = FindObjectOfType<inventoryControl>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("item"))
        {
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                bool itemAdded = inventorycontrol.AddItem(collision.gameObject);
                Debug.Log("Dodawanie przedmiotu: " + item.name + " wynik: " + itemAdded);
                if (itemAdded)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
