using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : SceneBase
{
    public DialogueUI dialogueUI;
    protected override void OnSceneLoad()
    {
        Managers.UI.Init();
        Managers.Sound.Init();
        Managers.Game.Init();
        Invoke("SetStart", 1f);
        Managers.Sound.PlayBGM("10_Boss_Faintly");
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
