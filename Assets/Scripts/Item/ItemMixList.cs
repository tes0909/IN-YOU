using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMixList : MonoBehaviour
{
    public List<ItemMixRecipe> itemMixRecipes = new List<ItemMixRecipe>();

    void Start()
    {
        // 예시 횃불 조합 아이템 레시피 추가
        itemMixRecipes.Add(new ItemMixRecipe
        {
            resultItem = new ItemData
            {
                itemName = "횃불",
                description = "어두운 곳을 밝히는 횃불",
                icon = null,
                itemType = ItemType.Info,
                attackPower = 0,
                healthRecovery = 0,
                quantity = 1
            },
            requiredItems = new List<ItemData>
            {
                new ItemData { itemName = "나뭇가지" },
                new ItemData { itemName = "돌" }
            },
            requiredQuantity = new List<int> { 5, 3 }
        });

        // 무덤 조합 아이템 레시피 추가
        itemMixRecipes.Add(new ItemMixRecipe
        {
            resultItem = new ItemData
            {
                itemName = "무덤",
                description = "죽은 자를 묻는 무덤",
                icon = null,
                itemType = ItemType.Info,
                attackPower = 0,
                healthRecovery = 0,
                quantity = 1
            },
            requiredItems = new List<ItemData>
            {
                new ItemData { itemName = "돌" },
                new ItemData { itemName = "나뭇가지" },
                new ItemData { itemName = "꽃" }
            },
            requiredQuantity = new List<int> { 10, 1, 1 }
        });
    }
}
