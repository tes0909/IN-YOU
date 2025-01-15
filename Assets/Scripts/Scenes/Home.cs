using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : SceneBase
{
    public DialogueUI dialogueUI;
    protected override void OnSceneLoad()
    {
        Invoke("SetStart", 1f);
        Managers.Game.Init();
        Managers.Sound.PlayBGM("9_Reminiscene");
        Managers.Game.SetMonsterID(10003);
    }

    protected override void OnSceneLoaded()
    {
    }

    protected override void OnSceneUnload()
    {
    }
    
    void SetStart()
    {
        DialogueManager.Instance.dialogueUI = dialogueUI;
        DialogueManager.Instance.StartDialogue();
    }
}
