using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : SceneBase
{
    public DialogueUI dialogueUI;
    protected override void OnSceneLoad()
    {
        Invoke("SetStart", 1f);
        Managers.Game.Init();
        Managers.Game.SetMonsterID(10001);
        Managers.Sound.PlayBGM("8_Fragment");
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
