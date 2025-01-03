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
    private void Update()
    {
        gameObject.SetActive(true);
    }
    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        List<ItemData> itemsToAdd = new List<ItemData>();

        if (newScene.buildIndex == 1)
        {
            itemsToAdd.Add(memoryItems[0]);
            itemsToAdd.Add(memoryItems[1]);
            itemsToAdd.Add(memoryItems[2]);
        }
        else if (newScene.buildIndex == 2)
        {
            itemsToAdd.Add(memoryItems[3]);
            itemsToAdd.Add(memoryItems[4]);
        }
        else if (newScene.buildIndex == 3)
        {
            itemsToAdd.Add(memoryItems[5]);
            itemsToAdd.Add(memoryItems[6]);
            itemsToAdd.Add(memoryItems[7]);
            itemsToAdd.Add(memoryItems[8]);
        }
        else if (newScene.buildIndex == 4)
        {
            itemsToAdd.Add(memoryItems[9]);
        }
        
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