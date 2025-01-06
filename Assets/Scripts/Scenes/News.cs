using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class News : SceneBase
{
    public DialogueUI dialogueUI;
    FadeScript fade;
    protected override void OnSceneLoad()
    {
        Invoke("SetStart", 3f);
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
