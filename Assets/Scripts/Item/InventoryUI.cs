using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public GameObject bagPanel;
    public GameObject infoPanel;
    public GameObject missionPanel;

    public Button bagButton;
    public Button infoButton;
    public Button missionButton;

    public GameObject itemPrefab;
    public GameObject combinePanel;
    public TextMeshProUGUI combineInfoText;
    public ItemMixManager itemMixManager;

    public void Start()
    {
        bagButton.onClick.AddListener(() => ShowPanel(bagPanel));
        infoButton.onClick.AddListener(() => ShowPanel(infoPanel));
        missionButton.onClick.AddListener(() => ShowPanel(missionPanel));
        ShowPanel(bagPanel);
    }

    public void ShowPanel(GameObject panelToShow)
    {
        bagPanel.SetActive(false);
        infoPanel.SetActive(false);
        missionPanel.SetActive(false);

        panelToShow.SetActive(true);
    }
    public void UpdateBagPanel(List<ItemData> items)
    {
        UpdateInventoryUI(items, bagPanel);
    }

    public void UpdateInfoPanel(List<ItemData> items)
    {
        UpdateInventoryUI(items, infoPanel);
    }

    public void UpdateMissionPanel(List<ItemData> items)
    {
        UpdateInventoryUI(items, missionPanel);
    }

    public void UpdateInventoryUI(List<ItemData> inventory, GameObject panel)
    {
        foreach (Transform child in panel.transform)
        {
            //Destroy(child.gameObject);
        }
        foreach (ItemData item in inventory)
        {
            GameObject newItem = Instantiate(itemPrefab, panel.transform);
            newItem.name = item.itemName;

            Image itemImage = newItem.transform.Find("ItemImage").GetComponent<Image>();
            TMP_Text itemDescription = newItem.transform.Find("ImageDescription/Description").GetComponent<TMP_Text>();
            TMP_Text itemQuantityText = newItem.transform.Find("ItemImage/Quantity").GetComponent<TMP_Text>();

            //Button itemButton = newItem.GetComponentInChildren<Button>();

            if (itemImage != null && itemDescription != null && itemQuantityText != null) //itemButton != null  
            {
                itemImage.sprite = item.icon;
                itemDescription.text = item.description;
                itemQuantityText.text = item.quantity.ToString();

                //itemButton.onClick.RemoveAllListeners();
                //itemButton.onClick.AddListener(() => OnItemClicked(item));
            }
        }
    }
    public void OnItemClicked(ItemData item)
    {
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
                    combineButton.onClick.RemoveAllListeners();
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
