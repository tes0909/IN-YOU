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
    public PlayerCondition playerCondition;
    public Animator Animator { get; private set; }

    public CharacterController Controller { get; private set; }

    private MonsterStateMachine stateMachine;

    public NavMeshAgent NavAgent {  get; private set; }

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
        Debug.Log(identifier);
        Debug.Log(monsterID);
        Debug.Log(spawnPoint);

        this.transform.localPosition = spawnPoint;
        MonsterEntity monsterEntity = Managers.DB.Get<MonsterEntity>(monsterID);
        if (monsterEntity == null) return false;
        Debug.Log(this.transform.name);
        GameObject go = Managers.Resource.Instantiate(monsterEntity.prefabPath, this.transform);
        NavAgent = GetComponentInChildren<NavMeshAgent>();
        Animator = GetComponentInChildren<Animator>();
        Debug.Log(go.name);
        if (go == null) return false;
        Rigidbody.gravityScale = 0f;
        AnimationData.Initialize();
        Stat = monsterEntity;
        Condition.SetData(Stat.maxHp);

        stateMachine = new MonsterStateMachine(this);
        stateMachine.ChangeState(stateMachine.WanderingState);
        return true;
    }

    private void Update()
    {
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

    //public void DealDamage()
    //{
    //    playerCondition.TakeDamage(stateMachine.Monster.Stat.attackDamage);
    //}
}
