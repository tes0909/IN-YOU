using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject itemPrefab;
    public GameObject combinePanel;
    public TextMeshProUGUI combineInfoText;
    public ItemMixManager itemMixManager;


    public void UpdateInventoryUI(List<ItemData> inventory)
    {
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (ItemData item in inventory)
        {
            GameObject newItem = Instantiate(itemPrefab, inventoryPanel.transform);
            newItem.name = item.itemName;

            Image itemImage = newItem.GetComponentInChildren<Image>();
            TMP_Text itemDescription = newItem.GetComponentInChildren<TMP_Text>();
            Button itemButton = newItem.GetComponentInChildren<Button>();
            TMP_Text itemQuantityText = newItem.GetComponentInChildren<TMP_Text>();

            if (itemImage != null && itemDescription != null && itemButton != null && itemQuantityText != null)
            {
                itemImage.sprite = item.icon;
                itemDescription.text = item.description;
                itemButton.onClick.AddListener(() => OnItemClicked(item));
                itemQuantityText.text = item.quantity.ToString();
            }
        }
    }
    public void OnItemClicked(ItemData item)
    {
        // 아이템이 조합 가능한지 확인
        foreach (var recipe in itemMixManager.itemMixList.itemMixRecipes)
        {
            if (recipe.requiredItems.Exists(r => r.itemName == item.itemName))
            {
                if (itemMixManager.CanCraft(recipe))
                {
                    combinePanel.SetActive(true);
                    combineInfoText.text = $"{item.itemName}을(를) 조합할 수 있습니다!";
                    Button combineButton = combinePanel.GetComponentInChildren<Button>();
                    combineButton.onClick.AddListener(() => CombineItem(recipe));
                    return;
                }
            }
        }
        combineInfoText.text = "조합할 수 없습니다.";
    }

    private void CombineItem(ItemMixRecipe recipe)
    {
        itemMixManager.CraftItem(recipe);
        combinePanel.SetActive(false);
    }
}
