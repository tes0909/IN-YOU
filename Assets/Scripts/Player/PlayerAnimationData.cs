using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string walkParameterName = "Walk";

    [SerializeField] private string moveXParameterName = "moveX";
    [SerializeField] private string moveYParameterName = "moveY";

    [SerializeField] private string attackParameterName = "Attack";
    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }
    
    public int MoveXParameterHash { get; private set; }
    public int MoveYParameterHash { get; private set; }

    public int AttackParameterHash { get; private set; }

    public void Initialize()
    {
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        WalkParameterHash = Animator.StringToHash(walkParameterName);
        
        MoveXParameterHash = Animator.StringToHash(moveXParameterName);
        MoveYParameterHash = Animator.StringToHash(moveYParameterName);

        AttackParameterHash = Animator.StringToHash(attackParameterName);
    }
}
