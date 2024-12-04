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
    [SerializeField] private string runParameterName = "Run";

    [SerializeField] private string moveXParameterName = "moveX";
    [SerializeField] private string moveYParameterName = "moveY";
    // [SerializeField] private string lastMoveXParameterName = "lastMoveX";
    // [SerializeField] private string lastMoveYParameterName = "lastMoveY";
    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }
    
    public int MoveXParameterHash { get; private set; }
    public int MoveYParameterHash { get; private set; }
    
    // public int LastMoveXParameterHash { get; private set; }
    // public int LastMoveYParameterHash { get; private set; }

    public void Initialize()
    {
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        WalkParameterHash = Animator.StringToHash(walkParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);
        
        MoveXParameterHash = Animator.StringToHash(moveXParameterName);
        MoveYParameterHash = Animator.StringToHash(moveYParameterName);
        // LastMoveXParameterHash = Animator.StringToHash(lastMoveXParameterName);
        // LastMoveYParameterHash = Animator.StringToHash(lastMoveYParameterName);
    }
}
