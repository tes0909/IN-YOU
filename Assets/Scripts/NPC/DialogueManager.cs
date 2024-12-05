using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Linq;
using UnityEditor.Rendering;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public TextMeshProUGUI playerText; 
    public TextMeshProUGUI npcText;
    public TextMeshProUGUI npcNameText;

    private NPCData currentNPCData;    
    private int dialogueIndex = 0;
    private int npcIndex = 0;
    private bool isPlayerTurn = true; 

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void StartDialogue(NPCData npcData)
    {
        currentNPCData = npcData;  
        dialogueIndex = 0;
        isPlayerTurn = true;

        playerText.gameObject.SetActive(false);
        npcText.gameObject.SetActive(false);

        npcNameText.text = currentNPCData.npcNames[npcIndex];

        ShowNextDialogue();
    }

    public void ShowNextDialogue()
    {
        
        if (dialogueIndex >= currentNPCData.npcDialogue.Length || dialogueIndex >= currentNPCData.playerDialogue.Length)
        {
            EndDialogue();
            return;
        }

        if (isPlayerTurn)
        {
            playerText.text = currentNPCData.playerDialogue[dialogueIndex];
            playerText.gameObject.SetActive(true);
            npcText.gameObject.SetActive(false);
        }
        else
        {
            npcText.text = currentNPCData.npcDialogue[dialogueIndex];
            npcText.gameObject.SetActive(true);
            playerText.gameObject.SetActive(false);

            dialogueIndex++; 
        }

        isPlayerTurn = !isPlayerTurn; 
    }

    public void EndDialogue()
    {
        playerText.gameObject.SetActive(false);
        npcText.gameObject.SetActive(false);

        playerText.text = string.Empty;
        npcText.text = string.Empty;
    }
}