using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void RecoverHealth(int amount)
    {
        Debug.Log($"Health recovered by {amount}");
    }

    public void EquipItem(ItemData itemData)
    {
        Debug.Log($"Equipped {itemData.itemName}");
    }
}
