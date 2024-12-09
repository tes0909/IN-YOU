using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    // public TextMeshProUGUI playerText; 
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI npcNameText;
    [SerializeField] private GameObject dialoguePanel;

    private NPCData currentNPCData;    
    private int dialogueIndex;
    // private int npcIndex = 0;
    // private bool isPlayerTurn = true; 

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        dialoguePanel.SetActive(false);
    }

    
    public void StartDialogue(NPCData npcData)
    {
        currentNPCData = npcData;
        dialogueIndex = 0;
        
        dialoguePanel.SetActive(true);

        // NPC 이름 표시
        npcNameText.text = currentNPCData.npcName;

        // 첫 대화 출력
        NextDialogue();
    }

    public void NextDialogue()
    {
        // 대화 종료
        if (dialogueIndex >= currentNPCData.dialogueLines.Length)
        {
            EndDialogue();
            return;
        }

        // 대화 출력
        dialogueText.text = currentNPCData.dialogueLines[dialogueIndex];
        dialogueText.gameObject.SetActive(true);

        dialogueIndex++;
    }
    
    public void EndDialogue()
    {
        dialoguePanel.gameObject.SetActive(false);
        dialogueText.text = string.Empty;
        npcNameText.text = string.Empty;
    }
    
    public bool DialogueActive()
    {
        return dialoguePanel.activeSelf;
    }
    
    // public void StartDialogue(NPCData npcData)
    // {
    //     currentNPCData = npcData;  
    //     dialogueIndex = 0;
    //     isPlayerTurn = true;
    //
    //     playerText.gameObject.SetActive(false);
    //     npcText.gameObject.SetActive(false);
    //
    //     npcNameText.text = currentNPCData.npcNames[npcIndex];
    //
    //     ShowNextDialogue();
    // }
    
    // public void ShowNextDialogue()
    // {
    //     if (dialogueIndex >= currentNPCData.npcDialogue.Length || dialogueIndex >= currentNPCData.playerDialogue.Length)
    //     {
    //         EndDialogue();
    //         return;
    //     }
    //
    //     if (isPlayerTurn)
    //     {
    //         playerText.text = currentNPCData.playerDialogue[dialogueIndex];
    //         playerText.gameObject.SetActive(true);
    //         npcText.gameObject.SetActive(false);
    //     }
    //     else
    //     {
    //         npcText.text = currentNPCData.npcDialogue[dialogueIndex];
    //         npcText.gameObject.SetActive(true);
    //         playerText.gameObject.SetActive(false);
    //
    //         dialogueIndex++; 
    //     }
    //
    //     isPlayerTurn = !isPlayerTurn; 
    // }

    // public void EndDialogue()
    // {
    //     playerText.gameObject.SetActive(false);
    //     npcText.gameObject.SetActive(false);
    //
    //     playerText.text = string.Empty;
    //     npcText.text = string.Empty;
    // }
}