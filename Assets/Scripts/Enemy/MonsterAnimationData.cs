using System;
using UnityEngine;
[Serializable]
public class MonsterAnimationData
{
    [SerializeField] private string wanderingParameterName = "Wandering";
    [SerializeField] private string attackParameterName = "Attack";
    [SerializeField] private string deadParameterName = "Dead";

    public int IdleParameterHash { get; private set; }
    public int WanderingParameterHash { get; private set; }
    public int AttackParameterHash { get; private set; }
    public int DeadParameterHash { get; private set; }

    public void Initialize()
    {
        Debug.Log($"{wanderingParameterName} , {attackParameterName}, {deadParameterName}");
        WanderingParameterHash = Animator.StringToHash(wanderingParameterName);
        AttackParameterHash = Animator.StringToHash(attackParameterName);
        DeadParameterHash = Animator.StringToHash(deadParameterName);
    }
}