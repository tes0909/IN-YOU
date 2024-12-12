using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public List<ItemData> playerInventory = new List<ItemData>();
    public InventoryManager inventoryManager;
    public InventoryUI inventoryUI;
    public void AddItem(ItemData newItem)
    {
        playerInventory.Add(newItem);
        inventoryUI.UpdateInventoryUI(playerInventory);
    }

    public void RemoveItem(ItemData itemToRemove)
    {
        if (playerInventory.Contains(itemToRemove))
        {
            playerInventory.Remove(itemToRemove);
            inventoryUI.UpdateInventoryUI(playerInventory);
        }
    }
    private void Start()
    {
        inventoryUI.UpdateInventoryUI(playerInventory);
    }
}
