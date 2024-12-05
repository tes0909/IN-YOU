using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;          
    public string description;       
    public Sprite icon;              
    public ItemType itemType;        

    public int attackPower;
    public int healthRecovery;
    public string additionalInfo;
}
