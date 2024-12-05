using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("Animation")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Animator Animator { get; private set; }
    public PlayerController input { get; private set; }
    //public CharacterController controller { get; private set; } rigidbody?

    void Awake()
    {
        AnimationData.Initialize();
        Animator = GetComponent<Animator>();
        input = GetComponent<PlayerController>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RecoverHealth(int amount)
    {
        Debug.Log($"Health recovered by {amount}");
    }

    public void EquipItem(ItemData itemData)
    {
        Debug.Log($"Equipped {itemData.itemName}");
    }

}
