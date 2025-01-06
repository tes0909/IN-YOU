using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MixeditemUI : MonoBehaviour
{
    public Image resultImage;
    public TextMeshProUGUI[] resultName;
    public TextMeshProUGUI resultText;
    private void Awake()
    {
    }
    public void UpdateUI(ItemData craftedItem)
    {
        if (craftedItem != null)
        {
            gameObject.SetActive(true);
            resultImage.sprite = craftedItem.icon;
            for (int i = 0; i < resultName.Length; i++)
            {
                resultName[i].text = craftedItem.itemName;
            }
            resultText.text = craftedItem.description;
        }
        else
        {
            Debug.LogWarning("Error");
        }
    }
}
