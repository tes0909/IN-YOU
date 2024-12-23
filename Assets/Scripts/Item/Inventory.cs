using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> bagItems = new List<ItemData>();    
    public List<ItemData> infoItems = new List<ItemData>();   
    public List<ItemData> missionItems = new List<ItemData>();
    public InventoryUI inventoryUI;
    public ItemMixManager itemMixManager;
    public void AddToBag(ItemData newItem)
    {
        bagItems.Add(newItem);
        inventoryUI.UpdateBagPanel(bagItems);
    }
    public void AddToInfo(ItemData newItem)
    {
        infoItems.Add(newItem);
         
    }
    public void AddToMission(ItemData newItem)
    {
        missionItems.Add(newItem);
        
    }
    public void RemoveItem(ItemData itemToRemove, string panel)
    {
        switch (panel.ToLower())
        {
            case "bag":
                if (bagItems.Contains(itemToRemove))
                {
                    bagItems.Remove(itemToRemove);
                   
                }
                break;

            case "info":
                if (infoItems.Contains(itemToRemove))
                {
                    infoItems.Remove(itemToRemove);
                    
                }
                break;

            case "mission":
                if (missionItems.Contains(itemToRemove))
                {
                    missionItems.Remove(itemToRemove);
                   
                }
                break;
        }
    }
    public void TryCombineItems(ItemMixRecipe recipe)
    {
        if (itemMixManager.CanCraft(recipe))
        {
            itemMixManager.CraftItem(recipe);
        }
    }
    private void Start()
    {
        if (inventoryUI == null)
        {
            inventoryUI = GetComponentInChildren<InventoryUI>();
            if (inventoryUI == null)
            {
                return;
            }
        }
    }
}

