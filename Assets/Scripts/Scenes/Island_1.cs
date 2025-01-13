using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island_1 : SceneBase
{
    public DialogueUI dialogueUI;
    protected override void OnSceneLoad()
    {
        Invoke("SetStart", 1f);
        Managers.Game.CreatePlayer();
        Managers.Game.SetMonsterID(10002);

        Managers.UI.LoadSceneUI<UIGameScene>();
    }

    protected override void OnSceneLoaded()
    {
        Managers.Sound.PlayBGM("6_Lostproperty");
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
