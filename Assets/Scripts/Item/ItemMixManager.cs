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
        List<ItemData> playerInventory = inventory.playerInventory;

        for (int i = 0; i < recipe.requiredItems.Count; i++)
        {
            int requiredAmount = recipe.requiredQuantity[i];
            int itemCount = 0;

            foreach (var item in playerInventory)
            {
                if (item.itemName == recipe.requiredItems[i].itemName)
                {
                    itemCount += item.quantity;  // 인벤토리에서 해당 아이템의 개수를 합산
                }
            }

            // 필요한 아이템 수가 부족하면 false 반환
            if (itemCount < requiredAmount)
            {
                return false;
            }
        }

        return true;
    }

    // 아이템을 조합하는 함수
    public void CraftItem(ItemMixRecipe recipe)
    {
        if (CanCraft(recipe))
        {
            List<ItemData> playerInventory = inventory.playerInventory;

            // 필요한 아이템만큼 차감
            for (int i = 0; i < recipe.requiredItems.Count; i++)
            {
                int requiredAmount = recipe.requiredQuantity[i];
                for (int j = 0; j < playerInventory.Count; j++)
                {
                    if (playerInventory[j].itemName == recipe.requiredItems[i].itemName)
                    {
                        if (playerInventory[j].quantity >= requiredAmount)
                        {
                            playerInventory[j].quantity -= requiredAmount;  // 재료 아이템 차감
                            break;
                        }
                    }
                }
            }

            // 결과 아이템을 인벤토리에 추가
            inventory.AddItem(recipe.resultItem);

            // UI 갱신
            inventory.inventoryUI.UpdateInventoryUI(inventory.playerInventory);

            Debug.Log($"{recipe.resultItem.itemName}이(가) 조합되었습니다.");
        }
        else
        {
            Debug.Log("조합할 수 없습니다. 재료가 부족합니다.");
        }
    }
}
