using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemData> playerInventory;
    public InventoryUI inventoryUI;
    private bool isInventoryActive = false;

    private void Start()
    {
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

    public void AddItem(ItemData item)
    {
        playerInventory.Add(item);
        inventoryUI.UpdateInventoryUI(playerInventory);
        Debug.Log($"{item.itemName}이 인벤토리에 추가되었습니다!");
    }
   
}
