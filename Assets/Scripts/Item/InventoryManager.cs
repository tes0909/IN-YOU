using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public InventoryUI inventoryUI;
    private bool isInventoryActive = false;
    public static InventoryManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }
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
    }
    public void SetInventory(Inventory inven)
    {
        ResetInventoryUI();
        inven = inventory;       
    }

    public void ResetInventoryUI()
    {
        inventory.bagItems.Clear();
        inventoryUI.UpdateBagPanel(inventory.bagItems);

    }
}
