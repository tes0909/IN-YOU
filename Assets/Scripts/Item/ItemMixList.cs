using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMixList : MonoBehaviour
{
    public List<ItemMixRecipe> itemMixRecipes = new List<ItemMixRecipe>();

    void Start()
    {
        itemMixRecipes.Add(new ItemMixRecipe
        {
            resultItem = new ItemData
            {
                itemName = "횃불",
                description = "불완전한 기억을 되살리는 빛",
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

        itemMixRecipes.Add(new ItemMixRecipe
        {
            resultItem = new ItemData
            {
                itemName = "무덤",
                description = "너를 내 안에 묻었으니, 이건 네 무덤이 아니야.",
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

        itemMixRecipes.Add(new ItemMixRecipe
        {
            resultItem = new ItemData
            {
                itemName = "꽃다발",
                description = "죽은 사람에게는 꽃을 주었던 것 같은데, 이거면 괜찮겠지",
                icon = null,
                itemType = ItemType.Info,
                attackPower = 0,
                healthRecovery = 0,
                quantity = 1
            },
            requiredItems = new List<ItemData>
            {
                new ItemData { itemName = "하얀 꽃" }
            },
            requiredQuantity = new List<int> { 10 }
        });

        itemMixRecipes.Add(new ItemMixRecipe
        {
            resultItem = new ItemData
            {
                itemName = "오래된 일기장",
                description = "낡고 닳아 어지러운 마음, 접고 접어.",
                icon = null,
                itemType = ItemType.Info,
                attackPower = 0,
                healthRecovery = 0,
                quantity = 1
            },
            requiredItems = new List<ItemData>
            {
                new ItemData { itemName = "찢겨진 조각" }
            },
            requiredQuantity = new List<int> { 6 }
        });
    }
}
