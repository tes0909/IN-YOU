using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : SceneBase
{
    public DialogueUI dialogueUI;

    protected override void OnSceneLoad()
    {  
        Invoke("SetStart", 0.01f);
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
