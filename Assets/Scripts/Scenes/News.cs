using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class News : SceneBase
{
    protected override void OnSceneLoad()
    {
        Invoke("SetStart", 3f);
    }

    protected override void OnSceneLoaded()
    {
        DialogueManager.Instance.playerNameText = GameObject.Find("Player_Name_Text").GetComponent<TextMeshProUGUI>();
        DialogueManager.Instance.playerDialogueText = GameObject.Find("Player_Dialogue_Text").GetComponent<TextMeshProUGUI>();
        DialogueManager.Instance.playerDialoguePanel = GameObject.Find("Player_Dialogue_Panel");
        DialogueManager.Instance.dialoguePrefab = GameObject.Find("News");
        DialogueManager.Instance.playerImage = GameObject.Find("Player_Image").GetComponent<Image>();
    }

    protected override void OnSceneUnload()
    {
    }
    
    void SetStart()
    {
        DialogueManager.Instance.StartDialogue();
    }
}
