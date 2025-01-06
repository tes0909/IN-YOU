using System;
using UnityEngine;
[Serializable]
public class MonsterAnimationData
{
    [SerializeField] private string wanderingParameterName = "Wandering";
    [SerializeField] private string attackParameterName = "Attack";
    public int IdleParameterHash { get; private set; }
    public int WanderingParameterHash { get; private set; }
    public int AttackParameterHash { get; private set; }

    public void Initialize()
    {
        WanderingParameterHash = Animator.StringToHash(wanderingParameterName);
        AttackParameterHash = Animator.StringToHash(attackParameterName);
    }
}