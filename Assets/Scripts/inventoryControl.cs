using System.Collections.Generic;
using UnityEngine;

public class inventoryControl : MonoBehaviour
{
    private itemDictionary itemdictionary;
    public GameObject inventPanel;
    public GameObject slotPrefab;
    public int slotCount;
    public GameObject[] itemPrefabs;
    void Start()
    {
        itemdictionary = FindObjectOfType<itemDictionary>();
        for (int i = 0; i < slotCount; i++)
        {
            Instantiate(slotPrefab, inventPanel.transform);
        }
    }
    public bool AddItem(GameObject itemPrefab)
    {
        foreach(Transform slotTransform in inventPanel.transform)
        {
            slot slot = slotTransform.GetComponent<slot>();
            if (slot != null && slot.currentItem == null)
            {
                GameObject newItem = Instantiate(itemPrefab, slot.transform);
                newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                slot.currentItem = newItem;
                return true;
            }
        }
        Debug.Log("Pe³ny ekwipunek");
        return false;
    }
    public List<saveItemData> GetInventoryItems()
    {
        List<saveItemData> invData = new List<saveItemData>();
        foreach(Transform slotTransform in inventPanel.transform)
        {
            slot slot = slotTransform.GetComponent<slot>();
            if(slot.currentItem != null)
            {
                Item item = slot.currentItem.GetComponent<Item>();
                invData.Add(new saveItemData { itemID = item.ID, slotIndex = slotTransform.GetSiblingIndex() });
            }
        }
        return invData;
    }
    public void SetInventoryItems(List<saveItemData> saveitemdata)
    {
        foreach (Transform slotTransform in inventPanel.transform)
        {
            slot s = slotTransform.GetComponent<slot>();
            if (s.currentItem != null)
            {
                Destroy(s.currentItem);
                s.currentItem = null;
            }
        }

        foreach (saveItemData data in saveitemdata)
        {
            if (data.slotIndex < slotCount)
            {
                slot slot = inventPanel.transform.GetChild(data.slotIndex).GetComponent<slot>();
                GameObject itemPrefab = itemdictionary.GetItemPrefab(data.itemID);

                if (itemPrefab != null)
                {
                    GameObject item = Instantiate(itemPrefab, slot.transform);
                    item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    slot.currentItem = item;
                }
            }
        }
    }
}
