using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftItemUI : MonoBehaviour
{
    public Image[] requireImages;
    public TextMeshProUGUI[] requireTexts;
    public Image resultImage;

    public void UpdateUI(ItemMixRecipe recipe)
    {
        for (int i = 0; i < requireImages.Length; i++)
        {
            requireImages[i].sprite = recipe.requiredItems[i].icon;
            requireTexts[i].text = recipe.requiredQuantity[i].ToString();
        }
        resultImage.sprite = recipe.resultItem.icon;
    }
}
