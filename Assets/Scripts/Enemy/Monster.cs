using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public int Identifier { get; private set; }

    public MonsterEntity Stat { get; private set; }
    [field: SerializeField] public MonsterCondition Condition { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }
    [field: SerializeField] public MonsterAnimationData AnimationData { get; private set; }
    public SpriteRenderer Renderer { get; private set; }

    public Animator Animator { get; private set; }

    public CharacterController Controller { get; private set; }

    private MonsterStateMachine stateMachine;

    public NavMeshAgent NavAgent { get; private set; }

    public event Action<int> OnDead;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Condition = GetComponent<MonsterCondition>();

        Condition.OnDead += Die;
    }

    public bool Initialize(int identifier, int monsterID, Vector3 spawnPoint)
    {
        Identifier = identifier;

        this.transform.position = spawnPoint;
        MonsterEntity monsterEntity = Managers.DB.Get<MonsterEntity>(monsterID);
        if (monsterEntity == null) return false;
        GameObject go = Managers.Resource.Instantiate(monsterEntity.prefabPath, this.transform);
        if (go == null) return false;

        NavAgent = GetComponentInChildren<NavMeshAgent>();
        Animator = GetComponentInChildren<Animator>();
        Renderer = GetComponentInChildren<SpriteRenderer>();

        Rigidbody.gravityScale = 0f;
        AnimationData.Initialize();
        Stat = monsterEntity;
        Condition.SetData(Stat.maxHp);
        NavAgent.speed = Stat.moveSpeed;

        stateMachine = new MonsterStateMachine(this);
        stateMachine.ChangeState(stateMachine.WanderingState);
        return true;
    }

    private void Update()
    {
        //SetTransform();
        stateMachine.Update();
    }

    private void Die()
    {
        Animator.SetTrigger("Dead");
        Invoke("DisableAfterDeath", 1);
    }

    private void DisableAfterDeath()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        if (collision == null) return;
        if (collision.transform.TryGetComponent(out PlayerCondition playerCondition))
        {
            playerCondition.TakeDamage(Stat.attackDamage);
        }
    }

    private void SetTransform()
    {
        stateMachine.Monster.transform.position = stateMachine.Monster.NavAgent.transform.position * Time.deltaTime;
    }
}
