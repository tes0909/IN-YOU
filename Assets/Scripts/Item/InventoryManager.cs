using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public InventoryUI inventoryUI;
    private bool isInventoryActive = false;
    public static InventoryManager instance;
    public DialogueUI dialogueUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    private void Start()
    {
        dialogueUI = FindObjectOfType<DialogueUI>();
        if(dialogueUI == null) Debug.Log("Dialogue UI not found");
        inventoryUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!DialogueActive() && Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    private bool DialogueActive()
    {
        return dialogueUI != null && dialogueUI.gameObject.activeSelf;
    }
    private void ToggleInventory()
    {
        isInventoryActive = !isInventoryActive;
        inventoryUI.gameObject.SetActive(isInventoryActive);
    }
    public void SetInventory(Player player)
    {
        ResetInventoryUI();
        player.inventory = inventory;
    }

    public void ResetInventoryUI()
    {
        inventory.bagItems.Clear();
        inventory.inventoryUI.ClearBagPanel();
        inventoryUI.UpdateBagPanel(inventory.bagItems);
    }
}
