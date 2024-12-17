using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMixManager : MonoBehaviour
{
    public Inventory inventory;
    public ItemMixList itemMixList;
    void Start()
    {
        if (inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();
        }
    }
    public bool CanCraft(ItemMixRecipe recipe)
    {
        List<ItemData> playerInventory = inventory.bagItems;

        for (int i = 0; i < recipe.requiredItems.Count; i++)
        {
            int requiredAmount = recipe.requiredQuantity[i];
            int itemCount = 0;

            foreach (var item in playerInventory)
            {
                if (item.itemName == recipe.requiredItems[i].itemName)
                {
                    itemCount += item.quantity; 
                }
            }
            if (itemCount < requiredAmount)
            {
                return false;
            }
        }
        return true;
    }
    public void CraftItem(ItemMixRecipe recipe)
    {
        if (CanCraft(recipe))
        {
            List<ItemData> playerInventory = inventory.missionItems;
            for (int i = 0; i < recipe.requiredItems.Count; i++)
            {
                int requiredAmount = recipe.requiredQuantity[i];
                for (int j = 0; j < playerInventory.Count; j++)
                {
                    if (playerInventory[j].itemName == recipe.requiredItems[i].itemName)
                    {
                        if (playerInventory[j].quantity >= requiredAmount)
                        {
                            playerInventory[j].quantity -= requiredAmount;
                            break;
                        }
                    }
                }
            }
            inventory.AddToBag(recipe.resultItem);
            inventory.inventoryUI.UpdateBagPanel(inventory.bagItems);
        }
    }
 }

