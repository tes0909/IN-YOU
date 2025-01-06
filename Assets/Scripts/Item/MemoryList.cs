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
    public TextMeshProUGUI Memory;
    public TextMeshProUGUI Description;
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
            inventory.infoItems.Add(memoryItems[1]);
            inventory.infoItems.Add(memoryItems[2]);
        }
        else if (newScene.buildIndex == 2)
        {
            inventory.infoItems.Add(memoryItems[3]);
            inventory.infoItems.Add(memoryItems[4]);
        }
        else if (newScene.buildIndex == 3)
        {
            inventory.infoItems.Add(memoryItems[5]);
            inventory.infoItems.Add(memoryItems[6]);
            inventory.infoItems.Add(memoryItems[7]);
            inventory.infoItems.Add(memoryItems[8]);
        }
        else if (newScene.buildIndex == 4)
        {
            inventory.infoItems.Add(memoryItems[9]);
        }
        inventory.inventoryUI.UpdateInfoPanel(inventory.infoItems);
    }

    private void AddToInfo(List<ItemData> items)
    {
        string memoryText = "";
        string descriptionText = "";

        foreach (var item in items)
        {
            memoryText += $"{item.itemName}\n";
            descriptionText += $"{item.description}\n\n";
        }
        Memory.text = memoryText;
        Description.text = descriptionText;
    }
}