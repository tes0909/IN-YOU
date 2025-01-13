using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : SceneBase
{
    public DialogueUI dialogueUI;

    protected override void OnSceneLoad()
    {  
       Invoke("SetStart", 2f);
       Managers.Sound.PlayBGM("1_Nostalgia");
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
