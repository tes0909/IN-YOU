using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemMixList : MonoBehaviour
{
    public List<ItemMixRecipe> itemMixRecipes = new List<ItemMixRecipe>();

    private void Awake()
    {
        Sprite campfireIcon = Resources.Load<Sprite>("Campfire36_0");
        Sprite flowerpot = Resources.Load<Sprite>("Tilemap_66");
        Sprite olddiary = Resources.Load<Sprite>("rpg_item_icon_book_132");


        itemMixRecipes.Add(new ItemMixRecipe
        {
            resultItem = new ItemData
            {
                itemName = "모닥불",
                description = "모닥불설명테스트",
                icon = campfireIcon,
                itemType = ItemType.Info,
                quantity = 1
            },
            requiredItems = new List<ItemData>
            {
                Resources.Load<ItemData>("Prefabs/Item/Data_FireWood1"),
                Resources.Load<ItemData>("Prefabs/Item/Data_Rock1")
            },
            requiredQuantity = new List<int> { 5, 3 }
        });

        itemMixRecipes.Add(new ItemMixRecipe
        {
            resultItem = new ItemData
            {
                itemName = "무덤",
                description = "무덤설명테스트",
                icon = null,
                itemType = ItemType.Info,
                quantity = 1
            },
            requiredItems = new List<ItemData>
            {
                Resources.Load<ItemData>("Prefabs/Item/Data_FireWood2"),
                Resources.Load<ItemData>("Prefabs/Item/Data_Born"),
            },
            requiredQuantity = new List<int> { 10, 14 }
        });

        itemMixRecipes.Add(new ItemMixRecipe
        {
            resultItem = new ItemData
            {
                itemName = "꽃다발",
                description = "꽃다발설명테스트",
                icon = flowerpot,
                itemType = ItemType.Info,
                quantity = 1
            },
            requiredItems = new List<ItemData>
            {
               Resources.Load<ItemData>("Prefabs/Item/Data_WhiteFlower"),
               Resources.Load<ItemData>("Prefabs/Item/Data_Chain")
            },
            requiredQuantity = new List<int> { 8, 1 }
        });

        itemMixRecipes.Add(new ItemMixRecipe
        {
            resultItem = new ItemData
            {
                itemName = "오래된 일기장",
                description = "일기장설명테스트",
                icon = olddiary,
                itemType = ItemType.Info,
                quantity = 1
            },
            requiredItems = new List<ItemData>
            {
               Resources.Load<ItemData>("Prefabs/Item/Data_DiaryPiece"),
               Resources.Load<ItemData>("Prefabs/Item/Data_Eye"),
            },
            requiredQuantity = new List<int> { 6, 2 }
        });
    }
}
