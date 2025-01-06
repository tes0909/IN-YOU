using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public DialogueInfo currentDialogueInfo;

    public int dialogueIndex;

    public DialogueUI dialogueUI;
    
    FadeScript fade;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentDialogueInfo = DataManager.instance.dialogueInfo;
    }

    public void StartDialogue()
    {
        dialogueUI.gameObject.SetActive(true);

        dialogueUI.NextDialogue(currentDialogueInfo);
        // 첫 대화 출력
    }

    public void EndDialogue()
    {
        dialogueUI.gameObject.SetActive(false);
    }
}