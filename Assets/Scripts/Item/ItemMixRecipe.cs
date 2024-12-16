using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemMixRecipe
{
    public ItemData resultItem;
    public List<ItemData> requiredItems;
    public List<int> requiredQuantity;
}