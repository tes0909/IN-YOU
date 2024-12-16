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
    public Image itemImage;
    public TMP_Text itemDescription;
    private SpriteRenderer spriteRenderer;
    private bool isPlayerNearby;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (itemData != null)
        {
            UpdateUI();
        }
    }
    public void SetData(ItemData data)
    {
        itemData = data;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (itemData != null)
        {
            itemImage.sprite = itemData.icon;
            itemDescription.text = itemData.description;
            gameObject.name = itemData.itemName;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false; 
        }
    }
    
    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F)) // F 키를 눌렀을 때
        {
            PickUpItem();
        }
    }
    
    private void PickUpItem()
    {
        ItemManager itemManager = FindObjectOfType<ItemManager>(); // 플레이어 참조
        if (itemManager != null)
        {
            //itemManager.AddItemToInventory(itemData); // 플레이어 인벤토리에 아이템 추가
            itemManager.AddItemToPlayerInventory(itemData);
            Debug.Log($"{itemData.itemName}을(를) 획득했습니다!");
            Destroy(gameObject); // 아이템 오브젝트 삭제
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
