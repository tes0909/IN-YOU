using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island_2 : SceneBase
{
    public DialogueUI dialogueUI;
    protected override void OnSceneLoad()
    {
        Invoke("SetStart", 1f);
        Managers.Game.CreatePlayer();

        Managers.UI.LoadSceneUI<UIGameScene>();
    }

    protected override void OnSceneLoaded()
    {
        Managers.Sound.PlayBGM("BGM");
        Managers.Sound.SetMasterVolume();
        Managers.Resource.Instantiate("Map/IslandMap");
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
