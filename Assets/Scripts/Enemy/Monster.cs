using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public int identifier { get; private set; }

    public MonsterEntity Stat { get; private set; }
    //public Health health { get; private set; }
    public BoxCollider2D HitCollider { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }
    public PlayerAnimationData AnimationData { get; private set; }

    public Animator Animator { get; private set; }

    public CharacterController Controller { get; private set; }

    private MonsterStateMachine stateMachine;

    public NavMeshAgent navAgent;

    public bool ValidAnimator { get; private set; }

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        HitCollider = GetComponent<BoxCollider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        stateMachine = new MonsterStateMachine(this);
    }
}
