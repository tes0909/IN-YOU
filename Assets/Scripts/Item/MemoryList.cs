using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MemoryList : MonoBehaviour
{
    public List<ItemData> memoryItems = new List<ItemData>();
    public Inventory inventory;
    private string[] itemNames;
 

    private void Awake()
    {    
        if (itemNames == null)
        {
            itemNames = new string[]
            {
            "Data_test1",
            "Data_test2",
            "Data_test3",
            "Data_test4",
            "Data_test5",
            "Data_test6",
            "Data_test7",
            "Data_test8",
            "Data_test9",
            "Data_test10",
            "Data_test11",
            "Data_test12",
            "Data_test13",
            "Data_test14"
            };
        }
        foreach (var itemName in itemNames)
        {
            memoryItems.Add(Resources.Load<ItemData>($"Prefabs/Item/{itemName}"));
        }
        SceneManager.activeSceneChanged += OnSceneChanged;
    }
  
    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        if (newScene.buildIndex == 1)
        {
            inventory.infoItems.Add(memoryItems[0]);
           
        }
        else if (newScene.buildIndex == 2)
        {
            inventory.infoItems.Add(memoryItems[1]);
            
        }
        else if (newScene.buildIndex == 3)
        {
            inventory.infoItems.Add(memoryItems[2]);
            
        }
        else if (newScene.buildIndex == 4)
        {
            inventory.infoItems.Add(memoryItems[3]);
            
        }
        else if (newScene.buildIndex == 5)
        {
            inventory.infoItems.Add(memoryItems[4]);
           
        }
        else if (newScene.buildIndex == 6)
        {
            inventory.infoItems.Add(memoryItems[5]);
           
        }
        else if (newScene.buildIndex == 7)
        {
            inventory.infoItems.Add(memoryItems[6]);
           
        }
        else if (newScene.buildIndex == 8)
        {
            inventory.infoItems.Add(memoryItems[7]);
           
        }
        else if (newScene.buildIndex == 9)
        {
            inventory.infoItems.Add(memoryItems[8]);
            inventory.infoItems.Add(memoryItems[9]);
            inventory.infoItems.Add(memoryItems[10]);
            inventory.infoItems.Add(memoryItems[11]);
            inventory.infoItems.Add(memoryItems[12]);
            inventory.infoItems.Add(memoryItems[13]);
        }
        inventory.inventoryUI.UpdateInfoPanel(inventory.infoItems);
    }
}