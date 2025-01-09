using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : SceneBase
{
    public DialogueUI dialogueUI;

    protected override void OnSceneLoad()
    {  
        Invoke("SetStart", 0.1f);
        Managers.Sound.PlayBGM("2_Fever");
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
