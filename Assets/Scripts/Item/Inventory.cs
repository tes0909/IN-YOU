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
        inventoryUI.UpdateInfoPanel(infoItems); 
    }
    public void AddToMission(ItemData newItem)
    {
        missionItems.Add(newItem);
        inventoryUI.UpdateMissionPanel(missionItems);
    }
    public void RemoveItem(ItemData itemToRemove, string panel)
    {
        switch (panel.ToLower())
        {
            case "bag":
                if (bagItems.Contains(itemToRemove))
                {
                    bagItems.Remove(itemToRemove);
                    inventoryUI.UpdateBagPanel(bagItems);
                }
                break;

            case "info":
                if (infoItems.Contains(itemToRemove))
                {
                    infoItems.Remove(itemToRemove);
                    inventoryUI.UpdateInfoPanel(infoItems);
                }
                break;

            case "mission":
                if (missionItems.Contains(itemToRemove))
                {
                    missionItems.Remove(itemToRemove);
                    inventoryUI.UpdateMissionPanel(missionItems);
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
        inventoryUI.UpdateBagPanel(bagItems);
        inventoryUI.UpdateInfoPanel(infoItems);
        inventoryUI.UpdateMissionPanel(missionItems);
    }
}

