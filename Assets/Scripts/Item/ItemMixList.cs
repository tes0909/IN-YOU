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
        Sprite grave = Resources.Load<Sprite>("ExtraObjects@64x648_150");
        Sprite flowerpot = Resources.Load<Sprite>("Tilemap_66");
        Sprite olddiary = Resources.Load<Sprite>("rpg_item_icon_book_132");


        itemMixRecipes.Add(new ItemMixRecipe
        {
            resultItem = new ItemData
            {
                itemName = "모닥불",
                description = "쉽게 꺼질 것 같이 아슬아슬하다.",
                icon = campfireIcon,
                itemType = ItemType.Info,
                quantity = 1
            },
            requiredItems = new List<ItemData>
            {
                Resources.Load<ItemData>("Prefabs/Item/Data_Branch1"),
                Resources.Load<ItemData>("Prefabs/Item/Data_Rock2")
            },
            requiredQuantity = new List<int> { 5, 3 }
        });

        itemMixRecipes.Add(new ItemMixRecipe
        {
            resultItem = new ItemData
            {
                itemName = "무덤",
                description = "있어야 할 곳은 여기가 아닌데.",
                icon = grave,
                itemType = ItemType.Info,
                quantity = 1
            },
            requiredItems = new List<ItemData>
            {
                Resources.Load<ItemData>("Prefabs/Item/Data_FireWood2"),
                Resources.Load<ItemData>("Prefabs/Item/Data_Rock1"),
            },
            requiredQuantity = new List<int> { 4, 8 }
        });

        itemMixRecipes.Add(new ItemMixRecipe
        {
            resultItem = new ItemData
            {
                itemName = "국화다발",
                description = "죽은 사람에게는 꽃을 주었던 것 같은데.",
                icon = flowerpot,
                itemType = ItemType.Info,
                quantity = 1
            },
            requiredItems = new List<ItemData>
            {
               Resources.Load<ItemData>("Prefabs/Item/Data_WhiteFlower"),
               Resources.Load<ItemData>("Prefabs/Item/Data_Chain")
            },
            requiredQuantity = new List<int> { 4, 1 }
        });

        itemMixRecipes.Add(new ItemMixRecipe
        {
            resultItem = new ItemData
            {
                itemName = "오래된 일기장",
                description = "몇 번을 반복해도 첫마디는 '미안합니다' 였다.",
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
