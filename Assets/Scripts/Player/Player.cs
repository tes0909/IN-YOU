using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public PlayerSO PlayerSOData { get; private set; }
    
    [field:Header("Animation")] 
    [field:SerializeField] public PlayerAnimationData AnimationData { get; private set; }
    
    public Animator Animator { get; private set; }
    public PlayerController input { get; private set; }
    public Rigidbody2D rigidbody2D { get; private set; }

    private PlayerStateMachine stateMachine;
    private bool isPlayerNearby;
    
    private Item item;
    public Inventory inventory;
    private UIPausePopup currentPausePopup;
    private const string filePath = "Prefabs/UI/Popup/UIPausePopup";

    
    void Awake()
    {
        AnimationData.Initialize();
        Animator = GetComponent<Animator>();
        input = GetComponent<PlayerController>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        stateMachine = new PlayerStateMachine(this);
    }

    void Start()
    {
        InventoryManager.instance.SetInventory(inventory);
        stateMachine.ChangeState(stateMachine.IdleState);
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        stateMachine.Update();
        stateMachine.HandleInput();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    public void RecoverHealth(int amount)
    {
        Debug.Log($"Health recovered by {amount}");
    }

    public void EquipItem(ItemData itemData)
    {
        Debug.Log($"Equipped {itemData.itemName}");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        item = collision.GetComponent<Item>();
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (item != null && collision.GetComponent<Item>() == item)
        {
            item = null;
        }
    }
    
    public void PickUpItem()
    {
        if (item != null && inventory != null)
        {
            inventory.AddToBag(item.itemData);
            Debug.Log($"{item.itemData.itemName}을(를) 획득했습니다!");
            Destroy(item.gameObject); // 아이템 오브젝트 삭제
        }
    }
    
    public void EscPopupInput()
    {
        if (currentPausePopup == null)
        {
            UIPausePopup prefab = Resources.Load<UIPausePopup>(filePath);
            currentPausePopup = Instantiate(prefab);
        }
        else
        {
            Destroy(currentPausePopup.gameObject);
            currentPausePopup = null;
        }
    }
    
    private void OnDrawGizmos() 
    {
        if (stateMachine != null && stateMachine.Player != null) 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(stateMachine.Player.transform.position, stateMachine.Player.PlayerSOData.AttackData.AttackRange);
        }
    }
}
