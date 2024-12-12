using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject itemPrefab;
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
    }
}
