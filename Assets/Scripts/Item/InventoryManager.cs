using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public InventoryUI inventoryUI;
    private bool isInventoryActive = false;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        inventoryUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }
    private void ToggleInventory()
    {
        isInventoryActive = !isInventoryActive;
        inventoryUI.gameObject.SetActive(isInventoryActive);
        Debug.Log(isInventoryActive);
    }
}
