/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Cinemachine;

public class savecontorler : MonoBehaviour
{
    private string saveLocation;
    private inventoryControl inventorycontrol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
        inventorycontrol = FindObjectOfType<inventoryControl>();
        LoadGame();
    }

    public void SaveGame()
    {
        savedata saveData = new savedata 
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            mapBoundary = FindObjectOfType<CinemachineCofiner>().m_BuildingShape2D.gameObject.name,
            saveitemdata = inventorycontrol.GetInventoryItems()
        };
        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            savedata saveData = JsonUtility.FromJson<savedata>(File.ReadAllText(saveLocation));
            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;
            FindObjectOfType<CinemachineCofiner>().m_BuildingShape2D = GameObject.Find(saveData.mapBoundary).GetComponent<PolygonCollider2D>();
            inventorycontrol.SetInventoryItems(saveData.saveitemdata);
        }
        else
        {
            SaveGame();
        }
    }

}*/
