using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum ItemType
{
    Equip,    
    Consume,  
    Info      
}
public class Item : MonoBehaviour
{
    public ItemData itemData;

    public void SetData(ItemData data)
    {
        itemData = data;
    }

    private void ApplyItemEffect(Player player)
    {
        switch (itemData.itemType)
        {
            case ItemType.Consume:
                player.RecoverHealth(itemData.healthRecovery);
                Debug.Log($"{itemData.healthRecovery} 체력을 회복했습니다!");
                break;

            case ItemType.Equip:
                player.EquipItem(itemData);
                Debug.Log($"{itemData.itemName} 장착했습니다!");
                break;

            case ItemType.Info:
                Debug.Log($"수집정보: {itemData.additionalInfo}");
                break;

            default:
                Debug.LogWarning("아이템 타입을 알 수 없습니다.");
                break;
        }
    }
}
