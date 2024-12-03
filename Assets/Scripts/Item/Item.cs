using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum ItemType
{
    Equip,    
    Consume,  
    Info      
}
public class Item : MonoBehaviour
{
    public ItemData itemData;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (itemData != null)
        {
            UpdateVisual();
        }
        else
        {
            Debug.LogWarning("ItemData is not assigned on " + gameObject.name);
        }
    }
    public void SetData(ItemData data)
    {
        itemData = data;
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (itemData != null)
        {
            spriteRenderer.sprite = itemData.icon;
            gameObject.name = itemData.itemName;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"{itemData.itemName}GetItem");

            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                ApplyItemEffect(player);
            }
            Destroy(gameObject);
        }
    }
    private void ApplyItemEffect(Player player)
    {
        switch (itemData.itemType)
        {
            case ItemType.Consume:
                player.RecoverHealth(itemData.healthRecovery);
                Debug.Log($"Recovered {itemData.healthRecovery} HP!");
                break;

            case ItemType.Equip:
                player.EquipItem(itemData);
                Debug.Log($"{itemData.itemName} has been equipped!");
                break;

            case ItemType.Info:
                Debug.Log($"Collected information: {itemData.additionalInfo}");
                break;

            default:
                Debug.LogWarning("Unknown item type.");
                break;
        }
    }
}
