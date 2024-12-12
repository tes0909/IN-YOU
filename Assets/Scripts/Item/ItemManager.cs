using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<ItemData> availableItems; 
    public List<ItemData> playerInventory;
    public InventoryManager inventoryManager;

    public void AddItemToInventory(ItemData item)
    {
        playerInventory.Add(item);
        Debug.Log($"{item.itemName}AddItemComplete");
    }
    public GameObject CreateItemObject(ItemData itemData, Vector3 position)
    {
        GameObject itemObject = new GameObject(itemData.itemName);
        itemObject.AddComponent<SpriteRenderer>().sprite = itemData.icon; 
        itemObject.AddComponent<Item>().SetData(itemData); 
        itemObject.transform.position = position;
        return itemObject;
    }
    public void AddItemToPlayerInventory(ItemData item)
    {
        inventoryManager.AddItem(item);
    }
}
