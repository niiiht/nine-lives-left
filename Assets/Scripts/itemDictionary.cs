using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class itemDictionary : MonoBehaviour
{
    public List<Item> itemPrefabs;
    private Dictionary<int, GameObject> ItemDictionary;
    private void Awake()
    {
        ItemDictionary = new Dictionary<int, GameObject>();
        for (int i = 0; i < itemPrefabs.Count; i++)
        {
            if (itemPrefabs[i] != null)
            {
                itemPrefabs[i].ID = i + 1;
            }
        }
        foreach (Item item in itemPrefabs)
        {
            if (item != null)
            {
                ItemDictionary[item.ID] = item.gameObject;
            }
        }
    }
    public GameObject GetItemPrefab(int itemID)
    {
        ItemDictionary.TryGetValue(itemID, out GameObject prefab);
        if (prefab == null)
        {
            Debug.Log($"item o id {itemID} nie istnieje");
        }
        return prefab;
    }
}