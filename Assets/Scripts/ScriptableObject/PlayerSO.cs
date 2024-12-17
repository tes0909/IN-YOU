using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]

public class PlayerGroundData
{
    [field: Header("IdleData")]
    [field: SerializeField] [field: Range(0f, 25f)] public float BaseSpeed { get; private set; } = 3f;
    
    [field: Header("WalkData")]
    [field: SerializeField] [field: Range(0f, 2f)] public float WalkSpeedModifier { get; private set; } = 0.2f;
}

[Serializable]
public class PlayerAttackData
{
    [field: SerializeField] public int AttackDamage { get; private set; } = 10;
    [field: SerializeField] public float AttackRange { get; private set; } = 1.5f; // 범위
    [field: SerializeField] public float AttackCooltime { get; private set; } = 0.5f; // 쿨타임
    [field: SerializeField] public float AttackDuration { get; private set; } = 0.7f;
}

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
    [field: SerializeField] public PlayerAttackData AttackData { get; private set; }
}
