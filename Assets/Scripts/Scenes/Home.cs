using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : SceneBase
{
    public DialogueUI dialogueUI;
    protected override void OnSceneLoad()
    {
        Managers.Game.Init();
        Managers.Game.SetMonsterID(10001);
        //Invoke("SetStart", 1f);
        Managers.Sound.PlayBGM("9_Reminiscene");
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
