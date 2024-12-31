using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ItemMixManager : MonoBehaviour
{
    public Inventory inventory;
    private ItemMixRecipe recipe;
    private ItemMixList mixList;
    public CraftItemUI craftButton;
    public int needRecipeIdx;

    public TextMeshProUGUI popUpText;

    private void Start()
    {
        if (IsSceneAllowed())
        {
            if (inventory == null)
            {
                inventory = FindObjectOfType<Inventory>();
            }
            mixList = GetComponent<ItemMixList>();
            recipe = mixList.itemMixRecipes[needRecipeIdx];
            craftButton.UpdateUI(recipe);
            HidePopUp();
        }
        else
        {
            this.enabled = false;
        }
    }
    private bool IsSceneAllowed()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        string[] allowedScenes = { "Intro", "6_Island_1", "7_Island_2", "8_Bridge", "9_Home_1" };
        return System.Array.Exists(allowedScenes, name => name == currentSceneName);
    }

    public bool CanCraft()
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
                int missingAmount = requiredAmount - itemCount;
                ShowPopUp(recipe.requiredItems[i].itemName + "아이템이 " + missingAmount + "개 더 필요합니다.");
                return false;
            }
        }
        ShowPopUp("Crafting is possible!");
        return true;
        
    }
    public void CraftItem()
    {
        if (CanCraft())
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
            inventory.AddToInfo(recipe.resultItem);
        }
    }
    private void ShowPopUp(string message)
    {
        popUpText.text = message; 
        popUpText.gameObject.SetActive(true);
        Invoke("HidePopUp", 3f);
    }
    private void HidePopUp()
    {
        popUpText.gameObject.SetActive(false);
    }
}

