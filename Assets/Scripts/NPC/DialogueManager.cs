using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject dialogueUI;      
    public TMP_Text npcNameText;       
    public TMP_Text dialogueText;     

    private string[] dialogueLines;
    private int currentLineIndex = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void StartDialogue(string npcName, string[] dialogueLines)
    {
        this.dialogueLines = dialogueLines;
        currentLineIndex = 0;
        dialogueUI.SetActive(true);
        npcNameText.text = npcName;
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        dialogueUI.SetActive(false);
    }
}
