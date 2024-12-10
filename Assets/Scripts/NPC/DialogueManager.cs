using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using DG.Tweening;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI playerDialogueText;
    [SerializeField] private TextMeshProUGUI npcDialogueText;
    [SerializeField] private TextMeshProUGUI npcNameText;
    
    [SerializeField] private GameObject npcDialoguePanel;
    [SerializeField] private GameObject playerDialoguePanel;
    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private Image npcHeadImage;
    [SerializeField] private Image npcBodyImage;

    private NPCData currentNPCData;
    private int playerIndex;
    private int npcIndex;
    private bool PlayerTurn;
    private bool npcAnimation = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        dialoguePanel.gameObject.SetActive(false);
    }
    
    public void StartDialogue(NPCData npcData)
    {
        currentNPCData = npcData;
        playerIndex = 0;
        npcIndex = 0;
        
        dialoguePanel.SetActive(true);

        // 이름 표시
       npcNameText.text = currentNPCData.npcName;
       playerNameText.text = currentNPCData.playerName;

       npcHeadImage.sprite = currentNPCData.npcHeadImage;
       npcBodyImage.sprite = currentNPCData.npcBodyImage;

        // 첫 대화 출력
        NextDialogue();
    }

    public void NextDialogue()
    {
        // npcAnimation 비활성화 중이라면 종료
        if (!npcAnimation)
        {
            return;
        }
        
        
        // 대화 종료
        if (npcIndex >= currentNPCData.npcDialogue.Length && playerIndex >= currentNPCData.playerDialogue.Length)
        {
            EndDialogue();
            return;
        }

        // TODO : 대화가 다 끝날시에만 넘기기
        // 대화 출력
        npcAnimation = false; // 대화 출력전 애니메이션 비활성화, 대화 출력 중 다른 대화로 넘어가는것 방지
        if (PlayerTurn)
        {
            if (playerIndex < currentNPCData.playerDialogue.Length)
            {
                playerDialogueText.text = string.Empty;
                playerDialogueText.DOText(currentNPCData.playerDialogue[playerIndex], 1f).OnComplete(() => npcAnimation = true); // 완료시에만 애니메이션 활성화
                playerNameText.text = currentNPCData.playerName;
                
                playerDialoguePanel.gameObject.SetActive(true);
                npcDialoguePanel.gameObject.SetActive(false);
                playerIndex++;
            }
        }
        else
        {
            if (npcIndex < currentNPCData.npcDialogue.Length)
            {
                npcDialogueText.text = string.Empty;
                npcDialogueText.DOText(currentNPCData.npcDialogue[npcIndex], 1f).OnComplete(() => npcAnimation = true);
                npcNameText.text = currentNPCData.npcName;
                
                npcDialoguePanel.gameObject.SetActive(true);
                playerDialoguePanel.gameObject.SetActive(false);
                npcIndex++;
            }
        }
        PlayerTurn = !PlayerTurn;
    }
    
    public void EndDialogue()
    {
        dialoguePanel.gameObject.SetActive(false);
        npcDialogueText.text = string.Empty;
        npcNameText.text = string.Empty;
        playerDialogueText.text = string.Empty;
        playerNameText.text = string.Empty;
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