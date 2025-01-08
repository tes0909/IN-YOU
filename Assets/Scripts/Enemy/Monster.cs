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
    public MonsterCondition Condition { get; private set; }
    public BoxCollider2D HitCollider { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }
    public MonsterAnimationData AnimationData { get; private set; }

    public Animator Animator { get; private set; }

    public CharacterController Controller { get; private set; }

    private MonsterStateMachine stateMachine;

    public NavMeshAgent NavAgent;

    public event Action<int> OnDead;

    private void Awake()
    {
        AnimationData.Initialize();
        NavAgent = GetComponent<NavMeshAgent>();
        HitCollider = GetComponent<BoxCollider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Condition = GetComponent<MonsterCondition>();

        Condition.OnDead += Die;
        stateMachine = new MonsterStateMachine(this);
    }

    public bool Initialize(int identifier, int monsterID, Vector3 spawnPoint)
    {
        Identifier = identifier;

        this.transform.localPosition = spawnPoint;
        MonsterEntity monsterEntity = Managers.DB.Get<MonsterEntity>(monsterID);
        if (monsterEntity == null) return false;
        GameObject go = Managers.Resource.Instantiate(monsterEntity.prefabPath, this.transform);
        if (go == null) return false;

        Stat = monsterEntity;
        Condition.SetData(Stat.maxHp);
        Debug.Log("!!");
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
}
