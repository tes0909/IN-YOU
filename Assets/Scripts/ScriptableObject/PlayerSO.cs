using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]

public class PlayerGroundData
{
    [field: SerializeField] [field: Range(0f, 25f)] public float BaseSpeed { get; private set; } = 3f;
    
    [field: Header("IdleData")]
    
    [field: Header("WalkData")]
    [field: SerializeField] [field: Range(0f, 2f)] public float WalkSpeedModifier { get; private set; } = 0.2f;
}

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
}
