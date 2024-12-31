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
            
        }
        foreach (ItemData item in inventory)
        {
            GameObject newItem = Instantiate(itemPrefab, panel.transform);
            newItem.name = item.itemName;

            Image itemImage = newItem.transform.Find("ItemImage").GetComponent<Image>();
            TMP_Text itemDescription = newItem.transform.Find("ImageDescription/Description").GetComponent<TMP_Text>();
            TMP_Text itemQuantityText = newItem.transform.Find("ItemImage/Quantity").GetComponent<TMP_Text>();

            if (itemImage != null && itemDescription != null && itemQuantityText != null) 
            {
                itemImage.sprite = item.icon;
                itemDescription.text = item.description;
                itemQuantityText.text = item.quantity.ToString();

            }
        }
    }
   
}
