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
    private float DOTextDelay = 1f;
    private int playerIndex;
    private int npcIndex;
    private bool PlayerTurn;
    private bool canTalking = true;

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
        // 타이핑중
        if (!canTalking)
        {
            playerDialogueText.DOComplete();
            npcDialogueText.DOComplete();
            return;
        }
        
        // 대화 종료
        if (npcIndex >= currentNPCData.npcDialogue.Length && playerIndex >= currentNPCData.playerDialogue.Length)
        {
            EndDialogue();
            return;
        }

        // 대화 출력
        canTalking = false; // 대화 출력전 애니메이션 비활성화, 대화 출력 중 다른 대화로 넘어가는것 방지
        if (PlayerTurn)
        {
            if (playerIndex < currentNPCData.playerDialogue.Length)
            {
                playerDialogueText.text = string.Empty;
                playerDialogueText.DOText(currentNPCData.playerDialogue[playerIndex], DOTextDelay)
                    .OnComplete(() => canTalking = true); // 완료시에만 애니메이션 활성화
                
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
                npcDialogueText.DOText(currentNPCData.npcDialogue[npcIndex], DOTextDelay).OnComplete(() => canTalking = true);
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
        npcDialogueText.text = string.Empty;
        npcNameText.text = string.Empty;
        playerDialogueText.text = string.Empty;
        playerNameText.text = string.Empty;
        canTalking = true; 
        PlayerTurn = false;
        dialoguePanel.gameObject.SetActive(false);
    }
    
    public bool DialogueActive()
    {
        return dialoguePanel.activeSelf;
    }
}